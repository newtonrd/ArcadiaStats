using System.Threading.Tasks;
using ArcadiaStats.Application.PlayerCharacters.Commands.CreatePlayer;
using ArcadiaStats.Application.Queries.Players.GetPlayers;
using Microsoft.AspNetCore.Mvc;

namespace ArcadiaStats.WebUI.Controllers
{
    public class PlayersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PlayerVm>> GetAll()
        {
            return await Mediator.Send(new GetPlayersQuery());
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<PlayerVm>> GetById(int id)
        // {
        //     return await Mediator.Send(new );
        // }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlayerCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}