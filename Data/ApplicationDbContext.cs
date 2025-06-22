using Microsoft.EntityFrameworkCore;
using JobApplicationMVC.Models;

namespace JobApplicationMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
