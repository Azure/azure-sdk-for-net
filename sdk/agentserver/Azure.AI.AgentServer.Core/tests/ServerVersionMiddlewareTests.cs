// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class ServerVersionMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_SetsXPlatformServerHeader()
    {
        // Use TestServer to actually run the middleware pipeline
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerVersion();

        var app = builder.Build();
        app.UseAgentServerVersion();
        app.MapGet("/test", () => Results.Ok());
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains("x-platform-server"), Is.True);
        var value = response.Headers.GetValues("x-platform-server").First();
        Assert.That(value, Does.Contain("azure-ai-agentserver/"));
        Assert.That(value, Does.Contain("dotnet/"));

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_IncludesRegisteredProtocolIdentity()
    {
        // Create a shared registry instance and register a protocol identity
        var registry = new ServerVersionRegistry();
        registry.Register("my-protocol/1.0.0 (dotnet/10.0)");

        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddSingleton(registry);
        builder.Services.AddSingleton<ServerVersionMiddleware>();
        builder.Services.Configure<AgentHostOptions>(_ => { });

        var app = builder.Build();
        app.UseAgentServerVersion();
        app.MapGet("/test", () => Results.Ok());
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var value = response.Headers.GetValues("x-platform-server").First();
        Assert.That(value, Does.Contain("azure-ai-agentserver/"));
        Assert.That(value, Does.Contain("my-protocol/1.0.0"));

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_AdditionalServerIdentity_AppendsToEnd()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerVersion();
        builder.Services.Configure<AgentHostOptions>(o => o.AdditionalServerIdentity = "custom/2.0");

        var app = builder.Build();
        app.UseAgentServerVersion();
        app.MapGet("/test", () => Results.Ok());
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var value = response.Headers.GetValues("x-platform-server").First();
        Assert.That(value, Does.Contain("azure-ai-agentserver/"));
        Assert.That(value, Does.EndWith("; custom/2.0"));

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_CallsNextMiddleware()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerVersion();

        var app = builder.Build();
        app.UseAgentServerVersion();
        app.MapGet("/test", () => Results.Ok("next was called"));
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.StopAsync();
    }
}
