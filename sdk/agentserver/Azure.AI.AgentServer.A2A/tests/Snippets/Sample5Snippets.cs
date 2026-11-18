// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample5Snippets
{
    #region Snippet:A2A_Sample5_Handler
    public sealed record GreetingSettings(string Prefix);

    public class GreetingAgent(GreetingSettings settings) : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            await new MessageResponder(eventQueue, context.ContextId).ReplyAsync(
                $"{settings.Prefix}: {context.UserText}", cancellationToken: cancellationToken);
        }
    }
    #endregion

    #region Snippet:A2A_Sample5_Configure
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(new GreetingSettings("Welcome"));
        services.AddSingleton<ITaskStore, InMemoryTaskStore>();
    }
    #endregion

    [Test]
    [Explicit("Starts a server; the handler is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample5_Start
        var builder = AgentHost.CreateBuilder();
        ConfigureServices(builder.Services);
        builder.AddA2A<GreetingAgent>(CreateCard(), options =>
        {
            options.AutoAppendHistory = false;
        });
        builder.Build().Run();
        #endregion
    }
}
