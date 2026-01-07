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

            Assert.That(nginxDeploymentApiKeyResourceIdentifier.ResourceType, Is.EqualTo(NginxDeploymentApiKeyResource.ResourceType));
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

            Assert.That(nginxDeploymentApiKey.HasData, Is.True);
            Assert.That(nginxDeploymentApiKey.Data, Is.Not.Null);
            Assert.That(nginxDeploymentApiKey.Data.Name.Equals(nginxDeploymentApiKeyName, StringComparison.InvariantCultureIgnoreCase), Is.True);
            Assert.That(nginxDeploymentApiKey.Data.Id, Is.EqualTo(nginxDeploymentApiKeyResourceIdentifier));
            Assert.That(nginxDeploymentApiKey.Data.Id.ResourceType, Is.EqualTo(NginxDeploymentApiKeyResource.ResourceType));
            Assert.That(nginxDeploymentApiKey.Data.SystemData, Is.Null);
            Assert.That(nginxDeploymentApiKey.Data.Properties.Hint, Is.Not.Null);
            Assert.That(nginxDeploymentApiKey.Data.Properties.EndOn, Is.Not.Null);
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

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data.Name.Equals(nginxDeploymentApiKeyName, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
            Assert.That((bool)await collection.ExistsAsync(nginxDeploymentApiKeyName), Is.True);

            await nginxDeploymentApiKey.DeleteAsync(WaitUntil.Completed);
            Assert.That((bool)await collection.ExistsAsync(nginxDeploymentApiKeyName), Is.False);
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
            Assert.That(updatedNginxDeploymentApiKey.Data.Properties.Hint, Is.EqualTo(apiKeyProperties.SecretText.Substring(0, 3)));
        }
    }
}
