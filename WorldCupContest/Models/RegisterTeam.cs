﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupContest.Models
{
    public class RegisterTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public RegisterTeam RegisteredTeam { get; set; }

        public RegisterTeam()
        {
        }

        public RegisterTeam(int id, string teamName)
        {
            Id = id;
            TeamName = teamName;
        }
    }
}
