using ArcadiaStats.Application.Common.Mappings;
using ArcadiaStats.Domain.Entities;
using System.Collections.Generic;

namespace ArcadiaStats.Application.Queries.TodoLists.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
