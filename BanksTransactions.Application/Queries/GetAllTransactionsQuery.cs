using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BanksTransactions.Application.Queries
{    
    public class GetAllTransactionsQuery: IRequest<List<TransactionDto>>
    {
    }
}
