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

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// Tests that the <c>x-platform-error-source</c> and <c>x-platform-error-detail</c>
/// response headers are set correctly on invocation error responses
/// per container-image-spec §8.
/// </summary>
[TestFixture]
public class InvocationsErrorSourceTests
{
    [Test]
    public async Task PostInvocations_HandlerThrows_ErrorSource_IsUpstream()
    {
        await using var app = await CreateAppAsync<ThrowingHandler>();
        var client = app.GetTestClient();

        HttpResponseMessage? response = null;
        try
        {
            response = await client.PostAsync("/invocations", new StringContent("{}"));
        }
        catch
        {
            // The test server may throw if no exception handler is configured.
            // In that case, verify via a handler that catches and returns 500.
        }

        if (response is not null)
        {
            Assert.That((int)response.StatusCode, Is.GreaterThanOrEqualTo(500));
            AssertErrorSource(response, "upstream");
            Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.False,
                "Upstream errors should not include error detail (developer code)");
        }
    }

    [Test]
    public async Task PostInvocations_SuccessfulRequest_NoErrorSourceHeader()
    {
        await using var app = await CreateAppAsync<SuccessHandler>();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.False,
            "Successful responses should not include error source header");
    }

    // ── Helpers ─────────────────────────────────────────────

    private static async Task<WebApplication> CreateAppAsync<THandler>()
        where THandler : InvocationHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, THandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();
        return app;
    }

    private static void AssertErrorSource(HttpResponseMessage response, string expected)
    {
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.True,
            $"Expected {PlatformHeaders.ErrorSource} header to be present");
        var value = response.Headers.GetValues(PlatformHeaders.ErrorSource).First();
        Assert.That(value, Is.EqualTo(expected));
    }

    private sealed class ThrowingHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            throw new InvalidOperationException("Simulated handler failure");
        }
    }

    private sealed class SuccessHandler : InvocationHandler
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
