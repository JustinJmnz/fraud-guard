using System.ComponentModel.DataAnnotations;

namespace FraudGuard.ApiService.DataAccess.Model
{
    public class Location
    {
        [Required]
        [MaxLength(10)]
        public required string Zip { get; set; }

        [Required]
        [MaxLength(100)]
        public required string City { get; set; }

        [Required]
        [MaxLength(100)]
        public required string State { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Country { get; set; }
    }
}
