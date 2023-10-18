using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnualInformation.API.Migrations
{
    /// <inheritdoc />
    public partial class accountNumberunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 12, 1, 43, 519, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountNumber",
                table: "Customers",
                column: "AccountNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 11, 46, 11, 597, DateTimeKind.Local).AddTicks(8560));
        }
    }
}
