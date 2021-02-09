// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMScenarioTests : VMTestBase
    {
        public VMScenarioTests(bool isAsync)
            : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        //[Trait("Name", "TestVMScenarioOperations")]
        public async Task TestVMScenarioOperations()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations");
        }
        /// <summary>
        /// Covers following Operations for managed disks:
        /// Create RG
        /// Create Network Resources
        /// Create VM with WriteAccelerator enabled OS and Data disk
        /// GET VM Model View
        /// GET VM InstanceView
        /// GETVMs in a RG
        /// List VMSizes in a RG
        /// List VMSizes in an AvailabilitySet
        /// Delete RG
        ///
        /// To record this test case, you need to run it in region which support XMF VMSizeFamily like eastus2.
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScenarioOperations_ManagedDisks")]
        public async Task TestVMScenarioOperations_ManagedDisks()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks", vmSize: VirtualMachineSizeTypes.StandardM64S.ToString(), hasManagedDisks: true,
                osDiskStorageAccountType: StorageAccountTypes.PremiumLRS.ToString(), dataDiskStorageAccountType: StorageAccountTypes.PremiumLRS.ToString(), writeAcceleratorEnabled: true);
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support local diff disks.
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScenarioOperations_DiffDisks")]
        public async Task TestVMScenarioOperations_DiffDisks()
        {
            EnsureClientsInitialized(LocationNorthEurope);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_DiffDisks", vmSize: VirtualMachineSizeTypes.StandardDS148V2.ToString(), hasManagedDisks: true,
               hasDiffDisks: true, osDiskStorageAccountType: StorageAccountTypes.StandardLRS.ToString());
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support DiskEncryptionSet resource for the Disks
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet")]
        public async Task TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet()
        {
            EnsureClientsInitialized(DefaultLocation);
            string diskEncryptionSetId = getDefaultDiskEncryptionSetId();
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet", vmSize: VirtualMachineSizeTypes.StandardA1V2.ToString(), hasManagedDisks: true,
               osDiskStorageAccountType: StorageAccountTypes.StandardLRS.ToString(), diskEncryptionSetId: diskEncryptionSetId);
        }

        /// <summary>
        /// TODO: StandardSSD is currently in preview and is available only in a few regions. Once it goes GA, it can be tested in
        /// the default test location.
        /// </summary>
        [Test]
        ////[Trait("Name", "TestVMScenarioOperations_ManagedDisks_StandardSSD")]
        public async Task TestVMScenarioOperations_ManagedDisks_StandardSSD()
        {
            EnsureClientsInitialized(LocationNorthEurope);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_StandardSSD", hasManagedDisks: true,
                osDiskStorageAccountType: StorageAccountTypes.StandardSSDLRS.ToString(), dataDiskStorageAccountType: StorageAccountTypes.StandardSSDLRS.ToString());
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2.
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record because of the incorrect subscriptionid")]
        //[Trait("Name", "TestVMScenarioOperations_ManagedDisks_PirImage_Zones")]
        public async Task TestVMScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            EnsureClientsInitialized(LocationCentralUs);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_PirImage_Zones", hasManagedDisks: true, zones: new List<string> { "1" }, callUpdateVM: true);
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2euap.
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScenarioOperations_ManagedDisks_UltraSSD")]
        public async Task TestVMScenarioOperations_ManagedDisks_UltraSSD()
        {
            EnsureClientsInitialized(LocationEastUs2);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_UltraSSD", hasManagedDisks: true, zones: new List<string> { "1" },
                vmSize: VirtualMachineSizeTypes.StandardE16SV3.ToString(), osDiskStorageAccountType: StorageAccountTypes.PremiumLRS.ToString(),
                dataDiskStorageAccountType: StorageAccountTypes.UltraSSDLRS.ToString(), callUpdateVM: true);
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2euap.
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record because of the incorrect subscriptionid")]
        //[Trait("Name", "TestVMScenarioOperations_PpgScenario")]
        public async Task TestVMScenarioOperations_PpgScenario()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScenarioOperationsInternal("TestVMScenarioOperations_PpgScenario", hasManagedDisks: true, isPpgScenario: true);
        }

        private async Task TestVMScenarioOperationsInternal(string methodName, bool hasManagedDisks = false, IList<string> zones = null, string vmSize = "Standard_A0",
            string osDiskStorageAccountType = "Standard_LRS", string dataDiskStorageAccountType = "Standard_LRS", bool? writeAcceleratorEnabled = null,
            bool hasDiffDisks = false, bool callUpdateVM = false, bool isPpgScenario = false, string diskEncryptionSetId = null)
        {
            var imageRef = await GetPlatformVMImage(useWindowsImage: true);
            const string expectedOSName = "Windows Server 2012 R2 Datacenter", expectedOSVersion = "Microsoft Windows NT 6.3.9600.0", expectedComputerName = ComputerName;
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            string ppgName = null;
            string expectedPpgReferenceId = null;

            if (isPpgScenario)
            {
                ppgName = Recording.GenerateAssetName("ppgtest");
                expectedPpgReferenceId = Helpers.GetProximityPlacementGroupRef(m_subId, rgName, ppgName);
            }

            VirtualMachine inputVM;
            if (!hasManagedDisks)
            {
                await CreateStorageAccount(rgName, storageAccountName);
            }

            var returnTwoVM = await CreateVM(rgName, asName, storageAccountName, imageRef, hasManagedDisks: hasManagedDisks, hasDiffDisks: hasDiffDisks, vmSize: vmSize, osDiskStorageAccountType: osDiskStorageAccountType,
                dataDiskStorageAccountType: dataDiskStorageAccountType, writeAcceleratorEnabled: writeAcceleratorEnabled, zones: zones, ppgName: ppgName, diskEncryptionSetId: diskEncryptionSetId);
            //VirtualMachine outVM = returnTwoVM.Item1;
            inputVM = returnTwoVM.Item2;
            string inputVMName = returnTwoVM.Item3;
            // Instance view is not completely populated just after VM is provisioned. So we wait here for a few minutes to
            // allow GA blob to populate.
            WaitMinutes(5);

            var getVMWithInstanceViewResponse = (await VirtualMachinesOperations.GetAsync(rgName, inputVMName)).Value;
            Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");

            if (diskEncryptionSetId != null)
            {
                Assert.True(getVMWithInstanceViewResponse.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet != null, "OsDisk.ManagedDisk.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getVMWithInstanceViewResponse.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "OsDisk.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");

                Assert.AreEqual(1, getVMWithInstanceViewResponse.StorageProfile.DataDisks.Count);
                Assert.True(getVMWithInstanceViewResponse.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet != null, ".DataDisks.ManagedDisk.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getVMWithInstanceViewResponse.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "DataDisks.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
            }

            ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion);

            var getVMInstanceViewResponse = await VirtualMachinesOperations.InstanceViewAsync(rgName, inputVMName);
            Assert.True(getVMInstanceViewResponse != null, "VM in InstanceView");
            ValidateVMInstanceView(inputVM, getVMInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion);

            bool hasUserDefinedAS = zones == null;

            string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVMName);
            var listResponse = await (VirtualMachinesOperations.ListAsync(rgName)).ToEnumerableAsync();
            ValidateVM(inputVM, listResponse.FirstOrDefault(x => x.Name == inputVMName),
                expectedVMReferenceId, hasManagedDisks, hasUserDefinedAS, writeAcceleratorEnabled, hasDiffDisks, expectedPpgReferenceId: expectedPpgReferenceId);

            var listVMSizesResponse = await (VirtualMachinesOperations.ListAvailableSizesAsync(rgName, inputVMName)).ToEnumerableAsync();
            Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled, hasDiffDisks: hasDiffDisks);

            listVMSizesResponse = await (AvailabilitySetsOperations.ListAvailableSizesAsync(rgName, asName)).ToEnumerableAsync();
            Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled, hasDiffDisks: hasDiffDisks);

            if (isPpgScenario)
            {
                ProximityPlacementGroup outProximityPlacementGroup = await ProximityPlacementGroupsOperations.GetAsync(rgName, ppgName);
                string expectedAvSetReferenceId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asName);
                Assert.AreEqual(1, outProximityPlacementGroup.VirtualMachines.Count);
                Assert.AreEqual(1, outProximityPlacementGroup.AvailabilitySets.Count);
                Assert.AreEqual(expectedVMReferenceId, outProximityPlacementGroup.VirtualMachines.First().Id);
                Assert.AreEqual(expectedAvSetReferenceId, outProximityPlacementGroup.AvailabilitySets.First().Id);
                //Assert.Equal(expectedVMReferenceId, outProximityPlacementGroup.VirtualMachines.First().Id, StringComparer.OrdinalIgnoreCase);
                //Assert.Equal(expectedAvSetReferenceId, outProximityPlacementGroup.AvailabilitySets.First().Id, StringComparer.OrdinalIgnoreCase);
            }

            if (callUpdateVM)
            {
                VirtualMachineUpdate updateParams = new VirtualMachineUpdate();
                updateParams.Tags.InitializeFrom(inputVM.Tags);

                string updateKey = "UpdateTag";
                updateParams.Tags.Add(updateKey, "UpdateTagValue");
                VirtualMachine updateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartUpdateAsync(rgName, inputVMName, updateParams));

                Assert.True(updateResponse.Tags.ContainsKey(updateKey));
            }
        }
    }
}
