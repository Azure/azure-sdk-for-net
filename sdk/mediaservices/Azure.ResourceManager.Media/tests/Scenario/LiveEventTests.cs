// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class LiveEventTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private LiveEventCollection liveEventCollection => _mediaService.GetLiveEvents();

        public LiveEventTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.WestUS2);
            var storage = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName(StorageAccountNamePrefix));
            _mediaService = await CreateMediaService(resourceGroup, Recording.GenerateAssetName("mediaservice"), storage.Id);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Create()
        {
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            var liveEvent = await CreateLiveEvent(_mediaService, liveEventName);
            Assert.IsNotNull(liveEvent);
            Assert.AreEqual(liveEventName, liveEvent.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Exist()
        {
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            await CreateLiveEvent(_mediaService, liveEventName);
            bool flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Get()
        {
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            await CreateLiveEvent(_mediaService, liveEventName);
            var liveEvent = await liveEventCollection.GetAsync(liveEventName);
            Assert.IsNotNull(liveEvent);
            Assert.AreEqual(liveEventName, liveEvent.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task GetAll()
        {
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            await CreateLiveEvent(_mediaService, liveEventName);
            var list = await liveEventCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Delete()
        {
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            var liveEvent = await CreateLiveEvent(_mediaService, liveEventName);
            bool flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.IsTrue(flag);

            await liveEvent.DeleteAsync(WaitUntil.Completed);
            flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.IsFalse(flag);
        }
    }
}
