// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NUnit.Framework;
using OpenTelemetry.Trace;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.Sample5Snippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample8Snippets
{
    #region Snippet:A2A_Sample8_Configure
    public static void ConfigureHost(AgentHostBuilder builder)
    {
        builder.Services.AddSingleton(new GreetingSettings("Configured"));
        builder.ConfigureShutdown(TimeSpan.FromSeconds(15));
        builder.ConfigureHealth(health => health.AddCheck(
            "application", () => HealthCheckResult.Healthy()));
        builder.ConfigureTracing(tracing => tracing.AddSource("Echo.Application"));
    }
    #endregion

    [Test]
    [Explicit("Starts a server; host configuration is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample8_Start
        A2AAgentServer.Run<GreetingAgent>(
            CreateCard(),
            configure: ConfigureHost);
        #endregion
    }
}
