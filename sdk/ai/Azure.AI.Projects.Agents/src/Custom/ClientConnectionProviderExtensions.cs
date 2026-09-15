// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Extension methods on <see cref="ClientConnectionProvider"/> that produce
/// Foundry-project-specific agent clients.
/// </summary>
public static partial class ClientConnectionProviderExtensions
{
    extension(ClientConnectionProvider connectionProvider)
    {
        /// <summary>
        /// Builds an <see cref="AgentAdministrationClient"/> from the connection
        /// information surfaced by this <see cref="ClientConnectionProvider"/>.
        /// </summary>
        /// <param name="endpoint">Optional endpoint override; if null, the locator from the connection is used.</param>
        /// <param name="options">Optional client configuration options.</param>
        public AgentAdministrationClient GetProjectAgentsClient(Uri endpoint = null, AgentAdministrationClientOptions options = null)
        {
            ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.AgentsPipelinePassthrough");
            ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
            options ??= new();
            // If the option without endpoint were provided, make sure, we still set it.
            endpoint ??= new(pipelineConnection.Locator);
            return new AgentAdministrationClient(new ClientDiagnostics(options, true), smuggledPipeline, endpoint, options.Version);
        }
    }
}
