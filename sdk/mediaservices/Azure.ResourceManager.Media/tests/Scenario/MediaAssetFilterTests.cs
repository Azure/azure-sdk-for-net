// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaAssetFilterTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaAssetIdentifier;
        private MediaAssetResource _mediaAssetResource;

        private AssetFilterCollection assetFilterCollection => _mediaAssetResource.GetAssetFilters();

        public MediaAssetFilterTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            var mediaAsset = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("asset"), new MediaAssetData());
            _mediaAssetIdentifier = mediaAsset.Value.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaAssetResource = await Client.GetMediaAssetResource(_mediaAssetIdentifier).GetAsync();
        }

        private async Task<AssetFilterResource> CreateDefaultAssetFilter(string filterName)
        {
            AssetFilterData data = new AssetFilterData();
            var filter = await assetFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, filterName, data);
            return filter.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string filterName = SessionRecording.GenerateAssetName("filter");
            var filter =await CreateDefaultAssetFilter(filterName);
            Assert.IsNotNull(filter);
            Assert.AreEqual(filterName, filter.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string filterName = SessionRecording.GenerateAssetName("filter");
            await CreateDefaultAssetFilter(filterName);
            bool flag = await assetFilterCollection.ExistsAsync(filterName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string filterName = SessionRecording.GenerateAssetName("filter");
            await CreateDefaultAssetFilter(filterName);
            var filter = await assetFilterCollection.GetAsync(filterName);
            Assert.IsNotNull(filter);
            Assert.AreEqual(filterName, filter.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string filterName = SessionRecording.GenerateAssetName("filter");
            await CreateDefaultAssetFilter(filterName);
            var list = await assetFilterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string filterName = SessionRecording.GenerateAssetName("filter");
            var filter=await CreateDefaultAssetFilter(filterName);
            bool flag = await assetFilterCollection.ExistsAsync(filterName);
            Assert.IsTrue(flag);

            await filter.DeleteAsync(WaitUntil.Completed);
            flag = await assetFilterCollection.ExistsAsync(filterName);
            Assert.IsFalse(flag);
        }
    }
}
