// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Tests
{
    using Azure.Identity;
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Keys;
    using Azure.Security.KeyVault.Keys.Tests;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class KVCryptoTests: CryptoTestBase
    {

        public KVCryptoTests(bool isAsync): base(isAsync)
        {   
            TestDiagnostics = false;
        }


        [Test]
        void EncryptKey()
        {

        }

        [Test]
        public async Task InstantiateCryptoClient()
        {
            Key key = await GetKeyAsync(KeyType.Rsa, verifyCreatedKey: false);
            key = null;
            InitCryptoClient(key);



        }

        #region private functions
        async Task<Key> GetKeyAsync(KeyType keyType, bool verifyCreatedKey)
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
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
