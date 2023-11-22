using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Novotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataToHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 22, 20, 18, 34, 28, DateTimeKind.Local).AddTicks(6752), "", "https://placehold.co/600x400", "Royal House", 4, 400.0, 550, null },
                    { 2, new DateTime(2023, 11, 22, 20, 18, 34, 28, DateTimeKind.Local).AddTicks(6767), "", "https://placehold.co/600x400", "Royal House", 3, 300.0, 540, null },
                    { 3, new DateTime(2023, 11, 22, 20, 18, 34, 28, DateTimeKind.Local).AddTicks(6769), "", "https://placehold.co/600x400", "Royal House", 4, 500.0, 650, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
