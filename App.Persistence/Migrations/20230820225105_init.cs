using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManufacturePhone = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    ManufactureEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureEmail_ProductDate",
                table: "Products",
                columns: new[] { "ManufactureEmail", "ProductDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
