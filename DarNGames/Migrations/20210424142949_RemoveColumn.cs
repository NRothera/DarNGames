using Microsoft.EntityFrameworkCore.Migrations;

namespace DarNGames.Migrations
{
    public partial class RemoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonGameProperties_VendorSubcategories_VendorSubcategoryId",
                table: "CommonGameProperties");

            migrationBuilder.DropIndex(
                name: "IX_CommonGameProperties_VendorSubcategoryId",
                table: "CommonGameProperties");

            migrationBuilder.AddColumn<int>(
                name: "VendorSubcategoriesId",
                table: "CommonGameProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonGameProperties_VendorSubcategoriesId",
                table: "CommonGameProperties",
                column: "VendorSubcategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonGameProperties_VendorSubcategories_VendorSubcategoriesId",
                table: "CommonGameProperties",
                column: "VendorSubcategoriesId",
                principalTable: "VendorSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonGameProperties_VendorSubcategories_VendorSubcategoriesId",
                table: "CommonGameProperties");

            migrationBuilder.DropIndex(
                name: "IX_CommonGameProperties_VendorSubcategoriesId",
                table: "CommonGameProperties");

            migrationBuilder.DropColumn(
                name: "VendorSubcategoriesId",
                table: "CommonGameProperties");

            migrationBuilder.CreateIndex(
                name: "IX_CommonGameProperties_VendorSubcategoryId",
                table: "CommonGameProperties",
                column: "VendorSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonGameProperties_VendorSubcategories_VendorSubcategoryId",
                table: "CommonGameProperties",
                column: "VendorSubcategoryId",
                principalTable: "VendorSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
