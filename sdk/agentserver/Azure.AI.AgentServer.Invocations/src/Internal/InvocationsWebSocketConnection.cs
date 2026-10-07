// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal readonly record struct InvocationsWebSocketCloseResult(
    WebSocketCloseStatus? Status,
    string Reason,
    string? ErrorCode,
    Exception? Exception,
    Exception? CleanupException = null,
    Exception? CloseException = null)
{
    internal int Code => Status is null ? 1006 : (int)Status.Value;
}

/// <summary>Serializes application frames and the final close frame.</summary>
internal sealed class InvocationsWebSocketConnection
{
    private static readonly TimeSpan DefaultCloseTimeout = TimeSpan.FromSeconds(5);
    private static readonly object SendFailureMarker = new();
    private readonly WebSocket _webSocket;
    private readonly TimeSpan _closeTimeout;
    private readonly SemaphoreSlim _writeGate = new(1, 1);
    private readonly ConditionalWeakTable<Exception, object> _sendFailures = new();
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
            try
            {
                await _webSocket.SendAsync(
                    payload,
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
                when (exception is WebSocketException or IOException or ObjectDisposedException ||
                      (exception is OperationCanceledException && !cancellationToken.IsCancellationRequested))
            {
                _sendFailures.GetValue(exception, static _ => SendFailureMarker);
                throw;
            }
        }
        finally
        {
            _writeGate.Release();
        }
    }

    internal bool IsSendFailure(Exception exception) =>
        _sendFailures.TryGetValue(exception, out _);

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
                    return CreateCloseTimeoutException();
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
                    return CreateCloseTimeoutException();
                }
            }
            else if (status is null)
            {
                TryAbort();
            }

            return null;
        }
        catch (OperationCanceledException) when (acquired && closeCancellation.IsCancellationRequested)
        {
            TryAbort();
            return CreateCloseTimeoutException();
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

    private static TimeoutException CreateCloseTimeoutException() =>
        new("Timed out closing the Voice WebSocket connection.");

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
