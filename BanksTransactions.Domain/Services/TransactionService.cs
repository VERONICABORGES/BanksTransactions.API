using System;
using System.Collections.Generic;
using System.Text;
using BanksTransactions.Domain.Models;
using BanksTransactions.Domain.Repositories;

namespace BanksTransactions.Domain.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

    }
}
