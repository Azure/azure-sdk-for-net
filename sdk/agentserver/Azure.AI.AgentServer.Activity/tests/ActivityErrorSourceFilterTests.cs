// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Tests that <see cref="ActivityErrorSourceFilter"/> sets the
/// <c>x-platform-error-source</c> and <c>x-platform-error-detail</c> response
/// headers with the correct classification.
/// </summary>
[TestFixture]
public class ActivityErrorSourceFilterTests
{
    [Test]
    public async Task HandlerThrows_ErrorSource_IsUpstream()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/throw/upstream", EmptyBody());

        Assert.That((int)response.StatusCode, Is.GreaterThanOrEqualTo(500));
        AssertErrorSource(response, PlatformHeaders.ErrorSourceUpstream);
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.False,
            "Upstream errors should not include error detail (developer code)");
    }

    [Test]
    public async Task BadHttpRequestException_ErrorSource_IsUser()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/throw/bad", EmptyBody());

        AssertErrorSource(response, PlatformHeaders.ErrorSourceUser);
    }

    [Test]
    public async Task ArgumentException_ErrorSource_IsUser()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/throw/arg", EmptyBody());

        AssertErrorSource(response, PlatformHeaders.ErrorSourceUser);
    }

    [Test]
    public async Task PlatformTaggedException_ErrorSource_IsPlatform_WithDetail()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/throw/platform", EmptyBody());

        AssertErrorSource(response, PlatformHeaders.ErrorSourcePlatform);
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.True,
            "Platform errors should include error detail");
    }

    [Test]
    public async Task PlatformError_Detail_IsTruncatedAt2048()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/throw/platform-long", EmptyBody());

        AssertErrorSource(response, PlatformHeaders.ErrorSourcePlatform);
        var detail = response.Headers.GetValues(PlatformHeaders.ErrorDetail).First();
        Assert.That(detail.Length, Is.EqualTo(2048));
        Assert.That(detail, Does.EndWith("...[truncated]"));
    }

    [Test]
    public async Task SuccessfulRequest_NoErrorSourceHeader()
    {
        await using var app = await CreateAppAsync();
        var client = app.GetTestClient();

        var response = await client.PostAsync("/ok", EmptyBody());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.False,
            "Successful responses should not include error source header");
    }

    // ── Helpers ─────────────────────────────────────────────

    private static StringContent EmptyBody() => new("{}");

    private static async Task<WebApplication> CreateAppAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        var app = builder.Build();

        // Convert re-thrown exceptions into a 500 so the TestServer client sees a response.
        app.UseExceptionHandler(error => error.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal Server Error");
        }));

        app.MapPost("/throw/{kind}", (string kind) =>
        {
            switch (kind)
            {
                case "bad":
                    throw new BadHttpRequestException("bad request");
                case "arg":
                    throw new ArgumentException("bad argument");
                case "platform":
                    throw MakePlatformException("platform failure");
                case "platform-long":
                    throw MakePlatformException(new string('x', 5000));
                default:
                    throw new InvalidOperationException("developer handler failure");
            }
        }).AddEndpointFilter<ActivityErrorSourceFilter>();

        app.MapPost("/ok", () => Results.Ok())
            .AddEndpointFilter<ActivityErrorSourceFilter>();

        await app.StartAsync();
        return app;
    }

    private static Exception MakePlatformException(string message)
    {
        var ex = new InvalidOperationException(message);
        PlatformErrorMarker.Tag(ex);
        return ex;
    }

    private static void AssertErrorSource(HttpResponseMessage response, string expected)
    {
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.True,
            $"Expected {PlatformHeaders.ErrorSource} header to be present");
        var value = response.Headers.GetValues(PlatformHeaders.ErrorSource).First();
        Assert.That(value, Is.EqualTo(expected));
    }
}
