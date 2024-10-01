using Microsoft.EntityFrameworkCore;
using WebAPIApp.Models;

namespace WebAPIApp.Data
{
    public class CustomDbContext: DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options):base(options)
        {
                
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
