// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetExtensionTests : VMScaleSetTestsBase
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
        public void TestVMScaleSetExtensions()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetExtensionsImpl(context);
            }
        }

        private void TestVMScaleSetExtensionsImpl(MockContext context)
        {
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
                    out inputVMScaleSet);

                // Add an extension to the VMSS
                VirtualMachineScaleSetExtension vmssExtension = GetTestVMSSVMExtension();
                vmssExtension.ForceUpdateTag = "RerunExtension";
                var response = m_CrpClient.VirtualMachineScaleSetExtensions.CreateOrUpdate(rgName, vmssName, vmssExtension.Name, vmssExtension);
                ValidateVmssExtension(vmssExtension, response);

                // Perform a Get operation on the extension
                var getVmssExtResponse = m_CrpClient.VirtualMachineScaleSetExtensions.Get(rgName, vmssName, vmssExtension.Name);
                ValidateVmssExtension(vmssExtension, getVmssExtResponse);

                // Validate the extension instance view in the VMSS instance-view
                var getVmssWithInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                ValidateVmssExtensionInstanceView(getVmssWithInstanceViewResponse.Extensions.FirstOrDefault());

                // Update an extension in the VMSS
                vmssExtension.Settings = string.Empty;
                var patchVmssExtsResponse = m_CrpClient.VirtualMachineScaleSetExtensions.CreateOrUpdate(rgName, vmssName, vmssExtension.Name, vmssExtension);
                ValidateVmssExtension(vmssExtension, patchVmssExtsResponse);

                // Perform a List operation on vmss extensions
                var listVmssExtsResponse = m_CrpClient.VirtualMachineScaleSetExtensions.List(rgName, vmssName);
                ValidateVmssExtension(vmssExtension, listVmssExtsResponse.FirstOrDefault());

                // Validate the extension delete API
                m_CrpClient.VirtualMachineScaleSetExtensions.Delete(rgName, vmssName, vmssExtension.Name);

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

        protected void ValidateVmssExtension(VirtualMachineScaleSetExtension vmssExtension, VirtualMachineScaleSetExtension vmssExtensionOut)
        {
            Assert.NotNull(vmssExtensionOut);
            Assert.True(!string.IsNullOrEmpty(vmssExtensionOut.ProvisioningState));

            Assert.True(vmssExtension.Publisher == vmssExtensionOut.Publisher);
            Assert.True(vmssExtension.Type == vmssExtensionOut.Type);
            Assert.True(vmssExtension.AutoUpgradeMinorVersion == vmssExtensionOut.AutoUpgradeMinorVersion);
            Assert.True(vmssExtension.TypeHandlerVersion == vmssExtensionOut.TypeHandlerVersion);
            Assert.True(vmssExtension.Settings.ToString() == vmssExtensionOut.Settings.ToString());
            Assert.True(vmssExtension.ForceUpdateTag == vmssExtensionOut.ForceUpdateTag);
        }

        protected void ValidateVmssExtensionInstanceView(VirtualMachineScaleSetVMExtensionsSummary vmssExtSummary)
        {
            Assert.NotNull(vmssExtSummary);
            Assert.NotNull(vmssExtSummary.Name);
            Assert.NotNull(vmssExtSummary.StatusesSummary[0].Code);
            Assert.NotNull(vmssExtSummary.StatusesSummary[0].Count);
        }
    }
}