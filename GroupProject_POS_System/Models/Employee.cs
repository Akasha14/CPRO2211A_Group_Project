using System.ComponentModel.DataAnnotations;

namespace GroupProject_POS_System.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required] 
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; } 

        [Required]
        [EmailAddress] // Validates email format.
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
