using Beverages_WebAPI.DataAccess.Implementations;
using Beverages_WebAPI.DataAccess.Interfaces;
using Beverages_WebAPI.Services.Implementations;
using Beverages_WebAPI.Services.Interfaces;

namespace Beverages_WebAPI
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
            builder.Services.AddTransient<IBeverageService, BeverageService>();
            builder.Services.AddTransient<IBeverageRepository, BeverageRepository>();
            builder.Services.AddSwaggerGen();

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
