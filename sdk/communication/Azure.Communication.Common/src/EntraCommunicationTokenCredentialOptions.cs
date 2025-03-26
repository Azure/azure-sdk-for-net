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
        private static string[] DefaultScopes = { "https://communication.azure.com/clients/.default" };
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
        public string[] Scopes { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="EntraCommunicationTokenCredentialOptions"/>.
        /// </summary>
        /// <param name="resourceEndpoint">The URI of the Azure Communication Services resource.For example, https://myResource.communication.azure.com.</param>
        /// <param name="entraTokenCredential">The credential capable of fetching an Entra user token.</param>
        /// <param name="scopes">One or more scopes required for the Entra user token. Optional, "https://communication.azure.com/clients/VoIP" is be used if not provided.</param>"
        public EntraCommunicationTokenCredentialOptions(
            string resourceEndpoint,
            TokenCredential entraTokenCredential,
            params string[] scopes)
        {
            Argument.AssertNotNullOrEmpty(resourceEndpoint, nameof(resourceEndpoint));
            Argument.AssertNotNull(entraTokenCredential, nameof(entraTokenCredential));

            this.ResourceEndpoint = resourceEndpoint;
            this.TokenCredential = entraTokenCredential;

            var validScopes = scopes?.Where(s => !string.IsNullOrEmpty(s)).ToArray() ?? Array.Empty<string>();
            this.Scopes = validScopes.Length > 0 ? validScopes : DefaultScopes;
        }
    }
}
