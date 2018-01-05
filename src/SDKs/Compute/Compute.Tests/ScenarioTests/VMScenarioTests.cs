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
        /// Delete VM
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
        /// Create VM
        /// GET VM Model View
        /// GET VM InstanceView
        /// GETVMs in a RG
        /// List VMSizes in a RG
        /// List VMSizes in an AvailabilitySet
        /// Delete VM
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScenarioOperations_ManagedDisks")]
        public void TestVMScenarioOperations_ManagedDisks()
        {
            TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks", hasManagedDisks: true);
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
                TestVMScenarioOperationsInternal("TestVMScenarioOperations_ManagedDisks_PirImage_Zones", hasManagedDisks: true, zones: new List<string> { "1" });
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        private void TestVMScenarioOperationsInternal(string methodName, bool hasManagedDisks = false, IList<string> zones = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    if (!hasManagedDisks)
                    {
                        // Create Storage Account, so that both the VMs can share it
                        var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                        m_CrpClient.VirtualMachines.Delete(rgName, "VMDoesNotExist");

                        m_CrpClient.AvailabilitySets.Delete(rgName, "ASDoesNotExist");
                    }

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountName, imageRef, out inputVM, hasManagedDisks: hasManagedDisks, zones: zones);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks);

                    var getVMInstanceViewResponse = m_CrpClient.VirtualMachines.InstanceView(rgName, inputVM.Name);
                    Assert.True(getVMInstanceViewResponse != null, "VM in InstanceView");
                    ValidateVMInstanceView(inputVM, getVMInstanceViewResponse, hasManagedDisks);

                    bool hasUserDefinedAS = zones == null;

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    ValidateVM(inputVM, listResponse.FirstOrDefault(x => x.Name == inputVM.Name),
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name), hasManagedDisks, hasUserDefinedAS);

                    var listVMSizesResponse = m_CrpClient.VirtualMachines.ListAvailableSizes(rgName, inputVM.Name);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null);

                    listVMSizesResponse = m_CrpClient.AvailabilitySets.ListAvailableSizes(rgName, asName);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse, hasAZ: zones != null);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
