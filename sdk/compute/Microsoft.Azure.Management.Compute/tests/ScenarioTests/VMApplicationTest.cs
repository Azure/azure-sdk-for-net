// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using Xunit;

namespace Compute.Tests
{
    public class VMApplicationTest : VMTestBase
    {
        [Fact]
        public void VMApplicationProfile_Tests()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centraluseuap");
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                var image = m_CrpClient.VirtualMachineImages.Get(
                    this.m_location, imageRef.Publisher, imageRef.Offer, imageRef.Sku, imageRef.Version);
                Assert.True(image != null);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    IList<VMGalleryApplication> galleryApplications = new List<VMGalleryApplication>()
                    {
                        // when re-recording the test ensure that you use a valid packageReferenceId
                        // refer to https://microsoft.sharepoint.com/:w:/t/ComputeVM/EcYeD-HHrLZHpYyxo3iRCtkB-VeO8BuWE4dq4hoX9tlzEg?e=nOTgTu
                        // for how to create a valid VMApplication
                        new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma/providers/Microsoft.Compute/galleries/bhbrahmaGallery/applications/go/versions/1.15.8")
                    };

                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, (vm) =>
                    {
                        vm.StorageProfile.OsDisk.DiskSizeGB = 150;
                        vm.ApplicationProfile = new ApplicationProfile(galleryApplications);
                    });

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                    ValidateVM(inputVM, getVMResponse, Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));
                    Assert.NotNull(getVMResponse.ApplicationProfile);
                    Assert.NotNull(getVMResponse.ApplicationProfile.GalleryApplications);
                    Assert.Equal(1, getVMResponse.ApplicationProfile.GalleryApplications.Count);
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
