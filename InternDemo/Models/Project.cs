


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Project name")]
        [Required(ErrorMessage = "Please enter project name")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Project Status")]
        [Required(ErrorMessage = "Please enter project status")]
        public string Status { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select project start date")]
        [DataType(DataType.Date)]
        [DateLessThanOrEqualToToday]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please select project end date")]
        [DataType(DataType.Date)]
      
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please select department")]
        // Foreign key   
        [Display(Name = "Department")]
        public virtual int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        
      
    }
   




}
