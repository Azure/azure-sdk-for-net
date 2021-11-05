// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Compute;
using System;

namespace Compute.Tests
{
    public class VMDeleteOptionTests : VMTestBase
    {
        [Fact]
        [Trait("Name", "TestDeleteOptionForDisks")]
        public void TestDeleteOptionForDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Hard code the location to "eastus2euap".
                // This is because NRP is still deploying to other regions and is not available worldwide.
                // Before changing the default location, we have to save it to be reset it at the end of the test.
                // Since ComputeManagementTestUtilities.DefaultLocation is a static variable and can affect other tests if it is not reset.
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachine inputVMIgnored;
                    VirtualMachine createdVM = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVMIgnored, hasManagedDisks: true);

                    Assert.Equal(DiskDeleteOptionTypes.Detach, createdVM.StorageProfile.OsDisk.DeleteOption);

                    foreach (DataDisk disk in createdVM.StorageProfile.DataDisks)
                    {
                        Assert.Equal(DiskDeleteOptionTypes.Detach, disk.DeleteOption);
                    }

                    m_CrpClient.VirtualMachines.Delete(rgName, createdVM.Name);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
