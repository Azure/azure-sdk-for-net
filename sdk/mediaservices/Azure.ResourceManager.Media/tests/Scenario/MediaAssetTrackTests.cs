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
        private MediaAssetResource _mediaAssetResource;

        private MediaAssetTrackCollection mediaAssetCollection => _mediaAssetResource.GetMediaAssetTracks();

        public MediaAssetTrackTests(bool isAsync)
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
