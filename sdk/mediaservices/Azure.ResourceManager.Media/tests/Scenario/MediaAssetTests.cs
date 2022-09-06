// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaAssetTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private MediaAssetCollection mediaAssetCollection => _mediaService.GetMediaAssets();

        public MediaAssetTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            _mediaServiceIdentifier = mediaService.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string assetName = SessionRecording.GenerateAssetName("asset");
            var mediaAsset = await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(assetName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string assetName = SessionRecording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            bool flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string assetName = SessionRecording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            var mediaAsset = await mediaAssetCollection.GetAsync(assetName);
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(assetName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string assetName = SessionRecording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            var list = await mediaAssetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string assetName = SessionRecording.GenerateAssetName("asset");
            var mediaAsset = await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            bool flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsTrue(flag);

            await mediaAsset.Value.DeleteAsync(WaitUntil.Completed);
            flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsFalse(flag);
        }
    }
}
