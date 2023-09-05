using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BanksTransactions.Application.Commands;
using BanksTransactions.Application.Queries;
using BanksTransactions.Domain.Repositories;
using BanksTransactions.Infrastructure.MediatR;
using BanksTransactions.Infrastructure.Persistence.Contexts;
using BanksTransactions.Infrastructure.Persistence.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using BanksTransactions.Application.Queries.Handler;

namespace BanksTransactions.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do banco de dados em memória
            services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDatabase"));

            // Configuração da injeção de dependência
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            // Registro do MediatR
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(typeof(CreateTransactionHandler).Assembly);
            services.AddMediatR(typeof(UpdateTransactionCommand).Assembly);
            services.AddMediatR(typeof(DeleteTransactionCommand).Assembly);
            services.AddScoped<IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>, GetAllTransactionsQueryHandler>();



            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers();

            // Configuração do Swagger para documentação da API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BanksTransactions API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Configuração do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BanksTransactions API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
