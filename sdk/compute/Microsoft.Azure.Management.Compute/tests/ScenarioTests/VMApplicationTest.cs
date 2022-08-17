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
                        new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma/providers/Microsoft.Compute/galleries/bhbrahmaGallery/applications/go/versions/1.15.8", treatFailureAsDeploymentFailure: true, enableAutomaticUpgrade: true)
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
                    VMGalleryApplication vmGalleryApplication = getVMResponse.ApplicationProfile.GalleryApplications[0];
                    Assert.True(vmGalleryApplication.TreatFailureAsDeploymentFailure);
                    Assert.True(vmGalleryApplication.EnableAutomaticUpgrade);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void VMApplicationController_Tests()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // use existing rg and vm for testing
                var rgName = "bhbrahma_testing";
                string vmName = "win10";
                // when re-recording the test ensure that you use a valid packageReferenceId
                // refer to https://microsoft.sharepoint.com/:w:/t/ComputeVM/EcYeD-HHrLZHpYyxo3iRCtkB-VeO8BuWE4dq4hoX9tlzEg?e=nOTgTu
                // for how to create a valid VMApplication
                (string applicationName, VMGalleryApplication v1, VMGalleryApplication v2) golang =
                    (
                        "golang",
                        new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/golang/versions/1.15.8", treatFailureAsDeploymentFailure: true),
                        new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/golang/versions/1.19.0", treatFailureAsDeploymentFailure: true)
                    );
                (string applicationName, VMGalleryApplication v1) firefox =
                    (
                        "firefox",
                        new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/firefox/versions/103.0.2", treatFailureAsDeploymentFailure: true)
                    );

                VirtualMachine testVM;
                try
                {
                    testVM = m_CrpClient.VirtualMachines.Get(rgName, vmName);
                    IList<VMGalleryApplication> galleryApplications = new List<VMGalleryApplication>()
                    {
                        golang.v1,
                    };

                    m_CrpClient.VirtualMachines.Update(rgName, vmName, new VirtualMachineUpdate(applicationProfile: new ApplicationProfile(galleryApplications)));

                    // test list
                    VirtualMachineApplicationsListResult listResult = m_CrpClient.VirtualMachineApplications.List(rgName, testVM.Name);
                    Assert.Single(listResult.Value);
                    Assert.Equal(galleryApplications[0].PackageReferenceId, listResult.Value[0].PackageReferenceId);

                    // add app 
                    VMGalleryApplication putResult = m_CrpClient.VirtualMachineApplications.Put(rgName, testVM.Name, firefox.applicationName, firefox.v1);
                    Assert.Equal(firefox.v1.PackageReferenceId, putResult.PackageReferenceId);
                    listResult = m_CrpClient.VirtualMachineApplications.List(rgName, testVM.Name);
                    Assert.Equal(2, listResult.Value.Count);

                    // update app
                    m_CrpClient.VirtualMachineApplications.Put(rgName, testVM.Name, golang.applicationName, golang.v2);
                    listResult = m_CrpClient.VirtualMachineApplications.List(rgName, testVM.Name);
                    Assert.Equal(2, listResult.Value.Count);

                    // test get
                    VMGalleryApplicationWithInstanceView golangInstanceView = m_CrpClient.VirtualMachineApplications.Get(rgName, testVM.Name, golang.applicationName, expand: "instanceView");
                    VMGalleryApplicationWithInstanceView firefoxInstanceView = m_CrpClient.VirtualMachineApplications.Get(rgName, testVM.Name, firefox.applicationName, expand: "instanceView");
                    Assert.Equal(golang.applicationName, golangInstanceView.InstanceView.Name);
                    Assert.Equal(firefox.applicationName, firefoxInstanceView.InstanceView.Name);

                    // test delete
                    m_CrpClient.VirtualMachineApplications.Delete(rgName, testVM.Name, golang.applicationName);
                    m_CrpClient.VirtualMachineApplications.Delete(rgName, testVM.Name, firefox.applicationName);
                    testVM = m_CrpClient.VirtualMachines.Get(rgName, vmName);
                    Assert.Equal(0, testVM.ApplicationProfile.GalleryApplications.Count);
                }
                finally
                {
                    // no cleanup required
                }
            }
        }
    }
}
