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
    public class GalleryContainerTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;

        public GalleryContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryContainer> GetGalleryContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetGalleries();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetGalleryContainerAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            Gallery gallery = await container.CreateOrUpdateAsync(name, input);
            Assert.AreEqual(name, gallery.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetGalleryContainerAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            Gallery gallery = await container.CreateOrUpdateAsync(name, input);
            Gallery gallery2 = await container.GetAsync(name);

            ResourceDataHelper.AssertGallery(gallery.Data, gallery2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetGalleryContainerAsync();
            var name = Recording.GenerateAssetName("testGallery_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            Gallery gallery = await container.CreateOrUpdateAsync(name, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(name));
            Assert.IsFalse(await container.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetGalleryContainerAsync();
            var name1 = Recording.GenerateAssetName("testGallery_");
            var name2 = Recording.GenerateAssetName("testGallery_");
            var input1 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var input2 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(name1, input1);
            _ = await container.CreateOrUpdateAsync(name2, input2);
            int count = 0;
            await foreach (var gallery in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var container = await GetGalleryContainerAsync();
            var name1 = Recording.GenerateAssetName("testGallery_");
            var name2 = Recording.GenerateAssetName("testGallery_");
            var input1 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var input2 = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(name1, input1);
            _ = await container.CreateOrUpdateAsync(name2, input2);

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
