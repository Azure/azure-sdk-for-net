// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Base class for handling invocation requests. Only <see cref="HandleAsync"/>
/// is required. Override the optional methods to opt in to GET, cancel, OpenAPI,
/// and AsyncAPI endpoints (they return 404 by default).
/// </summary>
/// <remarks>
/// To opt in to the <c>invocations_ws</c> (WebSocket) transport, derive from
/// <see cref="InvocationWebSocketHandler"/> instead.
/// </remarks>
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
    /// <param name="context">Per-request context with platform identity, headers, and query parameters.</param>
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
    /// <param name="context">Per-request context with platform identity, headers, and query parameters.</param>
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
    /// Handles <c>GET /invocations/docs/asyncapi.json</c>. Returns 404 by default.
    /// Override to return an AsyncAPI (JSON) spec for the agent's event-driven
    /// contract (e.g. the <c>invocations_ws</c> WebSocket protocol) — the AsyncAPI
    /// companion to <see cref="GetOpenApiAsync"/> for streaming/bidirectional
    /// surfaces that OpenAPI cannot express.
    /// </summary>
    /// <remarks>
    /// The path extension is authoritative for the returned content type — no
    /// <c>Accept</c> negotiation and no format conversion between the JSON and
    /// YAML representations. Override <see cref="GetAsyncApiYamlAsync"/>
    /// independently; publishing both is recommended for tooling compatibility.
    /// <para>
    /// When overriding, you MUST set <see cref="HttpResponse.StatusCode"/>
    /// explicitly. This method returns 404 by default; once you override it the
    /// default no longer runs (unless the override calls <c>base.GetAsyncApiJsonAsync(...)</c>
    /// / <c>base.GetAsyncApiYamlAsync(...)</c>), so if you forget to set a status the
    /// response defaults to 200 with whatever body you wrote (or empty).
    /// </para>
    /// </remarks>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public virtual Task GetAsyncApiJsonAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles <c>GET /invocations/docs/asyncapi.yaml</c>. Returns 404 by default.
    /// Override to return an AsyncAPI (YAML) spec for the agent's event-driven
    /// contract. Companion to <see cref="GetAsyncApiJsonAsync"/>; each format is
    /// served independently at its own path.
    /// </summary>
    /// <remarks>
    /// The path extension is authoritative for the returned content type — no
    /// <c>Accept</c> negotiation and no format conversion between the JSON and
    /// YAML representations. Override <see cref="GetAsyncApiJsonAsync"/>
    /// independently; publishing both is recommended for tooling compatibility.
    /// <para>
    /// When overriding, you MUST set <see cref="HttpResponse.StatusCode"/>
    /// explicitly. This method returns 404 by default; once you override it the
    /// default no longer runs (unless the override calls <c>base.GetAsyncApiJsonAsync(...)</c>
    /// / <c>base.GetAsyncApiYamlAsync(...)</c>), so if you forget to set a status the
    /// response defaults to 200 with whatever body you wrote (or empty).
    /// </para>
    /// </remarks>
    /// <param name="request">The incoming HTTP request.</param>
    /// <param name="response">The outgoing HTTP response.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the async operation.</returns>
    public virtual Task GetAsyncApiYamlAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken)
    {
        response.StatusCode = 404;
        return Task.CompletedTask;
    }
}
