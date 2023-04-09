using System;
using Goulash.Core;
using Goulash.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Goulash
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGoulashWebApplication(
            this IServiceCollection services,
            Action<GoulashApplication> configureAction)
        {
            services
                .AddRouting(options => options.LowercaseUrls = true)
                .AddControllers()
                .AddApplicationPart(typeof(PackageContentController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddRazorPages();

            services.AddHttpContextAccessor();
            services.AddTransient<IUrlGenerator, GoulashUrlGenerator>();

            services.AddGoulashApplication(configureAction);

            return services;
        }
    }
}
