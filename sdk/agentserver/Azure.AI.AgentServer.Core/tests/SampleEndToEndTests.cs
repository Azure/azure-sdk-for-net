// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

/// <summary>
/// End-to-end tests that validate Core sample patterns (Samples 1–2) work
/// correctly when wired into a real ASP.NET Core test server. Each test
/// uses the same <see cref="AgentHost.CreateBuilder()"/> +
/// <see cref="AgentHostBuilder.RegisterProtocol"/> pattern shown in sample docs.
/// </summary>
[TestFixture]
public class SampleEndToEndTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  Sample 1: Getting Started — RegisterProtocol with MapGet
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample1_RegisterProtocol_HelloEndpoint_Returns200()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.RegisterProtocol("MyProtocol", endpoints =>
        {
            endpoints.MapGet("/hello", () => "Hello from the agent server!");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/hello");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("Hello from the agent server!"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Sample1_RegisterProtocol_ReadinessEndpointExists()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.RegisterProtocol("MyProtocol", endpoints =>
        {
            endpoints.MapGet("/hello", () => "Hello!");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/readiness");

        // AgentHost auto-registers /readiness health endpoint
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 2: Configuration — Tracing, health checks, escape hatch
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample2_TracingAndShutdown_PingEndpoint_ReturnsPong()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.ConfigureTracing(tracing =>
        {
            tracing.AddSource("MyAgent.BusinessLogic");
        });

        builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

        builder.RegisterProtocol("MyProtocol", endpoints =>
        {
            endpoints.MapGet("/ping", () => "pong");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/ping");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("pong"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Sample2_HealthChecks_ReadinessEndpoint_ReturnsHealthy()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.ConfigureHealth(health =>
        {
            health.AddCheck("database", () =>
                Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("DB reachable"));
        });

        builder.RegisterProtocol("MyProtocol", endpoints =>
        {
            endpoints.MapGet("/ping", () => "pong");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/readiness");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Sample2_EscapeHatch_CustomServicesAvailable()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.Services.AddSingleton(new GreetingConfig { Name = "TestAgent" });

        builder.RegisterProtocol("MyProtocol", endpoints =>
        {
            endpoints.MapGet("/greet", (GreetingConfig config) =>
                $"Hello from {config.Name}");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/greet");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("Hello from TestAgent"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Sample2_MultipleProtocols_BothEndpointsWork()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.RegisterProtocol("ProtocolA", endpoints =>
        {
            endpoints.MapGet("/a", () => "from A");
        });

        builder.RegisterProtocol("ProtocolB", endpoints =>
        {
            endpoints.MapGet("/b", () => "from B");
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        var responseA = await client.GetAsync("/a");
        Assert.That(responseA.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await responseA.Content.ReadAsStringAsync(), Is.EqualTo("from A"));

        var responseB = await client.GetAsync("/b");
        Assert.That(responseB.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await responseB.Content.ReadAsStringAsync(), Is.EqualTo("from B"));

        await app.App.StopAsync();
    }

    // Helper types
    private class GreetingConfig
    {
        public string Name { get; set; } = "";
    }
}
