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
        private ResourceGroupResource _resourceGroup;

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
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            GalleryResource gallery = lro.Value;
            Assert.AreEqual(name, gallery.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetGalleryCollectionAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            GalleryResource gallery1 = lro.Value;
            GalleryResource gallery2 = await collection.GetAsync(name);

            ResourceDataHelper.AssertGallery(gallery1.Data, gallery2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetGalleryCollectionAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            GalleryResource gallery = lro.Value;
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name1, input1);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input2);
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name1, input1);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input2);

            GalleryResource gallery1 = null, gallery2 = null;
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
