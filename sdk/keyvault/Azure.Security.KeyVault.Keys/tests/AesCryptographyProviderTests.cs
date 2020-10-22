// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Azure.Core.TestFramework;
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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties);

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties);

            byte[] ek = { 0x64, 0xE8, 0xC3, 0xF9, 0xCE, 0x0F, 0x5B, 0xA2, 0x63, 0xE9, 0x77, 0x79, 0x05, 0x81, 0x8A, 0x2A, 0x93, 0xC8, 0x19, 0x1E, 0x7D, 0x6E, 0x8A, 0xE7 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.WrapKey(KeyWrapAlgorithm.A128KW, ek, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }

        [Test]
        public void EncryptBeforeValidDate()
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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties);

            byte[] iv = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            EncryptOptions options = EncryptOptions.A128CbcOptions(Encoding.UTF8.GetBytes("Single block msg"), iv);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Encrypt(options, default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void EncryptAfterValidDate()
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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties);

            byte[] iv = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            EncryptOptions options = EncryptOptions.A128CbcOptions(Encoding.UTF8.GetBytes("Single block msg"), iv);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => provider.Encrypt(options, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }

        [Test]
        public void EncryptionAlgorithmNotSupported()
        {
            using TestEventListener listener = new TestEventListener();
            listener.EnableEvents(KeysEventSource.Singleton, EventLevel.Verbose);

            using Aes aes = Aes.Create();
            JsonWebKey key = new JsonWebKey(aes);

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null);
            Assert.IsNull(provider.Encrypt(new EncryptOptions(new EncryptionAlgorithm("invalid"), new byte[] { 0 })));

            EventWrittenEventArgs e = listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual("Encrypt", e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [Test]
        public void DecryptionAlgorithmNotSupported()
        {
            using TestEventListener listener = new TestEventListener();
            listener.EnableEvents(KeysEventSource.Singleton, EventLevel.Verbose);

            using Aes aes = Aes.Create();
            JsonWebKey key = new JsonWebKey(aes);

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null);
            Assert.IsNull(provider.Decrypt(new DecryptOptions(new EncryptionAlgorithm("invalid"), new byte[] { 0 })));

            EventWrittenEventArgs e = listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual("Decrypt", e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [TestCaseSource(nameof(EncryptDecryptRoundtripsData))]
        public void EncryptDecryptRoundtrips(EncryptionAlgorithm algorithm)
        {
            // Use a 256-bit key which will be truncated based on the selected algorithm.
            byte[] k = new byte[] { 0xe2, 0x7e, 0xd0, 0xc8, 0x45, 0x12, 0xbb, 0xd5, 0x5b, 0x6a, 0xf4, 0x34, 0xd2, 0x37, 0xc1, 0x1f, 0xeb, 0xa3, 0x11, 0x87, 0x0f, 0x80, 0xf2, 0xc2, 0xe3, 0x36, 0x42, 0x60, 0xf3, 0x1c, 0x82, 0xc8 };
            byte[] iv = new byte[] { 0x89, 0xb8, 0xad, 0xbf, 0xb0, 0x73, 0x45, 0xe3, 0x59, 0x89, 0x32, 0xa0, 0x9c, 0x51, 0x74, 0x41 };
            byte[] aad = Encoding.UTF8.GetBytes("test");

            JsonWebKey key = new JsonWebKey(new[] { KeyOperation.Encrypt, KeyOperation.Decrypt })
            {
                K = k,
            };

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null);

            byte[] plaintext = Encoding.UTF8.GetBytes("plaintext");

            if (algorithm.IsAesGcm())
            {
                iv = iv.Take(AesGcmProxy.NonceByteSize);
            }

            EncryptOptions encryptOptions = new EncryptOptions(algorithm, plaintext, iv, aad);
            EncryptResult encrypted = provider.Encrypt(encryptOptions, default);

#if !NETCOREAPP3_1
            if (algorithm.IsAesGcm())
            {
                Assert.IsNull(encrypted);
                Assert.Ignore($"AES-GCM is not supported on {RuntimeInformation.FrameworkDescription} on {RuntimeInformation.OSDescription}");
            }
#endif
            Assert.IsNotNull(encrypted);

            DecryptOptions decryptOptions = algorithm.IsAesGcm() ?
                new DecryptOptions(algorithm, encrypted.Ciphertext, encrypted.Iv, encrypted.AuthenticationTag, encrypted.AdditionalAuthenticatedData) :
                new DecryptOptions(algorithm, encrypted.Ciphertext, encrypted.Iv);

            DecryptResult decrypted = provider.Decrypt(decryptOptions, default);
            Assert.IsNotNull(decrypted);

            // AES-CBC will be zero-padded.
            StringAssert.StartsWith("plaintext", Encoding.UTF8.GetString(decrypted.Plaintext));
        }

        private static IEnumerable EncryptDecryptRoundtripsData => new[]
        {
            EncryptionAlgorithm.A128Cbc,
            EncryptionAlgorithm.A192Cbc,
            EncryptionAlgorithm.A256Cbc,

            EncryptionAlgorithm.A128CbcPad,
            EncryptionAlgorithm.A192CbcPad,
            EncryptionAlgorithm.A256CbcPad,

            EncryptionAlgorithm.A128Gcm,
            EncryptionAlgorithm.A192Gcm,
            EncryptionAlgorithm.A256Gcm,
        };
    }
}
