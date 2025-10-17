using Leviatas.MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Leviatas.MicroRabbit.Banking.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {

        }

        public DbSet<TransferLog> TransferLogs
        {
            get; set;
        }
    }
}
