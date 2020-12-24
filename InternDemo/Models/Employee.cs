
using InternDemo.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("Employee")]
    public class Employee
    {
        
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Email")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FristName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Middle name")]       
        public string MiddleName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

 
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please select date of birth")]
        [DataType(DataType.Date)]
        [DateLessThanOrEqualToToday]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of Join")]
        [Required(ErrorMessage = "Please select date of join")]
        [DataType(DataType.Date)]
        [DateLessThanOrEqualToToday]        
        public DateTime DateOfJoin { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        // Foreign key   
        [Display(Name = "Gender")]
        public virtual int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [Required(ErrorMessage = "Please select marital status")]
        // Foreign key   
        [Display(Name = "Marital Status")]
        public virtual int MaritalId { get; set; }
        [ForeignKey("MaritalId")]
        public virtual Marital Marital { get; set; }

        [Required(ErrorMessage = "Please select Job position")]
        // Foreign key   
        [Display(Name = "Job Position")]
        public virtual int JobPositionId { get; set; }
        [ForeignKey("JobPositionId")]
        public virtual JobPosition JobPosition { get; set; }
        
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUsers { get; set; }
        public string Fullname
        {
            get
            {
                return FristName + " " + MiddleName + " "+ LastName;
            }
        }


    } 
    public class DateLessThanOrEqualToToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Date value should not be a future date";
        }

        protected override ValidationResult IsValid(object objValue,ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();           

            if (dateValue.Date > DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }







}
