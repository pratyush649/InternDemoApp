using InternDemo.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    public class EmployeeRoles
    {

        [Key]
        public int EmployeeRoleId { get; set; }
      
        [Display(Name = "Role Type")]
        public virtual int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleType RoleType { get; set; }

        [Display(Name = "Employee Name")]
        public virtual int Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
