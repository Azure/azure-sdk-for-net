// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Headers;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// End-to-end tests verifying that an invocation handler emitting
/// <c>text/event-stream</c> automatically receives periodic SSE keep-alive
/// comments — symmetric to the behavior the Responses package provides via
/// <see cref="Azure.AI.AgentServer.Core.SseKeepAliveSession"/>.
/// </summary>
[TestFixture]
public class SseKeepAliveTests
{
    private string? _previousSseEnv;

    [SetUp]
    public void SetUp()
    {
        _previousSseEnv = Environment.GetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL");
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", _previousSseEnv);
        FoundryEnvironment.Reload();
    }

    [Test]
    public async Task Default_NoKeepAliveCommentsInSseStream()
    {
        // Arrange: keep-alive disabled by default.
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", null);
        FoundryEnvironment.Reload();

        var app = BuildApp(new SseInvocationHandler(TimeSpan.FromMilliseconds(200)));
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/invocations", new StringContent("{}"));
            var body = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Does.Not.Contain(": keep-alive"));
            Assert.That(body, Does.Contain("data: token"));
            Assert.That(body, Does.Contain("data: done"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task ConfiguredKeepAlive_KeepAliveCommentsPresent_ForSseHandler()
    {
        // Arrange: 1-second keep-alive, handler takes ~3 seconds.
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "1");
        FoundryEnvironment.Reload();

        var app = BuildApp(new SseInvocationHandler(TimeSpan.FromSeconds(3)));
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/invocations", new StringContent("{}"));
            var body = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));
            Assert.That(body, Does.Contain(": keep-alive"));
            Assert.That(body, Does.Contain("data: done"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task ConfiguredKeepAlive_NonSseHandler_DoesNotEmitComments()
    {
        // Arrange: keep-alive enabled, but handler returns plain JSON.
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "1");
        FoundryEnvironment.Reload();

        var app = BuildApp(new JsonInvocationHandler(TimeSpan.FromSeconds(3)));
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/invocations", new StringContent("{}"));
            var body = await response.Content.ReadAsStringAsync();

            // Non-SSE responses must NOT have keep-alive comments injected,
            // which would corrupt the JSON payload.
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Does.Not.Contain(": keep-alive"));
            Assert.That(body, Does.Contain("\"status\":\"done\""));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    private static WebApplication BuildApp(InvocationHandler handler)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);

        var app = builder.Build();
        app.MapInvocationsServer();
        return app;
    }

    /// <summary>
    /// Handler that streams SSE: writes a token, waits, then writes a done frame.
    /// The delay window gives the keep-alive timer time to fire (if enabled).
    /// </summary>
    private sealed class SseInvocationHandler : InvocationHandler
    {
        private readonly TimeSpan _delay;

        public SseInvocationHandler(TimeSpan delay) => _delay = delay;

        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            response.ContentType = "text/event-stream; charset=utf-8";
            response.Headers["Cache-Control"] = "no-cache";

            await response.WriteAsync("data: token\n\n", cancellationToken);
            await response.Body.FlushAsync(cancellationToken);
            await Task.Delay(_delay, cancellationToken);
            await response.WriteAsync("data: done\n\n", cancellationToken);
        }
    }

    /// <summary>
    /// Handler that returns a plain JSON document after a delay. The framework
    /// must NOT inject SSE keep-alive bytes into a non-SSE response.
    /// </summary>
    private sealed class JsonInvocationHandler : InvocationHandler
    {
        private readonly TimeSpan _delay;

        public JsonInvocationHandler(TimeSpan delay) => _delay = delay;

        public override async Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            await Task.Delay(_delay, cancellationToken);
            response.StatusCode = 200;
            response.ContentType = "application/json";
            await response.WriteAsync("{\"status\":\"done\"}", cancellationToken);
        }
    }
}
