// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class VaultCRUDTest: RecoveryServicesDataReplicationManagementTestBase
    {
        public VaultCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task GetVaultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            DataReplicationVaultResource resource = await rg.GetDataReplicationVaults().GetAsync(
                DataReplicationTestUtilities.DefaultVaultName);
            Assert.That(resource, Is.Not.Null);
        }

        [TestCase]
        public async Task TestVaultCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            // Create
            DataReplicationVaultData vaultData = new DataReplicationVaultData(
                new AzureLocation(DataReplicationTestUtilities.DeafultLocation))
            {
                Properties = new Models.DataReplicationVaultProperties
                {
                    VaultType = Models.DataReplicationVaultType.Migrate,
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Tags =
                    {
                         ["Migrate Project"] = "sdkTest1-prj"
                    },
            };

            var vaultName = $"vault{IsAsync.ToString()}12";

            var vaultCreateOperation = await rg.GetDataReplicationVaults().CreateOrUpdateAsync(
                WaitUntil.Completed,
                vaultName,
                vaultData);

            Assert.That(vaultCreateOperation.HasCompleted, Is.True);
            Assert.That(vaultCreateOperation.HasValue, Is.True);

            // Get
            DataReplicationVaultResource resource = await rg.GetDataReplicationVaults().GetAsync(
                 vaultName);
            Assert.That(resource, Is.Not.Null);

            // Delete
            var deleteVaultOperation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleteVaultOperation.HasCompleted, Is.True);
        }
    }
}
