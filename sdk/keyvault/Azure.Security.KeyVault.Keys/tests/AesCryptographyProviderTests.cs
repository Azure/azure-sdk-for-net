// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class AesCryptographyProviderTests
    {
        [Test]
        public void WrapKeyBeforeValidDate()
        {
            using Aes aes = Aes.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(aes),
                Properties =
                {
                    NotBefore = DateTimeOffset.Now.AddDays(1),
                },
            };

            AesCryptographyProvider provider = new AesCryptographyProvider(key);

            byte[] ek = { 0x64, 0xE8, 0xC3, 0xF9, 0xCE, 0x0F, 0x5B, 0xA2, 0x63, 0xE9, 0x77, 0x79, 0x05, 0x81, 0x8A, 0x2A, 0x93, 0xC8, 0x19, 0x1E, 0x7D, 0x6E, 0x8A, 0xE7 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.WrapKey(KeyWrapAlgorithm.A128KW, ek, default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void WrapKeyAfterValidDate()
        {
            using Aes aes = Aes.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(aes),
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddDays(-1),
                },
            };

            AesCryptographyProvider provider = new AesCryptographyProvider(key);

            byte[] ek = { 0x64, 0xE8, 0xC3, 0xF9, 0xCE, 0x0F, 0x5B, 0xA2, 0x63, 0xE9, 0x77, 0x79, 0x05, 0x81, 0x8A, 0x2A, 0x93, 0xC8, 0x19, 0x1E, 0x7D, 0x6E, 0x8A, 0xE7 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.WrapKey(KeyWrapAlgorithm.A128KW, ek, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }
    }
}
