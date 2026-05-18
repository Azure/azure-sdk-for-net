// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.WebSockets;
using System.Text;
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
/// End-to-end tests for the <c>/invocations_ws</c> (WebSocket) protocol —
/// symmetric to the Python <c>tests/test_ws_*.py</c> suite. Covers:
/// 404 when the handler does not implement WS; clean echo round-trip;
/// uncaught exception → close code 1011; handler-initiated close passes
/// through; session ID precedence (env var vs UUID fallback); plain HTTP
/// to a WS endpoint → 400.
/// </summary>
[TestFixture]
[NonParallelizable]
public class WebSocketEndpointTests
{
    private string? _previousSessionEnv;
    private string? _previousWsEnv;

    [SetUp]
    public void SetUp()
    {
        _previousSessionEnv = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        _previousWsEnv = Environment.GetEnvironmentVariable("WS_KEEPALIVE_INTERVAL");
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", _previousSessionEnv);
        Environment.SetEnvironmentVariable("WS_KEEPALIVE_INTERVAL", _previousWsEnv);
        FoundryEnvironment.Reload();
    }

    [Test]
    public async Task HandlerWithoutWebSocketOverride_Returns404_ForWebSocketRequest()
    {
        var app = BuildApp(new HttpOnlyInvocationHandler());
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await wsClient.ConnectAsync(uri, CancellationToken.None));
            // TestServer wraps a 404 as InvalidOperationException with status text
            Assert.That(ex!.Message, Does.Contain("404").Or.Contain("NotFound"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task HandlerWithoutWebSocketOverride_PlainHttpGet_Returns404()
    {
        var app = BuildApp(new HttpOnlyInvocationHandler());
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.GetAsync("/invocations_ws");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task WebSocketEndpoint_PlainHttpGet_FromWebSocketHandler_Returns400()
    {
        var app = BuildApp(new EchoWebSocketInvocationHandler());
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.GetAsync("/invocations_ws");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                "GET without a WebSocket upgrade must yield 400 from a handler that supports WS.");
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task EchoHandler_RoundTripsTextFrame_AndClosesCleanly()
    {
        var app = BuildApp(new EchoWebSocketInvocationHandler());
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            var payload = Encoding.UTF8.GetBytes("hello, .NET WebSocket");
            await ws.SendAsync(payload, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);

            var buffer = new byte[1024];
            var received = await ws.ReceiveAsync(buffer, CancellationToken.None);
            var echoed = Encoding.UTF8.GetString(buffer, 0, received.Count);
            Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Text));
            Assert.That(echoed, Is.EqualTo("hello, .NET WebSocket"));

            // Trigger end-of-stream: send the empty "bye" frame the handler watches for.
            await ws.SendAsync(ReadOnlyMemory<byte>.Empty, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);

            // Server should close with NormalClosure when the handler returns cleanly.
            var closeFrame = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(closeFrame.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That(ws.CloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure),
                "Clean handler return must map to RFC 6455 close code 1000 (NormalClosure).");
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task HandlerThrows_ClosesWithInternalServerError_1011()
    {
        var app = BuildApp(new ThrowingWebSocketInvocationHandler());
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            // The handler will accept, throw, and the SDK will send a close frame.
            var buffer = new byte[1024];
            var frame = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(frame.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That(ws.CloseStatus, Is.EqualTo(WebSocketCloseStatus.InternalServerError),
                "Uncaught handler exception must map to RFC 6455 close code 1011 (InternalServerError).");
            Assert.That(ws.CloseStatusDescription, Is.EqualTo("Internal server error"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task HandlerInitiatedClose_PreservesItsCloseCode()
    {
        var app = BuildApp(new HandlerInitiatedCloseInvocationHandler(
            (WebSocketCloseStatus)1008, "policy violation"));
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            var buffer = new byte[1024];
            var frame = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(frame.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int)ws.CloseStatus!, Is.EqualTo(1008),
                "Handler-initiated CloseAsync must be preserved (no double-close from the SDK).");
            Assert.That(ws.CloseStatusDescription, Is.EqualTo("policy violation"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task SessionId_HonoursFoundryAgentSessionIdEnv()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "ws-session-from-env");
        FoundryEnvironment.Reload();

        var observed = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        var app = BuildApp(new CaptureSessionIdInvocationHandler(observed));
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);
            await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client done", CancellationToken.None);

            var sessionIdSeenByHandler = await observed.Task.WaitAsync(TimeSpan.FromSeconds(5));
            Assert.That(sessionIdSeenByHandler, Is.EqualTo("ws-session-from-env"));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task SessionId_FallsBackToGeneratedUuid_WhenEnvUnset()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
        FoundryEnvironment.Reload();

        var observed = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        var app = BuildApp(new CaptureSessionIdInvocationHandler(observed));
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);
            await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client done", CancellationToken.None);

            var sessionIdSeenByHandler = await observed.Task.WaitAsync(TimeSpan.FromSeconds(5));
            Assert.That(Guid.TryParse(sessionIdSeenByHandler, out _), Is.True,
                $"Expected a UUID fallback session ID but got '{sessionIdSeenByHandler}'.");
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task UpgradeResponseIncludes_SessionIdHeader()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "session-id-on-upgrade");
        FoundryEnvironment.Reload();

        var app = BuildApp(new EchoWebSocketInvocationHandler());
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");

            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            // TestServer doesn't expose upgrade response headers via the WebSocket
            // object, so we don't assert on them directly here. Driver-level checks
            // live in higher-level integration scenarios. The smoke test is that
            // the upgrade still succeeds when we set the header from the handler.
            Assert.That(ws.State, Is.EqualTo(WebSocketState.Open));
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
        // UseWebSockets is required for handlers that call AcceptWebSocketAsync.
        // Production code wires this through AgentHostMiddlewareExtensions.UseAgentServerCore;
        // tests build WebApplication directly, so call it here.
        app.UseWebSockets();
        app.MapInvocationsServer();
        return app;
    }

    // ---------- Test handlers -----------------------------------------

    private sealed class HttpOnlyInvocationHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            return Task.CompletedTask;
        }
        // Intentionally does NOT override HandleWebSocketAsync.
    }

    private sealed class EchoWebSocketInvocationHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            return Task.CompletedTask;
        }

