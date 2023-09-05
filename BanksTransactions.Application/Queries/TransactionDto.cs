using System;
using System.Collections.Generic;
using System.Text;

namespace BanksTransactions.Application.Queries
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
