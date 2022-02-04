using Microsoft.EntityFrameworkCore;
using TeacherSvc.Api.Models;

namespace TeacherSvc.Api.Database
{
    public class TeacherContext : DbContext
    {
        // constructor....
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options) { }


        // entities....
        public DbSet<Teacher> TeacherSet { get; set; }
        public DbSet<Qualification> QualificationSet { get; set; }
    }
}
