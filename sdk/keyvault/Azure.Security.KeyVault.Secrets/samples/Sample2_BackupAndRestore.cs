// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Sample demonstrates how to backup and restore secrets in the key vault
    /// using the synchronous methods of the SecretClient.
    /// </summary>
    [LiveOnly]
    public partial class BackupAndRestore
    {
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public void BackupAndRestoreSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");
            string backupPath = Path.GetTempFileName();

            // Instantiate a secret client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a secret holding bank account credentials valid for 1 year. if the secret
            // already exists in the key vault, then a new version of the secret is created.
            string secretName = $"StorageAccountPasswor{Guid.NewGuid()}";

            var secret = new KeyVaultSecret(secretName, "f4G34fMh8v")
            {
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddYears(1)
                }
            };

            KeyVaultSecret storedSecret = client.SetSecret(secret);

            // Backups are good to have if in case secrets get accidentally deleted by you.
            // For long term storage, it is ideal to write the backup to a file.
            File.WriteAllBytes(backupPath, client.BackupSecret(secretName));

            // The storage account secret is no longer in use, so you delete it.
            DeleteSecretOperation operation = client.StartDeleteSecret(secretName);

            // To ensure the secret is deleted on server before we try to purge it.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted secret needs to be purged.
            client.PurgeDeletedSecret(secretName);

            // After sometime, the secret is required again. We can use the backup value to restore it in the key vault.
            SecretProperties restoreSecret = client.RestoreSecretBackup(File.ReadAllBytes(backupPath));

            AssertSecretsEqual(storedSecret.Properties, restoreSecret);
        }

        private void AssertSecretsEqual(SecretProperties exp, SecretProperties act)
        {
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Version, act.Version);
            Assert.AreEqual(exp.Managed, act.Managed);
            Assert.AreEqual(exp.RecoveryLevel, act.RecoveryLevel);
            Assert.AreEqual(exp.ExpiresOn, act.ExpiresOn);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
        }
    }
}
