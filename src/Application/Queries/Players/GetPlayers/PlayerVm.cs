using ArcadiaStats.Application.Common.Mappings;
using ArcadiaStats.Domain.Entities;
using AutoMapper;

namespace ArcadiaStats.Application.Queries.Players.GetPlayers
{
    public class PlayerVm : IMapFrom<Player>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerVm>();        
        }
    }
}