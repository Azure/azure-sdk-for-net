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
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServiceResource _mediaService;
        private string _streamingEndpointName;  //The maximun allowed number of streaming endpoints is 2

        private StreamingEndpointCollection streamingEndpointCollection => _mediaService.GetStreamingEndpoints();

        public StreamingEndpointTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            _mediaServiceIdentifier = mediaService.Id;
            _streamingEndpointName = SessionRecording.GenerateAssetName("streamingEndpoint");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServiceResource(_mediaServiceIdentifier).GetAsync();
        }

        private async Task<StreamingEndpointResource> CreateStreamingEndpoint()
        {
            // streamingEndpointCollection.CreateOrUpdateAsync does not support update.
            bool isExist = await streamingEndpointCollection.ExistsAsync(_streamingEndpointName);
            if (!isExist)
            {
                StreamingEndpointData data = new StreamingEndpointData(_mediaService.Data.Location);
                var streamingEndpoint = await streamingEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, _streamingEndpointName, data);
                return streamingEndpoint.Value;
            }
            return await streamingEndpointCollection.GetAsync(_streamingEndpointName);
        }

        [Test]
        [RecordedTest]
        public async Task Create()
        {
            var streamingEndpoint = await CreateStreamingEndpoint();
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(_streamingEndpointName, streamingEndpoint.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Property 'StreamingEndpoint.Location' is read-only and cannot be changed")]
        public async Task Update()
        {
            var streamingEndpoint = await CreateStreamingEndpoint();
            StreamingEndpointData data = new StreamingEndpointData(_mediaService.Data.Location)
            {
                Description = "changes test."
            };
            data.Location = null; // System.ArgumentNullException : Value cannot be null. (Parameter 'location')
            var response = await streamingEndpoint.UpdateAsync(WaitUntil.Completed, data);
            Assert.IsNotNull(response);
            Assert.AreEqual(_streamingEndpointName, response.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            await CreateStreamingEndpoint();
            bool flag = await streamingEndpointCollection.ExistsAsync(_streamingEndpointName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateStreamingEndpoint();
            var streamingEndpoint = await streamingEndpointCollection.GetAsync(_streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(_streamingEndpointName, streamingEndpoint.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateStreamingEndpoint();
            var list = await streamingEndpointCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == "default"));
            Assert.IsTrue(list.Exists(item => item.Data.Name == _streamingEndpointName));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var streamingEndpoint = await CreateStreamingEndpoint();
            bool flag = await streamingEndpointCollection.ExistsAsync(_streamingEndpointName);
            Assert.IsTrue(flag);

            await streamingEndpoint.DeleteAsync(WaitUntil.Completed);
            flag = await streamingEndpointCollection.ExistsAsync(_streamingEndpointName);
            Assert.IsFalse(flag);
        }
    }
}
