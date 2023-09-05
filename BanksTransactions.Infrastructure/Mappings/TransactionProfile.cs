using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BanksTransactions.Application.Queries;
using BanksTransactions.Domain.Models;

namespace BanksTransactions.Infrastructure.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
