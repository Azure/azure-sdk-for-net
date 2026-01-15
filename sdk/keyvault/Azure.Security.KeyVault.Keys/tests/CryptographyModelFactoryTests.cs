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
            Assert.That(Assert.Throws<ArgumentNullException>(() => CryptographyModelFactory.DecryptParameters(EncryptionAlgorithm.A128Cbc, null)).ParamName, Is.EqualTo("ciphertext"));

        [Test]
        public void DecryptOptionsOnlyRequired()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            DecryptParameters options = CryptographyModelFactory.DecryptParameters(EncryptionAlgorithm.A128Cbc, buffer, null, null);

            Assert.That(options.Algorithm, Is.EqualTo(EncryptionAlgorithm.A128Cbc));
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

            Assert.That(options.Algorithm, Is.EqualTo(EncryptionAlgorithm.A128Cbc));
            CollectionAssert.AreEqual(buffer, options.Ciphertext);
            CollectionAssert.AreEqual(buffer, options.Iv);
            CollectionAssert.AreEqual(buffer, options.AuthenticationTag);
            CollectionAssert.AreEqual(buffer, options.AdditionalAuthenticatedData);
        }

        [Test]
        public void EncryptOptionsRequiresPlaintext() =>
            Assert.That(Assert.Throws<ArgumentNullException>(() => CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, null)).ParamName, Is.EqualTo("plaintext"));

        [Test]
        public void EncryptOptionsOnlyRequired()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            EncryptParameters options = CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, buffer);

            Assert.That(options.Algorithm, Is.EqualTo(EncryptionAlgorithm.A128Cbc));
            CollectionAssert.AreEqual(buffer, options.Plaintext);
            Assert.IsNull(options.Iv);
            Assert.IsNull(options.AdditionalAuthenticatedData);
        }

        [Test]
        public void EncryptOptionsAll()
        {
            byte[] buffer = new byte[] { 0, 1, 2, 3 };
            EncryptParameters options = CryptographyModelFactory.EncryptParameters(EncryptionAlgorithm.A128Cbc, buffer, buffer, buffer);

            Assert.That(options.Algorithm, Is.EqualTo(EncryptionAlgorithm.A128Cbc));
            CollectionAssert.AreEqual(buffer, options.Plaintext);
            CollectionAssert.AreEqual(buffer, options.Iv);
            CollectionAssert.AreEqual(buffer, options.AdditionalAuthenticatedData);
        }
    }
}
