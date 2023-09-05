using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BanksTransactions.Application.Commands
{
    public class UpdateTransactionCommand :IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
