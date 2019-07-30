using Azure.Identity;
using Azure.Security.KeyVault.Cryptography.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.KeyVault.Cryptography.Tests
{
    public class KVCryptoTests
    {
        [Test]
        void EncryptKey()
        {

        }

        [Test]
        public void InstantiateCryptoClient()
        {
            CryptographyClient cc = new CryptographyClient(new Uri("http://localhost"), new DefaultAzureCredential());


        }
    }
}
