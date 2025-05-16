// Data/DatabaseSeeder.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace OrganizedScannApi.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Aqui você pode adicionar dados iniciais se quiser
            if (!context.Motorcycles.Any())
            {
                context.Motorcycles.Add(new Models.Motorcycle
                {
                    // Inicialize com dados básicos
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
