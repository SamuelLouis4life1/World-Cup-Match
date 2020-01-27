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
    public class MatchupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matchups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matchups.ToListAsync());
        }

        // GET: Matchups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchup = await _context.Matchups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchup == null)
            {
                return NotFound();
            }

            return View(matchup);
        }

        // GET: Matchups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matchups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamQuantity,MatchupDate,FirstTeamName,SecondTimeName")] Matchup matchup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchup);
        }

        // GET: Matchups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchup = await _context.Matchups.FindAsync(id);
            if (matchup == null)
            {
                return NotFound();
            }
            return View(matchup);
        }

        // POST: Matchups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamQuantity,MatchupDate,FirstTeamName,SecondTimeName")] Matchup matchup)
        {
            if (id != matchup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchupExists(matchup.Id))
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
            return View(matchup);
        }

        // GET: Matchups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchup = await _context.Matchups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchup == null)
            {
                return NotFound();
            }

            return View(matchup);
        }

        // POST: Matchups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchup = await _context.Matchups.FindAsync(id);
            _context.Matchups.Remove(matchup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchupExists(int id)
        {
            return _context.Matchups.Any(e => e.Id == id);
        }
    }
}
