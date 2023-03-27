// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaPrivateLinkTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private MediaServicesPrivateLinkResourceCollection mediaPrivateLinkResourceCollection => _mediaService.GetMediaServicesPrivateLinkResources();

        public MediaPrivateLinkTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatests");
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await mediaPrivateLinkResourceCollection.ExistsAsync("keydelivery");
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var mediaPrivateLinkResource = await mediaPrivateLinkResourceCollection.GetAsync("keydelivery");
            Assert.IsNotNull(mediaPrivateLinkResource);
            Assert.AreEqual("keydelivery", mediaPrivateLinkResource.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await mediaPrivateLinkResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(3, list.Count);
        }
    }
}
