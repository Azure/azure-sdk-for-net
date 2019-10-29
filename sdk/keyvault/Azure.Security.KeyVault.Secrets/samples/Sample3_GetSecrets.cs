// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft-delete enabled key vault
    /// using the synchronous methods of the SecretClient.
    /// </summary>
    [LiveOnly]
    public partial class GetSecrets
    {
        [Test]
        public void GetSecretsSync()
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

            client.SetSecret(bankSecret);
            client.SetSecret(storageSecret);

            // You need to check if any of the secrets are sharing same values. Let's list the secrets and print their values.
            // List operations don't return the secrets with value information.
            // So, for each returned secret we call Get to get the secret with its value information.

            IEnumerable<SecretProperties> secrets = client.GetPropertiesOfSecrets();
            foreach (SecretProperties secret in secrets)
            {
                KeyVaultSecret secretWithValue = client.GetSecret(secret.Name);
                Debug.WriteLine($"Secret is returned with name {secretWithValue.Name} and value {secretWithValue.Value}");
            }

            // The bank account password got updated, so you want to update the secret in key vault to ensure it reflects the new password.
            // Calling Set on an existing secret creates a new version of the secret in the key vault with the new value.
            client.SetSecret(bankSecretName, "sskdjfsdasdjsd");

            // You need to check all the different values your bank account password secret had previously.
            // Lets print all the versions of this secret.
            IEnumerable<SecretProperties> secretVersions = client.GetPropertiesOfSecretVersions(bankSecretName);
            foreach (SecretProperties secret in secretVersions)
            {
                Debug.WriteLine($"Secret's version {secret.Version} with name {secret.Name}");
            }

            // The bank account was closed. You need to delete its credentials from the key vault.
            // You also want to delete the information of your storage account.
            DeleteSecretOperation bankSecretOperation = client.StartDeleteSecret(bankSecretName);
            DeleteSecretOperation storageSecretOperation = client.StartDeleteSecret(storageSecretName);

            // To ensure the secrets are deleted on server before we try to purge them.
            while (!bankSecretOperation.HasCompleted || !storageSecretOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                bankSecretOperation.UpdateStatus();
                storageSecretOperation.UpdateStatus();
            }

            // You can list all the deleted and non-purged secrets, assuming key vault is soft-delete enabled.
            IEnumerable<DeletedSecret> secretsDeleted = client.GetDeletedSecrets();
            foreach (DeletedSecret secret in secretsDeleted)
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            client.PurgeDeletedSecret(bankSecretName);
            client.PurgeDeletedSecret(storageSecretName);
        }
    }
}
