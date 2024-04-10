using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Domain.Entities
{
    public class Team : Entity
    {
        private List<Player> _players = new();
        private Team()
        {
        
        }
        public Team(string name, string country, DateTime createdDate)
        {
            Name = name;
            Country = country;
            CreatedDate = createdDate;
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public IReadOnlyList<Player> Players { get => _players.AsReadOnly(); }
    }
}
