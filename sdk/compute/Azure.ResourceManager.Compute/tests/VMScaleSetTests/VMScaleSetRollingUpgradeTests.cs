// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetRollingUpgradeTests : VMScaleSetTestsBase
    {
        public VMScaleSetRollingUpgradeTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// Upgrade scale set with an extension
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetRollingUpgrade")]
        public async Task TestVMScaleSetRollingUpgrade()
        {
            EnsureClientsInitialized(LocationSouthCentralUs);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = {
                            GetTestVMSSVMExtension(),
                        }
            };

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                    vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            var getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.NotNull(getInstanceViewResponse);
            ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

            var getVMInstanceViewResponse = await VirtualMachineScaleSetVMsOperations.GetInstanceViewAsync(rgName, vmssName, "0");
            Assert.NotNull(getVMInstanceViewResponse);
            Assert.NotNull(getVMInstanceViewResponse.Value.VmHealth);
            Assert.AreEqual("HealthState/healthy", getVMInstanceViewResponse.Value.VmHealth.Status.Code);

            // Update the VMSS by adding an extension
            WaitSeconds(600);
            var vmssStatus = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);

            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.NotNull(getInstanceViewResponse);
            ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmssName));
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Perform a rolling OS upgrade
        /// Validate the rolling upgrade completed
        /// Perform another rolling OS upgrade
        /// Cancel the rolling upgrade
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetRollingUpgradeAPIs")]
        public async Task TestVMScaleSetRollingUpgradeAPIs()
        {
            EnsureClientsInitialized(LocationSouthCentralUs);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            imageRef.Version = "latest";

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                    vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                    vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                    {
                        EnableAutomaticOSUpgrade = false
                    };
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
            WaitSeconds(600);
            var vmssStatus = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetRollingUpgradesOperations.StartStartOSUpgradeAsync(rgName, vmssName));
            var rollingUpgradeStatus = await VirtualMachineScaleSetRollingUpgradesOperations.GetLatestAsync(rgName, vmssName);
            Assert.AreEqual(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Value.Progress.SuccessfulInstanceCount);

            var upgradeTask = await WaitForCompletionAsync(await VirtualMachineScaleSetRollingUpgradesOperations.StartStartOSUpgradeAsync(rgName, vmssName));
            vmssStatus = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetRollingUpgradesOperations.StartCancelAsync(rgName, vmssName));

            rollingUpgradeStatus = await VirtualMachineScaleSetRollingUpgradesOperations.GetLatestAsync(rgName, vmssName);

            Assert.True(rollingUpgradeStatus.Value.RunningStatus.Code == RollingUpgradeStatusCode.Cancelled);
            Assert.True(rollingUpgradeStatus.Value.Progress.PendingInstanceCount >= 0);
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Perform a rolling OS upgrade
        /// Validate Upgrade History
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetRollingUpgradeHistory")]
        public async Task TestVMScaleSetRollingUpgradeHistory()
        {
            EnsureClientsInitialized(LocationSouthCentralUs);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            imageRef.Version = "latest";

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                    vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
            WaitSeconds(600);
            var vmssStatus = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetRollingUpgradesOperations.StartStartOSUpgradeAsync(rgName, vmssName));
            var rollingUpgrade = VirtualMachineScaleSetsOperations.GetOSUpgradeHistoryAsync(rgName, vmssName);
            var rollingUpgradeHistory = await rollingUpgrade.ToEnumerableAsync();
            Assert.NotNull(rollingUpgradeHistory);
            Assert.True(rollingUpgradeHistory.Count() == 1);
            Assert.AreEqual(inputVMScaleSet.Sku.Capacity, rollingUpgradeHistory.First().Properties.Progress.SuccessfulInstanceCount);
        }

        /// <summary>
        /// Testing Automatic OS Upgrade Policy
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetAutomaticOSUpgradePolicies")]
        public async Task TestVMScaleSetAutomaticOSUpgradePolicies()
        {
            EnsureClientsInitialized(LocationWestCentralUs);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            imageRef.Version = "latest";

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                    vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                    {
                        DisableAutomaticRollback = false
                    };
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            // Set Automatic OS Upgrade
            inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade = true;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            // with automatic OS upgrade policy as null
            inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = null;
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
            Assert.NotNull(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy);
            Assert.True(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback == false);
            Assert.True(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade == true);

            // Toggle Disable Auto Rollback
            inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
            {
                DisableAutomaticRollback = true,
                EnableAutomaticOSUpgrade = false
            };
            await UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

            getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
        }

        // Does the following operations:
        // Create ResourceGroup
        // Create StorageAccount
        // Create VMSS in Automatic Mode
        // Perform an extension rolling upgrade
        // Delete ResourceGroup
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestVMScaleSetExtensionUpgradeAPIs")]
        public async Task TestVMScaleSetExtensionUpgradeAPIs()
        {
            EnsureClientsInitialized(LocationEastUs2);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            // Windows VM image
            ImageReference imageRef = await GetPlatformVMImage(true);
            imageRef.Version = "latest";
            var extension = GetTestVMSSVMExtension();
            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = {
                    extension,
                }
            };

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, "VMScaleSetDoesNotExist"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccountOutput,
                imageRef,
                extensionProfile,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = false;
                    vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Automatic;
                },
                createWithManagedDisks: true,
                createWithPublicIpAddress: false,
                createWithHealthProbe: true);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

            await WaitForCompletionAsync(await VirtualMachineScaleSetRollingUpgradesOperations.StartStartExtensionUpgradeAsync(rgName, vmssName));
            var rollingUpgradeStatus = await VirtualMachineScaleSetRollingUpgradesOperations.GetLatestAsync(rgName, vmssName);
            Assert.AreEqual(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Value.Progress.SuccessfulInstanceCount);
        }
    }
}
