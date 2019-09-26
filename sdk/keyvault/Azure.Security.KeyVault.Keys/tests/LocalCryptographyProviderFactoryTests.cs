// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class LocalCryptographyProviderFactoryTests
    {
        [TestCaseSource(nameof(GetCreateData))]
        public void Create(JsonWebKey jwk, Type clientType)
        {
            ICryptographyProvider client = LocalCryptographyProviderFactory.Create(jwk);
            Assert.IsInstanceOf(clientType, client, "Key {0} of type {1} did not yield client type {2}", jwk.Id, jwk.KeyType, clientType.Name);
        }

        [Test]
        public void CreateThrows()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                Id = new Uri("http://localhost"),
                KeyType = new KeyType("invalid"),
            };

            Assert.Throws<NotSupportedException>(() => LocalCryptographyProviderFactory.Create(jwk));
        }

        private static IEnumerable<object[]> GetCreateData()
        {
#if !NET461
            ECDsa ecdsa = ECDsa.Create();
            yield return new object[] { new JsonWebKey(ecdsa, false) { Id = new Uri("http://localhost/ecdsaPublic") }, typeof(EcCryptographyProvider) };
            yield return new object[] { new JsonWebKey(ecdsa, true) { Id = new Uri("http://localhost/ecdsaPrivate") }, typeof(EcCryptographyProvider) };
#endif

            RSA rsa = RSA.Create();
            yield return new object[] { new JsonWebKey(rsa, false) { Id = new Uri("http://localhost/rsaPublic") }, typeof(RsaCryptographyProvider) };
            yield return new object[] { new JsonWebKey(rsa, true) { Id = new Uri("http://localhost/rsaPrivate") }, typeof(RsaCryptographyProvider) };
        }
    }
}
