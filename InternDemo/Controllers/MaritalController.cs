using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternDemo.Models;

namespace InternDemo.Controllers
{
    public class MaritalController : Controller
    {
        private readonly EmployeeDbContext _context;

        public MaritalController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Marital
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maritals.ToListAsync());
        }

        // GET: Marital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marital = await _context.Maritals
                .FirstOrDefaultAsync(m => m.MaritalId == id);
            if (marital == null)
            {
                return NotFound();
            }

            return View(marital);
        }

        // GET: Marital/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marital/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaritalId,Title")] Marital marital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marital);
        }

        // GET: Marital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marital = await _context.Maritals.FindAsync(id);
            if (marital == null)
            {
                return NotFound();
            }
            return View(marital);
        }

        // POST: Marital/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaritalId,Title")] Marital marital)
        {
            if (id != marital.MaritalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaritalExists(marital.MaritalId))
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
            return View(marital);
        }

        // GET: Marital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marital = await _context.Maritals
                .FirstOrDefaultAsync(m => m.MaritalId == id);
            if (marital == null)
            {
                return NotFound();
            }

            return View(marital);
        }

        // POST: Marital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marital = await _context.Maritals.FindAsync(id);
            _context.Maritals.Remove(marital);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaritalExists(int id)
        {
            return _context.Maritals.Any(e => e.MaritalId == id);
        }
    }
}
