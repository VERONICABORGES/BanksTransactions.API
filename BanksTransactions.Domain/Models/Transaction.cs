﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BanksTransactions.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
