using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("EmployeeAddress")]
    public class EmployeeAddress
    { 
        [Key]
        public int AddressId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "City name")]
        [Required(ErrorMessage = "Please enter city name")]

        public string City { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "District name")]
        [Required(ErrorMessage = "Please enter district name")]
        public string District { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Ward Number")]
        [Range(0, int.MaxValue, ErrorMessage = "It must be a positive number")]
        [Required(ErrorMessage = "Please enter ward number")]
        public int WardNo { get; set; }

        [Required(ErrorMessage = "Please select Employee")]
        // Foreign key   
        [Display(Name = "Employee")]
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
