// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample10Snippets
{
    [Test]
    [Explicit("Starts a server; the self-hosted pipeline is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample10_Start
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
        var app = builder.Build();
        app.MapGet("/", () => "My application");
        app.MapFoundryA2A();
        app.Run();
        #endregion
    }

    [Test]
    [Explicit("Starts a server; route-only mapping is exercised by SampleEndToEndTests.")]
    public void MapRoutesSeparately()
    {
        #region Snippet:A2A_Sample10_Routes
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapHealthChecks("/readiness");
        ((IEndpointRouteBuilder)app).MapFoundryA2A();
        app.Run();
        #endregion
    }
}
