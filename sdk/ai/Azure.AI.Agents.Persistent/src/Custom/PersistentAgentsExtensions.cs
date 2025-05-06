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
        public static PersistentAgentsAdministration GetPersistentAgentAdministrationClient(this ClientConnectionProvider provider)
        {
            PersistentAgentsAdministrationKey key = new();
            PersistentAgentsAdministration agentsClient = provider.Subclients.GetClient(key , () => CreateAdministrationAgentsClient(provider));
            return agentsClient;
        }

        private static PersistentAgentsAdministration CreateAdministrationAgentsClient(this ClientConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(PersistentAgentsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.CredentialKind == CredentialKind.TokenCredential
            ? new PersistentAgentsAdministration(uri, connection.Credential as TokenCredential)
            : new PersistentAgentsAdministration(uri, new AzureKeyCredential((string)connection.Credential!));
        }

        private record PersistentAgentsAdministrationKey();
    }
}
