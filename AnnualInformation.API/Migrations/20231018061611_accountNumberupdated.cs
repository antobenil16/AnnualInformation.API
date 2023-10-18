using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnualInformation.API.Migrations
{
    /// <inheritdoc />
    public partial class accountNumberupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 11, 46, 11, 597, DateTimeKind.Local).AddTicks(8560));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 11, 40, 42, 488, DateTimeKind.Local).AddTicks(6810));
        }
    }
}
