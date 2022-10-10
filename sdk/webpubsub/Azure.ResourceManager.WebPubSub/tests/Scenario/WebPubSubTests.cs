// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.WebPubSub.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class WebPubSubTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;

        public WebPubSubTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobleTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);
            Assert.AreEqual(webPubSubName, webPubSub.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, webPubSub.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsTrue(await _resourceGroup.GetWebPubSubs().ExistsAsync(webPubSubName));
            Assert.IsFalse(await _resourceGroup.GetWebPubSubs().ExistsAsync(webPubSubName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);
            Assert.AreEqual(webPubSubName, webPubSub.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, webPubSub.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            List<WebPubSubResource> webPubSubList = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, webPubSubList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            await webPubSub.DeleteAsync(WaitUntil.Completed);
        }
    }
}
