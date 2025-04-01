using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moneytor_api.Migrations
{
    /// <inheritdoc />
    public partial class addBudgetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyBudgetHeader",
                columns: table => new
                {
                    Month = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BudgetTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthTotalDays = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetHeader", x => new { x.Month, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBudgetDetail",
                columns: table => new
                {
                    SeqNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HeaderMonth = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HeaderYear = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumWeekDays = table.Column<int>(type: "int", nullable: false),
                    NumWeekEnds = table.Column<int>(type: "int", nullable: false),
                    NumHolidays = table.Column<int>(type: "int", nullable: false),
                    NumTotalDays = table.Column<int>(type: "int", nullable: false),
                    TotalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetDetail", x => x.SeqNo);
                    table.ForeignKey(
                        name: "FK_MonthlyBudgetDetail_MonthlyBudgetHeader_HeaderMonth_HeaderYear",
                        columns: x => new { x.HeaderMonth, x.HeaderYear },
                        principalTable: "MonthlyBudgetHeader",
                        principalColumns: new[] { "Month", "Year" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudgetDetail_HeaderMonth_HeaderYear",
                table: "MonthlyBudgetDetail",
                columns: new[] { "HeaderMonth", "HeaderYear" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyBudgetDetail");

            migrationBuilder.DropTable(
                name: "MonthlyBudgetHeader");
        }
    }
}
