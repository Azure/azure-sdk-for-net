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
    public class MediaAssetTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private MediaAssetCollection mediaAssetCollection => _mediaService.GetMediaAssets();

        public MediaAssetTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            var mediaServiceName = SessionRecording.GenerateAssetName("dotnetsdkmediatest");
            if (Mode == RecordedTestMode.Playback)
            {
                _mediaServiceIdentifier = MediaServicesAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var mediaService = await CreateMediaService(rgLro.Value, mediaServiceName, storage.Id);
                    _mediaServiceIdentifier = mediaService.Id;
                }
            }
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
            string assetName = Recording.GenerateAssetName("asset");
            var mediaAsset = await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(assetName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string assetName = Recording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            bool flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string assetName = Recording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            var mediaAsset = await mediaAssetCollection.GetAsync(assetName);
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(assetName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string assetName = Recording.GenerateAssetName("asset");
            await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            var list = await mediaAssetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string assetName = Recording.GenerateAssetName("asset");
            var mediaAsset = await mediaAssetCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, new MediaAssetData());
            bool flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsTrue(flag);

            await mediaAsset.Value.DeleteAsync(WaitUntil.Completed);
            flag = await mediaAssetCollection.ExistsAsync(assetName);
            Assert.IsFalse(flag);
        }
    }
}
