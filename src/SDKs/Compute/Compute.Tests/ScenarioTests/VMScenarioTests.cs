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
        [Fact(Skip = "ReRecord due to CR change")]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks")]
        public void TestVMScenarioOperations_ManagedDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks", vmSize: VirtualMachineSizeTypes.StandardM64s, hasManagedDisks: true,
                    storageAccountType: StorageAccountTypes.PremiumLRS, writeAcceleratorEnabled: true);
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
                    storageAccountType: StorageAccountTypes.StandardSSDLRS);
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
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_PirImage_Zones", hasManagedDisks: true, zones: new List<string> { "1" }, callUpdateVM: true);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        private void TestVMScenarioOperationsInternal(string methodName, bool hasManagedDisks = false, IList<string> zones = null, string vmSize = "Standard_A0",
            string storageAccountType = "Standard_LRS", bool? writeAcceleratorEnabled = null, bool callUpdateVM = false)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                const string expectedOSName = "Windows Server 2012 R2 Datacenter", expectedOSVersion = "Microsoft Windows NT 6.3.9600.0", expectedComputerName = ComputerName;
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    if (!hasManagedDisks)
                    {
                        CreateStorageAccount(rgName, storageAccountName);
                    }

                    CreateVM(rgName, asName, storageAccountName, imageRef, out inputVM, hasManagedDisks: hasManagedDisks, vmSize: vmSize, storageAccountType: storageAccountType, 
                        writeAcceleratorEnabled: writeAcceleratorEnabled, zones: zones);

                    // Instance view is not completely populated just after VM is provisioned. So we wait here for a few minutes to 
                    // allow GA blob to populate.
                    ComputeManagementTestUtilities.WaitMinutes(5);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion);

                    var getVMInstanceViewResponse = m_CrpClient.VirtualMachines.InstanceView(rgName, inputVM.Name);
                    Assert.True(getVMInstanceViewResponse != null, "VM in InstanceView");
                    ValidateVMInstanceView(inputVM, getVMInstanceViewResponse, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion);

                    bool hasUserDefinedAS = zones == null;

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    ValidateVM(inputVM, listResponse.FirstOrDefault(x => x.Name == inputVM.Name),
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name), hasManagedDisks, hasUserDefinedAS, writeAcceleratorEnabled);

                    var listVMSizesResponse = m_CrpClient.VirtualMachines.ListAvailableSizes(rgName, inputVM.Name);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled);

                    listVMSizesResponse = m_CrpClient.AvailabilitySets.ListAvailableSizes(rgName, asName);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null, writeAcceleratorEnabled: writeAcceleratorEnabled);

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
