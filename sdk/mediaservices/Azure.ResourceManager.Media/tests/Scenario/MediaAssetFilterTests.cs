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
        private ResourceIdentifier _mediaAssetIdentifier;
        private MediaAssetResource _mediaAssetResource;

        private MediaAssetFilterCollection assetFilterCollection => _mediaAssetResource.GetMediaAssetFilters();

        public MediaAssetFilterTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            var mediaServiceName = SessionRecording.GenerateAssetName("dotnetsdkmediatest");
            var mediaAssetName = SessionRecording.GenerateAssetName("asset");
            if (Mode == RecordedTestMode.Playback)
            {
                _mediaAssetIdentifier = MediaAssetResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName, mediaAssetName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var mediaService = await CreateMediaService(rgLro.Value, mediaServiceName, storage.Id);
                    var mediaAsset = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, mediaAssetName, new MediaAssetData());
                    _mediaAssetIdentifier = mediaAsset.Value.Id;
                }
            }
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
