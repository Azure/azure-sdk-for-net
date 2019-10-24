// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class Snippets
    {
#pragma warning disable IDE1006 // Naming Styles
        private CertificateClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public async Task CreateClientAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            #region Snippet:CreateCertificateClient
            // Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new CertificateClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateCertificate
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = await client.StartCreateCertificateAsync("MyCertificate");

            // You can await the completion of the create certificate operation.
            CertificateWithPolicy certificate = await operation.WaitForCompletionAsync();
            #endregion

            this.client = client;
        }

        [Test]
        public async Task RetrieveCertificateAsync()
        {
            #region Snippet:RetrieveCertificate
            CertificateWithPolicy certificateWithPolicy = await client.GetCertificateAsync("MyCertificate");
            #endregion

            #region Snippet:GetCertificate
            Certificate certificate = await client.GetCertificateVersionAsync(certificateWithPolicy.Name, certificateWithPolicy.Properties.Version);
            #endregion
        }

        [Test]
        public async Task UpdateCertificateAsync()
        {
            CertificateWithPolicy certificate = await client.GetCertificateAsync("MyCertificate");

            #region Snippet:UpdateCertificate
            CertificateProperties certificateProperties = new CertificateProperties(certificate.Id)
            {
                Tags =
                {
                    ["key1"] = "value1"
                }
            };

            Certificate updated = await client.UpdateCertificatePropertiesAsync(certificateProperties);
            #endregion
        }

        [Test]
        public async Task ListCertificatesAsync()
        {
            #region Snippet:ListCertificates
            AsyncPageable<CertificateProperties> allCertificates = client.GetCertificatesAsync();

            await foreach (CertificateProperties certificateProperties in allCertificates)
            {
                Console.WriteLine(certificateProperties.Name);
            }
            #endregion
        }

        [Test]
        public async Task NotFoundAsync()
        {
            #region Snippet:CertificateNotFound
            try
            {
                CertificateWithPolicy certificateWithPolicy = await client.GetCertificateAsync("SomeCertificate");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [OneTimeTearDown]
        public async Task DeleteCertificateAsync()
        {
            #region Snippet:DeleteCertificate
            DeletedCertificate deletedCert = await client.DeleteCertificateAsync("MyCertificate");

            Console.WriteLine(deletedCert.ScheduledPurgeDate);

            await client.PurgeDeletedCertificateAsync("MyCertificate");
            #endregion
        }
    }
}
