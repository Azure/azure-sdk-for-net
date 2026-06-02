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
    /// This sample demonstrates how to register an external key in an EKM-connected Managed HSM,
    /// get it, delete it, and then purge it using the asynchronous methods of <see cref="KeyClient"/>.
    /// </summary>
    public partial class CreateExternalKeySample
    {
        [Test]
        public async Task CreateExternalKeyAsync()
        {
            TestEnvironment.AssertManagedHsm();

            string managedHsmUrl = TestEnvironment.ManagedHsmUrl;
            string externalId = TestEnvironment.EkmExternalId;
            if (string.IsNullOrEmpty(externalId))
            {
                throw new IgnoreException(
                    "No external key ID provided. This sample requires an EKM-connected Managed HSM " +
                    "and an existing external key referenced by the EKM_EXTERNAL_ID environment variable.");
            }

            // Instantiate a key client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());

            // Register a Managed HSM key whose material is held in the connected external HSM by passing the
            // external key identifier through an ExternalKey reference.
            string externalKeyName = $"ExternalKey-{Guid.NewGuid()}";
            ExternalKey externalKey = new ExternalKey(externalId);

            KeyVaultKey createdKey = await client.CreateExternalKeyAsync(externalKeyName, externalKey);
            Debug.WriteLine($"External key created with name {createdKey.Name} referencing external id {createdKey.Properties.ExternalKey.Id}");

            // Get the external key back from Managed HSM and confirm the external_key reference round-trips.
            KeyVaultKey fetchedKey = await client.GetKeyAsync(externalKeyName);
            Debug.WriteLine($"Fetched external key {fetchedKey.Name} still references external id {fetchedKey.Properties.ExternalKey.Id}");

            // The external key reference is no longer needed; delete it from Managed HSM.
            DeleteKeyOperation operation = await client.StartDeleteKeyAsync(externalKeyName);

            #region Snippet:KeysSample9PurgeExternalKeyAsync
            // You only need to wait for completion if you want to purge or recover the key.
            await operation.WaitForCompletionAsync();

            await client.PurgeDeletedKeyAsync(externalKeyName);
            #endregion
        }
    }
}
