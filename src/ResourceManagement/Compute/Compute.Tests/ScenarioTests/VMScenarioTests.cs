//
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

using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
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
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                string imgRefId = GetPlatformOSImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var deleteVMResponse = m_CrpClient.VirtualMachines.Delete(rgName, "VMDoesNotExist");
                    Assert.True(deleteVMResponse.Status == OperationStatus.Succeeded);

                    var deleteASResponse = m_CrpClient.AvailabilitySets.Delete(rgName, "ASDoesNotExist");
                    Assert.True(deleteASResponse.StatusCode == HttpStatusCode.NoContent);

                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imgRefId, out inputVM);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, inputVM.Name);
                    Assert.True(getVMWithInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(getVMWithInstanceViewResponse.VirtualMachine != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse.VirtualMachine);

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    Assert.True(listResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVM(inputVM, listResponse.VirtualMachines.FirstOrDefault(x => x.Name == inputVM.Name),
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));

                    var listVMSizesResponse = m_CrpClient.VirtualMachines.ListAvailableSizes(rgName, inputVM.Name);
                    Assert.True(listVMSizesResponse.StatusCode == HttpStatusCode.OK);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

                    listVMSizesResponse = m_CrpClient.AvailabilitySets.ListAvailableSizes(rgName, asName);
                    Assert.True(listVMSizesResponse.StatusCode == HttpStatusCode.OK);
                    Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

                    var lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    Assert.True(lroResponse.Status != OperationStatus.Failed);
                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                }
            }
        }

        [Fact]
        public void TestVMScenarioWithPlan()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                string imgRefId = GetPlatformOSImage(useWindowsImage: true);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var imageRef = new ImageReference 
                            { 
                               Publisher = "datastax",
                               Offer = "datastax-enterprise-non-production-use-only",
                               Sku = "sandbox_single-node",
                               Version = "latest",
                            };

                    var plan = new Microsoft.Azure.Management.Compute.Models.Plan
                    {
                        Publisher = imageRef.Publisher,
                        Product = imageRef.Offer,
                        Name = imageRef.Sku,
                    };
                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imgRefId, out inputVM, (vm) =>
                        {
                            vm.StorageProfile.SourceImage = null;
                            vm.StorageProfile.ImageReference = imageRef;
                            vm.Plan = plan; 
                        }                        
                        );

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                    Assert.True(getVMResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVM(inputVM, getVMResponse.VirtualMachine, Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));

                    var listResponse = m_CrpClient.VirtualMachines.List(rgName);
                    Assert.True(listResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVM(inputVM, listResponse.VirtualMachines.FirstOrDefault(x => x.Name == inputVM.Name),
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));

                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                }
            }
        }


    }
}
