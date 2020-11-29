using System.Collections.Generic;
using MediatR;

namespace ArcadiaStats.Application.Queries.Players.GetPlayers
{
    public class GetPlayersQuery: IRequest<List<PlayerVm>>
    {
    }
}