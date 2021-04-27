// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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
                AutoUpgradeMinorVersion = false,
                ForceUpdateTag = "RerunExtension",
                Settings = "{}",
                ProtectedSettings = "{}",
                EnableAutomaticUpgrade = false,
            };
            typeof(Resource).GetRuntimeProperty("Name").SetValue(vmExtension, "vmext01");
            typeof(Resource).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/virtualMachines/extensions");

            return vmExtension;
        }

        VirtualMachineExtensionUpdate GetTestVMUpdateExtension()
        {
            var vmExtensionUpdate = new VirtualMachineExtensionUpdate
            {
                Tags =
                    new Dictionary<string, string>
                    {
                        {"extensionTag1", "1"},
                        {"extensionTag2", "2"},
                        {"extensionTag3", "3"}
                    }
            };

            return vmExtensionUpdate;
        }

        [Fact]
        public void TestVMExtensionOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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

                    var vm = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // Delete an extension that does not exist in the VM. A http status code of NoContent should be returned which translates to operation success.
                    m_CrpClient.VirtualMachineExtensions.Delete(rgName, vm.Name, "VMExtensionDoesNotExist");

                    // Add an extension to the VM
                    var vmExtension = GetTestVMExtension();
                    var response = m_CrpClient.VirtualMachineExtensions.CreateOrUpdate(rgName, vm.Name, vmExtension.Name, vmExtension);
                    ValidateVMExtension(vmExtension, response);

                    // Perform a Get operation on the extension
                    var getVMExtResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name);
                    ValidateVMExtension(vmExtension, getVMExtResponse);

                    // Perform a GetExtensions on the VM
                    var getVMExtsResponse = m_CrpClient.VirtualMachineExtensions.List(rgName, vm.Name);
                    Assert.True(getVMExtsResponse.Value.Count > 0);
                    var vme = getVMExtsResponse.Value.Where(c => c.Name == "vmext01");
                    Assert.Single(vme);
                    ValidateVMExtension(vmExtension, vme.First());

                    // Validate Get InstanceView for the extension
                    var getVMExtInstanceViewResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name, "instanceView");
                    ValidateVMExtensionInstanceView(getVMExtInstanceViewResponse.InstanceView);

                    // Update extension on the VM
                    var vmExtensionUpdate = GetTestVMUpdateExtension();
                    m_CrpClient.VirtualMachineExtensions.Update(rgName, vm.Name, vmExtension.Name, vmExtensionUpdate);
                    vmExtension.Tags["extensionTag3"] = "3";
                    getVMExtResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name);
                    ValidateVMExtension(vmExtension, getVMExtResponse);

                    // Validate the extension in the VM info
                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    ValidateVMExtension(vmExtension, getVMResponse.Resources.FirstOrDefault(c => c.Name == vmExtension.Name));

                    // Validate the extension instance view in the VM instance-view
                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name, InstanceViewTypes.InstanceView);
                    ValidateVMExtensionInstanceView(getVMWithInstanceViewResponse.InstanceView.Extensions.FirstOrDefault(c => c.Name == vmExtension.Name));

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
            Assert.True(vmExtExpected.ForceUpdateTag == vmExtReturned.ForceUpdateTag);
            Assert.True(vmExtExpected.Tags.SequenceEqual(vmExtReturned.Tags));
            Assert.True(vmExtExpected.EnableAutomaticUpgrade == vmExtReturned.EnableAutomaticUpgrade);
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

