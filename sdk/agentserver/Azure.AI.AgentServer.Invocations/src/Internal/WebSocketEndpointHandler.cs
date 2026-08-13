// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        var registeredVoiceHandler = httpContext.RequestServices.GetService<VoiceHandler>();
        if (registeredVoiceHandler is not null &&
            !ReferenceEquals(handler, registeredVoiceHandler))
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.Headers[PlatformHeaders.ErrorSource] =
                PlatformHeaders.ErrorSourcePlatform;
            return;
        }

        // If the handler does not derive from InvocationWebSocketHandler, refuse
        // the upgrade with HTTP 404 — "endpoint not registered" semantics so a
        // missing handler fails fast instead of accepting and immediately closing.
        if (handler is not InvocationWebSocketHandler webSocketHandler)
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

        // Reuse the same query → environment → UUID precedence as POST
        // /invocations. Bridge reconnects supply the stable agent_session_id on
        // each new WebSocket upgrade.
        var sessionId = SessionIdResolver.Resolve(httpContext.Request);

        // WebSocket has no per-message invocation ID — synthesise one so the
        // context contract (which requires a non-empty InvocationId) holds.
        var invocationId = Guid.NewGuid().ToString();

        var clientHeaders = ClientHeaderForwarder.ExtractClientHeaders(httpContext.Request);
        var queryParams = ClientHeaderForwarder.ExtractQueryParameters(httpContext.Request);
        var platformContext = PlatformContext.FromRequest(httpContext.Request);
        var context = new InvocationContext(invocationId, sessionId, clientHeaders, queryParams, platformContext);

        // Propagate invocation/session/x-request-id baggage onto the current request
        // Activity for downstream correlation. Reuses the same helper the HTTP
        // `POST /invocations` endpoint uses so HTTP and WS paths produce
        // the same baggage shape. No framework-level WS span is created — ASP.NET
        // Core auto-propagates the inbound W3C trace context to the request
        // Activity, so any spans the handler starts inherit it directly.
        _activitySource.PropagateInvocationBaggage(context, httpContext.Request.Headers);

        using var logScope = TryBeginScope(new Dictionary<string, object>
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
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
                errorCode = InvocationsWebSocketConstants.ErrorCodeAcceptFailed;
                TryLogError(
                    acceptEx,
                    "WebSocket accept failed for session {SessionId}",
                    sessionId);
                throw;
            }

            if (webSocketHandler is VoiceHandler voiceHandler)
            {
                var connection = new InvocationsWebSocketConnection(webSocket);
                var outcome = await voiceHandler.HandleWebSocketConnectionAsync(
                    connection,
                    context,
                    httpContext.RequestAborted);
                closeCode = outcome.Code;
                errorCode = outcome.ErrorCode;
                var closeException = await connection.CloseAsync(outcome.Status, outcome.Reason);
                webSocket = null;

                if (outcome.Exception is not null)
                {
                    TryLogError(
                        outcome.Exception,
                        "Voice connection failed for session {SessionId}",
                        sessionId);
                }
                if (outcome.CleanupException is not null)
                {
                    TryLogError(
                        outcome.CleanupException,
                        "Voice cleanup callback raised for session {SessionId}",
                        sessionId);
                }
                if (closeException is not null)
                {
                    TryLogDebug(
                        closeException,
                        "Error closing WebSocket session {SessionId}",
                        sessionId);
                }
            }
            else
            {
                try
                {
                    await webSocketHandler.HandleWebSocketAsync(
                        webSocket,
                        context,
                        httpContext.RequestAborted);
                }
                catch (OperationCanceledException oce)
                    when (oce.CancellationToken == httpContext.RequestAborted
                          && httpContext.RequestAborted.IsCancellationRequested)
                {
                    closeCode = InvocationsWebSocketConstants.CloseNormal;
                }
                catch (Exception exception)
                {
                    closeCode = InvocationsWebSocketConstants.CloseInternalError;
                    errorCode = InvocationsWebSocketConstants.ErrorCodeInternalError;
                    TryLogError(
                        exception,
                        "WebSocket handler raised for session {SessionId}",
                        sessionId);
                }
            }
        }
        finally
        {
            var durationMs = GetElapsedMilliseconds(startTimestamp);
            await CloseSocketAsync(webSocket, closeCode, sessionId);

            try
            {
                EmitCloseEventLog(sessionId, closeCode, durationMs, errorCode);
            }
            catch
            {
                // Telemetry is observational and cannot alter transport finalization.
            }
        }
    }

    private async Task CloseSocketAsync(
        WebSocket? webSocket,
        int closeCode,
        string sessionId)
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
            TryLogDebug(ex, "Error closing WebSocket session {SessionId}", sessionId);
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

    private void TryLogError(Exception exception, string message, string sessionId)
    {
        try
        {
            _logger.LogError(exception, message, sessionId);
        }
        catch
        {
            // Telemetry callbacks cannot alter connection finalization.
        }
    }

    private void TryLogDebug(Exception exception, string message, string sessionId)
    {
        try
        {
            _logger.LogDebug(exception, message, sessionId);
        }
        catch
        {
            // Telemetry callbacks cannot alter connection finalization.
        }
    }

    private IDisposable TryBeginScope(IReadOnlyDictionary<string, object> state)
    {
        try
        {
            return new SafeLogScope(_logger.BeginScope(state));
        }
        catch
        {
            return SafeLogScope.Empty;
        }
    }

    private sealed class SafeLogScope : IDisposable
    {
        internal static SafeLogScope Empty { get; } = new(null);

        private IDisposable? _inner;

        internal SafeLogScope(IDisposable? inner) => _inner = inner;

        public void Dispose()
        {
            var inner = Interlocked.Exchange(ref _inner, null);
            try
            {
                inner?.Dispose();
            }
            catch
            {
                // Logging scope disposal is observational only.
            }
        }
    }
}
