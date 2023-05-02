using BancoAPI.Data;
using BancoAPI.Mapper;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add conection string to the container.
            var connectionString = builder.Configuration.GetConnectionString("DockerSQLApi");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            // Add Automapper to the container.
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}