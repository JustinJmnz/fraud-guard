using Bogus.DataSets;
using FraudGuard.ApiService.DataAccess.Model;

namespace FraudGuard.ApiService.DataAccess.Development
{
    public class DataSeeder
    {
        private readonly FraudGuardContext _context;
        private readonly Random _random = new Random();
        private readonly Bogus.Faker _faker = new Bogus.Faker();

        public DataSeeder(FraudGuardContext context)
        {
            _context = context;
            Bogus.Randomizer.Seed = new Random(12345);
        }

        public async Task SeedAsync()
        {
            // Check if the database already has data
            if (_context.Transactions.Any())
            {
                return; // Skip seeding if data already exists
            }

            // Generate bogus data
            var transactions = Enumerable.Range(1, 1000)
                .Select(i => new Transaction
                {
                    TransactionId = Guid.NewGuid(),
                    Amount = _random.Next(10, 1000) * 0.01M, // Amount in dollars
                    TransactionDate = DateTime.Now.AddDays(-_random.Next(365)).ToUniversalTime(),
                    CreditCardNumber = _faker.Finance.CreditCardNumber(CardType.Visa),
                    CardHolderName = _faker.Name.FullName(),
                    Status = GetRandomTransactionStatus(),
                    Location = new Location
                    {
                        Zip = _faker.Address.ZipCode(),
                        City = _faker.Address.City(),
                        State = _faker.Address.State(),
                        Country = _faker.Address.Country()
                    }
                })
                .ToList();

            // Seed data transactionally
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Transactions.AddRangeAsync(transactions);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private string GetRandomTransactionStatus()
        {
            var statuses = new[] { "Success", "Failed", "Pending", "Declined", "Fraud" };
            return statuses[_random.Next(statuses.Length)];
        }
    }
}
