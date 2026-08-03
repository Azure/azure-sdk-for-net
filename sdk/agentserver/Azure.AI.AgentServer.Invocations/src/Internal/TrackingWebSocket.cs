// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Transparent WebSocket wrapper that shares terminal deadline and selected
/// close-code state between the transport endpoint and typed protocol layers.
/// </summary>
internal sealed class TrackingWebSocket : WebSocket
{
    private const int NoCloseCode = -1;

    private readonly WebSocket _inner;
    private int _selectedCloseCode = NoCloseCode;
    private int _disposed;

    public TrackingWebSocket(WebSocket inner, TimeSpan cleanupBudget)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        CleanupDeadline = new CleanupDeadline(cleanupBudget);
    }

    public CleanupDeadline CleanupDeadline { get; }

    public int? SelectedCloseCode
    {
        get
        {
            var value = Volatile.Read(ref _selectedCloseCode);
            return value == NoCloseCode ? null : value;
        }
    }

    public override WebSocketCloseStatus? CloseStatus => _inner.CloseStatus;

    public override string? CloseStatusDescription => _inner.CloseStatusDescription;

    public override WebSocketState State => _inner.State;

    public override string? SubProtocol => _inner.SubProtocol;

    public void RecordCloseCode(int closeCode) =>
        Interlocked.CompareExchange(ref _selectedCloseCode, closeCode, NoCloseCode);

    public override void Abort() => _inner.Abort();

    public override async Task CloseAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken)
    {
        RecordCloseCode((int)closeStatus);
        CleanupDeadline.Start();
        using var deadlineCancellation = CleanupDeadline.CreateCancellationTokenSource();
        using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            deadlineCancellation.Token);
        try
        {
            await _inner.CloseAsync(closeStatus, statusDescription, linkedCancellation.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (
            deadlineCancellation.IsCancellationRequested &&
            !cancellationToken.IsCancellationRequested)
        {
            _inner.Abort();
        }
    }

    public override async Task CloseOutputAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken)
    {
        RecordCloseCode((int)closeStatus);
        CleanupDeadline.Start();
        using var deadlineCancellation = CleanupDeadline.CreateCancellationTokenSource();
        using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            deadlineCancellation.Token);
        try
        {
            await _inner.CloseOutputAsync(closeStatus, statusDescription, linkedCancellation.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (
            deadlineCancellation.IsCancellationRequested &&
            !cancellationToken.IsCancellationRequested)
        {
            _inner.Abort();
        }
    }

    public override Task<WebSocketReceiveResult> ReceiveAsync(
        ArraySegment<byte> buffer,
        CancellationToken cancellationToken) =>
        _inner.ReceiveAsync(buffer, cancellationToken);

    public override Task SendAsync(
        ArraySegment<byte> buffer,
        WebSocketMessageType messageType,
        bool endOfMessage,
        CancellationToken cancellationToken) =>
        _inner.SendAsync(buffer, messageType, endOfMessage, cancellationToken);

    public override void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            _inner.Dispose();
        }
    }
}
