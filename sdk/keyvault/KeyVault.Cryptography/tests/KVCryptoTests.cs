using Azure.Identity;
using Azure.Security.KeyVault.Cryptography.Client;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Cryptography.Tests
{
    public class KVCryptoTests: KVCryptoTestBase
    {

        public KVCryptoTests(bool isAsync): base(isAsync)
        {   
            TestDiagnostics = false;
        }

        protected override void TestInit()
        {
            //System.Environment.SetEnvironmentVariable(TEST_MODE_ENV_VARIABLE, "Record");
            //Recording.Mode = "Record";
        }


        [Test]
        void EncryptKey()
        {

        }

        [Test]
        public async Task InstantiateCryptoClient()
        {
            //System.Environment.SetEnvironmentVariable(TEST_MODE_ENV_VARIABLE, "Record");
            string keyName = Recording.GenerateId();
            Key key = await KVKeyClient.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            //RegisterForCleanup(key);
            Key getKey = await KVKeyClient.GetKeyAsync(keyName);
            VerifyKeysEqual(key, getKey);

            InitCryptoClient(key);

            //KVCryptoClient.CryptoProvider.EncryptAsync()
        }
    }
}
