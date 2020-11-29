namespace ArcadiaStats.Application.Queries.TodoLists.ExportTodos
{
    public class ExportTodosVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}