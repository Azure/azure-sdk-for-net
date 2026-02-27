// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Configuration for creating a session with an agent as the main AI actor.
    /// When using an agent session, the agent's configuration (tools, instructions,
    /// temperature, etc.) is managed in the Foundry portal, not in session code.
    /// </summary>
    /// <remarks>
    /// This is distinct from <see cref="VoiceLiveToolDefinition"/> which represents agent tools
    /// that can be added to model-centric sessions.
    /// </remarks>
    public class AgentSessionConfig
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AgentSessionConfig"/>.
        /// </summary>
        /// <param name="agentName">The name of the Foundry agent to use.</param>
        /// <param name="projectName">The name of the Azure AI project which the agent belongs to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="agentName"/> or <paramref name="projectName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="agentName"/> or <paramref name="projectName"/> is empty.</exception>
        public AgentSessionConfig(string agentName, string projectName)
        {
            Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            AgentName = agentName;
            ProjectName = projectName;
        }

        /// <summary>
        /// The name of the Foundry agent to use.
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// The name of the Azure AI project which the agent belongs to.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// The version of the agent to use. If not specified, the latest version will be used.
        /// </summary>
        public string? AgentVersion { get; set; }

        /// <summary>
        /// The conversation ID to continue. If not specified, a new conversation will be created.
        /// </summary>
        public string? ConversationId { get; set; }

        /// <summary>
        /// The client ID of a user-assigned managed identity used for authenticating to the Foundry Agent service.
        /// If not specified, the system-assigned managed identity will be used.
        /// </summary>
        public string? AuthenticationIdentityClientId { get; set; }

        /// <summary>
        /// The Foundry resource name to use for cross-resource agent mode.
        /// When set, the agent service endpoint will use this resource instead of the one from the connection URL.
        /// </summary>
        public string? FoundryResourceOverride { get; set; }
    }
}

#nullable restore
