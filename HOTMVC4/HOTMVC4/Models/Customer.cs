using System.ComponentModel.DataAnnotations;

namespace HOTMVC4.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be between 1 and 20 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [RegularExpression(@"(?<nr>\([0-9]{3}\)\s+[0-9]{3}\-[0-9]{4})", ErrorMessage = "Invalid Phone# format: (555) 555-5555")]
        public string? PhoneNumber { get; set; }
    }
}
