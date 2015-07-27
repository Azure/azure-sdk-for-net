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

using System;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Xunit;

namespace Compute.Tests
{
    public class ExtensionTests : VMTestBase
    {
        VirtualMachineExtension GetTestVMExtension()
        {
            var vmExtension = new VirtualMachineExtension
            {
                Name = "vmext01",
                Location = ComputeManagementTestUtilities.DefaultLocation,
                Tags = new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Type = "Microsoft.Compute/virtualMachines/extensions",
                Publisher = "Microsoft.Compute",
                ExtensionType = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                Settings = "{}",
                ProtectedSettings = "{}"
            };

            return vmExtension;
        }

        [Fact]
        public void TestVMExtensionOperations()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vm = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // Delete an extension that does not exist in the VM. A http status code of NoContent should be returned which translates to operation success.
                    var deleteResponse = m_CrpClient.VirtualMachineExtensions.Delete(rgName, vm.Name, "VMExtensionDoesNotExist");
                    Assert.True(deleteResponse.StatusCode == HttpStatusCode.NoContent);
                    Assert.True(deleteResponse.Status == OperationStatus.Succeeded);
                    
                    // Add an extension to the VM
                    var vmExtension = GetTestVMExtension();
                    //var lroResponse = m_CrpClient.VirtualMachineExtensions.CreateOrUpdate(rgName, vm.Name, vmExtension);
                    //Assert.True(lroResponse.Status != ComputeOperationStatus.InProgress);
                    var response = m_CrpClient.VirtualMachineExtensions.BeginCreatingOrUpdating(rgName, vm.Name, vmExtension);
                    Assert.True(response.StatusCode == HttpStatusCode.Created);
                    ValidateVMExtension(vmExtension, response.VirtualMachineExtension);

                    // Perform a Get operation on the extension
                    var getVMExtResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name);
                    Assert.True(getVMExtResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVMExtension(vmExtension, getVMExtResponse.VirtualMachineExtension);

                    // Validate Get InstanceView for the extension
                    var getVMExtInstanceViewResponse = m_CrpClient.VirtualMachineExtensions.GetWithInstanceView(rgName, vm.Name, vmExtension.Name);
                    Assert.True(getVMExtInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVMExtensionInstanceView(getVMExtInstanceViewResponse.VirtualMachineExtension.InstanceView);

                    // Validate the extension in the VM info
                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name);
                    Assert.True(getVMResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVMExtension(vmExtension, getVMResponse.VirtualMachine.Extensions.FirstOrDefault());

                    // Validate the extension instance view in the VM instance-view
                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, vm.Name);
                    Assert.True(getVMWithInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                    ValidateVMExtensionInstanceView(getVMWithInstanceViewResponse.VirtualMachine.InstanceView.Extensions.FirstOrDefault());

                    // Validate the extension delete API
                    deleteResponse = m_CrpClient.VirtualMachineExtensions.BeginDeleting(rgName, vm.Name, vmExtension.Name);
                    Assert.True(deleteResponse.StatusCode == HttpStatusCode.Accepted);
                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.BeginDeleting(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.Accepted);
                }
            }
        }

        private void ValidateVMExtension(VirtualMachineExtension vmExtExpected, VirtualMachineExtension vmExtReturned)
        {
            Assert.NotNull(vmExtReturned);
            Assert.True(!string.IsNullOrEmpty(vmExtReturned.ProvisioningState));

            Assert.True(vmExtExpected.Publisher == vmExtReturned.Publisher);
            Assert.True(vmExtExpected.ExtensionType == vmExtReturned.ExtensionType);
            Assert.True(vmExtExpected.AutoUpgradeMinorVersion == vmExtReturned.AutoUpgradeMinorVersion);
            Assert.True(vmExtExpected.TypeHandlerVersion == vmExtReturned.TypeHandlerVersion);
            Assert.True(vmExtExpected.Settings == vmExtReturned.Settings);
        }

        private void ValidateVMExtensionInstanceView(VirtualMachineExtensionInstanceView vmExtInstanceView)
        {
            Assert.NotNull(vmExtInstanceView);
            //Assert.NotNull(vmExtInstanceView.Statuses[0].DisplayStatus);
            //Assert.NotNull(vmExtInstanceView.Statuses[0].Code);
            //Assert.NotNull(vmExtInstanceView.Statuses[0].Level);
            //Assert.NotNull(vmExtInstanceView.Statuses[0].Message);
        }
    }
}
