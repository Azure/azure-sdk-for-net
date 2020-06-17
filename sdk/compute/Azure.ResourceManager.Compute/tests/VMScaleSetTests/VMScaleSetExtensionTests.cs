// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetExtensionTests : VMScaleSetTestsBase
    {
        public VMScaleSetExtensionTests(bool isAsync)
       : base(isAsync)
        {
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestVMScaleSetExtensions()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestVMScaleSetExtensionsImpl();
        }

        [Test]
        public async Task TestVMScaleSetExtensionSequencing()
        {
            EnsureClientsInitialized(DefaultLocation);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            VirtualMachineScaleSet inputVMScaleSet;
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: false);
            VirtualMachineScaleSetExtensionProfile vmssExtProfile = GetTestVmssExtensionProfile();

            // Set extension sequencing (ext2 is provisioned after ext1)
            vmssExtProfile.Extensions[1].ProvisionAfterExtensions = new List<string> { vmssExtProfile.Extensions[0].Name };

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                null,
                imageRef,
                extensionProfile: vmssExtProfile,
                createWithManagedDisks: true);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            // Perform a Get operation on each extension
            VirtualMachineScaleSetExtension getVmssExtResponse = null;
            for (int i = 0; i < vmssExtProfile.Extensions.Count; i++)
            {
                getVmssExtResponse = await VirtualMachineScaleSetExtensionsOperations.GetAsync(rgName, vmssName, vmssExtProfile.Extensions[i].Name);
                ValidateVmssExtension(vmssExtProfile.Extensions[i], getVmssExtResponse);
            }

            // Add a new extension to the VMSS (ext3 is provisioned after ext2)
            VirtualMachineScaleSetExtension vmssExtension = GetTestVMSSVMExtension(name: "3", publisher: "Microsoft.CPlat.Core", type: "NullLinux", version: "4.0");
            vmssExtension.ProvisionAfterExtensions = new List<string> { vmssExtProfile.Extensions[1].Name };
            var response = await WaitForCompletionAsync(await VirtualMachineScaleSetExtensionsOperations.StartCreateOrUpdateAsync(rgName, vmssName, vmssExtension.Name, vmssExtension));
            ValidateVmssExtension(vmssExtension, response.Value);

            // Perform a Get operation on the extension
            getVmssExtResponse = await VirtualMachineScaleSetExtensionsOperations.GetAsync(rgName, vmssName, vmssExtension.Name);
            ValidateVmssExtension(vmssExtension, getVmssExtResponse);

            // Clear the sequencing in ext3
            vmssExtension.ProvisionAfterExtensions.Clear();
            var patchVmssExtsResponse = await WaitForCompletionAsync(await VirtualMachineScaleSetExtensionsOperations.StartCreateOrUpdateAsync(rgName, vmssName, vmssExtension.Name, vmssExtension));
            ValidateVmssExtension(vmssExtension, patchVmssExtsResponse.Value);

            // Perform a List operation on vmss extensions
            var listVmssExts = VirtualMachineScaleSetExtensionsOperations.ListAsync(rgName, vmssName);
            var listVmssExtsResponse = await listVmssExts.ToEnumerableAsync();
            int installedExtensionsCount = listVmssExtsResponse.Count();
            Assert.AreEqual(3, installedExtensionsCount);
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

        private VirtualMachineScaleSetExtensionProfile GetTestVmssExtensionProfile()
        {
            return new VirtualMachineScaleSetExtensionProfile
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetTestVMSSVMExtension(name: "1", publisher: "Microsoft.CPlat.Core", type: "NullSeqA", version: "2.0"),
                    GetTestVMSSVMExtension(name: "2", publisher: "Microsoft.CPlat.Core", type: "NullSeqB", version: "2.0")
                }
            };
        }

        private async Task TestVMScaleSetExtensionsImpl()
        {
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            bool passed = false;

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef);

            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            VirtualMachineScaleSetExtension vmssExtension = GetTestVMSSVMExtension();
            vmssExtension.ForceUpdateTag = "RerunExtension";
            var response = await WaitForCompletionAsync(await VirtualMachineScaleSetExtensionsOperations.StartCreateOrUpdateAsync(rgName, vmssName, vmssExtension.Name, vmssExtension));
            ValidateVmssExtension(vmssExtension, response.Value);

            // Perform a Get operation on the extension
            var getVmssExtResponse = await VirtualMachineScaleSetExtensionsOperations.GetAsync(rgName, vmssName, vmssExtension.Name);
            ValidateVmssExtension(vmssExtension, getVmssExtResponse);

            // Validate the extension instance view in the VMSS instance-view
            var getVmssWithInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            ValidateVmssExtensionInstanceView(getVmssWithInstanceViewResponse.Value.Extensions.FirstOrDefault());

            // Update an extension in the VMSS
            vmssExtension.Settings = string.Empty;
            var patchVmssExtsResponse = await WaitForCompletionAsync(await VirtualMachineScaleSetExtensionsOperations.StartCreateOrUpdateAsync(rgName, vmssName, vmssExtension.Name, vmssExtension));
            ValidateVmssExtension(vmssExtension, patchVmssExtsResponse.Value);

            // Perform a List operation on vmss extensions
            var listVmssExts = VirtualMachineScaleSetExtensionsOperations.ListAsync(rgName, vmssName);
            var listVmssExtsResponse = await listVmssExts.ToEnumerableAsync();
            ValidateVmssExtension(vmssExtension, listVmssExtsResponse.FirstOrDefault(c => c.ForceUpdateTag == "RerunExtension"));

            // Validate the extension delete API
            await WaitForCompletionAsync(await VirtualMachineScaleSetExtensionsOperations.StartDeleteAsync(rgName, vmssName, vmssExtension.Name));

            passed = true;
            Assert.True(passed);
        }

        protected void ValidateVmssExtension(VirtualMachineScaleSetExtension vmssExtension, VirtualMachineScaleSetExtension vmssExtensionOut)
        {
            Assert.NotNull(vmssExtensionOut);
            Assert.True(!string.IsNullOrEmpty(vmssExtensionOut.ProvisioningState));

            Assert.True(vmssExtension.Publisher == vmssExtensionOut.Publisher);
            Assert.True(vmssExtension.TypePropertiesType == vmssExtensionOut.TypePropertiesType);
            Assert.True(vmssExtension.AutoUpgradeMinorVersion == vmssExtensionOut.AutoUpgradeMinorVersion);
            Assert.True(vmssExtension.TypeHandlerVersion == vmssExtensionOut.TypeHandlerVersion);
            Assert.True(vmssExtension.Settings.ToString() == vmssExtensionOut.Settings.ToString());
            Assert.True(vmssExtension.ForceUpdateTag == vmssExtensionOut.ForceUpdateTag);

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
