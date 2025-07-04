﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moneytor_api.DbContexts;

#nullable disable

namespace moneytor_api.Migrations
{
    [DbContext(typeof(MoneytorDbContext))]
    [Migration("20250330142724_addBudgetTables")]
    partial class addBudgetTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("moneytor_api.Models.BudgetTypeModel", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ConversionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("BudgetType");
                });

            modelBuilder.Entity("moneytor_api.Models.DeductionTypeModel", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("DeductionType");

                    b.HasData(
                        new
                        {
                            Code = "DLD",
                            Desc = "Daily Deduction",
                            Status = "A",
                            UserId = "moneytor_admin"
                        },
                        new
                        {
                            Code = "TLD",
                            Desc = "Total Deduction",
                            Status = "A",
                            UserId = "moneytor_admin"
                        });
                });

            modelBuilder.Entity("moneytor_api.Models.ExpenseCategoryModel", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BudgetCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BudgetTypeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CalculatorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeductionTypeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseTypeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("StandardBudgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("BudgetTypeCode");

                    b.HasIndex("DeductionTypeCode");

                    b.HasIndex("ExpenseTypeCode");

                    b.ToTable("ExpenseCategory");

                    b.HasData(
                        new
                        {
                            Code = "EC_FOOD",
                            BudgetCurrency = "PHP",
                            BudgetTypeCode = "DLY",
                            DeductionTypeCode = "DLD",
                            Desc = "Food",
                            ExpenseTypeCode = "VAR",
                            StandardBudgetAmount = 200m,
                            Status = "A",
                            UserId = "zdencenzo"
                        },
                        new
                        {
                            Code = "EC_GAS",
                            BudgetCurrency = "PHP",
                            BudgetTypeCode = "BMT",
                            DeductionTypeCode = "DLD",
                            Desc = "Gasoline",
                            ExpenseTypeCode = "VAR",
                            StandardBudgetAmount = 250m,
                            Status = "A",
                            UserId = "zdencenzo"
                        },
                        new
                        {
                            Code = "EC_PERSONAL",
                            BudgetCurrency = "PHP",
                            BudgetTypeCode = "BMT",
                            DeductionTypeCode = "TLD",
                            Desc = "Personal",
                            ExpenseTypeCode = "VAR",
                            StandardBudgetAmount = 1000m,
                            Status = "A",
                            UserId = "zdencenzo"
                        });
                });

            modelBuilder.Entity("moneytor_api.Models.ExpenseTypeModel", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("ExpenseType");

                    b.HasData(
                        new
                        {
                            Code = "VAR",
                            Desc = "Variable Expenses",
                            Status = "A",
                            UserId = "moneytor_admin"
                        },
                        new
                        {
                            Code = "FIX",
                            Desc = "Fixed Expenses",
                            Status = "A",
                            UserId = "moneytor_admin"
                        },
                        new
                        {
                            Code = "EXT",
                            Desc = "Extra Expenses",
                            Status = "A",
                            UserId = "moneytor_admin"
                        });
                });

            modelBuilder.Entity("moneytor_api.Models.MonthlyBudgetDetailModel", b =>
                {
                    b.Property<string>("SeqNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeaderMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HeaderYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumHolidays")
                        .HasColumnType("int");

                    b.Property<int>("NumTotalDays")
                        .HasColumnType("int");

                    b.Property<int>("NumWeekDays")
                        .HasColumnType("int");

                    b.Property<int>("NumWeekEnds")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalBudgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeqNo");

                    b.HasIndex("HeaderMonth", "HeaderYear");

                    b.ToTable("MonthlyBudgetDetail");
                });

            modelBuilder.Entity("moneytor_api.Models.MonthlyBudgetHeaderModel", b =>
                {
                    b.Property<string>("Month")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BudgetTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonthTotalDays")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Month", "Year");

                    b.ToTable("MonthlyBudgetHeader");
                });

            modelBuilder.Entity("moneytor_api.Models.ExpenseCategoryModel", b =>
                {
                    b.HasOne("moneytor_api.Models.BudgetTypeModel", "BudgetType")
                        .WithMany()
                        .HasForeignKey("BudgetTypeCode");

                    b.HasOne("moneytor_api.Models.DeductionTypeModel", "DeductionType")
                        .WithMany()
                        .HasForeignKey("DeductionTypeCode");

                    b.HasOne("moneytor_api.Models.ExpenseTypeModel", "ExpenseType")
                        .WithMany()
                        .HasForeignKey("ExpenseTypeCode");

                    b.Navigation("BudgetType");

                    b.Navigation("DeductionType");

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("moneytor_api.Models.MonthlyBudgetDetailModel", b =>
                {
                    b.HasOne("moneytor_api.Models.MonthlyBudgetHeaderModel", "Header")
                        .WithMany("Details")
                        .HasForeignKey("HeaderMonth", "HeaderYear")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Header");
                });

            modelBuilder.Entity("moneytor_api.Models.MonthlyBudgetHeaderModel", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
