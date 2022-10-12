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

        private MediaAssetFilterCollection assetFilterCollection => _mediaAssetResource.GetMediaAssetFilters();

        public MediaAssetFilterTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaforasset"), storage.Id);
            var mediaAsset = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("asset"), new MediaAssetData());
            _mediaAssetIdentifier = mediaAsset.Value.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaAssetResource = await Client.GetMediaAssetResource(_mediaAssetIdentifier).GetAsync();
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
            string filterName = SessionRecording.GenerateAssetName("filterCreateOrUpdate");
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
