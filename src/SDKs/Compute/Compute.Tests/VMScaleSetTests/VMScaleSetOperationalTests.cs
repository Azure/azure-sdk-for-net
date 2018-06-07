// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetOperationalTests : VMScaleSetTestsBase
    {
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
        [Fact]
        public void TestVMScaleSetOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetOperationsInternal(context);
            }
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
        [Fact]
        public void TestVMScaleSetOperations_ManagedDisks()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetOperationsInternal(context, hasManagedDisks: true);
            }
        }

        private void TestVMScaleSetOperationsInternal(MockContext context, bool hasManagedDisks = false)
        {
            EnsureClientsInitialized(context);

            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            try
            {
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    createWithManagedDisks: hasManagedDisks);

                // TODO: AutoRest skips the following methods - Start, Restart, PowerOff, Deallocate
                m_CrpClient.VirtualMachineScaleSets.Start(rgName, vmScaleSet.Name);
                m_CrpClient.VirtualMachineScaleSets.Reimage(rgName, vmScaleSet.Name);
                if (hasManagedDisks)
                {
                    m_CrpClient.VirtualMachineScaleSets.ReimageAll(rgName, vmScaleSet.Name);
                }
                m_CrpClient.VirtualMachineScaleSets.Restart(rgName, vmScaleSet.Name);
                m_CrpClient.VirtualMachineScaleSets.PowerOff(rgName, vmScaleSet.Name);
                m_CrpClient.VirtualMachineScaleSets.Deallocate(rgName, vmScaleSet.Name);
                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);

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

        [Fact]
        public void TestVMScaleSetOperations_Redeploy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                        storageAccountOutput, imageRef, out inputVMScaleSet, createWithManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSets.Redeploy(rgName, vmScaleSet.Name);

                    passed = true;
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        [Fact]
        public void TestVMScaleSetOperations_PerformMaintenance()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                VirtualMachineScaleSet vmScaleSet = null;

                bool passed = false;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                        out inputVMScaleSet, createWithManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSets.PerformMaintenance(rgName, vmScaleSet.Name);

                    passed = true;
                }
                catch (CloudException cex)
                {
                    passed = true;
                    string expectedMessage =
                        $"Operation 'performMaintenance' is not allowed on VM '{vmScaleSet.Name}_0' " +
                        "since the Subscription of this VM is not eligible.";
                    Assert.Equal(expectedMessage, cex.Message);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
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
        [Fact]
        public void TestVMScaleSetBatchOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput, 
                        imageRef: imageRef, 
                        inputVMScaleSet: out inputVMScaleSet,
                        createWithManagedDisks: true,
                        vmScaleSetCustomizer: 
                            (virtualMachineScaleSet) => virtualMachineScaleSet.UpgradePolicy = new UpgradePolicy { Mode = UpgradeMode.Manual }
                    );

                    var virtualMachineScaleSetInstanceIDs = new List<string>() {"0", "1"};

                    m_CrpClient.VirtualMachineScaleSets.Start(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    virtualMachineScaleSetInstanceIDs = new List<string>() { "0" };
                    m_CrpClient.VirtualMachineScaleSets.Reimage(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.ReimageAll(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.PowerOff(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.UpdateInstances(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    virtualMachineScaleSetInstanceIDs = new List<string>() { "1" };
                    m_CrpClient.VirtualMachineScaleSets.Restart(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.Deallocate(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.DeleteInstances(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        [Fact]
        public void TestVMScaleSetBatchOperations_Redeploy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                        storageAccountOutput, imageRef, out inputVMScaleSet, createWithManagedDisks: true,
                        vmScaleSetCustomizer: virtualMachineScaleSet => virtualMachineScaleSet.UpgradePolicy =
                            new UpgradePolicy {Mode = UpgradeMode.Manual});

                    List<string> virtualMachineScaleSetInstanceIDs = new List<string> {"0", "1"};

                    m_CrpClient.VirtualMachineScaleSets.Redeploy(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);

                    passed = true;
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        [Fact]
        public void TestVMScaleSetBatchOperations_PerformMaintenance()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                VirtualMachineScaleSet vmScaleSet = null;

                bool passed = false;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                        out inputVMScaleSet, createWithManagedDisks: true,
                        vmScaleSetCustomizer: virtualMachineScaleSet => virtualMachineScaleSet.UpgradePolicy =
                            new UpgradePolicy {Mode = UpgradeMode.Manual});

                    List<string> virtualMachineScaleSetInstanceIDs = new List<string> { "0", "1" };

                    m_CrpClient.VirtualMachineScaleSets.PerformMaintenance(rgName, vmScaleSet.Name,
                        virtualMachineScaleSetInstanceIDs);

                    passed = true;
                }
                catch (CloudException cex)
                {
                    passed = true;
                    string expectedMessage =
                        $"Operation 'performMaintenance' is not allowed on VM '{vmScaleSet.Name}_0' " +
                        "since the Subscription of this VM is not eligible.";
                    Assert.Equal(expectedMessage, cex.Message);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}