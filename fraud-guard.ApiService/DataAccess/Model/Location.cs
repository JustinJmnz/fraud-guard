using System.ComponentModel.DataAnnotations;

namespace FraudGuard.ApiService.DataAccess.Model
{
    public class Location
    {
        [MaxLength(100)]
        public string? City { get; set; }

        [Required]
        [MaxLength(100)]
        public required string State { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Country { get; set; }
    }
}
