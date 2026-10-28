// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using global::A2A;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
[NonParallelizable]
public class HostedBehaviorTests
{
    private readonly Dictionary<string, string?> _saved = new();

    [SetUp]
    public void SetUp()
    {
        foreach (var key in new[] { "FOUNDRY_HOSTING_ENVIRONMENT", "FOUNDRY_AGENT_NAME", "FOUNDRY_AGENT_VERSION", "FOUNDRY_AGENT_ID" })
        {
            _saved[key] = Environment.GetEnvironmentVariable(key);
        }

        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "test");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "deployment");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "2.0");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_ID", "deployment-id");
        ReloadEnvironment();
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var pair in _saved)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        ReloadEnvironment();
    }

    private static void ReloadEnvironment() =>
        typeof(FoundryEnvironment).GetMethod("Reload", BindingFlags.Static | BindingFlags.NonPublic)!.Invoke(null, null);

    [Test]
    public void HostedDefaultUsesFoundryStoreButExplicitNativeStoreWins()
    {
        var services = new ServiceCollection();
        services.AddFoundryA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
        using var provider = services.BuildServiceProvider();
        Assert.That(provider.GetRequiredService<ITaskStore>(), Is.TypeOf<FoundryTaskStore>());

        var custom = new InMemoryTaskStore();
        var explicitServices = new ServiceCollection();
        explicitServices.AddSingleton<ITaskStore>(custom);
        explicitServices.AddFoundryA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
        using var explicitProvider = explicitServices.BuildServiceProvider();
        Assert.That(explicitProvider.GetRequiredService<ITaskStore>(), Is.SameAs(custom));
    }

    [Test]
    public async Task HostedPersistenceRequiresIdentityAndVerifiedServerIsolation()
    {
        var backing = new NonIsolatedStore();
        using var store = new FoundryTaskStore(backing);
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await store.GetTaskAsync("t1"));
        await using var app = await HostingTests.CreateAppAsync(services => services.AddSingleton<ITaskStore>(store));
        using var client = app.GetTestClient();
        client.DefaultRequestHeaders.Add("x-agent-foundry-call-id", "brokered-call");
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("GetTask", """{"id":"t1"}"""));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("\"error\""));
        Assert.That(backing.DescriptorReads, Is.EqualTo(1));
    }

    [Test]
    public async Task HostedInvocationAndNativeOperationHaveDistinctIdentitiesAndParentage()
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.A2A",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.Services.AddSingleton<ITaskStore, InMemoryTaskStore>();
        builder.AddA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
        await using var app = builder.Build().App;
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
        await response.Content.ReadAsStringAsync();
        var operation = stopped.Single(a => a.OperationName == "SendMessage");
        var invocation = stopped.Single(a => a.OperationName == "invoke_agent deployment");
        Assert.That(operation.ParentSpanId, Is.EqualTo(invocation.SpanId));
        Assert.That(operation.GetTagItem("gen_ai.agent.name"), Is.EqualTo("native-echo"));
        Assert.That(operation.GetTagItem("gen_ai.agent.version"), Is.EqualTo("1.0"));
        Assert.That(invocation.GetTagItem("gen_ai.agent.name"), Is.EqualTo("deployment"));
        Assert.That(invocation.GetTagItem("gen_ai.agent.version"), Is.EqualTo("2.0"));
        using var lookup = await client.PostAsync("/a2a", HostingTests.Rpc("GetTask", """{"id":"missing"}"""));
        await lookup.Content.ReadAsStringAsync();
        Assert.That(stopped.Count(a => a.OperationName.StartsWith("invoke_agent", StringComparison.Ordinal)), Is.EqualTo(1));
    }

    private sealed class NonIsolatedStore : FoundryStateStore
    {
        public int DescriptorReads { get; private set; }

        public override Task<StateStore?> GetAsync(CancellationToken cancellationToken = default)
        {
            DescriptorReads++;
            return Task.FromResult<StateStore?>(AzureAIAgentServerCoreStorageModelFactory.StateStore(userIsolation: false));
        }

        public override Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken = default) =>
            throw new AssertionException("Item access must not occur when server isolation is disabled.");
    }
}
