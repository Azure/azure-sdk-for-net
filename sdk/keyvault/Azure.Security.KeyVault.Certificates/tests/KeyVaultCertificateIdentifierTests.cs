// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class KeyVaultCertificateIdentifierTests
    {
        [Test]
        public void KeyVaultCertificateIdentifierNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new KeyVaultCertificateIdentifier(null));
            Assert.AreEqual("id", ex.ParamName);
        }

        [TestCaseSource(nameof(Data))]
        public bool Parse(Uri id, Uri vaultUri, string name, string version)
        {
            try
            {
                KeyVaultCertificateIdentifier identifier = new KeyVaultCertificateIdentifier(id);

                Assert.AreEqual(id, identifier.SourceId);
                Assert.AreEqual(vaultUri, identifier.VaultUri);
                Assert.AreEqual(name, identifier.Name);
                Assert.AreEqual(version, identifier.Version);

                return true;
            }
            catch (ArgumentException ex) when (ex.ParamName == "id")
            {
                return false;
            }
        }

        [Test]
        public void Equals()
        {
            KeyVaultCertificateIdentifier a = new KeyVaultCertificateIdentifier(new Uri("https://test.vault.azure.net/deletedcertificates/test-name/test-version"));
            KeyVaultCertificateIdentifier b = new KeyVaultCertificateIdentifier(new Uri("https://test.vault.azure.net/deletedcertificates/test-name/test-version"));

            Assert.AreEqual(a, b);
        }

        [Test]
        public void NotEquals()
        {
            KeyVaultCertificateIdentifier a = new KeyVaultCertificateIdentifier(new Uri("https://test.vault.azure.net/deletedcertificates/test-name/test-version?api-version=7.0"));
            KeyVaultCertificateIdentifier b = new KeyVaultCertificateIdentifier(new Uri("https://test.vault.azure.net/deletedcertificates/test-name/test-version?api-version=7.1"));

            Assert.AreNotEqual(a, b);
        }

        [Test]
        public void TestGetHashCode()
        {
            Uri uri = new Uri("https://test.vault.azure.net/keys/test-name/test-version");
            KeyVaultCertificateIdentifier keyId = new KeyVaultCertificateIdentifier(uri);

            Assert.AreEqual(uri.GetHashCode(), keyId.GetHashCode());
        }

        [Test]
        public void TryCreateFromNull()
        {
            Assert.IsFalse(KeyVaultCertificateIdentifier.TryCreate(null, out KeyVaultCertificateIdentifier identifier));
            Assert.That(() => default(KeyVaultCertificateIdentifier).Equals(identifier));
        }

        [TestCaseSource(nameof(Data))]
        public bool TryCreate(Uri id, Uri vaultUri, string name, string version)
        {
            bool result = KeyVaultCertificateIdentifier.TryCreate(id, out KeyVaultCertificateIdentifier identifier);

            if (result)
            {
                Assert.AreEqual(id, identifier.SourceId);
                Assert.AreEqual(vaultUri, identifier.VaultUri);
                Assert.AreEqual(name, identifier.Name);
                Assert.AreEqual(version, identifier.Version);
            }

            return result;
        }

        private static IEnumerable<IdentifierTestData> Data => new[]
        {
            new IdentifierTestData("https://test.vault.azure.net").Returns(false),
            new IdentifierTestData("https://test.vault.azure.net/certificates").Returns(false),
            new IdentifierTestData("https://test.vault.azure.net/certificates/test-name", "https://test.vault.azure.net", "test-name").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/certificates/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/deletedcertificates/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net:8443/certificates/test-name/test-version", "https://test.vault.azure.net:8443", "test-name", "test-version").Returns(true),

            // No client validation of other valid identifier paths.
            new IdentifierTestData("https://test.vault.azure.net/keys/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/secrets/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
        };

        private class IdentifierTestData : TestCaseData
        {
            public IdentifierTestData(string id, string vaultUri = null, string name = null, string version = null) :
                base(id is { } ? new Uri(id) : null, vaultUri is { } ? new Uri(vaultUri) : null, name, version)
            {
            }

            public IdentifierTestData Returns(bool value)
            {
                base.Returns(value);
                return this;
            }
        }
    }
}
