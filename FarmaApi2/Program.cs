
using FarmaApi2.Data.DBContext;
using FarmaApi2.Interfaces;
using FarmaApi2.Repositories;
using FarmaApi2.Services;
using Microsoft.EntityFrameworkCore;

namespace FarmaApi2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string mysqlString = "server=localhost; port=3306; database=farma_api;user=root;password=1234;Persist Security Info =False; Convert Zero DateTime=True";

            builder.Services.AddDbContext<Context>(options =>
                options.UseMySql(mysqlString, ServerVersion.AutoDetect(mysqlString)));

            
            builder.Services.AddScoped<IClientService,ClientService>();

            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ISaleService, SaleService>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ISaleRepository, SaleRepository>();

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
    }
}
