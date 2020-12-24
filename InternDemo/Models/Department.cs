using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        [Display(Name = "Department name")]    
        [Required(ErrorMessage = "Please enter department name")]
        public string Title { get; set; }
    }
}
