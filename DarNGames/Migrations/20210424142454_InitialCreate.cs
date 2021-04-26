using Microsoft.EntityFrameworkCore.Migrations;

namespace DarNGames.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameVendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorSubcategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    GameVendorId = table.Column<int>(nullable: false),
                    GameVendorsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorSubcategories_GameVendors_GameVendorsId",
                        column: x => x.GameVendorsId,
                        principalTable: "GameVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommonGameProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    VendorSubcategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonGameProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonGameProperties_VendorSubcategories_VendorSubcategoryId",
                        column: x => x.VendorSubcategoryId,
                        principalTable: "VendorSubcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonGameProperties_VendorSubcategoryId",
                table: "CommonGameProperties",
                column: "VendorSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorSubcategories_GameVendorsId",
                table: "VendorSubcategories",
                column: "GameVendorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonGameProperties");

            migrationBuilder.DropTable(
                name: "VendorSubcategories");

            migrationBuilder.DropTable(
                name: "GameVendors");
        }
    }
}
