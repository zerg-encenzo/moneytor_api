using moneytor_api.Models.MasterModels;
using System.ComponentModel.DataAnnotations;

namespace moneytor_api.Models.TransactionModels
{
    public class ExpenseModel
    {
        public Guid Id { get; set; }
        [Key]
        public required string Code { get; set; }
        public string? Ionicon { get; set; }
        public required string Source { get; set; }
        public DateTime Date { get; set; }
        public required string ExpenseTypeCode { get; set; }
        public ExpenseTypeModel? ExpenseType { get; set; }
        public required string ExpenseCategoryCode { get; set; }
        public ExpenseCategoryModel? ExpenseCategory { get; set; }
        public decimal Amount { get; set; }
        public decimal Remarks { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
    }
}
