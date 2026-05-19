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
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// End-to-end tests for the <c>/invocations_ws</c> (WebSocket) protocol.
/// Covers: 404 when the handler does not implement WS; clean echo round-trip;
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
    public async Task WebSocketOnlyHandler_HttpPostInvocations_Returns404_ByDefault()
    {
        // The new InvocationsWebSocketHandler base class lets developers
        // implement HandleWebSocketAsync without also implementing HandleAsync.
        // The default HandleAsync must return 404 so HTTP POST /invocations
        // against a WS-only handler is rejected cleanly.
        var app = BuildApp(new WebSocketOnlyEchoHandler());
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/invocations", new StringContent("{}"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                "WS-only InvocationsWebSocketHandler must default HandleAsync to 404 — multi-protocol opt-in only when the user overrides HandleAsync explicitly.");
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task WebSocketOnlyHandler_WebSocketUpgrade_EchoesFrames()
    {
        // The WS path on a WS-only handler must still work end to end —
        // the InvocationsWebSocketHandler default HandleAsync 404 must not
        // disrupt the WebSocket upgrade on /invocations_ws.
        var app = BuildApp(new WebSocketOnlyEchoHandler());
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");
            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            var payload = Encoding.UTF8.GetBytes("ws-only path");
            await ws.SendAsync(payload, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);

            var buffer = new byte[256];
            var received = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Text));
            Assert.That(Encoding.UTF8.GetString(buffer, 0, received.Count), Is.EqualTo("ws-only path"));

            await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
            await ws.ReceiveAsync(buffer, CancellationToken.None); // drain close frame
            Assert.That(ws.CloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure));
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
    public async Task HandlerThrowsOceFromUnrelatedToken_ClosesWith1011()
    {
        // Guard against the OCE-attribution edge case: a handler throwing
        // OperationCanceledException from its own CancellationTokenSource
        // (e.g., an internal timeout) must NOT be swallowed as a clean close
        // even when the request happens to be aborted concurrently. Only
        // cancellation whose token matches httpContext.RequestAborted is
        // attributable to the SDK / server shutdown.
        var app = BuildApp(new HandlerOceFromUnrelatedTokenInvocationHandler());
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
            Assert.That(ws.CloseStatus, Is.EqualTo(WebSocketCloseStatus.InternalServerError),
                "Handler-internal OCE (different token than RequestAborted) must surface as 1011, not 1000.");
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
    public async Task CloseEventLog_UsesDottedStructuredFieldNames()
    {
        // The close-event log line is documented (in README, CHANGELOG, and the
        // XML doc on `HandleWebSocketAsync`) as carrying dotted-name structured
        // fields like `azure.ai.agentserver.invocations_ws.session_id` — those
        // names are part of the cross-SDK wire contract. Verify the field names
        // downstream consumers see actually match.
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "log-shape-session");
        FoundryEnvironment.Reload();

        var captured = new CapturingLoggerProvider("invocations_ws connection closed");
        var app = BuildApp(new EchoWebSocketInvocationHandler(), captured);
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");
            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);
            await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client done", CancellationToken.None);

            var closeEvent = await captured.WaitForMatchAsync(TimeSpan.FromSeconds(5));

            var keys = closeEvent.StateKeys;
            Assert.That(keys, Does.Contain("azure.ai.agentserver.invocations_ws.session_id"),
                $"Structured-log field names must use the documented dotted keys. Got: [{string.Join(", ", keys)}]");
            Assert.That(keys, Does.Contain("azure.ai.agentserver.invocations_ws.close_code"));
            Assert.That(keys, Does.Contain("azure.ai.agentserver.invocations_ws.duration_ms"));
            Assert.That(closeEvent.GetValue("azure.ai.agentserver.invocations_ws.session_id"),
                Is.EqualTo("log-shape-session"));
            Assert.That(closeEvent.GetValue("azure.ai.agentserver.invocations_ws.close_code"),
                Is.EqualTo(1000));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task CloseEventLog_IncludesErrorCodeField_WhenHandlerThrows()
    {
        var captured = new CapturingLoggerProvider("invocations_ws connection closed");
        var app = BuildApp(new ThrowingWebSocketInvocationHandler(), captured);
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");
            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            // Drain the server's close frame, then reciprocate so the server's
            // `CloseAsync` (which sends a close frame and waits for one back)
            // unblocks — otherwise the server-side `finally` that emits the
            // close-event log line never runs within the test's timeout window.
            var buf = new byte[64];
            await ws.ReceiveAsync(buf, CancellationToken.None);
            try
            {
                await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "ack", CancellationToken.None);
            }
            catch (WebSocketException)
            {
                // Socket may already be torn down; nothing to recover.
            }

            var closeEvent = await captured.WaitForMatchAsync(TimeSpan.FromSeconds(5));

            Assert.That(closeEvent.StateKeys, Does.Contain("azure.ai.agentserver.invocations_ws.error.code"));
            Assert.That(closeEvent.GetValue("azure.ai.agentserver.invocations_ws.error.code"),
                Is.EqualTo("internal_error"));
            Assert.That(closeEvent.GetValue("azure.ai.agentserver.invocations_ws.close_code"),
                Is.EqualTo(1011));

            // Handler exception details must NOT appear in the close-event log line.
            var rendered = closeEvent.RenderedMessage ?? string.Empty;
            Assert.That(rendered, Does.Not.Contain("boom"),
                "Handler exception messages must not leak into the structured close-event log line.");
        }
        finally
        {
            await app.StopAsync();
        }
    }

    private static WebApplication BuildApp(InvocationHandler handler, ILoggerProvider? extraLoggerProvider = null)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);
        if (extraLoggerProvider is not null)
        {
            builder.Logging.AddProvider(extraLoggerProvider);
        }

        var app = builder.Build();
        // UseWebSockets is required for handlers that call AcceptWebSocketAsync.
        // Production code wires this through AgentHostMiddlewareExtensions.UseAgentServerCore;
        // tests build WebApplication directly, so call it here.
        app.UseWebSockets();
        app.MapInvocationsServer();
        return app;
    }

    // ---------- In-memory logger for structured-field verification ----

    private sealed class CapturingLoggerProvider : ILoggerProvider
    {
        private readonly System.Collections.Concurrent.ConcurrentQueue<CapturedLogEntry> _entries = new();
        private readonly TaskCompletionSource<CapturedLogEntry> _matchSignal =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly string _matchSubstring;

        public CapturingLoggerProvider(string matchSubstring)
        {
            _matchSubstring = matchSubstring;
        }

        public ILogger CreateLogger(string categoryName) => new CapturingLogger(categoryName, this);

        internal void Record(CapturedLogEntry entry)
        {
            _entries.Enqueue(entry);
            if ((entry.RenderedMessage ?? string.Empty).Contains(_matchSubstring))
            {
                _matchSignal.TrySetResult(entry);
            }
        }

        public Task<CapturedLogEntry> WaitForMatchAsync(TimeSpan timeout) =>
            _matchSignal.Task.WaitAsync(timeout);

        public void Dispose() { }
    }

    private sealed class CapturingLogger : ILogger
    {
        private readonly string _category;
        private readonly CapturingLoggerProvider _provider;

        public CapturingLogger(string category, CapturingLoggerProvider provider)
        {
            _category = category;
            _provider = provider;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var rendered = formatter(state, exception);
            var stateDict = new Dictionary<string, object?>();
            if (state is IEnumerable<KeyValuePair<string, object?>> pairs)
            {
                foreach (var pair in pairs)
                {
                    stateDict[pair.Key] = pair.Value;
                }
            }
            _provider.Record(new CapturedLogEntry(_category, logLevel, eventId, rendered, stateDict));
        }
    }

    private sealed record CapturedLogEntry(
        string Category,
        LogLevel Level,
        EventId EventId,
        string? RenderedMessage,
        IReadOnlyDictionary<string, object?> State)
    {
        public IReadOnlyCollection<string> StateKeys => (IReadOnlyCollection<string>)State.Keys;
        public object? GetValue(string key) => State.TryGetValue(key, out var v) ? v : null;
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
        // Intentionally NOT an InvocationsWebSocketHandler — a plain
        // InvocationHandler must yield 404 on the /invocations_ws route.
    }

    private sealed class EchoWebSocketInvocationHandler : InvocationsWebSocketHandler
    {
        // Overrides the default 404 HandleAsync from InvocationsWebSocketHandler
        // to also accept HTTP — exercises the multi-protocol path.
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

    private sealed class WebSocketOnlyEchoHandler : InvocationsWebSocketHandler
    {
        // Does NOT override HandleAsync — relies on the InvocationsWebSocketHandler
        // default that returns 404 on POST /invocations. This is the "WS-only"
        // ergonomic the new base class enables.
        public override async Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            var buffer = new byte[256];
            while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var received = await webSocket.ReceiveAsync(buffer, cancellationToken);
                if (received.MessageType == WebSocketMessageType.Close)
                {
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

    private sealed class ThrowingWebSocketInvocationHandler : InvocationsWebSocketHandler
    {
        public override Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
            => throw new InvalidOperationException("boom");
    }

    private sealed class HandlerInitiatedCloseInvocationHandler : InvocationsWebSocketHandler
    {
        private readonly WebSocketCloseStatus _status;
        private readonly string _description;

        public HandlerInitiatedCloseInvocationHandler(WebSocketCloseStatus status, string description)
        {
            _status = status;
            _description = description;
        }

        public override async Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            await webSocket.CloseAsync(_status, _description, cancellationToken);
        }
    }

    private sealed class HandlerOceFromUnrelatedTokenInvocationHandler : InvocationsWebSocketHandler
    {
        public override Task HandleWebSocketAsync(
            WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
        {
            // Simulate a handler-internal timeout: throw OCE bound to a
            // CancellationToken the SDK has never seen. The SDK's filter
            // must NOT swallow this as a clean close just because some
            // *other* token happens to be cancelled.
            using var localCts = new CancellationTokenSource();
            localCts.Cancel();
            throw new OperationCanceledException("handler-internal timeout", localCts.Token);
        }
    }

    private sealed class CaptureSessionIdInvocationHandler : InvocationsWebSocketHandler
    {
        private readonly TaskCompletionSource<string> _observed;

        public CaptureSessionIdInvocationHandler(TaskCompletionSource<string> observed)
        {
            _observed = observed;
        }

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
