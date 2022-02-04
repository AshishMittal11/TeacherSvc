using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherSvc.Api.Models
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher : TeacherBaseModel
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string HomePhone { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Qualification { get; set; }

        [StringLength(500)]
        public string CurrentAddress { get; set; }

        [StringLength(500)]
        public string ResidentialAddress { get; set; }
    }
}
