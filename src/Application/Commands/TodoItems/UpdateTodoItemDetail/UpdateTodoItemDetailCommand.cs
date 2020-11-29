using ArcadiaStats.Domain.Enums;
using MediatR;

namespace ArcadiaStats.Application.Commands.TodoItems.UpdateTodoItemDetail
{
    public class UpdateTodoItemDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public PriorityLevel Priority { get; set; }

        public string Note { get; set; }
    }
}
