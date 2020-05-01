// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// This sample demonstrates how to create, get, update, and delete a secret in Azure Key Vault using synchronous methods of <see cref="KeyClient"/>.
    /// </summary>
    public partial class HelloWorld
    {
        [Test]
        public void HelloWorldSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample1KeyClient
            var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample1CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(rsaKey);
            #endregion

            #region Snippet:KeysSample1GetKey
            KeyVaultKey cloudRsaKey = client.GetKey(rsaKeyName);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
            #endregion

            #region Snippet:KeysSample1UpdateKeyProperties
            cloudRsaKey.Properties.ExpiresOn.Value.AddYears(1);
            KeyVaultKey updatedKey = client.UpdateKeyProperties(cloudRsaKey.Properties, cloudRsaKey.KeyOperations);
            Debug.WriteLine($"Key's updated expiry time is {updatedKey.Properties.ExpiresOn}");
            #endregion

            #region Snippet:KeysSample1UpdateKey
            var newRsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 4096,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            client.CreateRsaKey(newRsaKey);
            #endregion

            #region Snippet:KeysSample1DeleteKey
            DeleteKeyOperation operation = client.StartDeleteKey(rsaKeyName);
            #endregion

            #region Snippet:KeysSample1PurgeKey
            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            client.PurgeDeletedKey(rsaKeyName);
            #endregion
        }
    }
}
