// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceWireSenderTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [Test]
    public void EscapedFrameOverOneMiBIsRejectedBeforeSocketWrite()
    {
        using var webSocket = new RecordingWebSocket();
        var sender = new VoiceSendTransaction(webSocket);
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = "r_test",
            ["item_id"] = "it_test",
            ["text"] = new string('\0', 200 * 1024),
        };

        Assert.That(
            async () => await sender.SendAsync("response.output_text.done", fields, CancellationToken.None),
            Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(webSocket.SendCount, Is.Zero);
    }

    [Test]
    public async Task EscapedFrameUnderOneMiBSendsExactlyOnce()
    {
        using var webSocket = new RecordingWebSocket();
        var sender = new VoiceSendTransaction(webSocket);
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = "r_test",
            ["item_id"] = "it_test",
            ["text"] = new string('\0', 100 * 1024),
        };

        await sender.SendAsync("response.output_text.done", fields, CancellationToken.None);

        Assert.That(webSocket.SendCount, Is.EqualTo(1));
    }

    [Test]
    public async Task MultibyteAndEscapedTextIsMeasuredByFinalUtf8WireSize()
    {
        using var webSocket = new RecordingWebSocket();
        var sender = new VoiceSendTransaction(webSocket);
        var text = string.Concat(Enumerable.Repeat("🙂\\\"", 50 * 1024));
        Assert.That(Encoding.UTF8.GetByteCount(text), Is.LessThan(VoiceProtocolConstants.MaxFrameBytes));
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = "r_test",
            ["item_id"] = "it_test",
            ["text"] = text,
        };

        await sender.SendAsync("response.output_text.done", fields, CancellationToken.None);

        Assert.That(webSocket.SendCount, Is.EqualTo(1));
    }

    [Test]
    public async Task EncodedOutputAccountingUsesExactPreparedFrameBytes()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var value = new CountingJsonValue();
        var frame = new VoiceFramePayload(
            "response.output_text.delta",
            new Dictionary<string, object?>
            {
                ["response_id"] = "r_test",
                ["item_id"] = "it_test",
                ["delta"] = "x",
                ["extension"] = value,
            },
            OutputResources: resources);

        await SendFrameAsync(transaction, frame);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.SentByteCounts, Has.Count.EqualTo(1));
            Assert.That(value.ReadCount, Is.EqualTo(1));
            Assert.That(governor.EncodedOutputBytes, Is.EqualTo(webSocket.SentByteCounts[0]));
            Assert.That(governor.EncodedOutputBytes, Is.GreaterThan(Encoding.UTF8.GetByteCount("x")));
        });

        resources.ReleaseAll();
        Assert.That(governor.EncodedOutputBytes, Is.Zero);
    }

    [Test]
    public async Task ResponseEncodedBudgetRejectsSecondFrameBeforeSocketWrite()
    {
        var frameBytes = await MeasureResponseFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxResponseEncodedOutputBytes = checked((2L * frameBytes) - 1),
        });
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var frame = ResponseFrame(resources, "x");

        await SendFrameAsync(transaction, frame);
        Assert.That(
            async () => await SendFrameAsync(transaction, frame),
            Throws.TypeOf<VoiceResourceExhaustedException>());

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(governor.EncodedOutputBytes, Is.EqualTo(frameBytes));
        });
        resources.ReleaseAll();
    }

    [Test]
    public async Task EncodedOutputBudgetIsSharedAcrossResponsesAndReleased()
    {
        var frameBytes = await MeasureResponseFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxEncodedOutputBytes = frameBytes,
        });
        var firstResources = governor.CreateResponseResources();
        var secondResources = governor.CreateResponseResources();
        using var firstSocket = new RecordingWebSocket();
        using var secondSocket = new RecordingWebSocket();
        var firstTransaction = new VoiceSendTransaction(firstSocket, governor);
        var secondTransaction = new VoiceSendTransaction(secondSocket, governor);

        await SendFrameAsync(firstTransaction, ResponseFrame(firstResources, "x"));
        Assert.That(
            async () => await SendFrameAsync(secondTransaction, ResponseFrame(secondResources, "x")),
            Throws.TypeOf<VoiceResourceExhaustedException>());
        Assert.That(secondSocket.SendCount, Is.Zero);

        firstResources.ReleaseAll();
        await SendFrameAsync(secondTransaction, ResponseFrame(secondResources, "x"));
        Assert.Multiple(() =>
        {
            Assert.That(secondSocket.SendCount, Is.EqualTo(1));
            Assert.That(governor.EncodedOutputBytes, Is.EqualTo(frameBytes));
        });
        secondResources.ReleaseAll();
        Assert.That(governor.EncodedOutputBytes, Is.Zero);
    }

    [Test]
    public async Task ExhaustedOrdinaryEncodedBudgetStillAllowsResponseControls()
    {
        var frameBytes = await MeasureResponseFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxEncodedOutputBytes = frameBytes,
            MaxResponseEncodedOutputBytes = frameBytes,
        });
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);

        await SendFrameAsync(transaction, ResponseFrame(resources, "x"));
        await SendFrameAsync(
            transaction,
            new VoiceFramePayload(
                "response.done",
                new Dictionary<string, object?> { ["response_id"] = "r_test" },
                "r_test",
                "done",
                resources));
        await SendFrameAsync(
            transaction,
            new VoiceFramePayload(
                "response.cancel",
                new Dictionary<string, object?> { ["response_id"] = "r_test" },
                OutputResources: resources));

        var unopenedResources = governor.CreateResponseResources();
        await transaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload(
                    "response.created",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = "r_unopened",
                        ["in_reply_to"] = new[] { "m_test" },
                    },
                    OutputResources: unopenedResources),
                new VoiceFramePayload(
                    "error",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = "r_unopened",
                        ["code"] = "agent_error",
                        ["message"] = "failed",
                    },
                    "r_unopened",
                    "error",
                    unopenedResources),
            },
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(5));
            Assert.That(governor.EncodedOutputBytes, Is.EqualTo(frameBytes));
            Assert.That(governor.TerminalEncodedOutputBytes, Is.GreaterThan(0));
        });
        resources.ReleaseAll();
        unopenedResources.ReleaseAll();
        Assert.Multiple(() =>
        {
            Assert.That(governor.EncodedOutputBytes, Is.Zero);
            Assert.That(governor.TerminalEncodedOutputBytes, Is.Zero);
        });
    }

    [Test]
    public async Task ResponseTerminalEncodedBudgetRejectsSecondControlBeforeSocketWrite()
    {
        var frameBytes = await MeasureTerminalFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxResponseTerminalEncodedOutputBytes = checked((2L * frameBytes) - 1),
        });
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var frame = TerminalFrame(resources);

        await SendFrameAsync(transaction, frame);
        Assert.That(
            async () => await SendFrameAsync(transaction, frame),
            Throws.TypeOf<VoiceResourceExhaustedException>());

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(governor.TerminalEncodedOutputBytes, Is.EqualTo(frameBytes));
        });
        resources.ReleaseAll();
    }

    [Test]
    public async Task TerminalEncodedBudgetIsSharedAcrossResponsesAndReleased()
    {
        var frameBytes = await MeasureTerminalFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxTerminalEncodedOutputBytes = frameBytes,
        });
        var firstResources = governor.CreateResponseResources();
        var secondResources = governor.CreateResponseResources();
        using var firstSocket = new RecordingWebSocket();
        using var secondSocket = new RecordingWebSocket();
        var firstTransaction = new VoiceSendTransaction(firstSocket, governor);
        var secondTransaction = new VoiceSendTransaction(secondSocket, governor);

        await SendFrameAsync(firstTransaction, TerminalFrame(firstResources));
        Assert.That(
            async () => await SendFrameAsync(secondTransaction, TerminalFrame(secondResources)),
            Throws.TypeOf<VoiceResourceExhaustedException>());
        Assert.That(secondSocket.SendCount, Is.Zero);

        firstResources.ReleaseAll();
        await SendFrameAsync(secondTransaction, TerminalFrame(secondResources));
        Assert.Multiple(() =>
        {
            Assert.That(secondSocket.SendCount, Is.EqualTo(1));
            Assert.That(governor.TerminalEncodedOutputBytes, Is.EqualTo(frameBytes));
        });
        secondResources.ReleaseAll();
        Assert.That(governor.TerminalEncodedOutputBytes, Is.Zero);
    }

    [Test]
    public async Task EncodedOutputReservationRollsBackBeforeWireAttempt()
    {
        var frameBytes = await MeasureResponseFrameBytesAsync();
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxResponseEncodedOutputBytes = frameBytes - 1,
        });
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);

        Assert.That(
            async () => await SendFrameAsync(transaction, ResponseFrame(resources, "x")),
            Throws.TypeOf<VoiceResourceExhaustedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.Zero);
            Assert.That(governor.EncodedOutputBytes, Is.Zero);
        });
        resources.ReleaseAll();
    }

    [Test]
    public async Task TerminalBeforeWireInvalidatesEncodedReservation()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var beforeWireEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBeforeWire = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var wireAttempted = new VoiceWireAttemptSignal();
        var send = transaction.ExecuteAsync(
            ResponseFrame(resources, "x"),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            beforeWireAsync: async () =>
            {
                beforeWireEntered.TrySetResult();
                await releaseBeforeWire.Task;
            },
            wireAttempted: wireAttempted);
        try
        {
            await beforeWireEntered.Task.WaitAsync(TimeSpan.FromSeconds(1));

            resources.ReleaseContent();
            releaseBeforeWire.TrySetResult();
            Assert.That(
                async () => await send.WaitAsync(TimeSpan.FromSeconds(1)),
                Throws.TypeOf<VoiceBridgeConnectionClosedException>());

            Assert.Multiple(() =>
            {
                Assert.That(webSocket.SendCount, Is.Zero);
                Assert.That(wireAttempted.IsAttempted, Is.False);
                Assert.That(governor.EncodedOutputBytes, Is.Zero);
                Assert.That(governor.PreparedFrameCount, Is.Zero);
                Assert.That(governor.PreparedFrameBytes, Is.Zero);
            });
        }
        finally
        {
            releaseBeforeWire.TrySetResult();
            try
            {
                await send.WaitAsync(TimeSpan.FromSeconds(1));
            }
            catch
            {
                _ = send.Exception;
            }
            resources.ReleaseAll();
        }
    }

    [Test]
    public async Task FullResponseReleaseBeforeWireDoesNotAbortCarrier()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var beforeWireEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBeforeWire = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var wireAttempted = new VoiceWireAttemptSignal();
        var send = transaction.ExecuteAsync(
            ResponseFrame(resources, "x"),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            beforeWireAsync: async () =>
            {
                beforeWireEntered.TrySetResult();
                await releaseBeforeWire.Task;
            },
            wireAttempted: wireAttempted);
        try
        {
            await beforeWireEntered.Task.WaitAsync(TimeSpan.FromSeconds(1));

            resources.ReleaseAll();
            releaseBeforeWire.TrySetResult();
            Assert.That(
                async () => await send.WaitAsync(TimeSpan.FromSeconds(1)),
                Throws.TypeOf<VoiceBridgeConnectionClosedException>());

            Assert.Multiple(() =>
            {
                Assert.That(webSocket.SendCount, Is.Zero);
                Assert.That(webSocket.AbortCount, Is.Zero);
                Assert.That(wireAttempted.IsAttempted, Is.False);
                Assert.That(governor.EncodedOutputBytes, Is.Zero);
                Assert.That(governor.PreparedFrameCount, Is.Zero);
                Assert.That(governor.PreparedFrameBytes, Is.Zero);
            });

            await transaction.SendAsync(
                    "future.message",
                    new Dictionary<string, object?>(),
                    CancellationToken.None)
                .WaitAsync(TestTimeout);
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
        }
        finally
        {
            releaseBeforeWire.TrySetResult();
            try
            {
                await send.WaitAsync(TimeSpan.FromSeconds(1));
            }
            catch
            {
                _ = send.Exception;
            }
        }
    }

    [Test]
    public async Task EncodedCommitPrecedesAttemptedPrefixPublication()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var beforeWireEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBeforeWire = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var encodedCommitStarted = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var governorSync = typeof(VoiceResourceGovernor).GetField(
            "_sync",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
            .GetValue(governor)!;
        var send = transaction.ExecuteAsync(
            ResponseFrame(resources, "x"),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            beforeWireAsync: async () =>
            {
                beforeWireEntered.TrySetResult();
                await releaseBeforeWire.Task;
            },
            encodedCommitStarted: () => encodedCommitStarted.TrySetResult());
        using var releaseGovernorLock = new ManualResetEventSlim();
        var governorLockAcquired = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        Task? lockOwner = null;
        try
        {
            await beforeWireEntered.Task.WaitAsync(TestTimeout);
            lockOwner = Task.Run(() =>
            {
                lock (governorSync)
                {
                    governorLockAcquired.TrySetResult();
                    releaseGovernorLock.Wait();
                }
            });
            try
            {
                await governorLockAcquired.Task.WaitAsync(TestTimeout);
                releaseBeforeWire.TrySetResult();
                await encodedCommitStarted.Task.WaitAsync(TestTimeout);

                Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);
            }
            finally
            {
                releaseGovernorLock.Set();
                releaseBeforeWire.TrySetResult();
                await lockOwner.WaitAsync(TestTimeout);
            }

            await send.WaitAsync(TestTimeout);
        }
        finally
        {
            releaseGovernorLock.Set();
            releaseBeforeWire.TrySetResult();
            try
            {
                await send.WaitAsync(TestTimeout);
            }
            catch
            {
                _ = send.Exception;
            }
            resources.ReleaseAll();
        }
    }

    [TestCase("wire")]
    [TestCase("operation")]
    [TestCase("response")]
    public async Task CancellationWhileEncodedCommitWaitsPreventsSocketCall(string cancellationKind)
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var wireCancellation = new CancellationTokenSource();
        using var operationCancellation = new CancellationTokenSource();
        using var responseCancellation = new CancellationTokenSource();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(
            webSocket,
            governor,
            wireCancellation: wireCancellation.Token);
        var reservationEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseReservation = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var encodedCommitStarted = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var wireAttempted = new VoiceWireAttemptSignal();
        var governorSync = typeof(VoiceResourceGovernor).GetField(
            "_sync",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
            .GetValue(governor)!;
        var send = transaction.ExecuteAsync(
            ResponseFrame(resources, "x"),
            async cancellationToken =>
            {
                reservationEntered.TrySetResult();
                await releaseReservation.Task.WaitAsync(cancellationToken);
                return 0;
            },
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token,
            operationDeadlineCancellation: operationCancellation.Token,
            wireAttempted: wireAttempted,
            encodedCommitStarted: () => encodedCommitStarted.TrySetResult());
        using var releaseGovernorLock = new ManualResetEventSlim();
        var governorLockAcquired = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        Task? lockOwner = null;
        try
        {
            await reservationEntered.Task.WaitAsync(TestTimeout);
            lockOwner = Task.Run(() =>
            {
                lock (governorSync)
                {
                    governorLockAcquired.TrySetResult();
                    releaseGovernorLock.Wait();
                }
            });
            await governorLockAcquired.Task.WaitAsync(TestTimeout);
            releaseReservation.TrySetResult();
            await encodedCommitStarted.Task.WaitAsync(TestTimeout);
            Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);

            var cancellation = cancellationKind switch
            {
                "wire" => wireCancellation,
                "operation" => operationCancellation,
                "response" => responseCancellation,
                _ => throw new AssertionException($"Unsupported cancellation kind {cancellationKind}."),
            };
            await cancellation.CancelAsync();
            releaseGovernorLock.Set();
            await lockOwner.WaitAsync(TestTimeout);

            try
            {
                await send.WaitAsync(TestTimeout);
                Assert.Fail("The cancelled transaction unexpectedly completed.");
            }
            catch (Exception exception) when (
                exception is VoiceBridgeConnectionClosedException or OperationCanceledException)
            {
            }

            Assert.Multiple(() =>
            {
                Assert.That(webSocket.SendCount, Is.Zero);
                Assert.That(webSocket.AbortCount, Is.Zero);
                Assert.That(wireAttempted.IsAttempted, Is.False);
                Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);
                Assert.That(governor.EncodedOutputBytes, Is.Zero);
                Assert.That(governor.PreparedFrameCount, Is.Zero);
                Assert.That(governor.PreparedFrameBytes, Is.Zero);
            });
        }
        finally
        {
            releaseReservation.TrySetResult();
            releaseGovernorLock.Set();
            if (lockOwner is not null)
            {
                await lockOwner.WaitAsync(TestTimeout);
            }
            try
            {
                await send.WaitAsync(TestTimeout);
            }
            catch
            {
                _ = send.Exception;
            }
            resources.ReleaseAll();
        }
    }

    [Test]
    public async Task AttemptedSendFailureRetainsEncodedBudgetUntilTerminalRelease()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket
        {
            SendException = new InvalidOperationException("failed"),
        };
        var transaction = new VoiceSendTransaction(webSocket, governor);

        Assert.That(
            async () => await SendFrameAsync(transaction, ResponseFrame(resources, "x")),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(governor.EncodedOutputBytes, Is.EqualTo(webSocket.SentByteCounts[0]));
        });

        resources.ReleaseAll();
        Assert.That(governor.EncodedOutputBytes, Is.Zero);
    }

    [Test]
    public async Task ItemlessWireOpenedTerminalReleasesEncodedOutputBudget()
    {
        var governor = new VoiceResourceGovernor();
        var response = new VoiceResponse(
            new StubConnection(),
            "r_proactive",
            inReplyTo: null,
            wireOpened: true,
            accepted: false,
            CancellationToken.None,
            governor);
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        var frame = new VoiceFramePayload(
            "response.created",
            new Dictionary<string, object?>
            {
                ["response_id"] = response.ResponseId,
                ["admission_timeout_ms"] = 5000,
            },
            OutputResources: response.OutputResources);

        await SendFrameAsync(transaction, frame);
        Assert.That(governor.EncodedOutputBytes, Is.GreaterThan(0));

        await response.MarkTerminalAsync();
        await VoiceTerminationCoordinator.ApplyResponseTermination(
            new VoiceResponseTermination(
                IsNewTerminal: true,
                TerminalKind: "dropped",
                response,
                VoiceTurnTermination.None("dropped")));

        Assert.That(governor.EncodedOutputBytes, Is.Zero);
    }

    [Test]
    public async Task BatchPreparesEveryFrameBeforeOneReservation()
    {
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        var first = new CountingJsonValue();
        var second = new CountingJsonValue();
        (int First, int Second) readsAtReservation = default;

        await transaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload(
                    "response.created",
                    new Dictionary<string, object?> { ["value"] = first }),
                new VoiceFramePayload(
                    "response.output_text.done",
                    new Dictionary<string, object?> { ["value"] = second }),
            },
            _ =>
            {
                readsAtReservation = (first.ReadCount, second.ReadCount);
                return ValueTask.FromResult(0);
            },
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(readsAtReservation, Is.EqualTo((1, 1)));
            Assert.That(first.ReadCount, Is.EqualTo(1));
            Assert.That(second.ReadCount, Is.EqualTo(1));
            Assert.That(webSocket.SendCount, Is.EqualTo(2));
        });
    }

    [Test]
    public void PreparationFailureDoesNotReserveState()
    {
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        var reserveCount = 0;

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new VoiceFramePayload(
                    "response.output_text.done",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = "r_test",
                        ["item_id"] = "it_test",
                        ["text"] = new string('\0', 200 * 1024),
                    }),
                _ =>
                {
                    reserveCount++;
                    return ValueTask.FromResult(0);
                },
                static _ => ValueTask.FromResult(true),
                CancellationToken.None),
            Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.Multiple(() =>
        {
            Assert.That(reserveCount, Is.Zero);
            Assert.That(webSocket.SendCount, Is.Zero);
        });
    }

    [Test]
    public void AttemptedSendFailureAbortsAndDoesNotCommit()
    {
        using var webSocket = new RecordingWebSocket { SendException = new InvalidOperationException("failed") };
        var transaction = new VoiceSendTransaction(webSocket);
        var reserveCount = 0;
        var commitCount = 0;

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
                _ =>
                {
                    reserveCount++;
                    return ValueTask.FromResult(0);
                },
                _ =>
                {
                    commitCount++;
                    return ValueTask.FromResult(true);
                },
                CancellationToken.None),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(reserveCount, Is.EqualTo(1));
            Assert.That(commitCount, Is.Zero);
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void ResponseTerminalBeforeWireAttemptDoesNotAbortCarrier()
    {
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        using var responseCancellation = new CancellationTokenSource();
        responseCancellation.Cancel();

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None,
                responseCancellation.Token),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.Zero);
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public void ResponseTerminalAfterReservationButBeforeWireAttemptDoesNotAbortCarrier()
    {
        using var webSocket = new RecordingWebSocket { ObserveCancellationBeforeSend = true };
        var transaction = new VoiceSendTransaction(webSocket);
        using var responseCancellation = new CancellationTokenSource();

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new VoiceFramePayload(
                    "response.output_text.delta",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = "r_test",
                        ["item_id"] = "it_test",
                    }),
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None,
                responseCancellation.Token,
                beforeWireAsync: async () =>
                {
                    Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);
                    await responseCancellation.CancelAsync();
                }),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.Zero);
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task ResponseTerminalDuringWireAttemptDoesNotAbortCarrier()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket { AllowSend = allowSend.Task };
        var transaction = new VoiceSendTransaction(webSocket);
        using var responseCancellation = new CancellationTokenSource();
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        await responseCancellation.CancelAsync();
        Assert.That(send.IsCompleted, Is.False);
        allowSend.TrySetResult();
        await send.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task PhysicalSendDeadlineAbortsSendThatIgnoresSemanticTerminal()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            AllowSend = allowSend.Task,
            IgnoreAbortDuringSend = true,
        };
        var transaction = new VoiceSendTransaction(
            webSocket,
            physicalSendTimeout: TimeSpan.FromMilliseconds(50));
        using var responseCancellation = new CancellationTokenSource();
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        try
        {
            await responseCancellation.CancelAsync();

            Assert.That(
                async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
                Throws.TypeOf<VoiceBridgeConnectionClosedException>());
            Assert.Multiple(() =>
            {
                Assert.That(webSocket.AbortCount, Is.EqualTo(1));
                Assert.That(webSocket.SendFinished.Task.IsCompleted, Is.False);
            });
        }
        finally
        {
            allowSend.TrySetResult();
            await webSocket.SendFinished.Task.WaitAsync(TimeSpan.FromSeconds(2));
        }
    }

    [Test]
    public async Task TerminalDrainDeadlineStartsOnlyAfterSemanticTerminal()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            AllowSend = allowSend.Task,
            IgnoreAbortDuringSend = true,
        };
        var transaction = new VoiceSendTransaction(
            webSocket,
            terminalSendDrainTimeout: TimeSpan.FromMilliseconds(50));
        using var responseCancellation = new CancellationTokenSource();
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromMilliseconds(100)),
            Throws.TypeOf<TimeoutException>());
        Assert.That(webSocket.AbortCount, Is.Zero);

        await responseCancellation.CancelAsync();
        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.That(webSocket.AbortCount, Is.EqualTo(1));

        allowSend.TrySetResult();
        await webSocket.SendFinished.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task DetachedSendReleasesProcessFrameBudgetWhenUnderlyingTaskCompletes()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            AllowSend = allowSend.Task,
            IgnoreAbortDuringSend = true,
        };
        var transaction = new VoiceSendTransaction(
            webSocket,
            physicalSendTimeout: TimeSpan.FromMilliseconds(25));
        var baseline = transaction.OutstandingPreparedFrameBytes;
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload(
                "response.output_text.delta",
                new Dictionary<string, object?>
                {
                    ["response_id"] = "r_test",
                    ["item_id"] = "it_test",
                    ["delta"] = new string('x', 1024),
                }),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.That(transaction.OutstandingPreparedFrameBytes, Is.GreaterThan(baseline));
        Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.True);

        allowSend.TrySetResult();
        await webSocket.SendFinished.Task.WaitAsync(TimeSpan.FromSeconds(2));
        await WaitForOutstandingFrameBytesAsync(transaction, baseline).WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);
    }

    [Test]
    public async Task SharedPreparedFrameBudgetRejectsBeforeSecondSocketWrite()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxPreparedFrameBytes = VoiceProtocolConstants.MaxFrameBytes,
            MaxPreparedFrames = 1,
        });
        var allowFirst = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var firstSocket = new RecordingWebSocket { AllowSend = allowFirst.Task };
        using var secondSocket = new RecordingWebSocket();
        var firstTransaction = new VoiceSendTransaction(
            firstSocket,
            governor,
            physicalSendTimeout: TimeSpan.FromSeconds(2));
        var secondTransaction = new VoiceSendTransaction(secondSocket, governor);
        var frame = new VoiceFramePayload(
            "response.output_text.delta",
            new Dictionary<string, object?>
            {
                ["response_id"] = "r_test",
                ["item_id"] = "it_test",
                ["delta"] = "x",
            });

        var first = firstTransaction.ExecuteAsync(
            frame,
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);
        await firstSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(
            async () => await secondTransaction.ExecuteAsync(
                frame,
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None),
            Throws.TypeOf<VoiceResourceExhaustedException>());
        Assert.Multiple(() =>
        {
            Assert.That(secondSocket.SendCount, Is.Zero);
            Assert.That(governor.PreparedFrameBytes, Is.EqualTo(VoiceProtocolConstants.MaxFrameBytes));
        });

        allowFirst.TrySetResult();
        await first.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(governor.PreparedFrameBytes, Is.Zero);
    }

    [Test]
    public async Task ResponseOpenTerminalBatchUsesProtectedControlCapacity()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxPreparedFrameBytes = VoiceProtocolConstants.MaxFrameBytes,
            MaxPreparedFrames = 1,
            MaxControlFrameBytes = 2L * VoiceProtocolConstants.MaxFrameBytes,
            MaxControlFrames = 2,
        });
        var allowData = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var dataSocket = new RecordingWebSocket { AllowSend = allowData.Task };
        using var controlSocket = new RecordingWebSocket();
        var dataTransaction = new VoiceSendTransaction(
            dataSocket,
            governor,
            physicalSendTimeout: TimeSpan.FromSeconds(2));
        var controlTransaction = new VoiceSendTransaction(controlSocket, governor);
        var dataSend = dataTransaction.SendAsync(
            "response.output_text.delta",
            new Dictionary<string, object?> { ["delta"] = "x" },
            CancellationToken.None);
        await dataSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        await controlTransaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload(
                    "response.created",
                    new Dictionary<string, object?> { ["response_id"] = "r_terminal" }),
                new VoiceFramePayload(
                    "error",
                    new Dictionary<string, object?> { ["response_id"] = "r_terminal" }),
            },
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(controlSocket.SendCount, Is.EqualTo(2));
            Assert.That(governor.PreparedFrameBytes, Is.EqualTo(VoiceProtocolConstants.MaxFrameBytes));
        });

        allowData.TrySetResult();
        await dataSend.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task MultiFrameAttemptExposesOnlyAttemptedPrefix()
    {
        var allowCreated = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var allowDelta = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var deltaStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            SendGate = sendNumber => sendNumber == 1 ? allowCreated.Task : allowDelta.Task,
            OnSendStarted = sendNumber =>
            {
                if (sendNumber == 2)
                {
                    deltaStarted.TrySetResult();
                }
            },
        };
        var transaction = new VoiceSendTransaction(webSocket);
        var send = transaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload(
                    "response.created",
                    new Dictionary<string, object?> { ["response_id"] = "r_test" }),
                new VoiceFramePayload(
                    "response.output_text.delta",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = "r_test",
                        ["item_id"] = "it_test",
                        ["delta"] = "hello",
                    }),
            },
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.False);

        allowCreated.TrySetResult();
        await deltaStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_test"), Is.True);

        allowDelta.TrySetResult();
        await send.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public void SynchronousSendThrowExposesCurrentFrameButNotLaterFrames()
    {
        using var webSocket = new SynchronousThrowWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        webSocket.BeforeThrow = () =>
        {
            Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_current"), Is.True);
            Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_later"), Is.False);
        };

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new[]
                {
                    new VoiceFramePayload(
                        "response.output_text.delta",
                        new Dictionary<string, object?>
                        {
                            ["response_id"] = "r_test",
                            ["item_id"] = "it_current",
                            ["delta"] = "first",
                        }),
                    new VoiceFramePayload(
                        "response.output_text.delta",
                        new Dictionary<string, object?>
                        {
                            ["response_id"] = "r_test",
                            ["item_id"] = "it_later",
                            ["delta"] = "second",
                        }),
                },
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_current"), Is.False);
            Assert.That(transaction.IsItemPotentiallyVisible("r_test", "it_later"), Is.False);
        });
    }

    [Test]
    public void SynchronousConnectionClosedSendFailureAbortsCarrier()
    {
        using var webSocket = new SynchronousThrowWebSocket
        {
            SendException = new VoiceBridgeConnectionClosedException("socket failed"),
        };
        var transaction = new VoiceSendTransaction(webSocket);

        Assert.That(
            async () => await transaction.SendAsync(
                "future.message",
                new Dictionary<string, object?>(),
                CancellationToken.None),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.That(webSocket.AbortCount, Is.EqualTo(1));
    }

    [Test]
    public void AsynchronousConnectionClosedSendFailureAbortsCarrier()
    {
        using var webSocket = new RecordingWebSocket
        {
            SendException = new VoiceBridgeConnectionClosedException("socket failed"),
        };
        var transaction = new VoiceSendTransaction(webSocket);

        Assert.That(
            async () => await transaction.SendAsync(
                "future.message",
                new Dictionary<string, object?>(),
                CancellationToken.None),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task ResponseTerminalFrameStartsBoundedDrainWithoutSemanticCancellation()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            AllowSend = allowSend.Task,
            IgnoreAbortDuringSend = true,
        };
        var transaction = new VoiceSendTransaction(
            webSocket,
            terminalSendDrainTimeout: TimeSpan.FromMilliseconds(50));
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload(
                "response.done",
                new Dictionary<string, object?> { ["response_id"] = "r_test" },
                OwnerResponseId: "r_test",
                TerminalKind: "done"),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.That(webSocket.AbortCount, Is.EqualTo(1));

        allowSend.TrySetResult();
        await webSocket.SendFinished.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ResponseOpenBatchStartsTerminalDrainAtTerminalFrameOnly()
    {
        var allowCreated = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var allowError = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var errorStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            IgnoreAbortDuringSend = true,
            SendGate = sendNumber => sendNumber == 1 ? allowCreated.Task : allowError.Task,
            OnSendStarted = sendNumber =>
            {
                if (sendNumber == 2)
                {
                    errorStarted.TrySetResult();
                }
            },
        };
        var transaction = new VoiceSendTransaction(
            webSocket,
            terminalSendDrainTimeout: TimeSpan.FromMilliseconds(50));
        var send = transaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload(
                    "response.created",
                    new Dictionary<string, object?> { ["response_id"] = "r_test" }),
                new VoiceFramePayload(
                    "error",
                    new Dictionary<string, object?> { ["response_id"] = "r_test" },
                    OwnerResponseId: "r_test",
                    TerminalKind: "error"),
            },
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromMilliseconds(100)),
            Throws.TypeOf<TimeoutException>());
        Assert.That(webSocket.AbortCount, Is.Zero);

        allowCreated.TrySetResult();
        await errorStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.That(webSocket.AbortCount, Is.EqualTo(1));

        allowError.TrySetResult();
        await webSocket.SendFinished.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task CompletedWireWriteWinsRacingResponseTerminal()
    {
        using var responseCancellation = new CancellationTokenSource();
        using var webSocket = new RecordingWebSocket
        {
            AfterSend = _ => responseCancellation.Cancel(),
        };
        var transaction = new VoiceSendTransaction(webSocket);

        await transaction.ExecuteAsync(
            new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task CompletedRawSendWinsBeforeItsContinuationRuns()
    {
        using var responseCancellation = new CancellationTokenSource();
        using var webSocket = new DeferredCompletionWebSocket();
        var transaction = new VoiceSendTransaction(
            webSocket,
            terminalSendDrainTimeout: TimeSpan.FromSeconds(1));
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        webSocket.CompleteSend();
        responseCancellation.Cancel();
        await send.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task CompletedRawSendWinsLaterOperationDeadline()
    {
        using var operationDeadline = new CancellationTokenSource();
        using var webSocket = new DeferredCompletionWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        webSocket.CompleteSend();
        operationDeadline.Cancel();
        await send.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task OperationDeadlineBeforeTaskPublicationWinsIncompleteSend()
    {
        using var operationDeadline = new CancellationTokenSource();
        using var webSocket = new DeadlineBeforePublicationWebSocket(
            () => operationDeadline.Cancel());
        var transaction = new VoiceSendTransaction(webSocket);
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);

        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });

        webSocket.CompleteSend();
        await webSocket.SendCompleted.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ResponseTerminalBetweenBatchFramesDoesNotAbortCarrier()
    {
        using var responseCancellation = new CancellationTokenSource();
        using var webSocket = new RecordingWebSocket
        {
            AfterSend = sendCount =>
            {
                if (sendCount == 1)
                {
                    responseCancellation.Cancel();
                }
            },
        };
        var transaction = new VoiceSendTransaction(webSocket);

        await transaction.ExecuteAsync(
            new[]
            {
                new VoiceFramePayload("response.created", new Dictionary<string, object?>()),
                new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
            },
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            responseCancellation.Token);
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(2));
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public void LostPostSendArbitrationDoesNotAbortCarrier()
    {
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(false),
                CancellationToken.None),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task CancellationWhileWaitingForTransactionDoesNotDamageGate()
    {
        var allowFirstSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket { AllowSend = allowFirstSend.Task };
        var transaction = new VoiceSendTransaction(webSocket);
        var first = transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        using var waitCancellation = new CancellationTokenSource();
        var cancelled = transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            waitCancellation.Token);

        waitCancellation.Cancel();
        Assert.That(async () => await cancelled, Throws.InstanceOf<OperationCanceledException>());
        allowFirstSend.TrySetResult();
        await first;
        await transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            CancellationToken.None);

        Assert.That(webSocket.SendCount, Is.EqualTo(2));
    }

    [Test]
    public async Task OperationDeadlineWhileWaitingForTransactionDoesNotLeaveGateWaiter()
    {
        var allowFirstSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket { AllowSend = allowFirstSend.Task };
        var transaction = new VoiceSendTransaction(webSocket);
        var first = transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            CancellationToken.None);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        using var operationDeadline = new CancellationTokenSource();
        var expired = transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);

        try
        {
            operationDeadline.Cancel();
            Assert.That(async () => await expired, Throws.InstanceOf<OperationCanceledException>());
        }
        finally
        {
            allowFirstSend.TrySetResult();
            await first;
        }

        await transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            CancellationToken.None);

        Assert.That(webSocket.SendCount, Is.EqualTo(2));
    }

    [Test]
    public async Task OperationDeadlineWinnerIsNotOverriddenByLaterSendSuccess()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket { AllowSend = allowSend.Task };
        using var operationDeadline = new CancellationTokenSource();
        var transaction = new VoiceSendTransaction(webSocket);
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);
        await webSocket.SendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        operationDeadline.Cancel();
        allowSend.TrySetResult();
        Assert.That(
            async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });
    }

    [Test]
    public async Task SynchronousSendCompletionWinsDeadlineRaisedInsideCall()
    {
        using var operationDeadline = new CancellationTokenSource();
        using var webSocket = new RecordingWebSocket
        {
            AfterSend = _ => operationDeadline.Cancel(),
        };
        var transaction = new VoiceSendTransaction(webSocket);

        await transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task OperationDeadlineCancelsReservationBeforeSocketWrite()
    {
        using var operationDeadline = new CancellationTokenSource();
        using var webSocket = new RecordingWebSocket();
        var reservationStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var transaction = new VoiceSendTransaction(webSocket);
        var send = transaction.ExecuteAsync(
            new VoiceFramePayload("future.message", new Dictionary<string, object?>()),
            async cancellationToken =>
            {
                reservationStarted.TrySetResult();
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                return 0;
            },
            static _ => ValueTask.FromResult(true),
            CancellationToken.None,
            operationDeadlineCancellation: operationDeadline.Token);
        try
        {
            await reservationStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
            operationDeadline.Cancel();
            Assert.That(
                async () => await send.WaitAsync(TimeSpan.FromSeconds(2)),
                Throws.InstanceOf<OperationCanceledException>());
        }
        finally
        {
            operationDeadline.Cancel();
            try
            {
                await send.WaitAsync(TimeSpan.FromSeconds(2));
            }
            catch (OperationCanceledException)
            {
            }
        }

        await transaction.SendAsync(
            "future.message",
            new Dictionary<string, object?>(),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.Zero);
        });
    }

    private sealed class CountingJsonValue
    {
        private int _readCount;

        [JsonIgnore]
        public int ReadCount => Volatile.Read(ref _readCount);

        public string Value
        {
            get
            {
                Interlocked.Increment(ref _readCount);
                return "value";
            }
        }
    }

    private static async Task WaitForOutstandingFrameBytesAsync(
        VoiceSendTransaction transaction,
        long expected)
    {
        while (transaction.OutstandingPreparedFrameBytes != expected)
        {
            await Task.Yield();
        }
    }

    private static VoiceFramePayload ResponseFrame(
        VoiceResponseResources resources,
        string text) =>
        new(
            "response.output_text.delta",
            new Dictionary<string, object?>
            {
                ["response_id"] = "r_test",
                ["item_id"] = "it_test",
                ["delta"] = text,
            },
            OutputResources: resources);

    private static VoiceFramePayload TerminalFrame(VoiceResponseResources resources) =>
        new(
            "response.done",
            new Dictionary<string, object?> { ["response_id"] = "r_test" },
            "r_test",
            "done",
            resources);

    private static async Task<int> SendFrameAsync(
        VoiceSendTransaction transaction,
        VoiceFramePayload frame) =>
        await transaction.ExecuteAsync(
            frame,
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None).WaitAsync(TestTimeout);

    private static async Task<int> MeasureResponseFrameBytesAsync()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        await SendFrameAsync(transaction, ResponseFrame(resources, "x"));
        var frameBytes = webSocket.SentByteCounts.Single();
        resources.ReleaseAll();
        return frameBytes;
    }

    private static async Task<int> MeasureTerminalFrameBytesAsync()
    {
        var governor = new VoiceResourceGovernor();
        var resources = governor.CreateResponseResources();
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket, governor);
        await SendFrameAsync(transaction, TerminalFrame(resources));
        var frameBytes = webSocket.SentByteCounts.Single();
        resources.ReleaseAll();
        return frameBytes;
    }

    private sealed class RecordingWebSocket : WebSocket
    {
        private readonly CancellationTokenSource _abortSignal = new();
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public int SendCount { get; private set; }

        public List<int> SentByteCounts { get; } = new();

        public int AbortCount => Volatile.Read(ref _abortCount);

        public Exception? SendException { get; init; }

        public Task? AllowSend { get; init; }

        public Func<int, Task?>? SendGate { get; init; }

        public bool ObserveCancellationBeforeSend { get; init; }

        public bool IgnoreAbortDuringSend { get; init; }

        public Action<int>? AfterSend { get; init; }

        public Action<int>? OnSendStarted { get; init; }

        public TaskCompletionSource SendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SendFinished { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
            _abortSignal.Cancel();
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

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) =>
            throw new NotSupportedException();

        public override async Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            if (ObserveCancellationBeforeSend)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            SendCount++;
            var sendNumber = SendCount;
            SentByteCounts.Add(buffer.Count);
            SendStarted.TrySetResult();
            OnSendStarted?.Invoke(sendNumber);
            if (SendException is not null)
            {
                throw SendException;
            }

            var sendGate = SendGate?.Invoke(sendNumber) ?? AllowSend;
            if (sendGate is not null)
            {
                try
                {
                    await sendGate.WaitAsync(
                        IgnoreAbortDuringSend ? CancellationToken.None : _abortSignal.Token);
                }
                finally
                {
                    SendFinished.TrySetResult();
                }
            }

            AfterSend?.Invoke(sendNumber);
        }

        public override void Dispose()
        {
            _state = WebSocketState.Closed;
            _abortSignal.Dispose();
        }
    }

    private sealed class StubConnection : IVoiceConnection
    {
        public bool Ending => false;

        public Task SendResponseFrameAsync(
            VoiceResponse response,
            string messageType,
            IReadOnlyDictionary<string, object?> fields,
            Action commit,
            bool terminal,
            string? terminalKind,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<bool> OpenResponseAsync(
            VoiceResponse response,
            IReadOnlyList<string>? inReplyTo,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task DeclineResponseAsync(
            VoiceResponse response,
            IReadOnlyList<string> inReplyTo,
            string? reason,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<Task<ResponseCancellationOutcome>> BeginCancelAsync(
            VoiceResponse response,
            string? reason,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task EndCallAsync(
            string reason,
            string mode,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<VoiceResponse> StartProactiveResponseAsync(
            int admissionTimeoutMs,
            string? supersedeKey,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task ReportSessionErrorAsync(
            string code,
            string message,
            CancellationToken cancellationToken) => throw new NotSupportedException();
    }

    private sealed class DeferredCompletionWebSocket : WebSocket
    {
        private readonly TaskCompletionSource _sendCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public int AbortCount => Volatile.Read(ref _abortCount);

        public TaskCompletionSource SendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public void CompleteSend() => _sendCompletion.TrySetResult();

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            SendStarted.TrySetResult();
            return _sendCompletion.Task;
        }

        public override void Dispose()
        {
            _sendCompletion.TrySetResult();
            _state = WebSocketState.Closed;
        }
    }

    private sealed class DeadlineBeforePublicationWebSocket : WebSocket
    {
        private readonly Action _beforeReturn;
        private readonly TaskCompletionSource _sendCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public DeadlineBeforePublicationWebSocket(Action beforeReturn)
        {
            _beforeReturn = beforeReturn;
        }

        public int AbortCount => Volatile.Read(ref _abortCount);

        public TaskCompletionSource SendCompleted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public void CompleteSend()
        {
            _sendCompletion.TrySetResult();
            SendCompleted.TrySetResult();
        }

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            _beforeReturn();
            return _sendCompletion.Task;
        }

        public override void Dispose()
        {
            CompleteSend();
            _state = WebSocketState.Closed;
        }
    }

    private sealed class SynchronousThrowWebSocket : WebSocket
    {
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public Action? BeforeThrow { get; set; }

        public Exception SendException { get; init; } =
            new WebSocketException("Synchronous send failure.");

        public int AbortCount => Volatile.Read(ref _abortCount);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            BeforeThrow?.Invoke();
            throw SendException;
        }

        public override void Dispose()
        {
            _state = WebSocketState.Closed;
        }
    }
}
