using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        public int TeamQuantity { get; set; }
        public DateTime MatchupDate { get; set; }
        public RegisterTeam RegisteredTeam { get; set; }
        public RegisterTournament RegisteredTournament { get; set; }
        public ICollection<RegisterTeam> RegisterTeams { get; set; } = new List<RegisterTeam>();

        public Matchup()
        {
        }

        public Matchup(int id, int teamQuantity, DateTime matchupDate)
        {
            Id = id;
            TeamQuantity = teamQuantity;
            MatchupDate = matchupDate;
        }

        public void AddRegisteredTeam(RegisterTeam registeredTeam)
        {
            RegisterTeams.Add(registeredTeam);
        }

        public void RemoveRegisteredTeam(RegisterTeam registeredTeam)
        {
            RegisterTeams.Remove(registeredTeam);
        }
    }
}
