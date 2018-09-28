// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class GalleryTests : VMTestBase
    {
        protected const string ResourceGroupPrefix = "galleryPsTestRg";
        protected const string GalleryNamePrefix = "galleryPsTestGallery";
        protected const string GalleryImageNamePrefix = "galleryPsTestGalleryImage";
        private string galleryHomeLocation = "eastus2euap";

        [Fact]
        public void Gallery_CRUD_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                Assert.Null(listGalleryImagesResult.NextPageLink);

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    Assert.Null(listGalleryImageVersionsResult.NextPageLink);

                    m_CrpClient.GalleryImageVersions.Delete(rgName, galleryName, galleryImageName, galleryImageVersionName);
                    listGalleryImageVersionsResult = m_CrpClient.GalleryImageVersions.
                        ListByGalleryImage(rgName, galleryName, galleryImageName);
                    Assert.Empty(listGalleryImageVersionsResult);
                    Assert.Null(listGalleryImageVersionsResult.NextPageLink);
                    Trace.TraceInformation(string.Format("Deleted the gallery image version: {0} in gallery image: {1}",
                        galleryImageVersionName, galleryImageName));

                    ComputeManagementTestUtilities.WaitMinutes(1);
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
            Assert.False(string.IsNullOrEmpty(imageVersionOut.PublishingProfile.Source.ManagedImage.Id),
                "imageVersionOut.PublishingProfile.Source.ManagedImage.Id is null or empty.");
            Assert.NotNull(imageVersionOut.PublishingProfile.EndOfLifeDate);
            Assert.NotNull(imageVersionOut.PublishingProfile.PublishedDate);
            Assert.NotNull(imageVersionOut.StorageProfile);
        }

        private Gallery GetTestInputGallery()
        {
            return new Gallery
            {
                Location = galleryHomeLocation,
                Description = "This is a sample gallery description"
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
                OsType = OperatingSystemTypes.Linux,
                Description = "This is the gallery image description."
            };
        }

        private GalleryImageVersion GetTestInputGalleryImageVersion(string sourceImageId)
        {
            return new GalleryImageVersion
            {
                Location = galleryHomeLocation,
                PublishingProfile = new GalleryImageVersionPublishingProfile
                {
                    Source = new GalleryArtifactSource
                    {
                        ManagedImage = new ManagedArtifact { Id = sourceImageId }
                    },
                    ReplicaCount = 1,
                    TargetRegions = new List<TargetRegion> {
                        new TargetRegion { Name = galleryHomeLocation, RegionalReplicaCount = 1 }
                    },
                    EndOfLifeDate = DateTime.Today.AddDays(10).Date
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
                }
            };
            m_CrpClient.Images.CreateOrUpdate(rgName, imageName, imageInput);
            Image getImage = m_CrpClient.Images.Get(rgName, imageName);
            sourceImageId = getImage.Id;
            return createdVM;
        }
    }
}
