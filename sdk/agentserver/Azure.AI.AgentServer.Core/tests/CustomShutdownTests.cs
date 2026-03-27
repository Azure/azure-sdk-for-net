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
public class CustomShutdownTests
{
    [Test]
    public async Task CustomShutdownTimeout_IsRespected()
    {
        var customTimeout = TimeSpan.FromSeconds(2);

        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.ConfigureShutdown(customTimeout);
        builder.AddInvocations<TestInvocationHandler>();

        var app = builder.Build();
        await app.App.StartAsync();

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await app.App.StopAsync(cts.Token);

        Assert.Pass("Shutdown completed with custom timeout.");
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
