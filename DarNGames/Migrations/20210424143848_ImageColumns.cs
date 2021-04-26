using Microsoft.EntityFrameworkCore.Migrations;

namespace DarNGames.Migrations
{
    public partial class ImageColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "GameVendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "CommonGameProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "GameVendors");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "CommonGameProperties");
        }
    }
}
