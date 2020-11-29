using ArcadiaStats.Application.Common.Mappings;
using ArcadiaStats.Domain.Entities;

namespace ArcadiaStats.Application.Queries.TodoLists.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
