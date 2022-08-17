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
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServiceResource _mediaService;

        private LiveEventCollection liveEventCollection => _mediaService.GetLiveEvents();

        public LiveEventTests(bool isAsync) : base(isAsync)
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
            _mediaService = await Client.GetMediaServiceResource(_mediaServiceIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("LiveEventInput.keyFrameIntervalDuration: System.FormatException : The string '' is not a valid TimeSpan value")]
        public async Task CreateOrUpdate()
        {
            LiveEventData data = new LiveEventData(_mediaService.Data.Location)
            {
                Input  = new LiveEventInput(LiveEventInputProtocol.Rtmp),
            };
            string liveEventName = SessionRecording.GenerateAssetName("liveEventName");
            var liveEvent = await liveEventCollection.CreateOrUpdateAsync(WaitUntil.Completed, liveEventName, data);
            Assert.IsNotNull(liveEvent);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await liveEventCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
