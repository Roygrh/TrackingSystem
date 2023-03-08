using Microsoft.EntityFrameworkCore;
using TrackingSystem.Models;

namespace TrackingSystem.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidate { get; set; }
    }
}
