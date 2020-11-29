using System;
using System.Collections.Generic;
using ArcadiaStats.Domain.Common;

namespace ArcadiaStats.Domain.Entities
{
    public class Campaign : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}

        public IList<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();
    }
}