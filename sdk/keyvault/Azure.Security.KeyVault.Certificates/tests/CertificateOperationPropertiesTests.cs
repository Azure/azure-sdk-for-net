// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateOperationPropertiesTests
    {
        [TestCase("https://adpnet.vault.azure.net", "https://adpnet.vault.azure.net/certificates/test")]
        [TestCase("https://adpnet.vault.azure.net/", "https://adpnet.vault.azure.net/certificates/test")]
        [TestCase("https://adpnet.vault.azure.net:443", "https://adpnet.vault.azure.net/certificates/test")]
        [TestCase("https://adpnet.vault.azure.net:443/", "https://adpnet.vault.azure.net/certificates/test")]
        [TestCase("https://adpnet.vault.azure.net:1234", "https://adpnet.vault.azure.net:1234/certificates/test")]
        [TestCase("https://adpnet.vault.azure.net:1234/", "https://adpnet.vault.azure.net:1234/certificates/test")]
        public void New(string vaultUri, string expected)
        {
            CertificateOperationProperties properties = new CertificateOperationProperties(new Uri(vaultUri), "test");

            Assert.That(properties.Name, Is.EqualTo("test"));
            Assert.That(properties.Id.ToString(), Is.EqualTo(expected));
        }
    }
}
