// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft-delete enabled key vault
    /// using the asynchronous methods of the SecretClient.
    /// </summary>
    [Category("Live")]
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

            var bankSecret = new Secret(bankSecretName, "f4G34fMh8v")
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            var storageSecret = new Secret(storageSecretName, "f4G34fMh8v547")
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            await client.SetAsync(bankSecret);
            await client.SetAsync(storageSecret);

            // You need to check if any of the secrets are sharing same values. Let's list the secrets and print their values.
            // List operations don't return the secrets with value information.
            // So, for each returned secret we call Get to get the secret with its value information.
            await foreach (SecretBase secret in client.GetSecretsAsync())
            {
                Secret secretWithValue = await client.GetAsync(secret.Name);
                Debug.WriteLine($"Secret is returned with name {secretWithValue.Name} and value {secretWithValue.Value}");
            }

            // The bank account password got updated, so you want to update the secret in key vault to ensure it reflects the new password.
            // Calling Set on an existing secret creates a new version of the secret in the key vault with the new value.
            await client.SetAsync(bankSecretName, "sskdjfsdasdjsd");

            // You need to check all the different values your bank account password secret had previously.
            // Lets print all the versions of this secret.
            await foreach (SecretBase secret in client.GetSecretVersionsAsync(bankSecretName))
            {
                Debug.WriteLine($"Secret's version {secret.Version} with name {secret.Name}");
            }

            // The bank account was closed. You need to delete its credentials from the key vault.
            // You also want to delete the information of your storage account.
            await client.DeleteAsync(bankSecretName);
            await client.DeleteAsync(storageSecretName);

            // To ensure secrets are deleted on server side.
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, bankSecretName));
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, storageSecretName));

            // You can list all the deleted and non-purged secrets, assuming key vault is soft-delete enabled.
            await foreach (DeletedSecret secret in client.GetDeletedSecretsAsync())
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            await client.PurgeDeletedAsync(bankSecretName);
            await client.PurgeDeletedAsync(storageSecretName);
        }

        private async Task<bool> WaitForDeletedKeyAsync(SecretClient client, string secretName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    await client.GetDeletedAsync(secretName);
                    return true;
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
            return false;
        }
    }
}
