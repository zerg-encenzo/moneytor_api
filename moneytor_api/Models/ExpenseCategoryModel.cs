using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moneytor_api.Models
{
    public class ExpenseCategoryModel
    {
        [Key]
        public required string Code { get; set; }
        public required string Desc { get; set; }
        public string? ExpenseTypeCode { get; set; }
        public ExpenseTypeModel? ExpenseType { get; set; }
        public string? DeductionTypeCode { get; set; }
        public DeductionTypeModel? DeductionType { get; set; }
        public string? BudgetTypeCode { get; set; }
        public BudgetTypeModel? BudgetType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public required decimal StandardBudgetAmount { get; set; }

        public required string BudgetCurrency { get; set; }
        public string? CalculatorCode { get; set; }
        public required string UserId { get; set; }
        public required string Status { get; set; }

    }
}
