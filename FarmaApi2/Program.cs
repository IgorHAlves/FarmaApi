
using FarmaApi2.Data.DBContext;
using FarmaApi2.Interfaces;
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

            string mysqlString = "server=localhost; port:3306; database=nome_banco;user=nome_user;passsword=senha;Persist Security Info =False; Convert Zero DateTime=True";

            builder.Services.AddDbContext<Context>(options =>
                options.UseMySql("", ServerVersion.AutoDetect(mysqlString)));

            builder.Services.AddScoped<IClientService>();

            builder.Services.AddScoped<IProductService>();
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
