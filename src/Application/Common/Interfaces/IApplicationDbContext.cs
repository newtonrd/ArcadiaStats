using ArcadiaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaStats.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Campaign> Campaigns { get; set; }
        DbSet<PlayerCharacter> PlayerCharacters { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
