// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to set, get, update and delete a key using the synchronous methods of the KeyClient.
    /// </summary>
    [LiveOnly]
    public partial class HelloWorld
    {
        [Test]
        public void HelloWorldSync()
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
            var rsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 2048)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(rsaKey);

            // Let's Get the Cloud RSA Key from the Key Vault.
            Key cloudRsaKey = client.GetKey(rsaKeyName);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyMaterial.KeyType}");

            // After one year, the Cloud RSA Key is still required, we need to update the expiry time of the key.
            // The update method can be used to update the expiry attribute of the key.
            cloudRsaKey.Properties.Expires.Value.AddYears(1);
            Key updatedKey = client.UpdateKeyProperties(cloudRsaKey.Properties, cloudRsaKey.KeyMaterial.KeyOps);
            Debug.WriteLine($"Key's updated expiry time is {updatedKey.Properties.Expires}");

            // We need the Cloud RSA key with bigger key size, so you want to update the key in Key Vault to ensure
            // it has the required size.
            // Calling CreateRsaKey on an existing key creates a new version of the key in the Key Vault
            // with the new specified size.
            var newRsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 4096)
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(newRsaKey);

            // The Cloud RSA Key is no longer needed, need to delete it from the Key Vault.
            client.DeleteKey(rsaKeyName);

            // To ensure key is deleted on server side.
            Assert.IsTrue(WaitForDeletedKey(client, rsaKeyName));

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            client.PurgeDeletedKey(rsaKeyName);

        }

        private bool WaitForDeletedKey(KeyClient client, string keyName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    client.GetDeletedKey(keyName);
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
