using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using BanksTransactions.Application.Commands;
using BanksTransactions.Application.Queries;
using System;

namespace BanksTransactions.API.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TransactionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        //Exibe todas as transações
        public async Task<ActionResult<List<TransactionDto>>> GetAllTransactions()
        {
            var query = new GetAllTransactionsQuery();
            var transactions = await _mediator.Send(query);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        //Exibe transações por Id
        public async Task<ActionResult<TransactionDto>> GetTransactionById(int id)
        {
            var query = new GetTransactionByIdQuery { Id = id };
            var transaction = await _mediator.Send(query);

            if (transaction == null)
            {
                return NotFound("transaction not found");
            }
            return Ok(transaction);
        }

        [HttpPost]
        //Cria nova transação
        public async Task<ActionResult<int>> CreateTransaction(CreateTransactionCommand command)
        {
            var transactionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionId }, null);

        }

        [HttpPut("{id}")]
        //Atualiza transação existente
        public async Task<IActionResult> UpdateTransaction(int id, UpdateTransactionCommand command)
        {
            if (id != command.Id)
            {
                return NotFound("Invalid ID");
            }

            try
            {
                await _mediator.Send(command);
                return Ok ("Update with sucess");
            }
            catch (Exception)
            {
                // Lida com erro de transação não encontrada
                return NotFound("transaction not found");
            }
        }

        [HttpDelete("{id}")]
        //Deleta transação da base
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                var command = new DeleteTransactionCommand { Id = id };
                await _mediator.Send(command);
                return Ok("Delete with sucess");
            }
            catch (Exception)
            {
                // Lida com erro de transação não encontrada
                return NotFound("transaction not found");
            }
        }

    }
}
