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
/// ASP.NET Core propagates the inbound W3C trace context to the request
/// <see cref="Activity"/>. The endpoint creates an <c>agentserver.connection</c>
/// child activity spanning the accepted socket through bounded close, and also
/// emits a structured close-event log line carrying
/// <c>azure.ai.agentserver.invocations_ws.session_id</c>,
/// <c>azure.ai.agentserver.invocations_ws.close_code</c>, and
/// <c>azure.ai.agentserver.invocations_ws.duration_ms</c>.
/// </remarks>
internal sealed class WebSocketEndpointHandler
{
    private const string SessionIdResponseHeader = PlatformHeaders.SessionId;
    private static readonly TimeSpan TelemetryStartTimeout = TimeSpan.FromMilliseconds(100);

    private readonly InvocationsActivitySource _activitySource;
    private readonly TelemetryCallbackDispatcher _telemetryDispatcher;
    private readonly ILogger<WebSocketEndpointHandler> _logger;

    public WebSocketEndpointHandler(
        InvocationsActivitySource activitySource,
        TelemetryCallbackDispatcher telemetryDispatcher,
        ILogger<WebSocketEndpointHandler> logger)
    {
        _activitySource = activitySource;
        _telemetryDispatcher = telemetryDispatcher;
        _logger = logger;
    }

    /// <summary>
    /// Handles a connection on <c>/invocations_ws</c>.
    /// </summary>
    internal async Task HandleAsync(HttpContext httpContext, InvocationHandler handler)
    {
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
        var platformContext = PlatformContext.FromRequest(httpContext.Request);
        var context = new InvocationContext(invocationId, sessionId, clientHeaders, queryParams, platformContext);

        // Surface the session ID on the upgrade response headers so clients can
        // correlate the connection without having to parse the close frame.
        if (!string.IsNullOrEmpty(sessionId))
        {
            httpContext.Response.Headers[SessionIdResponseHeader] = sessionId;
        }

        // Propagate invocation/session/x-request-id baggage onto the current request
        // Activity for downstream correlation. Reuses the same helper the HTTP
        // `POST /invocations` endpoint uses so HTTP and WS paths produce
        // the same baggage shape. ASP.NET Core propagates the inbound W3C
        // context to the request Activity; the connection Activity created
        // after accept remains current so handler spans inherit it directly.
        _activitySource.PropagateInvocationBaggage(context, httpContext.Request.Headers);

        var activityStartTimeUtc = DateTime.UtcNow;
        var startTimestamp = Stopwatch.GetTimestamp();
        var closeCode = InvocationsWebSocketConstants.CloseNormal;
        var abnormalClosure = false;
        string? errorCode = null;
        WebSocket? webSocket = null;
        Activity? connectionActivity = null;
        var requestActivity = Activity.Current;
        var requestBaggage = requestActivity?.Baggage.ToArray();
        var connectionActivityTerminal = new TaskCompletionSource<ConnectionActivityTerminal>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        try
        {
            try
            {
                var acceptedWebSocket = await httpContext.WebSockets.AcceptWebSocketAsync();
                webSocket = new TrackingWebSocket(
                    acceptedWebSocket,
                    TimeSpan.FromSeconds(InvocationsWebSocketConstants.CleanupTimeoutSeconds),
                    _telemetryDispatcher);
                var trackingWebSocket = (TrackingWebSocket)webSocket;
                var activityStart = InvocationsTelemetry.StartActivityAsync(
                    _telemetryDispatcher,
                    "agentserver.connection",
                    ActivityKind.Internal,
                    requestActivity?.Context ?? default,
                    baggage: requestBaggage,
                    startTimeUtc: activityStartTimeUtc,
                    activityStarted: activity =>
                        trackingWebSocket.ConnectionActivityContext.Publish(activity.Context));
                if (await Task.WhenAny(activityStart, Task.Delay(TelemetryStartTimeout)) == activityStart)
                {
                    connectionActivity = await activityStart;
                    Activity.Current = connectionActivity ?? requestActivity;
                }
                else
                {
                    ObserveLateActivity(
                        activityStart,
                        connectionActivityTerminal.Task);
                }

                connectionActivity?.SetTag("azure.ai.agentserver.invocations_ws.session_id", sessionId);
                connectionActivity?.SetTag("network.protocol.name", "websocket");
            }
            catch (Exception acceptEx)
            {
                InvocationsTelemetry.QueueCallback(_telemetryDispatcher, () => _logger.LogError(
                    acceptEx,
                    "WebSocket accept failed for session {SessionId} invocation {InvocationId}",
                    sessionId,
                    invocationId));
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
                errorCode = InvocationsWebSocketConstants.ErrorCodeAcceptFailed;
                throw;
            }

            try
            {
                await webSocketHandler.HandleWebSocketAsync(webSocket, context, httpContext.RequestAborted);
            }
            catch (OperationCanceledException oce)
                when (oce.CancellationToken == httpContext.RequestAborted
                      && httpContext.RequestAborted.IsCancellationRequested)
            {
                // Connection aborted (client disconnect / server shutdown). No
                // RFC 6455 close handshake completed, so report the local-only
                // abnormal-closure status rather than a successful 1000 close.
                //
                // The token-identity check (`oce.CancellationToken == httpContext.RequestAborted`)
                // distinguishes shutdown-driven cancellation from a handler-internal
                // OperationCanceledException (e.g., a handler's own timeout CTS firing
                // concurrently with shutdown) — those should still surface as close
                // code 1011 so real handler bugs aren't masked.
                closeCode = 1006;
                abnormalClosure = true;
            }
            catch (Exception ex)
                when (ex is WebSocketException or IOException &&
                    (httpContext.RequestAborted.IsCancellationRequested || webSocket.State == WebSocketState.Aborted))
            {
                closeCode = 1006;
                abnormalClosure = true;
            }
            catch (Exception ex)
            {
                // Handler exception details flow through this LogError(...) only —
                // they are deliberately NOT included in the close-event log line
                // so application stack traces never leak into the structured
                // metric stream.
                InvocationsTelemetry.QueueCallback(_telemetryDispatcher, () => _logger.LogError(
                    ex,
                    "WebSocket handler raised for session {SessionId} invocation {InvocationId}",
                    sessionId,
                    invocationId));
                closeCode = InvocationsWebSocketConstants.CloseInternalError;
                errorCode = InvocationsWebSocketConstants.ErrorCodeInternalError;
            }
        }
        finally
        {
            if (!abnormalClosure &&
                webSocket is TrackingWebSocket trackingWebSocket &&
                trackingWebSocket.SelectedCloseCode is int selectedCloseCode)
            {
                closeCode = selectedCloseCode;
            }

            closeCode = await CloseSocketAsync(webSocket, closeCode, sessionId, abnormalClosure);

            var durationMs = GetElapsedMilliseconds(startTimestamp);
            var activityTerminal = new ConnectionActivityTerminal(
                sessionId,
                closeCode,
                durationMs,
                errorCode,
                activityStartTimeUtc.AddMilliseconds(durationMs));
            if (connectionActivity is not null)
            {
                ApplyConnectionActivityTerminal(connectionActivity, activityTerminal);
                Activity.Current = requestActivity;
                _ = InvocationsTelemetry.StopActivityAsync(
                    _telemetryDispatcher,
                    connectionActivity,
                    connectionActivity.Stop);
            }

            connectionActivityTerminal.TrySetResult(activityTerminal);
            await EmitCloseEventLogAsync(webSocket, sessionId, closeCode, durationMs, errorCode);
        }
    }

