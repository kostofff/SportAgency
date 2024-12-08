using Microsoft.EntityFrameworkCore;
using SportAgency.Entities;

namespace SportAgency
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Club> Clubs { get; set; }
    }
}
