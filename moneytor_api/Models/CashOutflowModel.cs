namespace moneytor_api.Models
{
    public class CashOutflowModel
    {
        public Guid Id { get; set; }
        public required string Month { get; set; }
        public required string Year { get; set; }
        public required string MonthlyBudgetSeqNo { get; set; }
        public DateTime DeductionDate { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal DeductionRemarks { get; set; }
        public string? ExpenseTypeCode { get; set; }
        public ExpenseCategoryModel? ExpenseType { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
    }
}
