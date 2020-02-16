using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            SeedDb(host);

            host.Run();
        }

        private static void SeedDb(IHost host)
        {
            var scopefactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopefactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                seeder.Seed();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //remove default configuration options
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
