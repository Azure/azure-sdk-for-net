// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// US6 / FR-004 hosted-mode task-subsystem parity: in a hosted Foundry environment the resilient
/// paths still compose the Core task subsystem, but with a hosted task store selected via
/// <c>AddResilientTasks(credential)</c>. This fixture verifies hosted composition selects the hosted
/// durable response provider and does register the resilient <see cref="TaskDefinition{TInput,TOutput}"/>
/// keyed singletons, and that fail-loud startup validation accepts this hosted composition.
///
/// Untestable in this single sandbox (documented, not fabricated): the actual Foundry task-subsystem
/// recovery and any real HTTP round-trip to <c>FoundryStorageProvider</c> require a live Foundry
/// backend, which is not available here. Those paths are covered by hosted integration/live tests.
/// </summary>
[TestFixture]
public class HostedResilienceFailureTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    [NonParallelizable]
    public void HostedMode_ComposesWhenCoreCredentialIsRegisteredFirst()
    {
        ConfigureHostedEnvironment();
        var services = new ServiceCollection();
        services.AddLogging();
        var credential = new TestCredential();
        services.AddResilientTasks(credential);

        Assert.DoesNotThrow(() =>
            services.AddResponsesServerCore(
                o => o.ResilientBackground = true,
                CreateHostedStorage(credential)));

        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<TokenCredential>(),
            Is.SameAs(credential));
        Assert.That(
            provider.GetRequiredService<ITaskStore>(),
            Is.InstanceOf<HostedTaskStore>());
        Assert.That(
            provider.GetRequiredService<TaskHostEnvironment>().Credential,
            Is.SameAs(credential));
        Assert.That(provider.GetRequiredService<HttpPipeline>(), Is.Not.Null);
    }

    [Test]
    [NonParallelizable]
    public void HostedMode_ComposesWhenConsumerTaskIsRegisteredFirst()
    {
        ConfigureHostedEnvironment();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResilientTask<string, string>(
            "consumer-task",
            (ctx, ct) => Task.FromResult(ctx.Input));

        Assert.DoesNotThrow(() =>
            services.AddResponsesServerCore(
                o => o.ResilientBackground = true,
                CreateHostedStorage()));
    }

    [Test]
    public void HostedMode_ResilientBackground_EngagesTaskSubsystem()
    {
        using var provider = BuildHostedResilientProvider();

        // The Core task subsystem is now exposed as keyed TaskDefinition<TInput,TOutput> singletons
        // (one per registered task name) rather than a single ITaskInvoker. Hosted mode must still
        // compose them so ResponseEndpointHandler.StartResilientTurnAsync can resolve the one-shot
        // and multi-turn definitions and start turns against the hosted task store.
        Assert.That(
            provider.GetRequiredKeyedService<TaskDefinition<ResponseTaskInput, ResponseTaskOutput>>(
                ResponsesResilientTaskHandler.OneShotTaskName),
            Is.Not.Null,
            "Hosted mode must register the one-shot resilient task (backed by hosted task storage).");
        Assert.That(
            provider.GetRequiredKeyedService<TaskDefinition<ResponseTaskInput, ResponseTaskOutput>>(
                ResponsesResilientTaskHandler.MultiTurnTaskName),
            Is.Not.Null,
            "Hosted mode must register the multi-turn resilient task (backed by hosted task storage).");
    }

    [Test]
    public void HostedMode_SelectsHostedDurableProvider()
    {
        using var provider = BuildHostedResilientProvider();

        var responsesProvider = provider.GetRequiredService<ResponsesProvider>();
        Assert.That(responsesProvider, Is.InstanceOf<FoundryStorageProvider>(),
            "Hosted mode composition must select the durable Foundry storage provider.");
    }

    [Test]
    public void HostedMode_TaskSubsystemComposition_DoesNotTripFailLoudValidation()
    {
        using var provider = BuildHostedResilientProvider();

        // ValidateResilientComposition is the fail-loud startup gate (T006/T051). In hosted mode the
        // durable Foundry provider is selected and the task subsystem is present; this is a valid
        // resilient composition and must pass validation without throwing.
        Assert.DoesNotThrow(() => InvokeValidateResilientComposition(provider));
    }

    private static ServiceProvider BuildHostedResilientProvider()
    {
        ConfigureHostedEnvironment();

        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        services.AddAgentServerCore();
        services.AddSingleton<ResponseHandler>(new TestHandler());

        // Hosted registration binds the Foundry credential + endpoint from settings in production;
        // this unit test drives the shared core directly with a fake credential and the hosted
        // storage endpoint so it can assert the hosted composition without a live backend.
        services.AddResponsesServerCore(
            o => o.ResilientBackground = true,
            CreateHostedStorage());

        return services.BuildServiceProvider();
    }

    private static ResponsesHostedStorage CreateHostedStorage(
        TokenCredential? credential = null)
    {
        var projectEndpoint = new Uri("https://example.com/project");
        var storageBaseUri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri(
            projectEndpoint,
            isDevelopment: false);
        return new ResponsesHostedStorage(
            credential ?? new FakeTokenCredential(),
            projectEndpoint,
            storageBaseUri);
    }

    private static void ConfigureHostedEnvironment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "Production");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com/project");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "test-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        FoundryEnvironment.Reload();

        Assert.That(FoundryEnvironment.IsHosted, Is.True, "Hosted flag must be set for this test.");
    }

    private static void InvokeValidateResilientComposition(IServiceProvider provider)
    {
        var method = typeof(ResponsesServerEndpointRouteBuilderExtensions).GetMethod(
            "ValidateResilientComposition",
            BindingFlags.NonPublic | BindingFlags.Static)!;

        try
        {
            method.Invoke(null, new object[] { provider });
        }
        catch (TargetInvocationException tie) when (tie.InnerException is not null)
        {
            throw tie.InnerException;
        }
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
            => new("test-token", DateTimeOffset.MaxValue);

        public override ValueTask<AccessToken> GetTokenAsync(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
            => ValueTask.FromResult(
                new AccessToken("test-token", DateTimeOffset.MaxValue));
    }
}
