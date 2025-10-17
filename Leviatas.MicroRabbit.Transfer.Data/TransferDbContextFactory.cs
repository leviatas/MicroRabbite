using Leviatas.MicroRabbit.Banking.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leviatas.MicroRabbit.Banking.Data
{
    // I needed this to migrate and create the initial migration from the command line
    // Api as startup service. then nuget package console to create migrtation and update db
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            optionsBuilder.UseSqlServer("PASTECONNECTIONSTRINGTOMIGRATEHERE");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
