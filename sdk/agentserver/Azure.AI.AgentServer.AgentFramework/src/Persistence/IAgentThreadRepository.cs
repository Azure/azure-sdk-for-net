// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence
{
    /// <summary>
    /// An interface for managing the persistence of agent sessions.
    /// </summary>
    public interface IAgentThreadRepository
    {
        /// <summary>
        /// Gets an AgentSession instance based on the provided conversation ID.
        /// </summary>
        /// <param name="conversationId">Conversation ID for the session. When null, a new stateless session is created.</param>
        /// <param name="agent">
        /// Optional. Agent instance to associate with the session.
        /// If provided, this agent will be used for the session.
        /// </param>
        /// <returns>
        /// An AgentSession instance associated with the given conversation ID.
        /// If the conversation ID does not exist, a new AgentSession is created and returned.
        /// If the conversation ID is null, a new stateless session is returned.
        /// </returns>
        public Task<AgentSession> Get(string? conversationId, AIAgent? agent = null);

        /// <summary>
        /// Sets the AgentSession instance for the given conversation ID.
        /// </summary>
        /// <param name="conversationId">The conversation Id related to the AgentSession. When null, the operation is a no-op.</param>
        /// <param name="session">AgentSession instance.</param>
        /// <returns></returns>
        public Task Set(string? conversationId, AgentSession session);
    }
}
