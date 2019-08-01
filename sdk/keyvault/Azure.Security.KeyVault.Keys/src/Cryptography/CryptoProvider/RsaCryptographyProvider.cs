// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.CryptoProvider
{
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Defaults;
    using Azure.Security.KeyVault.Cryptography.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class RsaCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const
        const string RSA_CRYPTO_DEFAULT_NAME = "RSAProviderDefaults";
        #endregion

        #region fields
        CryptoProviderDefaults _cryptoProviderDefaults;
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public override CryptoProviderDefaults Defaults
        {
            // These defaults should match local/server defaults
            // meaning local/server defaults should be exactly the same as these defaults
            get
            {
                if(_cryptoProviderDefaults == null)
                {
                    _cryptoProviderDefaults = new CryptoProviderDefaults(EncryptionAlgorithmKindEnum.RsaOaep, EncryptionAlgorithmKindEnum.RsaOaep, EncryptionAlgorithmKindEnum.Rsa256, RSA_CRYPTO_DEFAULT_NAME);
                }

                return _cryptoProviderDefaults;
            }
        }

        #region private properties
        RsaLocalCryptographyProvider LocalCryptoProvider { get; set; }

        RsaServerCryptographyProvider ServerCryptoProvider { get; set; }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public RsaCryptographyProvider() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public RsaCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient)
        {
            if (CryptoClient.CryptoClientOptions.EnableLocalCryptographyOperations)
            {
                LocalCryptoProvider = new RsaLocalCryptographyProvider(CryptoClient);
            }

            if (CryptoClient.CryptoClientOptions.EnableServerCryptographyOperations)
            {
                ServerCryptoProvider = new RsaServerCryptographyProvider(CryptoClient);
            }
        }
        #endregion

        #region Public Functions

        #region ICryptoProvider
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            Task<EncryptResult> result = null;
            if(LocalCryptoProvider != null)
            {
                result =  LocalCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }
            else if(ServerCryptoProvider != null)
            {
                result = ServerCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }

            return await result.ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            return base.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
        }
        #endregion

        #endregion

        #region private functions

        #endregion

    }

    class RsaLocalCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public RsaLocalCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient) { }
        #endregion

        #region Public Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
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
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            return base.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
        }

        #region Virtual Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected override bool IsAlgorithmKindSupported(EncryptionAlgorithmKindEnum algorithmKind)
        {
            return base.IsAlgorithmKindSupported(algorithmKind);
        }
        #endregion

        #endregion

        #region private functions

        #endregion

    }

    class RsaServerCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RsaServerCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient) { }
        #endregion

        #region Public Functions

        #region ICryptoProvider
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {

            return null;
        }

        #endregion


        #region Virtual Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected override bool IsAlgorithmKindSupported(EncryptionAlgorithmKindEnum algorithmKind)
        {
            return base.IsAlgorithmKindSupported(algorithmKind);
        }
        #endregion
        #endregion

        #region private functions

        #endregion

    }
}
