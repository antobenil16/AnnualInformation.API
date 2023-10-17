﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnualInformation.API.Models
{
    public class Branch : CommonModel
    {
        [ForeignKey("Bank")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
