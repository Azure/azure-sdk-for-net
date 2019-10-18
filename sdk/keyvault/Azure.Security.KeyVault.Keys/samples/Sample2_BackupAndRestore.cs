// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to backup and restore keys in the Key Vault
    /// using the synchronous methods of the KeyClient.
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

            // Instantiate a key client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a RSA key valid for 1 year. If the key
            // already exists in the Key Vault, then a new version of the key is created.
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            KeyVaultKey storedKey = client.CreateRsaKey(rsaKey);

            // Backups are good to have if in case keys get accidentally deleted by you.
            // For long term storage, it is ideal to write the backup to a file, disk, database, etc.
            // For the purposes of this sample, we are storing the bakup in a temporary memory area.
            byte[] backupKey = client.BackupKey(rsaKeyName);

            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(backupKey, 0, backupKey.Length);

                // The storage account key is no longer in use, so you delete it.
                DeleteKeyOperation operation = client.StartDeleteKey(rsaKeyName);

                // To ensure the key is deleted on server before we try to purge it.
                while (!operation.HasCompleted)
                {
                    Thread.Sleep(2000);

                    operation.UpdateStatus();
                }

                // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
                client.PurgeDeletedKey(rsaKeyName);

                // After sometime, the key is required again. We can use the backup value to restore it in the Key Vault.
                KeyVaultKey restoredKey = client.RestoreKeyBackup(memoryStream.ToArray());

                AssertKeysEqual(storedKey.Properties, restoredKey.Properties);
            }
        }

        private void AssertKeysEqual(KeyProperties exp, KeyProperties act)
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
