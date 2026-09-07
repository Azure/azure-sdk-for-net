// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Providers;

[TestFixture]
[NonParallelizable]
public sealed class TaskStoreSelectorTests
{
    private string? _saved;

    [SetUp]
    public void SetUp() => _saved = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", _saved);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void ReturnsLocalStoreWhenNotHosted()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
        FoundryEnvironment.Reload();
        ITaskStore store = TaskStoreSelector.Create();
        Assert.That(store, Is.InstanceOf<LocalTaskStore>());
    }

    [Test]
    public void ThrowsWhenHostedWithoutFactory()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        FoundryEnvironment.Reload();
        Assert.Throws<InvalidOperationException>(() => TaskStoreSelector.Create());
    }

    [Test]
    public void UsesHostedFactoryWhenHosted()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        FoundryEnvironment.Reload();
        var sentinel = new LocalTaskStore();
        ITaskStore store = TaskStoreSelector.Create(() => sentinel);
        Assert.That(store, Is.SameAs(sentinel));
    }
}
