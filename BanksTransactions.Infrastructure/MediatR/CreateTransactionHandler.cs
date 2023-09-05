using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using BanksTransactions.Application.Commands;
using BanksTransactions.Domain.Models;
using BanksTransactions.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace BanksTransactions.Infrastructure.MediatR
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand,int>
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Description = request.Description,
                Amount = request.Amount,
                Date = request.Date
            };
            try
            {
                await _transactionRepository.AddAsync(transaction);
                return transaction.Id;
            }
            catch (Exception)
            {

                throw new NotImplementedException("Invalid Format");
            }       
                        
        }

    }
}
