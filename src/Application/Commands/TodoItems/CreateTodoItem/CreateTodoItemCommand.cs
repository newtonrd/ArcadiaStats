using MediatR;

namespace ArcadiaStats.Application.Commands.TodoItems.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }
}
