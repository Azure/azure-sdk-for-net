// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Compute.Tests
{
    public class VMScenarioTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// GET VM InstanceView
        /// GETVMs in a RG
        /// List VMSizes in a RG
        /// List VMSizes in an AvailabilitySet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations")]
        public void TestVMScenarioOperations()
        {
            TestVMScenarioOperationsInternal("TestVMScenarioOperations");
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
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks")]
        public void TestVMScenarioOperations_ManagedDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks", vmSize: VirtualMachineSizeTypes.StandardM64s, hasManagedDisks: true,
                    osDiskStorageAccountType: StorageAccountTypes.PremiumLRS, dataDiskStorageAccountType: StorageAccountTypes.PremiumLRS, writeAcceleratorEnabled: true, validateListAvailableSize: false);
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
        [Trait("Name", "TestVMScenarioOperations_DiffDisks")]
        public void TestVMScenarioOperations_DiffDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "northeurope");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_DiffDisks", vmSize: VirtualMachineSizeTypes.StandardDS148V2, hasManagedDisks: true,
                   hasDiffDisks: true, osDiskStorageAccountType: StorageAccountTypes.StandardLRS);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support Encryption at host
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_EncryptionAtHost")]
        public void TestVMScenarioOperations_EncryptionAtHost()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "northeurope");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_EncryptionAtHost", vmSize: VirtualMachineSizeTypes.StandardD2sV3, hasManagedDisks: true,
                    osDiskStorageAccountType: StorageAccountTypes.StandardLRS, encryptionAtHostEnabled: true);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }
        
        /// <summary>
        /// To record this test case, you need to run it in region which support Encryption at host
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_TrustedLaunch")]
        public void TestVMScenarioOperations_TrustedLaunch()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                ImageReference image = new ImageReference(publisher: "MICROSOFTWINDOWSDESKTOP", offer: "WINDOWS-10", version: "latest", sku: "20H2-ENT-G2");
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_TrustedLaunch", vmSize: VirtualMachineSizeTypes.StandardD2sV3, hasManagedDisks: true,
                    osDiskStorageAccountType: StorageAccountTypes.StandardSSDLRS, securityType: "TrustedLaunch", imageReference: image, validateListAvailableSize: false);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support ConfidentialVM
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ConfidentialVM")]
        public void TestVMScenarioOperations_ConfidentialVM()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                ImageReference image = new ImageReference(publisher: "MICROSOFTWINDOWSSERVER", offer: "WINDOWS-CVM", version: "20348.230.2109130355", sku: "2022-DATACENTER-CVM");
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "northeurope");
                VMDiskSecurityProfile diskSecurityProfile = new VMDiskSecurityProfile(securityEncryptionType: "VMGuestStateOnly");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ConfidentialVM", vmSize: "Standard_DC2as_v5", hasManagedDisks: true,
                    osDiskStorageAccountType: StorageAccountTypes.PremiumLRS, securityType: "ConfidentialVM", imageReference: image, validateListAvailableSize: false, diskSecurityProfile: diskSecurityProfile);
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
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet")]
        public void TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

            string diskEncryptionSetId = getDefaultDiskEncryptionSetId();
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_DiskEncryptionSet", vmSize: VirtualMachineSizeTypes.StandardA1V2, hasManagedDisks: true,
                   osDiskStorageAccountType: StorageAccountTypes.StandardLRS, diskEncryptionSetId: diskEncryptionSetId);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// TODO: StandardSSD is currently in preview and is available only in a few regions. Once it goes GA, it can be tested in 
        /// the default test location.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks_StandardSSD")]
        public void TestVMScenarioOperations_ManagedDisks_StandardSSD()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "northeurope");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_StandardSSD", hasManagedDisks: true,
                    osDiskStorageAccountType: StorageAccountTypes.StandardSSDLRS, dataDiskStorageAccountType: StorageAccountTypes.StandardSSDLRS);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks_PirImage_Zones")]
        public void TestVMScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_PirImage_Zones", hasManagedDisks: true, zones: new List<string> { "1" }, callUpdateVM: true);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks_UltraSSD")]
        public void TestVMScenarioOperations_ManagedDisks_UltraSSD()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_UltraSSD", hasManagedDisks: true, zones: new List<string> { "1" }, 
                    vmSize: VirtualMachineSizeTypes.StandardE16sV3, osDiskStorageAccountType: StorageAccountTypes.PremiumLRS, 
                    dataDiskStorageAccountType: StorageAccountTypes.UltraSSDLRS, callUpdateVM: true);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScenarioOperations_AutomaticPlacementOnDedicatedHostGroup")]
        public void TestVMScenarioOperations_AutomaticPlacementOnDedicatedHostGroup()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                // This test was recorded in WestUSValidation, where the platform image typically used for recording is not available.
                // Hence the following custom image was used.
                //ImageReference imageReference = new ImageReference
                //{
                //    Publisher = "AzureRT.PIRCore.TestWAStage",
                //    Offer = "TestUbuntuServer",
                //    Sku = "16.04",
                //    Version = "latest"
                //};
                //TestVMScenarioOperationsInternal("TestVMScenarioOperations_AutomaticPlacementOnDedicatedHostGroup",
                //    hasManagedDisks: true, vmSize: VirtualMachineSizeTypes.StandardD2sV3, isAutomaticPlacementOnDedicatedHostGroupScenario: true,
                //    imageReference: imageReference, validateListAvailableSize: false);
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_AutomaticPlacementOnDedicatedHostGroup",
                    hasManagedDisks: true, vmSize: VirtualMachineSizeTypes.StandardD2sV3, isAutomaticPlacementOnDedicatedHostGroupScenario: true,
                    validateListAvailableSize: false);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScenarioOperations_UsingCapacityReservationGroup")]
        public void TestVMScenarioOperations_UsingCapacityReservationGroup()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_UsingCapacityReservationGroup",
                    hasManagedDisks: true, vmSize: VirtualMachineSizeTypes.StandardDS1V2, associateWithCapacityReservation: true);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_PpgScenario")]
        public void TestVMScenarioOperations_PpgScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_PpgScenario", hasManagedDisks: true, isPpgScenario: true, validateListAvailableSize: false);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        private void TestVMScenarioOperationsInternal(string methodName, bool hasManagedDisks = false, IList<string> zones = null, string vmSize = "Standard_A1_v2",
            string osDiskStorageAccountType = "Standard_LRS", string dataDiskStorageAccountType = "Standard_LRS", bool? writeAcceleratorEnabled = null,
            bool hasDiffDisks = false, bool callUpdateVM = false, bool isPpgScenario = false, string diskEncryptionSetId = null, bool? encryptionAtHostEnabled = null,
            string securityType = null, bool isAutomaticPlacementOnDedicatedHostGroupScenario = false, ImageReference imageReference = null, bool validateListAvailableSize = true,
            bool associateWithCapacityReservation = false, VMDiskSecurityProfile diskSecurityProfile = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = imageReference ?? GetPlatformVMImage(useWindowsImage: true);
                const string expectedOSName = "Windows Server 2012 R2 Datacenter", expectedOSVersion = "Microsoft Windows NT 6.3.9600.0", expectedComputerName = ComputerName;
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string ppgName = null, expectedPpgReferenceId = null;
                string dedicatedHostGroupName = null, dedicatedHostName = null, dedicatedHostGroupReferenceId = null, dedicatedHostReferenceId = null;
                string capacityReservationGroupName = null, capacityReservationGroupReferenceId = null, capacityReservationName = null;

                if (isPpgScenario)
                {
                    ppgName = ComputeManagementTestUtilities.GenerateName("ppgtest");
                    expectedPpgReferenceId = Helpers.GetProximityPlacementGroupRef(m_subId, rgName, ppgName);
                }

                if (isAutomaticPlacementOnDedicatedHostGroupScenario)
                {
                    dedicatedHostGroupName = ComputeManagementTestUtilities.GenerateName("dhgtest");
                    dedicatedHostName = ComputeManagementTestUtilities.GenerateName("dhtest");
                    dedicatedHostGroupReferenceId = Helpers.GetDedicatedHostGroupRef(m_subId, rgName, dedicatedHostGroupName);
                    dedicatedHostReferenceId = Helpers.GetDedicatedHostRef(m_subId, rgName, dedicatedHostGroupName, dedicatedHostName);
                }

                if (associateWithCapacityReservation)
                {
                    capacityReservationGroupName = ComputeManagementTestUtilities.GenerateName("crgtest");
                    capacityReservationName = ComputeManagementTestUtilities.GenerateName("crtest");
                    CreateCapacityReservationGroup(rgName, capacityReservationGroupName);
                    CreateCapacityReservation(rgName, capacityReservationGroupName, capacityReservationName, VirtualMachineSizeTypes.StandardDS1V2, reservedCount: 1);
                    capacityReservationGroupReferenceId = Helpers.GetCapacityReservationGroupRef(m_subId, rgName, capacityReservationGroupName);
                }

                VirtualMachine inputVM;
                try
                {
                    if (!hasManagedDisks)
                    {
                        CreateStorageAccount(rgName, storageAccountName);
                    }

                    CreateVM(rgName, asName, storageAccountName, imageRef, out inputVM, hasManagedDisks: hasManagedDisks,hasDiffDisks: hasDiffDisks, vmSize: vmSize, osDiskStorageAccountType: osDiskStorageAccountType,
                        dataDiskStorageAccountType: dataDiskStorageAccountType, writeAcceleratorEnabled: writeAcceleratorEnabled, zones: zones, ppgName: ppgName, 
                        diskEncryptionSetId: diskEncryptionSetId, encryptionAtHostEnabled: encryptionAtHostEnabled, securityType: securityType, dedicatedHostGroupReferenceId: dedicatedHostGroupReferenceId,
                        dedicatedHostGroupName: dedicatedHostGroupName, dedicatedHostName: dedicatedHostName, capacityReservationGroupReferenceId: capacityReservationGroupReferenceId,
                        diskSecurityProfile: diskSecurityProfile);

                    // Instance view is not completely populated just after VM is provisioned. So we wait here for a few minutes to 
                    // allow GA blob to populate.
                    ComputeManagementTestUtilities.WaitMinutes(5);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    if (diskEncryptionSetId != null)
                    {

                        Assert.True(getVMWithInstanceViewResponse.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet != null, "OsDisk.ManagedDisk.DiskEncryptionSet is null");
                        Assert.True(string.Equals(diskEncryptionSetId, getVMWithInstanceViewResponse.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                            "OsDisk.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");

                        Assert.Equal(1, getVMWithInstanceViewResponse.StorageProfile.DataDisks.Count);
                        Assert.True(getVMWithInstanceViewResponse.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet != null, ".DataDisks.ManagedDisk.DiskEncryptionSet is null");
                        Assert.True(string.Equals(diskEncryptionSetId, getVMWithInstanceViewResponse.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                            "DataDisks.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
                    }

                    if (associateWithCapacityReservation)
                    {
                        Assert.True(getVMWithInstanceViewResponse.CapacityReservation.CapacityReservationGroup != null, "CapacityReservation.CapacityReservationGroup is null");
                        Assert.True(string.Equals(capacityReservationGroupReferenceId, getVMWithInstanceViewResponse.CapacityReservation.CapacityReservationGroup.Id, StringComparison.OrdinalIgnoreCase),
                            "CapacityReservation.CapacityReservationGroup.Id is not matching with expected CapacityReservationGroup resource");

                        CapacityReservation capacityReservation =
                             m_CrpClient.CapacityReservations.Get(rgName, capacityReservationGroupName, capacityReservationName, CapacityReservationInstanceViewTypes.InstanceView);

                        Assert.True(capacityReservation.VirtualMachinesAssociated.Any(), "capacityReservation.VirtualMachinesAssociated is not empty");
                        Assert.True(string.Equals(expectedVMReferenceId, capacityReservation.VirtualMachinesAssociated.First().Id, StringComparison.OrdinalIgnoreCase), "capacityReservation.VirtualMachinesAssociated are not matching");

                        Assert.True(capacityReservation.InstanceView.UtilizationInfo.VirtualMachinesAllocated.Any(), "InstanceView.UtilizationInfo.VirtualMachinesAllocated is empty");
                        Assert.True(string.Equals(expectedVMReferenceId, capacityReservation.InstanceView.UtilizationInfo.VirtualMachinesAllocated.First().Id, StringComparison.OrdinalIgnoreCase),
                            "InstanceView.UtilizationInfo.VirtualMachinesAllocated are not matching");
                    }

                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion, dedicatedHostReferenceId);

                    var getVMInstanceViewResponse = m_CrpClient.VirtualMachines.InstanceView(rgName, inputVM.Name);
                    Assert.True(getVMInstanceViewResponse != null, "VM in InstanceView");
                    ValidateVMInstanceView(inputVM, getVMInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion, dedicatedHostReferenceId);

                    bool hasUserDefinedAS = inputVM.AvailabilitySet != null;

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    ValidateVM(inputVM, listResponse.FirstOrDefault(x => x.Name == inputVM.Name),
                        expectedVMReferenceId, hasManagedDisks, hasUserDefinedAS, writeAcceleratorEnabled, hasDiffDisks, expectedPpgReferenceId: expectedPpgReferenceId,
                        encryptionAtHostEnabled: encryptionAtHostEnabled, expectedDedicatedHostGroupReferenceId: dedicatedHostGroupReferenceId);

                    if (validateListAvailableSize)
                    {
                        var listVMSizesResponse = m_CrpClient.VirtualMachines.ListAvailableSizes(rgName, inputVM.Name);
                        Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled,
                            hasDiffDisks: hasDiffDisks);

                        listVMSizesResponse = m_CrpClient.AvailabilitySets.ListAvailableSizes(rgName, asName);
                        Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled, hasDiffDisks: hasDiffDisks);
                    }
                    
                    if(securityType != null)
                    {
                        Assert.True(inputVM.SecurityProfile.UefiSettings.VTpmEnabled);
                        Assert.True(inputVM.SecurityProfile.UefiSettings.SecureBootEnabled);
                    }

                    if(diskSecurityProfile != null)
                    {
                        Assert.Equal("ConfidentialVM", inputVM.SecurityProfile.SecurityType);
                    }

                    if(isPpgScenario)
                    {
                        ProximityPlacementGroup outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(rgName, ppgName);
                        string expectedAvSetReferenceId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asName);
                        Assert.Equal(1, outProximityPlacementGroup.VirtualMachines.Count);
                        Assert.Equal(1, outProximityPlacementGroup.AvailabilitySets.Count);
                        Assert.Equal(expectedVMReferenceId, outProximityPlacementGroup.VirtualMachines.First().Id, StringComparer.OrdinalIgnoreCase);
                        Assert.Equal(expectedAvSetReferenceId, outProximityPlacementGroup.AvailabilitySets.First().Id, StringComparer.OrdinalIgnoreCase);
                    }

                    if (callUpdateVM)
                    {
                        VirtualMachineUpdate updateParams = new VirtualMachineUpdate()
                        {
                            Tags = inputVM.Tags
                        };

                        string updateKey = "UpdateTag";
                        updateParams.Tags.Add(updateKey, "UpdateTagValue");
                        VirtualMachine updateResponse = m_CrpClient.VirtualMachines.Update(rgName, inputVM.Name, updateParams);
                        Assert.True(updateResponse.Tags.ContainsKey(updateKey));
                    }
                }
                finally
                {
                    // Fire and forget. No need to wait for RG deletion completion
                    try
                    {
                        m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                    }
                    catch (Exception e)
                    {
                        // Swallow this exception so that the original exception is thrown
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}

