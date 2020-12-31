// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to list keys and versions of a given key,
    /// and list deleted keys in a soft-delete enabled Key Vault
    /// using the synchronous methods of the KeyClient.
    /// </summary>
    public partial class GetKeys
    {
        [Test]
        public void GetKeysSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample3KeyClient
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample3CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(rsaKey);

            string ecKeyName = $"CloudECKey-{Guid.NewGuid()}";
            var ecKey = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
            {
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateEcKey(ecKey);
            #endregion

            #region Snippet:KeysSample3ListKeys
            IEnumerable<KeyProperties> keys = client.GetPropertiesOfKeys();
            foreach (KeyProperties key in keys)
            {
                /*@@*/ if (key.Managed) continue;
                KeyVaultKey keyWithType = client.GetKey(key.Name);
                Debug.WriteLine($"Key is returned with name {keyWithType.Name} and type {keyWithType.KeyType}");
            }
            #endregion

            #region Snippet:KeysSample3UpdateKey
            var newRsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 4096,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(newRsaKey);
            #endregion

            #region Snippet:KeysSample3ListKeyVersions
            IEnumerable<KeyProperties> keysVersions = client.GetPropertiesOfKeyVersions(rsaKeyName);
            foreach (KeyProperties key in keysVersions)
            {
                Debug.WriteLine($"Key's version {key.Version} with name {key.Name}");
            }
            #endregion

            #region Snippet:KeysSample3DeletedKeys
            DeleteKeyOperation rsaKeyOperation = client.StartDeleteKey(rsaKeyName);
            DeleteKeyOperation ecKeyOperation = client.StartDeleteKey(ecKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!rsaKeyOperation.HasCompleted || !ecKeyOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                rsaKeyOperation.UpdateStatus();
                ecKeyOperation.UpdateStatus();
            }
            #endregion

            #region Snippet:KeysSample3ListDeletedKeys
            IEnumerable<DeletedKey> keysDeleted = client.GetDeletedKeys();
            foreach (DeletedKey key in keysDeleted)
            {
                Debug.WriteLine($"Deleted key's recovery Id {key.RecoveryId}");
            }
            #endregion

            // You only need to wait for completion if you want to purge or recover the key.
            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            client.PurgeDeletedKey(rsaKeyName);
            client.PurgeDeletedKey(ecKeyName);
        }
    }
}
