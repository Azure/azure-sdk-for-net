// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using NUnit.Framework;

namespace Microsoft.Azure.KeyVault.Samples
{
    public partial class Track1Snippets
    {
        [Ignore("Used only for the migration guide")]
        private static async Task Track1MigrationGuide()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_Create

            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateCustomPolicy
            CertificatePolicy policy = new CertificatePolicy
            {
                IssuerParameters = new IssuerParameters("issuer-name"),
                SecretProperties = new SecretProperties("application/x-pkcs12"),
                KeyProperties = new KeyProperties
                {
                    KeyType = "RSA",
                    KeySize = 2048,
                    ReuseKey = true
                },
                X509CertificateProperties = new X509CertificateProperties("CN=customdomain.com")
                {
                    KeyUsage = new[]
                    {
                      KeyUsageType.CRLSign,
                      KeyUsageType.DataEncipherment,
                      KeyUsageType.DigitalSignature,
                      KeyUsageType.KeyEncipherment,
                      KeyUsageType.KeyAgreement,
                      KeyUsageType.KeyCertSign
                    },
                    ValidityInMonths = 12
                },
                LifetimeActions = new[]
                {
                    new LifetimeAction(
                        new Trigger
                        {
                            DaysBeforeExpiry = 90
                        },
                        new Models.Action(ActionType.AutoRenew))
                }
            };
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateCustomPolicy
            {
                #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
                CertificateBundle certificate = null;

                // Start certificate creation.
                // Depending on the policy and your business process, this could even take days for manual signing.
                CertificateOperation createOperation = await client.CreateCertificateAsync("https://myvault.vault.azure.net", "certificate-name", policy);
                while (true)
                {
                    if ("InProgress".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
                    {
                        await Task.Delay(TimeSpan.FromSeconds(20));

                        createOperation = await client.GetCertificateOperationAsync("https://myvault.vault.azure.net", "certificate-name");
                        continue;
                    }

                    if ("Completed".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
                    {
                        certificate = await client.GetCertificateAsync(createOperation.Id);
                        break;
                    }

                    throw new Exception(string.Format(
                        CultureInfo.InvariantCulture,
                        "Polling on pending certificate returned an unexpected result. Error code = {0}, Error message = {1}",
                        createOperation.Error.Code,
                        createOperation.Error.Message));
                }

                // If you need to restart the application you can recreate the operation and continue awaiting.
                do
                {
                    createOperation = await client.GetCertificateOperationAsync("https://myvault.vault.azure.net", "certificate-name");

                    if ("InProgress".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
                    {
                        await Task.Delay(TimeSpan.FromSeconds(20));
                        continue;
                    }

                    if ("Completed".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
                    {
                        certificate = await client.GetCertificateAsync(createOperation.Id);
                        break;
                    }

                    throw new Exception(string.Format(
                        CultureInfo.InvariantCulture,
                        "Polling on pending certificate returned an unexpected result. Error code = {0}, Error message = {1}",
                        createOperation.Error.Code,
                        createOperation.Error.Message));
                } while (true);
                #endregion Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
                byte[] cer = File.ReadAllBytes("certificate.pfx");
                string cerBase64 = Convert.ToBase64String(cer);

                CertificateBundle certificate = await client.ImportCertificateAsync(
                    "https://myvault.vault.azure.net",
                    "certificate-name",
                    cerBase64,
                    certificatePolicy: policy);
                #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
                IPage<CertificateItem> page = await client.GetCertificatesAsync("https://myvault.vault.azure.net");
                foreach (CertificateItem item in page)
                {
                    CertificateIdentifier certificateId = item.Identifier;
                    CertificateBundle certificate = await client.GetCertificateAsync(certificateId.Vault, certificateId.Name);
                }

                while (page.NextPageLink != null)
                {
                    page = await client.GetCertificatesNextAsync(page.NextPageLink);
                    foreach (CertificateItem item in page)
                    {
                        CertificateIdentifier certificateId = item.Identifier;
                        CertificateBundle certificate = await client.GetCertificateAsync(certificateId.Vault, certificateId.Name);
                    }
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
                // Delete the certificate.
                DeletedCertificateBundle deletedCertificate = await client.DeleteCertificateAsync("https://myvault.vault.azure.net", "certificate-name");

                // Purge or recover the deleted certificate if soft delete is enabled.
                if (deletedCertificate.RecoveryId != null)
                {
                    DeletedCertificateIdentifier deletedCertificateId = deletedCertificate.RecoveryIdentifier;

                    // Deleting a certificate does not happen immediately. Wait a while and check if the deleted certificate exists.
                    while (true)
                    {
                        try
                        {
                            await client.GetDeletedCertificateAsync(deletedCertificateId.Vault, deletedCertificateId.Name);

                            // Finally deleted.
                            break;
                        }
                        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // Not yet deleted...
                        }
                    }

                    // Purge the deleted certificate.
                    await client.PurgeDeletedCertificateAsync(deletedCertificateId.Vault, deletedCertificateId.Name);

                    // You can also recover the deleted certificate using RecoverDeletedCertificateAsync.
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
            }
        }

        [Ignore("Used only for the migration guide")]
        private static void CreateWithOptions()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                KeyVaultClient client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
        }

        [Ignore("Used only for the migration guide")]
        private static void CreateSelfSignedPolicy()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
            CertificatePolicy policy = new CertificatePolicy
            {
                IssuerParameters = new IssuerParameters("Self"),
                X509CertificateProperties = new X509CertificateProperties("CN=DefaultPolicy")
            };
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
        }
    }
}
