using BanksTransactions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanksTransactions.Domain.Repositories
{
   public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(int id);
        Task<List<Transaction>> GetAllAsync();
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int id);
    }
}
