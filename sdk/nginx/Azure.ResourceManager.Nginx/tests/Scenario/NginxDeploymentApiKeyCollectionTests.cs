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

            Assert.IsTrue(nginxDeploymentApiKeyName.Equals(nginxDeploymentApiKey.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxDeploymentApiKeys().CreateOrUpdateAsync(WaitUntil.Completed, nginxDeploymentApiKeyName, null)).Value);

            NginxDeploymentApiKeyRequestProperties apiKeyProperties = new NginxDeploymentApiKeyRequestProperties
            {
                SecretText = NginxDeploymentApiKeySecretText
            };

            NginxDeploymentApiKeyCreateOrUpdateContent nginxDeploymentApiKeyCreateOrUpdateContent = new NginxDeploymentApiKeyCreateOrUpdateContent
            {
                Properties = apiKeyProperties
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxDeploymentApiKeys().CreateOrUpdateAsync(WaitUntil.Completed, null, nginxDeploymentApiKeyCreateOrUpdateContent)).Value);
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
            Assert.AreEqual(0, nginxDeploymentApiKeys.Count);

            string nginxDeploymentApiKeyName1 = Recording.GenerateAssetName("testDeploymentApiKey-");
            string nginxDeploymentApiKeyName2 = Recording.GenerateAssetName("testDeploymentApiKey-");
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName1);
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName2);

            nginxDeploymentApiKeys = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, nginxDeploymentApiKeys.Count);
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

            Assert.IsTrue(await collection.ExistsAsync(nginxDeploymentApiKeyName));
            Assert.IsFalse(await collection.ExistsAsync(nginxDeploymentApiKeyName + "1"));
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

            Assert.True(nginxDeploymentApiKeyResponse.HasValue);
            NginxDeploymentApiKeyResource nginxDeploymentApiKey2 = nginxDeploymentApiKeyResponse.Value;
            ResourceDataHelper.AssertResourceData(nginxDeploymentApiKey1.Data, nginxDeploymentApiKey2.Data);

            NullableResponse<NginxDeploymentApiKeyResource> nginxDeploymentApiKeyResponse2 = await collection.GetIfExistsAsync(nginxDeploymentApiKeyName + "1");
            Assert.False(nginxDeploymentApiKeyResponse2.HasValue);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetIfExistsAsync(null));
        }
    }
}
