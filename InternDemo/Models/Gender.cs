using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDemo.Models
{
    [Table("Gender")]
    public class Gender
    {

        [Key]
        public int GenderId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Title { get; set; }
    }
}
