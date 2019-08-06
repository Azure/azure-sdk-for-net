// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography
{
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
    internal class BaseCryptographyProvider
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties
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

        #region CryptographyOperations

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
