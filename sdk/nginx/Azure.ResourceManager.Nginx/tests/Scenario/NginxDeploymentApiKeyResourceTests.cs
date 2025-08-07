// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxDeploymentApiKeyResourceTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxDeploymentApiKeyResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxDeploymentApiKeyResourceTests(bool isAsync) : base(isAsync)
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
        public void CreateResourceIdentifier()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            ResourceIdentifier nginxDeploymentApiKeyResourceIdentifier = NginxDeploymentApiKeyResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, nginxDeploymentApiKeyName);
            NginxDeploymentApiKeyResource.ValidateResourceId(nginxDeploymentApiKeyResourceIdentifier);

            Assert.IsTrue(nginxDeploymentApiKeyResourceIdentifier.ResourceType.Equals(NginxDeploymentApiKeyResource.ResourceType));
            Assert.Throws<ArgumentException>(() => NginxDeploymentApiKeyResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            ResourceIdentifier nginxDeploymentApiKeyResourceIdentifier = NginxDeploymentApiKeyResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, nginxDeploymentApiKeyName);

            Assert.IsTrue(nginxDeploymentApiKey.HasData);
            Assert.NotNull(nginxDeploymentApiKey.Data);
            Assert.IsTrue(nginxDeploymentApiKey.Data.Name.Equals(nginxDeploymentApiKeyName, StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(nginxDeploymentApiKey.Data.Id.Equals(nginxDeploymentApiKeyResourceIdentifier));
            Assert.IsTrue(nginxDeploymentApiKey.Data.Id.ResourceType.Equals(NginxDeploymentApiKeyResource.ResourceType));
            Assert.Null(nginxDeploymentApiKey.Data.SystemData);
            Assert.NotNull(nginxDeploymentApiKey.Data.Properties.Hint);
            Assert.NotNull(nginxDeploymentApiKey.Data.Properties.EndOn);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            NginxDeploymentApiKeyResource response = await nginxDeploymentApiKey.GetAsync();

            Assert.NotNull(response);
            Assert.IsTrue(response.Data.Name.Equals(nginxDeploymentApiKeyName, StringComparison.InvariantCultureIgnoreCase));
            ResourceDataHelper.AssertResourceData(nginxDeploymentApiKey.Data, response.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            Assert.IsTrue(await collection.ExistsAsync(nginxDeploymentApiKeyName));

            await nginxDeploymentApiKey.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await collection.ExistsAsync(nginxDeploymentApiKeyName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testDeploymentApiKey-");
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);

            NginxDeploymentApiKeyRequestProperties apiKeyProperties = new NginxDeploymentApiKeyRequestProperties
            {
                SecretText = "U9d@t36" + NginxDeploymentApiKeySecretText,
            };
            NginxDeploymentApiKeyCreateOrUpdateContent nginxDeploymentApiKeyCreateOrUpdateContent = new NginxDeploymentApiKeyCreateOrUpdateContent
            {
                Properties = apiKeyProperties
            };
            NginxDeploymentApiKeyResource updatedNginxDeploymentApiKey = (await nginxDeploymentApiKey.UpdateAsync(WaitUntil.Completed, nginxDeploymentApiKeyCreateOrUpdateContent)).Value;
            Assert.AreEqual(apiKeyProperties.SecretText.Substring(0, 3), updatedNginxDeploymentApiKey.Data.Properties.Hint);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeploymentApiKey.UpdateAsync(WaitUntil.Completed, null)).Value);
        }
    }
}
