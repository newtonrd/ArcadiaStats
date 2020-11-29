using MediatR;

namespace ArcadiaStats.Application.Commands.TodoItems.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
