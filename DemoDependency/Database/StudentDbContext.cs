using DemoDependency.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDependency.Database
{
    public class StudentDbContext : DbContext 
    {
        public StudentDbContext(DbContextOptions option):base(option)
        {
            // DbContextOptions is a class that contains configuration information for the DbContext.
            // configures the context to connect to a specific database using the provided options.
        }
        public DbSet<Student> Students { get; set; }
    }
}
