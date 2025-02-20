// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class LocalCryptographyProviderFactoryTests
    {
        [TestCaseSource(nameof(GetCreateData))]
        public void Create(JsonWebKey jwk, Type clientType)
        {
            ICryptographyProvider provider = LocalCryptographyProviderFactory.Create(new KeyVaultKey { Key = jwk });
            Assert.IsInstanceOf(clientType, provider, "Key {0} of type {1} did not yield client type {2}", jwk.Id, jwk.KeyType, clientType.Name);
        }

        [Test]
        public void NotSupported()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                Id = "test",
                KeyType = new KeyType("invalid"),
            };

            ICryptographyProvider provider = LocalCryptographyProviderFactory.Create(new KeyVaultKey { Key = jwk });
            Assert.IsNull(provider);
        }

        [Test]
        public void NoKey()
        {
            ICryptographyProvider provider = LocalCryptographyProviderFactory.Create(null);
            Assert.IsNull(provider);
        }

        [Test]
        public void NoKeyMaterial()
        {
            KeyVaultKey key = new KeyVaultKey();

            ICryptographyProvider provider = LocalCryptographyProviderFactory.Create(key);
            Assert.IsNull(provider);
        }

        [Test]
        public void NoOctKeyMaterial()
        {
            JsonWebKey jwk = new(new[] { KeyOperation.WrapKey, KeyOperation.UnwrapKey })
            {
                KeyType = KeyType.OctHsm,
            };

            ICryptographyProvider provider = LocalCryptographyProviderFactory.Create(jwk, null);
            Assert.IsNull(provider);
        }

        private static IEnumerable<object[]> GetCreateData()
        {
            Aes aes = Aes.Create();
            yield return new object[] { new JsonWebKey(aes) { Id = nameof(aes) }, typeof(AesCryptographyProvider) };

#if !NET462
            ECDsa ecdsa = ECDsa.Create();
            yield return new object[] { new JsonWebKey(ecdsa, false) { Id = "ecdsaPublic" }, typeof(EcCryptographyProvider) };
            yield return new object[] { new JsonWebKey(ecdsa, true) { Id = "ecdsaPrivate" }, typeof(EcCryptographyProvider) };
#endif

            RSA rsa = RSA.Create();
            yield return new object[] { new JsonWebKey(rsa, false) { Id = "rsaPublic" }, typeof(RsaCryptographyProvider) };
            yield return new object[] { new JsonWebKey(rsa, true) { Id = "rsaPrivate" }, typeof(RsaCryptographyProvider) };
        }
    }
}
