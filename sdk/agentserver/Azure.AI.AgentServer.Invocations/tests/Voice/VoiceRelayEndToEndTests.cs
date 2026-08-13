// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceRelayEndToEndTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);

    [Test]
    public async Task SessionStartIsRelayedWithoutAutomaticReadiness()
    {
        var handler = new ExplicitReadinessHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, """
            {"type":"session.start","id":"m_start","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":5000,"idle_ms":8000,"max_duration_ms":60000}}
            """);
        await handler.StartReceived.Task.WaitAsync(TestTimeout);

        var receive = ReceiveJsonAsync(webSocket);
        Assert.That(receive.IsCompleted, Is.False, "The relay must not synthesize session.ready.");

        handler.AllowReadiness.TrySetResult();
        using var ready = await receive.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(ready.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
            Assert.That(handler.Session!.InvocationContext.SessionId, Is.Not.Empty);
            Assert.That(handler.Start.ProtocolVersion, Is.EqualTo("1.0"));
            Assert.That(handler.Start.Reconnect, Is.False);
        });

        await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
        await handler.Terminating.Task.WaitAsync(TestTimeout);
        Assert.That(handler.TerminationCount, Is.EqualTo(1));
    }

    [Test]
    public async Task SelectedInboundEventsAreDispatchedInWireOrderOnOneSession()
    {
        var handler = new OrderedDispatchHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);
        var frames = new[]
        {
            """{"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}""",
            """{"type":"user.message","id":"m_2","ts":"2026-08-13T00:00:01.000Z","item_id":"in_1","content":[{"type":"input_text","text":"hello"}]}""",
            """{"type":"user.no_input","id":"m_3","ts":"2026-08-13T00:00:02.000Z","item_id":"in_2","count":1}""",
            """{"type":"user.speech_started","id":"m_4","ts":"2026-08-13T00:00:03.000Z"}""",
            """{"type":"barge_in","id":"m_5","ts":"2026-08-13T00:00:04.000Z","response_id":"r_1","heard_text":"heard"}""",
            """{"type":"response.accepted","id":"m_6","ts":"2026-08-13T00:00:05.000Z","response_id":"r_2"}""",
            """{"type":"response.dropped","id":"m_7","ts":"2026-08-13T00:00:06.000Z","response_id":"r_3","reason":"queue_full"}""",
            """{"type":"response.cancelled","id":"m_8","ts":"2026-08-13T00:00:07.000Z","response_id":"r_4","heard_text":"heard"}""",
            """{"type":"response.timeout","id":"m_9","ts":"2026-08-13T00:00:08.000Z","item_ids":["in_3"],"stage":"first_output"}""",
            """{"type":"session.end","id":"m_10","ts":"2026-08-13T00:00:09.000Z","reason":"caller_hangup"}""",
        };

        foreach (var frame in frames)
        {
            await SendTextAsync(webSocket, frame);
        }
        await handler.AllEventsReceived.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(handler.MessageTypes, Is.EqualTo(new[]
            {
                "session.start",
                "user.message",
                "user.no_input",
                "user.speech_started",
                "barge_in",
                "response.accepted",
                "response.dropped",
                "response.cancelled",
                "response.timeout",
                "session.end",
            }));
            Assert.That(handler.Sessions.Distinct(ReferenceEqualityComparer.Instance).Count(), Is.EqualTo(1));
        });

        await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
        await handler.Terminating.Task.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task ProtocolClosePreservesCodeAndCleanupWhenTerminationHookThrows()
    {
        var logs = new CloseLogProvider();
        var handler = new ThrowingTerminationHandler();
        await using var app = BuildApp(handler, logs);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, "{");
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        var closeLog = await logs.CloseEvent.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1002));
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
            Assert.That(closeLog.CloseCode, Is.EqualTo(1002));
        });
    }

    [Test]
    public async Task ThrowingCloseLoggerCannotSuppressProtocolClose()
    {
        var handler = new TerminationCountingHandler();
        await using var app = BuildApp(handler, new ThrowingCloseLogProvider());
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, "{");
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        await handler.Terminating.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1002));
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task BlockingDiagnosticLoggerCannotDelayProtocolClose()
    {
        var logs = new BlockingDiagnosticLogProvider();
        var handler = new TerminationCountingHandler();
        await using var app = BuildApp(handler, logs);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, "{");
        var buffer = new byte[64];
        var receive = webSocket.ReceiveAsync(buffer, CancellationToken.None);
        await logs.Entered.Task.WaitAsync(TestTimeout);
        try
        {
            Assert.That(receive.IsCompleted, Is.True,
                "Transport close must complete before invoking diagnostic logger callbacks.");
        }
        finally
        {
            logs.Release.Set();
        }

        var close = await receive.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1002));
        });
    }

    [Test]
    public async Task PlatformIdentityAndTraceContextReachVoiceCallback()
    {
        const string traceId = "0123456789abcdef0123456789abcdef";
        var handler = new ContextCapturingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        var client = app.GetTestServer().CreateWebSocketClient();
        client.ConfigureRequest = request =>
        {
            request.Headers[PlatformHeaders.FoundryCallId] = "call-voice";
            request.Headers[PlatformHeaders.UserId] = "user-voice";
            request.Headers[PlatformHeaders.TraceParent] = $"00-{traceId}-0123456789abcdef-01";
        };
        using var webSocket = await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);

        await SendTextAsync(webSocket, """
            {"type":"session.start","id":"m_start","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """);
        await handler.Captured.Task.WaitAsync(TestTimeout);
        using var ready = await ReceiveJsonAsync(webSocket).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(handler.AmbientCallId, Is.EqualTo("call-voice"));
            Assert.That(handler.AmbientUserId, Is.EqualTo("user-voice"));
            Assert.That(handler.ExplicitCallId, Is.EqualTo("call-voice"));
            Assert.That(handler.ExplicitUserId, Is.EqualTo("user-voice"));
            Assert.That(handler.TraceId, Is.EqualTo(traceId));
        });

        await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
    }

    private static WebApplication BuildApp(VoiceHandler handler, ILoggerProvider? loggerProvider = null)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);
        if (loggerProvider is not null)
        {
            builder.Logging.AddProvider(loggerProvider);
        }

        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        return app;
    }

    private static async Task<WebSocket> ConnectAsync(WebApplication app)
    {
        var client = app.GetTestServer().CreateWebSocketClient();
        return await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);
    }

    private static Task SendTextAsync(WebSocket webSocket, string value) =>
        webSocket.SendAsync(
            Encoding.UTF8.GetBytes(value),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

    private static async Task<JsonDocument> ReceiveJsonAsync(WebSocket webSocket)
    {
        var buffer = new byte[4096];
        var received = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(received.EndOfMessage, Is.True);
        return JsonDocument.Parse(buffer.AsMemory(0, received.Count));
    }

    private sealed class ExplicitReadinessHandler : VoiceHandler
    {
        public TaskCompletionSource StartReceived { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource AllowReadiness { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource Terminating { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public VoiceSession? Session { get; private set; }

        public VoiceSessionStartEvent Start { get; private set; } = null!;

        public int TerminationCount { get; private set; }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Session = session;
            Start = start;
            StartReceived.TrySetResult();
            await AllowReadiness.Task.WaitAsync(cancellationToken);
            await session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
        }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            Session = session;
            TerminationCount++;
            Terminating.TrySetResult();
        }
    }

    private sealed class OrderedDispatchHandler : VoiceHandler
    {
        private readonly object _sync = new();

        public List<string> MessageTypes { get; } = new();

        public List<VoiceSession> Sessions { get; } = new();

        public TaskCompletionSource AllEventsReceived { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource Terminating { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) => Record(session, start);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            VoiceUserMessageEvent message,
            CancellationToken cancellationToken) => Record(session, message);

        protected override Task OnUserNoInputAsync(
            VoiceSession session,
            VoiceUserNoInputEvent noInput,
            CancellationToken cancellationToken) => Record(session, noInput);

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            VoiceUserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken) => Record(session, speechStarted);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            VoiceBargeInEvent bargeIn,
            CancellationToken cancellationToken) => Record(session, bargeIn);

        protected override Task OnResponseAcceptedAsync(
            VoiceSession session,
            VoiceResponseAcceptedEvent accepted,
            CancellationToken cancellationToken) => Record(session, accepted);

        protected override Task OnResponseDroppedAsync(
            VoiceSession session,
            VoiceResponseDroppedEvent dropped,
            CancellationToken cancellationToken) => Record(session, dropped);

        protected override Task OnResponseCancelledAsync(
            VoiceSession session,
            VoiceResponseCancelledEvent cancelled,
            CancellationToken cancellationToken) => Record(session, cancelled);

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            VoiceResponseTimeoutEvent timeout,
            CancellationToken cancellationToken) => Record(session, timeout);

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            VoiceSessionEndEvent end,
            CancellationToken cancellationToken) => Record(session, end);

        protected override void OnConnectionTerminating(VoiceSession session) =>
            Terminating.TrySetResult();

        private Task Record(VoiceSession session, VoiceInboundMessage message)
        {
            lock (_sync)
            {
                Sessions.Add(session);
                MessageTypes.Add(message.MessageType);
                if (MessageTypes.Count == 10)
                {
                    AllEventsReceived.TrySetResult();
                }
            }
            return Task.CompletedTask;
        }
    }

    private sealed class ThrowingTerminationHandler : VoiceHandler
    {
        public int TerminationCount { get; private set; }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            TerminationCount++;
            throw new InvalidOperationException("cleanup failed");
        }
    }

    private sealed class TerminationCountingHandler : VoiceHandler
    {
        public int TerminationCount { get; private set; }

        public TaskCompletionSource Terminating { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            TerminationCount++;
            Terminating.TrySetResult();
        }
    }

    private sealed class ContextCapturingHandler : VoiceHandler
    {
        public TaskCompletionSource Captured { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public string? AmbientCallId { get; private set; }

        public string? AmbientUserId { get; private set; }

        public string? ExplicitCallId { get; private set; }

        public string? ExplicitUserId { get; private set; }

        public string? TraceId { get; private set; }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            AmbientCallId = FoundryAgentRequestContext.Current.CallId;
            AmbientUserId = FoundryAgentRequestContext.Current.UserId;
            ExplicitCallId = session.InvocationContext.PlatformContext.CallId;
            ExplicitUserId = session.InvocationContext.PlatformContext.UserIdKey;
            TraceId = Activity.Current?.TraceId.ToString();
            Captured.TrySetResult();
            await session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
        }
    }

    private sealed class ImmediateReadinessHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
    }

    private sealed class CloseLogProvider : ILoggerProvider
    {
        public TaskCompletionSource<(int CloseCode, string Category)> CloseEvent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public ILogger CreateLogger(string categoryName) => new CloseLogger(categoryName, this);

        public void Dispose()
        {
        }

        private sealed class CloseLogger : ILogger
        {
            private readonly string _category;
            private readonly CloseLogProvider _owner;

            public CloseLogger(string category, CloseLogProvider owner)
            {
                _category = category;
                _owner = owner;
            }

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (state is not IEnumerable<KeyValuePair<string, object?>> fields)
                {
                    return;
                }

                var closeCode = fields.FirstOrDefault(field =>
                    field.Key == "azure.ai.agentserver.invocations_ws.close_code").Value;
                if (closeCode is int code)
                {
                    _owner.CloseEvent.TrySetResult((code, _category));
                }
            }
        }
    }

    private sealed class ThrowingCloseLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new ThrowingCloseLogger();

        public void Dispose()
        {
        }

        private sealed class ThrowingCloseLogger : ILogger
        {
            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (state is IEnumerable<KeyValuePair<string, object?>> fields &&
                    fields.Any(field => field.Key == "azure.ai.agentserver.invocations_ws.close_code"))
                {
                    throw new InvalidOperationException("logger failed");
                }
            }
        }
    }

    private sealed class BlockingDiagnosticLogProvider : ILoggerProvider
    {
        public TaskCompletionSource Entered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public ManualResetEventSlim Release { get; } = new(false);

        public ILogger CreateLogger(string categoryName) => new BlockingDiagnosticLogger(this);

        public void Dispose() => Release.Dispose();

        private sealed class BlockingDiagnosticLogger : ILogger
        {
            private readonly BlockingDiagnosticLogProvider _owner;

            public BlockingDiagnosticLogger(BlockingDiagnosticLogProvider owner) => _owner = owner;

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (exception is VoiceProtocolException)
                {
                    _owner.Entered.TrySetResult();
                    _owner.Release.Wait(TestTimeout);
                }
            }
        }
    }
}
