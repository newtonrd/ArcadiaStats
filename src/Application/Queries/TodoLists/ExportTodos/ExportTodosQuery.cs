using MediatR;

namespace ArcadiaStats.Application.Queries.TodoLists.ExportTodos
{
    public class ExportTodosQuery : IRequest<ExportTodosVm>
    {
        public int ListId { get; set; }
    }
}
