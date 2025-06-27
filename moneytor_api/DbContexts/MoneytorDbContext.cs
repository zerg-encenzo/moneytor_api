using Microsoft.EntityFrameworkCore;
using moneytor_api.Entities;
using moneytor_api.Models;
using moneytor_api.Models.MasterModels;
using moneytor_api.Models.TransactionModels;

namespace moneytor_api.DbContexts
{
    public class MoneytorDbContext(DbContextOptions<MoneytorDbContext> options) : DbContext(options)
    {
        //DB CONTEXTS:
        #region A. Type/Category Masters
        //Expense Category Table:
        public DbSet<ExpenseCategoryModel> ExpenseCategory => Set<ExpenseCategoryModel>();

        //Expense Type Table:
        public DbSet<ExpenseTypeModel> ExpenseType => Set<ExpenseTypeModel>();

        //Deduction Type Table:
        public DbSet<DeductionTypeModel> DeductionType => Set<DeductionTypeModel>();

        //Budget Type Table:
        public DbSet<BudgetTypeModel> BudgetType => Set<BudgetTypeModel>();

        //Budget Type Table:
        public DbSet<FundSourceModel> FundSource => Set<FundSourceModel>();
        #endregion


        #region B. Monthly Budget
        ////Header Table:
        //public DbSet<MonthlyBudgetHeaderModel> MonthlyBudgetHeader => Set<MonthlyBudgetHeaderModel>();

        ////Detail Table:
        //public DbSet<MonthlyBudgetDetailModel> MonthlyBudgetDetail => Set<MonthlyBudgetDetailModel>();
        
        //Income Table:
        public DbSet<IncomeModel> Income => Set<IncomeModel>();
        
        //Expenses Table:
        public DbSet<ExpenseModel> Expenses => Set<ExpenseModel>();
        #endregion


        #region C. User Authentication
        public DbSet<User> Users { get; set; }

        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //// Define composite primary key for MonthlyBudgetHeaderModel
        //    //modelBuilder.Entity<MonthlyBudgetHeaderModel>()
        //    //    .HasKey(mbh => new { mbh.Month, mbh.Year });

        //    //// Define composite primary key for MonthlyBudgetDetailModel
        //    //modelBuilder.Entity<MonthlyBudgetDetailModel>()
        //    //    .HasKey(mbd => new { mbd.SeqNo });

        //    //modelBuilder.Entity<DeductionTypeModel>().HasData(
        //    //    new DeductionTypeModel
        //    //    {
        //    //        Code = "DLD",
        //    //        Desc = "Daily Deduction",
        //    //        Status = "A",
        //    //        UserId = "moneytor_admin"
        //    //    },
        //    //    new DeductionTypeModel
        //    //    {
        //    //        Code = "TLD",
        //    //        Desc = "Total Deduction",
        //    //        Status = "A",
        //    //        UserId = "moneytor_admin"
        //    //    }
        //    //);

        //    //modelBuilder.Entity<ExpenseTypeModel>().HasData(
        //    //    new ExpenseTypeModel
        //    //    {
        //    //        Code = "VAR",
        //    //        Desc = "Variable Expenses",
        //    //        Status = "A",
        //    //        UserId = "moneytor_admin"
        //    //    },
        //    //    new ExpenseTypeModel
        //    //    {
        //    //        Code = "FIX",
        //    //        Desc = "Fixed Expenses",
        //    //        Status = "A",
        //    //        UserId = "moneytor_admin"
        //    //    },
        //    //    new ExpenseTypeModel
        //    //    {
        //    //        Code = "EXT",
        //    //        Desc = "Extra Expenses",
        //    //        Status = "A",
        //    //        UserId = "moneytor_admin"
        //    //    }
        //    //);

        //    //modelBuilder.Entity<ExpenseCategoryModel>().HasData(
        //    //    new ExpenseCategoryModel
        //    //    {
        //    //        Code = "EC_FOOD",
        //    //        Desc = "Food",
        //    //        ExpenseTypeCode = "VAR",
        //    //        DeductionTypeCode = "DLD",
        //    //        BudgetTypeCode = "DLY",
        //    //        StandardBudgetAmount = 200,
        //    //        BudgetCurrency = "PHP",
        //    //        CalculatorCode = null,
        //    //        UserId = "zdencenzo",
        //    //        Status = "A"
        //    //    },
        //    //    new ExpenseCategoryModel
        //    //    {
        //    //        Code = "EC_GAS",
        //    //        Desc = "Gasoline",
        //    //        ExpenseTypeCode = "VAR",
        //    //        DeductionTypeCode = "DLD",
        //    //        BudgetTypeCode = "BMT",
        //    //        StandardBudgetAmount = 250,
        //    //        BudgetCurrency = "PHP",
        //    //        CalculatorCode = null,
        //    //        UserId = "zdencenzo",
        //    //        Status = "A"
        //    //    },
        //    //    new ExpenseCategoryModel
        //    //    {
        //    //        Code = "EC_PERSONAL",
        //    //        Desc = "Personal",
        //    //        ExpenseTypeCode = "VAR",
        //    //        DeductionTypeCode = "TLD",
        //    //        BudgetTypeCode = "BMT",
        //    //        StandardBudgetAmount = 1000,
        //    //        BudgetCurrency = "PHP",
        //    //        CalculatorCode = null,
        //    //        UserId = "zdencenzo",
        //    //        Status = "A"
        //    //    }
        //    //);
        //}
    }
}
