using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("JobPosition")]
    public class JobPosition
    {
        [Key]
        public int JobPositionId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Position name")]
        [Required(ErrorMessage = "Please enter job position")]
        public string Position { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Please enter Grade")]
        public string Grade { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Please enter Grade")]
        public String LevelNo { get; set; }
    }
}
