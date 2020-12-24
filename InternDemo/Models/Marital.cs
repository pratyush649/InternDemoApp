using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("Marital")]
    public class Marital
    {
        [Key]
        public int MaritalId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Title { get; set; }
    }
}
