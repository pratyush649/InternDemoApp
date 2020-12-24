using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternDemo.Models;
using InternDemo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace InternDemo.Controllers
{
    
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employee 
        public async Task<IActionResult> Index()
        {
            var employeeContext = _context.Employees.Include(e => e.Gender).Include(e => e.JobPosition).Include(e => e.Marital).Include(e => e.ApplicationUsers);
            return View(await employeeContext.ToListAsync());
        }

        //GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees
                .Include(e => e.Gender)
                .Include(e => e.JobPosition)
                .Include(e => e.Marital)
                 .Include(e => e.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            //var employee = db.context.FromSql(
            //    @"select * from Employee as e 
            //        inner join AspNetUsers as a on e.Id=a.Id 
            //        inner join EmployeeTaskList as et on et.EmployeeId=e.EmployeeId
            //        inner join Project as p on p.ProjectId=et.ProjectId
            //        inner join TaskList as t on t.TaskListId=et.TaskListId
            //        where e.Id=id"
            //    );

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create

        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title");
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Email");
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "JobPositionId", "Position");
            ViewData["MaritalId"] = new SelectList(_context.Maritals, "MaritalId", "Title");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FristName,MiddleName,LastName,Email,Password,DateOfBirth,DateOfJoin,GenderId,MaritalId,JobPositionId,Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Email", employee.Id);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "JobPositionId", "Position", employee.JobPositionId);
            ViewData["MaritalId"] = new SelectList(_context.Maritals, "MaritalId", "Title", employee.MaritalId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Email", employee.Id);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "JobPositionId", "Position", employee.JobPositionId);
            ViewData["MaritalId"] = new SelectList(_context.Maritals, "MaritalId", "Title", employee.MaritalId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FristName,MiddleName,LastName,Email,DateOfBirth,DateOfJoin,GenderId,MaritalId,JobPositionId,Id")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["Id"] = new SelectList(_context.AspNetUser, "Id", "Email", employee.Id);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "JobPositionId", "Position", employee.JobPositionId);
            ViewData["MaritalId"] = new SelectList(_context.Maritals, "MaritalId", "Title", employee.MaritalId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Gender)
                .Include(e => e.JobPosition)
                .Include(e => e.Marital)
                .Include(e => e.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
