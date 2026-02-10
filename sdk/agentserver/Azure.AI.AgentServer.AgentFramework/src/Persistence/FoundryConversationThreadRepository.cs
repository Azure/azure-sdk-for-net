// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core.Responses.Conversations;
using Azure.Core;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence;

/// <summary>
/// Thread repository that hydrates thread messages from Foundry Conversations API.
/// </summary>
public class FoundryConversationThreadRepository : IAgentThreadRepository
{
    private readonly ConversationItemsClient _itemsClient;
    private readonly ConcurrentDictionary<string, AgentThread> _threads = new(StringComparer.Ordinal);

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
    public async Task<AgentThread> Get(string conversationId, AIAgent? agent = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conversationId);

        if (_threads.TryGetValue(conversationId, out var existingThread))
        {
            return existingThread;
        }

        var createdThread = await CreateThreadAsync(conversationId).ConfigureAwait(false);
        if (_threads.TryAdd(conversationId, createdThread))
        {
            return createdThread;
        }

        return _threads[conversationId];
    }

    /// <inheritdoc />
    public Task Set(string conversationId, AgentThread thread)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conversationId);
        ArgumentNullException.ThrowIfNull(thread);

        _threads[conversationId] = thread;
        return Task.CompletedTask;
    }

    private async Task<AgentThread> CreateThreadAsync(string conversationId)
    {
        var messageStore = new FoundryConversationMessageStore(_itemsClient, conversationId);
        var messages = await messageStore.GetMessagesAsync().ConfigureAwait(false);
        return new FoundryConversationAgentThread(conversationId, messages);
    }
}
