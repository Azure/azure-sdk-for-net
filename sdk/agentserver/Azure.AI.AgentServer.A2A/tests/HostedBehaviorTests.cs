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
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
[NonParallelizable]
public class HostedBehaviorTests
{
    private readonly Dictionary<string, string?> _saved = new();

    [SetUp]
    public void SetUp()
    {
        foreach (var key in new[]
        {
            "FOUNDRY_HOSTING_ENVIRONMENT", "FOUNDRY_AGENT_NAME", "FOUNDRY_AGENT_VERSION", "FOUNDRY_AGENT_ID",
            "AZURE_TOKEN_CREDENTIALS", "AZURE_TENANT_ID", "AZURE_CLIENT_ID", "AZURE_CLIENT_SECRET", "AZURE_FEDERATED_TOKEN_FILE",
        })
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

    [TestCase("EnvironmentCredential")]
    [TestCase("WorkloadIdentityCredential")]
    public void HostedCredentialHonorsOperatorSelectionWithoutNetworkAccess(string selection)
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", selection);
        foreach (string key in new[] { "AZURE_TENANT_ID", "AZURE_CLIENT_ID", "AZURE_CLIENT_SECRET", "AZURE_FEDERATED_TOKEN_FILE" })
        {
            Environment.SetEnvironmentVariable(key, null);
        }

        using var store = new FoundryTaskStore("credential-test");
        var credential = store.ResolveCredential();
        Assert.That(credential, Is.TypeOf<DefaultAzureCredential>());
        Assert.That(store.ResolveCredential(), Is.SameAs(credential));
        var exception = Assert.CatchAsync<CredentialUnavailableException>(async () =>
            await credential!.GetTokenAsync(new TokenRequestContext(["https://ai.azure.com/.default"]), CancellationToken.None));
        Assert.That(exception!.Message, Does.Contain(selection));
    }

    [Test]
    public void ExplicitCredentialWinsOverDefaultSelection()
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "invalid-selection");
        var supplied = new TestCredential();
        using var store = new FoundryTaskStore("credential-test", credential: supplied);
        Assert.That(store.ResolveCredential(), Is.SameAs(supplied));
    }

    [TestCase(null)]
    [TestCase("")]
    public void DefaultHostedFallbackExcludesDeveloperCredentials(string? selection)
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", selection);
        var options = FoundryTaskStore.CreateDefaultCredentialOptions();
        Assert.That(options.ExcludeEnvironmentCredential, Is.False);
        Assert.That(options.ExcludeWorkloadIdentityCredential, Is.False);
        Assert.That(options.ExcludeManagedIdentityCredential, Is.False);
        Assert.That(options.ExcludeVisualStudioCredential, Is.True);
        Assert.That(options.ExcludeVisualStudioCodeCredential, Is.True);
        Assert.That(options.ExcludeAzureCliCredential, Is.True);
        Assert.That(options.ExcludeAzurePowerShellCredential, Is.True);
        Assert.That(options.ExcludeAzureDeveloperCliCredential, Is.True);
        Assert.That(options.ExcludeBrokerCredential, Is.True);
    }

    [Test]
    public void ExplicitOperatorSelectionCanEnableDeveloperCredentials()
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "AzureCliCredential");
        var options = FoundryTaskStore.CreateDefaultCredentialOptions();
        Assert.That(options.ExcludeAzureCliCredential, Is.False);
        using var store = new FoundryTaskStore("credential-test");
        Assert.That(store.ResolveCredential(), Is.TypeOf<DefaultAzureCredential>());
    }

    [Test]
    public void InvalidOperatorSelectionIsNotReplacedByFallback()
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "invalid-selection");
        using var store = new FoundryTaskStore("credential-test");
        var exception = Assert.Throws<InvalidOperationException>(() => store.ResolveCredential());
        Assert.That(exception!.Message, Does.Contain("AZURE_TOKEN_CREDENTIALS"));
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            throw new AssertionException("Credential resolution must not acquire a token.");

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            throw new AssertionException("Credential resolution must not acquire a token.");
    }

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
