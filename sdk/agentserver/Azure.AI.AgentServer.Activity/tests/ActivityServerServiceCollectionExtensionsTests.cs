// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ActivityServerServiceCollectionExtensionsTests
{
    private static IServiceCollection NewServices()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        return services;
    }

    [Test]
    public void AddActivityServer_ReturnsSameCollection_ForChaining()
    {
        var services = NewServices();

        var result = services.AddActivityServerServices();

        Assert.That(result, Is.SameAs(services));
    }

    [Test]
    public void AddActivityServer_RegistersActivityProtocolActivitySource()
    {
        var services = NewServices();
        services.AddActivityServerServices();

        using var provider = services.BuildServiceProvider();

        Assert.That(provider.GetService<ActivityProtocolActivitySource>(), Is.Not.Null);
    }

    [Test]
    public void AddActivityServer_RegistersStartupLogger_AsHostedService()
    {
        var services = NewServices();
        services.AddActivityServerServices();

        using var provider = services.BuildServiceProvider();
        var hostedServices = provider.GetServices<IHostedService>();

        Assert.That(hostedServices.Any(s => s is ActivityStartupLogger), Is.True);
    }

    [Test]
    public void AddActivityServer_WithoutConfigure_DefaultsDigitalWorkerFalse()
    {
        var services = NewServices();
        services.AddActivityServerServices();

        using var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ActivityServerOptions>>().Value;

        Assert.That(options.DigitalWorker, Is.False);
    }

    [Test]
    public void AddActivityServer_WithConfigure_AppliesOptions()
    {
        var services = NewServices();
        services.AddActivityServerServices(o => o.DigitalWorker = true);

        using var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ActivityServerOptions>>().Value;

        Assert.That(options.DigitalWorker, Is.True);
    }

    [Test]
    public void AddActivityServer_CanBeCalledMultipleTimes()
    {
        var services = NewServices();

        Assert.That(() =>
        {
            services.AddActivityServerServices();
            services.AddActivityServerServices();
            using var provider = services.BuildServiceProvider();
            _ = provider.GetService<ActivityProtocolActivitySource>();
        }, Throws.Nothing);
    }
}
