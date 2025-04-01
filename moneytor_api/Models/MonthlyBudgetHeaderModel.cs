namespace moneytor_api.Models
{
    public class MonthlyBudgetHeaderModel
    {
        public required string Month { get; set; }
        public required string Year { get; set; }
        public required string BudgetTypeCode { get; set; }
        public required int MonthTotalDays { get; set; }
        public required string Status { get; set; }
        public required string UserId { get; set; }
        public ICollection<MonthlyBudgetDetailModel>? Details { get; set; }
    }
}
