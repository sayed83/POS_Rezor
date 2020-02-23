﻿using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Profit
    {
        [Key]
        public int ProfitId { get; set; }
        [Required]
        public string ProfitDec { get; set; }
        public float ProfitAmount { get; set; }
        public DateTime GivenDate { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? InvestId { get; set; }
        public virtual Invest Invest { get; set; }

    }
}
