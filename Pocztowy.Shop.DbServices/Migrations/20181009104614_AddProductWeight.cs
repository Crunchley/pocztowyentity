using Microsoft.EntityFrameworkCore.Migrations;

namespace Pocztowy.Shop.DbServices.Migrations
{
    public partial class AddProductWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");
        }
    }
}
