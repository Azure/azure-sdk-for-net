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
    private WebSocketCloseAttempt? _closeAttempt;
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

    public int? AttemptedCloseCode => Volatile.Read(ref _closeAttempt)?.CloseCode;

    public WebSocketCloseAttemptApi AttemptApi =>
        Volatile.Read(ref _closeAttempt)?.Api ?? WebSocketCloseAttemptApi.None;

    public bool CloseOperationSucceeded =>
        Volatile.Read(ref _closeAttempt)?.State == WebSocketCloseAttemptState.Succeeded;

    public override WebSocketCloseStatus? CloseStatus => _inner.CloseStatus;

    public override string? CloseStatusDescription => _inner.CloseStatusDescription;

    public override WebSocketState State => _inner.State;

    public override string? SubProtocol => _inner.SubProtocol;

    public void TrySelectCloseCode(int closeCode) =>
        Interlocked.CompareExchange(ref _selectedCloseCode, closeCode, NoCloseCode);

    public override void Abort()
    {
        if (Interlocked.Exchange(ref _aborted, 1) == 0)
        {
            _inner.Abort();
        }
    }

    public override async Task CloseAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken)
    {
        var requestedCloseCode = (int)closeStatus;
        TrySelectCloseCode(requestedCloseCode);
        cancellationToken.ThrowIfCancellationRequested();
        var attemptedCloseCode = WebSocketTerminationResult.MapWireCloseCode(requestedCloseCode);
        var attempt = TryRecordCloseAttempt(attemptedCloseCode, WebSocketCloseAttemptApi.CloseAsync);
        CleanupDeadline.Start();
        using var deadlineCancellation = CleanupDeadline.CreateCancellationTokenSource();
        using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            deadlineCancellation.Token);
        try
        {
            await _inner.CloseAsync(
                (WebSocketCloseStatus)attemptedCloseCode,
                GetMappedDescription(requestedCloseCode, attemptedCloseCode, statusDescription),
                linkedCancellation.Token).ConfigureAwait(false);
            MarkCloseAttemptSucceeded(attempt);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            // Preserve the caller's cancellation attribution: rethrow with the
            // original request token so upstream identity checks classify this
            // as caller cancellation rather than an internal handler failure.
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            // The shared cleanup deadline expired; abort best-effort.
            Abort();
        }
        catch
        {
            MarkCloseAttemptFailed(attempt);
            throw;
        }
    }

    public override async Task CloseOutputAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken)
    {
        var requestedCloseCode = (int)closeStatus;
        TrySelectCloseCode(requestedCloseCode);
        cancellationToken.ThrowIfCancellationRequested();
        var attemptedCloseCode = WebSocketTerminationResult.MapWireCloseCode(requestedCloseCode);
        var attempt = TryRecordCloseAttempt(attemptedCloseCode, WebSocketCloseAttemptApi.CloseOutputAsync);
        CleanupDeadline.Start();
        using var deadlineCancellation = CleanupDeadline.CreateCancellationTokenSource();
        using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            deadlineCancellation.Token);
        try
        {
            await _inner.CloseOutputAsync(
                (WebSocketCloseStatus)attemptedCloseCode,
                GetMappedDescription(requestedCloseCode, attemptedCloseCode, statusDescription),
                linkedCancellation.Token).ConfigureAwait(false);
            MarkCloseAttemptSucceeded(attempt);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            // Preserve the caller's cancellation attribution: rethrow with the
            // original request token so upstream identity checks classify this
            // as caller cancellation rather than an internal handler failure.
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            // The shared cleanup deadline expired; abort best-effort.
            Abort();
        }
        catch
        {
            MarkCloseAttemptFailed(attempt);
            throw;
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

    private WebSocketCloseAttempt? TryRecordCloseAttempt(
        int closeCode,
        WebSocketCloseAttemptApi api)
    {
        while (true)
        {
            var current = Volatile.Read(ref _closeAttempt);
            if (current is not null && current.State != WebSocketCloseAttemptState.Failed)
            {
                return null;
            }

            var attempt = new WebSocketCloseAttempt(
                closeCode,
                api,
                WebSocketCloseAttemptState.InProgress);
            if (Interlocked.CompareExchange(ref _closeAttempt, attempt, current) == current)
            {
                return attempt;
            }
        }
    }

    private void MarkCloseAttemptSucceeded(WebSocketCloseAttempt? attempt)
    {
        if (attempt is null)
        {
            return;
        }

        var succeeded = attempt with { State = WebSocketCloseAttemptState.Succeeded };
        Interlocked.CompareExchange(ref _closeAttempt, succeeded, attempt);
    }

    private void MarkCloseAttemptFailed(WebSocketCloseAttempt? attempt)
    {
        if (attempt is null)
        {
            return;
        }

        var failed = attempt with { State = WebSocketCloseAttemptState.Failed };
        Interlocked.CompareExchange(ref _closeAttempt, failed, attempt);
    }

    private static string? GetMappedDescription(
        int requestedCloseCode,
        int attemptedCloseCode,
        string? statusDescription) =>
        requestedCloseCode != attemptedCloseCode &&
        attemptedCloseCode == InvocationsWebSocketConstants.CloseInternalError
            ? "Internal server error"
            : statusDescription;

    private sealed record WebSocketCloseAttempt(
        int CloseCode,
        WebSocketCloseAttemptApi Api,
        WebSocketCloseAttemptState State);

    private enum WebSocketCloseAttemptState
    {
        InProgress,
        Succeeded,
        Failed,
    }
}
