using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        [Required]
        public int TeamQuantity { get; set; }
        public DateTime MatchupDate { get; set; }
        [Required]
        public string  FirstTeamName { get; set; }
        [Required]
        public string SecondTimeName { get; set; }
        public RegisterTeam RegisteredTeam { get; set; }
        public RegisterTournament RegisteredTournament { get; set; }
        public ICollection<RegisterTeam> RegisterTeams { get; set; } = new List<RegisterTeam>();

        public Matchup()
        {
        }

        public Matchup(int id, int teamQuantity, DateTime matchupDate, string firstTeamName, string secondTimeName)
        {
            Id = id;
            TeamQuantity = teamQuantity;
            MatchupDate = matchupDate;
            FirstTeamName = firstTeamName;
            SecondTimeName = secondTimeName;
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
