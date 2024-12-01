using System.ComponentModel.DataAnnotations;


namespace GroupProject_POS_System.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? Email { get; set; } // Optional.

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
