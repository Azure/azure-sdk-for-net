// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>
    /// The Communication Token Refresh Options
    /// </summary>
    public class EntraCommunicationTokenCredentialOptions
    {
        /// <summary>
        /// The initial token.
        /// </summary>
        public string ResourceEndpoint { get; }

        /// <summary>
        /// Entra ID token credential
        /// </summary>
        public TokenCredential TokenCredential { get; }

        /// <summary>
        /// Scopes
        /// </summary>
        public string[] Scopes { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="EntraCommunicationTokenCredentialOptions"/>.
        /// </summary>
        /// <param name="resourceEndpoint">Azure Communication Services resource endpoint URL. e.g. https://myResource.communication.azure.com</param>
        /// <param name="entraTokenCredential">Entra token credential</param>
        /// <param name="scopes">Scopes</param>
        public EntraCommunicationTokenCredentialOptions(
            string resourceEndpoint,
            TokenCredential entraTokenCredential,
            string[] scopes)
        {
            Argument.AssertNotNull(resourceEndpoint, nameof(resourceEndpoint));
            Argument.AssertNotNull(entraTokenCredential, nameof(entraTokenCredential));

            this.ResourceEndpoint = resourceEndpoint;
            this.TokenCredential = entraTokenCredential;
            this.Scopes = scopes;
        }
    }
}
