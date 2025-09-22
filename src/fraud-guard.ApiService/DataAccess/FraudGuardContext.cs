using Microsoft.EntityFrameworkCore;
using FraudGuard.ApiService.DataAccess.Model;

namespace FraudGuard.ApiService.DataAccess
{
    public class FraudGuardContext : DbContext
    {
        public FraudGuardContext(DbContextOptions<FraudGuardContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Location>()
                .HasKey(location => new { location.Zip, location.State });
        }
    }
}
