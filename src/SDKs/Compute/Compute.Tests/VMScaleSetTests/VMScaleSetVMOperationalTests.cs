// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetVMOperationalTests : VMScaleSetVMTestsBase
    {
        private string rgName, vmssName, storageAccountName, instanceId;
        private ImageReference imageRef;
        private VirtualMachineScaleSet inputVMScaleSet;

        private void InitializeCommon(MockContext context)
        {
            EnsureClientsInitialized(context);

            imageRef = GetPlatformVMImage(useWindowsImage: true);
            rgName = TestUtilities.GenerateName(TestPrefix) + 1;
            vmssName = TestUtilities.GenerateName("vmss");
            storageAccountName = TestUtilities.GenerateName(TestPrefix);
        }

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
            InitializeCommon(context);
            instanceId = "0";

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

        /// <summary>
        /// Covers following Operations for a VMSS VM with managed disks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSetVM
        /// RunCommand VMScaleSetVM
        /// Delete VMScaleSetVM
        /// Delete RG
        [Fact]
        public void TestVMScaleSetVMOperations_RunCommand()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeCommon(context);
                instanceId = "0";
                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet,
                        createWithManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSetVMs.Start(rgName, vmScaleSet.Name, instanceId);

                    RunCommandResult result = m_CrpClient.VirtualMachineScaleSetVMs.RunCommand(rgName, vmScaleSet.Name, instanceId, new RunCommandInput() { CommandId = "ipconfig" });
                    Assert.NotNull(result);
                    Assert.NotNull(result.Value);
                    Assert.True(result.Value.Count > 0);

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

        /// <summary>
        /// Covers following Operations for a VMSS VM with managed disks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Get VMScaleSetVM Model View
        /// Create DataDisk
        /// Update VirtualMachineScaleVM to Attach Disk
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations_Put()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
                bool passed = false;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                    InitializeCommon(context);
                    instanceId = "0";

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet, createWithManagedDisks: true);

                    VirtualMachineScaleSetVM vmssVM = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmScaleSet.Name, instanceId);

                    VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId, hasManagedDisks: true);
                    ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, vmssVM, hasManagedDisks: true);

                    AttachDataDiskToVMScaleSetVM(vmssVM, vmScaleSetVMModel, 2);

                    VirtualMachineScaleSetVM vmssVMReturned = m_CrpClient.VirtualMachineScaleSetVMs.Update(rgName, vmScaleSet.Name, vmssVM.InstanceId, vmssVM);
                    ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, vmssVMReturned, hasManagedDisks: true);

                    passed = true;
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Covers following operations:
        /// Create RG
        /// Create VM Scale Set
        /// Redeploy one instance of VM Scale Set
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations_Redeploy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                instanceId = "0";
                bool passed = false;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    InitializeCommon(context);

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                        storageAccountOutput, imageRef, out inputVMScaleSet, createWithManagedDisks: true);
                    m_CrpClient.VirtualMachineScaleSetVMs.Redeploy(rgName, vmScaleSet.Name, instanceId);

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

        /// <summary>
        /// Covers following operations:
        /// Create RG
        /// Create VM Scale Set
        /// Perform maintenance on one instance of VM Scale Set
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations_PerformMaintenance()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                instanceId = "0";
                VirtualMachineScaleSet vmScaleSet = null;

                bool passed = false;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "EastUS2");
                    InitializeCommon(context);

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                        out inputVMScaleSet, createWithManagedDisks: true);
                    m_CrpClient.VirtualMachineScaleSetVMs.PerformMaintenance(rgName, vmScaleSet.Name, instanceId);

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

        private Disk CreateDataDisk(string diskName)
        {
            var disk = new Disk
            {
                Location = m_location,
                DiskSizeGB = 10,
            };
            disk.Sku = new DiskSku()
            {
                Name = StorageAccountTypes.StandardLRS
            };
            disk.CreationData = new CreationData()
            {
                CreateOption = DiskCreateOption.Empty
            };

            return m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
        }

        private DataDisk CreateModelDataDisk(Disk disk)
        {
            var modelDisk = new DataDisk
            {
                DiskSizeGB = disk.DiskSizeGB,
                CreateOption = DiskCreateOptionTypes.Attach
            };

            return modelDisk;
        }

        private void AttachDataDiskToVMScaleSetVM(VirtualMachineScaleSetVM vmssVM, VirtualMachineScaleSetVM vmModel, int lun)
        {
            if(vmssVM.StorageProfile.DataDisks == null)
                vmssVM.StorageProfile.DataDisks = new List<DataDisk>();

            if (vmModel.StorageProfile.DataDisks == null)
                vmModel.StorageProfile.DataDisks = new List<DataDisk>();

            var diskName = TestPrefix + "dataDisk" + lun;

            var disk = CreateDataDisk(diskName);

            var dd = new DataDisk
            {
                CreateOption = DiskCreateOptionTypes.Attach,
                Lun = lun,
                Name = diskName,
                ManagedDisk = new ManagedDiskParameters()
                {
                    Id = disk.Id,
                    StorageAccountType = disk.Sku.Name
                }
            };

            vmssVM.StorageProfile.DataDisks.Add(dd);

            // Add the data disk to the model for validation later
            vmModel.StorageProfile.DataDisks.Add(CreateModelDataDisk(disk));
        }
    }
}