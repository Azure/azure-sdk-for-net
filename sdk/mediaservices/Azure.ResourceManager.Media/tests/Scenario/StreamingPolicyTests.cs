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
    public class StreamingPolicyTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private StreamingPolicyCollection streamingPolicyCollection => _mediaService.GetStreamingPolicies();

        public StreamingPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            _mediaServiceIdentifier = mediaService.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
        }

        private async Task<StreamingPolicyResource> CreateStreamingPolicy(string policyName)
        {
            StreamingPolicyData data = new StreamingPolicyData()
            {
                EnvelopeEncryption = new EnvelopeEncryption()
                {
                    EnabledProtocols = new MediaEnabledProtocols(false, true, true, true)
                },
            };
            var policy = await streamingPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyName, data);
            return policy.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string policyName = SessionRecording.GenerateAssetName("streamingPolicy");
            var streamingPolicy = await CreateStreamingPolicy(policyName);
            Assert.IsNotNull(streamingPolicy);
            Assert.AreEqual(policyName, streamingPolicy.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string policyName = SessionRecording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            bool flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string policyName = SessionRecording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            var streamingPolicy = await streamingPolicyCollection.GetAsync(policyName);
            Assert.IsNotNull(policyName);
            Assert.AreEqual(policyName, streamingPolicy.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string policyName = SessionRecording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            var list = await streamingPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == "Predefined_ClearKey"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string policyName = SessionRecording.GenerateAssetName("streamingPolicy");
            var streamingPolicy = await CreateStreamingPolicy(policyName);
            bool flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.IsTrue(flag);

            await streamingPolicy.DeleteAsync(WaitUntil.Completed);
            flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.IsFalse(flag);
        }
    }
}
