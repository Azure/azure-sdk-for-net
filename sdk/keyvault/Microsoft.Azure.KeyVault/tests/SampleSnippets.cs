// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.WebKey;
    using Microsoft.Azure.Services.AppAuthentication;

    // Used to compile sample snippets used in MigrationGuide.md documents for track 1.
    internal class SampleSnippets
    {
        private async Task CertificatesMigrationGuide()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_Create

            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                //@@AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                /*@@*/ provider = new AzureServiceTokenProvider();
                //@@KeyVaultClient client = new KeyVaultClient(
                /*@@*/ client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions

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

            #region Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
            //@@CertificatePolicy policy = new CertificatePolicy
            /*@@*/
            policy = new CertificatePolicy
            {
                IssuerParameters = new IssuerParameters("Self"),
                X509CertificateProperties = new X509CertificateProperties("CN=DefaultPolicy")
            };
            #endregion Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
            // TODO

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

        private async Task KeysMigrationGuide()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Create

            #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                //@@AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                /*@@*/ provider = new AzureServiceTokenProvider();
                //@@KeyVaultClient client = new KeyVaultClient(
                /*@@*/ client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions

            {
                #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateKey
                // Create RSA key.
                NewKeyParameters createRsaParameters = new NewKeyParameters
                {
                    Kty = JsonWebKeyType.Rsa,
                    KeySize = 4096
                };

                KeyBundle rsaKey = await client.CreateKeyAsync("https://myvault.vault.azure.net", "rsa-key-name", createRsaParameters);

                // Create Elliptic-Curve key.
                NewKeyParameters createEcParameters = new NewKeyParameters
                {
                    Kty = JsonWebKeyType.EllipticCurve,
                    CurveName = "P-256"
                };

                KeyBundle ecKey = await client.CreateKeyAsync("https://myvault.vault.azure.net", "ec-key-name", createEcParameters);
                #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateKey
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
                IPage<KeyItem> page = await client.GetKeysAsync("https://myvault.vault.azure.net");
                foreach (KeyItem item in page)
                {
                    KeyIdentifier keyId = item.Identifier;
                    KeyBundle key = await client.GetKeyAsync(keyId.Vault, keyId.Name);
                }

                while (page.NextPageLink != null)
                {
                    page = await client.GetKeysNextAsync(page.NextPageLink);
                    foreach (KeyItem item in page)
                    {
                        KeyIdentifier keyId = item.Identifier;
                        KeyBundle key = await client.GetKeyAsync(keyId.Vault, keyId.Name);
                    }
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
                // Delete the key.
                DeletedKeyBundle deletedKey = await client.DeleteKeyAsync("https://myvault.vault.azure.net", "key-name");

                // Purge or recover the deleted key if soft delete is enabled.
                if (deletedKey.RecoveryId != null)
                {
                    DeletedKeyIdentifier deletedKeyId = deletedKey.RecoveryIdentifier;

                    // Deleting a key does not happen immediately. Wait a while and check if the deleted key exists.
                    while (true)
                    {
                        try
                        {
                            await client.GetDeletedKeyAsync(deletedKeyId.Vault, deletedKeyId.Name);

                            // Finally deleted.
                            break;
                        }
                        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // Not yet deleted...
                        }
                    }

                    // Purge the deleted key.
                    await client.PurgeDeletedKeyAsync(deletedKeyId.Vault, deletedKeyId.Name);

                    // You can also recover the deleted key using RecoverDeletedKeyAsync.
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
                // Encrypt a message. The plaintext must be small enough for the chosen algorithm.
                byte[] plaintext = Encoding.UTF8.GetBytes("Small message to encrypt");
                KeyOperationResult encrypted = await client.EncryptAsync("rsa-key-name", JsonWebKeyEncryptionAlgorithm.RSAOAEP256, plaintext);

                // Decrypt the message.
                KeyOperationResult decrypted = await client.DecryptAsync("rsa-key-name", JsonWebKeyEncryptionAlgorithm.RSAOAEP256, encrypted.Result);
                string message = Encoding.UTF8.GetString(decrypted.Result);
                #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Wrap
                using (Aes aes = Aes.Create())
                {
                    // Use a symmetric key to encrypt large amounts of data, possibly streamed...

                    // Now wrap the key and store the encrypted key and plaintext IV to later decrypt the key to decrypt the data.
                    KeyOperationResult wrapped = await client.WrapKeyAsync(
                        "https://myvault.vault.azure.net",
                        "rsa-key-name",
                        null,
                        JsonWebKeyEncryptionAlgorithm.RSAOAEP256,
                        aes.Key);

                    // Read the IV and the encrypted key from the payload, then unwrap the key.
                    KeyOperationResult unwrapped = await client.UnwrapKeyAsync(
                        "https://myvault.vault.azure.net",
                        "rsa-key-name",
                        null,
                        JsonWebKeyEncryptionAlgorithm.RSAOAEP256,
                        wrapped.Result);

                    aes.Key = unwrapped.Result;

                    // Decrypt the payload with the symmetric key.
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Wrap
            }
        }

        private async Task SecretsMigrationGuide()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_Create

            #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                //@@AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                /*@@*/ provider = new AzureServiceTokenProvider();
                //@@KeyVaultClient client = new KeyVaultClient(
                /*@@*/ client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions

            {
                #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_SetSecret
                SecretBundle secret = await client.SetSecretAsync("https://myvault.vault.azure.net", "secret-name", "secret-value");
                #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_SetSecret
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_GetSecret
                // Get the latest secret value.
                SecretBundle secret = await client.GetSecretAsync("https://myvault.vault.azure.net", "secret-name", null);

                // Get a specific secret value.
                SecretBundle secretVersion = await client.GetSecretAsync("https://myvault.vault.azure.net", "secret-name", "e43af03a7cbc47d4a4e9f11540186048");
                #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_GetSecret
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecrets
                IPage<SecretItem> page = await client.GetSecretsAsync("https://myvault.vault.azure.net");
                foreach (SecretItem item in page)
                {
                    SecretIdentifier secretId = item.Identifier;
                    SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name);
                }

                while (page.NextPageLink != null)
                {
                    page = await client.GetSecretsNextAsync(page.NextPageLink);
                    foreach (SecretItem item in page)
                    {
                        SecretIdentifier secretId = item.Identifier;
                        SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name);
                    }
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecrets
            }

            {
                #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_DeleteSecret
                // Delete the secret.
                DeletedSecretBundle deletedSecret = await client.DeleteSecretAsync("https://myvault.vault.azure.net", "secret-name");

                // Purge or recover the deleted secret if soft delete is enabled.
                if (deletedSecret.RecoveryId != null)
                {
                    DeletedSecretIdentifier deletedSecretId = deletedSecret.RecoveryIdentifier;

                    // Deleting a secret does not happen immediately. Wait a while and check if the deleted secret exists.
                    while (true)
                    {
                        try
                        {
                            await client.GetDeletedSecretAsync(deletedSecretId.Vault, deletedSecretId.Name);

                            // Finally deleted.
                            break;
                        }
                        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // Not yet deleted...
                        }
                    }

                    // Purge the deleted secret.
                    await client.PurgeDeletedSecretAsync(deletedSecretId.Vault, deletedSecretId.Name);

                    // You can also recover the deleted secret using RecoverDeletedSecretAsync.
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_DeleteSecret
            }
        }
    }
}
