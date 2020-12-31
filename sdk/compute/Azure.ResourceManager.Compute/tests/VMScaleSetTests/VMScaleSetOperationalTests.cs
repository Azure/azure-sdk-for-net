// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetOperationalTests : VMScaleSetTestsBase
    {
        public VMScaleSetOperationalTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSet
        /// Stop VMScaleSet
        /// Restart VMScaleSet
        /// Deallocate VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetOperations()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScaleSetOperationsInternal();
        }

        /// <summary>
        /// Covers following Operations for a ScaleSet with ManagedDisks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSet
        /// Reimage VMScaleSet
        /// ReimageAll VMScaleSet
        /// Stop VMScaleSet
        /// Restart VMScaleSet
        /// Deallocate VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetOperations_ManagedDisks()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScaleSetOperationsInternal(hasManagedDisks: true);
        }

        private async Task TestVMScaleSetOperationsInternal(bool hasManagedDisks = false)
        {
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                createWithManagedDisks: hasManagedDisks);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            // TODO: AutoRest skips the following methods - Start, Restart, PowerOff, Deallocate
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartStartAsync(rgName, vmScaleSet.Name));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartReimageAsync(rgName, vmScaleSet.Name));
            if (hasManagedDisks)
            {
                await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartReimageAllAsync(rgName, vmScaleSet.Name));
            }
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartRestartAsync(rgName, vmScaleSet.Name));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartPowerOffAsync(rgName, vmScaleSet.Name));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeallocateAsync(rgName, vmScaleSet.Name));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmScaleSet.Name));
            passed = true;

            Assert.True(passed);
        }

        [Test]
        public async Task TestVMScaleSetOperations_Redeploy()
        {
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            EnsureClientsInitialized(LocationEastUs2UpperCase);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                storageAccountOutput, imageRef, createWithManagedDisks: true);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartRedeployAsync(rgName, vmScaleSet.Name));

            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VMSS
        /// Start VMSS
        /// Shutdown VMSS with skipShutdown = true
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetOperations_PowerOffWithSkipShutdown()
        {
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            EnsureClientsInitialized(LocationEastUs2UpperCase);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                storageAccountOutput, imageRef, createWithManagedDisks: true);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartStartAsync(rgName, vmScaleSet.Name));
            // Shutdown VM with SkipShutdown = true
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartPowerOffAsync(rgName, vmScaleSet.Name, true));
            passed = true;
            Assert.True(passed);
        }

        [Test]
        public async Task TestVMScaleSetOperations_PerformMaintenance()
        {
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            VirtualMachineScaleSet vmScaleSet = null;

            bool passed = false;

            try
            {
                EnsureClientsInitialized(LocationEastUs2UpperCase);

                ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
                StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

                var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                    createWithManagedDisks: true);
                vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
                inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
                await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartPerformMaintenanceAsync(rgName, vmScaleSet.Name));

                passed = true;
            }
            catch (Exception cex)
            {
                passed = true;
                string expectedMessage =
                    $"Operation 'performMaintenance' is not allowed on VM '{vmScaleSet.Name}_0' " +
                    "since the Subscription of this VM is not eligible.";
                Assert.IsTrue(cex.Message.Contains(expectedMessage));
            }
            Assert.True(passed);
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSet Instances
        /// Reimage VMScaleSet Instances
        /// ReimageAll VMScaleSet Instances
        /// Stop VMScaleSet Instance
        /// ManualUpgrade VMScaleSet Instance
        /// Restart VMScaleSet Instance
        /// Deallocate VMScaleSet Instance
        /// Delete VMScaleSet Instance
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetBatchOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                createWithManagedDisks: true,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) => virtualMachineScaleSet.UpgradePolicy = new UpgradePolicy { Mode = UpgradeMode.Manual }
            );
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var virtualMachineScaleSetInstanceIDs = new VirtualMachineScaleSetVMInstanceIDs()
            {
                InstanceIds = { "0", "1" }
            };

            var virtualMachineScaleSetRequ = new VirtualMachineScaleSetVMInstanceRequiredIDs(new List<string>() { "0", "1" });
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartStartAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs));
            virtualMachineScaleSetInstanceIDs = new VirtualMachineScaleSetVMInstanceIDs()
            {
                InstanceIds = { "0", "1" }
            };
            VirtualMachineScaleSetReimageParameters virtualMachineScaleSetReimageParameters = new VirtualMachineScaleSetReimageParameters
            {
                InstanceIds = { "0", "1" }
            };
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartReimageAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetReimageParameters));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartReimageAllAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartPowerOffAsync(rgName, vmScaleSet.Name, null, virtualMachineScaleSetInstanceIDs));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartUpdateInstancesAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetRequ));

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartRestartAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeallocateAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs));
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteInstancesAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetRequ));
            passed = true;
            Assert.True(passed);
        }

        [Test]
        public async Task TestVMScaleSetBatchOperations_Redeploy()
        {
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            EnsureClientsInitialized(LocationEastUs2UpperCase);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                storageAccountOutput, imageRef, createWithManagedDisks: true,
                vmScaleSetCustomizer: virtualMachineScaleSet => virtualMachineScaleSet.UpgradePolicy =
                    new UpgradePolicy { Mode = UpgradeMode.Manual });
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            List<string> virtualMachineScaleSetInstanceIDs = new List<string> { "0", "1" };
            var virtualMachineScaleSetInstanceID = new VirtualMachineScaleSetVMInstanceIDs()
            {
                InstanceIds = { "0", "1" }
            };
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartRedeployAsync(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceID));
            passed = true;
            Assert.True(passed);
        }

        [Test]
        public async Task TestVMScaleSetBatchOperations_PerformMaintenance()
        {
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            VirtualMachineScaleSet vmScaleSet = null;

            bool passed = false;
            try
            {
                EnsureClientsInitialized(LocationEastUs2UpperCase);

                ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
                StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

                var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                    createWithManagedDisks: true,
                    vmScaleSetCustomizer: virtualMachineScaleSet => virtualMachineScaleSet.UpgradePolicy =
                        new UpgradePolicy { Mode = UpgradeMode.Manual });
                vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
                inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
                List<string> virtualMachineScaleSetInstanceIDs = new List<string> { "0", "1" };
                var virtualMachineScaleSetInstanceID = new VirtualMachineScaleSetVMInstanceIDs()
                {
                    InstanceIds = { "0", "1" }
                };
                await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartPerformMaintenanceAsync(rgName, vmScaleSet.Name,
                    virtualMachineScaleSetInstanceID));

                passed = true;
            }
            catch (Exception cex)
            {
                passed = true;
                string expectedMessage =
                    $"Operation 'performMaintenance' is not allowed on VM '{vmScaleSet.Name}_0' " +
                    "since the Subscription of this VM is not eligible.";
                Assert.IsTrue(cex.Message.Contains(expectedMessage));
            }
            Assert.True(passed);
        }
    }
}
