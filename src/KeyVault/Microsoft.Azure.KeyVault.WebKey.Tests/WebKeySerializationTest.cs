// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System.Security.Cryptography;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeySerializationTest
    {
        [Fact]
        public void KeyVaultWebKeyTestRoundtripAes()
        {
            Aes aes = Aes.Create();

            var keyOriginal = new JsonWebKey(aes);
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripRsaPublic()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var keyOriginal = new JsonWebKey(rsa.ExportParameters(true));
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripRsaPrivate()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var keyOriginal = new JsonWebKey(rsa.ExportParameters(true));
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripOperations()
        {
            Aes aes = Aes.Create();

            var keyOriginal = new JsonWebKey(aes);

            keyOriginal.KeyOps = JsonWebKeyOperation.AllOperations;

            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

    }
}
