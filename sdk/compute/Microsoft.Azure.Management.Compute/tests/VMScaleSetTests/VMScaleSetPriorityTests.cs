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
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class VMScaleSetPriorityTests : VMScaleSetTestsBase
    {
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Regular);
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
        [Trait("Name", "TestVMScaleSetScenarioOperations_Accept_Low")]
        public void TestVMScaleSetPriorityOperations_Accept_Low()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetPriorityOperationsInternal(context, VirtualMachinePriorityTypes.Low);
            }
        }

        private void TestVMScaleSetPriorityOperationsInternal(
            MockContext context,
            string priority,
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
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "westcentralus");
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

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create Low Priority VMScaleSet with no EvictionPolicy specified
        /// Create Low Priority VMScaleSet with 'Delete' EvictionPolicy specified
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetEvictionPolicyOperations")]
        public void TestVMScaleSetEvictionPolicyOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "westcentralus");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    // Create low priority scaleset with no eviction policy specified
                    TestVMScaleSetEvictionPolicyInternal(rgName, storageAccountOutput, imageRef);

                    // Create low priority scaleset with 'delete' eviction policy specified
                    TestVMScaleSetEvictionPolicyInternal(rgName, storageAccountOutput, imageRef, VirtualMachineEvictionPolicyTypes.Delete);
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

        private void TestVMScaleSetEvictionPolicyInternal(
            string rgName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            string evictionPolicy = null)
        {
            VirtualMachineScaleSet inputVMScaleSet;

            var vmssName = TestUtilities.GenerateName("vmss");

            var getResponse = CreateVMScaleSet_NoAsyncTracking(
                rgName,
                vmssName,
                storageAccount,
                imageRef,
                out inputVMScaleSet,
                null,
                (vmScaleSet) =>
                {
                    vmScaleSet.Overprovision = true;
                    vmScaleSet.VirtualMachineProfile.Priority = VirtualMachinePriorityTypes.Low;
                    if (evictionPolicy != null) vmScaleSet.VirtualMachineProfile.EvictionPolicy = evictionPolicy;
                    vmScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1;
                    vmScaleSet.Sku.Tier = "Standard";
                    vmScaleSet.Sku.Capacity = 2;
                });

            ValidateVMScaleSet(inputVMScaleSet, getResponse);

            evictionPolicy = evictionPolicy ?? VirtualMachineEvictionPolicyTypes.Deallocate;

            Assert.Equal(getResponse.VirtualMachineProfile.EvictionPolicy.ToString(), evictionPolicy);

            m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
        }
    }
}
