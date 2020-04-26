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
    /// Sample demonstrates how to set, get, update, and delete a key using the asynchronous methods of the KeyClient.
    /// </summary>
    public partial class HelloWorld
    {
        [Test]
        public async Task HelloWorldAsync()
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

            await client.CreateRsaKeyAsync(rsaKey);

            // Let's Get the Cloud RSA Key from the Key Vault.
            KeyVaultKey cloudRsaKey = await client.GetKeyAsync(rsaKeyName);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");

            // After one year, the Cloud RSA Key is still required, we need to update the expiry time of the key.
            // The update method can be used to update the expiry attribute of the key.
            cloudRsaKey.Properties.ExpiresOn.Value.AddYears(1);
            KeyVaultKey updatedKey = await client.UpdateKeyPropertiesAsync(cloudRsaKey.Properties, cloudRsaKey.KeyOperations);
            Debug.WriteLine($"Key's updated expiry time is {updatedKey.Properties.ExpiresOn}");

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

            // The Cloud RSA Key is no longer needed, need to delete it from the Key Vault.
            DeleteKeyOperation operation = await client.StartDeleteKeyAsync(rsaKeyName);

            #region Snippet:KeysSample1PurgeKeyAsync
            // You only need to wait for completion if you want to purge or recover the key.
            await operation.WaitForCompletionAsync();

            await client.PurgeDeletedKeyAsync(rsaKeyName);
            #endregion
        }
    }
}
