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
    public static class PersistentAgentsExtensions
    {
        /// <summary>
        /// Gets the agents client.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static PersistentAgentsAdministrationClient GetPersistentAgentAdministrationClient(this ConnectionProvider provider)
        {
            PersistentAgentsAdministrationClient agentsClient = provider.Subclients.GetClient(() => CreateAdministrationAgentsClient(provider), null);
            return agentsClient;
        }

        private static PersistentAgentsAdministrationClient CreateAdministrationAgentsClient(this ConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(PersistentAgentsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new PersistentAgentsAdministrationClient(uri, connection.Credential as TokenCredential)
            : new PersistentAgentsAdministrationClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
        }
    }
}
