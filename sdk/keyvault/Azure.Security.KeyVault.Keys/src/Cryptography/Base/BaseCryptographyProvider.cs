// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Base
{
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Interface;
    using Azure.Security.KeyVault.Cryptography.Models;
    using Azure.Security.KeyVault.Keys.Cryptography.Interface;
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
    /// <typeparam name="T"></typeparam>
    internal class BaseCryptographyProvider<T> : ICryptographyOperations
        where T : IKeyVaultDefault
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public virtual T Defaults { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string Kid { get; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultCategoryName { get; }

        #region private properties
        CryptographyClientOptions CryptoClientOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected CryptographyClient CryptoClient { get; set; }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public BaseCryptographyProvider()
        {
            CryptoClientOptions = new CryptographyClientOptions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public BaseCryptographyProvider(CryptographyClient cryptoClient)
        {
            CryptoClient = cryptoClient;
            CryptoClientOptions = CryptoClient.CryptoClientOptions;
        }
        #endregion

        #region Public Functions

        #region virtual functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected virtual bool IsAlgorithmKindSupported(EncryptionAlgorithmKind algorithmKind)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ICryptographyOperations

        #region Decrypt
        public virtual Task<DecryptResult> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<DecryptResult> DecryptAsync(Stream ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Encrypt
        public virtual Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Wrap/UnWrap
        public virtual Task<WrapKeyResult> WrapKeyAsync(byte[] key, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public virtual Task<UnWrapKeyResult> UnwrapKeyAsync(byte[] encryptedKey, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Sign/Verify
        public Task<Tuple<byte[], string>> SignAsync(byte[] digest, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyAsync(byte[] digest, byte[] signature, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #endregion
    }
}
