using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BanksTransactions.Application.Commands
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
