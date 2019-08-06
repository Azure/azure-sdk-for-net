// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Tests
{
    using Azure.Identity;
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Models;
    using Azure.Security.KeyVault.Keys;
    using Azure.Security.KeyVault.Keys.Tests;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Security.Cryptography;

    public class KVCryptoTests: CryptoTestBase
    {
        static byte[] CEK = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };

        public KVCryptoTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        //public KVCryptoTests() : base()
        //{
        //    TestDiagnostics = false;
        //}

        [Test]
        public async Task EncryptRsa15Key()
        {
            Key key = await GetKeyAsync(KeyType.Rsa, verifyCreatedKey: false);
            InitCryptoClient(key);
            EncryptResult encryptedData = await KVCryptoClient.CryptographyOperations.EncryptAsync(CEK, null, null, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);
            Assert.NotNull(encryptedData);
            Assert.AreEqual(encryptedData.Algorithm, Base.EncryptionAlgorithmKind.Rsa15);
        }

        [Test]
        public async Task DecryptRsa15Key()
        {
            Key key = await GetKeyAsync(KeyType.Rsa, verifyCreatedKey: false);
            InitCryptoClient(key);
            EncryptResult encryptedData = await KVCryptoClient.CryptographyOperations.EncryptAsync(CEK, null, null, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);
            Assert.NotNull(encryptedData);
            Assert.AreEqual(encryptedData.Algorithm, Base.EncryptionAlgorithmKind.Rsa15);

            DecryptResult decryptedData = await KVCryptoClient.CryptographyOperations.DecryptAsync(encryptedData.CipherText, null, null, null, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);
            Assert.True(decryptedData.DecryptedData.SequenceEqual(CEK));
        }

        [Test]
        public async Task WrapRsa15Key()
        {
            Key key = await GetKeyAsync(KeyType.Rsa, verifyCreatedKey: false);
            Assert.AreEqual(key.KeyMaterial.KeyType, KeyType.Rsa);
            InitCryptoClient(key);

            Aes aesProvider = Aes.Create();
            byte[] keyData = aesProvider.Key;
            WrapKeyResult wkr = await KVCryptoClient.CryptographyOperations.WrapKeyAsync(keyData, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);
        }

        #region private functions
        async Task<Key> GetKeyAsync(KeyType keyType, bool verifyCreatedKey)
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.Rsa);
            //RegisterForCleanup(key);

            if(verifyCreatedKey)
            {
                Key getKey = await Client.GetKeyAsync(keyName);
                AssertKeysEqual(key, getKey);
            }

            return key;
        }
        #endregion
    }
}
