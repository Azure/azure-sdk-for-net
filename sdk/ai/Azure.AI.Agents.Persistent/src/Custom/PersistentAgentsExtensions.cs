// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Runtime.Serialization;
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
        public static PersistentAgentsClient GetPersistentAgentsClient(this ClientConnectionProvider provider)
        {
            PersistentAgentsAdministrationKey key = new();
            PersistentAgentsAdministrationClient agentsClient = provider.Subclients.GetClient(key , () => CreateAdministrationAgentsClient(provider));
            return new PersistentAgentsClient(agentsClient);
        }

        private static PersistentAgentsAdministrationClient CreateAdministrationAgentsClient(this ClientConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(PersistentAgentsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            if (connection.Credential is TokenCredential cred)
                return new PersistentAgentsAdministrationClient(uri, cred);
            throw new InvalidOperationException($"PersistentAgentsAdministrationClient does not support {connection.CredentialKind}.");
        }

        private record PersistentAgentsAdministrationKey();
    }
}
