// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Base class for handling invocation requests. Only <see cref="HandleAsync"/>
/// is required. Override the optional methods to opt in to GET, cancel,
/// OpenAPI, and WebSocket (<c>/invocations_ws</c>) endpoints (they return
/// 404 / refuse the upgrade by default).
/// </summary>
public abstract class InvocationHandler
{
    /// <summary>
    /// Handles a <c>POST /invocations</c> request. Required.
    /// </summary>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="context">Per-request context with resolved invocation/session IDs, headers, and query parameters.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public abstract Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Handles <c>GET /invocations/{invocationId}</c>. Returns 404 by default.
    /// Override to support polling for async/LRO invocations.
    /// </summary>
    /// <param name="invocationId">The invocation identifier.</param>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="context">Per-request context with isolation keys, headers, and query parameters.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public virtual Task GetAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles <c>POST /invocations/{invocationId}/cancel</c>. Returns 404 by default.
    /// Override to support cancellation.
    /// </summary>
    /// <param name="invocationId">The invocation identifier.</param>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="context">Per-request context with isolation keys, headers, and query parameters.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public virtual Task CancelAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles <c>GET /invocations/docs/openapi.json</c>. Returns 404 by default.
    /// Override to return an OpenAPI spec for the agent's contract.
    /// </summary>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public virtual Task GetOpenApiAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles a <c>/invocations_ws</c> WebSocket upgrade.
    /// </summary>
    /// <param name="webSocket">
    /// The accepted <see cref="WebSocket"/>. The SDK has already called
    /// <c>AcceptWebSocketAsync</c>; the handler owns the full duplex
    /// lifecycle from this point. On return the SDK will close the
    /// connection with code <c>1000</c> (Normal). An unhandled exception
    /// thrown by the handler will be mapped to close code <c>1011</c>
    /// (Internal Error).
    /// </param>
    /// <param name="context">
    /// Per-connection context. The session ID honours <c>FOUNDRY_AGENT_SESSION_ID</c>
    /// (matching the HTTP <c>POST /invocations</c> precedence, minus the
    /// query-param override which has no ergonomic equivalent on a
    /// long-lived WS connection). The invocation ID is a generated UUID
    /// — WebSocket has no per-message invocation ID.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelled when the connection is aborted (client disconnect, server
    /// shutdown, request aborted, etc.).
    /// </param>
    /// <returns>A task representing the async lifetime of the connection.</returns>
    /// <remarks>
    /// <para>The default implementation throws <see cref="NotSupportedException"/>;
    /// the SDK detects this at WS endpoint registration time and refuses the
    /// upgrade with HTTP <c>404 Not Found</c> when the handler does not
    /// override this method. Override to opt in to the
    /// <c>invocations_ws</c> protocol.</para>
    /// <para>The library calls <c>AcceptWebSocketAsync</c> for you and emits
    /// a single structured close-event log line carrying
    /// <c>azure.ai.agentserver.invocations_ws.session_id</c>,
    /// <c>azure.ai.agentserver.invocations_ws.close_code</c>, and
    /// <c>azure.ai.agentserver.invocations_ws.duration_ms</c> when the
    /// connection ends. No framework-level OpenTelemetry span is created;
    /// ASP.NET Core auto-propagates the inbound W3C trace context to the
    /// request <see cref="System.Diagnostics.Activity"/>, so any spans you
    /// start inside the handler are parented correctly.</para>
    /// </remarks>
    public virtual Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        throw new NotSupportedException(
            "This InvocationHandler does not support the invocations_ws (WebSocket) protocol. " +
            "Override HandleWebSocketAsync to handle /invocations_ws connections.");
    }
}
