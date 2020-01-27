using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class RegisterTournament
    {
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public DateTime TournamentDate { get; set; }
        public ICollection<RegisterTeam> RegisterTeams { get; set; } = new List<RegisterTeam>();
        public ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

        public RegisterTournament()
        {
        }

        public RegisterTournament(int id, string tournamentName, DateTime tournamentDate)
        {
            Id = id;
            TournamentName = tournamentName;
            TournamentDate = tournamentDate;
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
