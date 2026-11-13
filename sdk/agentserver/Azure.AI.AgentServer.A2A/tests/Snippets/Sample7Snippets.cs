// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using global::A2A.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample7Snippets
{
    #region Snippet:A2A_Sample7_Registration
    public static void RegisterNativeAgent(IServiceCollection services, AgentCard card)
    {
        services.AddSingleton<ITaskStore, InMemoryTaskStore>();
        services.AddA2AAgent<EchoAgent>(card);
    }
    #endregion

    [Test]
    [Explicit("Starts a server; native registration is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample7_Start
        var builder = WebApplication.CreateBuilder();
        RegisterNativeAgent(builder.Services, CreateCard());
        builder.Services.AddFoundryA2A();

        var app = builder.Build();
        app.MapFoundryA2A();
        app.Run();
        #endregion
    }
}
