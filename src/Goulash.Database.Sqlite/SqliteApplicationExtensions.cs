using System;
using Goulash.Core;
using Goulash.Database.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Goulash
{
    public static class SqliteApplicationExtensions
    {
        public static GoulashApplication AddSqliteDatabase(this GoulashApplication app)
        {
            app.Services.AddGoulashDbContextProvider<SqliteContext>("Sqlite", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlite(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static GoulashApplication AddSqliteDatabase(
            this GoulashApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddSqliteDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
