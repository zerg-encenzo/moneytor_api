using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace moneytor_api.Migrations
{
    /// <inheritdoc />
    public partial class IncomeAndExpensesUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyBudgetDetail");

            migrationBuilder.DropTable(
                name: "MonthlyBudgetHeader");

            migrationBuilder.DeleteData(
                table: "ExpenseCategory",
                keyColumn: "Code",
                keyValue: "EC_FOOD");

            migrationBuilder.DeleteData(
                table: "ExpenseCategory",
                keyColumn: "Code",
                keyValue: "EC_GAS");

            migrationBuilder.DeleteData(
                table: "ExpenseCategory",
                keyColumn: "Code",
                keyValue: "EC_PERSONAL");

            migrationBuilder.DeleteData(
                table: "ExpenseType",
                keyColumn: "Code",
                keyValue: "EXT");

            migrationBuilder.DeleteData(
                table: "ExpenseType",
                keyColumn: "Code",
                keyValue: "FIX");

            migrationBuilder.DeleteData(
                table: "DeductionType",
                keyColumn: "Code",
                keyValue: "DLD");

            migrationBuilder.DeleteData(
                table: "DeductionType",
                keyColumn: "Code",
                keyValue: "TLD");

            migrationBuilder.DeleteData(
                table: "ExpenseType",
                keyColumn: "Code",
                keyValue: "VAR");

            migrationBuilder.RenameColumn(
                name: "CalculatorCode",
                table: "ExpenseCategory",
                newName: "Ionicon");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ionicon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpenseCategoryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategory_ExpenseCategoryCode",
                        column: x => x.ExpenseCategoryCode,
                        principalTable: "ExpenseCategory",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseType_ExpenseTypeCode",
                        column: x => x.ExpenseTypeCode,
                        principalTable: "ExpenseType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundSource",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ionicon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSource", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryCode",
                table: "Expenses",
                column: "ExpenseCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeCode",
                table: "Expenses",
                column: "ExpenseTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FundSource");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.RenameColumn(
                name: "Ionicon",
                table: "ExpenseCategory",
                newName: "CalculatorCode");

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
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumHolidays = table.Column<int>(type: "int", nullable: false),
                    NumTotalDays = table.Column<int>(type: "int", nullable: false),
                    NumWeekDays = table.Column<int>(type: "int", nullable: false),
                    NumWeekEnds = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "DeductionType",
                columns: new[] { "Code", "Desc", "Status", "UserId" },
                values: new object[,]
                {
                    { "DLD", "Daily Deduction", "A", "moneytor_admin" },
                    { "TLD", "Total Deduction", "A", "moneytor_admin" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Code", "Desc", "Status", "UserId" },
                values: new object[,]
                {
                    { "EXT", "Extra Expenses", "A", "moneytor_admin" },
                    { "FIX", "Fixed Expenses", "A", "moneytor_admin" },
                    { "VAR", "Variable Expenses", "A", "moneytor_admin" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategory",
                columns: new[] { "Code", "BudgetCurrency", "BudgetTypeCode", "CalculatorCode", "DeductionTypeCode", "Desc", "ExpenseTypeCode", "StandardBudgetAmount", "Status", "UserId" },
                values: new object[,]
                {
                    { "EC_FOOD", "PHP", "DLY", null, "DLD", "Food", "VAR", 200m, "A", "zdencenzo" },
                    { "EC_GAS", "PHP", "BMT", null, "DLD", "Gasoline", "VAR", 250m, "A", "zdencenzo" },
                    { "EC_PERSONAL", "PHP", "BMT", null, "TLD", "Personal", "VAR", 1000m, "A", "zdencenzo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudgetDetail_HeaderMonth_HeaderYear",
                table: "MonthlyBudgetDetail",
                columns: new[] { "HeaderMonth", "HeaderYear" });
        }
    }
}
