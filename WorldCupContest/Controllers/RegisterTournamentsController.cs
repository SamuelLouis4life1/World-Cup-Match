using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldCupContest.Data;
using WorldCupContest.Models;

namespace WorldCupContest.Controllers
{
    public class RegisterTournamentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterTournamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegisterTournaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterTournaments.ToListAsync());
        }

        // GET: RegisterTournaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTournament = await _context.RegisterTournaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerTournament == null)
            {
                return NotFound();
            }

            return View(registerTournament);
        }

        // GET: RegisterTournaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterTournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournamentName,TournamentDate")] RegisterTournament registerTournament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerTournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerTournament);
        }

        // GET: RegisterTournaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTournament = await _context.RegisterTournaments.FindAsync(id);
            if (registerTournament == null)
            {
                return NotFound();
            }
            return View(registerTournament);
        }

        // POST: RegisterTournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournamentName,TournamentDate")] RegisterTournament registerTournament)
        {
            if (id != registerTournament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerTournament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterTournamentExists(registerTournament.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registerTournament);
        }

        // GET: RegisterTournaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTournament = await _context.RegisterTournaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerTournament == null)
            {
                return NotFound();
            }

            return View(registerTournament);
        }

        // POST: RegisterTournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerTournament = await _context.RegisterTournaments.FindAsync(id);
            _context.RegisterTournaments.Remove(registerTournament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterTournamentExists(int id)
        {
            return _context.RegisterTournaments.Any(e => e.Id == id);
        }
    }
}
