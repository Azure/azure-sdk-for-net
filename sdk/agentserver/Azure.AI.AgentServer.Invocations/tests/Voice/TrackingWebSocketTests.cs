// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class TrackingWebSocketTests
{
    [Test]
    public async Task CleanupDeadlineAbortIsObservableByEndpoint()
    {
        using var inner = new BlockingCloseWebSocket();
        using var webSocket = new TrackingWebSocket(inner, TimeSpan.FromMilliseconds(25));

        await webSocket.CloseAsync(
            WebSocketCloseStatus.PolicyViolation,
            "policy",
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(1008));
            Assert.That(webSocket.WasAborted, Is.True);
            Assert.That(inner.AbortCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void CallerCancellationPreservesTokenAndDoesNotMasqueradeAsDeadlineAbort()
    {
        using var inner = new BlockingCloseWebSocket();
        using var webSocket = new TrackingWebSocket(inner, TimeSpan.FromSeconds(1));
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        var exception = Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await webSocket.CloseOutputAsync(
                WebSocketCloseStatus.NormalClosure,
                "cancelled",
                cancellation.Token));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(webSocket.AttemptedCloseCode, Is.Null);
            Assert.That(webSocket.AttemptApi, Is.EqualTo(WebSocketCloseAttemptApi.None));
            Assert.That(webSocket.WasAborted, Is.False);
            Assert.That(inner.AbortCount, Is.Zero);
        });
    }

    [Test]
    public async Task SuccessfulRetryReplacesCancelledCloseAttempt()
    {
        using var inner = new CancelThenCompleteCloseWebSocket();
        using var webSocket = new TrackingWebSocket(inner, TimeSpan.FromSeconds(2));
        using var cancellation = new CancellationTokenSource();
        var first = webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "first",
            cancellation.Token);
        await inner.FirstCloseStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        await cancellation.CancelAsync();
        Assert.That(async () => await first, Throws.TypeOf<OperationCanceledException>());

        await webSocket.CloseAsync(
            WebSocketCloseStatus.PolicyViolation,
            "retry",
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.AttemptedCloseCode, Is.EqualTo(1008));
            Assert.That(webSocket.AttemptApi, Is.EqualTo(WebSocketCloseAttemptApi.CloseAsync));
            Assert.That(webSocket.CloseOperationSucceeded, Is.True);
        });
    }

    [Test]
    public async Task ReservedSelectedCodeIsMappedAndRecordedAsCloseOutputAttempt()
    {
        using var inner = new CompletingCloseWebSocket();
        using var webSocket = new TrackingWebSocket(inner, TimeSpan.FromSeconds(1));
        webSocket.TrySelectCloseCode(1006);

        await webSocket.CloseOutputAsync(
            (WebSocketCloseStatus)1006,
            "local abnormal status",
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(1006));
            Assert.That(webSocket.AttemptedCloseCode, Is.EqualTo(1011));
            Assert.That(webSocket.AttemptApi, Is.EqualTo(WebSocketCloseAttemptApi.CloseOutputAsync));
            Assert.That(webSocket.CloseOperationSucceeded, Is.True);
            Assert.That(inner.CloseOutputCode, Is.EqualTo(1011));
        });
    }

    [Test]
    public async Task FirstCloseAttemptCannotBeOverwritten()
    {
        using var inner = new CompletingCloseWebSocket();
        using var webSocket = new TrackingWebSocket(inner, TimeSpan.FromSeconds(1));

        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "first",
            CancellationToken.None);
        await webSocket.CloseAsync(
            WebSocketCloseStatus.PolicyViolation,
            "second",
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(1000));
            Assert.That(webSocket.AttemptedCloseCode, Is.EqualTo(1000));
            Assert.That(webSocket.AttemptApi, Is.EqualTo(WebSocketCloseAttemptApi.CloseOutputAsync));
        });
    }

    private sealed class BlockingCloseWebSocket : WebSocket
    {
        private int _abortCount;
        private WebSocketState _state = WebSocketState.Open;

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

        public override async Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);

        public override async Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override void Dispose() => _state = WebSocketState.Closed;
    }

    private sealed class CompletingCloseWebSocket : WebSocket
    {
        private WebSocketState _state = WebSocketState.Open;

        public int? CloseOutputCode { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort() => _state = WebSocketState.Aborted;

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
            CloseOutputCode = (int)closeStatus;
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override void Dispose() => _state = WebSocketState.Closed;
    }

    private sealed class CancelThenCompleteCloseWebSocket : WebSocket
    {
        private int _closeCalls;
        private WebSocketState _state = WebSocketState.Open;

        public TaskCompletionSource FirstCloseStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort() => _state = WebSocketState.Aborted;

        public override async Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            if (Interlocked.Increment(ref _closeCalls) == 1)
            {
                FirstCloseStarted.TrySetResult();
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            }

            _state = WebSocketState.Closed;
        }

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseAsync(closeStatus, statusDescription, cancellationToken);

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override void Dispose() => _state = WebSocketState.Closed;
    }
}
