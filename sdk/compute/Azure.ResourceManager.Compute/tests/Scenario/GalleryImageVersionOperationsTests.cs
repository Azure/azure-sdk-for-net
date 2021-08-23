// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryImageVersionOperationsTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;
        private GalleryImage _galleryImage;
        private GalleryImageVersion _galleryImageVersion;
        private Disk _disk;
        public GalleryImageVersionOperationsTests(bool isAsync)
        : base(isAsync , RecordedTestMode.Record)
        {
        }

        private async Task<GalleryImageVersion> CreateGalleryImageVersionAsync(string galleryImageVersionName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var galleryImageName = Recording.GenerateAssetName("testGalleryImage_");
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var Iro_gallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, galleryInput);
            _gallery = Iro_gallery.Value;
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var Iro_disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            _disk = Iro_disk.Value;
            //var GalleryImageVersionName = "1.0.0";
            var diskID = _disk.Id;
            var imageVersionInput = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, diskID);
            //var imageVersionInput = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation);
            var Iro_galleryImage = await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, imageInput);
            _galleryImage = Iro_galleryImage.Value;
            var Iro_galleryImageVersion =  await _galleryImage.GetGalleryImageVersions().CreateOrUpdateAsync(galleryImageVersionName, imageVersionInput);
            _galleryImageVersion = Iro_galleryImageVersion.Value;
            return _galleryImageVersion;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testGalleryImage_");
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            await imageVersion.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testGalleryImage_");
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            GalleryImageVersion imageVersion2 = await imageVersion.GetAsync();

            ResourceDataHelper.AssertGalleryImageVersion(imageVersion.Data, imageVersion2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var name = Recording.GenerateAssetName("testGalleryImage_");
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            var publishingProfile = new GalleryImageVersionPublishingProfile();
            var update = new GalleryImageVersionUpdate()
            {
            };
            var Iro_updatedGalleryImageVersion = await imageVersion.UpdateAsync(update);
            GalleryImageVersion updatedGalleryImageVersion = Iro_updatedGalleryImageVersion.Value;
            Assert.AreEqual(publishingProfile, updatedGalleryImageVersion.Data.StorageProfile);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            var name = Recording.GenerateAssetName("testGalleryVersion_");
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImageVersion updatedGalleryImageVersion = await imageVersion.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedGalleryImageVersion.Data.Tags);
        }
    }
}
