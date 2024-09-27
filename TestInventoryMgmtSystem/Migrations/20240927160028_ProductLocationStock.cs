using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestInventoryMgmtSystem.Migrations
{
    /// <inheritdoc />
    public partial class ProductLocationStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Suppliers",
                newName: "VatNr");

            migrationBuilder.RenameColumn(
                name: "TotalNrSoldProduct",
                table: "Stocks",
                newName: "TotalInStock");

            migrationBuilder.RenameColumn(
                name: "TotalNrOfProductInStock",
                table: "Stocks",
                newName: "LocationStockId");

            migrationBuilder.RenameColumn(
                name: "DescriptionProduct",
                table: "Products",
                newName: "ProductNr");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNr",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Suppliers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameLocation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Commune = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationStocks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductLocationsStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationStockId = table.Column<int>(type: "int", nullable: false),
                    TotalInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocationsStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLocationsStocks_LocationStocks_LocationStockId",
                        column: x => x.LocationStockId,
                        principalTable: "LocationStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLocationsStocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LocationStockId",
                table: "Stocks",
                column: "LocationStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocationsStocks_LocationStockId",
                table: "ProductLocationsStocks",
                column: "LocationStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocationsStocks_ProductId",
                table: "ProductLocationsStocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_LocationStocks_LocationStockId",
                table: "Stocks",
                column: "LocationStockId",
                principalTable: "LocationStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_LocationStocks_LocationStockId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "ProductLocationsStocks");

            migrationBuilder.DropTable(
                name: "LocationStocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_LocationStockId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PhoneNr",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "VatNr",
                table: "Suppliers",
                newName: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "TotalInStock",
                table: "Stocks",
                newName: "TotalNrSoldProduct");

            migrationBuilder.RenameColumn(
                name: "LocationStockId",
                table: "Stocks",
                newName: "TotalNrOfProductInStock");

            migrationBuilder.RenameColumn(
                name: "ProductNr",
                table: "Products",
                newName: "DescriptionProduct");
        }
    }
}
