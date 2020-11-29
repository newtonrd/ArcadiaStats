using MediatR;

namespace ArcadiaStats.Application.PlayerCharacters.Commands.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}