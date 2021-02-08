// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMFlexTests : VMFlexTestsBase
    {
        [Fact]
        public void TestCustomerAssignedFaultDomain()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                var image = m_CrpClient.VirtualMachineImages.Get(
                    this.m_location, imageRef.Publisher, imageRef.Offer, imageRef.Sku, imageRef.Version);
                Assert.True(image != null);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);

                try
                {                  
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    CreateFlexVM(rgName, vmssName, storageAccountName, imageRef, out VirtualMachine createdFlexVM, (vm) =>
                    {
                        vm.PlatformFaultDomain = 1;
                    });

                    Assert.Equal(1, createdFlexVM.PlatformFaultDomain);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
