using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moneytor_api.Migrations
{
    /// <inheritdoc />
    public partial class deleteTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyBudgetDetail_MonthlyBudgetHeader_Month_Year",
                table: "MonthlyBudgetDetail");

            migrationBuilder.DropTable(
                name: "MonthlyBudgetHeader");

            migrationBuilder.DropTable(
                name: "MonthlyBudgetDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyBudgetDetail",
                columns: table => new
                {
                    Month = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumHolidays = table.Column<int>(type: "int", nullable: false),
                    NumTotalDays = table.Column<int>(type: "int", nullable: false),
                    NumWeekDays = table.Column<int>(type: "int", nullable: false),
                    NumWeekEnds = table.Column<int>(type: "int", nullable: false),
                    SeqNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetDetail", x => new { x.Month, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBudgetHeader",
                columns: table => new
                {
                    Month = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailMonth = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DetailYear = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BudgetTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthTotalDays = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetHeader", x => new { x.Month, x.Year });
                    table.ForeignKey(
                        name: "FK_MonthlyBudgetHeader_MonthlyBudgetDetail_DetailMonth_DetailYear",
                        columns: x => new { x.DetailMonth, x.DetailYear },
                        principalTable: "MonthlyBudgetDetail",
                        principalColumns: new[] { "Month", "Year" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudgetHeader_DetailMonth_DetailYear",
                table: "MonthlyBudgetHeader",
                columns: new[] { "DetailMonth", "DetailYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyBudgetDetail_MonthlyBudgetHeader_Month_Year",
                table: "MonthlyBudgetDetail",
                columns: new[] { "Month", "Year" },
                principalTable: "MonthlyBudgetHeader",
                principalColumns: new[] { "Month", "Year" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
