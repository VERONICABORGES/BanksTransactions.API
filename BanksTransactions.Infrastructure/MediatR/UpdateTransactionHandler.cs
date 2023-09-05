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
    public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        public UpdateTransactionHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(request.Id);

            if (existingTransaction == null)
            {
                throw new NotImplementedException($"Transaction with ID {request.Id} not found.");
            }
            else
            {
                try
                {
                    // Atualiza campos modificado da transação
                    existingTransaction.Description = request.Description;
                    existingTransaction.Amount = request.Amount;
                    existingTransaction.Date = request.Date;

                    await _transactionRepository.UpdateAsync(existingTransaction);
                    return Unit.Value;
                }
                catch (Exception)
                {
                    throw new NotImplementedException("Invalid Format");
                }
            }
            
        }
    }    
    
}
