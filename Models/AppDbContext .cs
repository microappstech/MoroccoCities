using Microsoft.EntityFrameworkCore;

namespace MoroccoCities.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base
            (options)
        {          
        }
        public DbSet<City>City{ get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Street> Street { get; set; }
    }
}
