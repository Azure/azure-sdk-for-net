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
    private readonly bool _ownsTelemetryDispatcher;
    private int _selectedCloseCode = NoCloseCode;
    private int _aborted;
    private int _disposed;

    public TrackingWebSocket(
        WebSocket inner,
        TimeSpan cleanupBudget,
        TelemetryCallbackDispatcher? telemetryDispatcher = null)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        CleanupDeadline = new CleanupDeadline(cleanupBudget);
        TelemetryDispatcher = telemetryDispatcher ?? new TelemetryCallbackDispatcher();
        ConnectionActivityContext = new ConnectionActivityContextProvider();
        _ownsTelemetryDispatcher = telemetryDispatcher is null;
    }

    public CleanupDeadline CleanupDeadline { get; }

    public TelemetryCallbackDispatcher TelemetryDispatcher { get; }

    public ConnectionActivityContextProvider ConnectionActivityContext { get; }

    public int? SelectedCloseCode
    {
        get
        {
            var value = Volatile.Read(ref _selectedCloseCode);
            return value == NoCloseCode ? null : value;
        }
    }

    public bool WasAborted => Volatile.Read(ref _aborted) != 0;

    public override WebSocketCloseStatus? CloseStatus => _inner.CloseStatus;

    public override string? CloseStatusDescription => _inner.CloseStatusDescription;

    public override WebSocketState State => _inner.State;

    public override string? SubProtocol => _inner.SubProtocol;

    public void RecordCloseCode(int closeCode) =>
        Interlocked.CompareExchange(ref _selectedCloseCode, closeCode, NoCloseCode);

    public override void Abort()
    {
        Volatile.Write(ref _aborted, 1);
        _inner.Abort();
    }

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
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Preserve the caller's cancellation attribution: rethrow with the
            // original request token so upstream identity checks classify this
            // as caller cancellation rather than an internal handler failure.
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            // The shared cleanup deadline expired; abort best-effort.
            Abort();
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
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Preserve the caller's cancellation attribution: rethrow with the
            // original request token so upstream identity checks classify this
            // as caller cancellation rather than an internal handler failure.
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            // The shared cleanup deadline expired; abort best-effort.
            Abort();
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
            try
            {
                _inner.Dispose();
            }
            finally
            {
                if (_ownsTelemetryDispatcher)
                {
                    TelemetryDispatcher.Dispose();
                }
            }
        }
    }
}
