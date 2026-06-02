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
    /// This sample demonstrates how to register an external key in an EKM-connected Managed HSM,
    /// get it, delete it, and then purge it using the synchronous methods of <see cref="KeyClient"/>.
    /// </summary>
    public partial class CreateExternalKeySample
    {
        [Test]
        public void CreateExternalKeySync()
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

            #region Snippet:KeysSample9KeyClient
            var client = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample9CreateExternalKey
            string externalKeyName = $"ExternalKey-{Guid.NewGuid()}";
            ExternalKey externalKey = new ExternalKey(externalId);

            KeyVaultKey createdKey = client.CreateExternalKey(externalKeyName, externalKey);
            Debug.WriteLine($"External key created with name {createdKey.Name} referencing external id {createdKey.Properties.ExternalKey.Id}");
            #endregion

            #region Snippet:KeysSample9GetExternalKey
            KeyVaultKey fetchedKey = client.GetKey(externalKeyName);
            Debug.WriteLine($"Fetched external key {fetchedKey.Name} still references external id {fetchedKey.Properties.ExternalKey.Id}");
            #endregion

            #region Snippet:KeysSample9DeleteExternalKey
            DeleteKeyOperation operation = client.StartDeleteKey(externalKeyName);
            #endregion

            #region Snippet:KeysSample9PurgeExternalKey
            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            client.PurgeDeletedKey(externalKeyName);
            #endregion
        }
    }
}
