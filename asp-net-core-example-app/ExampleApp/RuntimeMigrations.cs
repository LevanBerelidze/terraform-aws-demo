using ExampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp
{
    public static class RuntimeMigrations
    {
        public static void ApplyMigrations(this IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
        }
    }
}
