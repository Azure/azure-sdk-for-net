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
        private ResourceIdentifier _mediaServiceIdentifier;
        private ResourceIdentifier _liveEventIdentifier;
        private MediaServicesAccountResource _mediaService;
        private LiveEventResource _liveEvent;
        private string _liveOutPutName; // The maximum allowed number of liveOutputs per liveEvent has been reached, maximum number is 3

        private LiveOutputCollection liveOutputCollection => _liveEvent.GetLiveOutputs();

        public LiveOutputTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            var liveEvent = await CreateLiveEvent(mediaService, SessionRecording.GenerateAssetName("liveEvent"));
            _liveOutPutName = SessionRecording.GenerateAssetName("liveoutput");
            _mediaServiceIdentifier = mediaService.Id;
            _liveEventIdentifier = liveEvent.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
            _liveEvent = await Client.GetLiveEventResource(_liveEventIdentifier).GetAsync();
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

        private async Task<LiveOutputResource> CreateLiveOutPut()
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
            var liveOutPut = await liveOutputCollection.CreateOrUpdateAsync(WaitUntil.Completed, _liveOutPutName, data);
            return liveOutPut.Value;
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task CreateOrUpdate()
        {
            var liveoutput = await CreateLiveOutPut();
            Assert.IsNotNull(liveoutput);
            Assert.AreEqual(_liveOutPutName, liveoutput.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Exist()
        {
            await CreateLiveOutPut();
            bool flag = await liveOutputCollection.ExistsAsync(_liveOutPutName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Get()
        {
            await CreateLiveOutPut();
            var liveoutput = await liveOutputCollection.GetAsync(_liveOutPutName);
            Assert.IsNotNull(liveoutput);
            Assert.AreEqual(_liveOutPutName, liveoutput.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task GetAll()
        {
            await CreateLiveOutPut();
            var list = await liveOutputCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Make sure [AccessToken] is not in the recording file during the re-recording process")]
        public async Task Delete()
        {
            var liveoutput = await CreateLiveOutPut();
            bool flag = await liveOutputCollection.ExistsAsync(_liveOutPutName);
            Assert.IsTrue(flag);

            await liveoutput.DeleteAsync(WaitUntil.Completed);
            flag = await liveOutputCollection.ExistsAsync(_liveOutPutName);
            Assert.IsFalse(flag);
        }
    }
}
