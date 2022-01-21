using Microsoft.EntityFrameworkCore;
using TeacherSvc.Api.Models;

namespace TeacherSvc.Api.Database
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options)
        {

        }


        public DbSet<Teacher> TeacherSet { get; set; }
    }
}
