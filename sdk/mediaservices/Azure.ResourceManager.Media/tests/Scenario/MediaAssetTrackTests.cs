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
        private MediaAssetResource _mediaAsset;

        private MediaAssetTrackCollection mediaAssetCollection => _mediaAsset.GetMediaAssetTracks();

        public MediaAssetTrackTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.WestUS2);
            var storage = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(resourceGroup, Recording.GenerateAssetName("mediaservice"), storage.Id);
            var mediaAsset = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("asset"), new MediaAssetData());
            _mediaAsset = mediaAsset.Value;
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
