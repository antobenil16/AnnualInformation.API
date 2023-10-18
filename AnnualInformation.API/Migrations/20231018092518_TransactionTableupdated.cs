using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnualInformation.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionTableupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_ReceiverId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_SenderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Transactions",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                newName: "IX_Transactions_CustomerId");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 14, 55, 18, 658, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Transactions",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                newName: "IX_Transactions_SenderId");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 12, 1, 43, 519, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_ReceiverId",
                table: "Transactions",
                column: "ReceiverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_SenderId",
                table: "Transactions",
                column: "SenderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
