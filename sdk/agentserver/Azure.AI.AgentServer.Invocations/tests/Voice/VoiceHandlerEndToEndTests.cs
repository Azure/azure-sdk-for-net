// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

/// <summary>
/// Full-pipeline protocol tests for the typed Voice Live Bridge handler.
/// </summary>
[TestFixture]
[NonParallelizable]
public class VoiceHandlerEndToEndTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);

    [Test]
    public async Task ActivationRejectsApplicationFrameAsFirstMessage()
    {
        var handler = new NoInputHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_early", "in_early", "too early"));

        using var response = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(response.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.rejected"));
            Assert.That(response.RootElement.GetProperty("code").GetString(), Is.EqualTo("invalid_session_start"));
        });
    }

    [Test]
    public async Task SynchronousStartupThrowRejectsWithStartupFailed()
    {
        await using var app = BuildApp(new SynchronousThrowStartupHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendAsync(webSocket, SessionStartFrame("m_start"));

        using var response = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(response.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.rejected"));
            Assert.That(response.RootElement.GetProperty("code").GetString(), Is.EqualTo("startup_failed"));
        });
    }

    [Test]
    public async Task NullStartupTaskRejectsWithStartupFailed()
    {
        await using var app = BuildApp(new NullTaskStartupHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendAsync(webSocket, SessionStartFrame("m_start"));

        using var response = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(response.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.rejected"));
            Assert.That(response.RootElement.GetProperty("code").GetString(), Is.EqualTo("startup_failed"));
        });
    }

    [Test]
    public async Task SessionExposesInvocationTransportContext()
    {
        var handler = new ContextCapturingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        var server = app.GetTestServer();
        var client = server.CreateWebSocketClient();
        client.ConfigureRequest = request =>
        {
            request.Headers["x-client-test"] = "forwarded";
            request.Headers["x-agent-user-id"] = "user-42";
            request.Headers["x-agent-foundry-call-id"] = "call-42";
        };
        using var webSocket = await client.ConnectAsync(
            new Uri(server.BaseAddress, "invocations_ws?custom=value"),
            CancellationToken.None);

        await SendAsync(webSocket, SessionStartFrame("m_start"));
        using var ready = await ReceiveJsonAsync(webSocket);
        var context = await handler.Context.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(context.InvocationId, Is.Not.Empty);
            Assert.That(context.SessionId, Is.Not.Empty);
            Assert.That(context.ClientHeaders["x-client-test"], Is.EqualTo("forwarded"));
            Assert.That(context.QueryParameters["custom"].ToString(), Is.EqualTo("value"));
            Assert.That(context.PlatformContext.UserIdKey, Is.EqualTo("user-42"));
            Assert.That(context.PlatformContext.CallId, Is.EqualTo("call-42"));
        });
    }

    [Test]
    public async Task NoInputTurnDispatchesAndRepliesInWireOrder()
    {
        var handler = new NoInputHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:00.000Z","item_id":"in_silence","count":2}
            """);

        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(created.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.created"));
            Assert.That(created.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_silence"));
            Assert.That(output.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.done"));
            Assert.That(output.RootElement.GetProperty("text").GetString(), Is.EqualTo("Silence count 2"));
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task UnknownOnlyUserContentDoesNotCreateTurnOrCloseConnection()
    {
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.message","id":"opaque-user","ts":"2026-08-03T00:00:00.000Z","item_id":"in_future","content":[{"type":"future_content","value":1}]}
            """);
        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"opaque-no-input","ts":"2026-08-03T00:00:01.000Z","item_id":"in_after_future","count":1}
            """);

        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
    }

    [Test]
    public async Task BinaryFrameClosesConnectionWithUnsupportedData()
    {
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await webSocket.SendAsync(
            new byte[] { 1, 2, 3 },
            WebSocketMessageType.Binary,
            endOfMessage: true,
            CancellationToken.None);

        var result = await webSocket.ReceiveAsync(new byte[64], CancellationToken.None).WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1003));
        });
    }

    [Test]
    public async Task FragmentedTextFrameIsReassembledBeforeDispatch()
    {
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);
        var payload = Encoding.UTF8.GetBytes("""
            {"type":"user.no_input","id":"m_fragmented","ts":"2026-08-03T00:00:00.000Z","item_id":"in_fragmented","count":3}
            """);
        var split = payload.Length / 2;

        await webSocket.SendAsync(
            payload.AsMemory(0, split),
            WebSocketMessageType.Text,
            endOfMessage: false,
            CancellationToken.None);
        await webSocket.SendAsync(
            payload.AsMemory(split),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(created.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_fragmented"));
            Assert.That(output.RootElement.GetProperty("text").GetString(), Is.EqualTo("Silence count 3"));
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task FragmentedFrameOverOneMiBClosesWithMessageTooBig()
    {
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);
        var fragment = new byte[600 * 1024];
        Array.Fill(fragment, (byte)' ');

        await webSocket.SendAsync(
            fragment,
            WebSocketMessageType.Text,
            endOfMessage: false,
            CancellationToken.None);
        await webSocket.SendAsync(
            fragment,
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

        var result = await webSocket.ReceiveAsync(new byte[64], CancellationToken.None).WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1009));
        });
    }

    [Test]
    public async Task AgentTerminalAbsorbsLateFramesWithoutInvokingCustomerCallbacks()
    {
        var handler = new AgentTerminalPhaseHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_terminal", "end"));
        using var endCall = await ReceiveJsonAsync(webSocket);
        Assert.That(endCall.RootElement.GetProperty("type").GetString(), Is.EqualTo("end_call"));
        await handler.TerminalSent.Task.WaitAsync(TestTimeout);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_late_signal","ts":"2026-08-03T00:00:01.000Z"}
            """);
        await SendAsync(webSocket, """
            {"type":"conversation.item.create","id":"m_late_history","ts":"2026-08-03T00:00:02.000Z","item":{"id":"hi_late","role":"user","content":[{"type":"input_text","text":"must not persist"}]}}
            """);
        await SendAsync(webSocket, UserMessageFrame("m_late_turn", "in_late", "must not run"));
        await SendAsync(webSocket, """
            {"type":"session.end","id":"m_end","ts":"2026-08-03T00:00:03.000Z","reason":"agent_completed"}
            """);

        await handler.SessionEnded.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(handler.SignalCallbackCount, Is.Zero);
            Assert.That(handler.HistoryCallbackCount, Is.Zero);
            Assert.That(handler.UserMessageCallbackCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task MoreThan4096UniqueMessagesDoNotTerminateValidConnection()
    {
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        for (var index = 0; index < 4100; index++)
        {
            await SendAsync(webSocket, $$"""
                {"type":"future.message","id":"opaque-{{index}}","ts":"2026-08-03T00:00:00.000Z"}
                """);
        }

        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"opaque-final","ts":"2026-08-03T00:00:01.000Z","item_id":"in_after_limit","count":1}
            """);
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
    }

    [Test]
    public async Task ThrowingMeterListenerDoesNotFailConnection()
    {
        using var listener = new MeterListener();
        listener.InstrumentPublished = (instrument, meterListener) =>
        {
            if (instrument.Meter.Name == "Azure.AI.AgentServer.Invocations")
            {
                meterListener.EnableMeasurementEvents(instrument);
            }
        };
        listener.SetMeasurementEventCallback<long>(static (instrument, measurement, tags, state) =>
            throw new InvalidOperationException("telemetry failed"));
        listener.SetMeasurementEventCallback<double>(static (instrument, measurement, tags, state) =>
            throw new InvalidOperationException("telemetry failed"));
        listener.Start();

        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);
        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:00.000Z","item_id":"in_silence","count":1}
            """);

        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
    }

    [Test]
    public async Task ThrowingTurnActivityListenerDoesNotFailConnection()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.Invocations",
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                options.Name == "hosted_agent.turn"
                    ? throw new InvalidOperationException("telemetry failed")
                    : ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(listener);
        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:00.000Z","item_id":"in_silence","count":1}
            """);

        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
    }

    [Test]
    public async Task BlockingTurnActivityListenerDoesNotSuppressSessionEnd()
    {
        var listenerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseListener = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.Invocations",
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Name == "hosted_agent.turn")
                {
                    listenerStarted.TrySetResult();
                    releaseListener.Task.GetAwaiter().GetResult();
                }

                return ActivitySamplingResult.AllData;
            },
        };
        ActivitySource.AddActivityListener(listener);
        var handler = new SessionEndHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        try
        {
            await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "blocked telemetry"));
            await listenerStarted.Task.WaitAsync(TestTimeout);
            await SendAsync(webSocket, """
                {"type":"session.end","id":"m_end","ts":"2026-08-03T00:00:01.000Z","reason":"caller_hangup"}
                """);

            var sessionEnd = await handler.SessionEnd.Task.WaitAsync(TimeSpan.FromSeconds(1));
            Assert.That(sessionEnd.Reason, Is.EqualTo("caller_hangup"));
        }
        finally
        {
            releaseListener.TrySetResult();
        }
    }

    [Test]
    public async Task BargeInCancelsActiveTurnBeforeDispatchingCallback()
    {
        var handler = new InterruptibleHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "hello"));
        await handler.TurnStarted.Task.WaitAsync(TestTimeout);

        using var created = await ReceiveJsonAsync(webSocket);
        using var delta = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        var itemId = delta.RootElement.GetProperty("item_id").GetString()!;

        await SendAsync(webSocket, $$"""
            {"type":"barge_in","id":"m_barge","ts":"2026-08-03T00:00:01.000Z","response_id":"{{responseId}}","item_id":"{{itemId}}","heard_text":"Hel"}
            """);

        await handler.TurnCancelled.Task.WaitAsync(TestTimeout);
        await handler.CancellationCallbackRan.Task.WaitAsync(TestTimeout);
        var bargeIn = await handler.BargeIn.Task.WaitAsync(TestTimeout);
        var terminalResponse = await handler.ResponseStarted.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(bargeIn.ResponseId, Is.EqualTo(responseId));
            Assert.That(bargeIn.ItemId, Is.EqualTo(itemId));
            Assert.That(bargeIn.HeardText, Is.EqualTo("Hel"));
            Assert.That(terminalResponse.RetainedOutputChunkCount, Is.Zero);
        });
    }

    [Test]
    public async Task InvalidTimeoutInputPrefixClosesWithPolicyViolation()
    {
        var handler = new BlockingTurnHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_expected", "wait"));
        await handler.TurnStarted.Task.WaitAsync(TestTimeout);
        await SendAsync(webSocket, """
            {"type":"response.timeout","id":"m_timeout","ts":"2026-08-03T00:00:01.000Z","item_ids":["in_wrong"],"stage":"first_output"}
            """);

        var result = await webSocket.ReceiveAsync(new byte[64], CancellationToken.None).WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(VoiceProtocolConstants.ClosePolicyViolation));
        });
    }

    [Test]
    public async Task ResponseTimeoutCancelsActiveTurnBeforeTimeoutCallback()
    {
        var handler = new TimeoutHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "hello"));
        await handler.TurnStarted.Task.WaitAsync(TestTimeout);

        using var created = await ReceiveJsonAsync(webSocket);
        using var delta = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;

        await SendAsync(webSocket, $$"""
            {"type":"response.timeout","id":"m_timeout","ts":"2026-08-03T00:00:01.000Z","response_id":"{{responseId}}","stage":"idle"}
            """);

        await handler.TurnCancelled.Task.WaitAsync(TestTimeout);
        await handler.CancellationCallbackRan.Task.WaitAsync(TestTimeout);
        var timeout = await handler.Timeout.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(timeout.ResponseId, Is.EqualTo(responseId));
            Assert.That(timeout.Stage, Is.EqualTo("idle"));
        });
    }

    [Test]
    public async Task MultiItemStreamingPreservesWireOrderAndFullItemText()
    {
        await using var app = BuildApp(new MultiItemHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "hello"));
        var frames = new List<JsonDocument>();
        try
        {
            for (var index = 0; index < 7; index++)
            {
                frames.Add(await ReceiveJsonAsync(webSocket));
            }

            Assert.That(
                frames.Select(frame => frame.RootElement.GetProperty("type").GetString()),
                Is.EqualTo(new[]
                {
                    "response.created",
                    "response.output_text.delta",
                    "response.output_text.delta",
                    "response.output_text.done",
                    "response.output_text.done",
                    "response.output_text.done",
                    "response.done",
                }));
            Assert.That(frames[3].RootElement.GetProperty("text").GetString(), Is.EqualTo("Hello world"));
            Assert.That(frames[1].RootElement.GetProperty("item_id").GetString(),
                Is.EqualTo(frames[3].RootElement.GetProperty("item_id").GetString()));
            Assert.That(frames[4].RootElement.GetProperty("item_id").GetString(),
                Is.Not.EqualTo(frames[3].RootElement.GetProperty("item_id").GetString()));
            Assert.That(frames[5].RootElement.GetProperty("voice").GetProperty("rate").GetString(), Is.EqualTo("+10%"));
        }
        finally
        {
            foreach (var frame in frames)
            {
                frame.Dispose();
            }
        }
    }

    [Test]
    public async Task StreamingRejectsDeltaBeforeFullDoneFrameWouldExceedLimit()
    {
        var handler = new EscapedStreamingLimitHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "limit"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var delta = await ReceiveJsonAsync(webSocket);
        using var itemDone = await ReceiveJsonAsync(webSocket);
        using var responseDone = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(handler.SecondDeltaRejected, Is.True);
            Assert.That(delta.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.delta"));
            Assert.That(itemDone.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.done"));
            Assert.That(itemDone.RootElement.GetProperty("text").GetString(), Has.Length.EqualTo(100 * 1024));
            Assert.That(responseDone.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task OversizedFirstOutputDoesNotConsumePendingPrefix()
    {
        var handler = new OversizedFirstOutputHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "recover"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(handler.OversizedOutputRejected, Is.True);
            Assert.That(created.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_1"));
            Assert.That(output.RootElement.GetProperty("text").GetString(), Is.EqualTo("recovered"));
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task DeclineEmitsResponseNoneWithoutOpeningResponse()
    {
        await using var app = BuildApp(new DecliningHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "ignore"));
        using var declined = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(declined.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.none"));
            Assert.That(declined.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_1"));
            Assert.That(declined.RootElement.GetProperty("reason").GetString(), Is.EqualTo("no_reply_needed"));
            Assert.That(declined.RootElement.TryGetProperty("response_id", out _), Is.False);
        });
    }

    [Test]
    public async Task ProactiveResponseIsUnwritableUntilAcceptedThenCompletes()
    {
        var handler = new ProactiveHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        using var created = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        Assert.That(created.RootElement.TryGetProperty("in_reply_to", out _), Is.False);

        await SendAsync(webSocket, $$"""
            {"type":"response.accepted","id":"m_accept","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}"}
            """);

        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(output.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.done"));
            Assert.That(output.RootElement.GetProperty("text").GetString(), Is.EqualTo("Proactive update"));
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task DroppedProactiveResponseCompletesAwaitWithTypedException()
    {
        var handler = new ProactiveHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        using var created = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;

        await SendAsync(webSocket, $$"""
            {"type":"response.dropped","id":"m_drop","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}","reason":"queue_full"}
            """);

        var exception = await handler.ProactiveDropped.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(exception.ResponseId, Is.EqualTo(responseId));
            Assert.That(exception.Reason, Is.EqualTo("queue_full"));
        });
    }

    [Test]
    public async Task TimeoutBeforeProactiveAcceptanceClosesWithPolicyViolation()
    {
        var handler = new PendingProactiveTimeoutHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        using var created = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;

        await SendAsync(webSocket, $$"""
            {"type":"response.timeout","id":"m_timeout","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}","stage":"first_output"}
            """);

        var close = await webSocket.ReceiveAsync(new byte[64], CancellationToken.None).WaitAsync(TestTimeout);
        var admissionFailure = await handler.AdmissionFailure.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(VoiceProtocolConstants.ClosePolicyViolation));
            Assert.That(admissionFailure, Is.TypeOf<VoiceBridgeConnectionClosedException>());
        });
    }

    [Test]
    public async Task AcceptedProactiveResponseBlocksLaterTurnUntilTerminal()
    {
        var handler = new ProactiveOrderingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        using var proactiveCreated = await ReceiveJsonAsync(webSocket);
        var proactiveResponseId = proactiveCreated.RootElement.GetProperty("response_id").GetString()!;
        await SendAsync(webSocket, $$"""
            {"type":"response.accepted","id":"m_accept","ts":"2026-08-03T00:00:02.000Z","response_id":"{{proactiveResponseId}}"}
            """);
        await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_later", "later"));

        handler.AllowProactiveCompletion.TrySetResult();
        using var proactiveOutput = await ReceiveJsonAsync(webSocket);
        using var proactiveDone = await ReceiveJsonAsync(webSocket);
        await handler.UserTurnStarted.Task.WaitAsync(TestTimeout);
        using var replyCreated = await ReceiveJsonAsync(webSocket);
        using var replyOutput = await ReceiveJsonAsync(webSocket);
        using var replyDone = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(proactiveOutput.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.done"));
            Assert.That(proactiveDone.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
            Assert.That(handler.UserTurnStartedBeforeProactiveTerminal, Is.False);
            Assert.That(replyCreated.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_later"));
        });
    }

    [Test]
    public async Task AcceptedProactiveResponseEmitsTurnSpan()
    {
        var proactiveTurnStopped = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.Invocations",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                if (activity.OperationName == "hosted_agent.turn" &&
                    Equals(activity.GetTagItem("voice.callback.kind"), "proactive"))
                {
                    proactiveTurnStopped.TrySetResult(activity);
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var handler = new ProactiveHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        using var created = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        await SendAsync(webSocket, $$"""
            {"type":"response.accepted","id":"m_accept","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}"}
            """);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);

        var proactiveTurn = await proactiveTurnStopped.Task.WaitAsync(TestTimeout);
        Assert.That(proactiveTurn.GetTagItem("gen_ai.response.id"), Is.EqualTo(responseId));
    }

    [Test]
    public async Task SelfCancelAwaitsResponseCancelledAndSuppressesResponseDone()
    {
        var handler = new SelfCancellingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "correct yourself"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var delta = await ReceiveJsonAsync(webSocket);
        using var cancel = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        var itemId = delta.RootElement.GetProperty("item_id").GetString()!;
        Assert.That(cancel.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.cancel"));

        await SendAsync(webSocket, $$"""
            {"type":"response.cancelled","id":"m_cancelled","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}","item_id":"{{itemId}}","heard_text":"Wr"}
            """);

        var outcome = await handler.Outcome.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(outcome.Kind, Is.EqualTo("cancelled"));
            Assert.That(outcome.HeardText, Is.EqualTo("Wr"));
            Assert.That(handler.IsTerminalAtOutcome, Is.True);
            Assert.That(handler.IsCancellationRequestedAtOutcome, Is.True);
        });
    }

    [Test]
    public async Task CancellingCancelAwaitDoesNotAutoCompleteResponse()
    {
        var handler = new AbandonedCancelAwaitHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "cancel await"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var cancel = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        var itemId = output.RootElement.GetProperty("item_id").GetString()!;

        handler.CancelAwait.TrySetResult();
        await handler.CancelAwaitCancelled.Task.WaitAsync(TestTimeout);
        Assert.That(handler.ResponseWasTerminalAfterAwaitCancellation, Is.False);

        await SendAsync(webSocket, $$"""
            {"type":"response.cancelled","id":"m_cancelled","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}","item_id":"{{itemId}}","heard_text":"safe"}
            """);

        await handler.TerminalObserved.Task.WaitAsync(TestTimeout);
        Assert.That(handler.CancelPendingAtTerminal, Is.False);
    }

    [Test]
    public async Task OversizedCancelDoesNotSetCancelPending()
    {
        var handler = new OversizedCancelHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "cancel"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);

        Assert.Multiple(() =>
        {
            Assert.That(handler.CancelRejected, Is.True);
            Assert.That(handler.CancelPendingAfterFailure, Is.False);
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task DtmfCollectionCompletesAsNewResponseTurn()
    {
        var handler = new DtmfHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "menu"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var menu = await ReceiveJsonAsync(webSocket);
        using var collect = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        var collectionId = collect.RootElement.GetProperty("collection_id").GetString()!;
        Assert.That(collect.RootElement.GetProperty("type").GetString(), Is.EqualTo("dtmf.collect"));

        await SendAsync(webSocket, $$"""
            {"type":"dtmf","id":"m_digits","ts":"2026-08-03T00:00:02.000Z","collection_id":"{{collectionId}}","item_id":"in_digits","digits":"12","completion_reason":"max_digits"}
            """);

        using var replyCreated = await ReceiveJsonAsync(webSocket);
        using var reply = await ReceiveJsonAsync(webSocket);
        using var replyDone = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(replyCreated.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_digits"));
            Assert.That(reply.RootElement.GetProperty("text").GetString(), Is.EqualTo("Received 2 digits"));
            Assert.That(replyDone.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
        });
    }

    [Test]
    public async Task HistoryMutationCompletesBeforeLaterTurnDispatch()
    {
        var handler = new OrderedHistoryHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"conversation.item.create","id":"m_history","ts":"2026-08-03T00:00:01.000Z","item":{"id":"hi_1","role":"user","content":[{"type":"input_text","text":"context"}]}}
            """);
        await handler.HistoryStarted.Task.WaitAsync(TestTimeout);
        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "question"));
        Assert.That(handler.UserTurnStarted.Task.IsCompleted, Is.False);

        handler.AllowHistory.TrySetResult();
        using var mutationResult = await ReceiveJsonAsync(webSocket);
        await handler.UserTurnStarted.Task.WaitAsync(TestTimeout);
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);

        Assert.That(mutationResult.RootElement.GetProperty("type").GetString(), Is.EqualTo("conversation.item.created"));
    }

    [Test]
    public async Task HistoryMutationCanInsertAfterUserInputItem()
    {
        var handler = new HistoryIdentityHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_anchor", "anchor"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        await SendAsync(webSocket, """
            {"type":"conversation.item.create","id":"m_history","ts":"2026-08-03T00:00:01.000Z","previous_item_id":"in_anchor","item":{"id":"hi_after_anchor","role":"user","content":[{"type":"input_text","text":"context"}]}}
            """);

        using var mutationResult = await ReceiveJsonAsync(webSocket);
        var mutation = await handler.HistoryCreated.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(mutation.PreviousItemId, Is.EqualTo("in_anchor"));
            Assert.That(mutationResult.RootElement.GetProperty("type").GetString(), Is.EqualTo("conversation.item.created"));
        });
    }

    [Test]
    public async Task ReusedHistoryItemIdClosesWithPolicyViolationBeforeSecondCallback()
    {
        var handler = new HistoryIdentityHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"conversation.item.create","id":"m_history_1","ts":"2026-08-03T00:00:01.000Z","item":{"id":"hi_reused","role":"user","content":[{"type":"input_text","text":"first"}]}}
            """);
        using var firstResult = await ReceiveJsonAsync(webSocket);
        await handler.HistoryCreated.Task.WaitAsync(TestTimeout);
        await SendAsync(webSocket, """
            {"type":"conversation.item.create","id":"m_history_2","ts":"2026-08-03T00:00:02.000Z","item":{"id":"hi_reused","role":"user","content":[{"type":"input_text","text":"second"}]}}
            """);

        var close = await webSocket.ReceiveAsync(new byte[128], CancellationToken.None).WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1008));
            Assert.That(handler.HistoryCallbackCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task ExactDuplicateIsIgnoredBeforeSemanticDispatch()
    {
        var handler = new DedupeHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        var userFrame = UserMessageFrame("m_user", "in_1", "hello");
        await SendAsync(webSocket, userFrame);
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        await SendAsync(webSocket, userFrame);
        await SendAsync(webSocket, """
            {"type":"user.speech_started","id":"m_after","ts":"2026-08-03T00:00:02.000Z"}
            """);

        await handler.AfterDuplicate.Task.WaitAsync(TestTimeout);
        Assert.That(handler.UserMessageCount, Is.EqualTo(1));
    }

    [Test]
    public async Task ReusedEnvelopeIdWithChangedPayloadClosesWithPolicyViolation()
    {
        var connectionStopped = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.Invocations",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                if (activity.OperationName == "agentserver.connection")
                {
                    connectionStopped.TrySetResult(activity);
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"future.message","id":"m_same","ts":"2026-08-03T00:00:01.000Z","value":1}
            """);
        await SendAsync(webSocket, """
            {"type":"future.message","id":"m_same","ts":"2026-08-03T00:00:01.000Z","value":2}
            """);

        var buffer = new byte[128];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)webSocket.CloseStatus, Is.EqualTo(1008));
        });

        var connection = await connectionStopped.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(connection.GetTagItem("azure.ai.agentserver.invocations_ws.close_code"), Is.EqualTo(1008));
            Assert.That(connection.Status, Is.EqualTo(ActivityStatusCode.Error));
        });
    }

    [Test]
    public async Task SessionEndInvokesCallbackDuringOrderedDrain()
    {
        var handler = new SessionEndHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"session.end","id":"m_end","ts":"2026-08-03T00:00:01.000Z","reason":"caller_hangup"}
            """);

        var sessionEnd = await handler.SessionEnd.Task.WaitAsync(TestTimeout);
        Assert.That(sessionEnd.Reason, Is.EqualTo("caller_hangup"));
    }

    [Test]
    public async Task SessionEndBypassesCallbackThatIgnoresCancellation()
    {
        var handler = new BlockingSignalSessionEndHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        try
        {
            await SendAsync(webSocket, """
                {"type":"user.speech_started","id":"m_signal","ts":"2026-08-03T00:00:01.000Z"}
                """);
            await handler.SignalStarted.Task.WaitAsync(TestTimeout);

            await SendAsync(webSocket, """
                {"type":"session.end","id":"m_end","ts":"2026-08-03T00:00:02.000Z","reason":"caller_hangup"}
                """);

            var sessionEnd = await handler.SessionEnd.Task.WaitAsync(TimeSpan.FromSeconds(1));
            Assert.Multiple(() =>
            {
                Assert.That(sessionEnd.Reason, Is.EqualTo("caller_hangup"));
                Assert.That(handler.SignalCompleted.Task.IsCompleted, Is.False);
            });
        }
        finally
        {
            handler.ReleaseSignal.TrySetResult();
        }
    }

    [Test]
    public async Task VoiceTurnSpanParentsCustomerWorkUnderConnectionSpan()
    {
        var stoppedActivities = new List<Activity>();
        var connectionStopped = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name is "Azure.AI.AgentServer.Invocations" or "AgentServer.Tests.Customer",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                lock (stoppedActivities)
                {
                    stoppedActivities.Add(activity);
                }

                if (activity.OperationName == "agentserver.connection")
                {
                    connectionStopped.TrySetResult();
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var handler = new TracingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_trace", "in_trace", "sensitive transcript"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        var customerParent = await handler.CustomerParent.Task.WaitAsync(TestTimeout);
        var customerBaggage = await handler.CustomerBaggage.Task.WaitAsync(TestTimeout);

        await SendAsync(webSocket, """
            {"type":"session.end","id":"m_end","ts":"2026-08-03T00:00:02.000Z","reason":"caller_hangup"}
            """);
        var closeBuffer = new byte[64];
        var close = await webSocket.ReceiveAsync(closeBuffer, CancellationToken.None).WaitAsync(TestTimeout);
        Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
        if (webSocket.State == WebSocketState.CloseReceived)
        {
            await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "ack", CancellationToken.None);
        }

        await connectionStopped.Task.WaitAsync(TestTimeout);

        Activity connection;
        Activity turn;
        lock (stoppedActivities)
        {
            connection = stoppedActivities.Single(activity => activity.OperationName == "agentserver.connection");
            turn = stoppedActivities.Single(activity => activity.OperationName == "hosted_agent.turn");
        }

        Assert.Multiple(() =>
        {
            Assert.That(turn.TraceId, Is.EqualTo(connection.TraceId));
            Assert.That(turn.ParentSpanId, Is.EqualTo(connection.SpanId));
            Assert.That(customerParent, Is.EqualTo(turn.SpanId));
            Assert.That(customerBaggage.InvocationId, Is.Not.Null.And.Not.Empty);
            Assert.That(customerBaggage.SessionId, Is.Not.Null.And.Not.Empty);
            Assert.That(turn.GetTagItem("gen_ai.response.id"), Is.EqualTo(responseId));
            Assert.That(turn.Tags.Any(tag => tag.Value?.Contains("sensitive transcript", StringComparison.Ordinal) == true), Is.False);
        });
    }

    [Test]
    public async Task DelayedConnectionActivityStillParentsLaterTurn()
    {
        var listenerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseListener = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var connectionStarted = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        var turnStarted = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Name == "agentserver.connection")
                {
                    listenerStarted.TrySetResult();
                    releaseListener.Task.GetAwaiter().GetResult();
                }

                return ActivitySamplingResult.AllDataAndRecorded;
            },
            ActivityStarted = activity =>
            {
                if (activity.OperationName == "agentserver.connection")
                {
                    connectionStarted.TrySetResult(activity);
                }
                else if (activity.OperationName == "hosted_agent.turn")
                {
                    turnStarted.TrySetResult(activity);
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var handler = new NoInputHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        try
        {
            var connectTask = ConnectAndActivateAsync(app);
            await listenerStarted.Task.WaitAsync(TestTimeout);
            using var webSocket = await connectTask.WaitAsync(TestTimeout);

            releaseListener.TrySetResult();
            var connection = await connectionStarted.Task.WaitAsync(TestTimeout);
            var telemetryDrained = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var dispatcher = app.Services.GetRequiredService<TelemetryCallbackDispatcher>();
            Assert.That(dispatcher.TryQueueCritical(telemetryDrained.SetResult), Is.True);
            await telemetryDrained.Task.WaitAsync(TestTimeout);

            await SendAsync(webSocket, """
                {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:01.000Z","item_id":"in_delayed_parent","count":1}
                """);
            using var created = await ReceiveJsonAsync(webSocket);
            using var output = await ReceiveJsonAsync(webSocket);
            using var done = await ReceiveJsonAsync(webSocket);
            var turn = await turnStarted.Task.WaitAsync(TestTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(turn.TraceId, Is.EqualTo(connection.TraceId));
                Assert.That(turn.ParentSpanId, Is.EqualTo(connection.SpanId));
                Assert.That(turn.GetTagItem("azure.ai.agentserver.trace.parent_fallback"), Is.Null);
            });
        }
        finally
        {
            releaseListener.TrySetResult();
        }
    }

    [Test]
    public async Task TurnCreatedWhileConnectionActivityIsPendingUsesExplicitFallback()
    {
        var listenerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseListener = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var turnStopped = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        var fallbackRecorded = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var meterListener = new MeterListener();
        meterListener.InstrumentPublished = (instrument, activeListener) =>
        {
            if (instrument.Name == "azure.ai.agentserver.invocations.voice.trace.parent_fallbacks")
            {
                activeListener.EnableMeasurementEvents(instrument);
            }
        };
        meterListener.SetMeasurementEventCallback<long>((instrument, measurement, tags, state) =>
        {
            var matchingReason = false;
            foreach (var tag in tags)
            {
                if (tag.Key == "reason" &&
                    string.Equals(tag.Value as string, "connection_activity_pending", StringComparison.Ordinal))
                {
                    matchingReason = true;
                    break;
                }
            }

            if (measurement == 1 && matchingReason)
            {
                fallbackRecorded.TrySetResult();
            }
        });
        meterListener.Start();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Name == "agentserver.connection")
                {
                    listenerStarted.TrySetResult();
                    releaseListener.Task.GetAwaiter().GetResult();
                }

                return ActivitySamplingResult.AllDataAndRecorded;
            },
            ActivityStopped = activity =>
            {
                if (activity.OperationName == "hosted_agent.turn")
                {
                    turnStopped.TrySetResult(activity);
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        await using var app = BuildApp(new NoInputHandler());
        await app.StartAsync();
        try
        {
            var connectTask = ConnectAndActivateAsync(app);
            await listenerStarted.Task.WaitAsync(TestTimeout);
            using var webSocket = await connectTask.WaitAsync(TestTimeout);

            await SendAsync(webSocket, """
                {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:01.000Z","item_id":"in_fallback","count":1}
                """);
            using var created = await ReceiveJsonAsync(webSocket);
            using var output = await ReceiveJsonAsync(webSocket);
            using var done = await ReceiveJsonAsync(webSocket);

            releaseListener.TrySetResult();
            var turn = await turnStopped.Task.WaitAsync(TestTimeout);
            await fallbackRecorded.Task.WaitAsync(TestTimeout);
            Assert.That(
                turn.GetTagItem("azure.ai.agentserver.trace.parent_fallback"),
                Is.EqualTo(true));
        }
        finally
        {
            releaseListener.TrySetResult();
        }
    }

    [Test]
    public async Task LateBargeInAfterResponseDoneStillDispatchesPlaybackOutcome()
    {
        var handler = new CompletedResponseBargeInHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "hello"));
        using var created = await ReceiveJsonAsync(webSocket);
        using var output = await ReceiveJsonAsync(webSocket);
        using var done = await ReceiveJsonAsync(webSocket);
        var responseId = created.RootElement.GetProperty("response_id").GetString()!;
        var itemId = output.RootElement.GetProperty("item_id").GetString()!;

        await SendAsync(webSocket, $$"""
            {"type":"barge_in","id":"m_late_barge","ts":"2026-08-03T00:00:03.000Z","response_id":"{{responseId}}","item_id":"{{itemId}}","heard_text":"Hello"}
            """);

        var bargeIn = await handler.BargeIn.Task.WaitAsync(TestTimeout);
        Assert.That(bargeIn.ResponseId, Is.EqualTo(responseId));
    }

    [Test]
    public async Task PreResponseTimeoutCancelsPendingTurnByItemIds()
    {
        var handler = new PendingTurnTimeoutHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, UserMessageFrame("m_user", "in_1", "slow"));
        await handler.TurnStarted.Task.WaitAsync(TestTimeout);
        await SendAsync(webSocket, """
            {"type":"response.timeout","id":"m_timeout","ts":"2026-08-03T00:00:01.000Z","item_ids":["in_1"],"stage":"first_output"}
            """);

        await handler.TurnCancelled.Task.WaitAsync(TestTimeout);
        var timeout = await handler.Timeout.Task.WaitAsync(TestTimeout);
        Assert.That(timeout.ItemIds, Is.EqualTo(new[] { "in_1" }));
    }

    [Test]
    public async Task MissingOptionalTurnCallbackEmitsSanitizedResponseError()
    {
        await using var app = BuildApp(new NoInputCallbackMissingHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"user.no_input","id":"m_no_input","ts":"2026-08-03T00:00:01.000Z","item_id":"in_silence","count":1}
            """);

        using var created = await ReceiveJsonAsync(webSocket);
        using var error = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(created.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.created"));
            Assert.That(error.RootElement.GetProperty("type").GetString(), Is.EqualTo("error"));
            Assert.That(error.RootElement.GetProperty("code").GetString(), Is.EqualTo("handler_error"));
        });
    }

    [Test]
    public async Task HistoryMutationFailureEmitsCorrelatedFailure()
    {
        await using var app = BuildApp(new FailingHistoryHandler());
        await app.StartAsync();
        using var webSocket = await ConnectAndActivateAsync(app);

        await SendAsync(webSocket, """
            {"type":"conversation.item.delete","id":"m_delete","ts":"2026-08-03T00:00:01.000Z","item_id":"hi_1"}
            """);

        using var failure = await ReceiveJsonAsync(webSocket);
        Assert.Multiple(() =>
        {
            Assert.That(failure.RootElement.GetProperty("type").GetString(), Is.EqualTo("conversation.item.failed"));
            Assert.That(failure.RootElement.GetProperty("request_id").GetString(), Is.EqualTo("m_delete"));
            Assert.That(failure.RootElement.GetProperty("message").GetString(), Is.EqualTo("History mutation callback failed"));
        });
    }

    [Test]
    public async Task ReattachCreatesFreshRuntimeAndSurfacesReconnectContext()
    {
        var handler = new ReconnectHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync();

        using (var initial = await ConnectAsync(app))
        {
            await SendAsync(initial, SessionStartFrame("m_initial"));
            using var ready = await ReceiveJsonAsync(initial);
            await initial.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "replace carrier", CancellationToken.None);
        }

        using (var reattached = await ConnectAsync(app))
        {
            await SendAsync(reattached, SessionStartFrame("m_reattach", reconnect: true));
            using var ready = await ReceiveJsonAsync(reattached);
            Assert.That(ready.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
        }

        var activations = await handler.TwoActivations.Task.WaitAsync(TestTimeout);
        Assert.That(activations, Is.EqualTo(new[] { false, true }));
    }

    private static WebApplication BuildApp(VoiceHandler handler)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            Args = new[] { "--hostBuilder:reloadConfigOnChange=false" },
        });
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);

        var app = builder.Build();
        app.UseWebSockets();
        app.MapInvocationsServer();
        return app;
    }

    private static async Task<WebSocket> ConnectAsync(WebApplication app)
    {
        var server = app.GetTestServer();
        var client = server.CreateWebSocketClient();
        return await client.ConnectAsync(new Uri(server.BaseAddress, "invocations_ws"), CancellationToken.None);
    }

    private static async Task<WebSocket> ConnectAndActivateAsync(WebApplication app)
    {
        var webSocket = await ConnectAsync(app);
        await SendAsync(webSocket, SessionStartFrame("m_start"));
        using var ready = await ReceiveJsonAsync(webSocket);
        Assert.That(ready.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
        Assert.That(ready.RootElement.TryGetProperty("protocol_version", out _), Is.False);
        return webSocket;
    }

    private static string SessionStartFrame(string id, bool reconnect = false) => JsonSerializer.Serialize(new
    {
        type = "session.start",
        id,
        ts = "2026-08-03T00:00:00.000Z",
        protocol_version = "1.0",
        reconnect,
        response_timeouts = new
        {
            first_output_ms = 5000,
            idle_ms = 8000,
            max_duration_ms = 60000,
        },
    });

    private static string UserMessageFrame(string id, string itemId, string text) => JsonSerializer.Serialize(new
    {
        type = "user.message",
        id,
        ts = "2026-08-03T00:00:00.000Z",
        item_id = itemId,
        content = new[] { new { type = "input_text", text } },
    });

    private static Task SendAsync(WebSocket webSocket, string json) =>
        webSocket.SendAsync(
            Encoding.UTF8.GetBytes(json),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

    private static async Task<JsonDocument> ReceiveJsonAsync(WebSocket webSocket)
    {
        var receiveTask = ReceiveTextAsync(webSocket);
        var text = await receiveTask.WaitAsync(TestTimeout);
        return JsonDocument.Parse(text);
    }

    private static async Task<string> ReceiveTextAsync(WebSocket webSocket)
    {
        var buffer = new byte[4096];
        using var stream = new MemoryStream();
        while (true)
        {
            var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                throw new AssertionException($"Expected a text frame but received close {(int?)webSocket.CloseStatus}.");
            }

            stream.Write(buffer, 0, result.Count);
            if (result.EndOfMessage)
            {
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }

    private sealed class NoInputHandler : VoiceHandler
    {
        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnUserNoInputAsync(
            VoiceSession session,
            UserNoInputEvent noInput,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.SendTextAsync($"Silence count {noInput.Count}", cancellationToken);
    }

    private sealed class AgentTerminalPhaseHandler : VoiceHandler
    {
        private int _signalCallbackCount;
        private int _historyCallbackCount;
        private int _userMessageCallbackCount;

        public TaskCompletionSource TerminalSent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SessionEnded { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int SignalCallbackCount => Volatile.Read(ref _signalCallbackCount);

        public int HistoryCallbackCount => Volatile.Read(ref _historyCallbackCount);

        public int UserMessageCallbackCount => Volatile.Read(ref _userMessageCallbackCount);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _userMessageCallbackCount);
            await session.EndCallAsync("test_complete", cancellationToken: cancellationToken);
            TerminalSent.TrySetResult();
        }

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _signalCallbackCount);
            return Task.CompletedTask;
        }

        protected override Task OnConversationItemCreateAsync(
            VoiceSession session,
            ConversationItemCreateEvent create,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _historyCallbackCount);
            return Task.CompletedTask;
        }

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            SessionEndEvent sessionEnd,
            CancellationToken cancellationToken)
        {
            SessionEnded.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class SynchronousThrowStartupHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken) =>
            throw new InvalidOperationException("startup exploded synchronously");

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class NullTaskStartupHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken) =>
            null!;

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class ContextCapturingHandler : VoiceHandler
    {
        public TaskCompletionSource<InvocationContext> Context { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            Context.TrySetResult(session.InvocationContext);
            return Task.CompletedTask;
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class BlockingTurnHandler : VoiceHandler
    {
        public TaskCompletionSource TurnStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            TurnStarted.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }
    }

    private abstract class CancellableTurnHandler : VoiceHandler
    {
        public TaskCompletionSource TurnStarted { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TurnCancelled { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource CancellationCallbackRan { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<VoiceResponse> ResponseStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("Hello", cancellationToken);
            ResponseStarted.TrySetResult(response);
            using var registration = response.CancellationToken.Register(() =>
            {
                _ = response.IsTerminal;
                CancellationCallbackRan.TrySetResult();
                throw new InvalidOperationException("Customer cancellation callback failure");
            });
            TurnStarted.TrySetResult();
            try
            {
                await Task.Delay(System.Threading.Timeout.InfiniteTimeSpan, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                TurnCancelled.TrySetResult();
            }
        }
    }

    private sealed class InterruptibleHandler : CancellableTurnHandler
    {
        public TaskCompletionSource<BargeInEvent> BargeIn { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeIn.TrySetResult(bargeIn);
            return Task.CompletedTask;
        }
    }

    private sealed class TimeoutHandler : CancellableTurnHandler
    {
        public TaskCompletionSource<ResponseTimeoutEvent> Timeout { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            ResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            Timeout.TrySetResult(timeout);
            return Task.CompletedTask;
        }
    }

    private sealed class MultiItemHandler : VoiceHandler
    {
        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            var first = response.CreateTextItem();
            await first.SendTextDeltaAsync("Hello ", cancellationToken);
            await first.SendTextDeltaAsync("world", cancellationToken);
            await first.SendTextDoneAsync(cancellationToken);

            var second = response.CreateTextItem();
            await second.SendTextAsync("Second", cancellationToken);

            var third = response.CreateTextItem();
            await third.SendTextAsync(
                "Third",
                new Dictionary<string, object?> { ["rate"] = "+10%" },
                cancellationToken);
        }
    }

    private sealed class EscapedStreamingLimitHandler : VoiceHandler
    {
        public bool SecondDeltaRejected { get; private set; }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync(new string('\0', 100 * 1024), cancellationToken);
            try
            {
                await response.SendTextDeltaAsync(new string('\0', 100 * 1024), cancellationToken);
            }
            catch (ArgumentOutOfRangeException)
            {
                SecondDeltaRejected = true;
            }

            await response.SendTextDoneAsync(cancellationToken);
        }
    }

    private sealed class OversizedFirstOutputHandler : VoiceHandler
    {
        public bool OversizedOutputRejected { get; private set; }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                await response.SendTextAsync(new string('\0', 200 * 1024), cancellationToken);
            }
            catch (ArgumentOutOfRangeException)
            {
                OversizedOutputRejected = true;
            }

            var recoveredItem = response.CreateTextItem();
            await recoveredItem.SendTextAsync("recovered", cancellationToken);
        }
    }

    private sealed class DecliningHandler : VoiceHandler
    {
        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.DeclineAsync("no_reply_needed", cancellationToken);
    }

    private sealed class ProactiveHandler : VoiceHandler
    {
        public TaskCompletionSource<VoiceProactiveResponseDroppedException> ProactiveDropped { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            _ = RunProactiveAsync(session, cancellationToken);
            return Task.CompletedTask;
        }

        private async Task RunProactiveAsync(VoiceSession session, CancellationToken cancellationToken)
        {
            try
            {
                var response = await session.StartProactiveResponseAsync(cancellationToken: cancellationToken);
                await response.SendTextAsync("Proactive update", cancellationToken);
                await response.CompleteAsync(cancellationToken);
            }
            catch (VoiceProactiveResponseDroppedException exception)
            {
                ProactiveDropped.TrySetResult(exception);
            }
        }
    }

    private sealed class ProactiveOrderingHandler : VoiceHandler
    {
        private int _proactiveTerminal;

        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource AllowProactiveCompletion { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource UserTurnStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool UserTurnStartedBeforeProactiveTerminal { get; private set; }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            UserTurnStartedBeforeProactiveTerminal = Volatile.Read(ref _proactiveTerminal) == 0;
            UserTurnStarted.TrySetResult();
            return response.SendTextAsync("later reply", cancellationToken);
        }

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            _ = RunProactiveAsync(session, cancellationToken);
            return Task.CompletedTask;
        }

        private async Task RunProactiveAsync(VoiceSession session, CancellationToken cancellationToken)
        {
            var response = await session.StartProactiveResponseAsync(cancellationToken: cancellationToken);
            ProactiveAccepted.TrySetResult();
            await AllowProactiveCompletion.Task.WaitAsync(cancellationToken);
            await response.SendTextAsync("proactive", cancellationToken);
            await response.CompleteAsync(cancellationToken);
            Volatile.Write(ref _proactiveTerminal, 1);
        }
    }

    private sealed class PendingProactiveTimeoutHandler : VoiceHandler
    {
        public TaskCompletionSource<Exception> AdmissionFailure { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            _ = StartProactiveAsync(session, cancellationToken);
            return Task.CompletedTask;
        }

        private async Task StartProactiveAsync(
            VoiceSession session,
            CancellationToken cancellationToken)
        {
            try
            {
                await session.StartProactiveResponseAsync(cancellationToken: cancellationToken);
            }
            catch (Exception exception) when (exception is VoiceBridgeConnectionClosedException or OperationCanceledException)
            {
                AdmissionFailure.TrySetResult(exception);
            }
        }
    }

    private sealed class SelfCancellingHandler : VoiceHandler
    {
        public TaskCompletionSource<ResponseCancellationOutcome> Outcome { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool IsTerminalAtOutcome { get; private set; }

        public bool IsCancellationRequestedAtOutcome { get; private set; }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("Wrong", cancellationToken);
            var outcome = await response.CancelAsync("self_correction");
            IsTerminalAtOutcome = response.IsTerminal;
            IsCancellationRequestedAtOutcome = response.CancellationToken.IsCancellationRequested;
            Outcome.TrySetResult(outcome);
        }
    }

    private sealed class AbandonedCancelAwaitHandler : VoiceHandler
    {
        public TaskCompletionSource CancelAwait { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource CancelAwaitCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool ResponseWasTerminalAfterAwaitCancellation { get; private set; }

        public bool CancelPendingAtTerminal { get; private set; }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextAsync("safe", cancellationToken);
            _ = response.CancellationToken.Register(() =>
            {
                CancelPendingAtTerminal = response.IsCancelPending;
                TerminalObserved.TrySetResult();
            });
            using var cancelAwaitCancellation = new CancellationTokenSource();
            var cancellationTask = CancelAwait.Task.ContinueWith(
                _ => cancelAwaitCancellation.Cancel(),
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
            try
            {
                await response.CancelAsync("agent_cancel", cancelAwaitCancellation.Token);
            }
            catch (OperationCanceledException) when (cancelAwaitCancellation.IsCancellationRequested)
            {
                ResponseWasTerminalAfterAwaitCancellation = response.IsTerminal;
                CancelAwaitCancelled.TrySetResult();
            }
            finally
            {
                await cancellationTask;
            }
        }
    }

    private sealed class OversizedCancelHandler : VoiceHandler
    {
        public bool CancelRejected { get; private set; }

        public bool CancelPendingAfterFailure { get; private set; }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextAsync("safe", cancellationToken);
            try
            {
                await response.CancelAsync(new string('\0', 200 * 1024), cancellationToken);
            }
            catch (ArgumentOutOfRangeException)
            {
                CancelRejected = true;
            }

            CancelPendingAfterFailure = response.IsCancelPending;
        }
    }

    private sealed class DtmfHandler : VoiceHandler
    {
        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextAsync("Enter digits", cancellationToken);
            _ = await response.CollectDtmfAsync(
                maxDigits: 2,
                initialTimeoutMs: 10000,
                interDigitTimeoutMs: 5000,
                terminator: "#",
                cancellationToken);
        }

        protected override Task OnDtmfCollectedAsync(
            VoiceSession session,
            DtmfCollectedEvent dtmf,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.SendTextAsync($"Received {dtmf.Digits.Length} digits", cancellationToken);
    }

    private sealed class OrderedHistoryHandler : VoiceHandler
    {
        public TaskCompletionSource HistoryStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource AllowHistory { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource UserTurnStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnConversationItemCreateAsync(
            VoiceSession session,
            ConversationItemCreateEvent create,
            CancellationToken cancellationToken)
        {
            HistoryStarted.TrySetResult();
            await AllowHistory.Task.WaitAsync(cancellationToken);
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            UserTurnStarted.TrySetResult();
            return response.SendTextAsync("after history", cancellationToken);
        }
    }

    private sealed class HistoryIdentityHandler : VoiceHandler
    {
        private int _historyCallbackCount;

        public TaskCompletionSource<ConversationItemCreateEvent> HistoryCreated { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int HistoryCallbackCount => Volatile.Read(ref _historyCallbackCount);

        protected override Task OnConversationItemCreateAsync(
            VoiceSession session,
            ConversationItemCreateEvent create,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _historyCallbackCount);
            HistoryCreated.TrySetResult(create);
            return Task.CompletedTask;
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => response.SendTextAsync("anchor", cancellationToken);
    }

    private sealed class DedupeHandler : VoiceHandler
    {
        private int _userMessageCount;

        public int UserMessageCount => Volatile.Read(ref _userMessageCount);

        public TaskCompletionSource AfterDuplicate { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _userMessageCount);
            return response.SendTextAsync("once", cancellationToken);
        }

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            AfterDuplicate.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class SessionEndHandler : VoiceHandler
    {
        public TaskCompletionSource<SessionEndEvent> SessionEnd { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            SessionEndEvent sessionEnd,
            CancellationToken cancellationToken)
        {
            SessionEnd.TrySetResult(sessionEnd);
            return Task.CompletedTask;
        }
    }

    private sealed class BlockingSignalSessionEndHandler : VoiceHandler
    {
        public TaskCompletionSource SignalStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseSignal { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SignalCompleted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<SessionEndEvent> SessionEnd { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override async Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            SignalStarted.TrySetResult();
            await ReleaseSignal.Task;
            SignalCompleted.TrySetResult();
        }

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            SessionEndEvent sessionEnd,
            CancellationToken cancellationToken)
        {
            SessionEnd.TrySetResult(sessionEnd);
            return Task.CompletedTask;
        }
    }

    private sealed class TracingHandler : VoiceHandler
    {
        private static readonly ActivitySource CustomerActivitySource = new("AgentServer.Tests.Customer");

        public TaskCompletionSource<ActivitySpanId> CustomerParent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<(string? InvocationId, string? SessionId)> CustomerBaggage { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            using var customerActivity = CustomerActivitySource.StartActivity("customer.model");
            CustomerParent.TrySetResult(customerActivity!.ParentSpanId);
            CustomerBaggage.TrySetResult((
                customerActivity.GetBaggageItem("azure.ai.agentserver.invocation_id"),
                customerActivity.GetBaggageItem("azure.ai.agentserver.session_id")));
            await response.SendTextAsync("safe reply", cancellationToken);
        }
    }

    private sealed class CompletedResponseBargeInHandler : VoiceHandler
    {
        public TaskCompletionSource<BargeInEvent> BargeIn { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => response.SendTextAsync("Hello", cancellationToken);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeIn.TrySetResult(bargeIn);
            return Task.CompletedTask;
        }
    }

    private sealed class PendingTurnTimeoutHandler : VoiceHandler
    {
        public TaskCompletionSource TurnStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TurnCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<ResponseTimeoutEvent> Timeout { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            TurnStarted.TrySetResult();
            try
            {
                await Task.Delay(System.Threading.Timeout.InfiniteTimeSpan, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                TurnCancelled.TrySetResult();
            }
        }

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            ResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            Timeout.TrySetResult(timeout);
            return Task.CompletedTask;
        }
    }

    private sealed class NoInputCallbackMissingHandler : VoiceHandler
    {
        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class FailingHistoryHandler : VoiceHandler
    {
        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnConversationItemDeleteAsync(
            VoiceSession session,
            ConversationItemDeleteEvent delete,
            CancellationToken cancellationToken) => throw new InvalidOperationException("sensitive failure");
    }

    private sealed class ReconnectHandler : VoiceHandler
    {
        private readonly List<bool> _activations = new();

        public TaskCompletionSource<IReadOnlyList<bool>> TwoActivations { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            lock (_activations)
            {
                _activations.Add(startEvent.Reconnect);
                if (_activations.Count == 2)
                {
                    TwoActivations.TrySetResult(_activations.ToArray());
                }
            }

            return Task.CompletedTask;
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
