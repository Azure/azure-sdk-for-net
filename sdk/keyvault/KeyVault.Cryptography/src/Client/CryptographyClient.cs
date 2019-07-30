// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Client
{
    using Azure.Core;
    using Azure.Core.Pipeline;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;

    /// <summary>
    /// The Cryptography Client 
    /// </summary>
    public class CryptographyClient
    {
        #region const
        const string DEFAULT_KV_SCOPE_URI = @"https://vault.azure.net/.default";
        #endregion

        #region fields

        #endregion

        #region Properties
        #region private properties
        /// <summary>
        /// Cryptography Client Options
        /// </summary>
        CryptographyClientOptions Options { get; }

        CryptographyOperation Operation { get; }

        /// <summary>
        /// KeyVault Uri
        /// </summary>
        Uri KeyVaultUri { get; }

        /// <summary>
        /// HttpPipeline
        /// </summary>
        HttpPipeline Pipeline {get;}
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        protected CryptographyClient() { }

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyVaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public CryptographyClient(Uri keyVaultUri, TokenCredential credential)
            : this(keyVaultUri, credential, new CryptographyClientOptions()) { }

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyVaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public CryptographyClient(Uri keyVaultUri, TokenCredential credential, CryptographyClientOptions options)
        {
            Check.NotNull(keyVaultUri, nameof(keyVaultUri));
            Check.NotNull(options, nameof(options));
            Check.NotNull(credential, nameof(credential));

            KeyVaultUri = keyVaultUri;
            Options = options;
            BearerTokenAuthenticationPolicy bearerAuthPolicy = new BearerTokenAuthenticationPolicy(credential, DEFAULT_KV_SCOPE_URI);

            Pipeline = HttpPipelineBuilder.Build(Options, bufferResponse: true, clientPolicies: bearerAuthPolicy);
        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions

        #endregion

    }
}
