// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaAssetTrackTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaAssetIdentifier;
        private MediaAssetResource _mediaAsset;

        private MediaAssetTrackCollection mediaAssetCollection => _mediaAsset.GetMediaAssetTracks();

        public MediaAssetTrackTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            var mediaAsset = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("asset"), new MediaAssetData());
            _mediaAssetIdentifier = mediaAsset.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaAsset = await Client.GetMediaAssetResource(_mediaAssetIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("Azure.RequestFailedException : The server manifest (.ism) file is not found in the asset.")]
        public async Task GetAll()
        {
            var list = await mediaAssetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
