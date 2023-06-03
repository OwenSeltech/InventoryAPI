using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddItemNos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemsNo",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsNo",
                table: "Invoices");
        }
    }
}
