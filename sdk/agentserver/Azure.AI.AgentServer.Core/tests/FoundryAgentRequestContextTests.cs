// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class FoundryAgentRequestContextTests
{
    [Test]
    public void Current_DefaultsToEmpty_WithNullFields()
    {
        var ctx = FoundryAgentRequestContext.Current;
        Assert.That(ctx, Is.Not.Null);
        Assert.That(ctx.CallId, Is.Null);
        Assert.That(ctx.UserId, Is.Null);
    }

    [Test]
    public void PlatformHeaders_IncludesOnlyCallId_NeverUserId()
    {
        var ctx = new FoundryAgentRequestContext { CallId = "call-1", UserId = "user-1" };
        var headers = ctx.PlatformHeaders().ToList();

        Assert.That(headers, Has.Count.EqualTo(1));
        Assert.That(headers[0].Key, Is.EqualTo(PlatformHeaders.FoundryCallId));
        Assert.That(headers[0].Value, Is.EqualTo("call-1"));
        Assert.That(headers.Any(h => h.Key == PlatformHeaders.UserId), Is.False);
    }

    [Test]
    public void PlatformHeaders_EmptyWhenNoCallId()
    {
        Assert.That(new FoundryAgentRequestContext().PlatformHeaders().Any(), Is.False);
        Assert.That(new FoundryAgentRequestContext { UserId = "u" }.PlatformHeaders().Any(), Is.False);
    }

    [Test]
    public async Task Middleware_CapturesInboundHeadersIntoContext()
    {
        string? seenCallId = null;
        string? seenUserId = null;

        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/test", () =>
        {
            seenCallId = FoundryAgentRequestContext.Current.CallId;
            seenUserId = FoundryAgentRequestContext.Current.UserId;
            return Results.Ok();
        });
        await app.StartAsync();

        var client = app.GetTestClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "/test");
        request.Headers.TryAddWithoutValidation(PlatformHeaders.FoundryCallId, "call-abc");
        request.Headers.TryAddWithoutValidation(PlatformHeaders.UserId, "user-xyz");
        await client.SendAsync(request);

        Assert.That(seenCallId, Is.EqualTo("call-abc"));
        Assert.That(seenUserId, Is.EqualTo("user-xyz"));

        await app.StopAsync();
    }

    [Test]
    public async Task FoundryCallIdHandler_StampsCallId_WhenPresent()
    {
        var capture = new CapturingHandler();
        var handler = new FoundryCallIdHandler(capture);
        using var client = new HttpClient(handler);

        FoundryAgentRequestContext.Set(new FoundryAgentRequestContext { CallId = "call-77", UserId = "user-77" });
        await client.GetAsync("https://example.test/x");

        Assert.That(capture.Request!.Headers.Contains(PlatformHeaders.FoundryCallId), Is.True);
        Assert.That(capture.Request.Headers.GetValues(PlatformHeaders.FoundryCallId).First(), Is.EqualTo("call-77"));
        // user-id is never echoed
        Assert.That(capture.Request.Headers.Contains(PlatformHeaders.UserId), Is.False);
    }

    [Test]
    public async Task FoundryCallIdHandler_NoOp_WhenNoCallId()
    {
        var capture = new CapturingHandler();
        var handler = new FoundryCallIdHandler(capture);
        using var client = new HttpClient(handler);

        FoundryAgentRequestContext.Set(new FoundryAgentRequestContext());
        await client.GetAsync("https://example.test/x");

        Assert.That(capture.Request!.Headers.Contains(PlatformHeaders.FoundryCallId), Is.False);
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
        }
    }
}
