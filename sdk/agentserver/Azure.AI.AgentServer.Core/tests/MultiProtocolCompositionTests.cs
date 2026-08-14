// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class MultiProtocolCompositionTests
{
    [Test]
    public async Task InvocationsEndpoint_AndHealthEndpoint_BothReachable()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<TestInvocationHandler>();

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        // POST /invocations works
        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // GET /readiness works
        var healthResponse = await client.GetAsync("/readiness");
        Assert.That(healthResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    [Test]
    public void DuplicateProtocol_ThrowsInvalidOperationException()
    {
        var builder = AgentHost.CreateBuilder();
        builder.AddInvocations<TestInvocationHandler>();

        Assert.Throws<InvalidOperationException>(() =>
        {
            builder.AddInvocations<TestInvocationHandler>();
        });
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
