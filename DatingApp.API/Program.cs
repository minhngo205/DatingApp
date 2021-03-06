using DatingApp.DatingApp.API.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var serviceprovider = scope.ServiceProvider;
            try
            {
                var context = serviceprovider.GetRequiredService<DataContext>();
                context.Database.Migrate();
                Seed.SeedUser(context);
            }
            catch (System.Exception)
            {
                var logger = serviceprovider.GetRequiredService<ILogger<Program>>();
                logger.LogError("Failed to migrate database");
                throw;
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
