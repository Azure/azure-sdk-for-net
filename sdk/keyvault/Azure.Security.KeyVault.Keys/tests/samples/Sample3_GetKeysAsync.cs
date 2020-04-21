// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to list keys and versions of a given key,
    /// and list deleted keys in a soft-delete enabled Key Vault
    /// using the asynchronous methods of the KeyClient.
    /// </summary>
    public partial class GetKeys
    {
        [Test]
        public async Task GetKeysAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            // Instantiate a key client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create EC and RSA keys valid for 1 year. If the key
            // already exists in the Key Vault, then a new version of the key is created.
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateRsaKeyAsync(rsaKey);

            string ecKeyName = $"CloudECKey-{Guid.NewGuid()}";
            var ecKey = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
            {
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateEcKeyAsync(ecKey);

            // You need to check the type of keys that already exist in your Key Vault.
            // Let's list the keys and print their types.
            // List operations don't return the actual key, but only properties of the key.
            // So, for each returned key we call GetKey to get the actual key.
            await foreach (KeyProperties key in client.GetPropertiesOfKeysAsync())
            {
                /*@@*/ if (key.Managed) continue;
                KeyVaultKey keyWithType = await client.GetKeyAsync(key.Name);
                Debug.WriteLine($"Key is returned with name {keyWithType.Name} and type {keyWithType.KeyType}");
            }

            // We need the Cloud RSA key with bigger key size, so you want to update the key in Key Vault to ensure
            // it has the required size.
            // Calling CreateRsaKey on an existing key creates a new version of the key in the Key Vault
            // with the new specified size.
            var newRsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 4096,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            await client.CreateRsaKeyAsync(newRsaKey);

            // You need to check all the different versions Cloud RSA key had previously.
            // Lets print all the versions of this key.
            await foreach (KeyProperties key in client.GetPropertiesOfKeyVersionsAsync(rsaKeyName))
            {
                Debug.WriteLine($"Key's version {key.Version} with name {key.Name}");
            }

            // The Cloud RSA Key and the Cloud EC Key are no longer needed.
            // You need to delete them from the Key Vault.
            DeleteKeyOperation rsaKeyOperation = await client.StartDeleteKeyAsync(rsaKeyName);
            DeleteKeyOperation ecKeyOperation = await client.StartDeleteKeyAsync(ecKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            await Task.WhenAll(
                rsaKeyOperation.WaitForCompletionAsync().AsTask(),
                ecKeyOperation.WaitForCompletionAsync().AsTask());

            // You can list all the deleted and non-purged keys, assuming Key Vault is soft-delete enabled.
            await foreach (DeletedKey key in client.GetDeletedKeysAsync())
            {
                Debug.WriteLine($"Deleted key's recovery Id {key.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            await Task.WhenAll(
                client.PurgeDeletedKeyAsync(rsaKeyName),
                client.PurgeDeletedKeyAsync(ecKeyName));
        }
    }
}
