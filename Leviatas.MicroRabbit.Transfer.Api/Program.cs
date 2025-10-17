
using Leviatas.MicroRabbit.Banking.Data.Context;
using Leviatas.MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;

namespace Leviatas.MicroRabbit.Transfer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TransferDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            RegisterServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServicesTransfer(services);
        }
    }
}
