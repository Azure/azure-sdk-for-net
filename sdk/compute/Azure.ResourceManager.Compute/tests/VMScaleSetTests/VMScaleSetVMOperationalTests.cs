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
    public class VMScaleSetVMOperationalTests : VMScaleSetVMTestsBase
    {
        public VMScaleSetVMOperationalTests(bool isAsync)
        : base(isAsync)
        {
        }
        private string rgName, vmssName, storageAccountName, instanceId;
        private ImageReference imageRef;
        private VirtualMachineScaleSet inputVMScaleSet;

        private async void InitializeCommon()
        {
            imageRef = await GetPlatformVMImage(useWindowsImage: true);
            rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            vmssName = Recording.GenerateAssetName("vmss");
            storageAccountName = Recording.GenerateAssetName(TestPrefix);
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
        [Test]
        public async Task TestVMScaleSetVMOperations()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestVMScaleSetVMOperationsInternal(false);
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
        [Test]
        public async Task TestVMScaleSetVMOperations_ManagedDisks()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestVMScaleSetVMOperationsInternal(true);
        }

        private async Task TestVMScaleSetVMOperationsInternal(bool hasManagedDisks = false)
        {
            InitializeCommon();
            instanceId = "0";

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName, vmssName, storageAccountOutput, imageRef,
                createWithManagedDisks: hasManagedDisks);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var getResponse = (await VirtualMachineScaleSetVMsOperations.GetAsync(rgName, vmScaleSet.Name, instanceId)).Value;

            var imageReference = getResponse.StorageProfile.ImageReference;
            Assert.NotNull(imageReference?.ExactVersion);
            Assert.AreEqual(imageReference.Version, imageReference.ExactVersion);

            VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId, hasManagedDisks);
            ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, getResponse, hasManagedDisks);

            var getInstanceViewResponse = await VirtualMachineScaleSetVMsOperations.GetInstanceViewAsync(rgName,
                vmScaleSet.Name, instanceId);
            Assert.True(getInstanceViewResponse != null, "VMScaleSetVM not returned.");
            ValidateVMScaleSetVMInstanceView(getInstanceViewResponse, hasManagedDisks);

            //var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
            //query.SetFilter(vm => vm.LatestModelApplied == true);
            var query = "properties/latestModelApplied eq true";
            var listResponse = await (VirtualMachineScaleSetVMsOperations.ListAsync(rgName, vmssName, query)).ToEnumerableAsync();
            Assert.False(listResponse == null, "VMScaleSetVMs not returned");
            Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);

            query = null;
            //query.Filter = null;
            //query.Expand = "instanceView";
            listResponse = await (VirtualMachineScaleSetVMsOperations.ListAsync(rgName, vmssName, query, null, "instanceView")).ToEnumerableAsync();
            Assert.False(listResponse == null, "VMScaleSetVMs not returned");
            Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);

            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartStartAsync(rgName, vmScaleSet.Name, instanceId));
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartReimageAsync(rgName, vmScaleSet.Name, instanceId));

            if (hasManagedDisks)
            {
                await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartReimageAllAsync(rgName, vmScaleSet.Name, instanceId));
            }
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartRestartAsync(rgName, vmScaleSet.Name, instanceId));
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartPowerOffAsync(rgName, vmScaleSet.Name, instanceId));
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartDeallocateAsync(rgName, vmScaleSet.Name, instanceId));
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartDeleteAsync(rgName, vmScaleSet.Name, instanceId));
            passed = true;
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
        /// </summary>
        [Test]
        public async Task TestVMScaleSetVMOperations_RunCommand()
        {
            EnsureClientsInitialized(DefaultLocation);
            InitializeCommon();
            instanceId = "0";
            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName, vmssName, storageAccountOutput, imageRef,
                createWithManagedDisks: true);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartStartAsync(rgName, vmScaleSet.Name, instanceId));

            RunCommandResult result = (await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartRunCommandAsync(rgName, vmScaleSet.Name, instanceId, new RunCommandInput("ipconfig")))).Value;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True(result.Value.Count > 0);
            passed = true;
            Assert.True(passed);
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
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestVMScaleSetVMOperations_Put()
        {
            bool passed = false;
            EnsureClientsInitialized("westus2");
            InitializeCommon();
            instanceId = "0";

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName, vmssName, storageAccountOutput, imageRef, createWithManagedDisks: true, machineSizeType: VirtualMachineSizeTypes.StandardA1V2.ToString());
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            VirtualMachineScaleSetVM vmssVM = await VirtualMachineScaleSetVMsOperations.GetAsync(rgName, vmScaleSet.Name, instanceId);

            VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId, hasManagedDisks: true);
            ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, vmssVM, hasManagedDisks: true);
            await AttachDataDiskToVMScaleSetVM(vmssVM, vmScaleSetVMModel, 2);
            VirtualMachineScaleSetVM vmssVMReturned = (await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartUpdateAsync(rgName, vmScaleSet.Name, vmssVM.InstanceId, vmssVM))).Value;
            ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, vmssVMReturned, hasManagedDisks: true);
            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Covers following operations:
        /// Create RG
        /// Create VM Scale Set
        /// Redeploy one instance of VM Scale Set
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetVMOperations_Redeploy()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            instanceId = "0";
            bool passed = false;

            InitializeCommon();

            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName,
                storageAccountOutput, imageRef, createWithManagedDisks: true);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            await VirtualMachineScaleSetVMsOperations.StartRedeployAsync(rgName, vmScaleSet.Name, instanceId);

            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Covers following operations:
        /// Create RG
        /// Create VM Scale Set
        /// Perform maintenance on one instance of VM Scale Set
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMScaleSetVMOperations_PerformMaintenance()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase);
            instanceId = "0";
            VirtualMachineScaleSet vmScaleSet = null;

            bool passed = false;

            try
            {
                InitializeCommon();

                var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
                var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef,
                    createWithManagedDisks: true);
                vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
                inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
                await WaitForCompletionAsync(await VirtualMachineScaleSetVMsOperations.StartPerformMaintenanceAsync(rgName, vmScaleSet.Name, instanceId));

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

        private async Task<Disk> CreateDataDisk(string diskName)
        {
            var disk = new Disk(null, null, null, TestEnvironment.Location, null, null, null, null, null, null, null, null, null, 10, null, null, null, null, null, null, null, null, null, null, null, null);
            disk.Sku = new DiskSku(StorageAccountTypes.StandardLRS.ToString(), null);
            disk.CreationData = new CreationData(DiskCreateOption.Empty);
            return await WaitForCompletionAsync((await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk)));
        }

        private DataDisk CreateModelDataDisk(Disk disk)
        {
            var modelDisk = new DataDisk(0, null, null, null, null, null, DiskCreateOptionTypes.Attach, disk.DiskSizeGB, null, null, null, null);

            return modelDisk;
        }

        private async Task AttachDataDiskToVMScaleSetVM(VirtualMachineScaleSetVM vmssVM, VirtualMachineScaleSetVM vmModel, int lun)
        {
            var diskName = TestPrefix + "dataDisk" + lun;

            var disk = await CreateDataDisk(diskName);

            var dd = new DataDisk(lun, DiskCreateOptionTypes.Attach)
            {
                Name = diskName,
                ManagedDisk = new ManagedDiskParameters()
                {
                    Id = disk.Id,
                    StorageAccountType = changeType(disk.Sku.Name)
                }
            };

            //(lun, diskName, null, null, null, DiskCreateOptionTypes.Attach, null, new ManagedDiskParameters(disk.Id,disk.Sku.Name,null), null, null, null);

            vmssVM.StorageProfile.DataDisks.Add(dd);

            // Add the data disk to the model for validation later
            vmModel.StorageProfile.DataDisks.Add(CreateModelDataDisk(disk));
        }

        public StorageAccountTypes? changeType(DiskStorageAccountTypes? DiskStorageAccountTypes)
        {
            StorageAccountTypes? storageAccountTypes = new StorageAccountTypes?(DiskStorageAccountTypes.ToString());
            return storageAccountTypes;
        }
    }
}
