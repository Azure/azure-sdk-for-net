// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class AgentHostBuilderTests
{
    [Test]
    public void CreateBuilder_ReturnsNonNullBuilder()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.That(builder, Is.Not.Null);
    }

    [Test]
    public void Services_ReturnsServiceCollection()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.That(builder.Services, Is.Not.Null);
        Assert.That(builder.Services, Is.InstanceOf<IServiceCollection>());
    }

    [Test]
    public void Configuration_ReturnsConfigurationRoot()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.That(builder.Configuration, Is.Not.Null);
        Assert.That(builder.Configuration, Is.InstanceOf<IConfiguration>());
    }

    [Test]
    public void WebApplicationBuilder_ReturnsUnderlyingBuilder()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.That(builder.WebApplicationBuilder, Is.Not.Null);
        Assert.That(builder.WebApplicationBuilder, Is.InstanceOf<WebApplicationBuilder>());
    }

    [Test]
    public void VersionRegistry_ReturnsRegistry()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.That(builder.VersionRegistry, Is.Not.Null);
        Assert.That(builder.VersionRegistry, Is.InstanceOf<ServerVersionRegistry>());
    }

    [Test]
    public void Configure_SetsOptions()
    {
        var builder = AgentHost.CreateBuilder();
        builder.Configure(o => o.ShutdownTimeout = TimeSpan.FromSeconds(45));
        builder.Configure(o => o.AdditionalServerIdentity = "test/1.0");

        // Verify options are resolved correctly via DI
        using var provider = builder.Services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<AgentHostOptions>>().Value;
        Assert.That(options.ShutdownTimeout, Is.EqualTo(TimeSpan.FromSeconds(45)));
        Assert.That(options.AdditionalServerIdentity, Is.EqualTo("test/1.0"));
    }

    [Test]
    public void Configure_IsChainable()
    {
        var builder = AgentHost.CreateBuilder();
        var result = builder.Configure(o => o.ShutdownTimeout = TimeSpan.FromSeconds(10));
        Assert.That(result, Is.SameAs(builder));
    }

    [Test]
    public void ConfigureShutdown_SetsTimeoutViaOptions()
    {
        var builder = AgentHost.CreateBuilder();
        builder.ConfigureShutdown(TimeSpan.FromSeconds(120));

        using var provider = builder.Services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<AgentHostOptions>>().Value;
        Assert.That(options.ShutdownTimeout, Is.EqualTo(TimeSpan.FromSeconds(120)));
    }

    [Test]
    public void ConfigureShutdown_IsChainable()
    {
        var builder = AgentHost.CreateBuilder();
        var result = builder.ConfigureShutdown(TimeSpan.FromSeconds(10));
        Assert.That(result, Is.SameAs(builder));
    }

    [Test]
    public void ConfigureHealth_IsChainable()
    {
        var builder = AgentHost.CreateBuilder();
        var result = builder.ConfigureHealth(health => health.AddCheck("test", () => HealthCheckResult.Healthy()));
        Assert.That(result, Is.SameAs(builder));
    }

    [Test]
    public void ConfigureTracing_IsChainable()
    {
        var builder = AgentHost.CreateBuilder();
        var result = builder.ConfigureTracing(tracing => tracing.AddSource("CustomSource"));
        Assert.That(result, Is.SameAs(builder));
    }

    [Test]
    public void RegisterProtocol_ThrowsOnNullName()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.Throws<ArgumentNullException>(() => builder.RegisterProtocol(null!, _ => { }));
    }

    [Test]
    public void RegisterProtocol_ThrowsOnEmptyName()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.Throws<ArgumentException>(() => builder.RegisterProtocol("", _ => { }));
    }

    [Test]
    public void RegisterProtocol_ThrowsOnNullMapper()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.Throws<ArgumentNullException>(() => builder.RegisterProtocol("Test", null!));
    }

    [Test]
    public void RegisterProtocol_ThrowsOnDuplicateName()
    {
        var builder = AgentHost.CreateBuilder();
        builder.RegisterProtocol("Test", _ => { });
        Assert.Throws<InvalidOperationException>(() => builder.RegisterProtocol("Test", _ => { }));
    }

    [Test]
    public void RegisterProtocol_IsCaseInsensitive()
    {
        var builder = AgentHost.CreateBuilder();
        builder.RegisterProtocol("responses", _ => { });
        Assert.Throws<InvalidOperationException>(() => builder.RegisterProtocol("Responses", _ => { }));
    }

    [Test]
    public void Build_ReturnsAgentHostApp()
    {
        var builder = AgentHost.CreateBuilder();
        // Use TestServer to avoid binding to a real port
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var app = builder.Build();
        Assert.That(app, Is.Not.Null);
        Assert.That(app.App, Is.Not.Null);
    }

    [Test]
    public async Task Build_RegistersProtocolEndpoints()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.RegisterProtocol("TestProtocol", endpoints =>
        {
            endpoints.MapGet("/test-protocol", () => Results.Ok("protocol-ok"));
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/test-protocol");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content, Does.Contain("protocol-ok"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Build_MapsHealthEndpoint()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/readiness");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Build_AppliesShutdownTimeoutToHostOptions()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.ConfigureShutdown(TimeSpan.FromSeconds(77));

        var app = builder.Build();
        await app.App.StartAsync();

        var hostOptions = app.App.Services.GetRequiredService<IOptions<HostOptions>>().Value;
        Assert.That(hostOptions.ShutdownTimeout, Is.EqualTo(TimeSpan.FromSeconds(77)));

        await app.App.StopAsync();
    }

    [Test]
    public async Task Build_AppliesUserAgentMiddleware()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.RegisterProtocol("Dummy", endpoints =>
        {
            endpoints.MapGet("/ping", () => Results.Ok());
        });

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.GetAsync("/ping");
        Assert.That(response.Headers.Contains("x-platform-server"), Is.True);

        await app.App.StopAsync();
    }

    [Test]
    public async Task RunAsync_CompletesOnCancellation()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var app = builder.Build();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        // RunAsync should honor the cancellation token and stop
        await app.RunAsync(cts.Token);

        // Reaching here means RunAsync completed without hanging
        Assert.Pass();
    }

    [Test]
    public void Build_ThrowsOnInvalidOptions()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.Configure(o => o.ShutdownTimeout = TimeSpan.FromSeconds(-5));

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }
}
