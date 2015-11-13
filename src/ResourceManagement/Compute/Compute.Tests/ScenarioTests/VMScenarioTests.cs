﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachines.Delete(rgName, "VMDoesNotExist");

                    m_CrpClient.AvailabilitySets.Delete(rgName, "ASDoesNotExist");

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, "instanceView");
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    ValidateVM(inputVM, listResponse.FirstOrDefault(x => x.Name == inputVM.Name),
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));

                    var listVMSizesResponse = m_CrpClient.VirtualMachines.ListAvailableSizes(rgName, inputVM.Name);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

                    listVMSizesResponse = m_CrpClient.AvailabilitySets.ListAvailableSizes(rgName, asName);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

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
