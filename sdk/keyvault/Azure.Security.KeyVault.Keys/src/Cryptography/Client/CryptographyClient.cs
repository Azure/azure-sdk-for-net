// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Client
{
    using Azure.Core;
    using Azure.Core.Pipeline;
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.CryptoProvider;
    using Azure.Security.KeyVault.Cryptography.Interface;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using Azure.Security.KeyVault.Keys;
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

        #region internal properties
        /// <summary>
        /// 
        /// </summary>
        internal TokenCredential Credentials { get; }
        /// <summary>
        /// Cryptography Client Options
        /// </summary>
        internal CryptographyClientOptions CryptoClientOptions { get; }

        /// <summary>
        /// HttpPipeline
        /// </summary>
        internal HttpPipeline Pipeline {get;}

        /// <summary>
        /// 
        /// </summary>
        internal ICryptographyProvider CryptoProvider { get; set; }
        #endregion

        /// <summary>
        /// KeyVault Uri
        /// </summary>
        public Uri KeyId { get; }

        /// <summary>
        /// KeyVault Key
        /// </summary>
        public Key KeyVaultKey { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        protected CryptographyClient()
        {
            KeyId = null;
            KeyVaultKey = null;
        }

        #region Local Crypto
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKeyUri"></param>
        public CryptographyClient(Uri keyVaultKeyUri)
            : this(keyVaultKeyUri, new CryptographyClientOptions()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKeyUri"></param>
        /// <param name="options"></param>
        public CryptographyClient(Uri keyVaultKeyUri, CryptographyClientOptions options)
        {
            KeyId = keyVaultKeyUri;
            options.EnableServerCryptographyOperations = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKey"></param>
        public CryptographyClient(Key keyVaultKey)
            : this(keyVaultKey, new CryptographyClientOptions()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKey"></param>
        /// <param name="options"></param>
        public CryptographyClient(Key keyVaultKey, CryptographyClientOptions options)
        {
            KeyVaultKey = keyVaultKey;
            options.EnableServerCryptographyOperations = false;
        }

        #endregion

        #region Server Crypto

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyVaultKeyUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public CryptographyClient(Uri keyVaultKeyUri, TokenCredential credential)
            : this(keyVaultKeyUri, credential, new CryptographyClientOptions()) { }

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyVaultKeyUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public CryptographyClient(Uri keyVaultKeyUri, TokenCredential credential, CryptographyClientOptions options) : this()
        {
            Check.NotNull(keyVaultKeyUri, nameof(keyVaultKeyUri));
            Check.NotNull(options, nameof(options));
            Check.NotNull(credential, nameof(credential));

            KeyId = keyVaultKeyUri;
            CryptoClientOptions = options;
            Credentials = credential;
            BearerTokenAuthenticationPolicy bearerAuthPolicy = new BearerTokenAuthenticationPolicy(credential, DEFAULT_KV_SCOPE_URI);
            Pipeline = HttpPipelineBuilder.Build(CryptoClientOptions, bufferResponse: true, clientPolicies: bearerAuthPolicy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKey"></param>
        /// <param name="credential"></param>
        public CryptographyClient(Key keyVaultKey, TokenCredential credential)
            : this(keyVaultKey, credential, new CryptographyClientOptions()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKey"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public CryptographyClient(Key keyVaultKey, TokenCredential credential, CryptographyClientOptions options) : this()
        {
            Check.NotNull(keyVaultKey, nameof(keyVaultKey));
            Check.NotNull(options, nameof(options));
            Check.NotNull(credential, nameof(credential));

            KeyVaultKey = keyVaultKey;
            KeyId = KeyVaultKey.VaultUri;
            CryptoClientOptions = options;
            Credentials = credential;

            BearerTokenAuthenticationPolicy bearerAuthPolicy = new BearerTokenAuthenticationPolicy(credential, DEFAULT_KV_SCOPE_URI);
            Pipeline = HttpPipelineBuilder.Build(CryptoClientOptions, bufferResponse: true, clientPolicies: bearerAuthPolicy);

            InitProvider();
        }

        #endregion

        #endregion

        #region Public Functions

        #endregion

        #region private functions
        void InitProvider()
        {
            switch(KeyVaultKey.KeyMaterial.KeyType)
            {
                case KeyType.EllipticCurve:
                    {
                        break;
                    }

                case KeyType.EllipticCurveHsm:
                    {
                        break;
                    }
                case KeyType.Octet:
                    {
                        break;
                    }
                case KeyType.Other:
                    {
                        break;
                    }
                case KeyType.Rsa:
                    {
                        CryptoProvider = new RsaCryptographyProvider(this);
                        break;
                    }
                case KeyType.RsaHsm:
                    {
                        break;
                    }
            }
        }
        #endregion

    }
}
