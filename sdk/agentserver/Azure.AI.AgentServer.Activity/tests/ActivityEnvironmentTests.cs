// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
[NonParallelizable]
public class ActivityEnvironmentTests
{
    private static readonly string[] s_managedVars =
    {
        ConnectionEnvironment.AuthType,
        ConnectionEnvironment.ClientId,
        ConnectionEnvironment.TenantId,
        ConnectionEnvironment.Scope0,
        ConnectionEnvironment.Authority,
        ConnectionEnvironment.ConnectionMapServiceUrl,
        ConnectionEnvironment.ConnectionMapConnection,
        ConnectionEnvironment.FoundryInstanceClientId,
        ConnectionEnvironment.FoundryBlueprintClientId,
        ConnectionEnvironment.FoundryTenantId,
    };

    private static void ClearVars()
    {
        foreach (var name in s_managedVars)
        {
            Environment.SetEnvironmentVariable(name, null);
        }
        FoundryEnvironment.Reload();
    }

    [SetUp]
    public void SetUp() => ClearVars();

    [TearDown]
    public void TearDown() => ClearVars();

    [Test]
    public void GetHostedAgentConfiguration_Default_ReturnsSimpleModeDefaults()
    {
        var config = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.Multiple(() =>
        {
            Assert.That(config[ConnectionEnvironment.AuthType], Is.EqualTo(ConnectionEnvironment.DefaultAuthType));
            Assert.That(config[ConnectionEnvironment.Scope0], Is.EqualTo(ConnectionEnvironment.BotConnectorScope));
            Assert.That(config[ConnectionEnvironment.ConnectionMapServiceUrl], Is.EqualTo(ConnectionEnvironment.DefaultServiceUrl));
            Assert.That(config[ConnectionEnvironment.ConnectionMapConnection], Is.EqualTo(ConnectionEnvironment.DefaultConnectionName));
        });
    }

    [Test]
    public void GetHostedAgentConfiguration_DoesNotMutateEnvironment()
    {
        _ = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.AuthType), Is.Null.Or.Empty);
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.Scope0), Is.Null.Or.Empty);
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ConnectionMapServiceUrl), Is.Null.Or.Empty);
        });
    }

    [Test]
    public void GetHostedAgentConfiguration_DigitalWorker_UsesDigitalWorkerScope()
    {
        var config = ActivityEnvironment.GetHostedAgentConfiguration(digitalWorker: true);

        Assert.That(config[ConnectionEnvironment.Scope0], Is.EqualTo(ConnectionEnvironment.DigitalWorkerScope));
    }

    [Test]
    public void GetHostedAgentConfiguration_SimpleMode_DerivesClientIdFromInstanceVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryInstanceClientId, "instance-client-id");

        var config = ActivityEnvironment.GetHostedAgentConfiguration(digitalWorker: false);

        Assert.That(config[ConnectionEnvironment.ClientId], Is.EqualTo("instance-client-id"));
    }

    [Test]
    public void GetHostedAgentConfiguration_DigitalWorker_DerivesClientIdFromBlueprintVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryBlueprintClientId, "blueprint-client-id");

        var config = ActivityEnvironment.GetHostedAgentConfiguration(digitalWorker: true);

        Assert.That(config[ConnectionEnvironment.ClientId], Is.EqualTo("blueprint-client-id"));
    }

    [Test]
    public void GetHostedAgentConfiguration_SetsTenantIdAndAuthority_FromTenantVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryTenantId, "tenant-123");

        var config = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.Multiple(() =>
        {
            Assert.That(config[ConnectionEnvironment.TenantId], Is.EqualTo("tenant-123"));
            Assert.That(config[ConnectionEnvironment.Authority],
                Is.EqualTo(ConnectionEnvironment.AuthorityFor("tenant-123")));
        });
    }

    [Test]
    public void GetHostedAgentConfiguration_ExistingExplicitValue_TakesPrecedence()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.Scope0, "explicit-scope");

        var config = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.That(config[ConnectionEnvironment.Scope0], Is.EqualTo("explicit-scope"));
    }

    [Test]
    public void GetHostedAgentConfiguration_NoClientIdSource_OmitsClientId()
    {
        var config = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.That(config.ContainsKey(ConnectionEnvironment.ClientId), Is.False);
    }

    [Test]
    public void GetHostedAgentConfiguration_NoTenantIdSource_OmitsTenantAndAuthority()
    {
        var config = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.Multiple(() =>
        {
            Assert.That(config.ContainsKey(ConnectionEnvironment.TenantId), Is.False);
            Assert.That(config.ContainsKey(ConnectionEnvironment.Authority), Is.False);
        });
    }

    [Test]
    public void GetHostedAgentConfiguration_ReturnsFreshMap_OnEachCall()
    {
        var first = ActivityEnvironment.GetHostedAgentConfiguration();
        var second = ActivityEnvironment.GetHostedAgentConfiguration();

        Assert.That(first, Is.Not.SameAs(second));
    }
}
