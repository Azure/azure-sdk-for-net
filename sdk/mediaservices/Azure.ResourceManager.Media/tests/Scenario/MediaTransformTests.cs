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
    public class MediaTransformTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private MediaTransformCollection mediaTransformCollection => _mediaService.GetMediaTransforms();

        public MediaTransformTests(bool isAsync)
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
        public async Task CreateOrUpdate()
        {
            string mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(_mediaService, mediaTransformName);
            Assert.IsNotNull(mediaTransfer);
            Assert.AreEqual(mediaTransformName, mediaTransfer.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            await CreateMediaTransfer(_mediaService, mediaTransformName);
            bool flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            await CreateMediaTransfer(_mediaService, mediaTransformName);
            var mediaTransfer = await mediaTransformCollection.GetAsync(mediaTransformName);
            Assert.IsNotNull(mediaTransfer);
            Assert.AreEqual(mediaTransformName, mediaTransfer.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(_mediaService, mediaTransformName);
            var list = await mediaTransformCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            var mediaTransfer = await CreateMediaTransfer(_mediaService, mediaTransformName);
            bool flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsTrue(flag);

            await mediaTransfer.DeleteAsync(WaitUntil.Completed);
            flag = await mediaTransformCollection.ExistsAsync(mediaTransformName);
            Assert.IsFalse(flag);
        }
    }
}
