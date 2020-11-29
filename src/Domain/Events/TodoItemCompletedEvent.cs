using ArcadiaStats.Domain.Common;
using ArcadiaStats.Domain.Entities;

namespace ArcadiaStats.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
