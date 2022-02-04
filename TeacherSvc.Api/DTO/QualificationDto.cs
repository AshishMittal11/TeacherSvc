namespace TeacherSvc.Api.DTO
{
    public class QualificationDto
    {
        public int Id { get; set; }
        public int PassingYear { get; set; }
        public string SchoolUnivName { get; set; }
        public string Subjects { get; set; }
        public float Percentage { get; set; }
        public string Division { get; set; }
        public string ModifiedOn { get; set; }
        public string CreatedOn { get; set; }
    }
}
