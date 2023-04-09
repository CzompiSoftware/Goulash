using System;
using Goulash.Core;
using Goulash.Gcp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Goulash
{
    public static class GoogleCloudApplicationExtensions
    {
        public static GoulashApplication AddGoogleCloudStorage(this GoulashApplication app)
        {
            app.Services.AddGoulashOptions<GoogleCloudStorageOptions>(nameof(GoulashOptions.Storage));
            app.Services.AddTransient<GoogleCloudStorageService>();

            app.Services.TryAddTransient<IStorageService>(provider => provider.GetRequiredService<GoogleCloudStorageService>());

            app.Services.AddProvider<IStorageService>((provider, config) =>
            {
                if (!config.HasStorageType("GoogleCloud")) return null;

                return provider.GetRequiredService<GoogleCloudStorageService>();
            });

            return app;
        }

        public static GoulashApplication AddGoogleCloudStorage(
            this GoulashApplication app,
            Action<GoogleCloudStorageOptions> configure)
        {
            app.AddGoogleCloudStorage();
            app.Services.Configure(configure);
            return app;
        }
    }
}
