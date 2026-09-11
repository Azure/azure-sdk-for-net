// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
    public async Task ProtocolClosePreservesWireCodeAndTelemetryWhenCleanupThrows()
    {
        var logs = new CapturingVoiceLogProvider();
        var handler = new ThrowingTerminationHandler();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(handler, logs, requestCompleted);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, "{");
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1002));
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1002));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanErrorCode), Is.EqualTo("protocol_error"));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => entry.Exception is VoiceProtocolException), Is.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => ReferenceEquals(entry.Exception, handler.Failure)), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task CallbackFailurePreserves1011TelemetryAndExceptionIdentity()
    {
        var logs = new CapturingVoiceLogProvider();
        var handler = new ThrowingStartHandler();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(handler, logs, requestCompleted);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, """
            {"type":"session.start","id":"m_start","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """);
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That((int?)close.CloseStatus, Is.EqualTo(1011));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1011));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanErrorCode), Is.EqualTo("internal_error"));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => ReferenceEquals(entry.Exception, handler.Failure)), Is.EqualTo(1));
            Assert.That(logs.ExceptionEntries, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public async Task PeerClosePreserves1001TelemetryWithoutErrorDiagnostic()
    {
        var logs = new CapturingVoiceLogProvider();
        var handler = new TerminationCountingHandler();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(handler, logs, requestCompleted);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.EndpointUnavailable,
            "service-shutdown",
            CancellationToken.None);
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That((int?)close.CloseStatus, Is.EqualTo(1001));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1001));
            Assert.That(closeEvent.State, Does.Not.ContainKey(InvocationsWebSocketConstants.AttrSpanErrorCode));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries, Is.Empty);
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task AbnormalTransportLossPreserves1006Telemetry()
    {
        var logs = new CapturingVoiceLogProvider();
        var handler = new TerminationCountingHandler();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(handler, logs, requestCompleted);
        await app.StartAsync();
        var webSocket = await ConnectAsync(app);

        webSocket.Abort();
        webSocket.Dispose();
        await handler.Terminating.Task.WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1006));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task HostedCloseFailureIsSecondaryAndDiagnosedExactlyOnce()
    {
        var closeException = new WebSocketException("close failed");
        using var webSocket = new FailureInjectingWebSocket(
            Encoding.UTF8.GetBytes("{"),
            closeException: closeException);
        var logs = new CapturingVoiceLogProvider();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(
            new TerminationCountingHandler(),
            logs,
            requestCompleted,
            new TestWebSocketFeature(webSocket));
        await app.StartAsync();

        using var response = await app.GetTestClient().GetAsync("/invocations_ws").WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1002));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1002));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanErrorCode), Is.EqualTo("protocol_error"));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => entry.Exception is VoiceProtocolException), Is.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => ReferenceEquals(entry.Exception, closeException)), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task HostedSendFailurePreserves1006TelemetryAndExceptionIdentity()
    {
        var sendException = new WebSocketException("send failed");
        using var webSocket = new FailureInjectingWebSocket(
            Encoding.UTF8.GetBytes("""
                {"type":"session.start","id":"m_start","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
                """),
            sendException: sendException);
        var logs = new CapturingVoiceLogProvider();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(
            new ImmediateReadinessHandler(),
            logs,
            requestCompleted,
            new TestWebSocketFeature(webSocket));
        await app.StartAsync();

        using var response = await app.GetTestClient().GetAsync("/invocations_ws").WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SentCloseStatus, Is.Null);
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1006));
            Assert.That(closeEvent.State, Does.Not.ContainKey(InvocationsWebSocketConstants.AttrSpanErrorCode));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries.Count(entry => ReferenceEquals(entry.Exception, sendException)), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task HostedRequestCancellationPreserves1006WithoutErrorDiagnostic()
    {
        using var requestCancellation = new CancellationTokenSource();
        using var webSocket = new FailureInjectingWebSocket(blockReceive: true);
        var logs = new CapturingVoiceLogProvider();
        var requestCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp(
            new TerminationCountingHandler(),
            logs,
            requestCompleted,
            new TestWebSocketFeature(webSocket),
            requestCancellation.Token);
        await app.StartAsync();

        var request = app.GetTestClient().GetAsync("/invocations_ws");
        await webSocket.ReceiveStarted.Task.WaitAsync(TestTimeout);
        await requestCancellation.CancelAsync();
        using var response = await request.WaitAsync(TestTimeout);
        var closeEvent = await logs.WaitForCloseEventAsync(TestTimeout);
        await requestCompleted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(closeEvent.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode), Is.EqualTo(1006));
            Assert.That(closeEvent.State, Does.Not.ContainKey(InvocationsWebSocketConstants.AttrSpanErrorCode));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.ExceptionEntries, Is.Empty);
        });
    }

    [Test]
    public async Task ProtocolFailureDoesNotLeakOutcomeToNextConnection()
    {
        var logs = new CapturingVoiceLogProvider();
        var handler = new TerminationCountingHandler();
        await using var app = BuildApp(handler, logs);
        await app.StartAsync();

        using (var first = await ConnectAsync(app))
        {
            await SendTextAsync(first, "{");
            var buffer = new byte[64];
            var close = await first.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
            Assert.That((int?)close.CloseStatus, Is.EqualTo(1002));
        }
        await logs.WaitForCloseEventCountAsync(1, TestTimeout);

        using (var second = await ConnectAsync(app))
        {
            await second.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
            var buffer = new byte[64];
            var close = await second.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
            Assert.That((int?)close.CloseStatus, Is.EqualTo(1000));
        }

        await logs.WaitForCloseEventCountAsync(2, TestTimeout);
        await app.StopAsync();

        Assert.Multiple(() =>
        {
            Assert.That(
                logs.CloseEvents.Select(entry => entry.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode)),
                Is.EqualTo(new object?[] { 1002, 1000 }));
            Assert.That(handler.TerminationCount, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task MalformedResponseTimeoutItemIdUsesProtocolClose()
    {
        var handler = new TimeoutCountingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendTextAsync(webSocket, """
            {"type":"response.timeout","id":"m_timeout","ts":"2026-08-13T00:00:00.000Z","item_ids":["bad"],"stage":"first_output"}
            """);
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        await handler.Terminating.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1002));
            Assert.That(handler.TimeoutCount, Is.Zero);
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
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

    private static WebApplication BuildApp(
        VoiceHandler handler,
        ILoggerProvider? loggerProvider = null,
        TaskCompletionSource? requestCompleted = null,
        IHttpWebSocketFeature? webSocketFeature = null,
        CancellationToken requestAborted = default)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        VoiceTracingRegistration.Add(builder.Services);
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);
        builder.Services.AddSingleton(new VoiceRegistrationMarker(handler.GetType()));
        if (loggerProvider is not null)
        {
            builder.Logging.AddProvider(loggerProvider);
        }

        var app = builder.Build();
        app.UseAgentServerCore();
        if (webSocketFeature is not null)
        {
            app.Use(async (context, next) =>
            {
                context.Features.Set(webSocketFeature);
                await next();
            });
        }
        if (requestAborted.CanBeCanceled)
        {
            app.Use(async (context, next) =>
            {
                context.RequestAborted = requestAborted;
                await next();
            });
        }
        if (requestCompleted is not null)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                finally
                {
                    requestCompleted.TrySetResult();
                }
            });
        }
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
        public InvalidOperationException Failure { get; } = new("cleanup failed");

        public int TerminationCount { get; private set; }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            TerminationCount++;
            throw Failure;
        }
    }

    private sealed class ThrowingStartHandler : VoiceHandler
    {
        public InvalidOperationException Failure { get; } = new("callback failed");

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) => throw Failure;
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

    private sealed class TimeoutCountingHandler : VoiceHandler
    {
        public int TimeoutCount { get; private set; }

        public int TerminationCount { get; private set; }

        public TaskCompletionSource Terminating { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            VoiceResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            TimeoutCount++;
            return Task.CompletedTask;
        }

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

    private sealed class CapturingVoiceLogProvider : ILoggerProvider
    {
        private readonly System.Collections.Concurrent.ConcurrentQueue<CapturedVoiceLogEntry> _entries = new();
        private readonly TaskCompletionSource<CapturedVoiceLogEntry> _closeEvent =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly TaskCompletionSource _secondCloseEvent =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _closeEventCount;

        public IReadOnlyList<CapturedVoiceLogEntry> CloseEvents =>
            _entries.Where(entry => entry.State.ContainsKey(InvocationsWebSocketConstants.AttrSpanCloseCode)).ToArray();

        public IReadOnlyList<CapturedVoiceLogEntry> ExceptionEntries =>
            _entries.Where(entry => entry.Exception is not null).ToArray();

        public ILogger CreateLogger(string categoryName) => new CapturingVoiceLogger(this);

        public Task<CapturedVoiceLogEntry> WaitForCloseEventAsync(TimeSpan timeout) =>
            _closeEvent.Task.WaitAsync(timeout);

        public Task WaitForCloseEventCountAsync(int count, TimeSpan timeout) => count switch
        {
            1 => _closeEvent.Task.WaitAsync(timeout),
            2 => _secondCloseEvent.Task.WaitAsync(timeout),
            _ => throw new ArgumentOutOfRangeException(nameof(count)),
        };

        public void Dispose()
        {
        }

        private void Record(CapturedVoiceLogEntry entry)
        {
            _entries.Enqueue(entry);
            if (entry.State.ContainsKey(InvocationsWebSocketConstants.AttrSpanCloseCode))
            {
                _closeEvent.TrySetResult(entry);
                if (Interlocked.Increment(ref _closeEventCount) == 2)
                {
                    _secondCloseEvent.TrySetResult();
                }
            }
        }

        private sealed class CapturingVoiceLogger : ILogger
        {
            private readonly CapturingVoiceLogProvider _owner;

            public CapturingVoiceLogger(CapturingVoiceLogProvider owner) => _owner = owner;

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                var fields = new Dictionary<string, object?>();
                if (state is IEnumerable<KeyValuePair<string, object?>> pairs)
                {
                    foreach (var pair in pairs)
                    {
                        fields[pair.Key] = pair.Value;
                    }
                }
                _owner.Record(new CapturedVoiceLogEntry(exception, fields));
            }
        }
    }

    private sealed record CapturedVoiceLogEntry(
        Exception? Exception,
        IReadOnlyDictionary<string, object?> State)
    {
        public object? GetValue(string key) => State.TryGetValue(key, out var value) ? value : null;
    }

    private sealed class TestWebSocketFeature : IHttpWebSocketFeature
    {
        private readonly WebSocket _webSocket;

        public TestWebSocketFeature(WebSocket webSocket) => _webSocket = webSocket;

        public bool IsWebSocketRequest => true;

        public Task<WebSocket> AcceptAsync(WebSocketAcceptContext context) =>
            Task.FromResult(_webSocket);
    }

    private sealed class FailureInjectingWebSocket : WebSocket
    {
        private readonly byte[]? _receivePayload;
        private readonly Exception? _sendException;
        private readonly Exception? _closeException;
        private readonly bool _blockReceive;
        private WebSocketState _state = WebSocketState.Open;
        private bool _received;

        public FailureInjectingWebSocket(
            byte[]? receivePayload = null,
            Exception? sendException = null,
            Exception? closeException = null,
            bool blockReceive = false)
        {
            _receivePayload = receivePayload;
            _sendException = sendException;
            _closeException = closeException;
            _blockReceive = blockReceive;
        }

        public TaskCompletionSource ReceiveStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount { get; private set; }

        public WebSocketCloseStatus? SentCloseStatus { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort()
        {
            AbortCount++;
            _state = WebSocketState.Aborted;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            SentCloseStatus = closeStatus;
            if (_closeException is not null)
            {
                return Task.FromException(_closeException);
            }
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override async Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            ReceiveStarted.TrySetResult();
            if (_blockReceive)
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            }
            if (_received)
            {
                throw new InvalidOperationException("The terminal Voice frame must be read exactly once.");
            }
            _received = true;
            if (_receivePayload is null)
            {
                throw new InvalidOperationException("No receive payload was configured.");
            }
            _receivePayload.AsSpan().CopyTo(buffer.AsSpan());
            return new WebSocketReceiveResult(
                count: _receivePayload.Length,
                WebSocketMessageType.Text,
                endOfMessage: true);
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) =>
            _sendException is null ? Task.CompletedTask : Task.FromException(_sendException);

        public override void Dispose() => _state = WebSocketState.Closed;
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
}
