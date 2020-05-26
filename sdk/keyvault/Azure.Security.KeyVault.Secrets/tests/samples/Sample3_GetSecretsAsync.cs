// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft delete-enabled key vault
    /// using the asynchronous methods of the SecretClient.
    /// </summary>
    public partial class GetSecrets
    {
        [Test]
        public async Task GetSecretsAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string bankSecretName = $"BankAccountPassword-{Guid.NewGuid()}";
            string storageSecretName = $"StorageAccountPassword{Guid.NewGuid()}";

            var bankSecret = new KeyVaultSecret(bankSecretName, "f4G34fMh8v");
            bankSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            var storageSecret = new KeyVaultSecret(storageSecretName, "f4G34fMh8v547");
            storageSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            await client.SetSecretAsync(bankSecret);
            await client.SetSecretAsync(storageSecret);

            Dictionary<string, string> secretValues = new Dictionary<string, string>();

            await foreach (SecretProperties secret in client.GetPropertiesOfSecretsAsync())
            {
                /*@@*/ if (secret.Managed) continue;
                // Getting a disabled secret will fail, so skip disabled secrets.
                if (!secret.Enabled.GetValueOrDefault())
                {
                    continue;
                }

                KeyVaultSecret secretWithValue = await client.GetSecretAsync(secret.Name);
                if (secretValues.ContainsKey(secretWithValue.Value))
                {
                    Debug.WriteLine($"Secret {secretWithValue.Name} shares a value with secret {secretValues[secretWithValue.Value]}");
                }
                else
                {
                    secretValues.Add(secretWithValue.Value, secretWithValue.Name);
                }
            }

            string newBankSecretPassword = "sskdjfsdasdjsd";

            await foreach (SecretProperties secret in client.GetPropertiesOfSecretVersionsAsync(bankSecretName))
            {
                // Secret versions may also be disabled if compromised and new versions generated, so skip disabled versions, too.
                if (!secret.Enabled.GetValueOrDefault())
                {
                    continue;
                }

                KeyVaultSecret oldBankSecret = await client.GetSecretAsync(secret.Name, secret.Version);
                if (newBankSecretPassword == oldBankSecret.Value)
                {
                    Debug.WriteLine($"Secret {secret.Name} reuses a password");
                }
            }

            await client.SetSecretAsync(bankSecretName, newBankSecretPassword);

            DeleteSecretOperation bankSecretOperation = await client.StartDeleteSecretAsync(bankSecretName);
            DeleteSecretOperation storageSecretOperation = await client.StartDeleteSecretAsync(storageSecretName);

            // You only need to wait for completion if you want to purge or recover the secret.
            await Task.WhenAll(
                bankSecretOperation.WaitForCompletionAsync().AsTask(),
                storageSecretOperation.WaitForCompletionAsync().AsTask());

            await foreach (DeletedSecret secret in client.GetDeletedSecretsAsync())
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }

            // If the Key Vault is soft delete-enabled, then for permanent deletion, deleted secret needs to be purged.
            await Task.WhenAll(
                client.PurgeDeletedSecretAsync(bankSecretName),
                client.PurgeDeletedSecretAsync(storageSecretName));
        }
    }
}
