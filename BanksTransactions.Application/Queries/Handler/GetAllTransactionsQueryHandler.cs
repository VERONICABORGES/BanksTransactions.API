using BanksTransactions.Application.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BanksTransactions.Domain.Repositories;
using System.Linq;
using System;

namespace BanksTransactions.Application.Queries.Handler
{
        
        public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
        {
            
            private readonly ITransactionRepository _transactionRepository;

            // Construtor para injetar dependências
            public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
            {
                
               this._transactionRepository = transactionRepository;
            }

            public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
            {
            // Busca todas transações 
            // do repositório de dados e mapeá para TransactionDto  

            var transactions = await _transactionRepository.GetAllAsync();

                if (transactions == null)
                {
                    throw new NotImplementedException("transaction not found.");
                }


            // Mapeia as transações para TransactionDto
            var transactionDtos = transactions.Select(transaction => new TransactionDto
                {
                    Id = transaction.Id,
                    Description = transaction.Description,
                    Amount = transaction.Amount,
                    Date = transaction.Date,
                    
                }).ToList();

                 return transactionDtos;
            
        }
        }
    }

