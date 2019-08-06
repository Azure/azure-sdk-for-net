// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography
{
    using Azure.Core;
    using Azure.Core.Pipeline;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using Azure.Security.KeyVault.Keys;
    using Azure.Security.KeyVault.Keys.Cryptography;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

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

        BaseCryptographyProvider CryptoProvider { get; set; }

        /// <summary>
        /// HttpPipeline
        /// </summary>
        internal HttpPipeline Pipeline {get;}
        #endregion

        /// <summary>
        /// KeyVault Uri
        /// </summary>
        internal KeyId KeyId { get; }

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

        //public CryptographyClient(Uri keyId)
        //    : this(keyId, new CryptographyClientOptions()) { }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="keyVaultKeyUri"></param>
        ///// <param name="options"></param>
        //public CryptographyClient(Uri keyVaultKeyUri, CryptographyClientOptions options)
        //{
        //    KeyId = keyVaultKeyUri;
        //    options.EnableServerCryptographyOperations = false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="keyVaultKey"></param>
        //public CryptographyClient(Key keyVaultKey)
        //    : this(keyVaultKey, new CryptographyClientOptions()) { }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="keyVaultKey"></param>
        ///// <param name="options"></param>
        //public CryptographyClient(Key keyVaultKey, CryptographyClientOptions options)
        //{
        //    KeyVaultKey = keyVaultKey;
        //    options.EnableServerCryptographyOperations = false;
        //}

        #endregion

        #region Server Crypto

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyId">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, new CryptographyClientOptions()) { }

        /// <summary>
        /// Initializes a new instance of Cryptography Client
        /// </summary>
        /// <param name="keyId">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options) : this()
        {
            Check.NotNull(keyId, nameof(keyId));
            Check.NotNull(options, nameof(options));
            Check.NotNull(credential, nameof(credential));

            KeyId = new KeyId(keyId);
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
            KeyId = new KeyId(KeyVaultKey.VaultUri, KeyVaultKey.Name, KeyVaultKey.Version);
            CryptoClientOptions = options;
            Credentials = credential;

            BearerTokenAuthenticationPolicy bearerAuthPolicy = new BearerTokenAuthenticationPolicy(credential, DEFAULT_KV_SCOPE_URI);
            Pipeline = HttpPipelineBuilder.Build(CryptoClientOptions, bufferResponse: true, clientPolicies: bearerAuthPolicy);

            InitProvider();
        }

        #endregion

        #endregion

        #region Public Functions
        #region CryptographyOperations

        #region Decrypt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<DecryptResult> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual DecryptResult Decrypt(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<DecryptResult> DecryptAsync(Stream ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<DecryptResult> Decrypt(Stream ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Encrypt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual EncryptResult Encrypt(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual EncryptResult Encrypt(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Wrap/UnWrap
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<WrapKeyResult> WrapKeyAsync(byte[] key, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual WrapKeyResult WrapKey(byte[] key, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedKey"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<UnWrapKeyResult> UnwrapKeyAsync(byte[] encryptedKey, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedKey"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual UnWrapKeyResult UnwrapKey(byte[] encryptedKey, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Sign/Verify
        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Tuple<byte[], string>> SignAsync(byte[] digest, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Tuple<byte[], string>> Sign(byte[] digest, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="signature"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<bool> VerifyAsync(byte[] digest, byte[] signature, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="signature"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual bool Verify(byte[] digest, byte[] signature, EncryptionAlgorithmKind algorithmKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
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
