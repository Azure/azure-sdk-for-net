// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetVMOperationalTests : VMScaleSetVMTestsBase 
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Get VMScaleSetVM Model View
        /// Get VMScaleSetVM Instance View
        /// List VMScaleSetVMs Model View
        /// List VMScaleSetVMs Instance View
        /// Start VMScaleSetVM
        /// Stop VMScaleSetVM
        /// Restart VMScaleSetVM
        /// Deallocate VMScaleSetVM
        /// Delete VMScaleSetVM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetVMOperationsInternal(context);
            }
        }

        /// <summary>
        /// Covers following Operations for a VMSS VM with managed disks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Get VMScaleSetVM Model View
        /// Get VMScaleSetVM Instance View
        /// List VMScaleSetVMs Model View
        /// List VMScaleSetVMs Instance View
        /// Start VMScaleSetVM
        /// Reimage VMScaleSetVM
        /// ReimageAll VMScaleSetVM
        /// Stop VMScaleSetVM
        /// Restart VMScaleSetVM
        /// Deallocate VMScaleSetVM
        /// Delete VMScaleSetVM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations_ManagedDisks()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetVMOperationsInternal(context, true);
            }
        }

        private void TestVMScaleSetVMOperationsInternal(MockContext context, bool hasManagedDisks = false)
        {
            EnsureClientsInitialized(context);

            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
            string vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            const string instanceId = "0";
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            try
            {
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                    rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet,
                    createWithManagedDisks: hasManagedDisks);

                var getResponse = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmScaleSet.Name, instanceId);

                VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId, hasManagedDisks);
                ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, getResponse, hasManagedDisks);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSetVMs.GetInstanceView(rgName,
                    vmScaleSet.Name, instanceId);
                Assert.True(getInstanceViewResponse != null, "VMScaleSetVM not returned.");
                ValidateVMScaleSetVMInstanceView(getInstanceViewResponse, hasManagedDisks);

                var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                query.SetFilter(vm => vm.LatestModelApplied == true);
                var listResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query);
                Assert.False(listResponse == null, "VMScaleSetVMs not returned");
                Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);

                query.Filter = null;
                query.Expand = "instanceView";
                listResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query, "instanceView");
                Assert.False(listResponse == null, "VMScaleSetVMs not returned");
                Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);

                m_CrpClient.VirtualMachineScaleSetVMs.Start(rgName, vmScaleSet.Name, instanceId);
                m_CrpClient.VirtualMachineScaleSetVMs.Reimage(rgName, vmScaleSet.Name, instanceId);

                if (hasManagedDisks)
                {
                    m_CrpClient.VirtualMachineScaleSetVMs.ReimageAll(rgName, vmScaleSet.Name, instanceId);
                }

                m_CrpClient.VirtualMachineScaleSetVMs.Restart(rgName, vmScaleSet.Name, instanceId);
                m_CrpClient.VirtualMachineScaleSetVMs.PowerOff(rgName, vmScaleSet.Name, instanceId);
                m_CrpClient.VirtualMachineScaleSetVMs.Deallocate(rgName, vmScaleSet.Name, instanceId);
                m_CrpClient.VirtualMachineScaleSetVMs.Delete(rgName, vmScaleSet.Name, instanceId);

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
    }
}