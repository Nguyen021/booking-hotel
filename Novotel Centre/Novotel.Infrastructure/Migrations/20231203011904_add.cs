using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 8, 19, 4, 195, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 8, 19, 4, 195, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 8, 19, 4, 195, DateTimeKind.Local).AddTicks(1233));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2310));
        }
    }
}
