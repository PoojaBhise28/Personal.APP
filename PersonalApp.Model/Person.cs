using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Model
{
    [Table("PersonalDetails")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="FirstName is Requried")]
        [MaxLength(50)]
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "mobileNumber is Requried")]
        [MaxLength(10)]
        public string mobileNumber { get; set; }=string.Empty; 
        public string phoneNumber { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
