using Microsoft.EntityFrameworkCore;
using apiUsuarios.Data;
using Scalar.AspNetCore;

namespace apiUsuarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            // Configura do DbContext - SQLServer
            //configuração do banco de dados utilizando o Entity Framework Core, onde é especificado o tipo de banco de dados (SQL Server) e a string de conexão obtida do arquivo de configuração da aplicação.
            // Entity Framework SQL Server
            // Dependencia do pacote NuGet "Microsoft.EntityFrameworkCore.SqlServer" para configurar o DbContext e permitir a comunicação com o banco de dados SQL Server.
            builder.Services.AddDbContext<AppDbContext>(opction => opction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                // Adiciona o mapeamento para a referência da API Scalar, permitindo que as rotas e endpoints relacionados à API Scalar sejam acessíveis e documentados na interface do OpenAPI.
                // Adiciona Scala Api referente (parte visual para teste de api)
                //Dependencia do pacote NuGet "Scalar.AspNetCore" para adicionar o mapeamento da referência da API Scalar, que é uma biblioteca que facilita a criação de APIs RESTful em ASP.NET Core.
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
