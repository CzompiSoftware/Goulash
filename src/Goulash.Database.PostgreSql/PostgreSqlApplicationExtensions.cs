using System;
using Goulash.Core;
using Goulash.Database.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Goulash
{
    public static class PostgreSqlApplicationExtensions
    {
        public static GoulashApplication AddPostgreSqlDatabase(this GoulashApplication app)
        {
            app.Services.AddGoulashDbContextProvider<PostgreSqlContext>("PostgreSql", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseNpgsql(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static GoulashApplication AddPostgreSqlDatabase(
            this GoulashApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddPostgreSqlDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
