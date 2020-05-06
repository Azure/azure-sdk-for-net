// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to backup and restore keys in the Key Vault
    /// using the asynchronous methods of the KeyClient.
    /// </summary>
    public partial class BackupAndRestore
    {
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public async Task BackupAndRestoreAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

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

            KeyVaultKey storedKey = await client.CreateRsaKeyAsync(rsaKey);

            // You might make backups in case keys get accidentally deleted.
            // For long term storage, it is ideal to write the backup to a file, disk, database, etc.
            // For the purposes of this sample, we are storing the back up in a temporary memory area.
            byte[] byteKey = await client.BackupKeyAsync(rsaKeyName);

            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteKey, 0, byteKey.Length);

                // The storage account key is no longer in use, so you delete it.
                DeleteKeyOperation operation = await client.StartDeleteKeyAsync(rsaKeyName);

                // To ensure the key is deleted on server before we try to purge it.
                await operation.WaitForCompletionAsync();

                // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
                await client.PurgeDeletedKeyAsync(rsaKeyName);

                // After sometime, the key is required again. We can use the backup value to restore it in the Key Vault.
                KeyVaultKey restoredKey = await client.RestoreKeyBackupAsync(memoryStream.ToArray());

                AssertKeysEqual(storedKey.Properties, restoredKey.Properties);

                // Delete and purge the restored key.
                operation = await client.StartDeleteKeyAsync(rsaKeyName);

                // You only need to wait for completion if you want to purge or recover the key.
                await operation.WaitForCompletionAsync();

                await client.PurgeDeletedKeyAsync(rsaKeyName);
            }
        }
    }
}
