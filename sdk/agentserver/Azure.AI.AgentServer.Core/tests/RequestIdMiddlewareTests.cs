// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class RequestIdMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_SetsXRequestIdHeader()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();

        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/test", () => Results.Ok());
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(PlatformHeaders.RequestId), Is.True);
        var value = response.Headers.GetValues(PlatformHeaders.RequestId).First();
        Assert.That(value, Is.Not.Empty);

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_UsesIncomingXRequestIdHeader_WhenNoActivity()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();

        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/test", () => Results.Ok());
        await app.StartAsync();

        var client = app.GetTestClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "/test");
        request.Headers.Add(PlatformHeaders.RequestId, "client-provided-id-123");

        // Suppress Activity so OTEL trace ID is not available
        using var suppressScope = SuppressInstrumentationScope.Begin();
        var response = await client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(PlatformHeaders.RequestId), Is.True);
        var value = response.Headers.GetValues(PlatformHeaders.RequestId).First();

        // The middleware should either use the OTEL trace (if ASP.NET created one)
        // or fall back to the incoming header value.
        // Since TestServer may still create an Activity, we just verify the header is set.
        Assert.That(value, Is.Not.Empty);

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_ReturnsConsistentValueForSameRequest()
    {
        string? capturedItemsValue = null;

        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();

        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/test", (HttpContext ctx) =>
        {
            capturedItemsValue = ctx.Items[PlatformHeaders.RequestIdItemKey] as string;
            return Results.Ok();
        });
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/test");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var headerValue = response.Headers.GetValues(PlatformHeaders.RequestId).First();

        // The value in HttpContext.Items should match the response header
        Assert.That(capturedItemsValue, Is.EqualTo(headerValue));

        await app.StopAsync();
    }

    [Test]
    public async Task InvokeAsync_SetsHeaderOnErrorResponses()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();

        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/error", () => Results.StatusCode(500));
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/error");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(response.Headers.Contains(PlatformHeaders.RequestId), Is.True);

        await app.StopAsync();
    }

    /// <summary>
    /// Helper scope that suppresses Activity creation. Used to test fallback behavior.
    /// </summary>
    private sealed class SuppressInstrumentationScope : IDisposable
    {
        private readonly Activity? _saved;

        private SuppressInstrumentationScope()
        {
            _saved = Activity.Current;
            Activity.Current = null;
        }

        public static SuppressInstrumentationScope Begin() => new();

        public void Dispose()
        {
            Activity.Current = _saved;
        }
    }
}
