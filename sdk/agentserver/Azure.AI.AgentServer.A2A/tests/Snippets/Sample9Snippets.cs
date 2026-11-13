// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.Sample5Snippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample9Snippets
{
    #region Snippet:A2A_Sample9_Handler
    public class StatusHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            await response.WriteAsync("Agent is ready", cancellationToken);
        }
    }
    #endregion

    #region Snippet:A2A_Sample9_Configure
    public static void ConfigureHost(AgentHostBuilder builder)
    {
        builder.Services.AddSingleton(new GreetingSettings("Composed"));
        builder.AddA2A<GreetingAgent>(CreateCard());
        builder.AddInvocations<StatusHandler>();
    }
    #endregion

    [Test]
    [Explicit("Starts a server; both protocols are exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample9_Start
        var builder = AgentHost.CreateBuilder();
        ConfigureHost(builder);
        builder.Build().Run();
        #endregion
    }
}
