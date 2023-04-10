using System;
using Microsoft.Extensions.DependencyInjection;

namespace Goulash.Core;

public class GoulashApplication
{
    public GoulashApplication(IServiceCollection services)
    {
        Services = services ?? throw new ArgumentNullException(nameof(services));
    }

    public IServiceCollection Services { get; }
}
