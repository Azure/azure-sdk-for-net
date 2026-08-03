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
        Assert.That(
            async () => await handler.UserTurnStarted.Task.WaitAsync(TimeSpan.FromMilliseconds(250)),
            Throws.TypeOf<TimeoutException>());

        handler.AllowProactiveCompletion.TrySetResult();
        using var proactiveOutput = await ReceiveJsonAsync(webSocket);
        using var proactiveDone = await ReceiveJsonAsync(webSocket);
        await handler.UserTurnStarted.Task.WaitAsync(TestTimeout);
        using var replyCreated = await ReceiveJsonAsync(webSocket);
        using var replyOutput = await ReceiveJsonAsync(webSocket);
        using var replyDone = await ReceiveJsonAsync(webSocket);

        Assert.That(replyCreated.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo("in_later"));
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
        Assert.That(
            async () => await ReceiveTextAsync(webSocket).WaitAsync(TimeSpan.FromMilliseconds(250)),
            Throws.TypeOf<TimeoutException>());

        await SendAsync(webSocket, $$"""
            {"type":"response.cancelled","id":"m_cancelled","ts":"2026-08-03T00:00:02.000Z","response_id":"{{responseId}}","item_id":"{{itemId}}","heard_text":"safe"}
            """);
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
            Assert.That(turn.GetTagItem("gen_ai.response.id"), Is.EqualTo(responseId));
            Assert.That(turn.Tags.Any(tag => tag.Value?.Contains("sensitive transcript", StringComparison.Ordinal) == true), Is.False);
        });
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
        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource AllowProactiveCompletion { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource UserTurnStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
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
        }
    }

    private sealed class SelfCancellingHandler : VoiceHandler
    {
        public TaskCompletionSource<ResponseCancellationOutcome> Outcome { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("Wrong", cancellationToken);
            var outcome = await response.CancelAsync("self_correction");
            Outcome.TrySetResult(outcome);
        }
    }

    private sealed class AbandonedCancelAwaitHandler : VoiceHandler
    {
        public TaskCompletionSource CancelAwait { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource CancelAwaitCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextAsync("safe", cancellationToken);
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

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            using var customerActivity = CustomerActivitySource.StartActivity("customer.model");
            CustomerParent.TrySetResult(customerActivity!.ParentSpanId);
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
