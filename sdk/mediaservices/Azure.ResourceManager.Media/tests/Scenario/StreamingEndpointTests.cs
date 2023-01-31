// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Microsoft.Identity.Client.Extensions.Msal;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class StreamingEndpointTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        public StreamingEndpointTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatests");
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        private async Task<StreamingEndpointResource> CreateStreamingEndpoint(string streamingEndpointName)
        {
            StreamingEndpointData data = new StreamingEndpointData(AzureLocation.WestUS2);
            var streamingEndpoint = await _mediaService.GetStreamingEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, streamingEndpointName, data);
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
            StreamingEndpointData data = new StreamingEndpointData(ResourceGroup.Data.Location)
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
            bool flag = await _mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            await CreateStreamingEndpoint(streamingEndpointName);
            var streamingEndpoint = await _mediaService.GetStreamingEndpoints().GetAsync(streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(streamingEndpointName, streamingEndpoint.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            await CreateStreamingEndpoint(streamingEndpointName);
            var list = await _mediaService.GetStreamingEndpoints().GetAllAsync().ToEnumerableAsync();
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
            bool flag = await _mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);

            await streamingEndpoint.DeleteAsync(WaitUntil.Completed);
            flag = await _mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsFalse(flag);
        }
    }
}
