// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
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
        public void KeyRotationSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample8KeyClient
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample8CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
            Debug.WriteLine($"{cloudRsaKey.KeyType} key is returned with name {cloudRsaKey.Name} and version {cloudRsaKey.Properties.Version}");
            #endregion

            #region Snippet:KeysSample8UpdateRotationPolicy
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

            keyClient.UpdateKeyRotationPolicy(rsaKeyName, policy);
            #endregion

            #region Snippet:KeysSample8RotateKey
            KeyVaultKey newRsaKey = keyClient.RotateKey(rsaKeyName);
            Debug.WriteLine($"Rotated key {newRsaKey.Name} with version {newRsaKey.Properties.Version}");
            #endregion

            DeleteKeyOperation operation = keyClient.StartDeleteKey(rsaKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
        }
    }
}
