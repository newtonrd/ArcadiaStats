using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaStats.Application.Common.Interfaces;
using ArcadiaStats.Application.Common.Mappings;
using ArcadiaStats.Application.Common.Models;
using ArcadiaStats.Application.Queries.TodoItems.GetTodoItemsWithPagination;
using ArcadiaStats.Application.Queries.TodoLists.GetTodos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Queries.Handlers
{
    public class TodoItemsQueryHandler : 
        IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TodoItemDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(x => x.ListId == request.ListId)
                .OrderBy(x => x.Title)
                .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}