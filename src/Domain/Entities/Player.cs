
using System.Collections.Generic;

namespace ArcadiaStats.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<PlayerCharacter> PlayerCharacters { get; private set; } = new List<PlayerCharacter>();
    }
}

