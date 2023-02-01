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

        public MediaAssetTrackTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatests");
            var mediaAssetName = Recording.GenerateAssetName("asset");
            var mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
            _mediaAsset = await CreateMediaAsset(mediaService, mediaAssetName);
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
