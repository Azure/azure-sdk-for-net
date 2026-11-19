// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Extension members on <see cref="ClientConnectionProvider"/> that produce
/// Foundry-project-specific agent clients.
/// </summary>
public static partial class ClientConnectionProviderExtensions
{
    // Extension members can't add fields to the provider; this keeps one client per provider without extending its lifetime.
    private static readonly ConditionalWeakTable<ClientConnectionProvider, AgentAdministrationClient> s_agentAdministrationClients = new();

    extension(ClientConnectionProvider connectionProvider)
    {
        /// <summary>
        /// Gets the <see cref="AgentAdministrationClient"/> for this <see cref="ClientConnectionProvider"/>.
        /// The client is created with default options on first access, as <c>GetProjectAgentsClient()</c> does,
        /// and the same instance is returned afterwards.
        /// </summary>
        public AgentAdministrationClient AgentAdministrationClient
            => s_agentAdministrationClients.GetValue(connectionProvider, static provider => provider.GetProjectAgentsClient());
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
