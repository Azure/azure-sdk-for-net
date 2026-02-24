// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence;

/// <summary>
/// Agent session pre-hydrated from Foundry conversation history.
/// Wraps an <see cref="AgentSession"/> and associates it with a conversation ID.
/// </summary>
internal sealed class FoundryConversationAgentThread
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryConversationAgentThread"/> class.
    /// </summary>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="session">The agent session.</param>
    public FoundryConversationAgentThread(
        string conversationId,
        AgentSession session)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conversationId);
        ArgumentNullException.ThrowIfNull(session);
        ConversationId = conversationId;
        Session = session;
    }

    /// <summary>
    /// Gets the conversation ID associated with this session.
    /// </summary>
    public string ConversationId { get; }

    /// <summary>
    /// Gets the agent session.
    /// </summary>
    public AgentSession Session { get; }
}
