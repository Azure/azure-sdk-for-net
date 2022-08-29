// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaTransformTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private MediaTransformCollection mediaTransformCollection => _mediaService.GetMediaTransforms();

        public MediaTransformTests(bool isAsync) : base(isAsync)
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
            string mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(mediaTransformCollection, mediaTransformName);
            Assert.IsNotNull(mediaTransfer);
            Assert.AreEqual(mediaTransformName, mediaTransfer.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            await CreateMediaTransfer(mediaTransformCollection, mediaTransformName);
            bool flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            await CreateMediaTransfer(mediaTransformCollection, mediaTransformName);
            var mediaTransfer = await mediaTransformCollection.GetAsync(mediaTransformName);
            Assert.IsNotNull(mediaTransfer);
            Assert.AreEqual(mediaTransformName, mediaTransfer.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(mediaTransformCollection, mediaTransformName);
            var list = await mediaTransformCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(mediaTransformCollection, mediaTransformName);
            bool flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsTrue(flag);

            await mediaTransfer.DeleteAsync(WaitUntil.Completed);
            flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsFalse(flag);
        }
    }
}
