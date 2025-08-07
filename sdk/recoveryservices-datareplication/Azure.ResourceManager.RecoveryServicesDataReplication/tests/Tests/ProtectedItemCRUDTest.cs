// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class ProtectedItemCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public ProtectedItemCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestProtectedItemCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            DataReplicationVaultResource vault = await rg.GetDataReplicationVaults().GetAsync(
                DataReplicationTestUtilities.DefaultVaultName);

            var disk = new Models.HyperVToAzStackHciDiskInput
            {
                DiskFileFormat = DataReplicationTestUtilities.DefaultProtectedItemDiskFileFormat,
                DiskSizeGB = DataReplicationTestUtilities.DefaultProtectedItemDiskSizeInGB,
                DiskId = DataReplicationTestUtilities.DefaultProtectedItemDiskId,
                IsDynamic = true,
                IsOSDisk = true
            };

            var nic = new Models.HyperVToAzStackHciNicInput
            {
                NicId = DataReplicationTestUtilities.DefaultProtectedItemNicId,
                TargetNetworkId = DataReplicationTestUtilities.DefaultProtectedItemTargetNetworkId,
                TestNetworkId = DataReplicationTestUtilities.DefaultProtectedItemTargetNetworkId,
                SelectionTypeForFailover = Models.VmNicSelection.SelectedByUser
            };

            var customeProperties = new Models.HyperVToAzStackHciProtectedItemCustomProperties
               (
                   targetHciClusterId: new ResourceIdentifier(DataReplicationTestUtilities.DefaultProtectedItemTargetHciClusterId),
                   targetArcClusterCustomLocationId: new ResourceIdentifier(DataReplicationTestUtilities.DefaultProtectedItemTargetArcClusterCustomLocationId),
                   storageContainerId: new ResourceIdentifier(DataReplicationTestUtilities.DefaultProtectedItemStorageContainerId),
                   targetResourceGroupId: new ResourceIdentifier(DataReplicationTestUtilities.DefaultProtectedItemTargetResourceGroupId),
                   customLocationRegion: DataReplicationTestUtilities.DefaultProtectedItemCustomLocationRegion,
                   disksToInclude: new List<Models.HyperVToAzStackHciDiskInput> { disk },
                   nicsToInclude: new List<Models.HyperVToAzStackHciNicInput> { nic },
                   hyperVGeneration: DataReplicationTestUtilities.DefaultProtectedItemHyperVGeneration,
                   fabricDiscoveryMachineId: new ResourceIdentifier(DataReplicationTestUtilities.DefaultProtectedItemFabricDiscoveryMachineId),
                   runAsAccountId: DataReplicationTestUtilities.DefaultProtectedItemRunAsAccountId,
                   sourceFabricAgentName: DataReplicationTestUtilities.DefaultProtectedItemSourceFabricAgentName,
                   targetFabricAgentName: DataReplicationTestUtilities.DefaultProtectedItemTargetFabricAgentName
               );

            customeProperties.InstanceType = DataReplicationTestUtilities.HyperVToAzStackHCI;
            customeProperties.TargetVmName = DataReplicationTestUtilities.DefaultProtectedItemTargetVMName;
            customeProperties.TargetCpuCores = DataReplicationTestUtilities.DefaultProtectedItemTargetCpuCore;
            customeProperties.IsDynamicRam = DataReplicationTestUtilities.DefaultProtectedItemIsDynamicRam;
            customeProperties.TargetMemoryInMegaBytes = DataReplicationTestUtilities.DefaultProtectedItemTargetMemoryInMegaByte;
            customeProperties.DynamicMemoryConfig = new Models.ProtectedItemDynamicMemoryConfig
            {
                MaximumMemoryInMegaBytes = 1048576,
                MinimumMemoryInMegaBytes = 1024,
                TargetMemoryBufferPercentage = 20
            };

            var protectedItemData = new DataReplicationProtectedItemData
            {
                Properties = new Models.DataReplicationProtectedItemProperties
                {
                    PolicyName = DataReplicationTestUtilities.DefaultPolicyName,
                    ReplicationExtensionName = DataReplicationTestUtilities.DefaultReplicationExtensionName,
                    CustomProperties = customeProperties
                }
            };

            // Create
            var createProtectedItemOperation = await vault.GetDataReplicationProtectedItems().CreateOrUpdateAsync(
                WaitUntil.Completed,
                DataReplicationTestUtilities.DefaultProtectedItemName,
                protectedItemData);
            Assert.IsTrue(createProtectedItemOperation.HasCompleted);
            Assert.IsTrue(createProtectedItemOperation.HasValue);

            // Get
            var getProtectedItemOperation = await vault.GetDataReplicationProtectedItems().GetAsync(
                DataReplicationTestUtilities.DefaultProtectedItemName);
            var protecteItemModelResource = getProtectedItemOperation.Value;
            Assert.IsNotNull(protecteItemModelResource);

            bool canDelete = protecteItemModelResource.Data.Properties.AllowedJobs.Contains("DisableProtection");
            for (int i = 0; i < DataReplicationTestUtilities.RetryCount; i++)
            {
                // check if resource is ready for delete operation
                if (canDelete)
                {
                    break;
                }

                Thread.Sleep(DataReplicationTestUtilities.ThreadSleepTime);

                getProtectedItemOperation = await vault.GetDataReplicationProtectedItems().GetAsync(
                         DataReplicationTestUtilities.DefaultProtectedItemName);
                protecteItemModelResource = getProtectedItemOperation.Value;
                canDelete = protecteItemModelResource.Data.Properties.AllowedJobs.Contains("DisableProtection");
            }

            if (canDelete)
            {
                // Delete
                var deleteProtectedItemOperation = await protecteItemModelResource.DeleteAsync(
                    WaitUntil.Completed,
                    forceDelete: true);

                Assert.IsTrue(deleteProtectedItemOperation.HasCompleted);
            }
        }
    }
}
