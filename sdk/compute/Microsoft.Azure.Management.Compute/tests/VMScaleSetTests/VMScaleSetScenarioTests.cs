// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetScenarioTests : VMScaleSetVMTestsBase
    {
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
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations")]
        public void TestVMScaleSetScenarioOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestScaleSetOperationsInternal(context);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, zones: new List<string> { "1" });
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support local diff disks.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_DiffDisks")]
        public void TestVMScaleSetScenarioOperations_DiffDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "northeurope");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardDS5V2, hasManagedDisks: true,
                        hasDiffDisks: true);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support DiskEncryptionSet resource for the Disks
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_With_DiskEncryptionSet")]
        public void TestVMScaleSetScenarioOperations_With_DiskEncryptionSet()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                string diskEncryptionSetId = getDefaultDiskEncryptionSetId();

                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centraluseuap");

                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardA1V2, hasManagedDisks: true, osDiskSizeInGB: 175, diskEncryptionSetId: diskEncryptionSetId);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_UltraSSD")]
        public void TestVMScaleSetScenarioOperations_UltraSSD()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardE4sV3, hasManagedDisks: true,
                        useVmssExtension: false, zones: new List<string> { "1" }, enableUltraSSD: true, osDiskSizeInGB: 175);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(
                        context, 
                        hasManagedDisks: true, 
                        useVmssExtension: false, 
                        zones: new List<string> { "1", "3" }, 
                        osDiskSizeInGB: 175);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_PpgScenario")]
        public void TestVMScaleSetScenarioOperations_PpgScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, isPpgScenario: true);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ScheduledEvents")]
        public void TestVMScaleSetScenarioOperations_ScheduledEvents()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false,
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
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest")]
        public void TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest()
        {
            string environmentVariable = "AZURE_VM_TEST_LOCATION";
            string region = "centraluseuap";
            string originalTestLocation = Environment.GetEnvironmentVariable(environmentVariable);

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    Environment.SetEnvironmentVariable(environmentVariable, region);
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    // Create resource group
                    var rgName = TestUtilities.GenerateName(TestPrefix);
                    var vmssName = TestUtilities.GenerateName("vmss");
                    string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                    VirtualMachineScaleSet inputVMScaleSet;

                    try
                    {
                        var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                        m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                        var getResponse = CreateVMScaleSet_NoAsyncTracking(
                            rgName,
                            vmssName,
                            storageAccountOutput,
                            imageRef,
                            out inputVMScaleSet,
                            null,
                            (vmScaleSet) =>
                            {
                                vmScaleSet.Overprovision = false;
                            },
                            createWithManagedDisks: true,
                            createWithPublicIpAddress: false,
                            createWithHealthProbe: true);

                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Set Automatic Repairs to true 
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = true
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Update Automatic Repairs default values 
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = true,

                            GracePeriod = "PT35M"
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Set automatic repairs to null 
                        inputVMScaleSet.AutomaticRepairsPolicy = null;
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == true);

                        Assert.Equal("PT35M", getResponse.AutomaticRepairsPolicy.GracePeriod, ignoreCase: true);

                        // Disable Automatic Repairs
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = false
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == false);
                    }
                    finally
                    {
                        //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                        //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                        m_ResourcesClient.ResourceGroups.Delete(rgName);
                    }
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }


        private void TestScaleSetOperationsInternal(MockContext context, string vmSize = null, bool hasManagedDisks = false, bool useVmssExtension = true, 
            bool hasDiffDisks = false, IList<string> zones = null, int? osDiskSizeInGB = null, bool isPpgScenario = false, bool? enableUltraSSD = false, 
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null, Action<VirtualMachineScaleSet> vmScaleSetValidator = null, string diskEncryptionSetId = null)
        {
            EnsureClientsInitialized(context);

            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = TestUtilities.GenerateName(TestPrefix);
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetTestVMSSVMExtension(),
                }
            };

            try
            {
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                string ppgId = null;
                string ppgName = null;
                if (isPpgScenario)
                {
                    ppgName = ComputeManagementTestUtilities.GenerateName("ppgtest");
                    ppgId = CreateProximityPlacementGroup(rgName, ppgName);
                }

                VirtualMachineScaleSet getResponse = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    useVmssExtension ? extensionProfile : null,
                    (vmScaleSet) => {
                        vmScaleSet.Overprovision = true;
                        if (!String.IsNullOrEmpty(vmSize))
                        {
                            vmScaleSet.Sku.Name = vmSize;
                        }
                        vmScaleSetCustomizer?.Invoke(vmScaleSet);
                    },
                    createWithManagedDisks: hasManagedDisks,
                    hasDiffDisks : hasDiffDisks,
                    zones: zones,
                    osDiskSizeInGB: osDiskSizeInGB,
                    ppgId: ppgId,
                    enableUltraSSD: enableUltraSSD,
                    diskEncryptionSetId: diskEncryptionSetId);

                if (diskEncryptionSetId != null)
                {
                    Assert.True(getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet != null, "OsDisk.ManagedDisk.DiskEncryptionSet is null");
                    Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                        "OsDisk.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");

                    Assert.Equal(1, getResponse.VirtualMachineProfile.StorageProfile.DataDisks.Count);
                    Assert.True(getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet != null, ".DataDisks.ManagedDisk.DiskEncryptionSet is null");
                    Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                        "DataDisks.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
                }

                ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks, ppgId: ppgId);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                Assert.NotNull(getInstanceViewResponse);
                ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                if (isPpgScenario)
                {
                    ProximityPlacementGroup outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(rgName, ppgName);
                    Assert.Equal(1, outProximityPlacementGroup.VirtualMachineScaleSets.Count);
                    string expectedVmssReferenceId = Helpers.GetVMScaleSetReferenceId(m_subId, rgName, vmssName);
                    Assert.Equal(expectedVmssReferenceId, outProximityPlacementGroup.VirtualMachineScaleSets.First().Id, StringComparer.OrdinalIgnoreCase);
                }

                var listResponse = m_CrpClient.VirtualMachineScaleSets.List(rgName);
                ValidateVMScaleSet(inputVMScaleSet, listResponse.FirstOrDefault(x => x.Name == vmssName), hasManagedDisks);

                var listSkusResponse = m_CrpClient.VirtualMachineScaleSets.ListSkus(rgName, vmssName);
                Assert.NotNull(listSkusResponse);
                Assert.False(listSkusResponse.Count() == 0);

                if (zones != null)
                {
                    var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                    query.SetFilter(vm => vm.LatestModelApplied == true);
                    var listVMsResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query);
                    Assert.False(listVMsResponse == null, "VMScaleSetVMs not returned");
                    Assert.True(listVMsResponse.Count() == inputVMScaleSet.Sku.Capacity);

                    foreach (var vmScaleSetVM in listVMsResponse)
                    {
                        string instanceId = vmScaleSetVM.InstanceId;
                        var getVMResponse = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmssName, instanceId);
                        ValidateVMScaleSetVM(inputVMScaleSet, instanceId, getVMResponse, hasManagedDisks);
                    }
                }

                vmScaleSetValidator?.Invoke(getResponse);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
            }
            finally
            {
                //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}

