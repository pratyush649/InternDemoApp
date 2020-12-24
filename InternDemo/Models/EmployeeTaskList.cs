using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("EmployeeTaskList")]
    public class EmployeeTaskList
    {
        [Key]
        public int EmployeeTaskListId { get; set; }
        
        [Required(ErrorMessage = "Please select employee name")]
        // Foreign key   
        [Display(Name = "Employee")]
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [Required(ErrorMessage = "Please select Task to assign")]
        // Foreign key   
        [Display(Name = "TaskList")]
        public virtual int TaskListId { get; set; }
        [ForeignKey("TaskListId")]
        public virtual TaskList TaskList { get; set; }

        [Required(ErrorMessage = "Please select project to assign")]
        // Foreign key   
        [Display(Name = "Project")]
        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

    }
}
