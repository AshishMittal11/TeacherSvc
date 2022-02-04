using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherSvc.Api.Models
{
    [Table("Qualification", Schema = "dbo")]
    public class Qualification : TeacherBaseModel
    {
        [Required]
        public int PassingYear { get; set; }

        [StringLength(100), Required]
        public string SchoolUnivName { get; set; }

        [StringLength(100), Required]
        public string Subjects { get; set; }

        [Required]
        public float Percentage { get; set; }

        [Required, StringLength(100)]
        public string Division { get; set; }

        public int TeacherId { get; set; }
    }
}
