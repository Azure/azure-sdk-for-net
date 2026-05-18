// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// ASP.NET Core endpoint handler that owns the <c>/invocations_ws</c>
/// WebSocket lifecycle. Mirrors the Python <c>_WSHandlerMixin._ws_endpoint</c>:
/// accept → dispatch → close-with-mapped-code → structured close-event log
/// + OpenTelemetry span attributes.
/// </summary>
internal sealed class WebSocketEndpointHandler
{
    private const string SessionIdResponseHeader = PlatformHeaders.SessionId;

    private readonly InvocationsActivitySource _activitySource;
    private readonly ILogger<WebSocketEndpointHandler> _logger;

    public WebSocketEndpointHandler(
        InvocationsActivitySource activitySource,
        ILogger<WebSocketEndpointHandler> logger)
    {
        _activitySource = activitySource;
        _logger = logger;
    }

    /// <summary>
    /// Handles a connection on <c>/invocations_ws</c>.
    /// </summary>
    internal async Task HandleAsync(HttpContext httpContext, InvocationHandler handler)
    {
        // If the handler has not opted in to the WS protocol, refuse the upgrade
        // with HTTP 404 — equivalent to Python's "route not registered" 404 when
        // no @ws_handler has been decorated.
        if (!InvocationHandlerCapabilities.SupportsWebSocket(handler.GetType()))
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        // Reject non-WebSocket requests with 400 — matches Kestrel's behavior
        // on endpoints that exclusively serve WebSocket upgrades.
        if (!httpContext.WebSockets.IsWebSocketRequest)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        // Per-connection identifiers. Honour the platform-injected
        // FOUNDRY_AGENT_SESSION_ID so HTTP and WebSocket transports on the same
        // container report the same session ID; fall back to a fresh UUID when
        // the platform does not inject one. Matches the Python behavior.
        var sessionId = !string.IsNullOrEmpty(FoundryEnvironment.SessionId)
            ? FoundryEnvironment.SessionId!
            : Guid.NewGuid().ToString();

        // WebSocket has no per-message invocation ID — synthesise one so the
        // context contract (which requires a non-empty InvocationId) holds.
        var invocationId = Guid.NewGuid().ToString();

        var clientHeaders = ClientHeaderForwarder.ExtractClientHeaders(httpContext.Request);
        var queryParams = ClientHeaderForwarder.ExtractQueryParameters(httpContext.Request);
        var isolation = IsolationContext.FromRequest(httpContext.Request);
        var context = new InvocationContext(invocationId, sessionId, clientHeaders, queryParams, isolation);

        // Surface the session ID on the upgrade response headers so clients can
        // correlate the connection without having to parse the close frame.
        if (!string.IsNullOrEmpty(sessionId))
        {
            httpContext.Response.Headers[SessionIdResponseHeader] = sessionId;
        }

        // Open the OTel span before accept so any tracecontext header the client
        // sent parents child spans inside the user handler.
        using var activity = _activitySource.StartWebSocketSessionActivity(context, httpContext.Request.Headers);

        using var logScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["SessionId"] = sessionId,
            ["InvocationId"] = invocationId,
        });

        var startTimestamp = Stopwatch.GetTimestamp();
        var closeCode = InvocationsWebSocketConstants.CloseNormal;
        Exception? handlerException = null;
        WebSocket? webSocket = null;

        try
        {
            try
            {
                webSocket = await httpContext.WebSockets.AcceptWebSocketAsync();
            }
            catch (Exception acceptEx)
            {
                _logger.LogError(
                    acceptEx,
                    "WebSocket accept failed for session {SessionId}",
                    sessionId);
                RecordWebSocketCloseAttributes(
                    activity,
                    sessionId,
                    InvocationsWebSocketConstants.CloseInternalError,
                    GetElapsedMilliseconds(startTimestamp),
                    InvocationsWebSocketConstants.ErrorCodeAcceptFailed,
                    acceptEx.Message);
                InvocationsExceptionFilter.RecordException(activity, acceptEx);
                throw;
            }

            try
            {
                await handler.HandleWebSocketAsync(webSocket, context, httpContext.RequestAborted);
            }
            catch (OperationCanceledException) when (httpContext.RequestAborted.IsCancellationRequested)
            {
                // Connection aborted (client disconnect / server shutdown). Treat
                // as a clean close — the socket is already gone, no exception to
                // record on the span.
                closeCode = InvocationsWebSocketConstants.CloseNormal;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "WebSocket handler raised for session {SessionId}",
                    sessionId);
                handlerException = ex;
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
            }
        }
        finally
        {
            var durationMs = GetElapsedMilliseconds(startTimestamp);
            await CloseSocketAsync(webSocket, closeCode, sessionId);
            RecordWebSocketCloseAttributes(
                activity,
                sessionId,
                closeCode,
                durationMs,
                handlerException is not null ? InvocationsWebSocketConstants.ErrorCodeInternalError : null,
                handlerException?.Message);
            if (handlerException is not null)
            {
                InvocationsExceptionFilter.RecordException(activity, handlerException);
            }
            EmitCloseEventLog(sessionId, closeCode, durationMs);
        }
    }

    private async Task CloseSocketAsync(WebSocket? webSocket, int closeCode, string sessionId)
    {
        if (webSocket is null)
        {
            return;
        }

        // Only send a close frame if neither side has already done so. The user
        // handler may have called CloseAsync itself, or the client may have
        // disconnected mid-stream — both leave the socket in a state where a
        // server-initiated close is either redundant or invalid.
        if (webSocket.State is WebSocketState.Closed or WebSocketState.CloseSent or WebSocketState.Aborted)
        {
            webSocket.Dispose();
            return;
        }

        var status = closeCode == InvocationsWebSocketConstants.CloseInternalError
            ? WebSocketCloseStatus.InternalServerError
            : WebSocketCloseStatus.NormalClosure;
        var description = closeCode == InvocationsWebSocketConstants.CloseInternalError
            ? "Internal server error"
            : string.Empty;

        try
        {
            await webSocket.CloseAsync(status, description, CancellationToken.None);
        }
        catch (Exception ex) when (ex is WebSocketException or ObjectDisposedException or OperationCanceledException)
        {
            // Connection already gone — nothing to recover.
            _logger.LogDebug(ex, "Error closing WebSocket session {SessionId}", sessionId);
        }
        finally
        {
            webSocket.Dispose();
        }
    }

    private static long GetElapsedMilliseconds(long startTimestamp)
    {
        return (long)Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    }

    private static void RecordWebSocketCloseAttributes(
        Activity? activity,
        string sessionId,
        int closeCode,
        long durationMs,
        string? errorCode,
        string? errorMessage)
    {
        if (activity is null)
        {
            return;
        }

        activity.SetTag(InvocationsWebSocketConstants.AttrSpanSessionId, sessionId);
        activity.SetTag(InvocationsWebSocketConstants.AttrSpanCloseCode, closeCode);
        activity.SetTag(InvocationsWebSocketConstants.AttrSpanDurationMs, durationMs);

        if (!string.IsNullOrEmpty(errorCode))
        {
            activity.SetTag(InvocationsWebSocketConstants.AttrSpanErrorCode, errorCode);
        }
        if (!string.IsNullOrEmpty(errorMessage))
        {
            activity.SetTag(InvocationsWebSocketConstants.AttrSpanErrorMessage, errorMessage);
        }
    }

    private void EmitCloseEventLog(string sessionId, int closeCode, long durationMs)
    {
        // Match Python's structured close-event line. The dotted attribute names
        // line up 1:1 with the OTel span attributes so log <-> trace
        // correlation in OTel logging bridges is trivial.
        _logger.LogInformation(
            "invocations_ws connection closed: session_id={SessionId} close_code={CloseCode} duration_ms={DurationMs}",
            sessionId,
            closeCode,
            durationMs);
    }
}
