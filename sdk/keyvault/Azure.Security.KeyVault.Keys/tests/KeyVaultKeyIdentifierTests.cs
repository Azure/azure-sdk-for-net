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
            Assert.That(ex.ParamName, Is.EqualTo("id"));
        }

        [TestCaseSource(nameof(Data))]
        public bool Parse(Uri id, Uri vaultUri, string name, string version)
        {
            try
            {
                KeyVaultKeyIdentifier identifier = new KeyVaultKeyIdentifier(id);

                Assert.That(identifier.SourceId, Is.EqualTo(id));
                Assert.That(identifier.VaultUri, Is.EqualTo(vaultUri));
                Assert.That(identifier.Name, Is.EqualTo(name));
                Assert.That(identifier.Version, Is.EqualTo(version));

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

            Assert.That(b, Is.EqualTo(a));
        }

        [Test]
        public void NotEquals()
        {
            KeyVaultKeyIdentifier a = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version?api-version=7.0"));
            KeyVaultKeyIdentifier b = new KeyVaultKeyIdentifier(new Uri("https://test.vault.azure.net/keys/test-name/test-version?api-version=7.1"));

            Assert.That(b, Is.Not.EqualTo(a));
        }

        [Test]
        public void TestGetHashCode()
        {
            Uri uri = new Uri("https://test.vault.azure.net/keys/test-name/test-version");
            KeyVaultKeyIdentifier keyId = new KeyVaultKeyIdentifier(uri);

            Assert.That(keyId.GetHashCode(), Is.EqualTo(uri.GetHashCode()));
        }

        [Test]
        public void TryCreateFromNull()
        {
            Assert.That(KeyVaultKeyIdentifier.TryCreate(null, out KeyVaultKeyIdentifier identifier), Is.False);
            Assert.That(() => default(KeyVaultKeyIdentifier).Equals(identifier));
        }

        [TestCaseSource(nameof(Data))]
        public bool TryCreate(Uri id, Uri vaultUri, string name, string version)
        {
            bool result = KeyVaultKeyIdentifier.TryCreate(id, out KeyVaultKeyIdentifier identifier);

            if (result)
            {
                Assert.That(identifier.SourceId, Is.EqualTo(id));
                Assert.That(identifier.VaultUri, Is.EqualTo(vaultUri));
                Assert.That(identifier.Name, Is.EqualTo(name));
                Assert.That(identifier.Version, Is.EqualTo(version));
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
