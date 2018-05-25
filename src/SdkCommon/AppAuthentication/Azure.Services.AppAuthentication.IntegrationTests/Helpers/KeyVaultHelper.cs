// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Helpers
{
    /// <summary>
    /// Used to get a certificate from Key Vault. The certificate is used for integration testing. 
    /// </summary>
    internal class KeyVaultHelper
    {
        private readonly KeyVaultClient _keyVaultClient;

        public KeyVaultHelper(KeyVaultClient keyVaultClient)
        {
            _keyVaultClient = keyVaultClient;
        }

        public async Task<string> ExportCertificateAsBlob(string secretUrl)
        {
            var certContentSecret = await _keyVaultClient.GetSecretAsync(secretUrl).ConfigureAwait(false);

            // Certificates can be exported in a mutiple formats (PFX, PEM).
            // Use the content type to determine how to strongly-type the certificate for the platform
            // The exported certificate doesn't have a password
            if (0 == string.CompareOrdinal(certContentSecret.ContentType, CertificateContentType.Pfx))
            {
                return certContentSecret.Value;

            }

            throw new Exception($"Certificate not found at {secretUrl}");
        }
    }
}
