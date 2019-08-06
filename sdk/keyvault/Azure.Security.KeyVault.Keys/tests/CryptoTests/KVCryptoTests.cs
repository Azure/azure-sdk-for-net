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
        void EncryptKey()
        {

        }

        [Test]
        public async Task InstantiateCryptoClient()
        {

            Key key = await GetKeyAsync(KeyType.Rsa, verifyCreatedKey: false);
            //key = null;
            InitCryptoClient(key);

            CryptographyOperationResult encryptedData = await KVCryptoClient.CryptographyOperations.EncryptAsync(CEK, null, null, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);

            Assert.NotNull(encryptedData);

            CryptographyOperationResult decryptedData = await KVCryptoClient.CryptographyOperations.DecryptAsync(encryptedData.CipherText, null, null, null, Base.EncryptionAlgorithmKind.Rsa15, default(CancellationToken)).ConfigureAwait(false);

            Assert.True(decryptedData.CipherText.SequenceEqual(CEK));

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
