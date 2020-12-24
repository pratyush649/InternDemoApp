using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace InternDemo.Controllers
{
    [Authorize]
    public class EmployeeContactController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeContactController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeContact
        public async Task<IActionResult> Index()
        {
            var employeeContext = _context.EmployeeContacts.Include(e => e.Employee);
            return View(await employeeContext.ToListAsync());
        }

        // GET: EmployeeContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContacts = await _context.EmployeeContacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (employeeContacts == null)
            {
                return NotFound();
            }

            return View(employeeContacts);
        }

        // GET: EmployeeContact/Create
        public IActionResult Create()
        {
            
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname");
            
            return View();
        }

        // POST: EmployeeContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,MobileNumber,ResidentNo,EmployeeId")] EmployeeContacts employeeContacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeContacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname", employeeContacts.EmployeeId);
            return View(employeeContacts);
        }

        // GET: EmployeeContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContacts = await _context.EmployeeContacts.FindAsync(id);
            if (employeeContacts == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FristName", employeeContacts.EmployeeId);
            return View(employeeContacts);
        }

        // POST: EmployeeContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,MobileNumber,ResidentNo,EmployeeId")] EmployeeContacts employeeContacts)
        {
            if (id != employeeContacts.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeContacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeContactsExists(employeeContacts.ContactId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FristName", employeeContacts.EmployeeId);
            return View(employeeContacts);
        }

        // GET: EmployeeContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContacts = await _context.EmployeeContacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (employeeContacts == null)
            {
                return NotFound();
            }

            return View(employeeContacts);
        }

        // POST: EmployeeContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeContacts = await _context.EmployeeContacts.FindAsync(id);
            _context.EmployeeContacts.Remove(employeeContacts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeContactsExists(int id)
        {
            return _context.EmployeeContacts.Any(e => e.ContactId == id);
        }
    }
}
