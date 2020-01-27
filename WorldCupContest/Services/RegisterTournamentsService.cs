using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupContest.Data;
using WorldCupContest.Models;

namespace WorldCupContest.Services
{
    public class RegisterTournamentsService
    {
        private readonly ApplicationDbContext _context;

        public RegisterTournamentsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<RegisterTournament> FindAll ()
        {
            return _context.RegisterTournaments.ToList();
        }
    }
}
