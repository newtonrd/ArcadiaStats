using MediatR;
using ArcadiaStats.Application.Queries.TodoLists.GetTodos;

namespace ArcadiaStats.Application.Queries.TodoLists.etTodos
{
    public class GetTodosQuery : IRequest<TodosVm> {}
}