    private void ObserveLateActivity(
        Task<Activity?> activityStart,
        Task<ConnectionActivityTerminal> activityTerminal)
    {
        _ = CompleteLateActivityAsync(activityStart, activityTerminal);
    }

    private async Task CompleteLateActivityAsync(
        Task<Activity?> activityStart,
        Task<ConnectionActivityTerminal> activityTerminal)
    {
        var activity = await activityStart.ConfigureAwait(false);
        if (activity is null)
        {
            return;
        }

        var terminal = await activityTerminal.ConfigureAwait(false);
        ApplyConnectionActivityTerminal(activity, terminal);
        await InvocationsTelemetry.StopActivityAsync(
            _telemetryDispatcher,
            activity,
            activity.Stop).ConfigureAwait(false);
    }

    private static void ApplyConnectionActivityTerminal(
        Activity activity,
        ConnectionActivityTerminal terminal)
    {
        activity.SetTag(InvocationsWebSocketConstants.AttrSpanSessionId, terminal.SessionId);
        activity.SetTag("network.protocol.name", "websocket");
        activity.SetTag(InvocationsWebSocketConstants.AttrSpanCloseCode, terminal.CloseCode);
        activity.SetTag(InvocationsWebSocketConstants.AttrSpanDurationMs, terminal.DurationMs);
        if (terminal.ErrorCode is not null)
        {
            activity.SetTag(InvocationsWebSocketConstants.AttrSpanErrorCode, terminal.ErrorCode);
        }

        activity.SetStatus(
            terminal.CloseCode == InvocationsWebSocketConstants.CloseNormal && terminal.ErrorCode is null
                ? ActivityStatusCode.Ok
                : ActivityStatusCode.Error);
        activity.SetEndTime(terminal.EndTimeUtc);
    }

