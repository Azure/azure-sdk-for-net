// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Compute.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class VMScaleSetPriorityTests : VMScaleSetTestsBase
    {
        #region Priority Tests

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
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Regular")]
        public void TestVMScaleSetPriorityOperations_Accept_Regular()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Regular);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Low")]
        public void TestVMScaleSetPriorityOperations_Accept_Low()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create low priority scaleset with no eviction policy specified. Eviction policy is defaulted to Deallocate.
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Low, hasManagedDisks: true);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Spot")]
        public void TestVMScaleSetScenarioOperations_Accept_Spot()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create Azure Spot scaleset with no eviction policy specified. Eviction policy is defaulted to Deallocate.
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Spot, hasManagedDisks: true);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetEvictionPolicyOperations_Accept_DeleteEvictionPolicy")]
        public void TestVMScaleSetEvictionPolicyOperations_Accept_DeleteEvictionPolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create low priority scaleset with 'delete' eviction policy specified
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Low, evictionPolicy: VirtualMachineEvictionPolicyTypes.Delete, hasManagedDisks: true);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetVariablePricedLowPriorityVM_Accept_DefaultMaxPrice")]
        public void TestVMScaleSetVariablePricedLowPriorityVM_Accept_DefaultMaxPrice()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Low, new BillingProfile { MaxPrice = -1 }, hasManagedDisks: true);
            }
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
        [Fact]
        [Trait("Name", "TestVMScaleSetVariablePricedLowPriorityVM_Accept_UserSpecifiedMaxPrice")]
        public void TestVMScaleSetVariablePricedLowPriorityVM_Accept_UserSpecifiedMaxPrice()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Low, new BillingProfile { MaxPrice = 100 }, hasManagedDisks: true);
            }
        }

        #endregion

        private void TestVMScaleSetPriorityOperationsInternal(
            MockContext context,
            string priority,
            BillingProfile billingProfile = null,
            string evictionPolicy = null,
            bool hasManagedDisks = false,
            IList<string> zones = null
            )
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

            // Create resource group
            var rgName = TestUtilities.GenerateName(TestPrefix);
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                EnsureClientsInitialized(context);
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                var getResponse = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    null,
                    (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = true;
                            vmScaleSet.VirtualMachineProfile.Priority = priority;
                            vmScaleSet.VirtualMachineProfile.EvictionPolicy = evictionPolicy;
                            vmScaleSet.VirtualMachineProfile.BillingProfile = billingProfile;

                            vmScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1;
                            vmScaleSet.Sku.Tier = "Standard";
                            vmScaleSet.Sku.Capacity = 2;
                        },
                    createWithManagedDisks: hasManagedDisks,
                    zones: zones);

                ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                Assert.NotNull(getInstanceViewResponse);
                ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                var listResponse = m_CrpClient.VirtualMachineScaleSets.List(rgName);
                ValidateVMScaleSet(
                    inputVMScaleSet,
                    listResponse.FirstOrDefault(x => x.Name == vmssName),
                    hasManagedDisks);

                var listSkusResponse = m_CrpClient.VirtualMachineScaleSets.ListSkus(rgName, vmssName);
                Assert.NotNull(listSkusResponse);
                Assert.False(listSkusResponse.Count() == 0);
                Assert.Same(inputVMScaleSet.VirtualMachineProfile.Priority.ToString(), priority);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}

