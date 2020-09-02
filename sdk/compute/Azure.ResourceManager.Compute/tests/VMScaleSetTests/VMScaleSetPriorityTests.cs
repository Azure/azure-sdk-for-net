// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetPriorityTests : VMScaleSetTestsBase
    {
        public VMScaleSetPriorityTests(bool isAsync)
        : base(isAsync)
        {
        }
        #region
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Regular")]
        public async Task TestVMScaleSetPriorityOperations_Accept_Regular()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Regular.ToString());
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create Low Priority VMScaleSet with no EvictionPolicy specified
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Low")]
        public async Task TestVMScaleSetPriorityOperations_Accept_Low()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            // Create low priority scaleset with no eviction policy specified. Eviction policy is defaulted to Deallocate.
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Low.ToString(), hasManagedDisks: true);
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create Azure Spot VMScaleSet with no EvictionPolicy specified
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Spot")]
        public async Task TestVMScaleSetScenarioOperations_Accept_Spot()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            // Create Azure Spot scaleset with no eviction policy specified. Eviction policy is defaulted to Deallocate.
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Spot.ToString(), hasManagedDisks: true);
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create Low Priority VMScaleSet with 'Delete' EvictionPolicy specified
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetEvictionPolicyOperations_Accept_DeleteEvictionPolicy")]
        public async Task TestVMScaleSetEvictionPolicyOperations_Accept_DeleteEvictionPolicy()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            // Create low priority scaleset with 'delete' eviction policy specified
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Low.ToString(), evictionPolicy: VirtualMachineEvictionPolicyTypes.Delete.ToString(), hasManagedDisks: true);
        }

        #endregion

        #region Variable Pricing Tests

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetVariablePricedLowPriorityVM_Accept_DefaultMaxPrice")]
        public async Task TestVMScaleSetVariablePricedLowPriorityVM_Accept_DefaultMaxPrice()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Low.ToString(), new BillingProfile { MaxPrice = -1 }, hasManagedDisks: true);
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Test]
        //[Trait("Name", "TestVMScaleSetVariablePricedLowPriorityVM_Accept_UserSpecifiedMaxPrice")]
        public async Task TestVMScaleSetVariablePricedLowPriorityVM_Accept_UserSpecifiedMaxPrice()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            await TestVMScaleSetPriorityOperationsInternal(VirtualMachinePriorityTypes.Low.ToString(), new BillingProfile { MaxPrice = 100 }, hasManagedDisks: true);
        }

        #endregion

        private async Task TestVMScaleSetPriorityOperationsInternal(
            string priority,
            BillingProfile billingProfile = null,
            VirtualMachineEvictionPolicyTypes? evictionPolicy = null,
            bool hasManagedDisks = false,
            IList<string> zones = null
            )
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

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
                    vmScaleSet.Overprovision = true;
                    vmScaleSet.VirtualMachineProfile.Priority = priority;
                    vmScaleSet.VirtualMachineProfile.EvictionPolicy = evictionPolicy;
                    vmScaleSet.VirtualMachineProfile.BillingProfile = billingProfile;

                    vmScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1.ToString();
                    vmScaleSet.Sku.Tier = "Standard";
                    vmScaleSet.Sku.Capacity = 2;
                },
                createWithManagedDisks: hasManagedDisks,
                zones: zones);
            VirtualMachineScaleSet getResponse = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks);

            var getInstanceViewResponse = await VirtualMachineScaleSetsOperations.GetInstanceViewAsync(rgName, vmssName);
            Assert.NotNull(getInstanceViewResponse);
            ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

            var listResponse = await (VirtualMachineScaleSetsOperations.ListAsync(rgName)).ToEnumerableAsync();
            ValidateVMScaleSet(
                inputVMScaleSet,
                listResponse.FirstOrDefault(x => x.Name == vmssName),
                hasManagedDisks);

            var listSkusResp = VirtualMachineScaleSetsOperations.ListSkusAsync(rgName, vmssName);
            var listSkusResponse = await listSkusResp.ToEnumerableAsync();
            Assert.NotNull(listSkusResponse);
            Assert.False(listSkusResponse.Count() == 0);
            Assert.AreEqual(inputVMScaleSet.VirtualMachineProfile.Priority.ToString(), priority);
            //Assert.Same(inputVMScaleSet.VirtualMachineProfile.Priority.ToString(), priority);

            await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmssName));
        }
    }
}
