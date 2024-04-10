using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamManager.Domain.Entities
{
    public class Player : Entity
    {
        private Player()
        {

        }
        public Player(Person personalData, string country, int? points = 0)
        {
            PersonalData = personalData;
            Country = country;
            Points = points.Value;
        }
        public Person PersonalData { get; private set; }
        public int? Points { get; set; }
        public string? Country {  get; set; }
        public int? TeamId { get; private set; }
        public void AddToTeam(int teamId)
        {
            if (teamId <= 0) return;
            TeamId = teamId;
        }
        public void LeaveTeam()
        {
            TeamId = 0;
        }
        public void ChangePoints(int points)
        {
            if (points < 0) return;
            Points = points;
        }

    }
}
