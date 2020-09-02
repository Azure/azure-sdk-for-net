// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// This sample demonstrates how to create, get, update, and delete a secret in Azure Key Vault using asynchronous methods of <see cref="SecretClient"/>.
    /// </summary>
    public partial class HelloWorld
    {
        [Test]
        public async Task HelloWorldAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string secretName = $"BankAccountPassword-{Guid.NewGuid()}";

            var secret = new KeyVaultSecret(secretName, "f4G34fMh8v");
            secret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            await client.SetSecretAsync(secret);

            KeyVaultSecret bankSecret = await client.GetSecretAsync(secretName);
            Debug.WriteLine($"Secret is returned with name {bankSecret.Name} and value {bankSecret.Value}");

            bankSecret.Properties.ExpiresOn = bankSecret.Properties.ExpiresOn.Value.AddYears(1);
            SecretProperties updatedSecret = await client.UpdateSecretPropertiesAsync(bankSecret.Properties);
            Debug.WriteLine($"Secret's updated expiry time is {updatedSecret.ExpiresOn}");

            var secretNewValue = new KeyVaultSecret(secretName, "bhjd4DDgsa");
            secretNewValue.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            await client.SetSecretAsync(secretNewValue);

            DeleteSecretOperation operation = await client.StartDeleteSecretAsync(secretName);

            #region Snippet:SecretsSample1PurgeSecretAsync
            // You only need to wait for completion if you want to purge or recover the secret.
            await operation.WaitForCompletionAsync();

            await client.PurgeDeletedSecretAsync(secretName);
            #endregion
        }
    }
}