    private async Task<int> CloseSocketAsync(
        WebSocket? webSocket,
        int closeCode,
        string sessionId,
        bool abnormalClosure)
    {
        if (webSocket is null)
        {
            return closeCode;
        }

        if (abnormalClosure)
        {
            try
            {
                webSocket.Abort();
            }
            catch (Exception exception) when (exception is WebSocketException or ObjectDisposedException)
            {
            }

            webSocket.Dispose();
            return 1006;
        }

        if (webSocket is TrackingWebSocket { WasAborted: true })
        {
            webSocket.Dispose();
            return 1006;
        }

        // Only send a close frame if neither side has already done so. The user
        // handler may have called CloseAsync itself, or the client may have
        // disconnected mid-stream — both leave the socket in a state where a
        // server-initiated close is either redundant or invalid.
        if (webSocket.State is WebSocketState.Closed or WebSocketState.CloseSent or WebSocketState.Aborted)
        {
            webSocket.Dispose();
            return closeCode;
        }

        var status = GetWireCloseStatus(closeCode);
        var description = status == WebSocketCloseStatus.InternalServerError
            ? "Internal server error"
            : string.Empty;

        try
        {
            if (webSocket is TrackingWebSocket)
            {
                // TrackingWebSocket records the selected close code and enforces
                // the shared cleanup deadline internally; delegate to it rather
                // than duplicating that logic with a second cancellation source
                // and a possibly different remaining budget.
                await webSocket.CloseAsync(status, description, CancellationToken.None);
                if (((TrackingWebSocket)webSocket).WasAborted)
                {
                    return 1006;
                }
            }
            else
            {
                using var closeCancellation = new CancellationTokenSource(
                    TimeSpan.FromSeconds(InvocationsWebSocketConstants.CleanupTimeoutSeconds));
                await webSocket.CloseAsync(status, description, closeCancellation.Token);
            }

            return (int)status;
        }
        catch (Exception ex) when (ex is WebSocketException or ObjectDisposedException or OperationCanceledException or IOException)
        {
            // Connection already gone — nothing to recover.
            InvocationsTelemetry.QueueCallback(_telemetryDispatcher, () =>
                _logger.LogDebug(ex, "Error closing WebSocket session {SessionId}", sessionId));
            try
            {
                webSocket.Abort();
            }
            catch (Exception abortException) when (abortException is WebSocketException or ObjectDisposedException)
            {
            }

            return 1006;
        }
        finally
        {
            try
            {
                webSocket.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }

    private static WebSocketCloseStatus GetWireCloseStatus(int closeCode)
    {
        // Preserve every valid RFC 6455 application/protocol close code selected
        // by the handler or typed protocol layer. In particular, policy and data
        // errors such as 1008/1009 must not be rewritten to normal closure 1000
        // during endpoint cleanup.
        if (closeCode is >= 1000 and <= 4999 &&
            closeCode is not (1004 or 1005 or 1006 or 1015))
        {
            return (WebSocketCloseStatus)closeCode;
        }

        // 1004/1005/1006/1015 are reserved for local status reporting and are
        // forbidden in a Close control frame. An invalid/out-of-range code also
        // cannot be sent. Use 1011 on the wire while TrackingWebSocket retains
        // the originally observed code for telemetry.
        return WebSocketCloseStatus.InternalServerError;
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

    private async Task EmitCloseEventLogAsync(
        WebSocket? webSocket,
        string sessionId,
        int closeCode,
        long durationMs,
        string? errorCode)
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
        using var enqueueCancellation = CreateCloseEventCancellation(
            (webSocket as TrackingWebSocket)?.CleanupDeadline);
        if (errorCode is null)
        {
            await InvocationsTelemetry.QueueCriticalCallbackAsync(_telemetryDispatcher, () => _logger.LogInformation(
                CloseEventTemplate,
                sessionId,
                closeCode,
                durationMs), enqueueCancellation.Token);
        }
        else
        {
            await InvocationsTelemetry.QueueCriticalCallbackAsync(_telemetryDispatcher, () => _logger.LogInformation(
                CloseEventTemplateWithError,
                sessionId,
                closeCode,
                durationMs,
                errorCode), enqueueCancellation.Token);
        }
    }

    internal static CancellationTokenSource CreateCloseEventCancellation(CleanupDeadline? cleanupDeadline) =>
        cleanupDeadline?.CreateCancellationTokenSource() ??
        new CancellationTokenSource(
            TimeSpan.FromSeconds(InvocationsWebSocketConstants.CleanupTimeoutSeconds));

    private readonly record struct ConnectionActivityTerminal(
        string SessionId,
        int CloseCode,
        long DurationMs,
        string? ErrorCode,
        DateTime EndTimeUtc);
}
