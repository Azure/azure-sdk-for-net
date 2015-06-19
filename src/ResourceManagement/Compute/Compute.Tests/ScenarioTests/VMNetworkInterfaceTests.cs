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

using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Compute.Tests
{
    public class VMNetworkInterfaceTests : VMTestBase
    {
        [Fact]
        public void TestNicVirtualMachineReference()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;

                try
                {   
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    SubnetGetResponse subnetResponse = CreateVNET(rgName);

                    NetworkInterfaceGetResponse nicResponse = CreateNIC(rgName, subnetResponse.Subnet, null);

                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.NetworkInterface.Id);
                    
                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(
                         rgName, inputVM);

                    Assert.True(createOrUpdateResponse.StatusCode == HttpStatusCode.OK);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.VirtualMachine.AvailabilitySetReference.ReferenceUri
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse.VirtualMachine, expectedVMReferenceId);

                    var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse.NetworkInterface.Name);
                    Assert.NotNull(getNicResponse.NetworkInterface.MacAddress);
                    Assert.NotNull(getNicResponse.NetworkInterface.Primary);
                    Assert.True(getNicResponse.NetworkInterface.Primary != null && getNicResponse.NetworkInterface.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    var deleteRg1Response = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.OK);
                }
            }
        }

        [Fact]
        public void TestMultiNicVirtualMachineReference()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;

                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    SubnetGetResponse subnetResponse = CreateVNET(rgName);

                    string nicname1 = TestUtilities.GenerateName();
                    string nicname2 = TestUtilities.GenerateName();
                    NetworkInterfaceGetResponse nicResponse1 = CreateNIC(rgName, subnetResponse.Subnet, null, nicname1);
                    NetworkInterfaceGetResponse nicResponse2 = CreateNIC(rgName, subnetResponse.Subnet, null, nicname2);
                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.NetworkInterface.Id);

                    inputVM.HardwareProfile.VirtualMachineSize = VirtualMachineSizeTypes.StandardA4;
                    inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

                    inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
                                                                     {
                                                                         ReferenceUri = nicResponse2.NetworkInterface.Id, 
                                                                         Primary = true
                                                                     });

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM);

                    Assert.True(createOrUpdateResponse.StatusCode == HttpStatusCode.OK);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.VirtualMachine.AvailabilitySetReference.ReferenceUri
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse.VirtualMachine, expectedVMReferenceId);

                    var getNicResponse1 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse1.NetworkInterface.Name);
                    Assert.NotNull(getNicResponse1.NetworkInterface.MacAddress);
                    Assert.NotNull(getNicResponse1.NetworkInterface.Primary);
                    Assert.True(getNicResponse1.NetworkInterface.Primary != null && !getNicResponse1.NetworkInterface.Primary.Value);

                    var getNicResponse2 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse2.NetworkInterface.Name);
                    Assert.NotNull(getNicResponse2.NetworkInterface.MacAddress);
                    Assert.NotNull(getNicResponse2.NetworkInterface.Primary);
                    Assert.True(getNicResponse2.NetworkInterface.Primary != null && getNicResponse2.NetworkInterface.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    var deleteRg1Response = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.OK);
                }
            }
        }
    }
}