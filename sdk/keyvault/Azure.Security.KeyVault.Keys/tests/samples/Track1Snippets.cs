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
            #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Create
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            KeyVaultClient client = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Create
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

        [Ignore("Used only for the migration guide")]
        private static void CreateWithOptions()
        {
            #region Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
                KeyVaultClient client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
                    httpClient);
            }
            #endregion Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
        }
    }
}
