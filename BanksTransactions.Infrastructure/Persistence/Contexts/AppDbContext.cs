using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BanksTransactions.Domain.Models;

namespace BanksTransactions.Infrastructure.Persistence.Contexts
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
