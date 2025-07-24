using Microsoft.EntityFrameworkCore;
using FraudGuard.ApiService.DataAccess.Model;

namespace FraudGuard.ApiService.DataAccess
{
    public class FraudGuardContext : DbContext
    {
        public int Id { get; set; }

        public FraudGuardContext(DbContextOptions<FraudGuardContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
