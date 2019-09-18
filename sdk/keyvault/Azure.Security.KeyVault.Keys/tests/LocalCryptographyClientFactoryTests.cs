// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class LocalCryptographyClientFactoryTests
    {
        [TestCaseSource(nameof(GetCreateData))]
        public void Create(JsonWebKey jwk, Type clientType)
        {
            ICryptographyProvider client = LocalCryptographyClientFactory.Create(jwk);
            Assert.IsInstanceOf(clientType, client, "Key {0} of type {1} did not yield client type {2}", jwk.KeyId, jwk.KeyType, clientType.Name);
        }

        [Test]
        public void CreateThrows()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyId = "invalid",
                KeyType = new KeyType("invalid"),
            };

            Assert.Throws<NotSupportedException>(() => LocalCryptographyClientFactory.Create(jwk));
        }

        private static IEnumerable<object[]> GetCreateData()
        {
            Aes aes = Aes.Create();
            yield return new object[] { new JsonWebKey(aes) { KeyId = nameof(aes) }, typeof(AesCryptographyClient) };

#if !NET461
            ECDsa ecdsa = ECDsa.Create();
            yield return new object[] { new JsonWebKey(ecdsa, false) { KeyId = "ecdsaPublic" }, typeof(EcCryptographyClient) };
            yield return new object[] { new JsonWebKey(ecdsa, true) { KeyId = "ecdsaPrivate" }, typeof(EcCryptographyClient) };
#endif

            RSA rsa = RSA.Create();
            yield return new object[] { new JsonWebKey(rsa, false) { KeyId = "rsaPublic" }, typeof(RsaCryptographyClient) };
            yield return new object[] { new JsonWebKey(rsa, true) { KeyId = "rsaPrivate" }, typeof(RsaCryptographyClient) };
        }
    }
}
