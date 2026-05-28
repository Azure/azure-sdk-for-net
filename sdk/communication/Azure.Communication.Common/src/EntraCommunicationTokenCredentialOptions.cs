// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>
    /// The Entra Communication Token Options.
    /// </summary>
    public class EntraCommunicationTokenCredentialOptions
    {
        private static string[] DefaultScopes = { EntraCommunicationTokenScopes.DefaultScopes };
        private string[] _scopes;

        /// <summary>
        /// The URI of the Azure Communication Services resource.
        /// </summary>
        public string ResourceEndpoint { get; }

        /// <summary>
        /// The credential capable of fetching an Entra user token. You can provide any implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        public TokenCredential TokenCredential { get; }

        /// <summary>
        /// The scopes required for the Entra user token. These scopes determine the permissions granted to the token. For example, ["https://communication.azure.com/clients/VoIP"].
        /// </summary>
        public string[] Scopes {
            get => _scopes;
            set
            {
                _scopes = ValidateScopes(value);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EntraCommunicationTokenCredentialOptions"/>.
        /// </summary>
        /// <param name="resourceEndpoint">The URI of the Azure Communication Services resource.For example, https://myResource.communication.azure.com.</param>
        /// <param name="entraTokenCredential">The credential capable of fetching an Entra user token.</param>
        public EntraCommunicationTokenCredentialOptions(
            string resourceEndpoint,
            TokenCredential entraTokenCredential)
        {
            Argument.AssertNotNullOrEmpty(resourceEndpoint, nameof(resourceEndpoint));
            Argument.AssertNotNull(entraTokenCredential, nameof(entraTokenCredential));

            this.ResourceEndpoint = resourceEndpoint;
            this.TokenCredential = entraTokenCredential;
            this.Scopes = DefaultScopes;
        }

        private static string[] ValidateScopes(string[] scopes)
        {
            if (scopes == null || scopes.Length == 0)
            {
                throw new ArgumentException(
                    $"Scopes must not be null or empty. Ensure all scopes start with either {EntraCommunicationTokenScopes.TeamsExtensionScopePrefix} or {EntraCommunicationTokenScopes.CommunicationClientsScopePrefix}.", nameof(scopes));
            }

            if (scopes.All(item => item.StartsWith(EntraCommunicationTokenScopes.TeamsExtensionScopePrefix))
                || scopes.All(item => item.StartsWith(EntraCommunicationTokenScopes.CommunicationClientsScopePrefix)))
            {
                return scopes;
            }

            throw new ArgumentException($"Scopes validation failed. Ensure all scopes start with either {EntraCommunicationTokenScopes.TeamsExtensionScopePrefix} or {EntraCommunicationTokenScopes.CommunicationClientsScopePrefix}.", nameof(_scopes));
        }
    }
}
