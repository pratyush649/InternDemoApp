using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternDemo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternDemo.Models
{
    public class EmployeeDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeContacts> EmployeeContacts { get; set; }
        public DbSet<EmployeeTaskList> EmployeeTask { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Marital> Maritals { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<ApplicationUser> AspNetUser { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
