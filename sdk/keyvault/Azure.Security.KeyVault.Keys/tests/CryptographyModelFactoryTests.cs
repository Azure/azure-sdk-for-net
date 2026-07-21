// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyModelFactoryTests
    {
        [Test]
        public void DecryptOptionsRequiresCiphertext() =>
            Assert.AreEqual("ciphertext", Assert.Throws<ArgumentNullException>(() => CryptographyModelFactory.DecryptParameters(EncryptionAlgorithm.A128Cbc, null)).ParamName);

        [Test]
        public void DecryptOptionsOnlyRequired()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            DecryptParameters options = CryptographyModelFactory.DecryptParameters(EncryptionAlgorithm.A128Cbc, buffer, null, null);

            Assert.AreEqual(EncryptionAlgorithm.A128Cbc, options.Algorithm);
            CollectionAssert.AreEqual(buffer, options.Ciphertext);
            Assert.IsNull(options.Iv);
            Assert.IsNull(options.AuthenticationTag);
            Assert.IsNull(options.AdditionalAuthenticatedData);
        }

        [Test]
        public void DecryptOptionsAll()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            DecryptParameters options = CryptographyModelFactory.DecryptParameters(EncryptionAlgorithm.A128Cbc, buffer, buffer, buffer, buffer);

            Assert.AreEqual(EncryptionAlgorithm.A128Cbc, options.Algorithm);
            CollectionAssert.AreEqual(buffer, options.Ciphertext);
            CollectionAssert.AreEqual(buffer, options.Iv);
            CollectionAssert.AreEqual(buffer, options.AuthenticationTag);
            CollectionAssert.AreEqual(buffer, options.AdditionalAuthenticatedData);
        }

        [Test]
        public void EncryptOptionsRequiresPlaintext() =>
            Assert.AreEqual("plaintext", Assert.Throws<ArgumentNullException>(() => CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, null)).ParamName);

        [Test]
        public void EncryptOptionsOnlyRequired()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            EncryptParameters options = CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, buffer);

            Assert.AreEqual(EncryptionAlgorithm.A128Cbc, options.Algorithm);
            CollectionAssert.AreEqual(buffer, options.Plaintext);
            Assert.IsNull(options.Iv);
            Assert.IsNull(options.AdditionalAuthenticatedData);
        }

        [Test]
        public void EncryptOptionsAll()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            EncryptParameters options = CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, buffer, buffer, buffer);

            Assert.AreEqual(EncryptionAlgorithm.A128Cbc, options.Algorithm);
            CollectionAssert.AreEqual(buffer, options.Plaintext);
            CollectionAssert.AreEqual(buffer, options.Iv);
            CollectionAssert.AreEqual(buffer, options.AdditionalAuthenticatedData);
        }

        [Test]
        public void SecureWrapResultProperties()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            SecureWrapResult result = CryptographyModelFactory.SecureWrapResult(
                keyId: "https://test.vault.azure.net/keys/test/version",
                encryptedKey: buffer,
                algorithm: SecureKeyWrapAlgorithm.A256KW);

            Assert.AreEqual("https://test.vault.azure.net/keys/test/version", result.KeyId);
            CollectionAssert.AreEqual(buffer, result.EncryptedKey);
            Assert.AreEqual(SecureKeyWrapAlgorithm.A256KW, result.Algorithm);
        }

        [Test]
        public void SecureWrapResultDefaults()
        {
            SecureWrapResult result = CryptographyModelFactory.SecureWrapResult();

            Assert.IsNull(result.KeyId);
            Assert.IsNull(result.EncryptedKey);
            Assert.AreEqual(default(SecureKeyWrapAlgorithm), result.Algorithm);
        }

        [Test]
        public void SecureUnwrapResultProperties()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            SecureUnwrapResult result = CryptographyModelFactory.SecureUnwrapResult(
                keyId: "https://test.vault.azure.net/keys/test/version",
                key: buffer,
                algorithm: SecureKeyWrapAlgorithm.A256KW);

            Assert.AreEqual("https://test.vault.azure.net/keys/test/version", result.KeyId);
            CollectionAssert.AreEqual(buffer, result.Key);
            Assert.AreEqual(SecureKeyWrapAlgorithm.A256KW, result.Algorithm);
        }

        [Test]
        public void SecureUnwrapResultDefaults()
        {
            SecureUnwrapResult result = CryptographyModelFactory.SecureUnwrapResult();

            Assert.IsNull(result.KeyId);
            Assert.IsNull(result.Key);
            Assert.AreEqual(default(SecureKeyWrapAlgorithm), result.Algorithm);
        }
    }
}
