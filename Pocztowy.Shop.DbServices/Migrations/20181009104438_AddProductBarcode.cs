using Microsoft.EntityFrameworkCore.Migrations;

namespace Pocztowy.Shop.DbServices.Migrations
{
    public partial class AddProductBarcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Items",
                unicode: false,
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Items");
        }
    }
}
