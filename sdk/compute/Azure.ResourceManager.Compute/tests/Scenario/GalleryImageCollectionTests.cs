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
    public class GalleryImageCollectionTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;

        public GalleryImageCollectionTests(bool isAsync)
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

        private async Task<GalleryImageCollection> GetGalleryImageCollectionAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, input);
            _gallery = lro.Value;
            return _gallery.GetGalleryImages();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetGalleryImageCollectionAsync();
            var name = Recording.GenerateAssetName("testImage_");
            var lro = await collection.CreateOrUpdateAsync(name, BasicGalleryImageData);
            GalleryImage image = lro.Value;
            Assert.AreEqual(name, image.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetGalleryImageCollectionAsync();
            var name = Recording.GenerateAssetName("testImage_");
            var lro = await collection.CreateOrUpdateAsync(name, BasicGalleryImageData);
            GalleryImage image1 = lro.Value;
            GalleryImage image2 = await collection.GetAsync(name);

            ResourceDataHelper.AssertGalleryImage(image1.Data, image2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var collection = await GetGalleryImageCollectionAsync();
            var name = Recording.GenerateAssetName("testImage_");
            var lro = await collection.CreateOrUpdateAsync(name, BasicGalleryImageData);
            GalleryImage image = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(name));
            Assert.IsFalse(await collection.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetGalleryImageCollectionAsync();
            var name1 = Recording.GenerateAssetName("testImage_");
            var name2 = Recording.GenerateAssetName("testImage_");
            var input1 = BasicGalleryImageData;
            var input2 = BasicGalleryImageData;
            _ = await collection.CreateOrUpdateAsync(name1, input1);
            _ = await collection.CreateOrUpdateAsync(name2, input2);
            int count = 0;
            await foreach (var galleryImage in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
