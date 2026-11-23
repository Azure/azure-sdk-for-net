// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#pragma warning disable AAAS005 // Implement the experimental attribution contract.

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
    /// The process-level session ID sourced from the <c>FOUNDRY_AGENT_SESSION_ID</c> environment
    /// variable via <see cref="FoundryEnvironment.SessionId"/>. The value is refreshed after
    /// snapshot restoration and does not reflect per-request overrides (e.g. the
    /// <c>agent_session_id</c> query parameter); <see langword="null"/> when the variable is absent.
    /// </summary>
    public string? SessionId { get; init; }

    /// <summary>
    /// Gets the invocation-local original-subject assertions, if supplied.
    /// These assertions are not proof of identity.
    /// </summary>
    [Experimental("AAAS005")]
    public FoundryOriginalSubject? OriginalSubject { get; init; }

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
    /// Binds a context to the current asynchronous execution until the returned
    /// scope is disposed. Dispose nested scopes in reverse order.
    /// </summary>
    /// <param name="context">The context to bind.</param>
    /// <returns>A scope that restores the prior context.</returns>
    [Experimental("AAAS005")]
    public static IDisposable BeginScope(FoundryAgentRequestContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        return new ContextScope(Exchange(context));
    }

    private sealed class ContextScope : IDisposable
    {
        private readonly FoundryAgentRequestContext? _previous;
        private bool _disposed;

        public ContextScope(FoundryAgentRequestContext? previous) => _previous = previous;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Exchange(_previous);
            }
        }
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
            yield return new KeyValuePair<string, string>(Azure.AI.AgentServer.Core.PlatformHeaders.FoundryCallId, CallId);
        }
    }

    /// <summary>
    /// Creates per-call headers for a model endpoint that explicitly supports
    /// original-subject attribution. Never use these as shared client defaults
    /// or send them to arbitrary endpoints, storage, or tools.
    /// </summary>
    /// <param name="headers">Existing per-call headers to copy and merge.</param>
    /// <returns>A new header dictionary; the input and model credentials are unchanged.</returns>
    /// <exception cref="InvalidOperationException">
    /// The subject is incomplete, unsafe, or exceeds the attribution transport limits.
    /// </exception>
    [Experimental("AAAS005")]
    public IDictionary<string, string> ModelAttributionHeaders(
        IEnumerable<KeyValuePair<string, string>>? headers = null)
    {
        const string subjectHeader = "x-ms-original-subject";
        const string baggageHeader = "x-ms-foundry-baggage";
        const string subjectKey = "foundry.original_subject";
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var baggage = new List<string>();
        if (headers is not null)
        {
            foreach (var header in headers)
            {
                if (string.Equals(header.Key, baggageHeader, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (string part in header.Value.Split(','))
                    {
                        string member = part.Trim();
                        string key = member.Split(';')[0].Split('=')[0].Trim();
                        key = Uri.UnescapeDataString(key);
                        if (member.Length != 0
                            && !string.Equals(key, subjectKey, StringComparison.OrdinalIgnoreCase)
                            && !key.StartsWith(subjectKey + ".", StringComparison.OrdinalIgnoreCase))
                        {
                            baggage.Add(member);
                        }
                    }
                }
                else if (!string.Equals(header.Key, subjectHeader, StringComparison.OrdinalIgnoreCase)
                    && !header.Key.StartsWith(subjectHeader + "-", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(header.Key, Azure.AI.AgentServer.Core.PlatformHeaders.FoundryCallId, StringComparison.OrdinalIgnoreCase))
                {
                    result[header.Key] = header.Value;
                }
            }
        }

        if (OriginalSubject is null)
        {
            if (baggage.Count != 0)
            {
                result[baggageHeader] = string.Join(",", baggage);
            }

            return result;
        }

        string[] values = { OriginalSubject.ObjectId!, OriginalSubject.TenantId!, OriginalSubject.IdentityType! };
        if (values.Any(value => string.IsNullOrEmpty(value) || value.Any(character => character < '!' || character > '~')))
        {
            throw new InvalidOperationException("Original-subject attribution requires a complete, HTTP-safe tuple.");
        }

        static string Escape(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
        string subject = $"oid=\"{Escape(values[0])}\", tid=\"{Escape(values[1])}\", idtype=\"{Escape(values[2])}\"";
        if (subject.Length > 256)
        {
            throw new InvalidOperationException("Original-subject attribution requires a quoted tuple of at most 256 characters.");
        }

        baggage.Insert(0, subjectKey + "=" + Uri.EscapeDataString(subject));
        string merged = string.Join(",", baggage);
        if (merged.Length > 1024)
        {
            throw new InvalidOperationException("Original-subject attribution requires merged baggage of at most 1024 characters.");
        }

        result[baggageHeader] = merged;
        if (CallId is not null)
        {
            result[Azure.AI.AgentServer.Core.PlatformHeaders.FoundryCallId] = CallId;
        }

        return result;
    }
}
