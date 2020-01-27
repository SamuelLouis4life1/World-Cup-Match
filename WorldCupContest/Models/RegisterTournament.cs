using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class RegisterTournament
    {
        public int Id { get; set; }
        [Required]
        public string TournamentName { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }
        public string AwayHomeGame { get; set; }
        public ICollection<RegisterTeam> RegisterTeams { get; set; } = new List<RegisterTeam>();
        public ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

        public RegisterTournament()
        {
        }

        public RegisterTournament(int id, string tournamentName, DateTime tournamentDate, string awayHomeGame)
        {
            Id = id;
            TournamentName = tournamentName;
            TournamentDate = tournamentDate;
            AwayHomeGame = awayHomeGame;
        }

        public void AddRegisterTeam(RegisterTeam registerTeam)
        {
            RegisterTeams.Add(registerTeam);
        }

        public void RemoveRegisterTeam(RegisterTeam registerTeam)
        {
            RegisterTeams.Remove(registerTeam);
        }

        public void AddMatchup(Matchup matchup)
        {
            Matchups.Add(matchup);
        }

        public void RemoveMatchup(Matchup matchup)
        {
            Matchups.Remove(matchup);
        }

    }
}
