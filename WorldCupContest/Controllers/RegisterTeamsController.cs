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
    public class RegisterTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegisterTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterTeams.ToListAsync());
        }

        // GET: RegisterTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTeam = await _context.RegisterTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerTeam == null)
            {
                return NotFound();
            }

            return View(registerTeam);
        }

        // GET: RegisterTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName")] RegisterTeam registerTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerTeam);
        }

        // GET: RegisterTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTeam = await _context.RegisterTeams.FindAsync(id);
            if (registerTeam == null)
            {
                return NotFound();
            }
            return View(registerTeam);
        }

        // POST: RegisterTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName")] RegisterTeam registerTeam)
        {
            if (id != registerTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterTeamExists(registerTeam.Id))
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
            return View(registerTeam);
        }

        // GET: RegisterTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerTeam = await _context.RegisterTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerTeam == null)
            {
                return NotFound();
            }

            return View(registerTeam);
        }

        // POST: RegisterTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerTeam = await _context.RegisterTeams.FindAsync(id);
            _context.RegisterTeams.Remove(registerTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterTeamExists(int id)
        {
            return _context.RegisterTeams.Any(e => e.Id == id);
        }
    }
}
