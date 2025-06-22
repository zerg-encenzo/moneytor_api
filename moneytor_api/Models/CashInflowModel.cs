namespace moneytor_api.Models
{
    public class CashInflowModel
    {
        public Guid Id { get; set; }
        public required string Month { get; set; }
        public required string Year { get; set; }
        public required string MonthlyBudgetSeqNo { get; set; }
        public DateTime IncomeDate { get; set; }
        public decimal IncomeAmount { get; set; }
        public decimal IncomeRemarks { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
