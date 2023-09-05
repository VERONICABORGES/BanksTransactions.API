using BanksTransactions.Application.Queries;
using BanksTransactions.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BanksTransactions.Application.Queries.Handler
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto>
    {
        
        private readonly ITransactionRepository _transactionRepository;

        // Construtor para injetar dependências
        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
        {
            
            this._transactionRepository = transactionRepository;
        }

        public async Task<TransactionDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            // Busca uma transação por ID
            // do repositório de dados e mapeia para TransactionDto            

            var transaction = await _transactionRepository.GetByIdAsync(request.Id);
            
            if (transaction == null)
            {
                throw new Exception("transaction not found.");                 
            }

            //Mapeando a transação para TransactionDto
            var transactionDto = new TransactionDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = transaction.Date
             };

            return transactionDto;
            
        }
    }
}
