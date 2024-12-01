using System.ComponentModel.DataAnnotations;

namespace GroupProject_POS_System.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Navigation Property
        public ICollection<TransactionDetail>? TransactionDetails { get; set; }
    }
}
