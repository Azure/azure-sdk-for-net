// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceConnectionDeadlineTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [TestCase("end_call")]
    [TestCase("error")]
    public async Task AgentTerminalAbortsCarrierWhenBridgeDoesNotClose(string terminalKind)
    {
        using var innerSocket = new BlockingReceiveWebSocket(terminalKind);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var connection = new VoiceConnection(
            webSocket,
            new AgentTerminalHandler(terminalKind),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);

        await runTask.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(innerSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });
    }

    [Test]
    public async Task BlockedResponseDoneAbortsCarrierAndReleasesCallbackWorker()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.done",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var connection = new VoiceConnection(
            webSocket,
            new CompletedResponseHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        try
        {
            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
                Assert.That(innerSocket.State, Is.EqualTo(WebSocketState.Aborted));
            });
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }
    }

    [Test]
    public async Task LaterUserMessageDoesNotCausallyCommitBlockedPriorDone()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.done",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var handler = new CountingCompletedResponseHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "user.message",
                id = "m_later_user",
                ts = "2026-08-03T00:00:02.000Z",
                item_id = "in_later_user",
                content = new[] { new { type = "input_text", text = "later" } },
            }));

            await runTask.WaitAsync(TestTimeout);
            Assert.That(handler.CallbackCount, Is.EqualTo(1));
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }
    }

    [Test]
    public async Task SessionEndAfterAgentTerminalStillInvokesTerminalCallback()
    {
        using var innerSocket = new BlockingReceiveWebSocket("end_call");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new AgentTerminalHandler("end_call");
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:02.000Z",
            reason = "agent_completed",
        }));

        var sessionEnd = await handler.SessionEnded.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);

        Assert.That(sessionEnd.Reason, Is.EqualTo("agent_completed"));
    }

    [Test]
    public async Task BlockingStartupCancellationRegistrationDoesNotStallTeardown()
    {
        using var innerSocket = new BlockingReceiveWebSocket("session.rejected");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var handler = new BlockingStartupCancellationHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await handler.StartupStarted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.CancellationStarted.Task.WaitAsync(TestTimeout);

        try
        {
            await runTask.WaitAsync(TestTimeout);
        }
        finally
        {
            handler.ReleaseCancellation.TrySetResult();
        }
    }

    [Test]
    public async Task CustomerTaskAdmissionOutlivesConnectionCleanupDeadline()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCustomerTasks = 1,
        });
        var handler = new ResistantFirstStartupHandler();
        using var firstCancellation = new CancellationTokenSource();
        using var firstInnerSocket = new BlockingReceiveWebSocket("unused");
        using var firstSocket = new TrackingWebSocket(firstInnerSocket, TimeSpan.FromMilliseconds(50));
        var firstConnection = new VoiceConnection(
            firstSocket,
            handler,
            CreateInvocationContext(),
            governor,
            firstCancellation.Token);
        firstInnerSocket.QueueFrame(SessionStartFrame());
        var firstRun = firstConnection.RunAsync();
        CancellationTokenSource? admittedCancellation = null;
        Task? admittedRun = null;

        try
        {
            await handler.FirstStarted.Task.WaitAsync(TestTimeout);
            await firstCancellation.CancelAsync();
            await ObserveConnectionCancellationAsync(firstRun);
            Assert.Multiple(() =>
            {
                Assert.That(governor.ConnectionCount, Is.Zero);
                Assert.That(governor.CustomerTaskCount, Is.EqualTo(1));
            });

            using var rejectedInnerSocket = new BlockingReceiveWebSocket("session.rejected");
            using var rejectedSocket = new TrackingWebSocket(rejectedInnerSocket, TimeSpan.FromMilliseconds(50));
            var rejectedConnection = new VoiceConnection(
                rejectedSocket,
                handler,
                CreateInvocationContext(),
                governor,
                CancellationToken.None);
            rejectedInnerSocket.QueueFrame(SessionStartFrame());
            var rejectedRun = rejectedConnection.RunAsync();
            await rejectedInnerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
            await rejectedRun.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(handler.StartupCount, Is.EqualTo(1));
                Assert.That(governor.CustomerTaskCount, Is.EqualTo(1));
            });

            handler.ReleaseFirst.TrySetResult();
            await handler.FirstCompleted.Task.WaitAsync(TestTimeout);
            await WaitForCustomerTasksAsync(governor, expected: 0);

            admittedCancellation = new CancellationTokenSource();
            using var admittedInnerSocket = new BlockingReceiveWebSocket("unused");
            using var admittedSocket = new TrackingWebSocket(admittedInnerSocket, TimeSpan.FromMilliseconds(50));
            var admittedConnection = new VoiceConnection(
                admittedSocket,
                handler,
                CreateInvocationContext(),
                governor,
                admittedCancellation.Token);
            admittedInnerSocket.QueueFrame(SessionStartFrame());
            admittedRun = admittedConnection.RunAsync();
            await admittedInnerSocket.ReadySent.Task.WaitAsync(TestTimeout);
            Assert.That(handler.StartupCount, Is.EqualTo(2));
            await admittedCancellation.CancelAsync();
            await ObserveConnectionCancellationAsync(admittedRun);
        }
        finally
        {
            if (admittedCancellation is not null)
            {
                await admittedCancellation.CancelAsync();
            }
            if (admittedRun is not null)
            {
                await ObserveConnectionCancellationAsync(admittedRun);
            }
            admittedCancellation?.Dispose();
            handler.ReleaseFirst.TrySetResult();
            await firstCancellation.CancelAsync();
            await ObserveConnectionCancellationAsync(firstRun);
            if (handler.FirstStarted.Task.IsCompleted)
            {
                await handler.FirstCompleted.Task.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
    }

    [Test]
    public async Task FrameArrivingAfterBridgeObservesReadyIsAccepted()
    {
        using var innerSocket = new BlockingReceiveWebSocket("session.ready", injectFrameDuringReady: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new DuringReadyHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();

        await handler.UserReceived.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:02.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(handler.UserReceived.Task.IsCompleted, Is.True);
            Assert.That(innerSocket.AbortCount, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveAcceptanceAfterBridgeObservesCreatedCompletesBeforeSendContinuation()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectAcceptanceDuringProactiveCreated: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CreatedAcceptanceHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.IdleReady.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        var completedBeforeSendContinuation = false;
        try
        {
            await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
            completedBeforeSendContinuation = true;
        }
        catch (TimeoutException)
        {
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        }

        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await proactiveTask.WaitAsync(TestTimeout);
        await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:02.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(completedBeforeSendContinuation, Is.True);
            Assert.That(innerSocket.AbortCount, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveDropAfterBridgeObservesCreatedCompletesBeforeSendContinuation()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectDropDuringProactiveCreated: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CreatedDropHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame("""
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        await handler.SpeechStarted.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        innerSocket.ExpireProactiveAdmission.TrySetResult();

        var completedBeforeSendContinuation = false;
        VoiceProactiveResponseDroppedException? dropped = null;
        try
        {
            dropped = await handler.ProactiveDropped.Task.WaitAsync(TestTimeout);
            completedBeforeSendContinuation = true;
        }
        catch (TimeoutException)
        {
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        }

        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await proactiveTask.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(completedBeforeSendContinuation, Is.True);
            Assert.That(dropped?.ResponseId, Is.EqualTo(responseId));
            Assert.That(dropped?.Reason, Is.EqualTo("no_barge_safe_window"));
            Assert.That(innerSocket.AbortCount, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveTimeoutBoundsAcceptedCreatedSendThatNeverReturns()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectAcceptanceDuringProactiveCreated: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedAcceptanceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame(firstOutputMs: 1));
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.IdleReady.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.timeout",
            id = "m_timeout",
            ts = "2026-08-03T00:00:03.000Z",
            response_id = responseId,
            stage = "first_output",
        }));
        await handler.TimeoutObserved.Task.WaitAsync(TestTimeout);

        var runCompletedBeforeSendRelease = false;
        try
        {
            await runTask.WaitAsync(TestTimeout);
            runCompletedBeforeSendRelease = true;
            Assert.Multiple(() =>
            {
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        catch (TimeoutException)
        {
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "session.end",
                id = "m_end",
                ts = "2026-08-03T00:00:04.000Z",
                reason = "caller_hangup",
            }));
        }

        await proactiveTask.WaitAsync(TestTimeout);
        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(runCompletedBeforeSendRelease, Is.True);
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveDropBoundsCreatedSendThatNeverReturns()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectDropDuringProactiveCreated: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedDropHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame("""
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        await handler.SpeechStarted.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        innerSocket.ExpireProactiveAdmission.TrySetResult();
        var dropped = await handler.ProactiveDropped.Task.WaitAsync(TestTimeout);

        var runCompletedBeforeSendRelease = false;
        try
        {
            await runTask.WaitAsync(TestTimeout);
            runCompletedBeforeSendRelease = true;
            Assert.Multiple(() =>
            {
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        catch (TimeoutException)
        {
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "session.end",
                id = "m_end",
                ts = "2026-08-03T00:00:03.000Z",
                reason = "caller_hangup",
            }));
        }

        await proactiveTask.WaitAsync(TestTimeout);
        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(runCompletedBeforeSendRelease, Is.True);
            Assert.That(dropped.ResponseId, Is.EqualTo(responseId));
            Assert.That(dropped.Reason, Is.EqualTo("no_barge_safe_window"));
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveAcceptanceBeforeCreatedSendFaultSupervisesUnderlyingSend()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectAcceptanceDuringProactiveCreated: true,
            failProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedAcceptanceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.IdleReady.Task.WaitAsync(TestTimeout);
        await WaitForCleanupTasksAsync(governor, 0);
        var proactiveTask = handler.StartProactiveAsync();
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        VoiceResponse? response = null;
        try
        {
            response = await proactiveTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseId, Is.EqualTo(responseId));
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        }

        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveDropBeforeCreatedSendFaultSupervisesUnderlyingSend()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectDropDuringProactiveCreated: true,
            failProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedDropHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame("""
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        await handler.SpeechStarted.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        innerSocket.ExpireProactiveAdmission.TrySetResult();
        VoiceProactiveResponseDroppedException? dropped = null;
        try
        {
            await proactiveTask.WaitAsync(TestTimeout);
            dropped = await handler.ProactiveDropped.Task.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(dropped.ResponseId, Is.EqualTo(responseId));
                Assert.That(dropped.Reason, Is.EqualTo("no_barge_safe_window"));
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        }

        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveSendFaultAfterRegistrationUsesConnectionTerminal()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            failProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedAcceptanceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.IdleReady.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        Assert.That(governor.PendingOperationCount, Is.EqualTo(1));

        innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        VoiceBridgeConnectionClosedException? failure = null;
        try
        {
            await proactiveTask.WaitAsync(TestTimeout);
        }
        catch (VoiceBridgeConnectionClosedException exception)
        {
            failure = exception;
        }

        await runTask.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(failure?.Message, Is.EqualTo("Voice connection terminated: connection_closed."));
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveSessionEndWhileCreatedSendIsBlockedUsesConnectionTerminal()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            failProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CreatedAcceptanceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame("""
            {"type":"user.speech_started","id":"m_speech","ts":"2026-08-03T00:00:01.000Z"}
            """);
        await handler.SpeechStarted.Task.WaitAsync(TestTimeout);
        var proactiveTask = handler.StartProactiveAsync();
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(governor.PendingOperationCount, Is.EqualTo(1));
            Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
            Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
        });

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:02.000Z",
            reason = "caller_hangup",
        }));

        VoiceBridgeConnectionClosedException? failure = null;
        try
        {
            try
            {
                await proactiveTask.WaitAsync(TestTimeout);
            }
            catch (VoiceBridgeConnectionClosedException exception)
            {
                failure = exception;
            }

            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(failure?.Message, Is.EqualTo("Voice connection terminated: session_end."));
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        }

        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await WaitForResourcesReleasedAsync(governor);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task CallerCancellationDuringBlockedProactiveCreatedKeepsDurableOwner()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            blockProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        try
        {
            await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameCount, Is.EqualTo(1));
                Assert.That(governor.PreparedFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
            await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
            if (!runTask.IsCompleted)
            {
                await runTask.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.ConnectionCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task AcceptedProactiveAfterCallerCancellationIsCompensated()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockProactiveCreatedSend: true,
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.accepted",
            id = "m_accepted",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
        }));
        innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        try
        {
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.cancelled",
                id = "m_cancelled",
                ts = "2026-08-03T00:00:03.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));
            await runTask.WaitAsync(TestTimeout);
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveSendFaultAfterReservationWaitsForAuthoritativeOutcome()
    {
        var outcome = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var arbitration = VoiceConnection.AwaitProactiveSendArbitrationAsync(
            Task.FromException(new VoiceBridgeConnectionClosedException("send failed")),
            outcome.Task,
            static () => true);

        var waitedForOutcome = !arbitration.IsCompleted;
        outcome.TrySetResult();
        Exception? failure = null;
        bool? retainSendTask = null;
        try
        {
            retainSendTask = await arbitration;
        }
        catch (Exception exception)
        {
            failure = exception;
        }

        Assert.Multiple(() =>
        {
            Assert.That(waitedForOutcome, Is.True);
            Assert.That(failure, Is.Null);
            Assert.That(retainSendTask, Is.False);
        });
    }

    [Test]
    public async Task ProactiveOutcomeWinsSimultaneousSendFault()
    {
        var outcome = Task.CompletedTask;
        var sendTask = Task.FromException(new VoiceBridgeConnectionClosedException("send failed"));
        var retainSendTask = await VoiceConnection.AwaitProactiveSendArbitrationAsync(
            sendTask,
            outcome,
            static () => true);

        Assert.That(retainSendTask, Is.True);
        _ = sendTask.Exception;
    }

    [Test]
    public async Task ProactiveSendFaultUsesAuthoritativeConnectionTerminal()
    {
        var sendFailure = new VoiceBridgeConnectionClosedException("send failed");
        var terminalFailure = new VoiceBridgeConnectionClosedException("connection terminal");
        var outcome = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var arbitration = VoiceConnection.AwaitProactiveSendArbitrationAsync(
            Task.FromException(sendFailure),
            outcome.Task,
            static () => true);

        Assert.That(arbitration.IsCompleted, Is.False);
        outcome.TrySetException(terminalFailure);
        Exception? observed = null;
        try
        {
            await arbitration;
        }
        catch (Exception exception)
        {
            observed = exception;
        }

        Assert.That(observed, Is.SameAs(terminalFailure));
    }

    [Test]
    public void ProactiveSendFaultBeforeReservationPropagates()
    {
        var outcome = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        Assert.That(
            async () => await VoiceConnection.AwaitProactiveSendArbitrationAsync(
                Task.FromException(new VoiceBridgeConnectionClosedException("send failed")),
                outcome.Task,
                static () => false),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
    }

    [Test]
    public async Task BargeInAfterBridgeObservesFirstDeltaAcceptsReservedItem()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectBargeInDuringFirstDelta: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new PeerObservedBargeInHandler(innerSocket.InjectedFrameHandled);
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());

        await handler.BargeInObserved.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task ProactiveAcceptanceAfterBridgeObservesDoneCommitsPriorTerminal()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectAcceptanceDuringDone: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new DoneAcceptanceHandler(
            innerSocket.ProactiveResponseCreated.Task,
            innerSocket.InjectedFrameHandled);
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());

        await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:04.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        Assert.That(innerSocket.AbortCount, Is.Zero);
    }

    [Test]
    public async Task ProactiveAcceptanceAfterBridgeObservesNoneCommitsPriorDecline()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            injectAcceptanceDuringDone: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new DeclineAcceptanceHandler(
            innerSocket.ProactiveResponseCreated.Task,
            innerSocket.InjectedFrameHandled);
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());

        await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:04.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        Assert.That(innerSocket.AbortCount, Is.Zero);
    }

    [Test]
    public async Task HandoffFailureAfterBridgeObservesHandoffReleasesPriorTurnBeforeLocalCommit()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "handoff",
            injectHandoffFailureDuringHandoff: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new HandoffRaceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        await WaitForNoActiveResponseAsync(connection).WaitAsync(TestTimeout);

        innerSocket.InjectedFrameHandled.TrySetResult();
        await handler.RecoveryStarted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:04.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        Assert.That(innerSocket.AbortCount, Is.Zero);
    }

    private static async Task WaitForNoActiveResponseAsync(VoiceConnection connection)
    {
        while (await connection.GetActiveResponseIdAsync() is not null)
        {
            await Task.Yield();
        }
    }

    private static async Task WaitForResourcesReleasedAsync(VoiceResourceGovernor governor)
    {
        using var timeout = new CancellationTokenSource(TestTimeout);
        while (governor.ConnectionCount != 0 ||
            governor.CustomerTaskCount != 0 ||
            governor.TerminalCustomerTaskCount != 0 ||
            governor.CleanupTaskCount != 0 ||
            governor.PendingOperationCount != 0 ||
            governor.PreparedFrameCount != 0 ||
            governor.PreparedFrameBytes != 0 ||
            governor.ControlFrameCount != 0 ||
            governor.ControlFrameBytes != 0 ||
            governor.CallbackQueueItems != 0 ||
            governor.CallbackQueueBytes != 0 ||
            governor.TrackedIdentityBytes != 0 ||
            governor.RetainedOutputBytes != 0 ||
            governor.RetainedOutputItems != 0 ||
            governor.RetainedOutputChunks != 0 ||
            governor.OutputWriteCount != 0 ||
            governor.EncodedOutputBytes != 0 ||
            governor.TerminalEncodedOutputBytes != 0)
        {
            if (timeout.IsCancellationRequested)
            {
                throw new TimeoutException("Voice resources were not released.");
            }

            await Task.Yield();
        }
    }

    private static async Task WaitForPendingOperationsAsync(
        VoiceResourceGovernor governor,
        long expected)
    {
        using var timeout = new CancellationTokenSource(TestTimeout);
        while (governor.PendingOperationCount != expected)
        {
            if (timeout.IsCancellationRequested)
            {
                throw new TimeoutException($"Pending operation count did not reach {expected}.");
            }

            await Task.Yield();
        }
    }

    private static async Task WaitForCleanupTasksAsync(
        VoiceResourceGovernor governor,
        long expected)
    {
        using var timeout = new CancellationTokenSource(TestTimeout);
        while (governor.CleanupTaskCount != expected)
        {
            if (timeout.IsCancellationRequested)
            {
                throw new TimeoutException($"Cleanup task count did not reach {expected}.");
            }

            await Task.Yield();
        }
    }

    private static async Task WaitForCustomerTasksAsync(
        VoiceResourceGovernor governor,
        long expected)
    {
        using var timeout = new CancellationTokenSource(TestTimeout);
        while (governor.CustomerTaskCount != expected)
        {
            if (timeout.IsCancellationRequested)
            {
                throw new TimeoutException($"Customer task count did not reach {expected}.");
            }

            await Task.Yield();
        }
    }

    private static async Task ObserveConnectionCancellationAsync(Task runTask)
    {
        try
        {
            await runTask.WaitAsync(TestTimeout);
        }
        catch (OperationCanceledException)
        {
        }
    }

    private static async Task ReleaseBlockedTerminalSendAsync(BlockingReceiveWebSocket innerSocket)
    {
        innerSocket.ReleaseTerminalSend.TrySetResult();
        await innerSocket.TerminalSendCompleted.Task.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task BlockedSessionRejectionIsAbortedByCleanupDeadline()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "session.rejected",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(UserMessageFrame());
        var runTask = connection.RunAsync();
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            await runTask.WaitAsync(TestTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
                Assert.That(innerSocket.State, Is.EqualTo(WebSocketState.Aborted));
            });
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }
    }

    [Test]
    public async Task CancelledProactiveAdmissionAcceptedThenTimedOutReleasesAbandonedIdentity()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.accepted",
            id = "m_accepted",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
        }));
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.timeout",
            id = "m_timeout",
            ts = "2026-08-03T00:00:03.000Z",
            response_id = responseId,
            stage = "first_output",
        }));

        await handler.TimeoutObserved.Task.WaitAsync(TestTimeout);
        Assert.That(await connection.GetAbandonedProactiveCancelCountAsync(), Is.Zero);

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:04.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task CancelledProactiveAdmissionDoesNotWaitForBlockedCompensation()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(governor.PendingOperationCount, Is.EqualTo(1));
                Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
            });

            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.dropped",
                id = "m_dropped",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                reason = "cancelled_by_agent",
            }));

            await runTask.WaitAsync(TestTimeout);
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
            if (!runTask.IsCompleted)
            {
                innerSocket.QueueFrame(JsonSerializer.Serialize(new
                {
                    type = "response.dropped",
                    id = "m_cleanup_drop",
                    ts = "2026-08-03T00:00:03.000Z",
                    response_id = responseId,
                    reason = "cancelled_by_agent",
                }));
                await runTask.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
        var abandonedCancelCount = await connection.GetAbandonedProactiveCancelCountAsync();
        Assert.Multiple(() =>
        {
            Assert.That(abandonedCancelCount, Is.Zero);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveCompensationDeadlineClosesUnresponsiveCarrier()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
                Assert.That(governor.ControlFrameCount, Is.EqualTo(1));
                Assert.That(governor.ControlFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }

        await WaitForResourcesReleasedAsync(governor);
        var abandonedCancelCount = await connection.GetAbandonedProactiveCancelCountAsync();
        Assert.Multiple(() =>
        {
            Assert.That(abandonedCancelCount, Is.Zero);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
            Assert.That(governor.ControlFrameCount, Is.Zero);
            Assert.That(governor.ControlFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ProactiveCompensationDoesNotStartWithoutCleanupAdmission()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCleanupTasks = 1,
        });
        using var occupiedCleanup = governor.AcquireCleanupTask();
        using var innerSocket = new BlockingReceiveWebSocket("response.cancel");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        Assert.That(innerSocket.TerminalSendStarted.Task.IsCompleted, Is.False);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.dropped",
            id = "m_dropped",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
            reason = "no_barge_safe_window",
        }));
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        occupiedCleanup.Dispose();
        await WaitForResourcesReleasedAsync(governor);
        Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
    }

    [Test]
    public async Task FaultedProactiveCleanupOwnerDoesNotSkipStructuralRelease()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxControlFrames = 1,
            MaxControlFrameBytes = VoiceProtocolConstants.MaxFrameBytes,
        });
        using var innerSocket = new BlockingReceiveWebSocket("response.cancel");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
        using var occupiedControl = governor.AcquirePreparedFrames(
            frameCount: 1,
            reservedBytes: VoiceProtocolConstants.MaxFrameBytes,
            control: true);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.dropped",
            id = "m_dropped",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
            reason = "no_barge_safe_window",
        }));
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);

        occupiedControl.Dispose();
        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(governor.ControlFrameCount, Is.Zero);
            Assert.That(governor.ControlFrameBytes, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.TrackedIdentityBytes, Is.Zero);
        });
    }

    [Test]
    public async Task PlaybackOutcomeConsumesTrackedIdentityBudget()
    {
        using var innerSocket = new BlockingReceiveWebSocket("response.done");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new PlaybackOutcomeHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
        var beforeOutcome = connection.TrackedIdentityBytes;

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "barge_in",
            id = "m_barge",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
            heard_text = string.Empty,
        }));
        await handler.BargeInObserved.Task.WaitAsync(TestTimeout);

        Assert.That(
            connection.TrackedIdentityBytes - beforeOutcome,
            Is.EqualTo(384),
            "The inbound message digest and playback outcome identity must both be budgeted.");

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task InvalidUtf8TextFrameIsRejectedAsProtocolError()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrameBytes(new byte[] { 0xC3, 0x28 });

        await runTask.WaitAsync(TestTimeout);
        Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(VoiceProtocolConstants.CloseProtocolError));
    }

    [Test]
    public async Task RequestCancellationEscapesWithOriginalTokenAndSelectsAbnormalClosure()
    {
        using var requestCancellation = new CancellationTokenSource();
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            requestCancellation.Token);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        await requestCancellation.CancelAsync();

        var exception = Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await runTask.WaitAsync(TestTimeout));
        Assert.Multiple(() =>
        {
            Assert.That(exception!.CancellationToken, Is.EqualTo(requestCancellation.Token));
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(1006));
        });
    }

    [Test]
    public async Task BargeInDuringBlockedCancelWriteReturnsAuthoritativeOutcome()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CancelRaceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "barge_in",
                id = "m_barge",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));

            var outcome = await handler.Outcome.Task.WaitAsync(TestTimeout);
            Assert.That(outcome.Kind, Is.EqualTo("barge_in"));

            await runTask.WaitAsync(TestTimeout);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }
    }

    [Test]
    public async Task TerminalBeforeCancelWaiterRegistrationRollsBackOwner()
    {
        using var innerSocket = new BlockingReceiveWebSocket("response.cancel");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var governor = new VoiceResourceGovernor();
        var handler = new TerminalBeforeCancelRegistrationHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);
        var terminationCoordinator = (VoiceTerminationCoordinator)typeof(VoiceConnection).GetField(
            "_termination",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
            .GetValue(connection)!;
        var rememberResponse = typeof(VoiceConnection).GetMethod(
            "RememberResponseLocked",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!;

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        Task<Task<ResponseCancellationOutcome>>? beginCancel = null;
        Task<ResponseCancellationOutcome>? outcome = null;
        VoiceResponseTermination termination = default;
        try
        {
            await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
            innerSocket.QueueFrame(UserMessageFrame());
            var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
            var response = await handler.ResponseReady.Task.WaitAsync(TestTimeout);
            response.ReserveCancellation();
            termination = terminationCoordinator.TryTerminateResponse(response, "barge_in");
            rememberResponse.Invoke(connection, new object[] { response });

            beginCancel = connection.BeginCancelAsync(response, reason: null, CancellationToken.None);
            Assert.That(
                async () => await beginCancel.WaitAsync(TimeSpan.FromSeconds(1)),
                Throws.TypeOf<VoiceBridgeConnectionClosedException>());
            Assert.Multiple(() =>
            {
                Assert.That(innerSocket.TerminalSendStarted.Task.IsCompleted, Is.False);
                Assert.That(innerSocket.AbortCount, Is.Zero);
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(response.IsCancelPending, Is.False);
            });
        }
        finally
        {
            if (termination.IsNewTerminal)
            {
                var response = await handler.ResponseReady.Task.WaitAsync(TestTimeout);
                await response.MarkTerminalAsync();
                await VoiceTerminationCoordinator.ApplyResponseTermination(termination);
            }
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "session.end",
                id = "m_end",
                ts = "2026-08-03T00:00:03.000Z",
                reason = "caller_hangup",
            }));
            await runTask.WaitAsync(TestTimeout);
            if (beginCancel is not null)
            {
                try
                {
                    outcome = await beginCancel.WaitAsync(TestTimeout);
                }
                catch
                {
                    _ = beginCancel.Exception;
                }
            }
            if (outcome is not null)
            {
                try
                {
                    await outcome.WaitAsync(TestTimeout);
                }
                catch
                {
                    _ = outcome.Exception;
                }
            }
        }

        await WaitForResourcesReleasedAsync(governor);
    }

    [Test]
    public async Task CancelledDuringBlockedCancelWriteReturnsAuthoritativeOutcome()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CancelRaceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        try
        {
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.cancelled",
                id = "m_cancelled",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));

            var outcome = await handler.Outcome.Task.WaitAsync(TestTimeout);
            Assert.That(outcome.Kind, Is.EqualTo("cancelled"));

            await runTask.WaitAsync(TestTimeout);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }
    }

    [Test]
    public async Task CallerCancellationDuringBlockedCancelWriteKeepsDurableArbitration()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CallerCancelledCancelHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        try
        {
            handler.CancelAwait();
            await handler.CancelAwaitCancelled.Task.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(handler.CancellationTokenPreserved, Is.True);
                Assert.That(handler.ResponseWasTerminalAfterAwaitCancellation, Is.False);
                Assert.That(handler.CancelPendingAfterAwaitCancellation, Is.True);
                Assert.That(governor.PendingOperationCount, Is.EqualTo(1));
            });

            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.cancelled",
                id = "m_cancelled",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));

            await handler.TerminalObserved.Task.WaitAsync(TestTimeout);
            await runTask.WaitAsync(TestTimeout);
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
            if (!runTask.IsCompleted)
            {
                innerSocket.QueueFrame(JsonSerializer.Serialize(new
                {
                    type = "session.end",
                    id = "m_end",
                    ts = "2026-08-03T00:00:03.000Z",
                    reason = "caller_hangup",
                }));
                await runTask.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(handler.CancelPendingAtTerminal, Is.False);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task CancelSendFaultWaitsForAuthoritativeConnectionTerminal()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true,
            failTerminalSendAfterRelease: true,
            holdReceiveFailureAfterAbort: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelFailureHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        try
        {
            innerSocket.ReleaseTerminalSend.TrySetResult();
            await innerSocket.ReceiveFailureHeld.Task.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(handler.Failure.Task.IsCompleted, Is.False);
                Assert.That(governor.PendingOperationCount, Is.EqualTo(1));
            });

            innerSocket.ReleaseReceiveFailure.TrySetResult();
            var failure = await handler.Failure.Task.WaitAsync(TestTimeout);
            await runTask.WaitAsync(TestTimeout);

            Assert.That(failure.Message, Is.EqualTo("Voice connection terminated: connection_closed."));
        }
        finally
        {
            innerSocket.ReleaseTerminalSend.TrySetResult();
            innerSocket.ReleaseReceiveFailure.TrySetResult();
            await innerSocket.TerminalSendCompleted.Task.WaitAsync(TestTimeout);
            if (!runTask.IsCompleted)
            {
                await runTask.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task CancelSendDeadlineClosesUnresponsiveCarrier()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelFailureHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);

        try
        {
            var failure = await handler.Failure.Task.WaitAsync(TestTimeout);
            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(failure.Message, Is.EqualTo("Voice connection terminated: connection_closed."));
                Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(governor.ControlFrameCount, Is.EqualTo(1));
                Assert.That(governor.ControlFrameBytes, Is.GreaterThan(0));
            });
        }
        finally
        {
            await ReleaseBlockedTerminalSendAsync(innerSocket);
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(governor.CleanupTaskCount, Is.Zero);
            Assert.That(governor.ControlFrameCount, Is.Zero);
            Assert.That(governor.ControlFrameBytes, Is.Zero);
        });
    }

    [Test]
    public async Task BargeInWhileCancelWaitsForSendGateCompletesRegisteredWaiter()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            blockProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelBehindProactiveSendHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        var proactiveResponseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.StartCancel();
        await WaitForPendingOperationsAsync(governor, expected: 2);
        try
        {
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "barge_in",
                id = "m_barge",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.accepted",
                id = "m_accepted",
                ts = "2026-08-03T00:00:03.000Z",
                response_id = proactiveResponseId,
            }));

            var outcome = await handler.Outcome.Task.WaitAsync(TestTimeout);
            await handler.ProactiveAccepted.Task.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(outcome.ResponseId, Is.EqualTo(responseId));
                Assert.That(outcome.Kind, Is.EqualTo("barge_in"));
                Assert.That(governor.PendingOperationCount, Is.Zero);
                Assert.That(innerSocket.TerminalSendStarted.Task.IsCompleted, Is.False);
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
            await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "session.end",
                id = "m_end",
                ts = "2026-08-03T00:00:04.000Z",
                reason = "caller_hangup",
            }));
            await runTask.WaitAsync(TestTimeout);
        }

        await WaitForResourcesReleasedAsync(governor);
    }

    [Test]
    public async Task CancelDeadlineBehindSendGateUsesConnectionTerminal()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "unused",
            blockProactiveCreatedSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var governor = new VoiceResourceGovernor();
        var handler = new CancelDeadlineBehindProactiveHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.StartCancel();
        try
        {
            var failure = await handler.Failure.Task.WaitAsync(TestTimeout);
            await runTask.WaitAsync(TestTimeout);
            Assert.Multiple(() =>
            {
                Assert.That(failure.Message, Is.EqualTo("Voice connection terminated: connection_closed."));
                Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
                Assert.That(governor.PendingOperationCount, Is.Zero);
            });
        }
        finally
        {
            innerSocket.ReleaseProactiveCreatedSend.TrySetResult();
            await innerSocket.ProactiveCreatedSendCompleted.Task.WaitAsync(TestTimeout);
            if (!runTask.IsCompleted)
            {
                await runTask.WaitAsync(TestTimeout);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
    }

    [Test]
    public async Task PlaybackTerminalFailureKeepsCancelWaiterDiscoverableForFailAll()
    {
        var limits = new VoiceResourceLimits
        {
            MaxTrackedIdentityBytes = 1024 * 1024,
        };
        var governor = new VoiceResourceGovernor(limits);
        using var innerSocket = new BlockingReceiveWebSocket("response.cancel");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(100));
        var handler = new CancelFailureHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            governor,
            CancellationToken.None);
        long externalReservation = 0;

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
        Assert.That(governor.PendingOperationCount, Is.EqualTo(1));

        try
        {
            externalReservation = limits.MaxTrackedIdentityBytes - governor.TrackedIdentityBytes - 128;
            governor.ReserveIdentityBytes(checked((int)externalReservation));
            innerSocket.QueueFrame(JsonSerializer.Serialize(new
            {
                type = "response.cancelled",
                id = "m_cancelled",
                ts = "2026-08-03T00:00:02.000Z",
                response_id = responseId,
                heard_text = string.Empty,
            }));

            var failure = await handler.Failure.Task.WaitAsync(TestTimeout);
            Assert.That(failure.Message, Is.EqualTo("Voice connection terminated: internal_error."));
            Assert.That(
                async () => await runTask.WaitAsync(TestTimeout),
                Throws.TypeOf<VoiceResourceExhaustedException>());
        }
        finally
        {
            if (externalReservation > 0)
            {
                governor.ReleaseIdentityBytes(externalReservation);
            }
        }

        await WaitForResourcesReleasedAsync(governor);
        Assert.Multiple(() =>
        {
            Assert.That(governor.PendingOperationCount, Is.Zero);
            Assert.That(governor.TrackedIdentityBytes, Is.Zero);
        });
    }

    [Test]
    public async Task UnexpectedRuntimeFailureEscapesAfterSelectingInternalError()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueReceiveException(new InvalidOperationException("runtime failed"));

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await runTask.WaitAsync(TestTimeout));
        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Is.EqualTo("runtime failed"));
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(VoiceProtocolConstants.CloseInternalError));
        });
    }

    [Test]
    public async Task CompletedSignalFailureRemainsFailureDuringSessionEndRace()
    {
        var failed = await VoiceConnection.ObserveSignalCallbackAsync(
            Task.FromException(new InvalidOperationException("callback failed")),
            CancellationToken.None);

        Assert.That(failed, Is.True);
    }

    private static string SessionStartFrame(int firstOutputMs = 5000) => JsonSerializer.Serialize(new
    {
        type = "session.start",
        id = "m_start",
        ts = "2026-08-03T00:00:00.000Z",
        protocol_version = "1.0",
        reconnect = false,
        response_timeouts = new
        {
            first_output_ms = firstOutputMs,
            idle_ms = 8000,
            max_duration_ms = 60000,
        },
    });

    private static InvocationContext CreateInvocationContext() => new(
        "test-invocation",
        "test-session",
        new Dictionary<string, string>(),
        new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
        Azure.AI.AgentServer.Core.PlatformContext.Empty);

    private static string UserMessageFrame() => JsonSerializer.Serialize(new
    {
        type = "user.message",
        id = "m_user",
        ts = "2026-08-03T00:00:01.000Z",
        item_id = "in_user",
        content = new[] { new { type = "input_text", text = "terminal" } },
    });

    private sealed class AgentTerminalHandler : VoiceHandler
    {
        private readonly string _terminalKind;

        public AgentTerminalHandler(string terminalKind)
        {
            _terminalKind = terminalKind;
        }

        public TaskCompletionSource<SessionEndEvent> SessionEnded { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            _terminalKind == "end_call"
                ? session.EndCallAsync("test_complete", cancellationToken: cancellationToken)
                : session.ReportErrorAsync("test_error", "Safe test error", cancellationToken);

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            SessionEndEvent sessionEnd,
            CancellationToken cancellationToken)
        {
            SessionEnded.TrySetResult(sessionEnd);
            return Task.CompletedTask;
        }
    }

    private sealed class CompletedResponseHandler : VoiceHandler
    {
        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.SendTextAsync("complete", cancellationToken);
    }

    private sealed class CountingCompletedResponseHandler : VoiceHandler
    {
        private int _callbackCount;

        public int CallbackCount => Volatile.Read(ref _callbackCount);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _callbackCount);
            return response.SendTextAsync("complete", cancellationToken);
        }
    }

    private sealed class BlockingStartupCancellationHandler : VoiceHandler
    {
        private readonly TaskCompletionSource _startupCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource StartupStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource CancellationStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseCancellation { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            _ = cancellationToken.Register(() =>
            {
                CancellationStarted.TrySetResult();
                ReleaseCancellation.Task.GetAwaiter().GetResult();
                _startupCompletion.TrySetResult();
            });
            StartupStarted.TrySetResult();
            return _startupCompletion.Task;
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class ResistantFirstStartupHandler : VoiceHandler
    {
        private int _startupCount;

        public TaskCompletionSource FirstStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseFirst { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource FirstCompleted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int StartupCount => Volatile.Read(ref _startupCount);

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            if (Interlocked.Increment(ref _startupCount) != 1)
            {
                return;
            }

            FirstStarted.TrySetResult();
            try
            {
                await ReleaseFirst.Task;
            }
            finally
            {
                FirstCompleted.TrySetResult();
            }
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class DuringReadyHandler : VoiceHandler
    {
        public TaskCompletionSource UserReceived { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            UserReceived.TrySetResult();
            return response.SendTextAsync("ready", cancellationToken);
        }
    }

    private sealed class PeerObservedBargeInHandler : VoiceHandler
    {
        private readonly TaskCompletionSource _injectedFrameHandled;

        public PeerObservedBargeInHandler(TaskCompletionSource injectedFrameHandled)
        {
            _injectedFrameHandled = injectedFrameHandled;
        }

        public TaskCompletionSource BargeInObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.SendTextDeltaAsync("hello", cancellationToken);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeInObserved.TrySetResult();
            _injectedFrameHandled.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class CreatedAcceptanceHandler : VoiceHandler
    {
        private VoiceSession? _session;

        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TimeoutObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource IdleReady { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SpeechStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task<VoiceResponse> StartProactiveAsync()
        {
            var response = await _session!.StartProactiveResponseAsync(cancellationToken: CancellationToken.None);
            ProactiveAccepted.TrySetResult();
            return response;
        }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            _session = session;
            return Task.CompletedTask;
        }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.DeclineAsync(cancellationToken: cancellationToken);
            IdleReady.TrySetResult();
        }

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            ResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            TimeoutObserved.TrySetResult();
            return Task.CompletedTask;
        }

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            SpeechStarted.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class CreatedDropHandler : VoiceHandler
    {
        private VoiceSession? _session;

        public TaskCompletionSource<VoiceProactiveResponseDroppedException> ProactiveDropped { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SpeechStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task StartProactiveAsync()
        {
            try
            {
                await _session!.StartProactiveResponseAsync(
                    admissionTimeoutMs: 1,
                    cancellationToken: CancellationToken.None);
            }
            catch (VoiceProactiveResponseDroppedException exception)
            {
                ProactiveDropped.TrySetResult(exception);
            }
        }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            _session = session;
            return Task.CompletedTask;
        }

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
            SpeechStarted.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class DoneAcceptanceHandler : VoiceHandler
    {
        private readonly Task<string> _proactiveCreated;
        private readonly TaskCompletionSource _injectedFrameHandled;

        public DoneAcceptanceHandler(
            Task<string> proactiveCreated,
            TaskCompletionSource injectedFrameHandled)
        {
            _proactiveCreated = proactiveCreated;
            _injectedFrameHandled = injectedFrameHandled;
        }

        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            _ = AwaitProactiveAsync(session, cancellationToken);
            await _proactiveCreated.WaitAsync(cancellationToken);
            await response.SendTextAsync("active response", cancellationToken);
        }

        private async Task AwaitProactiveAsync(VoiceSession session, CancellationToken cancellationToken)
        {
            _ = cancellationToken;
            await session.StartProactiveResponseAsync(cancellationToken: CancellationToken.None);
            ProactiveAccepted.TrySetResult();
            _injectedFrameHandled.TrySetResult();
        }
    }

    private sealed class DeclineAcceptanceHandler : VoiceHandler
    {
        private readonly Task<string> _proactiveCreated;
        private readonly TaskCompletionSource _injectedFrameHandled;

        public DeclineAcceptanceHandler(
            Task<string> proactiveCreated,
            TaskCompletionSource injectedFrameHandled)
        {
            _proactiveCreated = proactiveCreated;
            _injectedFrameHandled = injectedFrameHandled;
        }

        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            _ = AwaitProactiveAsync(session);
            await _proactiveCreated.WaitAsync(cancellationToken);
            await response.DeclineAsync("no_reply_needed", cancellationToken);
        }

        private async Task AwaitProactiveAsync(VoiceSession session)
        {
            await session.StartProactiveResponseAsync(cancellationToken: CancellationToken.None);
            ProactiveAccepted.TrySetResult();
            _injectedFrameHandled.TrySetResult();
        }
    }

    private sealed class HandoffRaceHandler : VoiceHandler
    {
        public TaskCompletionSource RecoveryStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            response.HandoffAsync("target-agent", cancellationToken: cancellationToken);

        protected override Task OnHandoffFailedAsync(
            VoiceSession session,
            HandoffFailedEvent failure,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            RecoveryStarted.TrySetResult();
            return response.SendTextAsync("recovered", cancellationToken);
        }
    }

    private sealed class CancelledProactiveHandler : VoiceHandler
    {
        private readonly CancellationTokenSource _admissionCancellation = new();

        public TaskCompletionSource AdmissionCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TimeoutObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public void CancelAdmission() => _admissionCancellation.Cancel();

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
            _ = StartProactiveAsync(session);
            return Task.CompletedTask;
        }

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            ResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            TimeoutObserved.TrySetResult();
            return Task.CompletedTask;
        }

        private async Task StartProactiveAsync(VoiceSession session)
        {
            try
            {
                await session.StartProactiveResponseAsync(
                    admissionTimeoutMs: 1,
                    cancellationToken: _admissionCancellation.Token);
            }
            catch (OperationCanceledException) when (_admissionCancellation.IsCancellationRequested)
            {
                AdmissionCancelled.TrySetResult();
            }
        }
    }

    private sealed class PlaybackOutcomeHandler : VoiceHandler
    {
        public TaskCompletionSource BargeInObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => response.SendTextAsync("ready", cancellationToken);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeInObserved.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class CancelRaceHandler : VoiceHandler
    {
        public TaskCompletionSource<ResponseCancellationOutcome> Outcome { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            var outcome = await response.CancelAsync(cancellationToken: CancellationToken.None);
            Outcome.TrySetResult(outcome);
        }
    }

    private sealed class TerminalBeforeCancelRegistrationHandler : VoiceHandler
    {
        public TaskCompletionSource<VoiceResponse> ResponseReady { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource BargeInObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            ResponseReady.TrySetResult(response);
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeInObserved.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class CallerCancelledCancelHandler : VoiceHandler
    {
        private readonly CancellationTokenSource _cancelAwait = new();

        public TaskCompletionSource CancelAwaitCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool CancellationTokenPreserved { get; private set; }

        public bool ResponseWasTerminalAfterAwaitCancellation { get; private set; }

        public bool CancelPendingAfterAwaitCancellation { get; private set; }

        public bool CancelPendingAtTerminal { get; private set; }

        public void CancelAwait() => _cancelAwait.Cancel();

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            _ = response.CancellationToken.Register(() =>
            {
                CancelPendingAtTerminal = response.IsCancelPending;
                TerminalObserved.TrySetResult();
            });

            try
            {
                await response.CancelAsync(cancellationToken: _cancelAwait.Token);
            }
            catch (OperationCanceledException exception) when (_cancelAwait.IsCancellationRequested)
            {
                CancellationTokenPreserved = exception.CancellationToken == _cancelAwait.Token;
                ResponseWasTerminalAfterAwaitCancellation = response.IsTerminal;
                CancelPendingAfterAwaitCancellation = response.IsCancelPending;
                CancelAwaitCancelled.TrySetResult();
            }
        }
    }

    private sealed class CancelFailureHandler : VoiceHandler
    {
        public TaskCompletionSource<VoiceBridgeConnectionClosedException> Failure { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            try
            {
                await response.CancelAsync(cancellationToken: CancellationToken.None);
            }
            catch (VoiceBridgeConnectionClosedException exception)
            {
                Failure.TrySetResult(exception);
            }
        }
    }

    private sealed class CancelBehindProactiveSendHandler : VoiceHandler
    {
        private readonly TaskCompletionSource _startCancel =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<ResponseCancellationOutcome> Outcome { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ProactiveAccepted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public void StartCancel() => _startCancel.TrySetResult();

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            var proactiveTask = StartProactiveAsync(session);
            await _startCancel.Task.WaitAsync(cancellationToken);
            var outcome = await response.CancelAsync(cancellationToken: CancellationToken.None);
            Outcome.TrySetResult(outcome);
            await proactiveTask;
        }

        private async Task StartProactiveAsync(VoiceSession session)
        {
            await session.StartProactiveResponseAsync(cancellationToken: CancellationToken.None);
            ProactiveAccepted.TrySetResult();
        }
    }

    private sealed class CancelDeadlineBehindProactiveHandler : VoiceHandler
    {
        private readonly TaskCompletionSource _startCancel =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<VoiceBridgeConnectionClosedException> Failure { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public void StartCancel() => _startCancel.TrySetResult();

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            _ = ObserveProactiveAsync(session);
            await _startCancel.Task.WaitAsync(cancellationToken);
            try
            {
                await response.CancelAsync(cancellationToken: CancellationToken.None);
            }
            catch (VoiceBridgeConnectionClosedException exception)
            {
                Failure.TrySetResult(exception);
            }
        }

        private static async Task ObserveProactiveAsync(VoiceSession session)
        {
            try
            {
                await session.StartProactiveResponseAsync(cancellationToken: CancellationToken.None);
            }
            catch (VoiceBridgeConnectionClosedException)
            {
            }
        }
    }

    private sealed class BlockingReceiveWebSocket : WebSocket
    {
        private readonly Channel<byte[]> _inbound = Channel.CreateUnbounded<byte[]>();
        private readonly string _terminalKind;
        private readonly bool _injectFrameDuringReady;
        private readonly bool _injectBargeInDuringFirstDelta;
        private readonly bool _injectAcceptanceDuringDone;
        private readonly bool _injectAcceptanceDuringProactiveCreated;
        private readonly bool _injectDropDuringProactiveCreated;
        private readonly bool _failProactiveCreatedSend;
        private readonly bool _blockProactiveCreatedSend;
        private readonly bool _injectHandoffFailureDuringHandoff;
        private readonly bool _blockTerminalSend;
        private readonly bool _failTerminalSendAfterRelease;
        private readonly bool _holdReceiveFailureAfterAbort;
        private readonly TaskCompletionSource _injectedFrameRead =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private WebSocketState _state = WebSocketState.Open;
        private Exception? _receiveException;
        private string? _pendingProactiveResponseId;
        private int _abortCount;
        private int _injectedFrameQueued;
        private int _bargeInInjected;
        private int _acceptanceInjected;

        public BlockingReceiveWebSocket(
            string terminalKind,
            bool injectFrameDuringReady = false,
            bool injectBargeInDuringFirstDelta = false,
            bool injectAcceptanceDuringDone = false,
            bool injectAcceptanceDuringProactiveCreated = false,
            bool injectDropDuringProactiveCreated = false,
            bool failProactiveCreatedSend = false,
            bool blockProactiveCreatedSend = false,
            bool injectHandoffFailureDuringHandoff = false,
            bool blockTerminalSend = false,
            bool failTerminalSendAfterRelease = false,
            bool holdReceiveFailureAfterAbort = false)
        {
            _terminalKind = terminalKind;
            _injectFrameDuringReady = injectFrameDuringReady;
            _injectBargeInDuringFirstDelta = injectBargeInDuringFirstDelta;
            _injectAcceptanceDuringDone = injectAcceptanceDuringDone;
            _injectAcceptanceDuringProactiveCreated = injectAcceptanceDuringProactiveCreated;
            _injectDropDuringProactiveCreated = injectDropDuringProactiveCreated;
            _failProactiveCreatedSend = failProactiveCreatedSend;
            _blockProactiveCreatedSend = blockProactiveCreatedSend;
            _injectHandoffFailureDuringHandoff = injectHandoffFailureDuringHandoff;
            _blockTerminalSend = blockTerminalSend;
            _failTerminalSendAfterRelease = failTerminalSendAfterRelease;
            _holdReceiveFailureAfterAbort = holdReceiveFailureAfterAbort;
        }

        public TaskCompletionSource ReadySent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseTerminalSend { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSendCompleted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReceiveFailureHeld { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseReceiveFailure { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<string> ProactiveResponseCreated { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseProactiveCreatedSend { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ProactiveCreatedSendCompleted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ExpireProactiveAdmission { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<string> ResponseCreated { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource InjectedFrameHandled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount => Volatile.Read(ref _abortCount);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public void QueueFrame(string frame) =>
            _inbound.Writer.TryWrite(Encoding.UTF8.GetBytes(frame));

        public void QueueFrameBytes(byte[] frame) => _inbound.Writer.TryWrite(frame);

        public void QueueReceiveException(Exception exception)
        {
            _receiveException = exception;
            _inbound.Writer.TryWrite(Array.Empty<byte>());
        }

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
            _inbound.Writer.TryComplete();
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override async Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            byte[] frame;
            try
            {
                frame = await _inbound.Reader.ReadAsync(cancellationToken);
            }
            catch (ChannelClosedException exception)
            {
                if (_holdReceiveFailureAfterAbort)
                {
                    ReceiveFailureHeld.TrySetResult();
                    await ReleaseReceiveFailure.Task.WaitAsync(cancellationToken);
                }

                throw new WebSocketException(
                    WebSocketError.ConnectionClosedPrematurely,
                    exception);
            }

            var injectedException = Interlocked.Exchange(ref _receiveException, null);
            if (injectedException is not null)
            {
                throw injectedException;
            }

            frame.AsSpan().CopyTo(buffer.AsSpan());
            if (Volatile.Read(ref _injectedFrameQueued) != 0)
            {
                _injectedFrameRead.TrySetResult();
            }

            return new WebSocketReceiveResult(
                frame.Length,
                WebSocketMessageType.Text,
                endOfMessage: true);
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            using var payload = JsonDocument.Parse(buffer);
            var isProactiveCreated =
                payload.RootElement.GetProperty("type").GetString() == "response.created" &&
                !payload.RootElement.TryGetProperty("in_reply_to", out _);
            var isBlockedTerminalSend =
                _blockTerminalSend &&
                payload.RootElement.GetProperty("type").GetString() == _terminalKind;
            var sendTask = SendCoreAsync(buffer, cancellationToken);
            if (isProactiveCreated)
            {
                _ = sendTask.ContinueWith(
                    static (_, state) =>
                        ((BlockingReceiveWebSocket)state!).ProactiveCreatedSendCompleted.TrySetResult(),
                    this,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
            }
            if (isBlockedTerminalSend)
            {
                _ = sendTask.ContinueWith(
                    static (_, state) =>
                        ((BlockingReceiveWebSocket)state!).TerminalSendCompleted.TrySetResult(),
                    this,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
            }

            return sendTask;
        }

        private async Task SendCoreAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            using var payload = JsonDocument.Parse(buffer);
            var messageTypeName = payload.RootElement.GetProperty("type").GetString();
            if (messageTypeName == "session.ready")
            {
                ReadySent.TrySetResult();
                if (_injectFrameDuringReady)
                {
                    Volatile.Write(ref _injectedFrameQueued, 1);
                    QueueFrame(UserMessageFrame());
                    await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                }
            }
            else if (messageTypeName == "response.created" &&
                !payload.RootElement.TryGetProperty("in_reply_to", out _))
            {
                _pendingProactiveResponseId = payload.RootElement.GetProperty("response_id").GetString()!;
                ProactiveResponseCreated.TrySetResult(_pendingProactiveResponseId);
                string? proactiveOutcomeType = null;
                if (_injectAcceptanceDuringProactiveCreated)
                {
                    proactiveOutcomeType = "response.accepted";
                }
                else if (_injectDropDuringProactiveCreated)
                {
                    if (payload.RootElement.GetProperty("admission_timeout_ms").GetInt32() != 1)
                    {
                        throw new InvalidOperationException("The drop test requires a one-millisecond admission timeout.");
                    }

                    await ExpireProactiveAdmission.Task;
                    proactiveOutcomeType = "response.dropped";
                }

                if (proactiveOutcomeType is not null)
                {
                    var outcome = new Dictionary<string, object?>
                    {
                        ["type"] = proactiveOutcomeType,
                        ["id"] = "m_outcome_during_created",
                        ["ts"] = "2026-08-03T00:00:02.000Z",
                        ["response_id"] = _pendingProactiveResponseId,
                    };
                    if (_injectDropDuringProactiveCreated)
                    {
                        outcome["reason"] = "no_barge_safe_window";
                    }

                    Volatile.Write(ref _injectedFrameQueued, 1);
                    QueueFrame(JsonSerializer.Serialize(outcome));
                    await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                }

                if (proactiveOutcomeType is not null || _failProactiveCreatedSend || _blockProactiveCreatedSend)
                {
                    await ReleaseProactiveCreatedSend.Task;
                    if (_failProactiveCreatedSend)
                    {
                        throw new WebSocketException(WebSocketError.ConnectionClosedPrematurely);
                    }
                }
            }
            else if (messageTypeName == "response.created")
            {
                ResponseCreated.TrySetResult(
                    payload.RootElement.GetProperty("response_id").GetString()!);
            }
            else if (messageTypeName == _terminalKind)
            {
                TerminalSendStarted.TrySetResult();
                if (_blockTerminalSend)
                {
                    await ReleaseTerminalSend.Task;
                }
                if (_state == WebSocketState.Aborted)
                {
                    throw new WebSocketException(WebSocketError.ConnectionClosedPrematurely);
                }
                if (_failTerminalSendAfterRelease)
                {
                    throw new WebSocketException(WebSocketError.ConnectionClosedPrematurely);
                }

                TerminalSent.TrySetResult();
            }

            if (_injectBargeInDuringFirstDelta &&
                messageTypeName == "response.output_text.delta" &&
                Interlocked.Exchange(ref _bargeInInjected, 1) == 0)
            {
                Volatile.Write(ref _injectedFrameQueued, 1);
                QueueFrame(JsonSerializer.Serialize(new
                {
                    type = "barge_in",
                    id = "m_barge_during_delta",
                    ts = "2026-08-03T00:00:02.000Z",
                    response_id = payload.RootElement.GetProperty("response_id").GetString(),
                    item_id = payload.RootElement.GetProperty("item_id").GetString(),
                    heard_text = string.Empty,
                }));
                await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                await InjectedFrameHandled.Task.WaitAsync(cancellationToken);
            }

            if (_injectAcceptanceDuringDone &&
                messageTypeName is "response.done" or "response.none" &&
                _pendingProactiveResponseId is not null &&
                Interlocked.Exchange(ref _acceptanceInjected, 1) == 0)
            {
                Volatile.Write(ref _injectedFrameQueued, 1);
                QueueFrame(JsonSerializer.Serialize(new
                {
                    type = "response.accepted",
                    id = "m_accept_during_done",
                    ts = "2026-08-03T00:00:03.000Z",
                    response_id = _pendingProactiveResponseId,
                }));
                await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                await InjectedFrameHandled.Task.WaitAsync(cancellationToken);
            }

            if (_injectHandoffFailureDuringHandoff && messageTypeName == "handoff")
            {
                Volatile.Write(ref _injectedFrameQueued, 1);
                QueueFrame(JsonSerializer.Serialize(new
                {
                    type = "handoff.failed",
                    id = "m_handoff_failed",
                    ts = "2026-08-03T00:00:03.000Z",
                    item_id = "in_handoff_recovery",
                    target = "target-agent",
                    code = "target_unavailable",
                }));
                await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                await InjectedFrameHandled.Task.WaitAsync(cancellationToken);
            }
        }

        public override void Dispose()
        {
            ExpireProactiveAdmission.TrySetResult();
            ReleaseProactiveCreatedSend.TrySetResult();
            ReleaseTerminalSend.TrySetResult();
            ReleaseReceiveFailure.TrySetResult();
            _injectedFrameRead.TrySetResult();
            InjectedFrameHandled.TrySetResult();
            _state = WebSocketState.Closed;
            _inbound.Writer.TryComplete();
        }
    }
}
