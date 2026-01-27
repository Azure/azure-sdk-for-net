// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence
{
    /// <summary>
    /// An interface for managing the persistence of agent threads.
    /// </summary>
    public interface IAgentThreadRepository
    {
        /// <summary>
        /// Gets an AgentThread instance based on the provided conversation ID.
        /// </summary>
        /// <param name="conversationId">Conversation ID for the thread.</param>
        /// <param name="agent">
        /// Optional. Agent instance to associate with the thread.
        /// If provided, this agent will be used for the thread.
        /// </param>
        /// <returns>
        /// An AgentThread instance associated with the given conversation ID.
        /// It the convertsation ID does not exist, a new AgentThread is created and returned.
        /// </returns>
        public Task<AgentThread> Get(string conversationId, AIAgent? agent = null);

        /// <summary>
        /// Sets the AgentThread instance for the given conversation ID.
        /// </summary>
        /// <param name="conversationId">The conversation Id related to the AgentThread.</param>
        /// <param name="thread">AgentThread instance.</param>
        /// <returns></returns>
        public Task Set(string conversationId, AgentThread thread);
    }

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
        public async Task<AgentThread> Get(string conversationId, AIAgent? agent = null)
        {
            if (!_threads.ContainsKey(conversationId))
            {
                agent ??= _agent;
                if (agent == null)
                {
                    throw new InvalidOperationException("AIAgent instance must be provided either in the instructor or in the method call.");
                }
                _threads[conversationId] = agent.GetNewThread();
            }
            return await Task.FromResult(_threads[conversationId]).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task Set(string conversationId, AgentThread agentThread)
        {
            _threads[conversationId] = agentThread;
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
