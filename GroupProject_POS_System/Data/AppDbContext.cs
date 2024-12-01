using GroupProject_POS_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using BCrypt.Net; // Dependency for hashing.

namespace GroupProject_POS_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.Subtotal)
                .HasPrecision(18, 2);



            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Alice",
                    LastName = "Kosh",
                    Email = "alice.kosh@example.com",
                    PasswordHash = HashPassword("alicepassword"), // Hash password for security.
                    Role = "Staff"
                },

                new Employee 
                { 
                    EmployeeID = 2, 
                    FirstName = "Bob", 
                    LastName = "Mash",
                    Email = "bob.mash@example.com",
                    PasswordHash = HashPassword("bobpassword"),
                    Role = "Admin" 
                }
            );

            // Seed Services
            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceID = 1, ServiceName = "Men's Haircut", Category = "Haircut", Price = 25.00M },
                new Service { ServiceID = 2, ServiceName = "Women's Haircut", Category = "Haircut", Price = 35.00M },
                new Service { ServiceID = 3, ServiceName = "Men's Beard Trim", Category = "Haircut", Price = 15.00M },
                new Service { ServiceID = 4, ServiceName = "Manicure", Category = "Manicure", Price = 30.00M },
                new Service { ServiceID = 5, ServiceName = "Pedicure", Category = "Pedicure", Price = 40.00M },
                new Service { ServiceID = 6, ServiceName = "Gel Manicure", Category = "Manicure", Price = 40.00M },
                new Service { ServiceID = 7, ServiceName = "French Pedicure", Category = "Pedicure", Price = 45.00M }

            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123-456-7890", Email = "john.doe@example.com" },
                new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", PhoneNumber = "987-654-3210", Email = "jane.smith@example.com" }
            );

            // Seed Transactions.
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    TransactionID = 1,
                    EmployeeID = 1,
                    CustomerID = 1,
                    TotalAmount = 60.00M,
                    PaymentType = "Cash",
                    TransactionDate = DateTime.Now
                }
            );

            modelBuilder.Entity<TransactionDetail>().HasData(
                // Bought 2 mens haircuts on one transaction.
                new TransactionDetail
                {
                    TransactionDetailID = 1,
                    TransactionID = 1,
                    ServiceID = 1, // Mens haircut.
                    Quantity = 1,
                    Subtotal = 25.00M
                },
                new TransactionDetail
                {
                    TransactionDetailID = 2,
                    TransactionID = 1,
                    ServiceID = 2, // Womens Haircut.
                    Quantity = 1,
                    Subtotal = 35.00M
                }
            );
        }

        // Static method to hash the password.
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
