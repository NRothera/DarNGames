using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarNGames.Migrations
{
    public partial class profileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_VendorSubcategories_VendorSubcategoriesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VendorSubcategoriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VendorSubcategoriesId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "VendorSubcategoriesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorSubcategoriesId",
                table: "Products",
                column: "VendorSubcategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VendorSubcategories_VendorSubcategoriesId",
                table: "Products",
                column: "VendorSubcategoriesId",
                principalTable: "VendorSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
