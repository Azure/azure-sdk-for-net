//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System.Security.Cryptography;
using Microsoft.Azure.KeyVault.WebKey;
using Newtonsoft.Json;
using Xunit;

namespace KeyVault.WebKey.Tests
{
    public class TestSerialization
    {
        [Fact]
        public void KeyVaultWebKeyTestRoundtripAes()
        {
            Aes aes = Aes.Create();

            var keyOriginal = CreateJsonWebKey(aes);
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripRsaPublic()
        {
            RSA rsa = RSA.Create();

            var keyOriginal = CreateJsonWebKey(rsa.ExportParameters(true));
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripRsaPrivate()
        {
            RSA rsa = RSA.Create();

            var keyOriginal = CreateJsonWebKey(rsa.ExportParameters(true));
            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        [Fact]
        public void KeyVaultWebKeyTestRoundtripOperations()
        {
            Aes aes = Aes.Create();

            var keyOriginal = CreateJsonWebKey(aes);

            keyOriginal.KeyOps = JsonWebKeyOperation.AllOperations;

            var keyString = keyOriginal.ToString();

            var keyRecovered = JsonConvert.DeserializeObject<JsonWebKey>(keyString);

            Assert.Equal(keyOriginal, keyRecovered);
        }

        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaParameters">The RSA parameters object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        private JsonWebKey CreateJsonWebKey(RSAParameters rsaParameters)
        {
            var key = new JsonWebKey
            {
                Kty = JsonWebKeyType.Rsa,
                E = rsaParameters.Exponent,
                N = rsaParameters.Modulus,
                D = rsaParameters.D,
                DP = rsaParameters.DP,
                DQ = rsaParameters.DQ,
                QI = rsaParameters.InverseQ,
                P = rsaParameters.P,
                Q = rsaParameters.Q
            };

            return key;
        }

        /// <summary>
        /// Converts an AES object to a WebKey of type Octet
        /// </summary>
        /// <param name="aesProvider"></param>
        /// <returns></returns>
        private JsonWebKey CreateJsonWebKey(Aes aesProvider)
        {
            if (aesProvider == null)
                throw new System.ArgumentNullException("aesProvider");

            var key = new JsonWebKey
            {
                Kty = JsonWebKeyType.Octet,
                K = aesProvider.Key
            };
            return key;
        }

    }
}
