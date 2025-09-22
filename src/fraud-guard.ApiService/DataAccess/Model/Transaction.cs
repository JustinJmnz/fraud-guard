using System.ComponentModel.DataAnnotations;

namespace FraudGuard.ApiService.DataAccess.Model
{
    public class Transaction
    {
        [Key]
        public required Guid TransactionId { get; set; }

        [Required]
        public required decimal Amount { get; set; }

        [Required]
        public required DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(19)]
        public required string CreditCardNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public required string CardHolderName { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Status { get; set; }

        [Required]
        public required Location Location { get; set; }
    }
}
