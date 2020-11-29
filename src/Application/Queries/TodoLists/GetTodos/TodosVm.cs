using System.Collections.Generic;

namespace ArcadiaStats.Application.Queries.TodoLists.GetTodos
{
    public class TodosVm
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<TodoListDto> Lists { get; set; }
    }
}
