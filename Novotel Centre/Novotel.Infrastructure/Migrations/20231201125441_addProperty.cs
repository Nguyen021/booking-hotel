using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "HousesNumbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseType",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "HouseType" },
                values: new object[] { new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2296), null });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "HouseType" },
                values: new object[] { new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2308), null });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "HouseType" },
                values: new object[] { new DateTime(2023, 12, 1, 19, 54, 41, 331, DateTimeKind.Local).AddTicks(2310), null });

            migrationBuilder.UpdateData(
                table: "HousesNumbers",
                keyColumn: "House_Number",
                keyValue: 101,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "HousesNumbers",
                keyColumn: "House_Number",
                keyValue: 102,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "HousesNumbers",
                keyColumn: "House_Number",
                keyValue: 103,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "HousesNumbers",
                keyColumn: "House_Number",
                keyValue: 201,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "HousesNumbers",
                keyColumn: "House_Number",
                keyValue: 202,
                column: "Status",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HousesNumbers");

            migrationBuilder.DropColumn(
                name: "HouseType",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 22, 22, 24, 211, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 22, 22, 24, 211, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 22, 22, 24, 211, DateTimeKind.Local).AddTicks(2846));
        }
    }
}
