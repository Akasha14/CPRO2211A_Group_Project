using System.ComponentModel.DataAnnotations;

namespace GroupProject_POS_System.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int EmployeeID { get; set; } // Foreign Key.
        public int? CustomerID { get; set; } // Foreign Key.
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentType { get; set; } // Cash or Card.

        // Navigation Properties
        public Employee Employee { get; set; }
        public Customer? Customer { get; set; } // Optional, for walk ins etc.
        public ICollection<TransactionDetail>? TransactionDetails { get; set; }
    }
}
