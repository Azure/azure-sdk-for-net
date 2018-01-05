// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPManagedByTests : DiskRPTestsBase
    {
        /// <summary>
        /// This test tests the new managedby feature that is replacing ownerid.
        /// It creates a VM, then gets the disk from that VM to check for the vm name in the manageby field
        /// </summary>
        [Fact]
        public void DiskManagedByTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);

                // Create a VM, so we can use its OS disk for testing managedby
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(DiskNamePrefix);
                string avSet = ComputeManagementTestUtilities.GenerateName("avSet");
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                VirtualMachine inputVM = null;

                // Create Storage Account for creating vm
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                // Create the VM, whose OS disk will be used in creating the image
                var createdVM = CreateVM_NoAsyncTracking(rgName, avSet, storageAccountOutput, imageRef, out inputVM, hasManagedDisks: true);
                var listResponse = m_CrpClient.VirtualMachines.ListAll();
                Assert.True(listResponse.Count() >= 1);
                var vmName = createdVM.Name;
                var vmDiskName = createdVM.StorageProfile.OsDisk.Name;

                //get disk from VM
                Disk diskFromVM = m_CrpClient.Disks.Get(rgName, vmDiskName);

                //managedby should have format: "/subscriptions/{subId}/resourceGroups/{rg}/Microsoft.Compute/virtualMachines/vm1"
                Assert.Contains(vmName, diskFromVM.ManagedBy);

                m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                m_CrpClient.VirtualMachines.Delete(rgName, createdVM.Name);
                m_CrpClient.Disks.Delete(rgName, diskName);
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}
