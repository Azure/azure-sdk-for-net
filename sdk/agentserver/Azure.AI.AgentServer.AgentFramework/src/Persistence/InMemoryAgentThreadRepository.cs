// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence
{
    /// <summary>
    /// An in-memory implementation of the IAgentThreadRepository interface.
    /// </summary>
    public class InMemoryAgentThreadRepository : IAgentThreadRepository
    {
        private readonly Dictionary<string, AgentSession> _sessions = new();
        private readonly AIAgent? _agent;

        /// <summary>
        /// Instructor of InMemoryAgentThreadRepository
        /// </summary>
        /// <param name="agent">AIAgent instance to associate with the sessions.</param>
        public InMemoryAgentThreadRepository(AIAgent? agent = null)
        {
            _agent = agent;
        }

        /// <inheritdoc/>
        public async Task<AgentSession> Get(string? conversationId, AIAgent? agent = null)
        {
            if (string.IsNullOrEmpty(conversationId) || !_sessions.ContainsKey(conversationId))
            {
                agent ??= _agent;

                if (agent == null)
                {
                    throw new InvalidOperationException("Agent instance must be provided either in the constructor or in the method call.");
                }
                return await agent.CreateSessionAsync().ConfigureAwait(false);
            }
            return _sessions[conversationId];
        }

        /// <inheritdoc/>
        public Task Set(string? conversationId, AgentSession session)
        {
            if (string.IsNullOrEmpty(conversationId))
            {
                return Task.CompletedTask;
            }

            _sessions[conversationId] = session;
            return Task.CompletedTask;
        }
    }
}
