// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryImageContainerTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;

        public GalleryImageContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private GalleryImageData BasicGalleryImageData
        {
            get
            {
                var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
                return ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            }
        }

        private async Task<GalleryImageContainer> GetGalleryImageContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _gallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, input);
            return _gallery.GetGalleryImages();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetGalleryImageContainerAsync();
            var name = Recording.GenerateAssetName("testImage_");
            GalleryImage image = await container.CreateOrUpdateAsync(name, BasicGalleryImageData);
            Assert.AreEqual(name, image.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetGalleryImageContainerAsync();
            var name = Recording.GenerateAssetName("testImage_");
            GalleryImage image = await container.CreateOrUpdateAsync(name, BasicGalleryImageData);
            GalleryImage image2 = await container.GetAsync(name);

            ResourceDataHelper.AssertGalleryImage(image.Data, image2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetGalleryImageContainerAsync();
            var name = Recording.GenerateAssetName("testImage_");
            GalleryImage image = await container.CreateOrUpdateAsync(name, BasicGalleryImageData);
            Assert.IsTrue(await container.CheckIfExistsAsync(name));
            Assert.IsFalse(await container.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetGalleryImageContainerAsync();
            var name1 = Recording.GenerateAssetName("testImage_");
            var name2 = Recording.GenerateAssetName("testImage_");
            var input1 = BasicGalleryImageData;
            var input2 = BasicGalleryImageData;
            _ = await container.CreateOrUpdateAsync(name1, input1);
            _ = await container.CreateOrUpdateAsync(name2, input2);
            int count = 0;
            await foreach (var galleryImage in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
