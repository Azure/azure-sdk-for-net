// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPManagedByTests : DiskRPTestsBase
    {
        public DiskRPManagedByTests(bool isAsync)
        : base(isAsync)
        {
        }

        /// <summary>
        /// This test tests the new managedby feature that is replacing ownerid.
        /// It creates a VM, then gets the disk from that VM to check for the vm name in the manageby field
        /// </summary>
        [Test]
        public async Task DiskManagedByTest()
        {
            EnsureClientsInitialized(DefaultLocation);
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            // Create a VM, so we can use its OS disk for testing managedby
            string storageAccountName = Recording.GenerateAssetName(DiskNamePrefix);
            string avSet = Recording.GenerateAssetName("avSet");
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            VirtualMachine inputVM = null;
            // Create Storage Account for creating vm
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            // Create the VM, whose OS disk will be used in creating the image
            var returnTwovm = await CreateVM(rgName, avSet, storageAccountOutput, imageRef, hasManagedDisks: true);
            var createdVM = returnTwovm.Item1;
            inputVM = returnTwovm.Item2;
            var listResponse = (await VirtualMachinesOperations.ListAllAsync().ToEnumerableAsync());
            Assert.True(listResponse.Count() >= 1);
            var vmName = createdVM.Name;
            var vmDiskName = createdVM.StorageProfile.OsDisk.Name;
            //get disk from VM
            Disk diskFromVM = await DisksOperations.GetAsync(rgName, vmDiskName);
            //managedby should have format: "/subscriptions/{subId}/resourceGroups/{rg}/Microsoft.Compute/virtualMachines/vm1"
            //Assert.Contains(vmName, diskFromVM.ManagedBy);
            Assert.True(diskFromVM.ManagedBy.Contains(vmName));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, createdVM.Name));
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }
    }
}
