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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties, false);

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties, false);

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties, false);

            byte[] iv = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            EncryptParameters options = EncryptParameters.A128CbcParameters(Encoding.UTF8.GetBytes("Single block msg"), iv);

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key.Key, key.Properties, false);

            byte[] iv = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            EncryptParameters options = EncryptParameters.A128CbcParameters(Encoding.UTF8.GetBytes("Single block msg"), iv);

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);
            Assert.IsNull(provider.Encrypt(new EncryptParameters(new EncryptionAlgorithm("invalid"), new byte[] { 0 })));

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

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);
            Assert.IsNull(provider.Decrypt(new DecryptParameters(new EncryptionAlgorithm("invalid"), new byte[] { 0 })));

            EventWrittenEventArgs e = listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual("Decrypt", e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [TestCaseSource(nameof(GetEncryptionAlgorithms))]
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

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);

            byte[] plaintext = Encoding.UTF8.GetBytes("plaintext");

            EncryptParameters encryptOptions = new EncryptParameters(algorithm, plaintext, iv, aad);
            EncryptResult encrypted = provider.Encrypt(encryptOptions, default);

            Assert.IsNotNull(encrypted);

            switch (algorithm.ToString())
            {
                // TODO: Move to new test to make sure CryptoClient and LocalCryptoClient initialize a null ICM for AES-CBC(PAD).
                case EncryptionAlgorithm.A128CbcValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0x63, 0x23, 0x21, 0xaf, 0x94, 0xf9, 0xe1, 0x21, 0xc2, 0xbd, 0xb1, 0x1b, 0x04, 0x89, 0x8c, 0x3a },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;

                case EncryptionAlgorithm.A192CbcValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0x95, 0x9d, 0x75, 0x91, 0x09, 0x8b, 0x70, 0x0b, 0x9c, 0xfe, 0xaf, 0xcd, 0x60, 0x1f, 0xaa, 0x79 },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;

                case EncryptionAlgorithm.A256CbcValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0xf4, 0xe8, 0x5a, 0xa4, 0xa8, 0xb3, 0xff, 0xc3, 0x85, 0x89, 0x17, 0x9a, 0x70, 0x09, 0x96, 0x7f },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;

                case EncryptionAlgorithm.A128CbcPadValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0xec, 0xb2, 0x63, 0x4c, 0xe0, 0x04, 0xe0, 0x31, 0x2d, 0x9a, 0x77, 0xb2, 0x11, 0xe5, 0x28, 0x7f },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;

                case EncryptionAlgorithm.A192CbcPadValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0xc3, 0x4e, 0x1b, 0xe7, 0x6e, 0xa1, 0xf1, 0xc3, 0x24, 0xae, 0x05, 0x1b, 0x0e, 0x32, 0xac, 0xb4 },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;

                case EncryptionAlgorithm.A256CbcPadValue:
                    CollectionAssert.AreEqual(
                        new byte[] { 0x4e, 0xbd, 0x78, 0xda, 0x90, 0x73, 0xc8, 0x97, 0x67, 0x2b, 0xa1, 0x0a, 0x41, 0x67, 0xf8, 0x99 },
                        encrypted.Ciphertext);
                    CollectionAssert.AreEqual(iv, encrypted.Iv);
                    Assert.IsNull(encrypted.AuthenticationTag);
                    Assert.IsNull(encrypted.AdditionalAuthenticatedData);
                    break;
            }

            DecryptParameters decryptOptions = new DecryptParameters(algorithm, encrypted.Ciphertext, encrypted.Iv);

            DecryptResult decrypted = provider.Decrypt(decryptOptions, default);
            Assert.IsNotNull(decrypted);

            // AES-CBC will be zero-padded.
            StringAssert.StartsWith("plaintext", Encoding.UTF8.GetString(decrypted.Plaintext));
        }

        [TestCaseSource(nameof(GetEncryptionAlgorithms))]
        public void InitializesIv(EncryptionAlgorithm algorithm)
        {
            // Use a 256-bit key which will be truncated based on the selected algorithm.
            byte[] k = new byte[] { 0xe2, 0x7e, 0xd0, 0xc8, 0x45, 0x12, 0xbb, 0xd5, 0x5b, 0x6a, 0xf4, 0x34, 0xd2, 0x37, 0xc1, 0x1f, 0xeb, 0xa3, 0x11, 0x87, 0x0f, 0x80, 0xf2, 0xc2, 0xe3, 0x36, 0x42, 0x60, 0xf3, 0x1c, 0x82, 0xc8 };

            JsonWebKey key = new JsonWebKey(new[] { KeyOperation.Encrypt, KeyOperation.Decrypt })
            {
                K = k,
            };

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);

            byte[] plaintext = Encoding.UTF8.GetBytes("plaintext");

            EncryptParameters encryptOptions = new EncryptParameters(algorithm, plaintext, null, null);
            EncryptResult encrypted = provider.Encrypt(encryptOptions, default);

            Assert.IsNotNull(encryptOptions.Iv);
            CollectionAssert.AreEqual(encryptOptions.Iv, encrypted.Iv);

            DecryptParameters decryptOptions = new DecryptParameters(algorithm, encrypted.Ciphertext, encrypted.Iv);
            DecryptResult decrypted = provider.Decrypt(decryptOptions, default);

            Assert.IsNotNull(decrypted);

            // AES-CBC will be zero-padded.
            StringAssert.StartsWith("plaintext", Encoding.UTF8.GetString(decrypted.Plaintext));
        }

        [Test]
        public void AesGcmEncryptNotSupported([EnumValues(nameof(EncryptionAlgorithm.A128Gcm), nameof(EncryptionAlgorithm.A192Gcm), nameof(EncryptionAlgorithm.A256Gcm))] EncryptionAlgorithm algorithm)
        {
            // Use a 256-bit key which will be truncated based on the selected algorithm.
            byte[] k = new byte[] { 0xe2, 0x7e, 0xd0, 0xc8, 0x45, 0x12, 0xbb, 0xd5, 0x5b, 0x6a, 0xf4, 0x34, 0xd2, 0x37, 0xc1, 0x1f, 0xeb, 0xa3, 0x11, 0x87, 0x0f, 0x80, 0xf2, 0xc2, 0xe3, 0x36, 0x42, 0x60, 0xf3, 0x1c, 0x82, 0xc8 };

            JsonWebKey key = new JsonWebKey(new[] { KeyOperation.Encrypt, KeyOperation.Decrypt })
            {
                K = k,
            };

            byte[] plaintext = Encoding.UTF8.GetBytes("plaintext");

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);
            Assert.IsNull(provider.Encrypt(new EncryptParameters(algorithm, plaintext)));
        }

        [Test]
        public void AesGcmDecryptNotSupported([EnumValues(nameof(EncryptionAlgorithm.A128Gcm), nameof(EncryptionAlgorithm.A192Gcm), nameof(EncryptionAlgorithm.A256Gcm))] EncryptionAlgorithm algorithm)
        {
            // Use a 256-bit key which will be truncated based on the selected algorithm.
            byte[] k = new byte[] { 0xe2, 0x7e, 0xd0, 0xc8, 0x45, 0x12, 0xbb, 0xd5, 0x5b, 0x6a, 0xf4, 0x34, 0xd2, 0x37, 0xc1, 0x1f, 0xeb, 0xa3, 0x11, 0x87, 0x0f, 0x80, 0xf2, 0xc2, 0xe3, 0x36, 0x42, 0x60, 0xf3, 0x1c, 0x82, 0xc8 };
            byte[] iv = new byte[] { 0x89, 0xb8, 0xad, 0xbf, 0xb0, 0x73, 0x45, 0xe3, 0x59, 0x89, 0x32, 0xa0 };

            JsonWebKey key = new JsonWebKey(new[] { KeyOperation.Encrypt, KeyOperation.Decrypt })
            {
                K = k,
            };

            byte[] ciphertext = new byte[] {0xed, 0x76, 0xc3, 0x94, 0xe7, 0xa3, 0xcb, 0xcc, 0x5f };
            byte[] tag = new byte[] { 0xeb, 0x2f, 0x3a, 0xd3, 0x87, 0xb0, 0x72, 0x68, 0xba, 0xcc, 0x04, 0x91 };

            AesCryptographyProvider provider = new AesCryptographyProvider(key, null, false);
            Assert.IsNull(provider.Decrypt(new DecryptParameters(algorithm, ciphertext, iv, tag, null)));
        }

        private static IEnumerable GetEncryptionAlgorithms()
        {
            yield return EncryptionAlgorithm.A128Cbc;
            yield return EncryptionAlgorithm.A192Cbc;
            yield return EncryptionAlgorithm.A256Cbc;

            yield return EncryptionAlgorithm.A128CbcPad;
            yield return EncryptionAlgorithm.A192CbcPad;
            yield return EncryptionAlgorithm.A256CbcPad;
        }
    }
}
