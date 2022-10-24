// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Compute.Tests.DiskRPTests;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Xunit;

namespace Compute.Tests
{
    public class GalleryTests : VMTestBase
    {
        protected const string ResourceGroupPrefix = "galleryPsTestRg";
        protected const string GalleryNamePrefix = "galleryPsTestGallery";
        protected const string GalleryImageNamePrefix = "galleryPsTestGalleryImage";
        protected const string GalleryApplicationNamePrefix = "galleryPsTestGalleryApplication";
        private string galleryHomeLocation = "eastus2";

        [Fact]
        public void Gallery_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);
                string rgName2 = rgName + "New";

                m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = galleryHomeLocation });
                Trace.TraceInformation("Created the resource group: " + rgName);

                string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                Gallery galleryIn = GetTestInputGallery();
                m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, galleryIn);
                Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

                Gallery galleryOut = m_CrpClient.Galleries.Get(rgName, galleryName);
                Trace.TraceInformation("Got the gallery.");
                Assert.NotNull(galleryOut);
                ValidateGallery(galleryIn, galleryOut);

                galleryIn.Description = "This is an updated description";
                m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, galleryIn);
                Trace.TraceInformation("Updated the gallery.");
                galleryOut = m_CrpClient.Galleries.Get(rgName, galleryName);
                ValidateGallery(galleryIn, galleryOut);

                Trace.TraceInformation("Listing galleries.");
                string galleryName2 = galleryName + "New";
                m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup { Location = galleryHomeLocation });
                Trace.TraceInformation("Created the resource group: " + rgName2);
                ComputeManagementTestUtilities.WaitSeconds(10);
                m_CrpClient.Galleries.CreateOrUpdate(rgName2, galleryName2, galleryIn);
                Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName2, rgName2));
                IPage<Gallery> listGalleriesInRgResult = m_CrpClient.Galleries.ListByResourceGroup(rgName);
                Assert.Single(listGalleriesInRgResult);
                Assert.Null(listGalleriesInRgResult.NextPageLink);
                IPage<Gallery> listGalleriesInSubIdResult = m_CrpClient.Galleries.List();
                // Below, >= instead of == is used because this subscription is shared in the group so other developers
                // might have created galleries in this subscription.
                Assert.True(listGalleriesInSubIdResult.Count() >= 2);

                Trace.TraceInformation("Deleting 2 galleries.");
                m_CrpClient.Galleries.Delete(rgName, galleryName);
                m_CrpClient.Galleries.Delete(rgName2, galleryName2);
                listGalleriesInRgResult = m_CrpClient.Galleries.ListByResourceGroup(rgName);
                Assert.Empty(listGalleriesInRgResult);
                // resource groups cleanup is taken cared by MockContext.Dispose() method.
            }
        }

        [Fact]
        public void GalleryImage_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);

                m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = galleryHomeLocation });
                Trace.TraceInformation("Created the resource group: " + rgName);
                string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                Gallery gallery = GetTestInputGallery();
                m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, gallery);
                Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

                string galleryImageName = ComputeManagementTestUtilities.GenerateName(GalleryImageNamePrefix);
                GalleryImage inputGalleryImage = GetTestInputGalleryImage();
                m_CrpClient.GalleryImages.CreateOrUpdate(rgName, galleryName, galleryImageName, inputGalleryImage);
                Trace.TraceInformation(string.Format("Created the gallery image: {0} in gallery: {1}", galleryImageName,
                    galleryName));

                GalleryImage galleryImageFromGet = m_CrpClient.GalleryImages.Get(rgName, galleryName, galleryImageName);
                Assert.NotNull(galleryImageFromGet);
                ValidateGalleryImage(inputGalleryImage, galleryImageFromGet);

                inputGalleryImage.Description = "Updated description.";
                m_CrpClient.GalleryImages.CreateOrUpdate(rgName, galleryName, galleryImageName, inputGalleryImage);
                Trace.TraceInformation(string.Format("Updated the gallery image: {0} in gallery: {1}", galleryImageName,
                    galleryName));
                galleryImageFromGet = m_CrpClient.GalleryImages.Get(rgName, galleryName, galleryImageName);
                Assert.NotNull(galleryImageFromGet);
                ValidateGalleryImage(inputGalleryImage, galleryImageFromGet);

                IPage<GalleryImage> listGalleryImagesResult = m_CrpClient.GalleryImages.ListByGallery(rgName, galleryName);
                Assert.Single(listGalleryImagesResult);
                Assert.Equal(1, listGalleryImagesResult.Count());
                //Assert.Null(listGalleryImagesResult.NextPageLink);

                m_CrpClient.GalleryImages.Delete(rgName, galleryName, galleryImageName);
                listGalleryImagesResult = m_CrpClient.GalleryImages.ListByGallery(rgName, galleryName);
                Assert.Empty(listGalleryImagesResult);
                Trace.TraceInformation(string.Format("Deleted the gallery image: {0} in gallery: {1}", galleryImageName,
                    galleryName));

                m_CrpClient.Galleries.Delete(rgName, galleryName);
            }
        }

        [Fact]
        public void GalleryImageVersion_CRUD_Tests()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", galleryHomeLocation);
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);
                VirtualMachine vm = null;
                string imageName = ComputeManagementTestUtilities.GenerateName("psTestSourceImage");

                try
                {
                    string sourceImageId = "";
                    vm = CreateCRPImage(rgName, imageName, ref sourceImageId);
                    Assert.False(string.IsNullOrEmpty(sourceImageId));
                    Trace.TraceInformation(string.Format("Created the source image id: {0}", sourceImageId));

                    string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                    Gallery gallery = GetTestInputGallery();
                    m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, gallery);
                    Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName,
                        rgName));
                    string galleryImageName = ComputeManagementTestUtilities.GenerateName(GalleryImageNamePrefix);
                    GalleryImage inputGalleryImage = GetTestInputGalleryImage();
                    m_CrpClient.GalleryImages.CreateOrUpdate(rgName, galleryName, galleryImageName, inputGalleryImage);
                    Trace.TraceInformation(string.Format("Created the gallery image: {0} in gallery: {1}", galleryImageName,
                        galleryName));

                    string galleryImageVersionName = "1.0.0";
                    GalleryImageVersion inputImageVersion = GetTestInputGalleryImageVersion(sourceImageId);
                    m_CrpClient.GalleryImageVersions.CreateOrUpdate(rgName, galleryName, galleryImageName,
                        galleryImageVersionName, inputImageVersion);
                    Trace.TraceInformation(string.Format("Created the gallery image version: {0} in gallery image: {1}",
                        galleryImageVersionName, galleryImageName));

                    GalleryImageVersion imageVersionFromGet = m_CrpClient.GalleryImageVersions.Get(rgName,
                        galleryName, galleryImageName, galleryImageVersionName);
                    Assert.NotNull(imageVersionFromGet);
                    ValidateGalleryImageVersion(inputImageVersion, imageVersionFromGet);
                    imageVersionFromGet = m_CrpClient.GalleryImageVersions.Get(rgName, galleryName, galleryImageName,
                        galleryImageVersionName, ReplicationStatusTypes.ReplicationStatus);
                    Assert.Equal(StorageAccountType.StandardLRS, imageVersionFromGet.PublishingProfile.StorageAccountType);
                    Assert.Equal(StorageAccountType.StandardLRS,
                        imageVersionFromGet.PublishingProfile.TargetRegions.First().StorageAccountType);
                    Assert.NotNull(imageVersionFromGet.ReplicationStatus);
                    Assert.NotNull(imageVersionFromGet.ReplicationStatus.Summary);

                    inputImageVersion.PublishingProfile.EndOfLifeDate = DateTime.Now.AddDays(100).Date;
                    m_CrpClient.GalleryImageVersions.CreateOrUpdate(rgName, galleryName, galleryImageName,
                        galleryImageVersionName, inputImageVersion);
                    Trace.TraceInformation(string.Format("Updated the gallery image version: {0} in gallery image: {1}",
                        galleryImageVersionName, galleryImageName));
                    imageVersionFromGet = m_CrpClient.GalleryImageVersions.Get(rgName, galleryName,
                        galleryImageName, galleryImageVersionName);
                    Assert.NotNull(imageVersionFromGet);
                    ValidateGalleryImageVersion(inputImageVersion, imageVersionFromGet);

                    Trace.TraceInformation("Listing the gallery image versions");
                    IPage<GalleryImageVersion> listGalleryImageVersionsResult = m_CrpClient.GalleryImageVersions.
                        ListByGalleryImage(rgName, galleryName, galleryImageName);
                    Assert.Single(listGalleryImageVersionsResult);
                    Assert.Equal(1, listGalleryImageVersionsResult.Count());
                    //Assert.Null(listGalleryImageVersionsResult.NextPageLink);

                    m_CrpClient.GalleryImageVersions.Delete(rgName, galleryName, galleryImageName, galleryImageVersionName);
                    listGalleryImageVersionsResult = m_CrpClient.GalleryImageVersions.
                        ListByGalleryImage(rgName, galleryName, galleryImageName);
                    Assert.Empty(listGalleryImageVersionsResult);
                    Trace.TraceInformation(string.Format("Deleted the gallery image version: {0} in gallery image: {1}",
                        galleryImageVersionName, galleryImageName));

                    ComputeManagementTestUtilities.WaitMinutes(5);
                    m_CrpClient.Images.Delete(rgName, imageName);
                    Trace.TraceInformation("Deleted the CRP image.");
                    m_CrpClient.VirtualMachines.Delete(rgName, vm.Name);
                    Trace.TraceInformation("Deleted the virtual machine.");
                    m_CrpClient.GalleryImages.Delete(rgName, galleryName, galleryImageName);
                    Trace.TraceInformation("Deleted the gallery image.");
                    m_CrpClient.Galleries.Delete(rgName, galleryName);
                    Trace.TraceInformation("Deleted the gallery.");
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    if (vm != null)
                    {
                        m_CrpClient.VirtualMachines.Delete(rgName, vm.Name);
                    }
                    m_CrpClient.Images.Delete(rgName, imageName);
                }
            }
        }

        [Fact]
        public void GalleryApplication_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string location = galleryHomeLocation;
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);

                m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                Trace.TraceInformation("Created the resource group: " + rgName);
                string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                Gallery gallery = GetTestInputGallery();
                gallery.Location = location;
                m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, gallery);
                Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

                string galleryApplicationName = ComputeManagementTestUtilities.GenerateName(GalleryApplicationNamePrefix);
                GalleryApplication inputGalleryApplication = GetTestInputGalleryApplication();
                m_CrpClient.GalleryApplications.CreateOrUpdate(rgName, galleryName, galleryApplicationName, inputGalleryApplication);
                Trace.TraceInformation(string.Format("Created the gallery application: {0} in gallery: {1}", galleryApplicationName,
                    galleryName));

                GalleryApplication galleryApplicationFromGet = m_CrpClient.GalleryApplications.Get(rgName, galleryName, galleryApplicationName);
                Assert.NotNull(galleryApplicationFromGet);
                ValidateGalleryApplication(inputGalleryApplication, galleryApplicationFromGet);

                inputGalleryApplication.Description = "Updated description.";
                m_CrpClient.GalleryApplications.CreateOrUpdate(rgName, galleryName, galleryApplicationName, inputGalleryApplication);
                Trace.TraceInformation(string.Format("Updated the gallery application: {0} in gallery: {1}", galleryApplicationName,
                    galleryName));
                galleryApplicationFromGet = m_CrpClient.GalleryApplications.Get(rgName, galleryName, galleryApplicationName);
                Assert.NotNull(galleryApplicationFromGet);
                ValidateGalleryApplication(inputGalleryApplication, galleryApplicationFromGet);

                m_CrpClient.GalleryApplications.Delete(rgName, galleryName, galleryApplicationName);

                Trace.TraceInformation(string.Format("Deleted the gallery application: {0} in gallery: {1}", galleryApplicationName,
                    galleryName));

                m_CrpClient.Galleries.Delete(rgName, galleryName);
            }
        }

        [Fact]
        public void GalleryApplicationVersion_CRUD_Tests()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string location = galleryHomeLocation;
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", location);
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);
                string applicationName = ComputeManagementTestUtilities.GenerateName("psTestSourceApplication");
                string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                string galleryApplicationName = ComputeManagementTestUtilities.GenerateName(GalleryApplicationNamePrefix);
                string galleryApplicationVersionName = "1.0.0";

                try
                {
                    string applicationMediaLink = CreateApplicationMediaLink(rgName, "test.txt");

                    Assert.False(string.IsNullOrEmpty(applicationMediaLink));
                    Trace.TraceInformation(string.Format("Created the source application media link: {0}", applicationMediaLink));

                    Gallery gallery = GetTestInputGallery();
                    gallery.Location = location;
                    m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, gallery);
                    Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName,
                        rgName));
                    GalleryApplication inputGalleryApplication = GetTestInputGalleryApplication();
                    m_CrpClient.GalleryApplications.CreateOrUpdate(rgName, galleryName, galleryApplicationName, inputGalleryApplication);
                    Trace.TraceInformation(string.Format("Created the gallery application: {0} in gallery: {1}", galleryApplicationName,
                        galleryName));

                    GalleryApplicationVersion inputApplicationVersion = GetTestInputGalleryApplicationVersion(applicationMediaLink);
                    m_CrpClient.GalleryApplicationVersions.CreateOrUpdate(rgName, galleryName, galleryApplicationName,
                        galleryApplicationVersionName, inputApplicationVersion);
                    Trace.TraceInformation(string.Format("Created the gallery application version: {0} in gallery application: {1}",
                        galleryApplicationVersionName, galleryApplicationName));

                    GalleryApplicationVersion applicationVersionFromGet = m_CrpClient.GalleryApplicationVersions.Get(rgName,
                        galleryName, galleryApplicationName, galleryApplicationVersionName);
                    Assert.NotNull(applicationVersionFromGet);
                    ValidateGalleryApplicationVersion(inputApplicationVersion, applicationVersionFromGet);
                    applicationVersionFromGet = m_CrpClient.GalleryApplicationVersions.Get(rgName, galleryName, galleryApplicationName,
                        galleryApplicationVersionName, ReplicationStatusTypes.ReplicationStatus);
                    Assert.Equal(StorageAccountType.StandardLRS, applicationVersionFromGet.PublishingProfile.StorageAccountType);
                    Assert.Equal(StorageAccountType.StandardLRS,
                        applicationVersionFromGet.PublishingProfile.TargetRegions.First().StorageAccountType);
                    Assert.NotNull(applicationVersionFromGet.ReplicationStatus);
                    Assert.NotNull(applicationVersionFromGet.ReplicationStatus.Summary);

                    inputApplicationVersion.PublishingProfile.EndOfLifeDate = DateTime.Now.AddDays(100).Date;
                    m_CrpClient.GalleryApplicationVersions.CreateOrUpdate(rgName, galleryName, galleryApplicationName,
                        galleryApplicationVersionName, inputApplicationVersion);
                    Trace.TraceInformation(string.Format("Updated the gallery application version: {0} in gallery application: {1}",
                        galleryApplicationVersionName, galleryApplicationName));
                    applicationVersionFromGet = m_CrpClient.GalleryApplicationVersions.Get(rgName, galleryName,
                        galleryApplicationName, galleryApplicationVersionName);
                    Assert.NotNull(applicationVersionFromGet);
                    ValidateGalleryApplicationVersion(inputApplicationVersion, applicationVersionFromGet);

                    m_CrpClient.GalleryApplicationVersions.Delete(rgName, galleryName, galleryApplicationName, galleryApplicationVersionName);
                    Trace.TraceInformation(string.Format("Deleted the gallery application version: {0} in gallery application: {1}",
                        galleryApplicationVersionName, galleryApplicationName));
                    ComputeManagementTestUtilities.WaitSeconds(300);

                    m_CrpClient.GalleryApplications.Delete(rgName, galleryName, galleryApplicationName);
                    Trace.TraceInformation("Deleted the gallery application.");
                    m_CrpClient.Galleries.Delete(rgName, galleryName);
                    Trace.TraceInformation("Deleted the gallery.");
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }


        [Fact]
        public void Gallery_SharingToSubscriptionAndTenant_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = galleryHomeLocation });
                    Trace.TraceInformation("Created the resource group: " + rgName);

                    string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                    Gallery galleryIn = GetTestInputSharedGallery();
                    m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, galleryIn);
                    Trace.TraceInformation(string.Format("Created the  shared gallery: {0} in resource group: {1} with sharing profile permission: {2}",
                        galleryName, rgName, galleryIn.SharingProfile.Permissions));

                    Gallery galleryOut = m_CrpClient.Galleries.Get(rgName, galleryName);
                    Trace.TraceInformation("Got the gallery.");
                    Assert.NotNull(galleryOut);
                    ValidateGallery(galleryIn, galleryOut);
                    Assert.Equal("Groups", galleryOut.SharingProfile.Permissions);

                    Trace.TraceInformation("Update the sharing profile via post, add the sharing profile groups.");
                    string newTenantId = "583d66a9-0041-4999-8838-75baece101d5";
                    SharingProfileGroup tenantGroups = new SharingProfileGroup()
                    {
                        Type = "AADTenants",
                        Ids = new List<string> { newTenantId }

                    };

                    string newSubId = "640c5810-13bf-4b82-b94d-f38c2565e3bc";
                    SharingProfileGroup subGroups = new SharingProfileGroup()
                    {
                        Type = "Subscriptions",
                        Ids = new List<string> { newSubId }

                    };

                    List<SharingProfileGroup> groups = new List<SharingProfileGroup> { tenantGroups, subGroups };
                    SharingUpdate sharingUpdate = new SharingUpdate()
                    {
                        OperationType = SharingUpdateOperationTypes.Add,
                        Groups = groups
                    };

                    m_CrpClient.GallerySharingProfile.Update(rgName, galleryName, sharingUpdate);

                    Gallery galleryOutWithSharingProfile = m_CrpClient.Galleries.Get(rgName, galleryName, SelectPermissions.Permissions);
                    Trace.TraceInformation("Got the gallery");
                    Assert.NotNull(galleryOutWithSharingProfile);

                    ValidateSharingProfile(galleryIn, galleryOutWithSharingProfile, groups);

                    Trace.TraceInformation("Reset this gallery to private before deleting it.");
                    SharingUpdate resetPrivateUpdate = new SharingUpdate()
                    {
                        OperationType = SharingUpdateOperationTypes.Reset,
                        Groups = null
                    };

                    m_CrpClient.GallerySharingProfile.Update(rgName, galleryName, resetPrivateUpdate);

                    Trace.TraceInformation("Deleting this gallery.");
                    m_CrpClient.Galleries.Delete(rgName, galleryName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }

                // resource groups cleanup is taken cared by MockContext.Dispose() method.
            }
        }

        [Fact]
        public void Gallery_SharingToCommunity_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                string rgName = ComputeManagementTestUtilities.GenerateName(ResourceGroupPrefix);

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = galleryHomeLocation });
                    Trace.TraceInformation("Created the resource group: " + rgName);

                    string galleryName = ComputeManagementTestUtilities.GenerateName(GalleryNamePrefix);
                    Gallery galleryIn = GetTestInputCommunityGallery();
                    m_CrpClient.Galleries.CreateOrUpdate(rgName, galleryName, galleryIn);
                    Trace.TraceInformation(string.Format("Created the community gallery: {0} in resource group: {1} with sharing profile permission: {2}",
                        galleryName, rgName, galleryIn.SharingProfile.Permissions));

                    Gallery galleryOut = m_CrpClient.Galleries.Get(rgName, galleryName);
                    Trace.TraceInformation("Got the gallery.");
                    Assert.NotNull(galleryOut);
                    ValidateGallery(galleryIn, galleryOut);
                    Assert.NotNull(galleryOut.SharingProfile);
                    Assert.NotNull(galleryOut.SharingProfile.CommunityGalleryInfo);
                    Assert.Equal("Community", galleryOut.SharingProfile.Permissions);

                    Trace.TraceInformation("Enable sharing to the public via post");

                    SharingUpdate sharingUpdate = new SharingUpdate()
                    {
                        OperationType = SharingUpdateOperationTypes.EnableCommunity
                    };

                    m_CrpClient.GallerySharingProfile.Update(rgName, galleryName, sharingUpdate);

                    Gallery galleryOutWithSharingProfile = m_CrpClient.Galleries.Get(rgName, galleryName, SelectPermissions.Permissions);
                    Trace.TraceInformation("Got the gallery");
                    Assert.NotNull(galleryOutWithSharingProfile);
                    //CommunityGalleryInfo communityGalleryInfo = JsonConvert.DeserializeObject<CommunityGalleryInfo>(galleryOutWithSharingProfile.SharingProfile.CommunityGalleryInfo.ToString());
                    //Assert.True(communityGalleryInfo.CommunityGalleryEnabled);
                    Assert.True(galleryOutWithSharingProfile.SharingProfile.CommunityGalleryInfo.CommunityGalleryEnabled);

                    Trace.TraceInformation("Reset this gallery to private before deleting it.");
                    SharingUpdate resetPrivateUpdate = new SharingUpdate()
                    {
                        OperationType = SharingUpdateOperationTypes.Reset
                    };

                    m_CrpClient.GallerySharingProfile.Update(rgName, galleryName, resetPrivateUpdate);

                    Trace.TraceInformation("Deleting this gallery.");
                    m_CrpClient.Galleries.Delete(rgName, galleryName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
                // resource groups cleanup is taken cared by MockContext.Dispose() method.
            }
        }

        private void ValidateGallery(Gallery galleryIn, Gallery galleryOut)
        {
            Assert.False(string.IsNullOrEmpty(galleryOut.ProvisioningState));

            if (galleryIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in galleryIn.Tags)
                {
                    Assert.Equal(kvp.Value, galleryOut.Tags[kvp.Key]);
                }
            }

            if (!string.IsNullOrEmpty(galleryIn.Description))
            {
                Assert.Equal(galleryIn.Description, galleryOut.Description);
            }

            Assert.False(string.IsNullOrEmpty(galleryOut?.Identifier?.UniqueName));
        }

        private void ValidateSharingProfile(Gallery galleryIn, Gallery galleryOut, List<SharingProfileGroup> groups)
        {
            if (galleryIn.SharingProfile != null)
            {
                Assert.Equal(galleryIn.SharingProfile.Permissions, galleryOut.SharingProfile.Permissions);
                Assert.Equal(groups.Count, galleryOut.SharingProfile.Groups.Count);

                foreach (SharingProfileGroup sharingProfileGroup in galleryOut.SharingProfile.Groups)
                {
                    if (sharingProfileGroup.Ids != null)
                    {
                        List<string> outIds = sharingProfileGroup.Ids as List<string>;
                        List<string> inIds = null;

                        foreach (SharingProfileGroup inGroup in groups)
                        {
                            if (inGroup.Type == sharingProfileGroup.Type)
                            {
                                inIds = inGroup.Ids as List<string>;
                                break;
                            }
                        }

                        Assert.NotNull(inIds);
                        Assert.Equal(inIds.Count, outIds.Count);

                        for (int i = 0; i < inIds.Count; i++)
                        {
                            Assert.Equal(outIds[i], inIds[i]);
                        }

                    }
                }
            }
        }

        private void ValidateGalleryImage(GalleryImage imageIn, GalleryImage imageOut)
        {
            Assert.False(string.IsNullOrEmpty(imageOut.ProvisioningState));

            if (imageIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in imageIn.Tags)
                {
                    Assert.Equal(kvp.Value, imageOut.Tags[kvp.Key]);
                }
            }

            Assert.Equal(imageIn.Identifier.Publisher, imageOut.Identifier.Publisher);
            Assert.Equal(imageIn.Identifier.Offer, imageOut.Identifier.Offer);
            Assert.Equal(imageIn.Identifier.Sku, imageOut.Identifier.Sku);
            Assert.Equal(imageIn.Location, imageOut.Location);
            Assert.Equal(imageIn.OsState, imageOut.OsState);
            Assert.Equal(imageIn.OsType, imageOut.OsType);
            if (imageIn.HyperVGeneration == null)
            {
                Assert.Equal(HyperVGenerationType.V1, imageOut.HyperVGeneration);
            }
            else
            {
                Assert.Equal(imageIn.HyperVGeneration, imageOut.HyperVGeneration);
            }

            if (!string.IsNullOrEmpty(imageIn.Description))
            {
                Assert.Equal(imageIn.Description, imageOut.Description);
            }
        }

        private void ValidateGalleryImageVersion(GalleryImageVersion imageVersionIn,
            GalleryImageVersion imageVersionOut)
        {
            Assert.False(string.IsNullOrEmpty(imageVersionOut.ProvisioningState));

            if (imageVersionIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in imageVersionIn.Tags)
                {
                    Assert.Equal(kvp.Value, imageVersionOut.Tags[kvp.Key]);
                }
            }

            Assert.Equal(imageVersionIn.Location, imageVersionOut.Location);
            Assert.False(string.IsNullOrEmpty(imageVersionOut.StorageProfile.Source.Id),
                "imageVersionOut.PublishingProfile.Source.ManagedImage.Id is null or empty.");
            Assert.NotNull(imageVersionOut.PublishingProfile.EndOfLifeDate);
            Assert.NotNull(imageVersionOut.PublishingProfile.PublishedDate);
            Assert.NotNull(imageVersionOut.StorageProfile);
            ValidateImageVersionSecurityProfile(imageVersionIn.SafetyProfile, imageVersionOut.SafetyProfile);
        }

        private void ValidateImageVersionSecurityProfile(
            GalleryImageVersionSafetyProfile safetyProfileIn,
            GalleryImageVersionSafetyProfile safetyProfileOut)
        {
            Assert.Equal(safetyProfileIn.AllowDeletionOfReplicatedLocations, safetyProfileOut.AllowDeletionOfReplicatedLocations);
        }

        private Gallery GetTestInputGallery()
        {
            return new Gallery
            {
                Location = galleryHomeLocation,
                Description = "This is a sample gallery description"
            };
        }

        private Gallery GetTestInputSharedGallery()
        {
            return new Gallery
            {
                Location = galleryHomeLocation,
                Description = "This is a sample gallery description",
                SharingProfile = new SharingProfile
                {
                    Permissions = "Groups"
                }
            };
        }

        private Gallery GetTestInputCommunityGallery()
        {
            return new Gallery
            {
                Location = galleryHomeLocation,
                Description = "This is a sample gallery description",
                SharingProfile = new SharingProfile
                {
                    Permissions = "Community",
                    CommunityGalleryInfo = new CommunityGalleryInfo()
                    {
                        PublicNamePrefix = "PsTestCg",
                        Eula = "PsEual",
                        PublisherUri = "PsTestUri",
                        PublisherContact = "SIG@microsoft.com"
                    }
                }
            };
        }

        private GalleryImage GetTestInputGalleryImage()
        {
            return new GalleryImage
            {
                Identifier = new GalleryImageIdentifier
                {
                    Publisher = "testPub",
                    Offer = "testOffer",
                    Sku = "testSku"
                },
                Location = galleryHomeLocation,
                OsState = OperatingSystemStateTypes.Generalized,
                OsType = OperatingSystemTypes.Windows,
                Description = "This is the gallery image description.",
                HyperVGeneration = null
            };
        }

        private GalleryImageVersion GetTestInputGalleryImageVersion(string sourceImageId)
        {
            return new GalleryImageVersion
            {
                Location = galleryHomeLocation,
                SafetyProfile = new GalleryImageVersionSafetyProfile()
                {
                    AllowDeletionOfReplicatedLocations = true
                },
                PublishingProfile = new GalleryImageVersionPublishingProfile
                {
                    ReplicaCount = 1,
                    StorageAccountType = StorageAccountType.StandardLRS,
                    TargetRegions = new List<TargetRegion> {
                        new TargetRegion {
                            Name = galleryHomeLocation,
                            RegionalReplicaCount = 1,
                            StorageAccountType = StorageAccountType.StandardLRS
                        }
                    },
                    EndOfLifeDate = DateTime.Today.AddDays(10).Date
                },
                StorageProfile = new GalleryImageVersionStorageProfile
                {
                    Source = new GalleryArtifactVersionFullSource
                    {
                        Id = sourceImageId
                    }
                }
            };
        }

        private VirtualMachine CreateCRPImage(string rgName, string imageName, ref string sourceImageId)
        {
            string storageAccountName = ComputeManagementTestUtilities.GenerateName("saforgallery");
            string asName = ComputeManagementTestUtilities.GenerateName("asforgallery");
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
            StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName); // resource group is also created in this method.
            VirtualMachine inputVM = null;
            VirtualMachine createdVM = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM);
            Image imageInput = new Image()
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                StorageProfile = new ImageStorageProfile()
                {
                    OsDisk = new ImageOSDisk()
                    {
                        BlobUri = createdVM.StorageProfile.OsDisk.Vhd.Uri,
                        OsState = OperatingSystemStateTypes.Generalized,
                        OsType = OperatingSystemTypes.Windows,
                    },
                    ZoneResilient = true
                },
                HyperVGeneration = HyperVGenerationTypes.V1
            };
            m_CrpClient.Images.CreateOrUpdate(rgName, imageName, imageInput);
            Image getImage = m_CrpClient.Images.Get(rgName, imageName);
            sourceImageId = getImage.Id;
            return createdVM;
        }

        private string CreateApplicationMediaLink(string rgName, string fileName)
        {
            string storageAccountName = ComputeManagementTestUtilities.GenerateName("saforgallery");
            string asName = ComputeManagementTestUtilities.GenerateName("asforgallery");
            StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName); // resource group is also created in this method.
            string applicationMediaLink = @"https://saforgallery1969.blob.core.windows.net/sascontainer/test.txt\";
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var accountKeyResult = m_SrpClient.StorageAccounts.ListKeysWithHttpMessagesAsync(rgName, storageAccountName).Result;
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, accountKeyResult.Body.Key1), useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("sascontainer");
                bool created = container.CreateIfNotExistsAsync().Result;

                CloudPageBlob pageBlob = container.GetPageBlobReference(fileName);
                byte[] blobContent = Encoding.UTF8.GetBytes("Application Package Test");
                byte[] bytes = new byte[512]; // Page blob must be multiple of 512
                System.Buffer.BlockCopy(blobContent, 0, bytes, 0, blobContent.Length);
                pageBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);

                SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddDays(-1);
                sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddDays(2);
                sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

                //Generate the shared access signature on the blob, setting the constraints directly on the signature.
                string sasContainerToken = pageBlob.GetSharedAccessSignature(sasConstraints);

                //Return the URI string for the container, including the SAS token.
                applicationMediaLink = pageBlob.Uri + sasContainerToken;
            }
            return applicationMediaLink;
        }

        private GalleryApplication GetTestInputGalleryApplication()
        {
            return new GalleryApplication
            {
                Eula = "This is the gallery application EULA.",
                Location = galleryHomeLocation,
                SupportedOSType = OperatingSystemTypes.Windows,
                PrivacyStatementUri = "www.privacystatement.com",
                ReleaseNoteUri = "www.releasenote.com",
                Description = "This is the gallery application description.",
            };
        }

        private GalleryApplicationVersion GetTestInputGalleryApplicationVersion(string applicationMediaLink)
        {
            return new GalleryApplicationVersion
            {
                Location = galleryHomeLocation,
                SafetyProfile = new GalleryApplicationVersionSafetyProfile()
                {
                    AllowDeletionOfReplicatedLocations = true
                },
                PublishingProfile = new GalleryApplicationVersionPublishingProfile
                {
                    Source = new UserArtifactSource
                    {
                        MediaLink = applicationMediaLink
                    },
                    ManageActions = new UserArtifactManage
                    {
                        Install = "powershell -command \"Expand-Archive -Path test.zip -DestinationPath C:\\package\"",
                        Remove = "del C:\\package "
                    },
                    CustomActions = new List<GalleryApplicationCustomAction>()
                    {
                        new GalleryApplicationCustomAction()
                        {
                            Name = "testCustomAction",
                            Script = "powershell -command \"echo testCustomActionScript\"",
                            Description = "A test custom action",
                            Parameters = new List<GalleryApplicationCustomActionParameter>()
                            {
                                new GalleryApplicationCustomActionParameter()
                                {
                                    Name = "testCustomActionParam",
                                    Description = "A test custom action parameter",
                                    Type = GalleryApplicationCustomActionParameterType.String,
                                    DefaultValue = "paramDefaultValue",
                                    Required = true,
                                }
                            }
                        }
                    },
                    Settings = new UserArtifactSettings
                    {
                        PackageFileName = "test.zip",
                        ConfigFileName = "config.cfg"
                    },
                    AdvancedSettings = new Dictionary<string, string>()
                    {
                        { "cacheLimit", "500" },
                        { "user", "root"}
                    },
                    ReplicaCount = 1,
                    StorageAccountType = StorageAccountType.StandardLRS,
                    TargetRegions = new List<TargetRegion> {
                        new TargetRegion { Name = galleryHomeLocation, RegionalReplicaCount = 1, StorageAccountType = StorageAccountType.StandardLRS }
                    },
                    EndOfLifeDate = DateTime.Today.AddDays(10).Date
                }
            };
        }

        private void ValidateGalleryApplication(GalleryApplication applicationIn, GalleryApplication applicationOut)
        {
            if (applicationIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in applicationIn.Tags)
                {
                    Assert.Equal(kvp.Value, applicationOut.Tags[kvp.Key]);
                }
            }
            Assert.Equal(applicationIn.Eula, applicationOut.Eula);
            Assert.Equal(applicationIn.PrivacyStatementUri, applicationOut.PrivacyStatementUri);
            Assert.Equal(applicationIn.ReleaseNoteUri, applicationOut.ReleaseNoteUri);
            Assert.Equal(applicationIn.Location.ToLower(), applicationOut.Location.ToLower());
            Assert.Equal(applicationIn.SupportedOSType, applicationOut.SupportedOSType);
            if (!string.IsNullOrEmpty(applicationIn.Description))
            {
                Assert.Equal(applicationIn.Description, applicationOut.Description);
            }
        }

        private void ValidateGalleryApplicationVersion(GalleryApplicationVersion applicationVersionIn, GalleryApplicationVersion applicationVersionOut)
        {
            Assert.False(string.IsNullOrEmpty(applicationVersionOut.ProvisioningState));

            if (applicationVersionIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in applicationVersionIn.Tags)
                {
                    Assert.Equal(kvp.Value, applicationVersionOut.Tags[kvp.Key]);
                }
            }

            Assert.Equal(applicationVersionIn.Location.ToLower(), applicationVersionOut.Location.ToLower());
            Assert.False(string.IsNullOrEmpty(applicationVersionOut.PublishingProfile.Source.MediaLink),
                "applicationVersionOut.PublishingProfile.Source.MediaLink is null or empty.");
            Assert.NotNull(applicationVersionOut.PublishingProfile.EndOfLifeDate);
            Assert.NotNull(applicationVersionOut.PublishingProfile.PublishedDate);
            Assert.NotNull(applicationVersionOut.Id);
            Assert.Equal(applicationVersionIn.PublishingProfile.Settings.PackageFileName, applicationVersionOut.PublishingProfile.Settings.PackageFileName);
            Assert.Equal(applicationVersionIn.PublishingProfile.Settings.ConfigFileName, applicationVersionOut.PublishingProfile.Settings.ConfigFileName);
            Assert.Equal(applicationVersionIn.SafetyProfile.AllowDeletionOfReplicatedLocations, applicationVersionOut.SafetyProfile.AllowDeletionOfReplicatedLocations);
            IDictionary<string, string> advancedSettingsIn = applicationVersionIn.PublishingProfile.AdvancedSettings;
            IDictionary<string, string> advancedSettingsOut = applicationVersionOut.PublishingProfile.AdvancedSettings;
            Assert.Equal(advancedSettingsIn.Count, advancedSettingsOut.Count);
            foreach (KeyValuePair<string, string> kvp in advancedSettingsIn)
            {
                Assert.True(advancedSettingsOut.ContainsKey(kvp.Key));
                Assert.Equal(kvp.Value, advancedSettingsOut[kvp.Key]);
            }
            ValidateCustomActions(applicationVersionIn.PublishingProfile.CustomActions, applicationVersionOut.PublishingProfile.CustomActions);
        }

        private void ValidateCustomActions(IList<GalleryApplicationCustomAction> customActionsIn, IList<GalleryApplicationCustomAction> customActionsOut)
        {
            Assert.Equal(customActionsIn.Count, customActionsOut.Count);
            foreach (var customActionIn in customActionsIn)
            {
                var customActionOut = customActionsOut.First(a => a.Name == customActionIn.Name);
                Assert.NotNull(customActionOut);
                Assert.Equal(customActionIn.Script, customActionOut.Script);
                Assert.Equal(customActionIn.Description, customActionOut.Description);

                var parametersIn = customActionIn.Parameters;
                var parametersOut = customActionOut.Parameters;
                Assert.Equal(parametersIn.Count, parametersOut.Count);
                foreach (var parameterIn in parametersIn)
                {
                    var parameterOut = parametersOut.First(a => a.Name == parameterIn.Name);
                    Assert.NotNull(parameterOut);
                    Assert.Equal(parameterIn.DefaultValue, parameterOut.DefaultValue);
                    Assert.Equal(parameterIn.Description, parameterOut.Description);
                    Assert.Equal(parameterIn.Required, parameterOut.Required);
                    Assert.Equal(parameterIn.Type, parameterOut.Type);
                }
            }
        }
    }
}