using Ejercicio4Modulo2;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DBContext>(options => 
                options.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=Password12345;"));

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}