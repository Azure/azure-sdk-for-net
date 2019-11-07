﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft delete-enabled key vault
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
            await GetSecretsAsync(keyVaultUrl);
        }

        private async Task GetSecretsAsync(string keyVaultUrl)
        {
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
                KeyVaultSecret secretWithValue = await client.GetSecretAsync(secret.Name);

                if (secretValues.ContainsKey(secretWithValue.Value))
                {
                    throw new InvalidOperationException($"Secret {secretWithValue.Name} shares a value with secret {secretValues[secretWithValue.Value]}");
                }

                secretValues.Add(secretWithValue.Value, secretWithValue.Name);
            }

            string newBankSecretPassword = "sskdjfsdasdjsd";

            await foreach (SecretProperties secret in client.GetPropertiesOfSecretVersionsAsync(bankSecretName))
            {
                KeyVaultSecret oldBankSecret = await client.GetSecretAsync(secret.Name, secret.Version);
                if (newBankSecretPassword == oldBankSecret.Value)
                {
                    throw new InvalidOperationException($"Secret {secret.Name} reuses a password");
                }
            }

            await client.SetSecretAsync(bankSecretName, newBankSecretPassword);

            DeleteSecretOperation bankSecretOperation = await client.StartDeleteSecretAsync(bankSecretName);
            DeleteSecretOperation storageSecretOperation = await client.StartDeleteSecretAsync(storageSecretName);

            Task.WaitAll(
                bankSecretOperation.WaitForCompletionAsync().AsTask(),
                storageSecretOperation.WaitForCompletionAsync().AsTask());

            await foreach (DeletedSecret secret in client.GetDeletedSecretsAsync())
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }

            // If the Key Vault is soft delete-enabled, then for permanent deletion, deleted secret needs to be purged.
            Task.WaitAll(
                client.PurgeDeletedSecretAsync(bankSecretName),
                client.PurgeDeletedSecretAsync(storageSecretName));
        }
    }
}
