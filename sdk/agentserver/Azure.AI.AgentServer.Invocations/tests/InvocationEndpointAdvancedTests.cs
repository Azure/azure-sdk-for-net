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
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
[NonParallelizable]
public class InvocationEndpointAdvancedTests
{
    // ─── Error path: handler throws → 500, exception recorded ───

    [Test]
    public async Task PostInvocations_Returns500_WhenHandlerThrows()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, ThrowingHandler>();

        var app = builder.Build();

        // Add exception-handling middleware so TestServer returns 500 instead of propagating
        app.Use(async (ctx, next) =>
        {
            try
            {
                await next();
            }
            catch
            {
                ctx.Response.StatusCode = 500;
            }
        });

        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

        await app.StopAsync();
    }

    // ─── AddInvocations(handler instance) overload ───

    [Test]
    public async Task AddInvocations_WithHandlerInstance_Registers_And_Works()
    {
        var appBuilder = AgentHost.CreateBuilder();
        appBuilder.WebApplicationBuilder.WebHost.UseTestServer();
        appBuilder.AddInvocations(new SimpleHandler("instance-ok"));

        var app = appBuilder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();
        var response = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("instance-ok"));

        await app.App.StopAsync();
        await app.App.DisposeAsync();
    }

    // ─── AddInvocations null argument validation ───

    [Test]
    public void AddInvocations_WithNullHandler_ThrowsArgumentNullException()
    {
        var appBuilder = AgentHost.CreateBuilder();

        Assert.That(
            () => appBuilder.AddInvocations((InvocationHandler)null!),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void AddInvocations_WithNullFactory_ThrowsArgumentNullException()
    {
        var appBuilder = AgentHost.CreateBuilder();

        Assert.That(
            () => appBuilder.AddInvocations((Func<IServiceProvider, InvocationHandler>)null!),
            Throws.InstanceOf<ArgumentNullException>());
    }

    // ─── MapInvocationsServer with prefix ───

    [Test]
    public async Task MapInvocationsServer_WithPrefix_RoutesUnderPrefix()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, SimpleHandler>();

        var app = builder.Build();
        app.MapInvocationsServer("/v1");
        await app.StartAsync();

        var client = app.GetTestClient();

        // Prefix route should work
        var prefixResponse = await client.PostAsync("/v1/invocations", new StringContent("{}"));
        Assert.That(prefixResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Root route should NOT work (404)
        var rootResponse = await client.PostAsync("/invocations", new StringContent("{}"));
        Assert.That(rootResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        await app.StopAsync();
    }

    [Test]
    public async Task MapInvocationsServer_WithPrefixTrailingSlash_TrimsCorrectly()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, SimpleHandler>();

        var app = builder.Build();
        app.MapInvocationsServer("/api/");
        await app.StartAsync();

        var client = app.GetTestClient();

        // Routes with prefix (trailing slash trimmed)
        var response = await client.PostAsync("/api/invocations", new StringContent("{}"));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.StopAsync();
    }

    // ─── AddInvocationsServer configure callback ───

    [Test]
    public void AddInvocationsServer_WithConfigureCallback_InvokesCallback()
    {
        var services = new ServiceCollection();
        bool callbackInvoked = false;

        services.AddInvocationsServer(options =>
        {
            callbackInvoked = true;
        });

        using var provider = services.BuildServiceProvider();
        // Resolve to trigger Options configuration
        var options = provider.GetRequiredService<IOptions<InvocationsServerOptions>>();
        _ = options.Value;

        Assert.That(callbackInvoked, Is.True);
    }

    // ─── Handler override behavior ───

    [Test]
    public async Task GetInvocation_Returns200_WhenHandlerOverridesGet()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, FullOverrideHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/invocations/test-id-123");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("get:test-id-123"));

        await app.StopAsync();
    }

    [Test]
    public async Task CancelInvocation_Returns200_WhenHandlerOverridesCancel()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, FullOverrideHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/invocations/test-id-456/cancel", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("cancel:test-id-456"));

        await app.StopAsync();
    }

    [Test]
    public async Task GetOpenApi_Returns200_WhenHandlerOverridesOpenApi()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, FullOverrideHandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/invocations/docs/openapi.json");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("{\"openapi\":\"3.0\"}"));

        await app.StopAsync();
    }

    // ─── Test handler implementations ───

    private sealed class ThrowingHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException("Handler error for testing");
        }
    }

    private sealed class SimpleHandler : InvocationHandler
    {
        private readonly string _body;

        public SimpleHandler() : this("ok") { }
        public SimpleHandler(string body) => _body = body;

        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync(_body, cancellationToken);
        }
    }

    private sealed class FullOverrideHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("invoke-ok", cancellationToken);
        }

        public override async Task GetAsync(
            string invocationId, HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync($"get:{invocationId}", cancellationToken);
        }

        public override async Task CancelAsync(
            string invocationId, HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync($"cancel:{invocationId}", cancellationToken);
        }

        public override async Task GetOpenApiAsync(
            HttpRequest request, HttpResponse response,
            CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            response.ContentType = "application/json";
            await response.WriteAsync("{\"openapi\":\"3.0\"}", cancellationToken);
        }
    }
}
