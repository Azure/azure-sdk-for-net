// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Base class for handling invocation requests. Only <see cref="HandleAsync"/>
/// is required. Override the optional methods to opt in to GET, cancel, and
/// OpenAPI endpoints (they return 404 by default).
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
}
