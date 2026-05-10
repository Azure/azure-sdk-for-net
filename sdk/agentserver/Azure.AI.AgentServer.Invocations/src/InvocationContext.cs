// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Per-request context for an invocation, carrying platform-resolved identifiers,
/// forwarded client headers, and query parameters.
/// </summary>
public sealed class InvocationContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="InvocationContext"/>.
    /// </summary>
    /// <param name="invocationId">The resolved invocation ID.</param>
    /// <param name="sessionId">The resolved session ID.</param>
    /// <param name="clientHeaders">Forwarded <c>x-client-*</c> headers.</param>
    /// <param name="queryParameters">All forwarded query parameters.</param>
    /// <param name="isolation">Platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    public InvocationContext(
        string invocationId,
        string sessionId,
        IReadOnlyDictionary<string, string> clientHeaders,
        IReadOnlyDictionary<string, StringValues> queryParameters,
        IsolationContext isolation)
    {
        ArgumentException.ThrowIfNullOrEmpty(invocationId);
        ArgumentException.ThrowIfNullOrEmpty(sessionId);
        ArgumentNullException.ThrowIfNull(clientHeaders);
        ArgumentNullException.ThrowIfNull(queryParameters);

        InvocationId = invocationId;
        SessionId = sessionId;
        ClientHeaders = clientHeaders;
        QueryParameters = queryParameters;
        ArgumentNullException.ThrowIfNull(isolation);
        Isolation = isolation;
    }

    /// <summary>
    /// The invocation ID. Sourced from the <c>x-agent-invocation-id</c> request header
    /// if present, otherwise a generated UUID.
    /// </summary>
    public string InvocationId { get; }

    /// <summary>
    /// The session ID. Resolved from <c>agent_session_id</c> query parameter,
    /// <c>FOUNDRY_AGENT_SESSION_ID</c> env var, or a generated UUID (in that order).
    /// </summary>
    public string SessionId { get; }

    /// <summary>
    /// Read-only dictionary of <c>x-client-*</c> headers forwarded from the request.
    /// Keys include the full header name (e.g., <c>x-client-foo</c>).
    /// </summary>
    public IReadOnlyDictionary<string, string> ClientHeaders { get; }

    /// <summary>
    /// Read-only dictionary of all query parameters forwarded from the caller's
    /// request. Per the invocation protocol spec, all query parameters are
    /// forwarded unchanged — containers may define additional custom parameters
    /// as part of their own contract.
    /// </summary>
    public IReadOnlyDictionary<string, StringValues> QueryParameters { get; }

    /// <summary>
    /// Gets the platform-injected isolation keys for this request.
    /// Handlers use these opaque partition keys to scope user-private and
    /// conversation-shared state. Returns <see cref="IsolationContext.Empty"/>
    /// when the platform headers are absent (e.g., local development).
    /// </summary>
    public IsolationContext Isolation { get; }
}
