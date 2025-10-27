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

        /// <summary>Creates an <see cref="AITool"/> to represent a <see cref="ToolDefinition"/>.</summary>
        /// <param name="tool">The tool to wrap as an <see cref="AITool"/>.</param>
        /// <returns>The <paramref name="tool"/> wrapped as an <see cref="AITool"/>.</returns>
        /// <remarks>
        /// <para>
        /// The returned tool is only suitable for use with the <see cref="IChatClient"/> returned by
        /// <see cref="AsIChatClient"/> (or <see cref="IChatClient"/>s that delegate
        /// to such an instance). It is likely to be ignored by any other <see cref="IChatClient"/> implementation.
        /// </para>
        /// <para>
        /// When a tool has a corresponding <see cref="AITool"/>-derived type already defined in Microsoft.Extensions.AI,
        /// such as <see cref="AIFunction"/>, <see cref="HostedWebSearchTool"/>, or <see cref="HostedFileSearchTool"/>,
        /// those types should be preferred instead of this method, as they are more portable,
        /// capable of being respected by any <see cref="IChatClient"/> implementation. This method does not attempt to
        /// map the supplied <see cref="ToolDefinition"/> to any of those types, it simply wraps it as-is:
        /// the <see cref="IChatClient"/> returned by <see cref="AsIChatClient"/> will be able to unwrap the
        /// <see cref="ToolDefinition"/> when it processes the list of tools.
        /// </para>
        /// </remarks>
        public static AITool AsAITool(this ToolDefinition tool)
        {
            Argument.AssertNotNull(tool, nameof(tool));

            return new PersistentAgentsChatClient.ToolDefinitionAITool(tool);
        }
    }
}
