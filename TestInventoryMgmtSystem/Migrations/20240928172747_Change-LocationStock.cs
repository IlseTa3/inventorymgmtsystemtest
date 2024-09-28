using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestInventoryMgmtSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLocationStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commune",
                table: "LocationStocks",
                newName: "Municipality");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "LocationStocks",
                newName: "Commune");
        }
    }
}
