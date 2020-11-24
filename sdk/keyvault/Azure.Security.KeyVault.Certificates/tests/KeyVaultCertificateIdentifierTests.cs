// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class KeyVaultCertificateIdentifierTests
    {
        [TestCaseSource(nameof(Data))]
        public bool Parse(Uri id, Uri vaultUri, string name, string version)
        {
            try
            {
                KeyVaultCertificateIdentifier identifier = KeyVaultCertificateIdentifier.Parse(id);

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

        [TestCaseSource(nameof(Data))]
        public bool TryParse(Uri id, Uri vaultUri, string name, string version)
        {
            if (KeyVaultCertificateIdentifier.TryParse(id, out KeyVaultCertificateIdentifier identifier))
            {
                Assert.AreEqual(id, identifier.SourceId);
                Assert.AreEqual(vaultUri, identifier.VaultUri);
                Assert.AreEqual(name, identifier.Name);
                Assert.AreEqual(version, identifier.Version);

                return true;
            }

            return false;
        }

        private static IEnumerable<IdentifierTestData> Data => new[]
        {
            new IdentifierTestData(null).Returns(false),
            new IdentifierTestData("https://test.vault.azure.net").Returns(false),
            new IdentifierTestData("https://test.vault.azure.net/certificates").Returns(false),
            new IdentifierTestData("https://test.vault.azure.net/certificates/test-name", "https://test.vault.azure.net", "test-name").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/certificates/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),
            new IdentifierTestData("https://test.vault.azure.net/deletedcertificates/test-name/test-version", "https://test.vault.azure.net", "test-name", "test-version").Returns(true),

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
