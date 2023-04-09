using System;
using System.Threading;
using System.Threading.Tasks;
using Goulash.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Goulash.Web
{
    public static class IHostExtensions
    {
        public static IHostBuilder UseGoulash(this IHostBuilder host, Action<GoulashApplication> configure)
        {
            return host.ConfigureServices(services =>
            {
                services.AddGoulashWebApplication(configure);
            });
        }

        public static async Task RunMigrationsAsync(
            this IHost host,
            CancellationToken cancellationToken = default)
        {
            // Run migrations if necessary.
            var options = host.Services.GetRequiredService<IOptions<GoulashOptions>>();

            if (options.Value.RunMigrationsAtStartup)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<IContext>();
                    if (ctx != null)
                    {
                        await ctx.RunMigrationsAsync(cancellationToken);
                    }
                }
            }
        }

        public static bool ValidateStartupOptions(this IHost host)
        {
            return host
                .Services
                .GetRequiredService<ValidateStartupOptions>()
                .Validate();
        }
    }
}
