﻿using System.ComponentModel.DataAnnotations;

namespace moneytor_api.Models.MasterModels
{
    public class ExpenseTypeModel
    {
        [Key]
        public required string Code { get; set; }
        public required string Desc { get; set; }
        public required string Status { get; set; }
        public required string UserId { get; set; }
    }
}
