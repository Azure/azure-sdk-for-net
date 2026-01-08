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
        private MediaServicesAccountResource _mediaService;

        private StreamingPolicyCollection streamingPolicyCollection => _mediaService.GetStreamingPolicies();

        public StreamingPolicyTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
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
            string policyName = Recording.GenerateAssetName("streamingPolicy");
            var streamingPolicy = await CreateStreamingPolicy(policyName);
            Assert.That(streamingPolicy, Is.Not.Null);
            Assert.That(streamingPolicy.Data.Name, Is.EqualTo(policyName));
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string policyName = Recording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            bool flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.That(flag, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string policyName = Recording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            var streamingPolicy = await streamingPolicyCollection.GetAsync(policyName);
            Assert.Multiple(() =>
            {
                Assert.That(policyName, Is.Not.Null);
                Assert.That(streamingPolicy.Value.Data.Name, Is.EqualTo(policyName));
            });
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string policyName = Recording.GenerateAssetName("streamingPolicy");
            await CreateStreamingPolicy(policyName);
            var list = await streamingPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Exists(item => item.Data.Name == "Predefined_ClearKey"), Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string policyName = Recording.GenerateAssetName("streamingPolicy");
            var streamingPolicy = await CreateStreamingPolicy(policyName);
            bool flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.That(flag, Is.True);

            await streamingPolicy.DeleteAsync(WaitUntil.Completed);
            flag = await streamingPolicyCollection.ExistsAsync(policyName);
            Assert.That(flag, Is.False);
        }
    }
}
