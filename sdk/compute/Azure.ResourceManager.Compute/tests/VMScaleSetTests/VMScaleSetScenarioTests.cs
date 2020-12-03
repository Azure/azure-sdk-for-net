// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetScenarioTests : VMScaleSetVMTestsBase
    {
        public VMScaleSetScenarioTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetScenarioOperations")]
        public async Task TestVMScaleSetScenarioOperations()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestScaleSetOperationsInternal();
        }

        /// <summary>
        /// Covers following Operations for ManagedDisks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks")]
        public async Task TestVMScaleSetScenarioOperations_ManagedDisks_PirImage()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestScaleSetOperationsInternal(hasManagedDisks: true, useVmssExtension: false);
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone")]
        public async Task TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone()
        {
            EnsureClientsInitialized(LocationCentralUs);
            await TestScaleSetOperationsInternal(hasManagedDisks: true, useVmssExtension: false, zones: new List<string> { "1" });
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support local diff disks.
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_DiffDisks")]
        public async Task TestVMScaleSetScenarioOperations_DiffDisks()
        {
            EnsureClientsInitialized(LocationNorthEurope);
            await TestScaleSetOperationsInternal(vmSize: VirtualMachineSizeTypes.StandardDS5V2.ToString(), hasManagedDisks: true,
                hasDiffDisks: true);
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support DiskEncryptionSet resource for the Disks
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_With_DiskEncryptionSet")]
        public async Task TestVMScaleSetScenarioOperations_With_DiskEncryptionSet()
        {
            EnsureClientsInitialized(LocationCentralUsEuap);
            string diskEncryptionSetId = getDefaultDiskEncryptionSetId();

            await TestScaleSetOperationsInternal(vmSize: VirtualMachineSizeTypes.StandardA1V2.ToString(), hasManagedDisks: true, osDiskSizeInGB: 175, diskEncryptionSetId: diskEncryptionSetId);
        }

        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_UltraSSD")]
        public async Task TestVMScaleSetScenarioOperations_UltraSSD()
        {
            EnsureClientsInitialized(LocationEastUs2);
            await TestScaleSetOperationsInternal(vmSize: VirtualMachineSizeTypes.StandardE4SV3.ToString(), hasManagedDisks: true,
                    useVmssExtension: false, zones: new List<string> { "1" }, enableUltraSSD: true, osDiskSizeInGB: 175);
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones")]
        public async Task TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            EnsureClientsInitialized(LocationCentralUs);
            await TestScaleSetOperationsInternal(
                hasManagedDisks: true,
                useVmssExtension: false,
                zones: new List<string> { "1", "3" },
                osDiskSizeInGB: 175);
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_PpgScenario")]
        public async Task TestVMScaleSetScenarioOperations_PpgScenario()
        {
            EnsureClientsInitialized(LocationEastUs2);
            await TestScaleSetOperationsInternal(hasManagedDisks: true, useVmssExtension: false, isPpgScenario: true);
        }

        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_ScheduledEvents")]
        public async Task TestVMScaleSetScenarioOperations_ScheduledEvents()
        {
            EnsureClientsInitialized(LocationEastUs2);
            await TestScaleSetOperationsInternal(hasManagedDisks: true, useVmssExtension: false,
                vmScaleSetCustomizer:
                vmScaleSet =>
                {
                    vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile = new ScheduledEventsProfile
                    {
                        TerminateNotificationProfile = new TerminateNotificationProfile
                        {
                            Enable = true,
                            NotBeforeTimeout = "PT6M",
                        }
                    };
                },
                vmScaleSetValidator: vmScaleSet =>
                {
                    Assert.True(true == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.TerminateNotificationProfile?.Enable);
                    Assert.True("PT6M" == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.TerminateNotificationProfile?.NotBeforeTimeout);
                });
        }

        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest")]
        public async Task TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest()
        {
            EnsureClientsInitialized(LocationEastUs2);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            // Set Automatic Repairs to true
            inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
            {
                Enabled = true
            };
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            // Update Automatic Repairs default values
            inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
            {
                Enabled = true,

                GracePeriod = "PT35M"
            };
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            // Set automatic repairs to null
            inputVMScaleSet.AutomaticRepairsPolicy = null;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
            Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == true);

            Assert.AreEqual("PT35M", getResponse.AutomaticRepairsPolicy.GracePeriod);

            // Disable Automatic Repairs
            inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
            {
                Enabled = false
            };
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
            Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == false);
        }

        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_OrchestrationService")]
        public async Task TestVMScaleSetScenarioOperations_OrchestrationService()
        {
            EnsureClientsInitialized(LocationNorthEurope);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            AutomaticRepairsPolicy automaticRepairsPolicy = new AutomaticRepairsPolicy()
            {
                Enabled = true
            };
            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true,
                automaticRepairsPolicy: automaticRepairsPolicy);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
            var getInstanceViewResponse = (await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName)).Value;

            Assert.True(getInstanceViewResponse.OrchestrationServices.Count == 1);
            Assert.AreEqual("Running", getInstanceViewResponse.OrchestrationServices[0].ServiceState.ToString());
            Assert.AreEqual("AutomaticRepairs", getInstanceViewResponse.OrchestrationServices[0].ServiceName.ToString());

            ////TODO
            OrchestrationServiceStateInput orchestrationServiceStateInput = new OrchestrationServiceStateInput(OrchestrationServiceNames.AutomaticRepairs, OrchestrationServiceStateAction.Suspend);
            //OrchestrationServiceStateAction orchestrationServiceStateAction = new OrchestrationServiceStateAction();
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartSetOrchestrationServiceStateAsync(rgName, vmssName, orchestrationServiceStateInput));

            getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.AreEqual(OrchestrationServiceState.Suspended.ToString(), getInstanceViewResponse.OrchestrationServices[0].ServiceState.ToString());

            orchestrationServiceStateInput = new OrchestrationServiceStateInput(OrchestrationServiceNames.AutomaticRepairs, OrchestrationServiceStateAction.Resume);
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartSetOrchestrationServiceStateAsync(rgName, vmssName, orchestrationServiceStateInput));
            getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.AreEqual(OrchestrationServiceState.Running.ToString(), getInstanceViewResponse.OrchestrationServices[0].ServiceState.ToString());

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmssName));
        }

        private async Task TestScaleSetOperationsInternal(string vmSize = null, bool hasManagedDisks = false, bool useVmssExtension = true,
            bool hasDiffDisks = false, IList<string> zones = null, int? osDiskSizeInGB = null, bool isPpgScenario = false, bool? enableUltraSSD = false,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null, Action<VirtualMachineScaleSet> vmScaleSetValidator = null, string diskEncryptionSetId = null)
        {
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = {
                    GetTestVMSSVMExtension(),
                }
            };
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));
            string ppgId = null;
            string ppgName = null;
            if (isPpgScenario)
            {
                ppgName = Recording.GenerateAssetName("ppgtest");
                ppgId = await CreateProximityPlacementGroup(rgName, ppgName);
            }

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                useVmssExtension ? extensionProfile : null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = true;
                    if (!String.IsNullOrEmpty(vmSize))
                    {
                        vmScaleSet.Sku.Name = vmSize;
                    }
                    vmScaleSetCustomizer?.Invoke(vmScaleSet);
                },
                createWithManagedDisks: hasManagedDisks,
                hasDiffDisks: hasDiffDisks,
                zones: zones,
                osDiskSizeInGB: osDiskSizeInGB,
                ppgId: ppgId,
                enableUltraSSD: enableUltraSSD,
                diskEncryptionSetId: diskEncryptionSetId);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            if (diskEncryptionSetId != null)
            {
                Assert.True(getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet != null, "OsDisk.ManagedDisk.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "OsDisk.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");

                Assert.AreEqual(1, getResponse.VirtualMachineProfile.StorageProfile.DataDisks.Count);
                Assert.True(getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet != null, ".DataDisks.ManagedDisk.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "DataDisks.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
            }

            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks, ppgId: ppgId);

            var getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.NotNull(getInstanceViewResponse);
            ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

            if (isPpgScenario)
            {
                ProximityPlacementGroup outProximityPlacementGroup = await ProximityPlacementGroupsOperations.GetAsync(rgName, ppgName);
                Assert.AreEqual(1, outProximityPlacementGroup.VirtualMachineScaleSets.Count);
                string expectedVmssReferenceId = Helpers.GetVMScaleSetReferenceId(m_subId, rgName, vmssName);
                Assert.AreEqual(expectedVmssReferenceId.ToLower(), outProximityPlacementGroup.VirtualMachineScaleSets.First().Id.ToLower());
            }

            var listResponse = await (VirtualMachineScaleSetsOperations.ListAsync(rgName)).ToEnumerableAsync();
            ValidateVMScaleSet(inputVMScaleSet, listResponse.FirstOrDefault(x => x.Name == vmssName), hasManagedDisks);

            var listSkusResponse = await (VirtualMachineScaleSetsOperations.ListSkusAsync(rgName, vmssName)).ToEnumerableAsync();
            Assert.NotNull(listSkusResponse);
            Assert.False(listSkusResponse.Count() == 0);

            if (zones != null)
            {
                var query = "properties/latestModelApplied eq true";
                var listVMsResponse = await (VirtualMachineScaleSetVMsOperations.ListAsync(rgName, vmssName, query)).ToEnumerableAsync();
                Assert.False(listVMsResponse == null, "VMScaleSetVMs not returned");
                Assert.True(listVMsResponse.Count() == inputVMScaleSet.Sku.Capacity);

                foreach (var vmScaleSetVM in listVMsResponse)
                {
                    string instanceId = vmScaleSetVM.InstanceId;
                    var getVMResponse = await VirtualMachineScaleSetVMsOperations.GetAsync(rgName, vmssName, instanceId);
                    ValidateVMScaleSetVM(inputVMScaleSet, instanceId, getVMResponse, hasManagedDisks);
                }
            }

            vmScaleSetValidator?.Invoke(getResponse);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmssName));
        }
    }
}
