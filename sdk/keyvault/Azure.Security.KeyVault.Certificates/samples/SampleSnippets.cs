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

            #region CreateClient
            // Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new CertificateClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            #endregion

            #region CreateCertificate
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = await client.StartCreateCertificateAsync("MyCertificate");

            // You can await the completion of the create certificate operation.
            CertificateWithPolicy certificate = await operation.WaitCompletionAsync();
            #endregion

            this.client = client;
        }

        [Test]
        public async Task RetrieveCertificateAsync()
        {
            #region RetrieveCertificate
            CertificateWithPolicy certificateWithPolicy = await client.GetCertificateWithPolicyAsync("MyCertificate");
            #endregion

            #region GetCertificate
            Certificate certificate = await client.GetCertificateAsync(certificateWithPolicy.Name, certificateWithPolicy.Properties.Version);
            #endregion
        }

        [Test]
        public async Task UpdateCertificateAsync()
        {
            CertificateWithPolicy certificate = await client.GetCertificateWithPolicyAsync("MyCertificate");

            #region UpdateCertificate
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
        public async Task NotFoundAsync()
        {
            #region NotFound
            try
            {
                CertificateWithPolicy certificateWithPolicy = await client.GetCertificateWithPolicyAsync("SomeCertificate");
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
            #region DeleteCertificate
            DeletedCertificate deletedCert = await client.DeleteCertificateAsync("MyCertificate");

            Console.WriteLine(deletedCert.ScheduledPurgeDate);

            await client.PurgeDeletedCertificateAsync("MyCertificate");
            #endregion
        }
    }
}
