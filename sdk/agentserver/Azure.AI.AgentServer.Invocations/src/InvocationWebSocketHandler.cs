// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Base class for handlers that opt in to the <c>invocations_ws</c>
/// (WebSocket) transport at <c>/invocations_ws</c>, optionally alongside
/// the HTTP <c>POST /invocations</c> transport.
/// </summary>
/// <remarks>
/// <para>Override <see cref="HandleWebSocketAsync"/> to serve a WebSocket
/// connection. The library calls <c>AcceptWebSocketAsync</c> for you,
/// maps a clean handler return to RFC 6455 close code <c>1000</c>
/// (<c>NormalClosure</c>) and an uncaught handler exception to
/// <c>1011</c> (<c>InternalServerError</c>), preserves handler-initiated
/// close codes unchanged, and emits a structured close-event log line
/// carrying <c>azure.ai.agentserver.invocations_ws.session_id</c>,
/// <c>azure.ai.agentserver.invocations_ws.close_code</c>, and
/// <c>azure.ai.agentserver.invocations_ws.duration_ms</c>.</para>
/// <para>The inherited <see cref="HandleAsync"/> (HTTP
/// <c>POST /invocations</c>) returns <c>404 Not Found</c> by default — a
/// WS-only handler does not need to override it. Multi-protocol handlers
/// override both <see cref="HandleAsync"/> and
/// <see cref="HandleWebSocketAsync"/>; both methods see the same session
/// when <c>FOUNDRY_AGENT_SESSION_ID</c> is set so HTTP and WebSocket turns
/// correlate.</para>
/// <para>No framework-level OpenTelemetry span is created for the
/// connection; ASP.NET Core auto-propagates the inbound W3C trace context
/// to the request <see cref="System.Diagnostics.Activity"/>, so any spans
/// the handler starts are parented correctly. Session / invocation /
/// <c>x-request-id</c> baggage is propagated onto the current Activity
/// before the handler runs.</para>
/// </remarks>
public abstract class InvocationWebSocketHandler : InvocationHandler
{
    /// <summary>
    /// Handles a <c>POST /invocations</c> request. Returns <c>404 Not Found</c>
    /// by default — override to add HTTP support alongside the WebSocket
    /// endpoint.
    /// </summary>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="context">Per-request context with resolved invocation/session IDs, headers, and query parameters.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public override Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles a <c>/invocations_ws</c> WebSocket connection. Required.
    /// </summary>
    /// <param name="webSocket">
    /// The accepted <see cref="WebSocket"/>. The SDK has already called
    /// <c>AcceptWebSocketAsync</c>; the handler owns the full-duplex
    /// lifecycle from this point. On clean return the SDK closes the
    /// connection with RFC 6455 code <c>1000</c> (<c>NormalClosure</c>);
    /// an unhandled exception is mapped to code <c>1011</c>
    /// (<c>InternalServerError</c>); a handler-initiated <c>CloseAsync</c>
    /// is preserved unchanged.
    /// </param>
    /// <param name="context">
    /// Per-connection context. The session ID honours
    /// <c>FOUNDRY_AGENT_SESSION_ID</c> (matching the HTTP
    /// <c>POST /invocations</c> precedence, minus the query-param override
    /// which has no ergonomic equivalent on a long-lived WS connection).
    /// The invocation ID is a generated UUID — WebSocket has no
    /// per-message invocation ID.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelled when the connection is aborted (client disconnect,
    /// server shutdown, request aborted, etc.).
    /// </param>
    /// <returns>A task representing the async lifetime of the connection.</returns>
    public abstract Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken);
}
