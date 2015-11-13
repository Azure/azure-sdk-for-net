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
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Compute.Tests
{
    public class ExtensionTests : VMTestBase
    {
        VirtualMachineExtension GetTestVMExtension()
        {
            var vmExtension = new VirtualMachineExtension
            {
                Location = ComputeManagementTestUtilities.DefaultLocation,
                Tags = new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Publisher = "Microsoft.Compute",
                VirtualMachineExtensionType = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                Settings = "{}",
                ProtectedSettings = "{}"
            };
            typeof(Resource).GetRuntimeProperty("Name").SetValue(vmExtension, "vmext01");
            typeof(Resource).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/virtualMachines/extensions");

            return vmExtension;
        }

        public void TestVMExtensionOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                //VMNetworkInterfaceTests.FixRecords();

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

                    var vm = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // Delete an extension that does not exist in the VM. A http status code of NoContent should be returned which translates to operation success.
                    m_CrpClient.VirtualMachineExtensions.Delete(rgName, vm.Name, "VMExtensionDoesNotExist");
                    
                    // Add an extension to the VM
                    var vmExtension = GetTestVMExtension();
                    //var lroResponse = m_CrpClient.VirtualMachineExtensions.CreateOrUpdate(rgName, vm.Name, vmExtension);
                    //Assert.True(lroResponse.Status != ComputeOperationStatus.InProgress);
                    var response = m_CrpClient.VirtualMachineExtensions.CreateOrUpdate(rgName, vm.Name, vmExtension.Name, vmExtension);
                    ValidateVMExtension(vmExtension, response);

                    // Perform a Get operation on the extension
                    var getVMExtResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name);
                    ValidateVMExtension(vmExtension, getVMExtResponse);

                    // Validate Get InstanceView for the extension
                    var getVMExtInstanceViewResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name, "instanceView");
                    ValidateVMExtensionInstanceView(getVMExtInstanceViewResponse.InstanceView);

                    // Validate the extension in the VM info
                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    ValidateVMExtension(vmExtension, getVMResponse.Resources.FirstOrDefault());

                    // Validate the extension instance view in the VM instance-view
                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name, "instanceView");
                    ValidateVMExtensionInstanceView(getVMWithInstanceViewResponse.InstanceView.Extensions.FirstOrDefault());

                    // Validate the extension delete API
                    m_CrpClient.VirtualMachineExtensions.Delete(rgName, vm.Name, vmExtension.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private void ValidateVMExtension(VirtualMachineExtension vmExtExpected, VirtualMachineExtension vmExtReturned)
        {
            Assert.NotNull(vmExtReturned);
            Assert.True(!string.IsNullOrEmpty(vmExtReturned.ProvisioningState));

            Assert.True(vmExtExpected.Publisher == vmExtReturned.Publisher);
            Assert.True(vmExtExpected.VirtualMachineExtensionType == vmExtReturned.VirtualMachineExtensionType);
            Assert.True(vmExtExpected.AutoUpgradeMinorVersion == vmExtReturned.AutoUpgradeMinorVersion);
            Assert.True(vmExtExpected.TypeHandlerVersion == vmExtReturned.TypeHandlerVersion);
            Assert.True(vmExtExpected.Settings.ToString() == vmExtReturned.Settings.ToString());
        }

        private void ValidateVMExtensionInstanceView(VirtualMachineExtensionInstanceView vmExtInstanceView)
        {
            Assert.NotNull(vmExtInstanceView);
            Assert.NotNull(vmExtInstanceView.Statuses[0].DisplayStatus);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Code);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Level);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Message);
        }
    }
}
