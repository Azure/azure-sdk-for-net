// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMHealthExtensionTests : VMTestBase
    {
        VirtualMachineExtension GetHealthVMExtension()
        {
            var vmExtension = new VirtualMachineExtension
            {
                Location = ComputeManagementTestUtilities.DefaultLocation,
                Tags = new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Publisher = "Microsoft.ManagedServices",
                VirtualMachineExtensionType = "ApplicationHealthWindows",
                TypeHandlerVersion = "1.0",
                AutoUpgradeMinorVersion = true,
                ForceUpdateTag = "RerunExtension",
                Settings = new JRaw("{ \"port\": 3389, \"protocol\": \"tcp\" }"),
                ProtectedSettings = "{}"
            };
            typeof(Resource).GetRuntimeProperty("Name").SetValue(vmExtension, "vmext01");
            typeof(Resource).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/virtualMachines/extensions");

            return vmExtension;
        }

        [Fact]
        public void TestVMHealthExtensionOperations()
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
                    // Create VM with storage account
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vm = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // Add an extension to the VM
                    var vmExtension = GetHealthVMExtension();
                    var response = m_CrpClient.VirtualMachineExtensions.CreateOrUpdate(rgName, vm.Name, vmExtension.Name, vmExtension);
                    ValidateVMExtension(vmExtension, response);

                    // Perform a Get operation on the extension
                    var getVMExtResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name);
                    ValidateVMExtension(vmExtension, getVMExtResponse);

                    // Validate Get InstanceView for the extension
                    var getVMExtInstanceViewResponse = m_CrpClient.VirtualMachineExtensions.Get(rgName, vm.Name, vmExtension.Name, "instanceView");
                    ValidateVMExtensionInstanceView(getVMExtInstanceViewResponse.InstanceView);

                    var getVMInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, vm.Name, InstanceViewTypes.InstanceView);
                    ValidateVMHealthStatusInstanceView(getVMInstanceViewResponse.InstanceView.VmHealth);

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
        }

        private void ValidateVMExtensionInstanceView(VirtualMachineExtensionInstanceView vmExtInstanceView)
        {
            Assert.NotNull(vmExtInstanceView);
            ValidateInstanceViewStatus(vmExtInstanceView.Statuses[0]);
        }

        private void ValidateVMHealthStatusInstanceView(VirtualMachineHealthStatus vmHealthStatus)
        {
            Assert.NotNull(vmHealthStatus);
            ValidateInstanceViewStatus(vmHealthStatus.Status);
        }

        private void ValidateInstanceViewStatus(InstanceViewStatus instanceViewStatus)
        {
            Assert.NotNull(instanceViewStatus.DisplayStatus);
            Assert.NotNull(instanceViewStatus.Code);
            Assert.NotNull(instanceViewStatus.Level);
        }
    }
}
