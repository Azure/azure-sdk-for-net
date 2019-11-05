// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to set, get, update and delete a secret using the synchronous methods of the SecretClient.
    /// </summary>
    [LiveOnly]
    public partial class HelloWorld
    {
        [Test]
        public void HelloWorldSync()
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

            var secret = new KeyVaultSecret(secretName, "f4G34fMh8v")
            {
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddYears(1)
                }
            };

            client.SetSecret(secret);

            // Let's Get the bank secret from the key vault.
            KeyVaultSecret bankSecret = client.GetSecret(secretName);
            Debug.WriteLine($"Secret is returned with name {bankSecret.Name} and value {bankSecret.Value}");

            // After one year, the bank account is still active, we need to update the expiry time of the secret.
            // The update method can be used to update the expiry attribute of the secret. It cannot be used to update
            // the value of the secret.
            bankSecret.Properties.ExpiresOn = bankSecret.Properties.ExpiresOn.Value.AddYears(1);
            SecretProperties updatedSecret = client.UpdateSecretProperties(bankSecret.Properties);
            Debug.WriteLine($"Secret's updated expiry time is {updatedSecret.ExpiresOn}");

            // Bank forced a password update for security purposes. Let's change the value of the secret in the key vault.
            // To achieve this, we need to create a new version of the secret in the key vault. The update operation cannot
            // change the value of the secret.
            var secretNewValue = new KeyVaultSecret(secretName, "bhjd4DDgsa")
            {
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddYears(1)
                }
            };

            client.SetSecret(secretNewValue);

            // The bank account was closed. You need to delete its credentials from the key vault.
            DeleteSecretOperation operation = client.StartDeleteSecret(secretName);

            // To ensure the secret is deleted on server before we try to purge it.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            client.PurgeDeletedSecret(secretName);
        }
    }
}
