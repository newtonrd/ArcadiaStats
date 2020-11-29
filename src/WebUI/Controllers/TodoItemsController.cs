using ArcadiaStats.Application.Common.Models;
using ArcadiaStats.Application.Commands.TodoItems.CreateTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.DeleteTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.UpdateTodoItem;
using ArcadiaStats.Application.Commands.TodoItems.UpdateTodoItemDetail;
using ArcadiaStats.Application.Queries.TodoItems.GetTodoItemsWithPagination;
using ArcadiaStats.Application.Queries.TodoLists.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArcadiaStats.WebUI.Controllers
{
    [Authorize]
    public class TodoItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TodoItemDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
