using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BanksTransactions.Application.Commands
{
    public class DeleteTransactionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
