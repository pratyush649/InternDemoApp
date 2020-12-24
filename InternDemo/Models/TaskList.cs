using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("TaskList")]
    public class TaskList
    {
        [Key]
        public int TaskListId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Task name")]
        [Required(ErrorMessage = "Please enter task name")]
        public string TaskName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Project status")]
        [Required(ErrorMessage = "Please enter project status")]
        public string TaskStatus { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Project priority")]
        [Required(ErrorMessage = "Please enter priority")]
        public string Priority { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select project start date")]
        [DataType(DataType.Date)]
        [DateLessThanOrEqualToToday]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please select project end date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
