using Microsoft.EntityFrameworkCore;
using moneytor_api.Models;

namespace moneytor_api.DbContexts
{
    public class MoneytorDbContext(DbContextOptions<MoneytorDbContext> expCategories) : DbContext(expCategories)
    {
        //DB Context for Expense Category Table:
        public DbSet<ExpenseCategoryModel> ExpenseCategory => Set<ExpenseCategoryModel>();

        //DB Context for Expense Type Table:
        public DbSet<ExpenseTypeModel> ExpenseType => Set<ExpenseTypeModel>();

        //DB Context for Deduction Type Table:
        public DbSet<DeductionTypeModel> DeductionType => Set<DeductionTypeModel>();

        //DB Context for Budget Type Table:
        public DbSet<BudgetTypeModel> BudgetType => Set<BudgetTypeModel>();

        //DB Context for Monthly Budget Header Table:
        public DbSet<MonthlyBudgetHeaderModel> MonthlyBudgetHeader => Set<MonthlyBudgetHeaderModel>();

        //DB Context for Monthly Budget Detail Table:
        public DbSet<MonthlyBudgetDetailModel> MonthlyBudgetDetail => Set<MonthlyBudgetDetailModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for MonthlyBudgetHeaderModel
            modelBuilder.Entity<MonthlyBudgetHeaderModel>()
                .HasKey(mbh => new { mbh.Month, mbh.Year });

            // Define composite primary key for MonthlyBudgetDetailModel
            modelBuilder.Entity<MonthlyBudgetDetailModel>()
                .HasKey(mbd => new { mbd.SeqNo });

            //// Define foreign key relationship between Header and Detail
            //modelBuilder.Entity<MonthlyBudgetDetailModel>()
            //    .HasOne<MonthlyBudgetHeaderModel>()
            //    .WithMany() // One header can have multiple details
            //    .HasForeignKey(mbd => new { mbd.Month, mbd.Year })
            //    .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete details when the header is deleted


            modelBuilder.Entity<DeductionTypeModel>().HasData(
                new DeductionTypeModel
                {
                    Code = "DLD",
                    Desc = "Daily Deduction",
                    Status = "A",
                    UserId = "moneytor_admin"
                },
                new DeductionTypeModel
                {
                    Code = "TLD",
                    Desc = "Total Deduction",
                    Status = "A",
                    UserId = "moneytor_admin"
                }
            );

            modelBuilder.Entity<ExpenseTypeModel>().HasData(
                new ExpenseTypeModel
                {
                    Code = "VAR",
                    Desc = "Variable Expenses",
                    Status = "A",
                    UserId = "moneytor_admin"
                },
                new ExpenseTypeModel
                {
                    Code = "FIX",
                    Desc = "Fixed Expenses",
                    Status = "A",
                    UserId = "moneytor_admin"
                },
                new ExpenseTypeModel
                {
                    Code = "EXT",
                    Desc = "Extra Expenses",
                    Status = "A",
                    UserId = "moneytor_admin"
                }
            );

            modelBuilder.Entity<ExpenseCategoryModel>().HasData(
                new ExpenseCategoryModel
                {
                    Code = "EC_FOOD",
                    Desc = "Food",
                    ExpenseTypeCode = "VAR",
                    DeductionTypeCode = "DLD",
                    BudgetTypeCode = "DLY",
                    StandardBudgetAmount = 200,
                    BudgetCurrency = "PHP",
                    CalculatorCode = null,
                    UserId = "zdencenzo",
                    Status = "A"
                },
                new ExpenseCategoryModel
                {
                    Code = "EC_GAS",
                    Desc = "Gasoline",
                    ExpenseTypeCode = "VAR",
                    DeductionTypeCode = "DLD",
                    BudgetTypeCode = "BMT",
                    StandardBudgetAmount = 250,
                    BudgetCurrency = "PHP",
                    CalculatorCode = null,
                    UserId = "zdencenzo",
                    Status = "A"
                },
                new ExpenseCategoryModel
                {
                    Code = "EC_PERSONAL",
                    Desc = "Personal",
                    ExpenseTypeCode = "VAR",
                    DeductionTypeCode = "TLD",
                    BudgetTypeCode = "BMT",
                    StandardBudgetAmount = 1000,
                    BudgetCurrency = "PHP",
                    CalculatorCode = null,
                    UserId = "zdencenzo",
                    Status = "A"
                }
            );
        }
    }
}
