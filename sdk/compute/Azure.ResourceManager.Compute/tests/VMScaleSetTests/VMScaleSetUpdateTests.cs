// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Compute.Models.Sku;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetUpdateTests : VMScaleSetTestsBase
    {
        public VMScaleSetUpdateTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// ScaleOut VMScaleSet
        /// ScaleIn VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetScalingOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            // Scale Out VMScaleSet
            inputVMScaleSet.Sku.Capacity = 3;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            // Scale In VMScaleSet
            inputVMScaleSet.Sku.Capacity = 1;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmScaleSet.Name));
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Update VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestVMScaleSetUpdateOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            inputVMScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1.ToString();
            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = {
                            GetTestVMSSVMExtension(),
                        }
            };
            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmScaleSet.Name));
        }

        /// <summary>
        /// This is same as TestVMScaleSetUpdateOperations except that this test calls PATCH API instead of PUT
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Update VMScaleSet
        /// Scale VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("this case need to be tested by compute team")]
        public async Task TestVMScaleSetPatchOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            // Adding an extension to the VMScaleSet. We will use Patch to update this.
            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = {
                            GetTestVMSSVMExtension(),
                        }
            };

            VirtualMachineScaleSetUpdate patchVMScaleSet = new VirtualMachineScaleSetUpdate()
            {
                VirtualMachineProfile = new VirtualMachineScaleSetUpdateVMProfile()
                {
                    ExtensionProfile = extensionProfile,
                },
            };
            await PatchVMScaleSet(rgName, vmssName, patchVMScaleSet);

            // Update the inputVMScaleSet and then compare it with response to verify the result.
            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;
            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            // Scaling the VMScaleSet now to 3 instances
            VirtualMachineScaleSetUpdate patchVMScaleSet2 = new VirtualMachineScaleSetUpdate()
            {
                Sku = new Sku()
                {
                    Capacity = 3,
                },
            };
            await PatchVMScaleSet(rgName, vmssName, patchVMScaleSet2);

            // Validate that ScaleSet Scaled to 3 instances
            inputVMScaleSet.Sku.Capacity = 3;
            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmScaleSet.Name);
            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmScaleSet.Name));
        }
    }
}
