using InternDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternDemo.Controllers
{
    [Authorize]
    public class EmployeeRoleController: Controller

    {
        private readonly EmployeeDbContext _context;

        public EmployeeRoleController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeRole
        public async Task<IActionResult> Index()
        {
            var employeeContext = _context.EmployeeRoles.Include(e => e.ApplicationUser).Include(e => e.RoleType);
            return View(await employeeContext.ToListAsync());
        }

        // GET: EmployeeRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.ApplicationUser)
                .Include(e => e.RoleType)
                .FirstOrDefaultAsync(m => m.EmployeeRoleId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // GET: EmployeeRole/Create
        public IActionResult Create()
        {
            ViewBag.Id = new SelectList(_context.AspNetUser.ToList(), "Id", "Fullname");
            ViewBag.RoleType = new SelectList(_context.RoleTypes.ToList(), "RoleId", "RoleName");
            return View();
        }

        // POST: EmployeeRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeRoleId,Id,RoleId")] EmployeeRoles employeeRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Fullname", employeeRole.Id);
            ViewData["RoleId"] = new SelectList(_context.RoleTypes, "RoleId", "RoleName", employeeRole.RoleId);
            return View(employeeRole);
        }

        // GET: EmployeeRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRole == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Fullname", employeeRole.Id);
            ViewData["RoleId"] = new SelectList(_context.RoleTypes, "RoleId", "RoleName", employeeRole.RoleId);
            return View(employeeRole);
        }

        // POST: EmployeeRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeRoleId,Id,RoleId")] EmployeeRoles employeeRole)
        {
            if (id != employeeRole.EmployeeRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRoleExists(employeeRole.EmployeeRoleId))
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
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Fullname", employeeRole.Id);
            ViewData["RoleId"] = new SelectList(_context.RoleTypes, "RoleId", "RoleName", employeeRole.RoleId);
            return View(employeeRole);
        }

        // GET: EmployeeRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.ApplicationUser)
                .Include(e => e.RoleType)
                .FirstOrDefaultAsync(m => m.EmployeeRoleId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // POST: EmployeeRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(employeeRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRoleExists(int id)
        {
            return _context.EmployeeRoles.Any(e => e.EmployeeRoleId == id);
        }
    }
}
