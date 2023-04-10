using System;
using Goulash.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Goulash;

public static class GoulashApplicationExtensions
{
    public static GoulashApplication AddFileStorage(this GoulashApplication app)
    {
        app.Services.TryAddTransient<IStorageService>(provider => provider.GetRequiredService<FileStorageService>());
        return app;
    }

    public static GoulashApplication AddFileStorage(
        this GoulashApplication app,
        Action<FileSystemStorageOptions> configure)
    {
        app.AddFileStorage();
        app.Services.Configure(configure);
        return app;
    }

    public static GoulashApplication AddNullStorage(this GoulashApplication app)
    {
        app.Services.TryAddTransient<IStorageService>(provider => provider.GetRequiredService<NullStorageService>());
        return app;
    }

    public static GoulashApplication AddNullSearch(this GoulashApplication app)
    {
        app.Services.TryAddTransient<ISearchIndexer>(provider => provider.GetRequiredService<NullSearchIndexer>());
        app.Services.TryAddTransient<ISearchService>(provider => provider.GetRequiredService<NullSearchService>());
        return app;
    }
}
