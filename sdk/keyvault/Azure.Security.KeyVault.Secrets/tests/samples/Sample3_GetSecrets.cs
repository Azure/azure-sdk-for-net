// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to list secrets and versions of a given secret,
    /// and list deleted secrets in a soft delete-enabled key vault
    /// using the synchronous methods of the SecretClient.
    /// </summary>
    public partial class GetSecrets
    {
        [Test]
        public void GetSecretsSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:SecretsSample3SecretClient
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:SecretsSample3CreateSecret
            string bankSecretName = $"BankAccountPassword-{Guid.NewGuid()}";
            string storageSecretName = $"StorageAccountPassword{Guid.NewGuid()}";

            var bankSecret = new KeyVaultSecret(bankSecretName, "f4G34fMh8v");
            bankSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            var storageSecret = new KeyVaultSecret(storageSecretName, "f4G34fMh8v547");
            storageSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

            client.SetSecret(bankSecret);
            client.SetSecret(storageSecret);
            #endregion

            #region Snippet:SecretsSample3ListSecrets
            Dictionary<string, string> secretValues = new Dictionary<string, string>();

            IEnumerable<SecretProperties> secrets = client.GetPropertiesOfSecrets();
            foreach (SecretProperties secret in secrets)
            {
                /*@@*/ if (secret.Managed) continue;
                // Getting a disabled secret will fail, so skip disabled secrets.
                if (!secret.Enabled.GetValueOrDefault())
                {
                    continue;
                }

                KeyVaultSecret secretWithValue = client.GetSecret(secret.Name);
                if (secretValues.ContainsKey(secretWithValue.Value))
                {
                    Debug.WriteLine($"Secret {secretWithValue.Name} shares a value with secret {secretValues[secretWithValue.Value]}");
                }
                else
                {
                    secretValues.Add(secretWithValue.Value, secretWithValue.Name);
                }
            }
            #endregion

            #region Snippet:SecretsSample3ListSecretVersions
            string newBankSecretPassword = "sskdjfsdasdjsd";

            IEnumerable<SecretProperties> secretVersions = client.GetPropertiesOfSecretVersions(bankSecretName);
            foreach (SecretProperties secret in secretVersions)
            {
                // Secret versions may also be disabled if compromised and new versions generated, so skip disabled versions, too.
                if (!secret.Enabled.GetValueOrDefault())
                {
                    continue;
                }

                KeyVaultSecret oldBankSecret = client.GetSecret(secret.Name, secret.Version);
                if (newBankSecretPassword == oldBankSecret.Value)
                {
                    Debug.WriteLine($"Secret {secret.Name} reuses a password");
                }
            }

            client.SetSecret(bankSecretName, newBankSecretPassword);
            #endregion

            #region Snippet:SecretsSample3DeleteSecrets
            DeleteSecretOperation bankSecretOperation = client.StartDeleteSecret(bankSecretName);
            DeleteSecretOperation storageSecretOperation = client.StartDeleteSecret(storageSecretName);

            // You only need to wait for completion if you want to purge or recover the secret.
            while (!bankSecretOperation.HasCompleted || !storageSecretOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                bankSecretOperation.UpdateStatus();
                storageSecretOperation.UpdateStatus();
            }
            #endregion

            #region Snippet:SecretsSample3ListDeletedSecrets
            IEnumerable<DeletedSecret> secretsDeleted = client.GetDeletedSecrets();
            foreach (DeletedSecret secret in secretsDeleted)
            {
                Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
            }
            #endregion

            // If the Key Vault is soft delete-enabled, then for permanent deletion, deleted secret needs to be purged.
            client.PurgeDeletedSecret(bankSecretName);
            client.PurgeDeletedSecret(storageSecretName);
        }
    }
}
