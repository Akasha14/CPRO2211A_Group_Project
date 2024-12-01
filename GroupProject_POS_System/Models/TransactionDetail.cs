using System.ComponentModel.DataAnnotations;

namespace GroupProject_POS_System.Models
{
    public class TransactionDetail
    {
        public int TransactionDetailID { get; set; }
        public int TransactionID { get; set; } // Foreign Key.
        public int ServiceID { get; set; } // Foreign Key.

        [Required]
        public int Quantity { get; set; } 
        public decimal Subtotal { get; set; }

        // Navigation Properties
        public Transaction Transaction { get; set; }
        public Service Service { get; set; }
    }
}
