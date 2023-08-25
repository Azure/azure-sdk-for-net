// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Xunit;


namespace Compute.Tests
{
    public class VMScaleSetVMExtensionTests : VMScaleSetVMTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Create VMSS Extension
        /// Update VMSS Extension
        /// Get VMSS Extension
        /// List VMSS Extensions
        /// Delete VMSS Extension
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMExtensions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetVMExtensionsImpl(context);
            }
        }

        private void TestVMScaleSetVMExtensionsImpl(MockContext context)
        {
            var instanceId = "0";
            // Create resource group
            string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            bool passed = false;
            try
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    createWithManagedDisks: true);

                // Add an extension to the intance of VMSS
                VirtualMachineScaleSetVMExtension vmssVMExtension = GetVMSSVMExtension(autoUpdateMinorVersion: false, enableAutomaticUpgrade: false, suppressFailures: true);

                var response = m_CrpClient.VirtualMachineScaleSetVMExtensions.CreateOrUpdate(rgName, vmssName, instanceId, vmssVMExtension.Name, vmssVMExtension);
                ValidateVmssVMExtension(vmssVMExtension, response);

                // Perform a Get operation on the extension
                var getVmssVMExtResponse = m_CrpClient.VirtualMachineScaleSetVMExtensions.Get(rgName, vmssName, instanceId, vmssVMExtension.Name);
                ValidateVmssVMExtension(vmssVMExtension, getVmssVMExtResponse);

                // Perform a List operation on the Extensions
                var listVmssExtsResponse = m_CrpClient.VirtualMachineScaleSetVMExtensions.List(rgName, vmssName, instanceId);
                ValidateVmssVMExtension(vmssVMExtension, listVmssExtsResponse.Value.FirstOrDefault(e => e.Name == "vmssext01"));

                // Validate the extension delete API
                m_CrpClient.VirtualMachineScaleSetVMExtensions.Delete(rgName, vmssName, instanceId, vmssVMExtension.Name);
                passed = true;
            }
            finally
            {
                // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }

            Assert.True(passed);
        }

        VirtualMachineScaleSetVMExtension GetVMSSVMExtension(
            string name = "vmssext01",
            string publisher = "Microsoft.Compute",
            string type = "VMAccessAgent",
            string version = "2.0",
            bool autoUpdateMinorVersion = true,
            bool? enableAutomaticUpgrade = null,
            bool? suppressFailures = null)
        {
            var vmExtension = new VirtualMachineScaleSetVMExtension
            {
                Publisher = publisher,
                Type1 = type,
                TypeHandlerVersion = version,
                AutoUpgradeMinorVersion = autoUpdateMinorVersion,
                Settings = "{}",
                ProtectedSettings = "{}",
                EnableAutomaticUpgrade = enableAutomaticUpgrade,
                SuppressFailures = suppressFailures
            };

            typeof(VirtualMachineScaleSetVMExtension).GetRuntimeProperty("Name").SetValue(vmExtension, name);
            typeof(VirtualMachineScaleSetVMExtension).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/vitualMachineScaleSets/virtualMachines/extensions");
            typeof(VirtualMachineScaleSetVMExtension).GetRuntimeProperty("Location").SetValue(vmExtension, ComputeManagementTestUtilities.DefaultLocation);

            return vmExtension;
        }
        protected void ValidateVmssVMExtension(VirtualMachineScaleSetVMExtension vmssExtension, VirtualMachineScaleSetVMExtension vmssExtensionOut)
        {
            Assert.NotNull(vmssExtensionOut);
            Assert.True(!string.IsNullOrEmpty(vmssExtensionOut.ProvisioningState));

            Assert.True(vmssExtension.Location == vmssExtensionOut.Location);
            Assert.True(vmssExtension.Publisher == vmssExtensionOut.Publisher);
            Assert.True(vmssExtension.Type1 == vmssExtensionOut.Type1);
            Assert.True(vmssExtension.AutoUpgradeMinorVersion == vmssExtensionOut.AutoUpgradeMinorVersion);
            Assert.True(vmssExtension.TypeHandlerVersion == vmssExtensionOut.TypeHandlerVersion);
            Assert.True(vmssExtension.Settings.ToString() == vmssExtensionOut.Settings.ToString());
            Assert.True(vmssExtension.ForceUpdateTag == vmssExtensionOut.ForceUpdateTag);
            Assert.True(vmssExtension.EnableAutomaticUpgrade == vmssExtensionOut.EnableAutomaticUpgrade);
            Assert.True(vmssExtension.SuppressFailures == vmssExtensionOut.SuppressFailures);
        }
    }
}
