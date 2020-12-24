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
    public class EmployeeTaskListController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeTaskListController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeTaskList
        public async Task<IActionResult> Index()
        {
            var employeeContext = _context.EmployeeTask.Include(e => e.Employee).Include(e => e.Project).Include(e => e.TaskList);
            return View(await employeeContext.ToListAsync());
        }

        // GET: EmployeeTaskList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTaskList = await _context.EmployeeTask
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .Include(e => e.TaskList)
                .FirstOrDefaultAsync(m => m.EmployeeTaskListId == id);
            if (employeeTaskList == null)
            {
                return NotFound();
            }

            return View(employeeTaskList);
        }

        // GET: EmployeeTaskList/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["TaskListId"] = new SelectList(_context.TaskLists, "TaskListId", "TaskName");
            return View();
        }

        // POST: EmployeeTaskList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeTaskListId,EmployeeId,TaskListId,ProjectId")] EmployeeTaskList employeeTaskList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTaskList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname", employeeTaskList.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeTaskList.ProjectId);
            ViewData["TaskListId"] = new SelectList(_context.TaskLists, "TaskListId", "TaskName", employeeTaskList.TaskListId);
            return View(employeeTaskList);
        }

        //public async Task<IActionResult> GetEmployeeProject()
        //{
        //    var employeeContext=
        //}


        // GET: EmployeeTaskList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTaskList = await _context.EmployeeTask.FindAsync(id);
            if (employeeTaskList == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Fullname", employeeTaskList.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeTaskList.ProjectId);
            ViewData["TaskListId"] = new SelectList(_context.TaskLists, "TaskListId", "TaskName", employeeTaskList.TaskListId);
            return View(employeeTaskList);
        }

        // POST: EmployeeTaskList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeTaskListId,EmployeeId,TaskListId,ProjectId")] EmployeeTaskList employeeTaskList)
        {
            if (id != employeeTaskList.EmployeeTaskListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTaskList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTaskListExists(employeeTaskList.EmployeeTaskListId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FristName", employeeTaskList.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeTaskList.ProjectId);
            ViewData["TaskListId"] = new SelectList(_context.TaskLists, "TaskListId", "TaskName", employeeTaskList.TaskListId);
            return View(employeeTaskList);
        }

        // GET: EmployeeTaskList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTaskList = await _context.EmployeeTask
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .Include(e => e.TaskList)
                .FirstOrDefaultAsync(m => m.EmployeeTaskListId == id);
            if (employeeTaskList == null)
            {
                return NotFound();
            }

            return View(employeeTaskList);
        }

        // POST: EmployeeTaskList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTaskList = await _context.EmployeeTask.FindAsync(id);
            _context.EmployeeTask.Remove(employeeTaskList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTaskListExists(int id)
        {
            return _context.EmployeeTask.Any(e => e.EmployeeTaskListId == id);
        }
    }
}
