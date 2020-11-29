using ArcadiaStats.Application.Queries.TodoLists.ExportTodos;
using CsvHelper.Configuration;
using System.Globalization;

namespace ArcadiaStats.Infrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
