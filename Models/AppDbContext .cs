using Microsoft.EntityFrameworkCore;

namespace MoroccoCities.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base
            (options)
        {          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>()
                .HasOne(c => c.Region)
                .WithMany(r => r.Provinces)
                .HasForeignKey(c => c.RegionId);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Region)
                .WithMany(r => r.Cities)
                .HasForeignKey(c => c.RegionId);

        }
        public DbSet<City>City{ get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Province> Province { get; set; }
    }
}
