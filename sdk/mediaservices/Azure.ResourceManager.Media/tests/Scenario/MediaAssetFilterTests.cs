// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaAssetFilterTests : MediaManagementTestBase
    {
        private MediaAssetResource _mediaAsset;

        private MediaAssetFilterCollection assetFilterCollection => _mediaAsset.GetMediaAssetFilters();

        public MediaAssetFilterTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            var mediaAssetName = Recording.GenerateAssetName("asset");
            var mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
            _mediaAsset = await CreateMediaAsset(mediaService, mediaAssetName);
        }

        private async Task<MediaAssetFilterResource> CreateDefaultAssetFilter(string filterName)
        {
            MediaAssetFilterData data = new MediaAssetFilterData();
            var filter = await assetFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, filterName, data);
            return filter.Value;
        }

        [Test]
        [RecordedTest]
        public async Task MediaAssetFilterBasicTests()
        {
            // Create
            string filterName = Recording.GenerateAssetName("mediaAssetFilter");
            var filter =await CreateDefaultAssetFilter(filterName);
            Assert.IsNotNull(filter);
            Assert.AreEqual(filterName, filter.Data.Name);
            // Check exists
            bool flag = await assetFilterCollection.ExistsAsync(filterName);
            Assert.IsTrue(flag);
            // Get
            var result = await assetFilterCollection.GetAsync(filterName);
            Assert.IsNotNull(filter);
            Assert.AreEqual(filterName, result.Value.Data.Name);
            // List
            var list = await assetFilterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await filter.DeleteAsync(WaitUntil.Completed);
            flag = await assetFilterCollection.ExistsAsync(filterName);
            Assert.IsFalse(flag);
        }
    }
}
