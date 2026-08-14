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
public class Tier1InvocationsStartupTests
{
    [Test]
    public async Task AgentHostBuilder_WithInvocations_StartsSuccessfully()
    {
        // Use builder API (Tier 2) since Tier 1 InvocationsServer.Run requires actual port binding
        var appBuilder = AgentHost.CreateBuilder();
        appBuilder.WebApplicationBuilder.WebHost.UseTestServer();
        appBuilder.AddInvocations<TestHandler>();

        var app = appBuilder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        // Verify POST /invocations works
        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Verify response headers
        Assert.That(invocationResponse.Headers.Contains("x-agent-invocation-id"), Is.True);
        Assert.That(invocationResponse.Headers.Contains("x-agent-session-id"), Is.True);

        // Verify x-platform-server identity header
        Assert.That(invocationResponse.Headers.Contains("x-platform-server"), Is.True);

        // Verify GET /readiness returns 200
        var healthResponse = await client.GetAsync("/readiness");
        Assert.That(healthResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    [Test]
    public async Task AgentHostBuilder_WithFactoryDelegate_StartsSuccessfully()
    {
        var appBuilder = AgentHost.CreateBuilder();
        appBuilder.WebApplicationBuilder.WebHost.UseTestServer();
        appBuilder.AddInvocations(sp => new TestHandler());

        var app = appBuilder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        // Verify POST /invocations works with factory-created handler
        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await invocationResponse.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("handled"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task AgentHostBuilder_WithFactoryDelegate_ResolvesDependencies()
    {
        var appBuilder = AgentHost.CreateBuilder();
        appBuilder.WebApplicationBuilder.WebHost.UseTestServer();
        appBuilder.Services.AddSingleton<string>("injected-value");
        appBuilder.AddInvocations(sp =>
        {
            var value = sp.GetRequiredService<string>();
            return new DependencyHandler(value);
        });

        var app = appBuilder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await invocationResponse.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("injected-value"));

        await app.App.StopAsync();
    }

    private sealed class TestHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("handled", cancellationToken);
        }
    }

    private sealed class DependencyHandler : InvocationHandler
    {
        private readonly string _value;

        public DependencyHandler(string value) => _value = value;

        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync(_value, cancellationToken);
        }
    }
}
