using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("EmployeeContacts")]
    public class EmployeeContacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Mobile Number")]
        [Column(TypeName = "nvarchar(250)")]
        [Range(0, long.MaxValue, ErrorMessage = "It must be a positive number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter resident number")]
        [Display(Name = "Resident Number")]
        [Column(TypeName = "nvarchar(250)")]
        [Range(0, long.MaxValue, ErrorMessage = "It must be a positive number")]
        public string ResidentNo { get; set; }

        [Required(ErrorMessage = "Please select Employee")]
        // Foreign key   
        [Display(Name = "Employee")]
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }

   
}
