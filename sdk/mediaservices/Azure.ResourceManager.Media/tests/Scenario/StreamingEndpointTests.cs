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
    public class StreamingEndpointTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private StreamingEndpointCollection streamingEndpointCollection => _mediaService.GetStreamingEndpoints();

        public StreamingEndpointTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.WestUS2);
            var storage = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName(StorageAccountNamePrefix));
            _mediaService = await CreateMediaService(resourceGroup, Recording.GenerateAssetName("mediaservice"), storage.Id);
        }

        private async Task<StreamingEndpointResource> CreateStreamingEndpoint(string streamingEndpointName)
        {
            StreamingEndpointData data = new StreamingEndpointData(_mediaService.Data.Location);
            var streamingEndpoint = await streamingEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, streamingEndpointName, data);
            return streamingEndpoint.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Create()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var streamingEndpoint = await CreateStreamingEndpoint(streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(streamingEndpointName, streamingEndpoint.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Property 'StreamingEndpoint.Location' is read-only and cannot be changed")]
        public async Task Update()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var streamingEndpoint = await CreateStreamingEndpoint(streamingEndpointName);
            StreamingEndpointData data = new StreamingEndpointData(_mediaService.Data.Location)
            {
                Description = "changes test."
            };
            var response = await streamingEndpoint.UpdateAsync(WaitUntil.Completed, data);
            Assert.IsNotNull(response);
            Assert.AreEqual(streamingEndpointName, response.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            await CreateStreamingEndpoint(streamingEndpointName);
            bool flag = await streamingEndpointCollection.ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            await CreateStreamingEndpoint(streamingEndpointName);
            var streamingEndpoint = await streamingEndpointCollection.GetAsync(streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(streamingEndpointName, streamingEndpoint.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            await CreateStreamingEndpoint(streamingEndpointName);
            var list = await streamingEndpointCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == "default"));
            Assert.IsTrue(list.Exists(item => item.Data.Name == streamingEndpointName));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var streamingEndpoint = await CreateStreamingEndpoint(streamingEndpointName);
            bool flag = await streamingEndpointCollection.ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);

            await streamingEndpoint.DeleteAsync(WaitUntil.Completed);
            flag = await streamingEndpointCollection.ExistsAsync(streamingEndpointName);
            Assert.IsFalse(flag);
        }
    }
}
