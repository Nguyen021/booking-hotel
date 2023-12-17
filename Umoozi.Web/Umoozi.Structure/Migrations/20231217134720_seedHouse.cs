using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Umoozi.Structure.Migrations
{
    /// <inheritdoc />
    public partial class seedHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "CreatedDate", "Description", "ImgUrl", "IsActive", "Name", "Occupancy", "Price", "SquareFeet", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 17, 20, 47, 20, 512, DateTimeKind.Local).AddTicks(2853), "Description", "", true, "Name", 4, 0.0, 550, null },
                    { 2, new DateTime(2023, 12, 17, 20, 47, 20, 512, DateTimeKind.Local).AddTicks(2867), "Description", "", true, "Name @2", 4, 0.0, 550, null }
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
        }
    }
}
