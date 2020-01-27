using System;
using System.Collections.Generic;
using System.Text;
using WorldCupContest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WorldCupContest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<RegisterTeam> RegisterTeams { get; set; }
        public DbSet<RegisterTournament> RegisterTournaments { get; set; }
    }
}
