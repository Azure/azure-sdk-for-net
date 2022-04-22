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

        private async Task<Gallery> CreateGalleryAsync(string galleryName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(true, galleryName, galleryInput);
            _gallery = lro.Value;
            return _gallery;
        }

        private async Task<GalleryImage> CreateGalleryImageAsync(string galleryImageName)
        {
            var galleryName = Recording.GenerateAssetName("testGallery_");
            _gallery = await CreateGalleryAsync(galleryName);
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            var lro = await _gallery.GetGalleryImages().CreateOrUpdateAsync(true, galleryImageName, imageInput);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            await image.DeleteAsync(true);
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
        public async Task Update()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var description = "This is a gallery for test";
            var update = new GalleryImageUpdate()
            {
                OSType = OperatingSystemTypes.Linux, // We have to put this here, otherwise we get a 409 Changing property 'galleryImage.properties.osType' is not allowed.
                Description = description
            };
            var lro = await image.UpdateAsync(true, update);
            GalleryImage updatedGalleryImage = lro.Value;

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
