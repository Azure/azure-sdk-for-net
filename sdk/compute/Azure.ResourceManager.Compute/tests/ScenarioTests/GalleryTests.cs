// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.Management.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class GalleryTests : VMTestBase
    {
        public GalleryTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        protected const string ResourceGroupPrefix = "galleryPsTestRg";
        protected const string GalleryNamePrefix = "galleryPsTestGallery";
        protected const string GalleryImageNamePrefix = "galleryPsTestGalleryImage";
        protected const string GalleryApplicationNamePrefix = "galleryPsTestGalleryApplication";
        private string sourceImageId = "";

        [Test]
        public async Task Gallery_CRUD_Tests()
        {
            EnsureClientsInitialized(LocationEastUs2);
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefix);
            string rgName2 = rgName + "New";

            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(LocationEastUs2));
            Trace.TraceInformation("Created the resource group: " + rgName);

            string galleryName = Recording.GenerateAssetName(GalleryNamePrefix);
            Gallery galleryIn = GetTestInputGallery();
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryIn));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

            Gallery galleryOut = await GalleriesOperations.GetAsync(rgName, galleryName);
            Trace.TraceInformation("Got the gallery.");
            Assert.NotNull(galleryOut);
            ValidateGallery(galleryIn, galleryOut);

            galleryIn.Description = "This is an updated description";
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryIn));
            Trace.TraceInformation("Updated the gallery.");
            galleryOut = await GalleriesOperations.GetAsync(rgName, galleryName);
            ValidateGallery(galleryIn, galleryOut);

            Trace.TraceInformation("Listing galleries.");
            string galleryName2 = galleryName + "New";
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName2, new ResourceGroup(LocationEastUs2));
            Trace.TraceInformation("Created the resource group: " + rgName2);
            WaitSeconds(10);
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName2, galleryName2, galleryIn));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName2, rgName2));
            List<Gallery> listGalleriesInRgResult = await (GalleriesOperations.ListByResourceGroupAsync(rgName)).ToEnumerableAsync();
            Assert.True(listGalleriesInRgResult.Count() == 1);
            //Assert.Null(listGalleriesInRgResult.NextPageLink);
            List<Gallery> listGalleriesInSubIdResult = await (GalleriesOperations.ListAsync()).ToEnumerableAsync();
            // Below, >= instead of == is used because this subscription is shared in the group so other developers
            // might have created galleries in this subscription.
            Assert.True(listGalleriesInSubIdResult.Count() >= 2);

            Trace.TraceInformation("Deleting 2 galleries.");
            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName, galleryName));
            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName2, galleryName2));
            listGalleriesInRgResult = await (GalleriesOperations.ListByResourceGroupAsync(rgName)).ToEnumerableAsync();
            Assert.IsEmpty(listGalleriesInRgResult);
            // resource groups cleanup is taken cared by MockContext.Dispose() method.
        }

        [Test]
        public async Task GalleryImage_CRUD_Tests()
        {
            EnsureClientsInitialized(LocationEastUs2);
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefix);

            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(LocationEastUs2));
            Trace.TraceInformation("Created the resource group: " + rgName);
            string galleryName = Recording.GenerateAssetName(GalleryNamePrefix);
            Gallery gallery = GetTestInputGallery();
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, gallery));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

            string galleryImageName = Recording.GenerateAssetName(GalleryImageNamePrefix);
            GalleryImage inputGalleryImage = GetTestInputGalleryImage();
            await WaitForCompletionAsync(await GalleryImagesOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryImageName, inputGalleryImage));
            Trace.TraceInformation(string.Format("Created the gallery image: {0} in gallery: {1}", galleryImageName,
                galleryName));

            GalleryImage galleryImageFromGet = await GalleryImagesOperations.GetAsync(rgName, galleryName, galleryImageName);
            Assert.NotNull(galleryImageFromGet);
            ValidateGalleryImage(inputGalleryImage, galleryImageFromGet);

            inputGalleryImage.Description = "Updated description.";
            await WaitForCompletionAsync(await GalleryImagesOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryImageName, inputGalleryImage));
            Trace.TraceInformation(string.Format("Updated the gallery image: {0} in gallery: {1}", galleryImageName,
                galleryName));
            galleryImageFromGet = await GalleryImagesOperations.GetAsync(rgName, galleryName, galleryImageName);
            Assert.NotNull(galleryImageFromGet);
            ValidateGalleryImage(inputGalleryImage, galleryImageFromGet);

            List<GalleryImage> listGalleryImagesResult = await (GalleryImagesOperations.ListByGalleryAsync(rgName, galleryName)).ToEnumerableAsync();
            Assert.IsTrue(listGalleryImagesResult.Count() == 1);
            //Assert.Single(listGalleryImagesResult);
            //Assert.Null(listGalleryImagesResult.NextPageLink);

            await WaitForCompletionAsync(await GalleryImagesOperations.StartDeleteAsync(rgName, galleryName, galleryImageName));
            listGalleryImagesResult = await (GalleryImagesOperations.ListByGalleryAsync(rgName, galleryName)).ToEnumerableAsync();
            Assert.IsEmpty(listGalleryImagesResult);
            Trace.TraceInformation(string.Format("Deleted the gallery image: {0} in gallery: {1}", galleryImageName,
                galleryName));
            WaitSeconds(30);
            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName, galleryName));
        }

        [Test]
        public async Task GalleryImageVersion_CRUD_Tests()
        {
            EnsureClientsInitialized(LocationEastUs2);
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefix);
            VirtualMachine vm = null;
            string imageName = Recording.GenerateAssetName("psTestSourceImage");
            vm = await CreateCRPImage(rgName, imageName);
            Assert.False(string.IsNullOrEmpty(sourceImageId));
            Trace.TraceInformation(string.Format("Created the source image id: {0}", sourceImageId));

            string galleryName = Recording.GenerateAssetName(GalleryNamePrefix);
            Gallery gallery = GetTestInputGallery();
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, gallery));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName,
                rgName));
            string galleryImageName = Recording.GenerateAssetName(GalleryImageNamePrefix);
            GalleryImage inputGalleryImage = GetTestInputGalleryImage();
            await WaitForCompletionAsync((await GalleryImagesOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryImageName, inputGalleryImage)));
            Trace.TraceInformation(string.Format("Created the gallery image: {0} in gallery: {1}", galleryImageName,
                galleryName));

            string galleryImageVersionName = "1.0.0";
            GalleryImageVersion inputImageVersion = GetTestInputGalleryImageVersion(sourceImageId);
            await WaitForCompletionAsync(await GalleryImageVersionsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryImageName,
                galleryImageVersionName, inputImageVersion));
            Trace.TraceInformation(string.Format("Created the gallery image version: {0} in gallery image: {1}",
                galleryImageVersionName, galleryImageName));

            GalleryImageVersion imageVersionFromGet = await GalleryImageVersionsOperations.GetAsync(rgName,
                galleryName, galleryImageName, galleryImageVersionName);
            Assert.NotNull(imageVersionFromGet);
            ValidateGalleryImageVersion(inputImageVersion, imageVersionFromGet);
            imageVersionFromGet = await GalleryImageVersionsOperations.GetAsync(rgName, galleryName, galleryImageName,
                galleryImageVersionName);
            Assert.AreEqual(StorageAccountType.StandardLRS, imageVersionFromGet.PublishingProfile.StorageAccountType);
            Assert.AreEqual(StorageAccountType.StandardLRS,
                imageVersionFromGet.PublishingProfile.TargetRegions.First().StorageAccountType);
            Assert.NotNull(imageVersionFromGet.ReplicationStatus);
            Assert.NotNull(imageVersionFromGet.ReplicationStatus.Summary);

            inputImageVersion.PublishingProfile.EndOfLifeDate = Recording.UtcNow.AddDays(100);
            await WaitForCompletionAsync(await GalleryImageVersionsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryImageName,
                galleryImageVersionName, inputImageVersion));
            Trace.TraceInformation(string.Format("Updated the gallery image version: {0} in gallery image: {1}",
                galleryImageVersionName, galleryImageName));
            imageVersionFromGet = await GalleryImageVersionsOperations.GetAsync(rgName, galleryName,
                galleryImageName, galleryImageVersionName);
            Assert.NotNull(imageVersionFromGet);
            ValidateGalleryImageVersion(inputImageVersion, imageVersionFromGet);

            Trace.TraceInformation("Listing the gallery image versions");
            List<GalleryImageVersion> listGalleryImageVersionsResult = await (GalleryImageVersionsOperations.
                ListByGalleryImageAsync(rgName, galleryName, galleryImageName)).ToEnumerableAsync();
            Assert.IsTrue(listGalleryImageVersionsResult.Count() == 1);
            //Assert.Single(listGalleryImageVersionsResult);
            //Assert.Null(listGalleryImageVersionsResult.NextPageLink);

            await WaitForCompletionAsync(await GalleryImageVersionsOperations.StartDeleteAsync(rgName, galleryName, galleryImageName, galleryImageVersionName));
            listGalleryImageVersionsResult = await (GalleryImageVersionsOperations.
                ListByGalleryImageAsync(rgName, galleryName, galleryImageName)).ToEnumerableAsync();
            //Assert.Null(listGalleryImageVersionsResult.NextPageLink);
            Trace.TraceInformation(string.Format("Deleted the gallery image version: {0} in gallery image: {1}",
                galleryImageVersionName, galleryImageName));

            this.WaitMinutes(5);
            await WaitForCompletionAsync(await ImagesOperations.StartDeleteAsync(rgName, imageName));
            Trace.TraceInformation("Deleted the CRP image.");
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, vm.Name));
            Trace.TraceInformation("Deleted the virtual machine.");
            await WaitForCompletionAsync(await GalleryImagesOperations.StartDeleteAsync(rgName, galleryName, galleryImageName));
            Trace.TraceInformation("Deleted the gallery image.");
            WaitSeconds(30);
            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName, galleryName));
            WaitSeconds(30);
            Trace.TraceInformation("Deleted the gallery.");
        }

        [Test]
        public async Task GalleryApplication_CRUD_Tests()
        {
            string location = DefaultLocation;
            EnsureClientsInitialized(location);
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefix);

            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(location));
            Trace.TraceInformation("Created the resource group: " + rgName);
            string galleryName = Recording.GenerateAssetName(GalleryNamePrefix);
            Gallery gallery = GetTestInputGallery();
            gallery.Location = location;
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, gallery));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName, rgName));

            string galleryApplicationName = Recording.GenerateAssetName(GalleryApplicationNamePrefix);
            GalleryApplication inputGalleryApplication = GetTestInputGalleryApplication();
            await WaitForCompletionAsync(await GalleryApplicationsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryApplicationName, inputGalleryApplication));
            Trace.TraceInformation(string.Format("Created the gallery application: {0} in gallery: {1}", galleryApplicationName,
                galleryName));

            GalleryApplication galleryApplicationFromGet = await GalleryApplicationsOperations.GetAsync(rgName, galleryName, galleryApplicationName);
            Assert.NotNull(galleryApplicationFromGet);
            ValidateGalleryApplication(inputGalleryApplication, galleryApplicationFromGet);

            inputGalleryApplication.Description = "Updated description.";
            await WaitForCompletionAsync(await GalleryApplicationsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryApplicationName, inputGalleryApplication));
            Trace.TraceInformation(string.Format("Updated the gallery application: {0} in gallery: {1}", galleryApplicationName,
                galleryName));
            galleryApplicationFromGet = await GalleryApplicationsOperations.GetAsync(rgName, galleryName, galleryApplicationName);
            Assert.NotNull(galleryApplicationFromGet);
            ValidateGalleryApplication(inputGalleryApplication, galleryApplicationFromGet);

            await WaitForCompletionAsync(await GalleryApplicationsOperations.StartDeleteAsync(rgName, galleryName, galleryApplicationName));

            Trace.TraceInformation(string.Format("Deleted the gallery application: {0} in gallery: {1}", galleryApplicationName,
                galleryName));

            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName, galleryName));
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task GalleryApplicationVersion_CRUD_Tests()
        {
            string location = DefaultLocation;
            EnsureClientsInitialized(DefaultLocation);
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefix);
            string applicationName = Recording.GenerateAssetName("psTestSourceApplication");
            string galleryName = Recording.GenerateAssetName(GalleryNamePrefix);
            string galleryApplicationName = Recording.GenerateAssetName(GalleryApplicationNamePrefix);
            string applicationMediaLink = await CreateApplicationMediaLink(rgName, "test.txt");

            Assert.False(string.IsNullOrEmpty(applicationMediaLink));
            Trace.TraceInformation(string.Format("Created the source application media link: {0}", applicationMediaLink));

            Gallery gallery = GetTestInputGallery();
            gallery.Location = location;
            await WaitForCompletionAsync(await GalleriesOperations.StartCreateOrUpdateAsync(rgName, galleryName, gallery));
            Trace.TraceInformation(string.Format("Created the gallery: {0} in resource group: {1}", galleryName,
                rgName));
            GalleryApplication inputGalleryApplication = GetTestInputGalleryApplication();
            await WaitForCompletionAsync(await GalleryApplicationsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryApplicationName, inputGalleryApplication));
            Trace.TraceInformation(string.Format("Created the gallery application: {0} in gallery: {1}", galleryApplicationName,
                galleryName));

            string galleryApplicationVersionName = "1.0.0";
            GalleryApplicationVersion inputApplicationVersion = GetTestInputGalleryApplicationVersion(applicationMediaLink);
            await WaitForCompletionAsync(await GalleryApplicationVersionsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryApplicationName,
                galleryApplicationVersionName, inputApplicationVersion));
            Trace.TraceInformation(string.Format("Created the gallery application version: {0} in gallery application: {1}",
                galleryApplicationVersionName, galleryApplicationName));

            GalleryApplicationVersion applicationVersionFromGet = await GalleryApplicationVersionsOperations.GetAsync(rgName,
                galleryName, galleryApplicationName, galleryApplicationVersionName);
            Assert.NotNull(applicationVersionFromGet);
            ValidateGalleryApplicationVersion(inputApplicationVersion, applicationVersionFromGet);
            //applicationVersionFromGet = await GalleryApplicationVersionsClient.Get(rgName, galleryName, galleryApplicationName,
            //    galleryApplicationVersionName, ReplicationStatusTypes.ReplicationStatus);
            applicationVersionFromGet = await GalleryApplicationVersionsOperations.GetAsync(rgName, galleryName, galleryApplicationName,
                    galleryApplicationVersionName);
            Assert.AreEqual(StorageAccountType.StandardLRS, applicationVersionFromGet.PublishingProfile.StorageAccountType);
            Assert.AreEqual(StorageAccountType.StandardLRS,
                applicationVersionFromGet.PublishingProfile.TargetRegions.First().StorageAccountType);
            Assert.NotNull(applicationVersionFromGet.ReplicationStatus);
            Assert.NotNull(applicationVersionFromGet.ReplicationStatus.Summary);

            inputApplicationVersion.PublishingProfile.EndOfLifeDate = Recording.UtcNow.AddDays(100);
            await WaitForCompletionAsync(await GalleryApplicationVersionsOperations.StartCreateOrUpdateAsync(rgName, galleryName, galleryApplicationName,
                galleryApplicationVersionName, inputApplicationVersion));
            Trace.TraceInformation(string.Format("Updated the gallery application version: {0} in gallery application: {1}",
                galleryApplicationVersionName, galleryApplicationName));
            applicationVersionFromGet = await GalleryApplicationVersionsOperations.GetAsync(rgName, galleryName,
                galleryApplicationName, galleryApplicationVersionName);
            Assert.NotNull(applicationVersionFromGet);
            ValidateGalleryApplicationVersion(inputApplicationVersion, applicationVersionFromGet);

            await WaitForCompletionAsync(await GalleryApplicationVersionsOperations.StartDeleteAsync(rgName, galleryName, galleryApplicationName, galleryApplicationVersionName));
            Trace.TraceInformation(string.Format("Deleted the gallery application version: {0} in gallery application: {1}",
                galleryApplicationVersionName, galleryApplicationName));

            await WaitForCompletionAsync(await GalleryApplicationsOperations.StartDeleteAsync(rgName, galleryName, galleryApplicationName));
            Trace.TraceInformation("Deleted the gallery application.");
            await WaitForCompletionAsync(await GalleriesOperations.StartDeleteAsync(rgName, galleryName));
            Trace.TraceInformation("Deleted the gallery.");
        }

        private void ValidateGallery(Gallery galleryIn, Gallery galleryOut)
        {
            Assert.False(string.IsNullOrEmpty(galleryOut.ProvisioningState.ToString()));

            if (galleryIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in galleryIn.Tags)
                {
                    Assert.AreEqual(kvp.Value, galleryOut.Tags[kvp.Key]);
                }
            }

            if (!string.IsNullOrEmpty(galleryIn.Description))
            {
                Assert.AreEqual(galleryIn.Description, galleryOut.Description);
            }

            Assert.False(string.IsNullOrEmpty(galleryOut?.Identifier?.UniqueName));
        }

        private void ValidateGalleryImage(GalleryImage imageIn, GalleryImage imageOut)
        {
            Assert.False(string.IsNullOrEmpty(imageOut.ProvisioningState.ToString()));

            if (imageIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in imageIn.Tags)
                {
                    Assert.AreEqual(kvp.Value, imageOut.Tags[kvp.Key]);
                }
            }

            Assert.AreEqual(imageIn.Identifier.Publisher, imageOut.Identifier.Publisher);
            Assert.AreEqual(imageIn.Identifier.Offer, imageOut.Identifier.Offer);
            Assert.AreEqual(imageIn.Identifier.Sku, imageOut.Identifier.Sku);
            Assert.AreEqual(imageIn.Location, imageOut.Location);
            Assert.AreEqual(imageIn.OsState, imageOut.OsState);
            Assert.AreEqual(imageIn.OsType, imageOut.OsType);
            if (imageIn.HyperVGeneration == null)
            {
                Assert.AreEqual(HyperVGeneration.V1, imageOut.HyperVGeneration);
            }
            else
            {
                Assert.AreEqual(imageIn.HyperVGeneration, imageOut.HyperVGeneration);
            }

            if (!string.IsNullOrEmpty(imageIn.Description))
            {
                Assert.AreEqual(imageIn.Description, imageOut.Description);
            }
        }

        private void ValidateGalleryImageVersion(GalleryImageVersion imageVersionIn,
            GalleryImageVersion imageVersionOut)
        {
            Assert.False(string.IsNullOrEmpty(imageVersionOut.ProvisioningState.ToString()));

            if (imageVersionIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in imageVersionIn.Tags)
                {
                    Assert.AreEqual(kvp.Value, imageVersionOut.Tags[kvp.Key]);
                }
            }

            Assert.AreEqual(imageVersionIn.Location, imageVersionOut.Location);
            Assert.False(string.IsNullOrEmpty(imageVersionOut.StorageProfile.Source.Id),
                "imageVersionOut.PublishingProfile.Source.ManagedImage.Id is null or empty.");
            Assert.NotNull(imageVersionOut.PublishingProfile.EndOfLifeDate);
            Assert.NotNull(imageVersionOut.PublishingProfile.PublishedDate);
            Assert.NotNull(imageVersionOut.StorageProfile);
        }

        private Gallery GetTestInputGallery()
        {
            return new Gallery(LocationEastUs2)
            {
                Description = "This is a sample gallery description"
            };
        }

        private GalleryImage GetTestInputGalleryImage()
        {
            return new GalleryImage(LocationEastUs2)
            {
                Identifier = new GalleryImageIdentifier("testPub", "testOffer", "testSku"),
                OsState = OperatingSystemStateTypes.Generalized,
                OsType = OperatingSystemTypes.Windows,
                Description = "This is the gallery image description.",
                HyperVGeneration = null
            };
        }

        private GalleryImageVersion GetTestInputGalleryImageVersion(string sourceImageId)
        {
            return new GalleryImageVersion(LocationEastUs2)
            {
                PublishingProfile = new GalleryImageVersionPublishingProfile
                {
                    ReplicaCount = 1,
                    StorageAccountType = StorageAccountType.StandardLRS,
                    TargetRegions = new List<TargetRegion> {
                        new TargetRegion(LocationEastUs2) {
                            RegionalReplicaCount = 1,
                            StorageAccountType = StorageAccountType.StandardLRS
                        }
                    },
                    EndOfLifeDate = Recording.UtcNow.AddDays(10)
                },
                StorageProfile = new GalleryImageVersionStorageProfile
                {
                    Source = new GalleryArtifactVersionSource
                    {
                        Id = sourceImageId
                    }
                }
            };
        }

        private async Task<VirtualMachine> CreateCRPImage(string rgName, string imageName)
        {
            string storageAccountName = Recording.GenerateAssetName("saforgallery");
            string asName = Recording.GenerateAssetName("asforgallery");
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName); // resource group is also created in this method.
            VirtualMachine inputVM = null;
            var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef);
            VirtualMachine createdVM = returnTwoVM.Item1;
            inputVM = returnTwoVM.Item2;
            Image imageInput = new Image(m_location)
            {
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                StorageProfile = new ImageStorageProfile()
                {
                    OsDisk = new ImageOSDisk(OperatingSystemTypes.Windows, OperatingSystemStateTypes.Generalized)
                    {
                        BlobUri = createdVM.StorageProfile.OsDisk.Vhd.Uri,
                    },
                    ZoneResilient = true
                },
                HyperVGeneration = HyperVGenerationTypes.V1
            };
            await WaitForCompletionAsync(await ImagesOperations.StartCreateOrUpdateAsync(rgName, imageName, imageInput));
            Image getImage = await ImagesOperations.GetAsync(rgName, imageName);
            sourceImageId = getImage.Id;
            return createdVM;
        }

        private async Task<string> CreateApplicationMediaLink(string rgName, string fileName)
        {
            string storageAccountName = Recording.GenerateAssetName("saforgallery");
            string asName = Recording.GenerateAssetName("asforgallery");
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName); // resource group is also created in this method.
            string applicationMediaLink = @"https://saforgallery1969.blob.core.windows.net/sascontainer/test.txt\";
            if (Mode == RecordedTestMode.Record)
            {
                var accountKeyResult = await (StorageAccountsOperations.ListKeysAsync(rgName, storageAccountName));
                StorageAccount storageAccount = new StorageAccount(DefaultLocation);
                //StorageAccount storageAccount = new StorageAccount(new StorageCredentials(storageAccountName, accountKeyResult.Body.Key1), useHttps: true);

                //var blobClient = storageAccount.CreateCloudBlobClient();
                BlobContainer container = await BlobContainersOperations.GetAsync(rgName, storageAccountName, "sascontainer");

                //byte[] blobContent = Encoding.UTF8.GetBytes("Application Package Test");
                //byte[] bytes = new byte[512]; // Page blob must be multiple of 512
                //System.Buffer.BlockCopy(blobContent, 0, bytes, 0, blobContent.Length);
                //var blobClient = storageAccount.CreateCloudBlobClient();
                //CloudBlobContainer container = blobClient.GetContainerReference("sascontainer");
                //bool created = container.CreateIfNotExistsAsync().Result;

                //CloudPageBlob pageBlob = container.GetPageBlobReference(fileName);
                //byte[] blobContent = Encoding.UTF8.GetBytes("Application Package Test");
                //byte[] bytes = new byte[512]; // Page blob must be multiple of 512
                //System.Buffer.BlockCopy(blobContent, 0, bytes, 0, blobContent.Length);
                //pageBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);

                //SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                //sasConstraints.SharedAccessStartTime = Recording.UtcNow.AddDays(-1);
                //sasConstraints.SharedAccessExpiryTime = Recording.UtcNow.AddDays(2);
                //sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

                ////Generate the shared access signature on the blob, setting the constraints directly on the signature.
                //string sasContainerToken = pageBlob.GetSharedAccessSignature(sasConstraints);

                ////Return the URI string for the container, including the SAS token.
                //applicationMediaLink = pageBlob.Uri + sasContainerToken;
            }
            return applicationMediaLink;
        }

        private GalleryApplication GetTestInputGalleryApplication()
        {
            return new GalleryApplication(DefaultLocation)
            {
                Eula = "This is the gallery application EULA.",
                SupportedOSType = OperatingSystemTypes.Windows,
                PrivacyStatementUri = "www.privacystatement.com",
                ReleaseNoteUri = "www.releasenote.com",
                Description = "This is the gallery application description.",
            };
        }

        private GalleryApplicationVersion GetTestInputGalleryApplicationVersion(string applicationMediaLink)
        {
            return new GalleryApplicationVersion(DefaultLocation)
            {
                PublishingProfile = new GalleryApplicationVersionPublishingProfile(
                    new UserArtifactSource("test.zip", applicationMediaLink))
                {
                    ReplicaCount = 1,
                    StorageAccountType = StorageAccountType.StandardLRS,
                    TargetRegions = new List<TargetRegion> {
                        new TargetRegion(DefaultLocation){ RegionalReplicaCount = 1, StorageAccountType = StorageAccountType.StandardLRS }
                    },
                    EndOfLifeDate = Recording.UtcNow.AddDays(10)
                }
            };
        }

        private void ValidateGalleryApplication(GalleryApplication applicationIn, GalleryApplication applicationOut)
        {
            if (applicationIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in applicationIn.Tags)
                {
                    Assert.AreEqual(kvp.Value, applicationOut.Tags[kvp.Key]);
                }
            }
            Assert.AreEqual(applicationIn.Eula, applicationOut.Eula);
            Assert.AreEqual(applicationIn.PrivacyStatementUri, applicationOut.PrivacyStatementUri);
            Assert.AreEqual(applicationIn.ReleaseNoteUri, applicationOut.ReleaseNoteUri);
            Assert.AreEqual(applicationIn.Location.ToLower(), applicationOut.Location.ToLower());
            Assert.AreEqual(applicationIn.SupportedOSType, applicationOut.SupportedOSType);
            if (!string.IsNullOrEmpty(applicationIn.Description))
            {
                Assert.AreEqual(applicationIn.Description, applicationOut.Description);
            }
        }

        private void ValidateGalleryApplicationVersion(GalleryApplicationVersion applicationVersionIn, GalleryApplicationVersion applicationVersionOut)
        {
            Assert.False(string.IsNullOrEmpty("properties.provisioningState"));

            if (applicationVersionIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in applicationVersionIn.Tags)
                {
                    Assert.AreEqual(kvp.Value, applicationVersionOut.Tags[kvp.Key]);
                }
            }

            Assert.AreEqual(applicationVersionIn.Location.ToLower(), applicationVersionOut.Location.ToLower());
            Assert.False(string.IsNullOrEmpty(applicationVersionOut.PublishingProfile.Source.MediaLink),
                "applicationVersionOut.PublishingProfile.Source.MediaLink is null or empty.");
            Assert.NotNull(applicationVersionOut.PublishingProfile.EndOfLifeDate);
            Assert.NotNull(applicationVersionOut.PublishingProfile.PublishedDate);
            Assert.NotNull(applicationVersionOut.Id);
        }
    }
}
