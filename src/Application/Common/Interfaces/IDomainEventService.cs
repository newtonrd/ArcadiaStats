using ArcadiaStats.Domain.Common;
using System.Threading.Tasks;

namespace ArcadiaStats.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
