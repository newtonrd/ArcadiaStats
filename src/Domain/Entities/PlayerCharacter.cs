using ArcadiaStats.Domain.Common;
using ArcadiaStats.Domain.Enums;

namespace ArcadiaStats.Domain.Entities
{
    public class PlayerCharacter : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DndClass Class { get; set; }
    }
}
