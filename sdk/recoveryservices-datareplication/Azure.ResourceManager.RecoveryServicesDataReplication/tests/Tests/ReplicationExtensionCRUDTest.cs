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

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class ReplicationExtensionCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public ReplicationExtensionCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestReplicationExtensionCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            DataReplicationVaultResource vault = await rg.GetDataReplicationVaults().GetAsync(
                DataReplicationTestUtilities.DefaultVaultName);

            var replicationExtdata = new DataReplicationExtensionData
            {
                Properties = new Models.DataReplicationExtensionProperties
                {
                    CustomProperties = new Models.HyperVToAzStackHciReplicationExtensionCustomProperties
                    {
                        HyperVFabricArmId = new ResourceIdentifier(DataReplicationTestUtilities.DefaultSourceFabricId),
                        AzStackHciFabricArmId = new ResourceIdentifier(DataReplicationTestUtilities.DefaultTargetFabricId),
                        StorageAccountId = DataReplicationTestUtilities.DefaultStorageAccountId,
                        StorageAccountSasSecretName = string.Empty,
                        InstanceType = DataReplicationTestUtilities.HyperVToAzStackHCI
                    }
                }
            };

            // Create
            var createReplicationExtOperation = await vault.GetDataReplicationExtensions().CreateOrUpdateAsync(
                WaitUntil.Completed,
                DataReplicationTestUtilities.DefaultReplicationExtensionName,
                replicationExtdata);

            Assert.IsTrue(createReplicationExtOperation.HasCompleted);
            Assert.IsTrue(createReplicationExtOperation.HasValue);

            // Get
            var getReplicationExtOperation = await vault.GetDataReplicationExtensions().GetAsync(
                DataReplicationTestUtilities.DefaultReplicationExtensionName);
            var relicationExtModelResource = getReplicationExtOperation.Value;

            Assert.IsNotNull(relicationExtModelResource);

            // Delete
            var deleteReplicationExtOperation = await relicationExtModelResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteReplicationExtOperation.HasCompleted);
        }
    }
}
