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
    /// This sample demonstrates how to create, get, update, and delete a secret in Azure Key Vault using synchronous methods of <see cref="SecretClient"/>.
    /// </summary>
    [LiveOnly]
    public partial class HelloWorld
    {
        [Test]
        public void HelloWorldSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");
            HelloWorldSync(keyVaultUrl);
        }

        private void HelloWorldSync(string keyVaultUrl)
        {
            #region Snippet:SecretsHelloWorldSecretClient
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:SecretsHelloWorldCreateSecret
            string secretName = $"BankAccountPassword-{Guid.NewGuid()}";

            var secret = new KeyVaultSecret(secretName, "f4G34fMh8v");
            secret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            client.SetSecret(secret);
            #endregion

            #region Snippet:SecretsHelloWorldGetSecret
            KeyVaultSecret bankSecret = client.GetSecret(secretName);
            Debug.WriteLine($"Secret is returned with name {bankSecret.Name} and value {bankSecret.Value}");
            #endregion

            #region Snippet:SecretsHelloWorldUpdateSecretProperties
            bankSecret.Properties.ExpiresOn = bankSecret.Properties.ExpiresOn.Value.AddYears(1);
            SecretProperties updatedSecret = client.UpdateSecretProperties(bankSecret.Properties);
            Debug.WriteLine($"Secret's updated expiry time is {updatedSecret.ExpiresOn}");
            #endregion

            #region Snippet:SecretsHelloWorldUpdateSecret
            var secretNewValue = new KeyVaultSecret(secretName, "bhjd4DDgsa");
            secretNewValue.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            client.SetSecret(secretNewValue);
            #endregion

            #region Snippet:SecretsHelloWorldDeleteSecret
            DeleteSecretOperation operation = client.StartDeleteSecret(secretName);
            #endregion

            #region Snippet:SecretsHelloWorldPurgeSecret
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            client.PurgeDeletedSecret(secretName);
            #endregion
        }
    }
}
