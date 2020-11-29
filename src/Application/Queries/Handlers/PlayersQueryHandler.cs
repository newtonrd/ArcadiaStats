using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaStats.Application.Common.Interfaces;
using ArcadiaStats.Application.Common.Mappings;
using ArcadiaStats.Application.Queries.Players.GetPlayers;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Handlers
{
    public class PlayersQueryHandler :
        IRequestHandler<GetPlayersQuery, List<PlayerVm>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayersQueryHandler> _logger;

        public PlayersQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper,
            ILogger<PlayersQueryHandler> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PlayerVm>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Players
                .ProjectToListAsync<PlayerVm>(_mapper.ConfigurationProvider);        
        }
    }
}