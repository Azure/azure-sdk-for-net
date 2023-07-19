// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyVaultKeyIdentifierTests
    {
        [Test]
        public void KeyVaultKeyIdentifierNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new KeyVaultKeyIdentifier(null));
            Assert.AreEqual("id", ex.ParamName);
        }

        [TestCaseSource(nameof(Data))]
        public bool Parse(Uri id, Uri vaultUri, string name, string version)
        {
            try
            {
                KeyVaultKeyIdentifier identifier = new KeyVaultKeyIdentifier(id);

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
            KeyVaultKeyIdentifier a = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version"));
            KeyVaultKeyIdentifier b = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version"));

            Assert.AreEqual(a, b);
        }

        [Test]
        public void NotEquals()
        {
            KeyVaultKeyIdentifier a = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version?api-version=7.0"));
            KeyVaultKeyIdentifier b = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version?api-version=7.1"));

            Assert.AreNotEqual(a, b);
        }

        [Test]
        public void TestGetHashCode()
        {
            Uri uri = new Uri("https://test.vault.azure.net/keys/test-name/test-version");
            KeyVaultKeyIdentifier keyId = new KeyVaultKeyIdentifier(uri);

            Assert.AreEqual(uri.GetHashCode(), keyId.GetHashCode());
        }

        [Test]
        public void TryCreateFromNull()
        {
            Assert.IsFalse(KeyVaultKeyIdentifier.TryCreate(null, out KeyVaultKeyIdentifier identifier));
            Assert.That(() => default(KeyVaultKeyIdentifier).Equals(identifier));
        }

        [TestCaseSource(nameof(Data))]
        public bool TryCreate(Uri id, Uri vaultUri, string name, string version)
        {
            bool result = KeyVaultKeyIdentifier.TryCreate(id, out KeyVaultKeyIdentifier identifier);

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
            new IdentifierTestData("https://test.vault.azure.net/keys").Returns(false),
            new IdentifierTestData("https://test.vault.azure.net/keys/test-name", "https://test.vault.azure.net", "test-name").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/keys/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/deletedkeys/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net:8443/keys/test-name/test-version", "https://test.vault.azure.net:8443", "test-name", "test-version").Returns(true),

            // No client validation of other valid identifier paths.
            new IdentifierTestData("https://test.vault.azure.net/certificates/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
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
