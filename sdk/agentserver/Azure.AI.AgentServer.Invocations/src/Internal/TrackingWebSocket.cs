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

    public override Task CloseAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken) =>
        ExecuteCloseAsync(
            _inner.CloseAsync,
            closeStatus,
            statusDescription,
            WebSocketCloseAttemptApi.CloseAsync,
            cancellationToken);

    public override Task CloseOutputAsync(
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        CancellationToken cancellationToken) =>
        ExecuteCloseAsync(
            _inner.CloseOutputAsync,
            closeStatus,
            statusDescription,
            WebSocketCloseAttemptApi.CloseOutputAsync,
            cancellationToken);

    private async Task ExecuteCloseAsync(
        Func<WebSocketCloseStatus, string?, CancellationToken, Task> closeAsync,
        WebSocketCloseStatus closeStatus,
        string? statusDescription,
        WebSocketCloseAttemptApi attemptApi,
        CancellationToken cancellationToken)
    {
        var requestedCloseCode = (int)closeStatus;
        TrySelectCloseCode(requestedCloseCode);
        cancellationToken.ThrowIfCancellationRequested();
        var attemptedCloseCode = WebSocketTerminationResult.MapWireCloseCode(requestedCloseCode);
        var attempt = TryRecordCloseAttempt(attemptedCloseCode, attemptApi);
        CleanupDeadline.Start();
        var deadlineCancellation = CleanupDeadline.CreateCancellationTokenSource();
        var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            deadlineCancellation.Token);
        Task closeTask;
        try
        {
            closeTask = closeAsync(
                (WebSocketCloseStatus)attemptedCloseCode,
                GetMappedDescription(requestedCloseCode, attemptedCloseCode, statusDescription),
                linkedCancellation.Token) ?? throw new InvalidOperationException(
                    "The inner WebSocket close returned a null task.");
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            linkedCancellation.Dispose();
            deadlineCancellation.Dispose();
            MarkCloseAttemptFailed(attempt);
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            linkedCancellation.Dispose();
            deadlineCancellation.Dispose();
            MarkCloseAttemptFailed(attempt);
            Abort();
            return;
        }
        catch
        {
            linkedCancellation.Dispose();
            deadlineCancellation.Dispose();
            MarkCloseAttemptFailed(attempt);
            throw;
        }

        var detached = false;
        try
        {
            await closeTask.WaitAsync(linkedCancellation.Token).ConfigureAwait(false);
            MarkCloseAttemptSucceeded(attempt);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            detached = !closeTask.IsCompleted;
            if (detached)
            {
                ObserveDetachedClose(closeTask, linkedCancellation, deadlineCancellation);
            }
            throw new OperationCanceledException(cancellationToken);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
            MarkCloseAttemptFailed(attempt);
            detached = !closeTask.IsCompleted;
            if (detached)
            {
                ObserveDetachedClose(closeTask, linkedCancellation, deadlineCancellation);
            }
            Abort();
        }
        catch
        {
            MarkCloseAttemptFailed(attempt);
            throw;
        }
        finally
        {
            if (!detached)
            {
                linkedCancellation.Dispose();
                deadlineCancellation.Dispose();
            }
        }
    }

    private static void ObserveDetachedClose(
        Task closeTask,
        CancellationTokenSource linkedCancellation,
        CancellationTokenSource deadlineCancellation) =>
        _ = ObserveDetachedCloseAsync(closeTask, linkedCancellation, deadlineCancellation);

    private static async Task ObserveDetachedCloseAsync(
        Task closeTask,
        CancellationTokenSource linkedCancellation,
        CancellationTokenSource deadlineCancellation)
    {
        try
        {
            await closeTask.ConfigureAwait(false);
        }
#pragma warning disable CA1031 // Detached transport completion is observed after endpoint finalization.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
        finally
        {
            linkedCancellation.Dispose();
            deadlineCancellation.Dispose();
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
