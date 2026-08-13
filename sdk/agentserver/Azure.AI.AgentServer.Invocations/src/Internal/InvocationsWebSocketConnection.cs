// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>Serializes application frames and the final close frame.</summary>
internal sealed class InvocationsWebSocketConnection
{
    private static readonly TimeSpan DefaultCloseTimeout = TimeSpan.FromSeconds(5);
    private readonly WebSocket _webSocket;
    private readonly TimeSpan _closeTimeout;
    private readonly SemaphoreSlim _writeGate = new(1, 1);
    private int _terminating;
    private int _disposed;

    internal InvocationsWebSocketConnection(WebSocket webSocket, TimeSpan? closeTimeout = null)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _closeTimeout = closeTimeout ?? DefaultCloseTimeout;
        if (_closeTimeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(closeTimeout));
        }
    }

    internal WebSocketCloseStatus? PeerCloseStatus => _webSocket.CloseStatus;

    internal string? PeerCloseStatusDescription => _webSocket.CloseStatusDescription;

    internal ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(
        Memory<byte> buffer,
        CancellationToken cancellationToken) => _webSocket.ReceiveAsync(buffer, cancellationToken);

    internal async Task SendTextAsync(ReadOnlyMemory<byte> payload, CancellationToken cancellationToken)
    {
        ThrowIfTerminating();
        await _writeGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            ThrowIfTerminating();
            await _webSocket.SendAsync(
                payload,
                WebSocketMessageType.Text,
                endOfMessage: true,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _writeGate.Release();
        }
    }

    internal void StopSending() => Interlocked.Exchange(ref _terminating, 1);

    internal async Task<Exception?> CloseAsync(
        WebSocketCloseStatus? status,
        string reason)
    {
        StopSending();
        var started = Stopwatch.GetTimestamp();
        using var closeCancellation = new CancellationTokenSource(_closeTimeout);
        var acquired = false;
        try
        {
            await _writeGate.WaitAsync(closeCancellation.Token).ConfigureAwait(false);
            acquired = true;
            if (status is not null &&
                _webSocket.State is WebSocketState.Open or WebSocketState.CloseReceived)
            {
                var remaining = _closeTimeout - Stopwatch.GetElapsedTime(started);
                if (remaining <= TimeSpan.Zero)
                {
                    TryAbort();
                    return null;
                }
                var closeTask = _webSocket.CloseOutputAsync(
                    status.Value,
                    reason,
                    closeCancellation.Token);
                var deadline = Task.Delay(remaining, CancellationToken.None);
                if (await Task.WhenAny(closeTask, deadline).ConfigureAwait(false) == closeTask)
                {
                    await closeTask.ConfigureAwait(false);
                }
                else
                {
                    TryAbort();
                    ObserveLateTask(closeTask);
                }
            }
            else if (status is null)
            {
                TryAbort();
            }

            return null;
        }
        catch (Exception exception)
        {
            TryAbort();
            return exception;
        }
        finally
        {
            if (acquired)
            {
                _writeGate.Release();
            }
            DisposeSocket();
        }
    }

    private void ThrowIfTerminating()
    {
        if (Volatile.Read(ref _terminating) != 0)
        {
            throw new InvalidOperationException("The Voice connection is terminating.");
        }
    }

    private void TryAbort()
    {
        try
        {
            _webSocket.Abort();
        }
        catch
        {
        }
    }

    private void DisposeSocket()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        try
        {
            _webSocket.Dispose();
        }
        catch
        {
        }
    }

    private static void ObserveLateTask(Task task)
    {
        _ = task.ContinueWith(
            static completed => { _ = completed.Exception; },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }
}
