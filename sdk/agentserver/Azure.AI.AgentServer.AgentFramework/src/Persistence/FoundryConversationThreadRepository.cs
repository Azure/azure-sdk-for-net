// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core.Responses.Conversations;
using Azure.Core;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence;

/// <summary>
/// Thread repository that hydrates session messages from Foundry Conversations API.
/// </summary>
public class FoundryConversationThreadRepository : IAgentThreadRepository
{
    private readonly ConversationItemsClient _itemsClient;
    private readonly ConcurrentDictionary<string, AgentSession> _sessions = new(StringComparer.Ordinal);

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryConversationThreadRepository"/> class.
    /// </summary>
    /// <param name="projectEndpoint">The Foundry project endpoint.</param>
    /// <param name="credential">The token credential used to fetch conversation items.</param>
    public FoundryConversationThreadRepository(
        Uri projectEndpoint,
        TokenCredential credential)
    {
        ArgumentNullException.ThrowIfNull(projectEndpoint);
        ArgumentNullException.ThrowIfNull(credential);

        _itemsClient = new ConversationItemsClient(projectEndpoint, credential);
    }

    /// <inheritdoc />
    public async Task<AgentSession> Get(string? conversationId, AIAgent? agent = null)
    {
        if (string.IsNullOrWhiteSpace(conversationId))
        {
            if (agent != null)
            {
                return await agent.CreateSessionAsync().ConfigureAwait(false);
            }

            throw new InvalidOperationException("Agent instance must be provided when conversation ID is null.");
        }

        if (_sessions.TryGetValue(conversationId, out var existingSession))
        {
            return existingSession;
        }

        var createdSession = await CreateSessionAsync(conversationId, agent).ConfigureAwait(false);
        if (_sessions.TryAdd(conversationId, createdSession))
        {
            return createdSession;
        }

        return _sessions[conversationId];
    }

    /// <inheritdoc />
    public Task Set(string? conversationId, AgentSession session)
    {
        if (string.IsNullOrWhiteSpace(conversationId))
        {
            return Task.CompletedTask;
        }

        ArgumentNullException.ThrowIfNull(session);

        _sessions[conversationId] = session;
        return Task.CompletedTask;
    }

    private async Task<AgentSession> CreateSessionAsync(string conversationId, AIAgent? agent)
    {
        var messageStore = new FoundryConversationMessageStore(_itemsClient, conversationId);
        var messages = await messageStore.GetMessagesAsync().ConfigureAwait(false);

        // Agent sessions must be created by the target agent to ensure compatibility.
        if (agent is ChatClientAgent chatClientAgent)
        {
            var session = await chatClientAgent.CreateSessionAsync(conversationId).ConfigureAwait(false);
            if (chatClientAgent.ChatHistoryProvider is InMemoryChatHistoryProvider memoryProvider)
            {
                memoryProvider.SetMessages(session, messages.ToList());
            }
            return session;
        }

        if (agent != null)
        {
            var session = await agent.CreateSessionAsync().ConfigureAwait(false);

            if (agent.GetService<ChatHistoryProvider>() is InMemoryChatHistoryProvider memoryProvider)
            {
                memoryProvider.SetMessages(session, messages.ToList());
            }

            return session;
        }

        // Fallback: no agent available to create a session
        throw new InvalidOperationException("Agent instance must be provided to create a session.");
    }
}
