
using FarmaApi2.Data.DBContext;
using FarmaApi2.Interfaces;
using FarmaApi2.Repositories;
using FarmaApi2.Services;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


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

            string mysqlString = "server=localhost; port=3306; database=farma_api;user=root;password=1234;Persist Security Info=False; Convert Zero DateTime=True";

            builder.Services.AddDbContext<Context>(options =>
                options.UseMySql(mysqlString, ServerVersion.AutoDetect(mysqlString)));

            
            builder.Services.AddScoped<IClientService,ClientService>();

            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ISaleService, SaleService>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ISaleRepository, SaleRepository>();

            #region  Autorizacao
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando o esquema Bearer. Exemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme, 
                                Id = "Bearer" 
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            
            var authenticationOptions = builder
                .Configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Get<KeycloakAuthenticationOptions>();

            builder.Services.AddKeycloakAuthentication(authenticationOptions);

            var authorizationOptions = builder
                .Configuration
                .GetSection(KeycloakProtectionClientOptions.Section)
                .Get<KeycloakProtectionClientOptions>();

            builder.Services.AddKeycloakAuthorization(authorizationOptions);

            var adminClientOptions = builder
                .Configuration
                .GetSection(KeycloakAdminClientOptions.Section)
                .Get<KeycloakAdminClientOptions>();

            builder.Services.AddKeycloakAdminHttpClient(adminClientOptions);
            
            
            #endregion            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); //Parte da autorização
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
