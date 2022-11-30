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
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        public StreamingEndpointTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                _storageAccountIdentifier = StorageAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, storageAccountName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _storageAccountIdentifier = storage.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<StreamingEndpointResource> CreateStreamingEndpoint(MediaServicesAccountResource mediaService, string streamingEndpointName)
        {
            StreamingEndpointData data = new StreamingEndpointData(_resourceGroup.Data.Location);
            var streamingEndpoint = await mediaService.GetStreamingEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, streamingEndpointName, data);
            return streamingEndpoint.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Create()
        {
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            var streamingEndpoint = await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(streamingEndpointName, streamingEndpoint.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Property 'StreamingEndpoint.Location' is read-only and cannot be changed")]
        public async Task Update()
        {
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            var streamingEndpoint = await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            StreamingEndpointData data = new StreamingEndpointData(_resourceGroup.Data.Location)
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
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            bool flag = await mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            var streamingEndpoint = await mediaService.GetStreamingEndpoints().GetAsync(streamingEndpointName);
            Assert.IsNotNull(streamingEndpoint);
            Assert.AreEqual(streamingEndpointName, streamingEndpoint.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            var list = await mediaService.GetStreamingEndpoints().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == "default"));
            Assert.IsTrue(list.Exists(item => item.Data.Name == streamingEndpointName));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatest");
            string streamingEndpointName = Recording.GenerateAssetName("streamingEndpoint");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            var streamingEndpoint = await CreateStreamingEndpoint(mediaService, streamingEndpointName);
            bool flag = await mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsTrue(flag);

            await streamingEndpoint.DeleteAsync(WaitUntil.Completed);
            flag = await mediaService.GetStreamingEndpoints().ExistsAsync(streamingEndpointName);
            Assert.IsFalse(flag);
        }
    }
}
