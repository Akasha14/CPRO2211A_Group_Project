using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GroupProject_POS_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    TransactionDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => x.TransactionDetailID);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CreatedAt", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 30, 14, 14, 55, 621, DateTimeKind.Local).AddTicks(425), "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, new DateTime(2024, 11, 30, 14, 14, 55, 623, DateTimeKind.Local).AddTicks(4809), "jane.smith@example.com", "Jane", "Smith", "987-654-3210" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "FirstName", "LastName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, "alice.kosh@example.com", "Alice", "Kosh", "$2a$11$2JPpX8hjE7K4u8W.YlMSF.j7uK/8qdX0WIQ3ppVMhb7e1V4I1i..u", "Staff" },
                    { 2, "bob.mash@example.com", "Bob", "Mash", "$2a$11$17VtfmMvQRXHlHCeAmgV9u0p6vI1fT1zt42ZRxG3V858h80IDGRtS", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Category", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Haircut", 25.00m, "Men's Haircut" },
                    { 2, "Haircut", 35.00m, "Women's Haircut" },
                    { 3, "Haircut", 15.00m, "Men's Beard Trim" },
                    { 4, "Manicure", 30.00m, "Manicure" },
                    { 5, "Pedicure", 40.00m, "Pedicure" },
                    { 6, "Manicure", 40.00m, "Gel Manicure" },
                    { 7, "Pedicure", 45.00m, "French Pedicure" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "CustomerID", "EmployeeID", "PaymentType", "TotalAmount", "TransactionDate" },
                values: new object[] { 1, 1, 1, "Cash", 60.00m, new DateTime(2024, 11, 30, 14, 14, 55, 623, DateTimeKind.Local).AddTicks(6569) });

            migrationBuilder.InsertData(
                table: "TransactionDetail",
                columns: new[] { "TransactionDetailID", "Quantity", "ServiceID", "Subtotal", "TransactionID" },
                values: new object[,]
                {
                    { 1, 1, 1, 25.00m, 1 },
                    { 2, 1, 2, 35.00m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ServiceID",
                table: "TransactionDetail",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionID",
                table: "TransactionDetail",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transactions",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
