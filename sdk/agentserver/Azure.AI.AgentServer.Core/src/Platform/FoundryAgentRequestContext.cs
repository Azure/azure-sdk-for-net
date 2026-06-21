// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Request-scoped platform identity context, backed by an
/// <see cref="System.Threading.AsyncLocal{T}"/> so it flows across
/// <c>await</c> points and child tasks within a single request without being
/// threaded through every call site. This is the .NET analogue of the Python
/// SDK's <c>get_request_context()</c> / <c>FoundryAgentRequestContext</c>.
/// </summary>
/// <remarks>
/// <para>
/// On container protocol version <c>2.0.0</c> the platform stamps
/// <c>x-agent-foundry-call-id</c> and <c>x-agent-user-id</c> on the inbound
/// request. The SDK's request-context middleware captures them here before the
/// handler runs; outbound Foundry-bound clients read <see cref="Current"/> and
/// echo <b>only</b> the call id (e.g. via <see cref="FoundryCallIdHandler"/>).
/// </para>
/// <para>
/// <c>x-agent-user-id</c> is exposed purely as a convenience for the container's
/// own per-user state isolation — it is <b>never</b> echoed on outbound calls
/// (the receiver resolves user identity from the call id).
/// </para>
/// <para>
/// <see cref="Current"/> never returns <see langword="null"/>; outside a request
/// (e.g. local development) it yields an empty context with all-<see langword="null"/>
/// fields.
/// </para>
/// </remarks>
public sealed class FoundryAgentRequestContext
{
    private static readonly System.Threading.AsyncLocal<FoundryAgentRequestContext?> CurrentContext = new();

    /// <summary>
    /// The opaque per-request call identifier from <c>x-agent-foundry-call-id</c>
    /// (container protocol version <c>2.0.0</c>). Echoed verbatim on outbound
    /// Foundry-bound calls; <see langword="null"/> when absent.
    /// </summary>
    public string? CallId { get; init; }

    /// <summary>
    /// The global, cross-agent per-user identity from <c>x-agent-user-id</c>.
    /// A convenience for the container's own per-user state isolation; it is
    /// <b>never</b> echoed on outbound calls. <see langword="null"/> when absent.
    /// </summary>
    public string? UserId { get; init; }

    /// <summary>
    /// The resolved session ID for the request, when available; otherwise <see langword="null"/>.
    /// </summary>
    public string? SessionId { get; init; }

    /// <summary>
    /// Gets the platform identity context for the current request. Never returns
    /// <see langword="null"/> — an empty context is returned outside a request.
    /// </summary>
    public static FoundryAgentRequestContext Current => CurrentContext.Value ?? Empty;

    /// <summary>
    /// An empty context with all fields <see langword="null"/>, returned by
    /// <see cref="Current"/> when no request context has been established.
    /// </summary>
    public static FoundryAgentRequestContext Empty { get; } = new FoundryAgentRequestContext();

    /// <summary>
    /// Binds <paramref name="context"/> as the current request context. Called by
    /// the SDK's request-context middleware at the start of request handling.
    /// </summary>
    /// <param name="context">The context to bind.</param>
    internal static void Set(FoundryAgentRequestContext context) => CurrentContext.Value = context;

    /// <summary>
    /// Atomically binds <paramref name="context"/> as the current request context
    /// and returns the previously bound context (or <see langword="null"/>). Used by
    /// the request-context middleware to restore the prior value in a <c>finally</c>
    /// block so a completed request's call id/user id cannot leak into work that runs
    /// afterwards on the same execution context (e.g. nested pipelines).
    /// </summary>
    /// <param name="context">The context to bind, or <see langword="null"/> to clear.</param>
    /// <returns>The previously bound context, or <see langword="null"/> if none.</returns>
    internal static FoundryAgentRequestContext? Exchange(FoundryAgentRequestContext? context)
    {
        FoundryAgentRequestContext? previous = CurrentContext.Value;
        CurrentContext.Value = context;
        return previous;
    }

    /// <summary>
    /// Builds the platform identity headers to echo on outbound Foundry-bound
    /// calls. Only <c>x-agent-foundry-call-id</c> is included; <c>x-agent-user-id</c>
    /// is never echoed. Mirrors the Python SDK's <c>FoundryAgentRequestContext.platform_headers()</c>.
    /// </summary>
    /// <returns>The headers to merge onto an outbound request (empty when no call id is present).</returns>
    public IEnumerable<KeyValuePair<string, string>> PlatformHeaders()
    {
        if (CallId is not null)
        {
            yield return new KeyValuePair<string, string>(Core.PlatformHeaders.FoundryCallId, CallId);
        }
    }
}
