using System.Collections.Generic;
using ArcadiaStats.Application.Queries.TodoLists.ExportTodos;

namespace ArcadiaStats.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
