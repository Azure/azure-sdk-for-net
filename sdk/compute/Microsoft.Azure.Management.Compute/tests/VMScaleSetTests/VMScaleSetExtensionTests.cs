// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetExtensionsImpl(context);
            }
        }

        [Fact]
        public void TestVMScaleSetExtensionSequencing()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: false);
                    VirtualMachineScaleSetExtensionProfile vmssExtProfile = GetTestVmssExtensionProfile();
                    // Set extension sequencing (ext2 is provisioned after ext1)
                    vmssExtProfile.Extensions[1].ProvisionAfterExtensions = new List<string> { vmssExtProfile.Extensions[0].Name };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        null,
                        imageRef,
                        out inputVMScaleSet,
                        extensionProfile: vmssExtProfile,
                        createWithManagedDisks: true);

                    Assert.Equal("PT1H20M", vmScaleSet.VirtualMachineProfile.ExtensionProfile.ExtensionsTimeBudget);
                    // Perform a Get operation on each extension
                    VirtualMachineScaleSetExtension getVmssExtResponse = null;
                    for (int i = 0; i < vmssExtProfile.Extensions.Count; i++)
                    {
                        getVmssExtResponse = m_CrpClient.VirtualMachineScaleSetExtensions.Get(rgName, vmssName, vmssExtProfile.Extensions[i].Name);
                        ValidateVmssExtension(vmssExtProfile.Extensions[i], getVmssExtResponse);
                    }
                    // Add a new extension to the VMSS (ext3 is provisioned after ext2)
                    VirtualMachineScaleSetExtension vmssExtension = GetTestVMSSVMExtension(name: "3", publisher: "Microsoft.CPlat.Core", type: "NullLinux", version: "4.0");
                    vmssExtension.ProvisionAfterExtensions = new List<string> { vmssExtProfile.Extensions[1].Name };
                    var response = m_CrpClient.VirtualMachineScaleSetExtensions.CreateOrUpdate(rgName, vmssName, vmssExtension.Name, vmssExtension);
                    ValidateVmssExtension(vmssExtension, response);

                    // Perform a Get operation on the extension
                    getVmssExtResponse = m_CrpClient.VirtualMachineScaleSetExtensions.Get(rgName, vmssName, vmssExtension.Name);
                    ValidateVmssExtension(vmssExtension, getVmssExtResponse);

                    // Clear the sequencing in ext3
                    vmssExtension.ProvisionAfterExtensions.Clear();
                    var patchVmssExtsResponse = m_CrpClient.VirtualMachineScaleSetExtensions.CreateOrUpdate(rgName, vmssName, vmssExtension.Name, vmssExtension);
                    ValidateVmssExtension(vmssExtension, patchVmssExtsResponse);

                    // Perform a List operation on vmss extensions
                    var listVmssExtsResponse = m_CrpClient.VirtualMachineScaleSetExtensions.List(rgName, vmssName);
                    int installedExtensionsCount = listVmssExtsResponse.Count();
                    Assert.Equal(3, installedExtensionsCount);
                    VirtualMachineScaleSetExtension expectedVmssExt = null;
                    for (int i = 0; i < installedExtensionsCount; i++)
                    {
                        if (i < installedExtensionsCount - 1)
                        {
                            expectedVmssExt = vmssExtProfile.Extensions[i];
                        }
                        else
                        {
                            expectedVmssExt = vmssExtension;
                        }

                        ValidateVmssExtension(expectedVmssExt, listVmssExtsResponse.ElementAt(i));
                    }
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private VirtualMachineScaleSetExtensionProfile GetTestVmssExtensionProfile()
        {
            return new VirtualMachineScaleSetExtensionProfile
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetTestVMSSVMExtension(name: "1", publisher: "Microsoft.CPlat.Core", type: "NullSeqA", version: "2.0"),
                    GetTestVMSSVMExtension(name: "2", publisher: "Microsoft.CPlat.Core", type: "NullSeqB", version: "2.0")
                },
                ExtensionsTimeBudget = "PT1H20M"
            };
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
                VirtualMachineScaleSetExtension vmssExtension = GetTestVMSSVMExtension(autoUpdateMinorVersion:false, enableAutomaticUpgrade: false);
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
                ValidateVmssExtension(vmssExtension, listVmssExtsResponse.FirstOrDefault(c => c.ForceUpdateTag == "RerunExtension"));

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
            Assert.True(vmssExtension.Type1 == vmssExtensionOut.Type1);
            Assert.True(vmssExtension.AutoUpgradeMinorVersion == vmssExtensionOut.AutoUpgradeMinorVersion);
            Assert.True(vmssExtension.TypeHandlerVersion == vmssExtensionOut.TypeHandlerVersion);
            Assert.True(vmssExtension.Settings.ToString() == vmssExtensionOut.Settings.ToString());
            Assert.True(vmssExtension.ForceUpdateTag == vmssExtensionOut.ForceUpdateTag);
            Assert.True(vmssExtension.EnableAutomaticUpgrade == vmssExtensionOut.EnableAutomaticUpgrade);

            if (vmssExtension.ProvisionAfterExtensions != null)
            {
                Assert.True(vmssExtension.ProvisionAfterExtensions.Count == vmssExtensionOut.ProvisionAfterExtensions.Count);
                for (int i = 0; i < vmssExtension.ProvisionAfterExtensions.Count; i++)
                {
                    Assert.True(vmssExtension.ProvisionAfterExtensions[i] == vmssExtensionOut.ProvisionAfterExtensions[i]);
                }
            }
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
