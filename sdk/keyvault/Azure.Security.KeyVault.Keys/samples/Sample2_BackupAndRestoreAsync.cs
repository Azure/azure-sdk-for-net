// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to backup and restore keys in the key vault
    /// using the asynchronous methods of the KeyClient.
    /// </summary>
    [Category("Live")]
    public partial class BackupAndRestore
    {
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public async Task BackupAndRestoreAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");
            string backupPath = Path.GetTempFileName();

            // Instantiate a key client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a Rsa key valid for 1 year. If the key
            // already exists in the key vault, then a new version of the key is created.
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 2048)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            Key storedKey = await client.CreateRsaKeyAsync(rsaKey);

            // Backups are good to have if in case keys get accidentally deleted by you.
            // For long term storage, it is ideal to write the backup to a file.
            using (FileStream sourceStream = File.Open(backupPath, FileMode.OpenOrCreate))
            {
                byte[] byteKey = await client.BackupKeyAsync(rsaKeyName);
                sourceStream.Seek(0, SeekOrigin.End);
                await sourceStream.WriteAsync(byteKey, 0, byteKey.Length);
            }

            // The storage account key is no longer in use, so you delete it.
            await client.DeleteKeyAsync(rsaKeyName);

            // To ensure the key is deleted on server side.
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, rsaKeyName));

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            await client.PurgeDeletedKeyAsync(rsaKeyName);

            // After sometime, the key is required again. We can use the backup value to restore it in the key vault.
            KeyBase restoredKey = null;
            using (FileStream sourceStream = File.Open(backupPath, FileMode.Open))
            {
                byte[] result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
                restoredKey = await client.RestoreKeyAsync(result);
            }

            AssertKeysEqual((KeyBase)storedKey, restoredKey);
        }

        private async Task<bool> WaitForDeletedKeyAsync(KeyClient client, string keyName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    await client.GetDeletedKeyAsync(keyName);
                    return true;
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
            return false;
        }
    }
}
