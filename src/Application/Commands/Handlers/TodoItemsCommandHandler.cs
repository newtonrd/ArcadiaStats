using System.Threading;
using System.Threading.Tasks;
using ArcadiaStats.Application.Commands.TodoItems.CreateTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.DeleteTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.UpdateTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.UpdateTodoItemDetail;
using ArcadiaStats.Application.Common.Exceptions;
using ArcadiaStats.Application.Common.Interfaces;
using ArcadiaStats.Domain.Entities;
using ArcadiaStats.Domain.Events;
using MediatR;

namespace ArcadiaStats.Application.Commands.Handlers
{
    public class TodoItemCommandHandler : 
        IRequestHandler<CreateTodoItemCommand, int>,
        IRequestHandler<DeleteTodoItemCommand>,
        IRequestHandler<UpdateTodoItemCommand>,
        IRequestHandler<UpdateTodoItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public TodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.TodoItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    
        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.Title = request.Title;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    
        public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Priority = request.Priority;
            entity.Note = request.Note;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

    