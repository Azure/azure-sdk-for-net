// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// E2E tests verifying that <c>x-agent-user-id</c> and
/// <c>x-agent-foundry-call-id</c> headers flow through to the
/// <see cref="InvocationContext.PlatformContext"/> property on all endpoints.
/// </summary>
[TestFixture]
public class PlatformContextEndpointTests
{
    [Test]
    public async Task PostInvocations_IsolationHeaders_FlowToHandler()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations");
        request.Content = new StringContent("{}");
        request.Headers.Add(PlatformHeaders.UserId, "user-abc");
        request.Headers.Add(PlatformHeaders.FoundryCallId, "call-xyz");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("userKey").GetString(), Is.EqualTo("user-abc"));
        Assert.That(json.GetProperty("callId").GetString(), Is.EqualTo("call-xyz"));
    }

    [Test]
    public async Task PostInvocations_NoIsolationHeaders_ReturnsEmpty()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var response = await env.Client.PostAsync("/invocations", new StringContent("{}"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("userKey").ValueKind, Is.EqualTo(JsonValueKind.Null));
        Assert.That(json.GetProperty("callId").ValueKind, Is.EqualTo(JsonValueKind.Null));
    }

    [Test]
    public async Task GetInvocation_IsolationHeaders_FlowToHandler()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var request = new HttpRequestMessage(HttpMethod.Get, "/invocations/inv-123");
        request.Headers.Add(PlatformHeaders.UserId, "user-get");
        request.Headers.Add(PlatformHeaders.FoundryCallId, "call-get");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("userKey").GetString(), Is.EqualTo("user-get"));
        Assert.That(json.GetProperty("callId").GetString(), Is.EqualTo("call-get"));
    }

    [Test]
    public async Task CancelInvocation_IsolationHeaders_FlowToHandler()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations/inv-456/cancel");
        request.Headers.Add(PlatformHeaders.UserId, "user-cancel");
        request.Headers.Add(PlatformHeaders.FoundryCallId, "call-cancel");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("userKey").GetString(), Is.EqualTo("user-cancel"));
        Assert.That(json.GetProperty("callId").GetString(), Is.EqualTo("call-cancel"));
    }

    [Test]
    public async Task GetInvocation_ContextIncludesQueryParams()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var request = new HttpRequestMessage(HttpMethod.Get, "/invocations/inv-789?custom=value1");
        request.Headers.Add(PlatformHeaders.UserId, "u");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("queryParam_custom").GetString(), Is.EqualTo("value1"));
    }

    [Test]
    public async Task GetInvocation_ContextIncludesClientHeaders()
    {
        using var env = await StartAsync<IsolationCapturingHandler>();

        var request = new HttpRequestMessage(HttpMethod.Get, "/invocations/inv-101");
        request.Headers.Add("x-client-trace-id", "trace-abc");
        request.Headers.Add(PlatformHeaders.UserId, "u");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await ParseJsonAsync(response);
        Assert.That(json.GetProperty("clientHeader_x-client-trace-id").GetString(), Is.EqualTo("trace-abc"));
    }

    // ─── helpers ──────────────────────────────────────────────

    private static async Task<JsonElement> ParseJsonAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(body);
        return document.RootElement.Clone();
    }

    private static async Task<TestEnv> StartAsync<THandler>() where THandler : InvocationHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, THandler>();

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        return new TestEnv(app);
    }

    private sealed class TestEnv : IDisposable
    {
        private readonly WebApplication _app;
        public HttpClient Client { get; }

        public TestEnv(WebApplication app)
        {
            _app = app;
            Client = app.GetTestClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _app.StopAsync().GetAwaiter().GetResult();
            _app.DisposeAsync().AsTask().GetAwaiter().GetResult();
        }
    }

    /// <summary>
    /// Handler that captures isolation context and writes it as JSON for assertion.
    /// </summary>
    private sealed class IsolationCapturingHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            await WriteContextJsonAsync(response, context, cancellationToken);
        }

        public override async Task GetAsync(
            string invocationId, HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            await WriteContextJsonAsync(response, context, cancellationToken);
        }

        public override async Task CancelAsync(
            string invocationId, HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            await WriteContextJsonAsync(response, context, cancellationToken);
        }

        private static async Task WriteContextJsonAsync(
            HttpResponse response, InvocationContext context, CancellationToken ct)
        {
            response.StatusCode = 200;
            var result = new Dictionary<string, object?>
            {
                ["userKey"] = context.PlatformContext.UserIdKey,
                ["callId"] = context.PlatformContext.CallId,
            };

            // Include client headers
            foreach (var h in context.ClientHeaders)
            {
                result[$"clientHeader_{h.Key}"] = h.Value;
            }

            // Include query parameters
            foreach (var q in context.QueryParameters)
            {
                result[$"queryParam_{q.Key}"] = q.Value.ToString();
            }

            await response.WriteAsJsonAsync(result, ct);
        }
    }
}
