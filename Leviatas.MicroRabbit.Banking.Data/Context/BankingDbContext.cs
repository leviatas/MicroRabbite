using Leviatas.MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Leviatas.MicroRabbit.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts
        {
            get; set;
        }
    }
}
