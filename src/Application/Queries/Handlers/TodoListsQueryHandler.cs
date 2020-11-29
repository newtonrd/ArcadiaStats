using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaStats.Application.Common.Interfaces;
using ArcadiaStats.Application.Queries.TodoLists.etTodos;
using ArcadiaStats.Application.Queries.TodoLists.ExportTodos;
using ArcadiaStats.Application.Queries.TodoLists.GetTodos;
using ArcadiaStats.Domain.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Handlers
{
    public class TodoListsQueryHandler : 
        IRequestHandler<GetTodosQuery, TodosVm>,
        IRequestHandler<ExportTodosQuery, ExportTodosVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public TodoListsQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper,
            ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return new TodosVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Lists = await _context.TodoLists
                    .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }

        public async Task<ExportTodosVm> Handle(ExportTodosQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportTodosVm();

            var records = await _context.TodoItems
                    .Where(t => t.ListId == request.ListId)
                    .ProjectTo<TodoItemRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildTodoItemsFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TodoItems.csv";

            return await Task.FromResult(vm);
        }

    }
}