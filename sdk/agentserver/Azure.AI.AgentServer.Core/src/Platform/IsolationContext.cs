// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Carries the platform-injected isolation keys for a single request.
/// The Foundry platform sets <c>x-agent-user-isolation-key</c> and
/// <c>x-agent-chat-isolation-key</c> headers on every protocol request
/// (e.g., <c>/responses</c>, <c>/invocations</c>). These opaque partition
/// keys let handlers scope user-private and conversation-shared state
/// without inspecting user identity.
/// </summary>
/// <remarks>
/// <para>
/// <b>User isolation key</b> — the partition for data that belongs to the
/// individual who initiated the request (e.g., OAuth tokens, personal memory,
/// per-user preferences, cache entries). Stable for a given user across
/// sessions. In multi-participant surfaces each participant yields a distinct
/// value per turn.
/// </para>
/// <para>
/// <b>Chat isolation key</b> — the partition for conversation-scoped state
/// (e.g., conversation history, turn state, shared files). In a 1:1
/// user↔agent chat this equals the user isolation key. It differs only in
/// shared-surface scenarios (e.g., a Teams group chat) where it represents
/// the common partition all participants write to.
/// </para>
/// <para>
/// Both keys are opaque, platform-generated, and scoped to the agent — data
/// cannot leak between agents. Neither key is guaranteed to be present when
/// running locally (outside the platform); containers should handle
/// <see langword="null"/> values gracefully (e.g., fall back to a default
/// partition).
/// </para>
/// </remarks>
public class IsolationContext
{
    /// <summary>
    /// An empty <see cref="IsolationContext"/> with both keys <see langword="null"/>.
    /// Used when the platform headers are absent (e.g., local development).
    /// </summary>
    public static IsolationContext Empty { get; } = new IsolationContext(null, null);

    /// <summary>
    /// Reads the <c>x-agent-user-isolation-key</c> and <c>x-agent-chat-isolation-key</c>
    /// headers from the HTTP request. Returns <see cref="Empty"/> when neither
    /// header is present.
    /// </summary>
    /// <param name="request">The HTTP request to extract headers from.</param>
    /// <returns>An <see cref="IsolationContext"/> with the extracted keys.</returns>
    public static IsolationContext FromRequest(HttpRequest request)
    {
        string? userKey = request.Headers.TryGetValue(PlatformHeaders.UserIsolationKey, out var userValue)
            ? NormalizeHeaderValue(userValue)
            : null;

        string? chatKey = request.Headers.TryGetValue(PlatformHeaders.ChatIsolationKey, out var chatValue)
            ? NormalizeHeaderValue(chatValue)
            : null;

        if (userKey is null && chatKey is null)
        {
            return Empty;
        }

        return new IsolationContext(userKey, chatKey);
    }

    /// <summary>
    /// Normalizes a header value for use as an isolation key.
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
    /// Initializes a new instance of <see cref="IsolationContext"/>.
    /// </summary>
    /// <param name="userIsolationKey">
    /// The value of the <c>x-agent-user-isolation-key</c> header, or
    /// <see langword="null"/> if the header was absent.
    /// </param>
    /// <param name="chatIsolationKey">
    /// The value of the <c>x-agent-chat-isolation-key</c> header, or
    /// <see langword="null"/> if the header was absent.
    /// </param>
    public IsolationContext(string? userIsolationKey, string? chatIsolationKey)
    {
        UserIsolationKey = userIsolationKey;
        ChatIsolationKey = chatIsolationKey;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="IsolationContext"/> for mocking.
    /// </summary>
    protected IsolationContext()
    {
    }

    /// <summary>
    /// Gets the user isolation key — the partition under which
    /// <b>user-private</b> state should be stored.
    /// </summary>
    /// <value>
    /// An opaque string from <c>x-agent-user-isolation-key</c>, or
    /// <see langword="null"/> when running outside the platform.
    /// </value>
    public virtual string? UserIsolationKey { get; }

    /// <summary>
    /// Gets the chat isolation key — the partition under which
    /// <b>conversation / shared</b> state should be stored.
    /// </summary>
    /// <value>
    /// An opaque string from <c>x-agent-chat-isolation-key</c>, or
    /// <see langword="null"/> when running outside the platform.
    /// In a 1:1 user↔agent chat this equals <see cref="UserIsolationKey"/>.
    /// </value>
    public virtual string? ChatIsolationKey { get; }
}
