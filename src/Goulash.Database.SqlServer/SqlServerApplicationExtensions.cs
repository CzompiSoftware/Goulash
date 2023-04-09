using System;
using Goulash.Core;
using Goulash.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Goulash
{
    public static class SqlServerApplicationExtensions
    {
        public static GoulashApplication AddSqlServerDatabase(this GoulashApplication app)
        {
            app.Services.AddGoulashDbContextProvider<SqlServerContext>("SqlServer", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlServer(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static GoulashApplication AddSqlServerDatabase(
            this GoulashApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddSqlServerDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
