// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace AzureSamples.Security.KeyVault.Proxy
{
    public partial class KeyVaultProxyTests
    {
        [Fact]
        public void DefaultTtl()
        {
            KeyVaultProxy proxy = new KeyVaultProxy();
            Assert.Equal(TimeSpan.FromHours(1), proxy.Ttl);
        }

        [Theory]
        [InlineData("https://test.vault.azure.net/secrets/", true)]
        [InlineData("https://test.vault.azure.net/secrets/?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/secrets/test-secret", true)]
        [InlineData("https://test.vault.azure.net/secrets/test-secret?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/secrets/test-secret/version", true)]
        [InlineData("https://test.vault.azure.net/secrets/test-secret/version?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/keys/", true)]
        [InlineData("https://test.vault.azure.net/keys/?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/keys/test-key", true)]
        [InlineData("https://test.vault.azure.net/keys/test-key?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/keys/test-key/version", true)]
        [InlineData("https://test.vault.azure.net/keys/test-key/version?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/certificates/", true)]
        [InlineData("https://test.vault.azure.net/certificates/?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/certificates/test-certificate", true)]
        [InlineData("https://test.vault.azure.net/certificates/test-certificate?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/certificates/test-certificate/version", true)]
        [InlineData("https://test.vault.azure.net/certificates/test-certificate/version?api-version=7.0", true)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/", false)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/test-secret", false)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/test-secret?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/test-secret/version", false)]
        [InlineData("https://test.vault.azure.net/deletedsecrets/test-secret/version?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys/", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys?/api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys/test-key", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys/test-key?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys/test-key/version", false)]
        [InlineData("https://test.vault.azure.net/deletedkeys/test-key/version?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/test-certificate", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/test-certificate?api-version=7.0", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/test-certificate/version", false)]
        [InlineData("https://test.vault.azure.net/deletedcertificates/test-certificate/version?api-version=7.0", false)]
        public void IsSupported(string uri, bool expected) => Assert.Equal(expected, KeyVaultProxy.IsSupported(uri));
    }
}
