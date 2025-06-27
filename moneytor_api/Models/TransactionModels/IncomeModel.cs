namespace moneytor_api.Models.TransactionModels
{
    public class IncomeModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Remarks { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
    }
}
