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
    public class GalleryImageOperationsTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;

        public GalleryImageOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryImage> CreateGalleryImageAsync(string galleryImageName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _gallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, galleryInput);
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            return await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, imageInput);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            await image.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var deleteOp = await image.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            GalleryImage image2 = await image.GetAsync();

            ResourceDataHelper.AssertGalleryImage(image.Data, image2.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("There is a bug in OperationInternals causing we cannot handle this kind of PATCH LRO right now")]
        public async Task Update()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var description = "This is a gallery for test";
            var update = new GalleryImageUpdate()
            {
                OsType = OperatingSystemTypes.Linux, // We have to put this here, otherwise we get a 409 Changing property 'galleryImage.properties.osType' is not allowed.
                Description = description
            };
            GalleryImage updatedGalleryImage = await image.UpdateAsync(update);

            Assert.AreEqual(description, updatedGalleryImage.Data.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImage updatedGalleryImage = await image.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedGalleryImage.Data.Tags);
        }
    }
}
