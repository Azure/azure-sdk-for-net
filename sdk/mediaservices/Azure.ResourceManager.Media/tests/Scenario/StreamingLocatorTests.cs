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
    public class StreamingLocatorTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private StreamingLocatorCollection streamingLocatorCollection => _mediaService.GetStreamingLocators();

        public StreamingLocatorTests(bool isAsync) : base(isAsync)
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

        private async Task<StreamingLocatorResource> CreateStreamingLocator(string streamingLocatorName)
        {
            var emptyAsset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("emptyAsset"), new MediaAssetData());
            StreamingLocatorData data = new StreamingLocatorData()
            {
                AssetName = emptyAsset.Value.Data.Name,
                StreamingPolicyName = "Predefined_ClearStreamingOnly"
            };
            var streamingLocator = await streamingLocatorCollection.CreateOrUpdateAsync(WaitUntil.Completed, streamingLocatorName, data);
            return streamingLocator.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string streamingLocatorName = SessionRecording.GenerateAssetName("streamingLocator");
            var streamingLocator = await CreateStreamingLocator(streamingLocatorName);
            Assert.IsNotNull(streamingLocator);
            Assert.AreEqual(streamingLocatorName, streamingLocator.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string streamingLocatorName = SessionRecording.GenerateAssetName("streamingLocator");
            await CreateStreamingLocator(streamingLocatorName);
            bool flag = await streamingLocatorCollection.ExistsAsync(streamingLocatorName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string streamingLocatorName = SessionRecording.GenerateAssetName("streamingLocator");
            await CreateStreamingLocator(streamingLocatorName);
            var streamingLocator = await streamingLocatorCollection.GetAsync(streamingLocatorName);
            Assert.IsNotNull(streamingLocator);
            Assert.AreEqual(streamingLocatorName, streamingLocator.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string streamingLocatorName = SessionRecording.GenerateAssetName("streamingLocator");
            await CreateStreamingLocator(streamingLocatorName);
            var list = await streamingLocatorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string streamingLocatorName = SessionRecording.GenerateAssetName("streamingLocator");
            var streamingLocator = await CreateStreamingLocator(streamingLocatorName);
            bool flag = await streamingLocatorCollection.ExistsAsync(streamingLocatorName);
            Assert.IsTrue(flag);

            await streamingLocator.DeleteAsync(WaitUntil.Completed);
            flag = await streamingLocatorCollection.ExistsAsync(streamingLocatorName);
            Assert.IsFalse(flag);
        }
    }
}
