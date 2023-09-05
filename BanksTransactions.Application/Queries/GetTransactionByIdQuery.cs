using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BanksTransactions.Application.Queries
{    
    public class GetTransactionByIdQuery : IRequest<TransactionDto>
    {
        public int Id { get; set; }
    }
}
