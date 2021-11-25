// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryCollectionTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;

        public GalleryCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryCollection> GetGalleryCollectionAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetGalleries();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetGalleryCollectionAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            Gallery gallery = lro.Value;
            Assert.AreEqual(name, gallery.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetGalleryCollectionAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            Gallery gallery1 = lro.Value;
            Gallery gallery2 = await collection.GetAsync(name);

            ResourceDataHelper.AssertGallery(gallery1.Data, gallery2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetGalleryCollectionAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            Gallery gallery = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(name));
            Assert.IsFalse(await collection.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetGalleryCollectionAsync();
            var name1 = Recording.GenerateAssetName("testGallery_");
            var name2 = Recording.GenerateAssetName("testGallery_");
            var input1 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var input2 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _ = await collection.CreateOrUpdateAsync(name1, input1);
            _ = await collection.CreateOrUpdateAsync(name2, input2);
            int count = 0;
            await foreach (var gallery in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetGalleryCollectionAsync();
            var name1 = Recording.GenerateAssetName("testGallery_");
            var name2 = Recording.GenerateAssetName("testGallery_");
            var input1 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var input2 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _ = await collection.CreateOrUpdateAsync(name1, input1);
            _ = await collection.CreateOrUpdateAsync(name2, input2);

            Gallery gallery1 = null, gallery2 = null;
            await foreach (var gallery in DefaultSubscription.GetGalleriesAsync())
            {
                if (gallery.Data.Name == name1)
                    gallery1 = gallery;
                if (gallery.Data.Name == name2)
                    gallery2 = gallery;
            }

            Assert.NotNull(gallery1);
            Assert.NotNull(gallery2);
        }
    }
}
