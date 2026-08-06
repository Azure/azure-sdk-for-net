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
            Assert.That(webSocket.WasAborted, Is.False);
            Assert.That(inner.AbortCount, Is.Zero);
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
}
