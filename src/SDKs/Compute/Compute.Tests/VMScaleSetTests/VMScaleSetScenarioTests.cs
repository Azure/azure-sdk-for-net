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
    public class VMScaleSetScenarioTests : VMScaleSetVMTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations")]
        public void TestVMScaleSetScenarioOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestScaleSetOperationsInternal(context);
            }
        }

        /// <summary>
        /// Covers following Operations for ManagedDisks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                using (MockContext context = MockContext.Start(this.GetType().FullName))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, zones: new List<string> { "1" });
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                using (MockContext context = MockContext.Start(this.GetType().FullName))
                {
                    TestScaleSetOperationsInternal(
                        context, 
                        hasManagedDisks: true, 
                        useVmssExtension: false, 
                        zones: new List<string> { "1", "3" }, 
                        osDiskSizeInGB: 175);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        private void TestScaleSetOperationsInternal(MockContext context, bool hasManagedDisks = false, bool useVmssExtension = true, 
            IList<string> zones = null, int? osDiskSizeInGB = null)
        {
            EnsureClientsInitialized(context);

            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = TestUtilities.GenerateName(TestPrefix);
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetTestVMSSVMExtension(),
                }
            };

            try
            {
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                var getResponse = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    useVmssExtension ? extensionProfile : null,
                    (vmScaleSet) => { vmScaleSet.Overprovision = true; },
                    createWithManagedDisks: hasManagedDisks,
                    zones: zones,
                    osDiskSizeInGB: osDiskSizeInGB);

                ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                Assert.NotNull(getInstanceViewResponse);
                ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                var listResponse = m_CrpClient.VirtualMachineScaleSets.List(rgName);
                ValidateVMScaleSet(inputVMScaleSet, listResponse.FirstOrDefault(x => x.Name == vmssName), hasManagedDisks);

                var listSkusResponse = m_CrpClient.VirtualMachineScaleSets.ListSkus(rgName, vmssName);
                Assert.NotNull(listSkusResponse);
                Assert.False(listSkusResponse.Count() == 0);

                if (zones != null)
                {
                    var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                    query.SetFilter(vm => vm.LatestModelApplied == true);
                    var listVMsResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query);
                    Assert.False(listVMsResponse == null, "VMScaleSetVMs not returned");
                    Assert.True(listVMsResponse.Count() == inputVMScaleSet.Sku.Capacity);

                    foreach (var vmScaleSetVM in listVMsResponse)
                    {
                        string instanceId = vmScaleSetVM.InstanceId;
                        var getVMResponse = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmssName, instanceId);
                        ValidateVMScaleSetVM(inputVMScaleSet, instanceId, getVMResponse, hasManagedDisks);
                    }
                }

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
            }
            finally
            {
                //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}
