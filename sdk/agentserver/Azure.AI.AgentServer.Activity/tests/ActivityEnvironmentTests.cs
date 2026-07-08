// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Activity.Internal;
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
    }

    [SetUp]
    public void SetUp() => ClearVars();

    [TearDown]
    public void TearDown() => ClearVars();

    [Test]
    public void InitializeEnvironment_Default_SetsSimpleModeDefaults()
    {
        ActivityEnvironment.InitializeEnvironment();

        Assert.Multiple(() =>
        {
            Assert.That(ActivityEnvironment.IsDigitalWorkerMode, Is.False);
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.AuthType),
                Is.EqualTo(ConnectionEnvironment.DefaultAuthType));
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.Scope0),
                Is.EqualTo(ConnectionEnvironment.BotConnectorScope));
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ConnectionMapServiceUrl),
                Is.EqualTo(ConnectionEnvironment.DefaultServiceUrl));
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ConnectionMapConnection),
                Is.EqualTo(ConnectionEnvironment.DefaultConnectionName));
        });
    }

    [Test]
    public void InitializeEnvironment_DigitalWorker_SetsDigitalWorkerScope()
    {
        ActivityEnvironment.InitializeEnvironment(digitalWorker: true);

        Assert.Multiple(() =>
        {
            Assert.That(ActivityEnvironment.IsDigitalWorkerMode, Is.True);
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.Scope0),
                Is.EqualTo(ConnectionEnvironment.DigitalWorkerScope));
        });
    }

    [Test]
    public void InitializeEnvironment_SimpleMode_DerivesClientIdFromInstanceVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryInstanceClientId, "instance-client-id");

        ActivityEnvironment.InitializeEnvironment(digitalWorker: false);

        Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ClientId),
            Is.EqualTo("instance-client-id"));
    }

    [Test]
    public void InitializeEnvironment_DigitalWorker_DerivesClientIdFromBlueprintVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryBlueprintClientId, "blueprint-client-id");

        ActivityEnvironment.InitializeEnvironment(digitalWorker: true);

        Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ClientId),
            Is.EqualTo("blueprint-client-id"));
    }

    [Test]
    public void InitializeEnvironment_SetsTenantIdAndAuthority_FromTenantVar()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryTenantId, "tenant-123");

        ActivityEnvironment.InitializeEnvironment();

        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.TenantId), Is.EqualTo("tenant-123"));
            Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.Authority),
                Is.EqualTo(ConnectionEnvironment.AuthorityFor("tenant-123")));
        });
    }

    [Test]
    public void InitializeEnvironment_NeverOverwrites_ExistingValue()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.Scope0, "explicit-scope");

        ActivityEnvironment.InitializeEnvironment();

        Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.Scope0), Is.EqualTo("explicit-scope"));
    }

    [Test]
    public void InitializeEnvironment_IsIdempotent()
    {
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryInstanceClientId, "id-1");
        ActivityEnvironment.InitializeEnvironment();

        // A second call with a different derived client id must not overwrite the first.
        Environment.SetEnvironmentVariable(ConnectionEnvironment.FoundryInstanceClientId, "id-2");
        ActivityEnvironment.InitializeEnvironment();

        Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ClientId), Is.EqualTo("id-1"));
    }

    [Test]
    public void InitializeEnvironment_NoClientIdSource_DoesNotSetClientId()
    {
        ActivityEnvironment.InitializeEnvironment();

        Assert.That(Environment.GetEnvironmentVariable(ConnectionEnvironment.ClientId), Is.Null.Or.Empty);
    }
}
