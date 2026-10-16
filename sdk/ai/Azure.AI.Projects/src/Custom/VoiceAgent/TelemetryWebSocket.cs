// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects;

// The OpenAI session's non-overridable Dispose calls WebSocket.Dispose, so the wrapper owns telemetry cleanup.
internal sealed class TelemetryWebSocket(WebSocket inner, VoiceAgentRealtimeTelemetry telemetry) : WebSocket
{
    private int _disposed;
    public override WebSocketCloseStatus? CloseStatus => inner.CloseStatus;
    public override string CloseStatusDescription => inner.CloseStatusDescription;
    public override WebSocketState State => inner.State;
    public override string SubProtocol => inner.SubProtocol;

    public override void Abort()
    {
        try
        {
            inner.Abort();
        }
        finally
        {
            telemetry.Close(inner.CloseStatus, false);
        }
    }

    public override void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }
        WebSocketCloseStatus? status = inner.CloseStatus;
        bool wasClean = inner.State == WebSocketState.Closed;
        try
        {
            inner.Dispose();
        }
        finally
        {
            telemetry.Close(status, wasClean);
        }
    }

    public override async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    {
        try
        {
            await inner.CloseAsync(closeStatus, statusDescription, cancellationToken).ConfigureAwait(false);
            telemetry.Close(inner.CloseStatus ?? closeStatus, inner.State == WebSocketState.Closed);
        }
        catch (Exception exception)
        {
            telemetry.TransportFailed(exception, false);
            throw;
        }
    }

    public override async Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    {
        try
        {
            await inner.CloseOutputAsync(closeStatus, statusDescription, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            telemetry.TransportFailed(exception, false);
            throw;
        }
    }

    public override async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    {
        WebSocketReceiveResult result;
        try
        {
            result = await inner.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            telemetry.TransportFailed(exception, false);
            throw;
        }
        if (result.MessageType == WebSocketMessageType.Close)
        {
            telemetry.Close(result.CloseStatus, inner.State == WebSocketState.Closed);
        }
        else if (result.MessageType == WebSocketMessageType.Text)
        {
            telemetry.ObserveFrame(new ArraySegment<byte>(buffer.Array, buffer.Offset, result.Count), result.EndOfMessage, false);
        }
        return result;
    }

    public override async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
    {
        try
        {
            await inner.SendAsync(buffer, messageType, endOfMessage, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            telemetry.TransportFailed(exception, true);
            throw;
        }
        if (messageType == WebSocketMessageType.Text)
        {
            telemetry.ObserveFrame(buffer, endOfMessage, true);
        }
    }
}
