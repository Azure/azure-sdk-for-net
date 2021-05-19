// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets
    {
#pragma warning disable IDE1006 // Naming Styles
        private CertificateClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:CreateCertificateClient
            // Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new CertificateClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            #endregion

            this.client = client;
        }

        [Test]
        public void CreateCertificate()
        {
            #region Snippet:CreateCertificate
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = client.StartCreateCertificate("MyCertificate", CertificatePolicy.Default);

            // You can await the completion of the create certificate operation.
            // You should run UpdateStatus in another thread or do other work like pumping messages between calls.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            KeyVaultCertificateWithPolicy certificate = operation.Value;
            #endregion
        }

        [Ignore("The certificate was already created in the synchronous method.")]
        public async Task CreateCertificateAsync()
        {
            #region Snippet:CreateCertificateAsync
            // Create a certificate. This starts a long running operation to create and sign the certificate.
            CertificateOperation operation = await client.StartCreateCertificateAsync("MyCertificate", CertificatePolicy.Default);

            // You can await the completion of the create certificate operation.
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
            CertificateProperties certificateProperties = new CertificateProperties(certificate.Id);
            certificateProperties.Tags["key1"] = "value1";

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
        public async Task DeleteAndPurgeCertificateAsync()
        {
            #region Snippet:DeleteAndPurgeCertificateAsync
            DeleteCertificateOperation operation = await client.StartDeleteCertificateAsync("MyCertificate");

            // You only need to wait for completion if you want to purge or recover the certificate.
            await operation.WaitForCompletionAsync();

            DeletedCertificate certificate = operation.Value;
            await client.PurgeDeletedCertificateAsync(certificate.Name);
            #endregion
        }

        [Ignore("The certificate is deleted and purged on tear down of this text fixture.")]
        public void DeleteAndPurgeCertificate()
        {
            #region Snippet:DeleteAndPurgeCertificate
            DeleteCertificateOperation operation = client.StartDeleteCertificate("MyCertificate");

            // You only need to wait for completion if you want to purge or recover the certificate.
            // You should call `UpdateStatus` in another thread or after doing additional work like pumping messages.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            DeletedCertificate certificate = operation.Value;
            client.PurgeDeletedCertificate(certificate.Name);
            #endregion
        }

        [Ignore("Used only for the migration guide")]
        private async Task MigrationGuide()
        {
            #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_Create
            CertificateClient client = new CertificateClient(
                new Uri("https://myvault.vault.azure.net"),
                new DefaultAzureCredential());
            #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_Create

            #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                CertificateClientOptions options = new CertificateClientOptions
                {
                    Transport = new HttpClientTransport(httpClient)
                };

                //@@CertificateClient client = new CertificateClient(
                /*@@*/ CertificateClient _ = new CertificateClient(
                    new Uri("https://myvault.vault.azure.net"),
                    new DefaultAzureCredential(),
                    options);
            }
            #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions

            #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCustomPolicy
            CertificatePolicy policy = new CertificatePolicy("issuer-name", "CN=customdomain.com")
            {
                ContentType = CertificateContentType.Pkcs12,
                KeyType = CertificateKeyType.Rsa,
                ReuseKey = true,
                KeyUsage =
                {
                    CertificateKeyUsage.CrlSign,
                    CertificateKeyUsage.DataEncipherment,
                    CertificateKeyUsage.DigitalSignature,
                    CertificateKeyUsage.KeyEncipherment,
                    CertificateKeyUsage.KeyAgreement,
                    CertificateKeyUsage.KeyCertSign
                },
                ValidityInMonths = 12,
                LifetimeActions =
                {
                    new LifetimeAction(CertificatePolicyAction.AutoRenew)
                    {
                        DaysBeforeExpiry = 90,
                    }
                }
            };
            #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy

            #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
            //@@CertificatePolicy policy = CertificatePolicy.Default;
            /*@@*/ policy = CertificatePolicy.Default;
            #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
            {
                #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
                // Start certificate creation.
                // Depending on the policy and your business process, this could even take days for manual signing.
                CertificateOperation createOperation = await client.StartCreateCertificateAsync("certificate-name", policy);
                KeyVaultCertificateWithPolicy certificate = await createOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(20), CancellationToken.None);

                // If you need to restart the application you can recreate the operation and continue awaiting.
                createOperation = new CertificateOperation(client, "certificate-name");
                certificate = await createOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(20), CancellationToken.None);
                #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
            }

            {
                #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
                byte[] cer = File.ReadAllBytes("certificate.pfx");
                ImportCertificateOptions importCertificateOptions = new ImportCertificateOptions("certificate-name", cer)
                {
                    Policy = policy
                };

                KeyVaultCertificateWithPolicy certificate = await client.ImportCertificateAsync(importCertificateOptions);
                #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
            }

            {
                #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
                // List all certificates asynchronously.
                await foreach (CertificateProperties item in client.GetPropertiesOfCertificatesAsync())
                {
                    KeyVaultCertificateWithPolicy certificate = await client.GetCertificateAsync(item.Name);
                }

                // List all certificates synchronously.
                foreach (CertificateProperties item in client.GetPropertiesOfCertificates())
                {
                    KeyVaultCertificateWithPolicy certificate = client.GetCertificate(item.Name);
                }
                #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
            }

            {
                #region Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
                // Delete the certificate.
                DeleteCertificateOperation deleteOperation = await client.StartDeleteCertificateAsync("certificate-name");

                // Purge or recover the deleted certificate if soft delete is enabled.
                if (deleteOperation.Value.RecoveryId != null)
                {
                    // Deleting a certificate does not happen immediately. Wait for the certificate to be deleted.
                    DeletedCertificate deletedCertificate = await deleteOperation.WaitForCompletionAsync();

                    // Purge the deleted certificate.
                    await client.PurgeDeletedCertificateAsync(deletedCertificate.Name);

                    // You can also recover the deleted certificate using StartRecoverDeletedCertificateAsync,
                    // which returns RecoverDeletedCertificateOperation you can await like DeleteCertificateOperation above.
                }
                #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
            }
        }
    }
}
