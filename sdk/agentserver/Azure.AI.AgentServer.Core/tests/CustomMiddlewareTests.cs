// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class CustomMiddlewareTests
{
    [Test]
    public async Task CustomRoute_WorksAlongsideProtocol()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<TestInvocationHandler>();

        var app = builder.Build();

        // Use escape hatch to add custom route
        app.App.MapGet("/custom", () => Results.Ok("custom-route"));

        await app.App.StartAsync();
        var client = app.App.GetTestClient();

        // Custom route
        var customResponse = await client.GetAsync("/custom");
        Assert.That(customResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await customResponse.Content.ReadAsStringAsync();
        Assert.That(body, Does.Contain("custom-route"));

        // Protocol route still works
        var invResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    private sealed class TestInvocationHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("ok", cancellationToken);
        }
    }
}
