// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// US6 / FR-004 hosted-mode task-subsystem parity: in a hosted Foundry environment the resilient
/// paths still compose the Core task subsystem, but with a hosted task store selected via
/// <c>AddResilientTasks(credential)</c>. This fixture verifies hosted composition selects the hosted
/// durable response provider and does register <see cref="ITaskInvoker"/>, and that fail-loud startup
/// validation accepts this hosted composition.
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
    public void HostedMode_ResilientBackground_EngagesTaskSubsystem()
    {
        using var provider = BuildHostedResilientProvider();

        Assert.That(provider.GetService<ITaskInvoker>(), Is.Not.Null,
            "Hosted mode must register the Core task invoker (backed by hosted task storage).");
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
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "Production");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com/project");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "test-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        FoundryEnvironment.Reload();

        Assert.That(FoundryEnvironment.IsHosted, Is.True, "Hosted flag must be set for this test.");

        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        services.AddAgentServerCore();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer(o => o.ResilientBackground = true);

        return services.BuildServiceProvider();
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
}
