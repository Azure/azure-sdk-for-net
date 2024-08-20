// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="AzureApplicationCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    internal class AzureApplicationCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies the client id of the azure ManagedIdentity in the case of user assigned identity.
        /// </summary>
        public ManagedIdentityId ManagedIdentityId { get; set; } = GetManagedIdentityIdFromEnvironment(EnvironmentVariables.ClientId);

        private static ManagedIdentityId GetManagedIdentityIdFromEnvironment(string clientId)
        {
            return !string.IsNullOrEmpty(clientId) ? ManagedIdentityId.FromUserAssignedClientId(clientId) : ManagedIdentityId.SystemAssigned;
        }
    }
}
