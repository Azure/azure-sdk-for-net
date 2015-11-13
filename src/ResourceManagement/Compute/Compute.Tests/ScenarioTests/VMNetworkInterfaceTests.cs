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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMNetworkInterfaceTests : VMTestBase
    {
        [Fact]
        public void TestNicVirtualMachineReference()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;
                try
                {   
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    NetworkInterface nicResponse = CreateNIC(rgName, subnetResponse, null);

                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id);
                    
                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(
                         rgName, inputVM.Name, inputVM);

                    Assert.NotNull(createOrUpdateResponse);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse.MacAddress);
                    Assert.NotNull(getNicResponse.Primary);
                    Assert.True(getNicResponse.Primary != null && getNicResponse.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void TestMultiNicVirtualMachineReference()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;

                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    string nicname1 = ComputeManagementTestUtilities.GenerateName(null);
                    string nicname2 = ComputeManagementTestUtilities.GenerateName(null);
                    NetworkInterface nicResponse1 = CreateNIC(rgName, subnetResponse, null, nicname1);
                    NetworkInterface nicResponse2 = CreateNIC(rgName, subnetResponse, null, nicname2);
                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.Id);

                    inputVM.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                    inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

                    inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
                                                                     {
                                                                         Id = nicResponse2.Id, 
                                                                         Primary = true
                                                                     });

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse1 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse1.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                   Assert.NotNull(getNicResponse1.MacAddress);
                   Assert.NotNull(getNicResponse1.Primary);
                   Assert.True(getNicResponse1.Primary != null && !getNicResponse1.Primary.Value);

                    var getNicResponse2 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse2.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse2.MacAddress);
                    Assert.NotNull(getNicResponse2.Primary);
                    Assert.True(getNicResponse2.Primary != null && getNicResponse2.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}