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
        private readonly Dictionary<string, AgentThread> _threads = new();
        private readonly AIAgent? _agent;

        /// <summary>
        /// Instructor of InMemoryAgentThreadRepository
        /// </summary>
        /// <param name="agent">AIAgent instance to associate with the threads.</param>
        public InMemoryAgentThreadRepository(AIAgent? agent = null)
        {
            _agent = agent;
        }

        /// <inheritdoc/>
        public Task<AgentThread> Get(string conversationId, AIAgent? agent = null)
        {
            if (!_threads.ContainsKey(conversationId))
            {
                agent ??= _agent;

                if (agent == null)
                {
                    throw new InvalidOperationException("Agent instance must be provided either in the instructor or in the method call.");
                }
                return Task.FromResult(agent.GetNewThread());
            }
            return Task.FromResult(_threads[conversationId]);
        }

        /// <inheritdoc/>
        public Task Set(string conversationId, AgentThread agentThread)
        {
            _threads[conversationId] = agentThread;
            return Task.CompletedTask;
        }
    }
}
