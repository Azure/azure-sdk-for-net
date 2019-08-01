// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Base
{
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Interface;
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
    /// <typeparam name="T"></typeparam>
    public class BaseCryptographyProvider<T> : ICryptographyProvider
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
        /// <param name="options"></param>
        BaseCryptographyProvider(CryptographyClientOptions options)
        {
            CryptoClientOptions = options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public BaseCryptographyProvider(CryptographyClient cryptoClient)
        {
            CryptoClient = cryptoClient;
        }
        #endregion

        #region Public Functions

        #region ICryptoProvider
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<byte[]> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
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
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<byte[]> DecryptAsync(Stream ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
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
        public virtual Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
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
        public virtual Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<Tuple<byte[], string>> SignAsync(byte[] digest, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedKey"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<byte[]> UnwrapKeyAsync(byte[] encryptedKey, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="signature"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<bool> VerifyAsync(byte[] digest, byte[] signature, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task<Tuple<byte[], string>> WrapKeyAsync(byte[] key, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LocalCrypto

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected virtual Task<byte[]> LocalDecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKindEnum algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ServerCrypto

        #endregion

        #region virtual functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected virtual bool IsAlgorithmKindSupported(EncryptionAlgorithmKindEnum algorithmKind)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region private functions

        #endregion
    }
}
