using ExampleApp.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(dbContextOptions =>
            {
                string connectionString = builder.Configuration.GetConnectionString("Database");
                dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            builder.Services.AddControllers();

            WebApplication app = builder.Build();
            app.UseForwardedHeaders();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.ApplyMigrations();
            app.Run();
        }
    }
}