using ArcadiaStats.Domain.Common;
using ArcadiaStats.Domain.Entities;

namespace ArcadiaStats.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
