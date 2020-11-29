using System.Threading;
using System.Threading.Tasks;
using ArcadiaStats.Application.Common.Interfaces;
using ArcadiaStats.Application.PlayerCharacters.Commands.CreatePlayer;
using ArcadiaStats.Domain.Entities;
using MediatR;

namespace ArcadiaStats.Application.Commands.Handlers
{
    public class PlayersCommandHandler :
        IRequestHandler<CreatePlayerCommand, int>

    {
        private readonly IApplicationDbContext _context;

        public PlayersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Player
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            _context.Players.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}