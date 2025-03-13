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
using System.Reflection;
using System.ClientModel.Primitives;
using System.Threading;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class ReplicationExtensionCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public ReplicationExtensionCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task TestReplicationExtensionCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            VaultModelResource vault = await rg.GetVaultModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);

            var replicationExtdata = new ReplicationExtensionModelData
            {
                Properties = new Models.ReplicationExtensionModelProperties
                {
                    CustomProperties = new Models.VMwareToAzStackHCIReplicationExtensionModelCustomProperties
                    {
                        VmwareFabricArmId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultSourceApplianceId,
                        AzStackHciFabricArmId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultTargetApplianceId,
                        StorageAccountId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultStorageAccountId,
                        StorageAccountSasSecretName = string.Empty,
                        InstanceType = "VMwareToAzStackHCI"
                    }
                }
            };

            // Create
            var createReplicationExtOperation = await vault.GetReplicationExtensionModels().CreateOrUpdateAsync(
                WaitUntil.Completed,
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultReplicationExtensionName,
                replicationExtdata);

            Assert.IsTrue(createReplicationExtOperation.HasCompleted);
            Assert.IsTrue(createReplicationExtOperation.HasValue);

            // Get
            var getReplicationExtOperation = await vault.GetReplicationExtensionModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultReplicationExtensionName);
            var relicationExtModelResource = getReplicationExtOperation.Value;

            Assert.IsNotNull(relicationExtModelResource);

            // Delete
            var deleteReplicationExtOperation = await relicationExtModelResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteReplicationExtOperation.HasCompleted);
        }
    }
}
