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
    public async Task TransactionPreparesExactFrameOnlyOnce()
    {
        using var webSocket = new RecordingWebSocket();
        var transaction = new VoiceSendTransaction(webSocket);
        var value = new CountingJsonValue();

        await transaction.ExecuteAsync(
            new VoiceFramePayload(
                "future.message",
                new Dictionary<string, object?> { ["value"] = value }),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(value.ReadCount, Is.EqualTo(1));
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
        });
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
                new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None,
                responseCancellation.Token,
                beforeWireAsync: async () => await responseCancellation.CancelAsync()),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.Zero);
            Assert.That(webSocket.AbortCount, Is.Zero);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public async Task ResponseTerminalDuringWireAttemptAbortsCarrier()
    {
        var neverComplete = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket { AllowSend = neverComplete.Task };
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

        Assert.That(async () => await send, Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });
    }

    [Test]
    public async Task ResponseTerminalDoesNotWaitForSendThatIgnoresAbort()
    {
        var allowSend = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var webSocket = new RecordingWebSocket
        {
            AllowSend = allowSend.Task,
            IgnoreAbortDuringSend = true,
        };
        var transaction = new VoiceSendTransaction(webSocket);
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
    public void ResponseTerminalBetweenBatchFramesAbortsCarrier()
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

        Assert.That(
            async () => await transaction.ExecuteAsync(
                new[]
                {
                    new VoiceFramePayload("response.created", new Dictionary<string, object?>()),
                    new VoiceFramePayload("response.output_text.delta", new Dictionary<string, object?>()),
                },
                static _ => ValueTask.FromResult(0),
                static _ => ValueTask.FromResult(true),
                CancellationToken.None,
                responseCancellation.Token),
            Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(1));
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
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

    private sealed class RecordingWebSocket : WebSocket
    {
        private readonly CancellationTokenSource _abortSignal = new();
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public int SendCount { get; private set; }

        public int AbortCount => Volatile.Read(ref _abortCount);

        public Exception? SendException { get; init; }

        public Task? AllowSend { get; init; }

        public bool ObserveCancellationBeforeSend { get; init; }

        public bool IgnoreAbortDuringSend { get; init; }

        public Action<int>? AfterSend { get; init; }

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
            SendStarted.TrySetResult();
            if (SendException is not null)
            {
                throw SendException;
            }

            if (AllowSend is not null)
            {
                try
                {
                    await AllowSend.WaitAsync(
                        IgnoreAbortDuringSend ? CancellationToken.None : _abortSignal.Token);
                }
                finally
                {
                    SendFinished.TrySetResult();
                }
            }

            AfterSend?.Invoke(SendCount);
        }

        public override void Dispose()
        {
            _state = WebSocketState.Closed;
            _abortSignal.Dispose();
        }
    }
}
