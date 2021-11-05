// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class RsaCryptographyProviderTests
    {
        [Test]
        public void EncryptBeforeValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    NotBefore = DateTimeOffset.Now.AddDays(1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] plaintext = Encoding.UTF8.GetBytes("test");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Encrypt(EncryptParameters.RsaOaep256Parameters(plaintext), default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void EncryptAfterValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddDays(-1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] plaintext = Encoding.UTF8.GetBytes("test");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Encrypt(EncryptParameters.RsaOaep256Parameters(plaintext), default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }

        [Test]
        public void SignBeforeValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    NotBefore = DateTimeOffset.Now.AddDays(1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Sign(SignatureAlgorithm.PS256, digest, default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void SignAfterValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddDays(-1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Sign(SignatureAlgorithm.PS256, digest, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }

        [Test]
        public void WrapKeyBeforeValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    NotBefore = DateTimeOffset.Now.AddDays(1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] ek = { 0x64, 0xE8, 0xC3, 0xF9, 0xCE, 0x0F, 0x5B, 0xA2, 0x63, 0xE9, 0x77, 0x79, 0x05, 0x81, 0x8A, 0x2A, 0x93, 0xC8, 0x19, 0x1E, 0x7D, 0x6E, 0x8A, 0xE7 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.WrapKey(KeyWrapAlgorithm.RsaOaep256, ek, default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void WrapKeyAfterValidDate()
        {
            using RSA rsa = RSA.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(rsa),
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddDays(-1),
                },
            };

            RsaCryptographyProvider provider = new RsaCryptographyProvider(key.Key, key.Properties, false);

            byte[] ek = { 0x64, 0xE8, 0xC3, 0xF9, 0xCE, 0x0F, 0x5B, 0xA2, 0x63, 0xE9, 0x77, 0x79, 0x05, 0x81, 0x8A, 0x2A, 0x93, 0xC8, 0x19, 0x1E, 0x7D, 0x6E, 0x8A, 0xE7 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.WrapKey(KeyWrapAlgorithm.RsaOaep256, ek, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }
    }
}
