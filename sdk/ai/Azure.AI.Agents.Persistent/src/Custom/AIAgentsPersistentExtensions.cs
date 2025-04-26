// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    /// <summary>
    /// The Azure AI Agents Persistent extensions.
    /// </summary>
    public static class AIAgentsPersistentExtensions
    {
        /// <summary>
        /// Gets the agents client.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static AgentsAdministrationClient GetAgentsClient(this ConnectionProvider provider)
        {
            AgentsAdministrationClient agentsClient = provider.Subclients.GetClient(() => CreateAdministrationAgentsClient(provider), null);
            return agentsClient;
        }

        private static AgentsAdministrationClient CreateAdministrationAgentsClient(this ConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(PersistentAgentsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new AgentsAdministrationClient(uri, connection.Credential as TokenCredential)
            : new AgentsAdministrationClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
        }
    }
}
