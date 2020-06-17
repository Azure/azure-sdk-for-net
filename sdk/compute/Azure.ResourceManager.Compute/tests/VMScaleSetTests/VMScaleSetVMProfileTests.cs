// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.VMScaleSetTests
{
    public class VMScaleSetVMProfileTests : VMScaleSetTestsBase
    {
        public VMScaleSetVMProfileTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Checks if licenseType can be set through API
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithLicenseType()
        {
            EnsureClientsInitialized(DefaultLocation);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            VirtualMachineScaleSet inputVMScaleSet;

            Action<VirtualMachineScaleSet> vmProfileCustomizer = vmss =>
            {
                vmss.VirtualMachineProfile.StorageProfile.ImageReference = GetPlatformVMImage(true).Result;
                vmss.VirtualMachineProfile.LicenseType = "Windows_Server";
            };

            try
            {
                var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                    rgName: rgName,
                    vmssName: vmssName,
                    storageAccount: storageAccountOutput,
                    imageRef: null,
                    createWithManagedDisks: true,
                    vmScaleSetCustomizer: vmProfileCustomizer
                    );
                VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
                inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;

                var response = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;

                Assert.AreEqual("Windows_Server", response.VirtualMachineProfile.LicenseType);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("One or more errors occurred while preparing VM disks. See disk instance view for details."))
                {
                    return;
                }
                throw;
            }
        }

        /// <summary>
        /// Checks if diagnostics profile can be set through API
        /// </summary>
        [Test]
        public async Task TestVMScaleSetDiagnosticsProfile()
        {
            EnsureClientsInitialized(DefaultLocation);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            VirtualMachineScaleSet inputVMScaleSet;

            Action<VirtualMachineScaleSet> vmProfileCustomizer = vmss =>
            {
                vmss.VirtualMachineProfile.DiagnosticsProfile = new DiagnosticsProfile(
                    new BootDiagnostics
                    {
                        Enabled = true,
                        StorageUri = string.Format(Constants.StorageAccountBlobUriTemplate, storageAccountName)
                    });
            };
            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: await GetPlatformVMImage(true),
                createWithManagedDisks: true,
                vmScaleSetCustomizer: vmProfileCustomizer
                );
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var response = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;

            Assert.True(response.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.Enabled.GetValueOrDefault(true));
        }
    }
}
