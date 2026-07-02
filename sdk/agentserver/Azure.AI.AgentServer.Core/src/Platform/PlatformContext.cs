// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Carries the platform-injected identity context for a single request.
/// The Foundry platform sets <c>x-agent-user-id</c> and (on container protocol
/// version <c>2.0.0</c>) <c>x-agent-foundry-call-id</c> headers on every
/// protocol request (e.g., <c>/responses</c>, <c>/invocations</c>). These
/// opaque values let handlers partition per-user state and let the SDK forward
/// the per-request caller context to Foundry platform services.
/// </summary>
/// <remarks>
/// <para>
/// <b>User ID key</b> — the global, cross-agent partition key for per-user
/// data (e.g., user profile, preferences, OAuth tokens, memory). The same user
/// yields the same value regardless of which agent they interact with. Used
/// container-side for per-user state partitioning; it is <b>not</b> forwarded
/// on outbound 1P calls (not accepted/trusted by 1P services).
/// </para>
/// <para>
/// <b>Call ID</b> — the opaque per-request call identifier (present only on
/// container protocol version <c>2.0.0</c>). The container <b>must</b> forward
/// it on outbound calls to Foundry platform services so that 1P services
/// resolve the server-side-stored caller context. Never parsed.
/// </para>
/// <para>
/// Both values are opaque and platform-generated. Neither is guaranteed to be
/// present when running locally (outside the platform); containers should
/// handle <see langword="null"/> values gracefully (e.g., fall back to a
/// default partition).
/// </para>
/// </remarks>
public class PlatformContext
{
    /// <summary>
    /// An empty <see cref="PlatformContext"/> with both values <see langword="null"/>.
    /// Used when the platform headers are absent (e.g., local development).
    /// </summary>
    public static PlatformContext Empty { get; } = new PlatformContext(null, null);

    /// <summary>
    /// Reads the <c>x-agent-user-id</c> and <c>x-agent-foundry-call-id</c>
    /// headers from the HTTP request. Returns <see cref="Empty"/> when neither
    /// header is present.
    /// </summary>
    /// <param name="request">The HTTP request to extract headers from.</param>
    /// <returns>A <see cref="PlatformContext"/> with the extracted values.</returns>
    public static PlatformContext FromRequest(HttpRequest request)
    {
        string? userIdKey = request.Headers.TryGetValue(PlatformHeaders.UserId, out var userValue)
            ? NormalizeHeaderValue(userValue)
            : null;

        string? callId = request.Headers.TryGetValue(PlatformHeaders.FoundryCallId, out var callValue)
            ? NormalizeHeaderValue(callValue)
            : null;

        if (userIdKey is null && callId is null)
        {
            return Empty;
        }

        return new PlatformContext(userIdKey, callId);
    }

    /// <summary>
    /// Normalizes a header value for use as a platform identity value.
    /// Uses the first value when multiple are present and trims whitespace,
    /// returning <see langword="null"/> when the result is empty or whitespace.
    /// </summary>
    /// <param name="values">The raw header values.</param>
    /// <returns>A normalized header value or <see langword="null"/>.</returns>
    private static string? NormalizeHeaderValue(Microsoft.Extensions.Primitives.StringValues values)
    {
        if (values.Count == 0)
        {
            return null;
        }

        string? first = values[0];
        if (string.IsNullOrWhiteSpace(first))
        {
            return null;
        }

        return first.Trim();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlatformContext"/>.
    /// </summary>
    /// <param name="userIdKey">
    /// The value of the <c>x-agent-user-id</c> header, or
    /// <see langword="null"/> if the header was absent.
    /// </param>
    /// <param name="callId">
    /// The value of the <c>x-agent-foundry-call-id</c> header, or
    /// <see langword="null"/> if the header was absent.
    /// </param>
    public PlatformContext(string? userIdKey, string? callId)
    {
        UserIdKey = userIdKey;
        CallId = callId;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlatformContext"/> for mocking.
    /// </summary>
    protected PlatformContext()
    {
    }

    /// <summary>
    /// Gets the user ID key — the global, cross-agent partition under which
    /// <b>per-user</b> state should be stored.
    /// </summary>
    /// <value>
    /// An opaque string from <c>x-agent-user-id</c>, or
    /// <see langword="null"/> when running outside the platform.
    /// </value>
    public virtual string? UserIdKey { get; }

    /// <summary>
    /// Gets the opaque per-request call identifier from
    /// <c>x-agent-foundry-call-id</c> (container protocol version <c>2.0.0</c>).
    /// </summary>
    /// <value>
    /// An opaque string forwarded verbatim on outbound Foundry 1P calls, or
    /// <see langword="null"/> when running outside the platform or under
    /// protocol version <c>1.0.0</c>.
    /// </value>
    public virtual string? CallId { get; }
}
