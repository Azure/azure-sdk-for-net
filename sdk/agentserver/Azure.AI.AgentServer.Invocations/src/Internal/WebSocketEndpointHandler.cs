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
/// WebSocket lifecycle: accept → dispatch → close-with-mapped-code →
/// structured close-event log line.
/// </summary>
/// <remarks>
/// No framework-level OpenTelemetry span is created for the connection.
/// ASP.NET Core automatically propagates the inbound W3C trace context to
/// the request <see cref="Activity"/>, so any spans the user handler starts
/// inside <c>HandleWebSocketAsync</c> are parented correctly without a
/// per-connection wrapper span. Telemetry for the connection is delivered
/// as a single structured close-event log line carrying
/// <c>azure.ai.agentserver.invocations_ws.session_id</c>,
/// <c>azure.ai.agentserver.invocations_ws.close_code</c>, and
/// <c>azure.ai.agentserver.invocations_ws.duration_ms</c>.
/// </remarks>
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
        // with HTTP 404. The route is mapped unconditionally so this short-circuit
        // — equivalent to "endpoint not registered" — keeps the upgrade decision
        // colocated with the handler-capability check.
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
        // the platform does not inject one. Matches the HTTP precedence used by
        // POST /invocations (minus the agent_session_id query-param override,
        // which has no ergonomic equivalent on a long-lived WS connection).
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

        // Propagate invocation/session/x-request-id baggage onto the current request
        // Activity for downstream correlation. Reuses the same helper the HTTP
        // `POST /invocations` endpoint uses so HTTP and WS paths produce
        // the same baggage shape. No framework-level WS span is created — ASP.NET
        // Core auto-propagates the inbound W3C trace context to the request
        // Activity, so any spans the handler starts inherit it directly.
        _activitySource.PropagateInvocationBaggage(context, httpContext.Request.Headers);

        using var logScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["SessionId"] = sessionId,
            ["InvocationId"] = invocationId,
        });

        var startTimestamp = Stopwatch.GetTimestamp();
        var closeCode = InvocationsWebSocketConstants.CloseNormal;
        string? errorCode = null;
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
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
                errorCode = InvocationsWebSocketConstants.ErrorCodeAcceptFailed;
                throw;
            }

            try
            {
                await handler.HandleWebSocketAsync(webSocket, context, httpContext.RequestAborted);
            }
            catch (OperationCanceledException oce)
                when (oce.CancellationToken == httpContext.RequestAborted
                      && httpContext.RequestAborted.IsCancellationRequested)
            {
                // Connection aborted (client disconnect / server shutdown). Treat
                // as a clean close — the socket is already gone, so emit a normal
                // close event and let the caller observe the cancellation.
                //
                // The token-identity check (`oce.CancellationToken == httpContext.RequestAborted`)
                // distinguishes shutdown-driven cancellation from a handler-internal
                // OperationCanceledException (e.g., a handler's own timeout CTS firing
                // concurrently with shutdown) — those should still surface as close
                // code 1011 so real handler bugs aren't masked.
                closeCode = InvocationsWebSocketConstants.CloseNormal;
            }
            catch (Exception ex)
            {
                // Handler exception details flow through this LogError(...) only —
                // they are deliberately NOT included in the close-event log line
                // so application stack traces never leak into the structured
                // metric stream.
                _logger.LogError(
                    ex,
                    "WebSocket handler raised for session {SessionId}",
                    sessionId);
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
                errorCode = InvocationsWebSocketConstants.ErrorCodeInternalError;
            }
        }
        finally
        {
            var durationMs = GetElapsedMilliseconds(startTimestamp);
            await CloseSocketAsync(webSocket, closeCode, sessionId);
            EmitCloseEventLog(sessionId, closeCode, durationMs, errorCode);
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

    // Templates that pin the structured-log field names to the documented
    // cross-SDK contract keys defined on InvocationsWebSocketConstants.
    // Concatenation here is a compile-time fold over const strings, so the
    // template is still a constant for analyzers like CA2254.
    private const string CloseEventTemplate =
        "invocations_ws connection closed: session_id={" + InvocationsWebSocketConstants.AttrSpanSessionId +
        "} close_code={" + InvocationsWebSocketConstants.AttrSpanCloseCode +
        "} duration_ms={" + InvocationsWebSocketConstants.AttrSpanDurationMs + "}";

    private const string CloseEventTemplateWithError =
        "invocations_ws connection closed: session_id={" + InvocationsWebSocketConstants.AttrSpanSessionId +
        "} close_code={" + InvocationsWebSocketConstants.AttrSpanCloseCode +
        "} duration_ms={" + InvocationsWebSocketConstants.AttrSpanDurationMs +
        "} error_code={" + InvocationsWebSocketConstants.AttrSpanErrorCode + "}";

    private void EmitCloseEventLog(string sessionId, int closeCode, long durationMs, string? errorCode)
    {
        // Single structured close-event log line. The message-template
        // placeholder names ARE the structured-log field names downstream
        // consumers see, so we use the dotted names defined on
        // InvocationsWebSocketConstants to honour the cross-SDK wire
        // contract (e.g., `azure.ai.agentserver.invocations_ws.session_id`).
        // Exception details (when an error_code is set) are NOT included here;
        // they flow through LogError(ex, ...) at the call site instead, by
        // contract: application stack traces must never leak into the
        // structured close-event log line.
        if (errorCode is null)
        {
            _logger.LogInformation(
                CloseEventTemplate,
                sessionId,
                closeCode,
                durationMs);
        }
        else
        {
            _logger.LogInformation(
                CloseEventTemplateWithError,
                sessionId,
                closeCode,
                durationMs,
                errorCode);
        }
    }
}