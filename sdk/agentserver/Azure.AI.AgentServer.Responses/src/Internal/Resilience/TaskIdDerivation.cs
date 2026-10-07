// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>Derives the private physical task ID for a resilient response chain.</summary>
internal static class TaskIdDerivation
{
    private const char SessionScopeSeparator = '\x1f';

    /// <summary>Combines a hosted session incarnation GUID with its public session identity.</summary>
    public static string DeriveSessionScope(string sessionId, string? sessionGuid)
        => string.IsNullOrEmpty(sessionGuid)
            ? sessionId
            : $"{sessionGuid}{SessionScopeSeparator}{sessionId}";

    /// <summary>
    /// Derives a physical task ID using a private session scope while preserving the public
    /// session identity used by <see cref="ConversationChainIdDerivation"/>.
    /// </summary>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        string agentName,
        string sessionId,
        string? taskSessionId,
        bool steerable = true)
        => ConversationChainIdDerivation.Derive(
            conversationId,
            previousResponseId,
            responseId,
            agentName,
            taskSessionId ?? sessionId,
            steerable);
}
