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
    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(request.Id);

            if (existingTransaction == null)
            {
                throw new ApplicationException($"Transaction with ID {request.Id} not found.");
            }
            else
            {
                try
                {
                    await _transactionRepository.DeleteAsync(request.Id);
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
