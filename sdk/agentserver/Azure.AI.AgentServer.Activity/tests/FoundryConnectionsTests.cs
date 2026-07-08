// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Agents.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Verifies that <see cref="FoundryConnections"/> resolves under dependency injection with
/// the connection settings supplied through <see cref="IConfiguration"/> (the config map
/// produced by <c>ActivityEnvironment.GetHostedAgentConfiguration</c>) rather than from
/// process environment variables.
/// </summary>
[TestFixture]
public class FoundryConnectionsTests
{
    private static ServiceProvider BuildProvider(IReadOnlyDictionary<string, string?> connectionConfig)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<IConfiguration>(
            new ConfigurationBuilder().AddInMemoryCollection(connectionConfig).Build());
        services.AddSingleton<IConnections, FoundryConnections>();
        return services.BuildServiceProvider();
    }

    [Test]
    public void FoundryConnections_ResolvesFromConfiguration()
    {
        var config = new Dictionary<string, string?>
        {
            [ConnectionEnvironment.ClientId] = "11112222-3333-4444-5555-666677778888",
            [ConnectionEnvironment.TenantId] = "tenant-abc",
            [ConnectionEnvironment.Scope0] = ConnectionEnvironment.BotConnectorScope,
        };
        using var provider = BuildProvider(config);

        var connections = provider.GetRequiredService<IConnections>();

        Assert.That(connections, Is.InstanceOf<FoundryConnections>());
        var foundry = (FoundryConnections)connections;
        Assert.Multiple(() =>
        {
            Assert.That(foundry.ClientId, Is.EqualTo("11112222-3333-4444-5555-666677778888"));
            Assert.That(foundry.Scope, Is.EqualTo(ConnectionEnvironment.BotConnectorScope));
        });
    }

    [Test]
    public void FoundryConnections_DefaultsScope_WhenConfigMissingScope()
    {
        var config = new Dictionary<string, string?>
        {
            [ConnectionEnvironment.ClientId] = "client-1",
        };
        using var provider = BuildProvider(config);

        var foundry = (FoundryConnections)provider.GetRequiredService<IConnections>();

        Assert.That(foundry.Scope, Is.EqualTo(ConnectionEnvironment.BotConnectorScope));
    }

    [Test]
    public void FoundryConnections_ProvidesTokenProvider_ForAllAccessors()
    {
        var config = new Dictionary<string, string?>
        {
            [ConnectionEnvironment.ClientId] = "client-1",
            [ConnectionEnvironment.Scope0] = ConnectionEnvironment.BotConnectorScope,
        };
        using var provider = BuildProvider(config);
        var connections = provider.GetRequiredService<IConnections>();

        Assert.Multiple(() =>
        {
            Assert.That(connections.GetDefaultConnection(), Is.Not.Null);
            Assert.That(connections.GetConnection("SERVICE_CONNECTION"), Is.Not.Null);
            Assert.That(connections.TryGetConnection("SERVICE_CONNECTION", out var conn), Is.True);
            Assert.That(conn, Is.Not.Null);
        });
    }
}
