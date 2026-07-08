// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Security.Claims;
using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Verifies that <see cref="ActivityServerOptions"/> overrides flow through
/// <see cref="ActivityStack.RegisterM365Services"/> and
/// <see cref="ActivityStack.GetConnectionConfiguration"/> into the built stack.
/// </summary>
[TestFixture]
public class ActivityStackOptionsTests
{
    private static ServiceProvider BuildProvider(ActivityServerOptions options)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<IConfiguration>(
            new ConfigurationBuilder()
                .AddInMemoryCollection(ActivityStack.GetConnectionConfiguration(options))
                .Build());
        ActivityStack.RegisterM365Services(services, options);
        return services.BuildServiceProvider();
    }

    [Test]
    public void GetConnectionConfiguration_PrefersSuppliedConfiguration()
    {
        var supplied = new Dictionary<string, string?>
        {
            [ConnectionEnvironment.ClientId] = "supplied-client",
        };
        var options = new ActivityServerOptions { ConnectionConfiguration = supplied };

        var result = ActivityStack.GetConnectionConfiguration(options);

        Assert.That(result, Is.SameAs(supplied));
    }

    [Test]
    public void RegisterM365Services_UsesSuppliedStorage()
    {
        var storage = new MemoryStorage();
        using var provider = BuildProvider(new ActivityServerOptions { Storage = storage });

        Assert.That(provider.GetRequiredService<IStorage>(), Is.SameAs(storage));
    }

    [Test]
    public void RegisterM365Services_DefaultsToMemoryStorage_WhenNoneSupplied()
    {
        using var provider = BuildProvider(new ActivityServerOptions());

        Assert.That(provider.GetRequiredService<IStorage>(), Is.InstanceOf<MemoryStorage>());
    }

    [Test]
    public void RegisterM365Services_UsesSuppliedConnections()
    {
        var connections = new StubConnections();
        using var provider = BuildProvider(new ActivityServerOptions { Connections = connections });

        Assert.That(provider.GetRequiredService<IConnections>(), Is.SameAs(connections));
    }

    [Test]
    public void RegisterM365Services_DefaultsToFoundryConnections_WhenNoneSupplied()
    {
        using var provider = BuildProvider(new ActivityServerOptions());

        Assert.That(provider.GetRequiredService<IConnections>(), Is.InstanceOf<FoundryConnections>());
    }

    [Test]
    public void RegisterM365Services_InvokesConfigureServices()
    {
        var marker = new Marker();
        var options = new ActivityServerOptions
        {
            ConfigureServices = services => services.AddSingleton(marker),
        };

        using var provider = BuildProvider(options);

        Assert.That(provider.GetRequiredService<Marker>(), Is.SameAs(marker));
    }

    private sealed class Marker
    {
    }

    private sealed class StubConnections : IConnections
    {
        public IAccessTokenProvider GetConnection(string name) => throw new System.NotImplementedException();

        public IAccessTokenProvider GetDefaultConnection() => throw new System.NotImplementedException();

        public bool TryGetConnection(string name, out IAccessTokenProvider connection) => throw new System.NotImplementedException();

        public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, string serviceUrl) => throw new System.NotImplementedException();

        public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, IActivity activity) => throw new System.NotImplementedException();
    }
}
