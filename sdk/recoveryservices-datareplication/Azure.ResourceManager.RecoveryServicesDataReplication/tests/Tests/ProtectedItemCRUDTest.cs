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
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            DataReplicationVaultResource vault = await rg.GetDataReplicationVaults().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);

            var disk = new Models.VMwareToAzStackHciDiskInput
            {
                DiskFileFormat = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemDiskFileFormat,
                DiskSizeGB = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemDiskSizeInGB,
                DiskId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemDiskId,
                IsDynamic = true,
                IsOSDisk = true
            };

            var nic = new Models.VMwareToAzStackHciNicInput
            {
                NicId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemNicId,
                TargetNetworkId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetNetworkId,
                TestNetworkId = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetNetworkId,
                SelectionTypeForFailover = Models.VmNicSelection.SelectedByUser
            };

            var customeProperties = new Models.VMwareToAzStackHciProtectedItemModelCustomProperties
               (
                   targetHciClusterId: new ResourceIdentifier(RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetHciClusterId),
                   targetArcClusterCustomLocationId: new ResourceIdentifier(RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetArcClusterCustomLocationId),
                   storageContainerId: new ResourceIdentifier(RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemStorageContainerId),
                   targetResourceGroupId: new ResourceIdentifier(RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetResourceGroupId),
                   customLocationRegion: RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemCustomLocationRegion,
                   disksToInclude: new List<Models.VMwareToAzStackHciDiskInput> { disk },
                   nicsToInclude: new List<Models.VMwareToAzStackHciNicInput> { nic },
                   hyperVGeneration: RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemHyperVGeneration,
                   fabricDiscoveryMachineId: new ResourceIdentifier(RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemFabricDiscoveryMachineId),
                   runAsAccountId: RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemRunAsAccountId,
                   sourceFabricAgentName: RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemSourceFabricAgentName,
                   targetFabricAgentName: RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetFabricAgentName
               );

            customeProperties.InstanceType = "VMwareToAzStackHCI";
            customeProperties.TargetVmName = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetVMName;
            customeProperties.TargetCpuCores = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetCpuCore;
            customeProperties.IsDynamicRam = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemIsDynamicRam;
            customeProperties.TargetMemoryInMegaBytes = RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemTargetMemoryInMegaByte;
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
                    PolicyName = RecoveryServicesDataReplicationManagementTestUtilities.DefaultPolicyName,
                    ReplicationExtensionName = RecoveryServicesDataReplicationManagementTestUtilities.DefaultReplicationExtensionName,
                    CustomProperties = customeProperties
                }
            };

            // Create
            var createProtectedItemOperation = await vault.GetDataReplicationProtectedItems().CreateOrUpdateAsync(
                WaitUntil.Completed,
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemName,
                protectedItemData);
            Assert.IsTrue(createProtectedItemOperation.HasCompleted);
            Assert.IsTrue(createProtectedItemOperation.HasValue);

            // Get
            var getProtectedItemOperation = await vault.GetDataReplicationProtectedItems().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemName);
            var protecteItemModelResource = getProtectedItemOperation.Value;
            Assert.IsNotNull(protecteItemModelResource);

            bool canDelete = protecteItemModelResource.Data.Properties.AllowedJobs.Contains("DisableProtection");
            for (int i = 0; i < RecoveryServicesDataReplicationManagementTestUtilities.RetryCount; i++)
            {
                // check if resource is ready for delete operation
                if (canDelete)
                {
                    break;
                }

                // sleep for 15 seconds
                Thread.Sleep(RecoveryServicesDataReplicationManagementTestUtilities.ThreadSleepTime);

                getProtectedItemOperation = await vault.GetDataReplicationProtectedItems().GetAsync(
                         RecoveryServicesDataReplicationManagementTestUtilities.DefaultProtectedItemName);
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
