namespace moneytor_api.Models.TransactionModels
{
    public class MonthlyBudgetDetailModel
    {
        public required string HeaderMonth { get; set; }
        public required string HeaderYear { get; set; }
        public required string SeqNo { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required int NumWeekDays { get; set; }
        public required int NumWeekEnds { get; set; }
        public required int? NumHolidays { get; set; }
        public required int NumTotalDays { get; set; }
        public required decimal TotalBudgetAmount { get; set; }
        public required string Status { get; set; }
        public required string UserId { get; set; }
        public required MonthlyBudgetHeaderModel Header { get; set; }
    }
}
