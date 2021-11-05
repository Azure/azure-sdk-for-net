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
    }
}
