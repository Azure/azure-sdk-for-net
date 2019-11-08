// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Threading;
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
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            #region Snippet:CreateCertificateClient
            // Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new CertificateClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Create a certificate using the certificate client.
            CertificateOperation operation = client.StartCreateCertificate("MyCertificate", CertificatePolicy.Default);

            // Retrieve a certificate using the certificate client.
            KeyVaultCertificateWithPolicy certificate = client.GetCertificate("MyCertificate");
            #endregion

            this.client = client;
        }

        [Test]
        public void CreateCertificate()
        {
            #region Snippet:CreateCertificate
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = client.StartCreateCertificate("MyCertificate", CertificatePolicy.Default);
            #endregion
        }

        [Test]
        public async Task CreateCertificateAsync()
        {
            #region Snippet:CreateCertificateAsync
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = await client.StartCreateCertificateAsync("MyCertificate", CertificatePolicy.Default);

            // You can  the completion of the create certificate operation.
            KeyVaultCertificateWithPolicy certificate = await operation.WaitForCompletionAsync();
            #endregion
        }

        [Test]
        public void RetrieveCertificate()
        {
            #region Snippet:RetrieveCertificate
            KeyVaultCertificateWithPolicy certificateWithPolicy = client.GetCertificate("MyCertificate");
            #endregion

            #region Snippet:GetCertificate
            KeyVaultCertificate certificate = client.GetCertificateVersion(certificateWithPolicy.Name, certificateWithPolicy.Properties.Version);
            #endregion
        }

        [Test]
        public void UpdateCertificate()
        {
            KeyVaultCertificateWithPolicy certificate = client.GetCertificate("MyCertificate");

            #region Snippet:UpdateCertificate
            CertificateProperties certificateProperties = new CertificateProperties(certificate.Id)
            {
                Tags =
                {
                    ["key1"] = "value1"
                }
            };

            KeyVaultCertificate updated = client.UpdateCertificateProperties(certificateProperties);
            #endregion
        }

        [Test]
        public void ListCertificates()
        {
            #region Snippet:ListCertificates
            Pageable<CertificateProperties> allCertificates = client.GetPropertiesOfCertificates();

            foreach (CertificateProperties certificateProperties in allCertificates)
            {
                Console.WriteLine(certificateProperties.Name);
            }
            #endregion
        }

        [Test]
        public async Task ListCertificatesAsync()
        {
            #region Snippet:ListCertificatesAsync
            AsyncPageable<CertificateProperties> allCertificates = client.GetPropertiesOfCertificatesAsync();

            await foreach (CertificateProperties certificateProperties in allCertificates)
            {
                Console.WriteLine(certificateProperties.Name);
            }
            #endregion
        }

        [Test]
        public void NotFound()
        {
            #region Snippet:CertificateNotFound
            try
            {
                KeyVaultCertificateWithPolicy certificateWithPolicy = client.GetCertificate("SomeCertificate");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [OneTimeTearDown]
        public void DeleteCertificate()
        {
            #region Snippet:DeleteCertificate
            DeletedCertificate deleteCert = client.DeleteCertificate("MyCertificate");

            Console.WriteLine(deleteCert.ScheduledPurgeDate);

            client.PurgeDeletedCertificate(deleteCert.Name);
            #endregion
        }
    }
}
