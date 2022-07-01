// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample that shows how to update a <see cref="KeyRotationPolicy"/> and manually rotate a <see cref="KeyVaultKey"/>.
    /// </summary>
    public partial class Sample8_KeyRotation
    {
        [Test]
        [KeyVaultOnly]
        public async Task KeyRotationAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = await keyClient.CreateRsaKeyAsync(rsaKey);
            Debug.WriteLine($"{cloudRsaKey.KeyType} key is returned with name {cloudRsaKey.Name} and version {cloudRsaKey.Properties.Version}");

            KeyRotationPolicy policy = new KeyRotationPolicy()
            {
                ExpiresIn = "P90D",
                LifetimeActions =
                {
                    new KeyRotationLifetimeAction(KeyRotationPolicyAction.Rotate)
                    {
                        TimeBeforeExpiry = "P30D"
                    }
                }
            };

            await keyClient.UpdateKeyRotationPolicyAsync(rsaKeyName, policy);

            KeyVaultKey newRsaKey = await keyClient.RotateKeyAsync(rsaKeyName);
            Debug.WriteLine($"Rotated key {newRsaKey.Name} with version {newRsaKey.Properties.Version}");

            DeleteKeyOperation operation = await keyClient.StartDeleteKeyAsync(rsaKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            await operation.WaitForCompletionAsync();

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
        }
    }
}
