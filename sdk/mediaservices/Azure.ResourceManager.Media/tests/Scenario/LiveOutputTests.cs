// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class LiveOutputTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;
        private LiveEventResource _liveEvent;

        private LiveOutputCollection liveOutputCollection => _liveEvent.GetLiveOutputs();

        public LiveOutputTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.WestUS2);
            var storage = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName(StorageAccountNamePrefix));
            _mediaService = await CreateMediaService(resourceGroup, Recording.GenerateAssetName("mediaservice"), storage.Id);
            _liveEvent = await CreateLiveEvent(_mediaService, Recording.GenerateAssetName("liveEvent"));
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await liveOutputCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<LiveOutputResource> CreateLiveOutPut(string liveOutPutName)
        {
            var asset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, "empty-asset-input", new MediaAssetData());
            LiveOutputData data = new LiveOutputData()
            {
                AssetName = asset.Value.Data.Name,
                ArchiveWindowLength = new TimeSpan(0, 5, 0),
                HttpLiveStreaming = new Hls()
                {
                    FragmentsPerTsSegment = 5
                },
            };
            var liveOutPut = await liveOutputCollection.CreateOrUpdateAsync(WaitUntil.Completed, liveOutPutName, data);
            return liveOutPut.Value;
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task CreateOrUpdate()
        {
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            var liveoutput = await CreateLiveOutPut(liveOutPutName);
            Assert.IsNotNull(liveoutput);
            Assert.AreEqual(liveOutPutName, liveoutput.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Exist()
        {
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            await CreateLiveOutPut(liveOutPutName);
            bool flag = await liveOutputCollection.ExistsAsync(liveOutPutName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Get()
        {
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            await CreateLiveOutPut(liveOutPutName);
            var liveoutput = await liveOutputCollection.GetAsync(liveOutPutName);
            Assert.IsNotNull(liveoutput);
            Assert.AreEqual(liveOutPutName, liveoutput.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task GetAll()
        {
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            await CreateLiveOutPut(liveOutPutName);
            var list = await liveOutputCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Delete()
        {
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            var liveoutput = await CreateLiveOutPut(liveOutPutName);
            bool flag = await liveOutputCollection.ExistsAsync(liveOutPutName);
            Assert.IsTrue(flag);

            await liveoutput.DeleteAsync(WaitUntil.Completed);
            flag = await liveOutputCollection.ExistsAsync(liveOutPutName);
            Assert.IsFalse(flag);
        }
    }
}
