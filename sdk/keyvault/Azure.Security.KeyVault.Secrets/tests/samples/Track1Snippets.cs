// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Services.AppAuthentication;
using NUnit.Framework;

namespace Microsoft.Azure.KeyVault.Samples
{
    public partial class Track1Snippets
    {
        [Ignore("Used only for the migration guide")]
        private static async Task Track1MigrationGuide()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_Create
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
                #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecretVersions
                IPage<SecretItem> page = await client.GetSecretVersionsAsync("https://myvault.vault.azure.net", "secret-name");
                foreach (SecretItem item in page)
                {
                    SecretIdentifier secretId = item.Identifier;
                    SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name, secretId.Version);
                }

                while (page.NextPageLink != null)
                {
                    page = await client.GetSecretVersionsNextAsync(page.NextPageLink);
                    foreach (SecretItem item in page)
                    {
                        SecretIdentifier secretId = item.Identifier;
                        SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name, secretId.Version);
                    }
                }
                #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecretVersions
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

        [Ignore("Used only for the migration guide")]
        private static void CreateWithOptions()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                KeyVaultClient client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions
        }
    }
}
