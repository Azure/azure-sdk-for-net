// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using global::A2A.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample6Snippets
{
    [Test]
    [Explicit("Starts a server; the existing-handler path is exercised by SampleEndToEndTests.")]
    public async Task StartServerAsync()
    {
        #region Snippet:A2A_Sample6_Start
        var card = CreateCard();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<ITaskStore, InMemoryTaskStore>();
        services.AddA2AAgent<TaskAgent>(card);

        await using var nativeServices = services.BuildServiceProvider();
        var requestHandler = nativeServices.GetRequiredService<IA2ARequestHandler>();
        A2AAgentServer.Run(card, requestHandler);
        #endregion
    }
}
