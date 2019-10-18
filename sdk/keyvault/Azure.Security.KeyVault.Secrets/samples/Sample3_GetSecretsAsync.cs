// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft-delete enabled key vault
    /// using the asynchronous methods of the SecretClient.
    /// </summary>
    [LiveOnly]
    public partial class GetSecrets
    {
        [Test]
        public async Task GetSecretsAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a secret client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create secrets holding storage and bank accounts credentials valid for 1 year. if the secret
            // already exists in the key vault, then a new version of the secret is created.
            string bankSecretName = $"BankAccountPassword-{Guid.NewGuid()}";
            string storageSecretName = $"StorageAccountPasswor{Guid.NewGuid()}";

            var bankSecret = new KeyVaultSecret(bankSecretName, "f4G34fMh8v")
            {
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddYears(1)
                }
            };

            var storageSecret = new KeyVaultSecret(storageSecretName, "f4G34fMh8v547")
            {
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddYears(1)
                }
            };

            await client.SetSecretAsync(bankSecret);
            await client.SetSecretAsync(storageSecret);

            // You need to check if any of the secrets are sharing same values. Let's list the secrets and print their values.
            // List operations don't return the secrets with value information.
            // So, for each returned secret we call Get to get the secret with its value information.
            await foreach (SecretProperties secret in client.GetPropertiesOfSecretsAsync())
            {
                KeyVaultSecret secretWithValue = await client.GetSecretAsync(secret.Name);
                Debug.WriteLine($"Secret is returned with name {secretWithValue.Name} and value {secretWithValue.Value}");
            }

            // The bank account password got updated, so you want to update the secret in key vault to ensure it reflects the new password.
            // Calling Set on an existing secret creates a new version of the secret in the key vault with the new value.
            await client.SetSecretAsync(bankSecretName, "sskdjfsdasdjsd");

            // You need to check all the different values your bank account password secret had previously.
            // Lets print all the versions of this secret.
            await foreach (SecretProperties secret in client.GetPropertiesOfSecretVersionsAsync(bankSecretName))
            {
                Debug.WriteLine($"Secret's version {secret.Version} with name {secret.Name}");
            }

            // The bank account was closed. You need to delete its credentials from the key vault.
            // You also want to delete the information of your storage account.
            DeleteSecretOperation bankSecretOperation = await client.StartDeleteSecretAsync(bankSecretName);
            DeleteSecretOperation storageSecretOperation = await client.StartDeleteSecretAsync(storageSecretName);

            // To ensure the secrets are deleted on server before we try to purge them.
            Task.WaitAll(
                bankSecretOperation.WaitForCompletionAsync().AsTask(),
                storageSecretOperation.WaitForCompletionAsync().AsTask());

            // You can list all the deleted and non-purged secrets, assuming key vault is soft-delete enabled.
            await foreach (DeletedSecret secret in client.GetDeletedSecretsAsync())
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            Task.WaitAll(
                client.PurgeDeletedSecretAsync(bankSecretName),
                client.PurgeDeletedSecretAsync(storageSecretName));
        }
    }
}