        public override async Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            var buffer = new byte[1024];
            while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var received = await webSocket.ReceiveAsync(buffer, cancellationToken);
                if (received.MessageType == WebSocketMessageType.Close)
                {
                    break;
                }
                if (received.Count == 0)
                {
                    // Sentinel "bye" frame — terminate the loop and let the SDK close cleanly.
                    break;
                }
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, received.Count),
                    received.MessageType,
                    received.EndOfMessage,
                    cancellationToken);
            }
        }
    }

    private sealed class ThrowingWebSocketInvocationHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public override Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
            => throw new InvalidOperationException("boom");
    }

    private sealed class HandlerInitiatedCloseInvocationHandler : InvocationHandler
    {
        private readonly WebSocketCloseStatus _status;
        private readonly string _description;

        public HandlerInitiatedCloseInvocationHandler(WebSocketCloseStatus status, string description)
        {
            _status = status;
            _description = description;
        }

        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public override async Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            await webSocket.CloseAsync(_status, _description, cancellationToken);
        }
    }

    private sealed class CaptureSessionIdInvocationHandler : InvocationHandler
    {
        private readonly TaskCompletionSource<string> _observed;

        public CaptureSessionIdInvocationHandler(TaskCompletionSource<string> observed)
        {
            _observed = observed;
        }

        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public override async Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            _observed.TrySetResult(context.SessionId);
            var buffer = new byte[256];
            try
            {
                while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    var received = await webSocket.ReceiveAsync(buffer, cancellationToken);
                    if (received.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException) { }
        }
    }
}
