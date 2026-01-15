// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxDeploymentApiKeyCollectionTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxDeploymentApiKeyCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxDeploymentApiKeyCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await CreateResourceGroup(Subscription, ResourceGroupPrefix, Location);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);

            Assert.That(nginxDeploymentApiKeyName.Equals(nginxDeploymentApiKey.Data.Name), Is.True);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();
            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey1 = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            NginxDeploymentApiKeyResource nginxDeploymentApiKey2 = await collection.GetAsync(nginxDeploymentApiKeyName);

            ResourceDataHelper.AssertResourceData(nginxDeploymentApiKey1.Data, nginxDeploymentApiKey2.Data);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(nginxDeploymentApiKeyName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();
            List<NginxDeploymentApiKeyResource> nginxDeploymentApiKeys = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(nginxDeploymentApiKeys.Count, Is.EqualTo(0));

            string nginxDeploymentApiKeyName1 = Recording.GenerateAssetName("testDeploymentApiKey-");
            string nginxDeploymentApiKeyName2 = Recording.GenerateAssetName("testDeploymentApiKey-");
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName1);
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName2);

            nginxDeploymentApiKeys = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(nginxDeploymentApiKeys.Count, Is.EqualTo(2));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();
            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);

            Assert.That((bool)await collection.ExistsAsync(nginxDeploymentApiKeyName), Is.True);
            Assert.That((bool)await collection.ExistsAsync(nginxDeploymentApiKeyName + "1"), Is.False);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetIfExists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();
            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey1 = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            NullableResponse<NginxDeploymentApiKeyResource> nginxDeploymentApiKeyResponse = await collection.GetIfExistsAsync(nginxDeploymentApiKeyName);

            Assert.That(nginxDeploymentApiKeyResponse.HasValue, Is.True);
            NginxDeploymentApiKeyResource nginxDeploymentApiKey2 = nginxDeploymentApiKeyResponse.Value;
            ResourceDataHelper.AssertResourceData(nginxDeploymentApiKey1.Data, nginxDeploymentApiKey2.Data);

            NullableResponse<NginxDeploymentApiKeyResource> nginxDeploymentApiKeyResponse2 = await collection.GetIfExistsAsync(nginxDeploymentApiKeyName + "1");
            Assert.That(nginxDeploymentApiKeyResponse2.HasValue, Is.False);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetIfExistsAsync(null));
        }
    }
}
