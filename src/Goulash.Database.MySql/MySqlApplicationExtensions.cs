using System;
using Goulash.Core;
using Goulash.Database.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Goulash
{
    public static class MySqlApplicationExtensions
    {
        public static GoulashApplication AddMySqlDatabase(this GoulashApplication app)
        {
            app.Services.AddGoulashDbContextProvider<MySqlContext>("MySql", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseMySql(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static GoulashApplication AddMySqlDatabase(
            this GoulashApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddMySqlDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
