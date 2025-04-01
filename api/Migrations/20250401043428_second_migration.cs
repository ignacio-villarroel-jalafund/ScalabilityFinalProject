using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class second_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AdminType = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegisterDate = table.Column<string>(type: "text", nullable: false),
                    Nit = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorID);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegionID = table.Column<Guid>(type: "uuid", nullable: false),
                    Nit = table.Column<int>(type: "integer", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    AnimalCategory = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    BrandID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false),
                    HasTax = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ReportDate = table.Column<string>(type: "text", nullable: false),
                    ObtainedTaxes = table.Column<decimal>(type: "numeric", nullable: false),
                    ApplicationTax = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryTime = table.Column<decimal>(type: "numeric", nullable: false),
                    LocalQuantity = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MunicipalTax = table.Column<decimal>(type: "numeric", nullable: false),
                    StatalTax = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewMessage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<Guid>(type: "uuid", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Cvv = table.Column<int>(type: "integer", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAvailable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
