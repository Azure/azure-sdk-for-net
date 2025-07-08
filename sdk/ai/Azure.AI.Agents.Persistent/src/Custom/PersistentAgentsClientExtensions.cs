// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Microsoft.Extensions.AI;

namespace Azure.AI.Agents.Persistent
{
    /// <summary>
    /// Provides extension methods for <see cref="PersistentAgentsClient"/>.
    /// </summary>
    public static class PersistentAgentsClientExtensions
    {
        /// <summary>
        /// Creates an <see cref="IChatClient"/> for a <see cref="PersistentAgentsClient"/> client for interacting with a specific agent.
        /// </summary>
        /// <param name="client">The <see cref="PersistentAgentsClient"/> instance to be accessed as an <see cref="IChatClient"/>.</param>
        /// <param name="agentId">The unique identifier of the agent with which to interact.</param>
        /// <param name="defaultThreadId">
        /// An optional existing thread identifier for the chat session. This serves as a default, and may be overridden per call to
        /// <see cref="IChatClient.GetResponseAsync"/> or <see cref="IChatClient.GetStreamingResponseAsync"/> via the <see cref="ChatOptions.ConversationId"/>
        /// property. If no thread ID is provided via either mechanism, a new thread will be created for the request.
        /// </param>
        /// <returns>An <see cref="IChatClient"/> instance configured to interact with the specified agent and thread.</returns>
        public static IChatClient AsIChatClient(this PersistentAgentsClient client, string agentId, string? defaultThreadId = null) =>
            new PersistentAgentsChatClient(client, agentId, defaultThreadId);
    }
}
