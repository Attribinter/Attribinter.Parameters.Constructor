﻿namespace Paraminter.Parameters.ParaminterMethodParametersServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

public sealed class AddParaminterMethodParameters
{
    [Fact]
    public void IMethodParameterFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IMethodParameterFactory>();

    private static void Target(
        IServiceCollection services)
    {
        ParaminterMethodParametersServices.AddParaminterMethodParameters(services);
    }

    [AssertionMethod]
    private static void ServiceCanBeResolved<TService>()
        where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
