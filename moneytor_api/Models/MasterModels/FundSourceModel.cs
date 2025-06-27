using System.ComponentModel.DataAnnotations;

namespace moneytor_api.Models.MasterModels
{
    public class FundSourceModel
    {
        public Guid Id { get; set; }
        [Key]
        public required string Name { get; set; }
        public required string? Ionicon { get; set; }
        public required string Status { get; set; }
        public required string UserId { get; set; }
    }
}
