using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class RegisterTeam
    {
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int Score { get; set; }
        public RegisterTeam RegisteredTeam { get; set; }

        public RegisterTeam()
        {
        }

        public RegisterTeam(int id, string teamName, int score)
        {
            Id = id;
            TeamName = teamName;
            Score = score;
        }
    }
}
