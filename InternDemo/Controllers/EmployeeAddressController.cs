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
    public class EmployeeAddressController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeAddressController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeAddress
        public async Task<IActionResult> Index()
        {
            var employeeContext = _context.EmployeeAddress.Include(e => e.Employee);
            return View(await employeeContext.ToListAsync());
        }

        // GET: EmployeeAddress/Details/5
      

        // GET: EmployeeAddress/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname");
            return View(new EmployeeAddress());
        }

        // POST: EmployeeAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,City,District,WardNo,EmployeeId")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname", employeeAddress.EmployeeId);
            return View(employeeAddress);
        }

        //GET: EmployeeAddress/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAddress = await _context.EmployeeAddress.FindAsync(id);
            if (employeeAddress == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname", employeeAddress.EmployeeId);
            return View(employeeAddress);
        }

        // POST: EmployeeTaskList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,City,District,WardNo,EmployeeId")] EmployeeAddress employeeAddress)

        {
            if (id != employeeAddress.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAddressExists(employeeAddress.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FristName", employeeAddress.EmployeeId);
            
            return View(employeeAddress);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAddress = await _context.EmployeeAddress
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (employeeAddress == null)
            {
                return NotFound();
            }

            return View(employeeAddress);
        }

        // POST: EmployeeAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeAddress = await _context.EmployeeAddress.FindAsync(id);
            _context.EmployeeAddress.Remove(employeeAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAddressExists(int id)
        {
            return _context.EmployeeAddress.Any(e => e.AddressId == id);
        }
    }
}
