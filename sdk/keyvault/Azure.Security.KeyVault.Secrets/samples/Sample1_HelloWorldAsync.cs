// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to set, get, update and delete a secret using the asynchronous methods of the SecretClient.
    /// </summary>
    [LiveOnly]
    public partial class HelloWorld
    {
        [Test]
        public async Task HelloWorldAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a secret client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a secret holding bank account credentials valid for 1 year. if the secret
            // already exists in the key vault, then a new version of the secret is created.
            string secretName = $"BankAccountPassword-{Guid.NewGuid()}";

            var secret = new Secret(secretName, "f4G34fMh8v")
            {
                Properties =
                {
                    Expires = DateTimeOffset.Now.AddYears(1)
                }
            };

            await client.SetAsync(secret);

            // Let's Get the bank secret from the key vault.
            Secret bankSecret = await client.GetAsync(secretName);
            Debug.WriteLine($"Secret is returned with name {bankSecret.Properties.Name} and value {bankSecret.Value}");

            // After one year, the bank account is still active, we need to update the expiry time of the secret.
            // The update method can be used to update the expiry attribute of the secret. It cannot be used to update
            // the value of the secret.
            bankSecret.Properties.Expires = bankSecret.Properties.Expires.Value.AddYears(1);
            SecretProperties updatedSecret = await client.UpdatePropertiesAsync(bankSecret.Properties);
            Debug.WriteLine($"Secret's updated expiry time is {updatedSecret.Expires}");

            // Bank forced a password update for security purposes. Let's change the value of the secret in the key vault.
            // To achieve this, we need to create a new version of the secret in the key vault. The update operation cannot
            // change the value of the secret.
            var secretNewValue = new Secret(secretName, "bhjd4DDgsa")
            {
                Properties =
                {
                    Expires = DateTimeOffset.Now.AddYears(1)
                }
            };

            await client.SetAsync(secretNewValue);

            // The bank account was closed. You need to delete its credentials from the key vault.
            await client.DeleteAsync(secretName);

            // To ensure secret is deleted on server side.
            Assert.IsTrue(await WaitForDeletedSecretAsync(client, secretName));

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            await client.PurgeDeletedAsync(secretName);

        }

        private async Task<bool> WaitForDeletedSecretAsync(SecretClient client, string secretName)
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
