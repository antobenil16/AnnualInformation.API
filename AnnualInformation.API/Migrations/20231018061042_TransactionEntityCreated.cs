using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnualInformation.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionEntityCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 11, 40, 42, 488, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchId",
                table: "Transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 23, 23, 19, 493, DateTimeKind.Local).AddTicks(3592));
        }
    }
}
