using System;

namespace TeacherSvc.Api.DTO
{
    public class TeacherDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string CurrentAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string ModifiedOn { get; set; }
        public string CreatedOn { get; set; }
    }
}
