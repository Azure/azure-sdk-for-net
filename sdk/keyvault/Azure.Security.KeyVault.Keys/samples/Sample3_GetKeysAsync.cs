﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to list keys and versions of a given key,
    /// and list deleted keys in a soft-delete enabled Key Vault
    /// using the asynchronous methods of the KeyClient.
    /// </summary>
    [Category("Live")]
    public partial class GetKeys
    {
        [Test]
        public async Task GetKeysAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a key client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create EC and RSA keys valid for 1 year. If the key
            // already exists in the Key Vault, then a new version of the key is created.
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 2048)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateRsaKeyAsync(rsaKey);

            string ecKeyName = $"CloudECKey-{Guid.NewGuid()}";
            var ecKey = new EcKeyCreateOptions(ecKeyName, hsm: false)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateEcKeyAsync(ecKey);

            // You need to check the type of keys that already exist in your Key Vault.
            // Let's list the keys and print their types.
            // List operations don't return the keys with key material information.
            // So, for each returned key we call GetKey to get the key with its key material information.
            await foreach (KeyBase key in client.GetKeysAsync())
            {
                Key keyWithType = await client.GetKeyAsync(key.Name);
                Debug.WriteLine($"Key is returned with name {keyWithType.Name} and type {keyWithType.KeyMaterial.KeyType}");
            }

            // We need the Cloud RSA key with bigger key size, so you want to update the key in Key Vault to ensure
            // it has the required size.
            // Calling CreateRsaKey on an existing key creates a new version of the key in the Key Vault 
            // with the new specified size.
            var newRsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 4096)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateRsaKeyAsync(newRsaKey);

            // You need to check all the different versions Cloud RSA key had previously.
            // Lets print all the versions of this key.
            await foreach (KeyBase key in client.GetKeyVersionsAsync(rsaKeyName))
            {
                Debug.WriteLine($"Key's version {key.Version} with name {key.Name}");
            }

            // The Cloud RSA Key and the Cloud EC Key are no longer needed. 
            // You need to delete them from the Key Vault.
            await client.DeleteKeyAsync(rsaKeyName);
            await client.DeleteKeyAsync(ecKeyName);

            // To ensure secrets are deleted on server side.
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, rsaKeyName));
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, ecKeyName));

            // You can list all the deleted and non-purged keys, assuming Key Vault is soft-delete enabled.
            await foreach (DeletedKey key in client.GetDeletedKeysAsync())
            {
                Debug.WriteLine($"Deleted key's recovery Id {key.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            await client.PurgeDeletedKeyAsync(rsaKeyName);
            await client.PurgeDeletedKeyAsync(ecKeyName);
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
                    await Task.Delay(5000);
                }
            }
            return false;
        }
    }
}
