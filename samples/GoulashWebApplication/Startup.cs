using Goulash;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoulashWebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGoulashWebApplication(app =>
            {
                // Use SQLite as Goulash's database and store packages on the local file system.
                app.AddSqliteDatabase();
                app.AddFileStorage();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Add Goulash's endpoints.
                var goulash = new GoulashEndpointBuilder();

                goulash.MapEndpoints(endpoints);
            });
        }
    }
}
