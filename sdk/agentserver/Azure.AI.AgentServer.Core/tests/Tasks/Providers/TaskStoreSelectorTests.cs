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
    private string? _savedHosting;
    private string? _savedTaskApi;

    [SetUp]
    public void SetUp()
    {
        _savedHosting = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        _savedTaskApi = Environment.GetEnvironmentVariable("FOUNDRY_TASK_API_ENABLED");
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", _savedHosting);
        Environment.SetEnvironmentVariable("FOUNDRY_TASK_API_ENABLED", _savedTaskApi);
        FoundryEnvironment.Reload();
    }

    private static void SetEnv(string? hosting, string? taskApi)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", hosting);
        Environment.SetEnvironmentVariable("FOUNDRY_TASK_API_ENABLED", taskApi);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void ReturnsLocalStoreWhenNotHosted()
    {
        SetEnv(hosting: null, taskApi: "1");
        ITaskStore store = TaskStoreSelector.Create(() => throw new InvalidOperationException("hosted factory must not run when not hosted"));
        Assert.That(store, Is.InstanceOf<LocalTaskStore>());
    }

    [Test]
    public void ReturnsLocalStoreWhenHostedButTaskApiDisabled()
    {
        // Hosted but the Task Storage API opt-in flag is unset: the hosted factory must NOT run;
        // the SDK falls back to the local file store (the hosted API is not yet GA).
        SetEnv(hosting: "production", taskApi: null);
        ITaskStore store = TaskStoreSelector.Create(() => throw new InvalidOperationException("hosted factory must not run when the Task API is disabled"));
        Assert.That(store, Is.InstanceOf<LocalTaskStore>());
    }

    [TestCase("1")]
    [TestCase("true")]
    [TestCase("TRUE")]
    [TestCase("yes")]
    public void UsesHostedFactoryWhenHostedAndTaskApiEnabled(string flag)
    {
        SetEnv(hosting: "production", taskApi: flag);
        var sentinel = new LocalTaskStore();
        ITaskStore store = TaskStoreSelector.Create(() => sentinel);
        Assert.That(store, Is.SameAs(sentinel));
    }

    [Test]
    public void ThrowsWhenTaskApiEnabledWithoutFactory()
    {
        SetEnv(hosting: "production", taskApi: "1");
        Assert.Throws<InvalidOperationException>(() => TaskStoreSelector.Create());
    }

    [TestCase("0")]
    [TestCase("false")]
    [TestCase("")]
    public void ReturnsLocalStoreForNonTruthyTaskApiFlag(string flag)
    {
        SetEnv(hosting: "production", taskApi: flag);
        ITaskStore store = TaskStoreSelector.Create(() => throw new InvalidOperationException("hosted factory must not run for a non-truthy flag"));
        Assert.That(store, Is.InstanceOf<LocalTaskStore>());
    }
}
