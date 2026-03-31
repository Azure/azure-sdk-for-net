// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class InvocationEndpointTests
{
    [Test]
    public async Task PostInvocations_CallsHandler_And_Returns200()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains("x-agent-invocation-id"), Is.True);
        Assert.That(response.Headers.Contains("x-agent-session-id"), Is.True);

        await app.StopAsync();
    }

    [Test]
    public async Task GetInvocation_Returns404_ByDefault()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/invocations/some-id-123");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        await app.StopAsync();
    }

    [Test]
    public async Task CancelInvocation_Returns404_ByDefault()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/invocations/some-id-123/cancel", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        await app.StopAsync();
    }

    [Test]
    public async Task GetOpenApi_Returns404_ByDefault()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/invocations/docs/openapi.json");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        await app.StopAsync();
    }

    [Test]
    public async Task PostInvocations_IncludesIdentityHeader()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerUserAgent();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();
        app.UseAgentServerUserAgent();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.Headers.Contains("x-platform-server"), Is.True);
        var value = response.Headers.GetValues("x-platform-server").First();
        Assert.That(value, Does.Contain("azure-ai-agentserver-invocations/"));

        await app.StopAsync();
    }

    /// <summary>
    /// Test handler that writes a simple 200 response for HandleAsync
    /// and returns 404 for all other methods (base class defaults).
    /// </summary>
    private sealed class TestInvocationHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("OK", cancellationToken);
        }
    }
}
