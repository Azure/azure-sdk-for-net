// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence;

/// <summary>
/// In-memory agent thread pre-hydrated from Foundry conversation history.
/// </summary>
internal sealed class FoundryConversationAgentThread : InMemoryAgentThread
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryConversationAgentThread"/> class.
    /// </summary>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="messages">Initial hydrated messages for the thread.</param>
    public FoundryConversationAgentThread(
        string conversationId,
        IEnumerable<ChatMessage> messages)
        : base(messages)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conversationId);
        ConversationId = conversationId;
    }

    /// <summary>
    /// Gets the conversation ID associated with this thread.
    /// </summary>
    public string ConversationId { get; }
}
