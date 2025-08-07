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
    public class WebPubSubHubTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;

        public WebPubSubHubTests(bool isAsync) : base(isAsync)
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

        private async Task<WebPubSubHubResource> CreateDefaultWebPubSubHub(WebPubSubHubCollection collection, string name)
        {
            IList<Models.WebPubSubEventHandler> eventHandlers = new List<Models.WebPubSubEventHandler>()
            {
                new Models.WebPubSubEventHandler("http://example.com/api/{hub}/{event}")
                {
                    SystemEvents ={"none"},
                    Auth = new UpstreamAuthSettings(),
                },
            };
            var webPubSubHubProperties = new WebPubSubHubProperties(eventHandlers, "Deny", null);
            WebPubSubHubData data = new WebPubSubHubData(webPubSubHubProperties)
            {
            };
            var hub = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            return hub.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);

            var collection = webPubSub.GetWebPubSubHubs();
            string webPubSubHubName = Recording.GenerateAssetName("webpubsubhub");
            var hub = await CreateDefaultWebPubSubHub(collection, webPubSubHubName);
            Assert.IsNotNull(hub.Data);
            Assert.AreEqual(webPubSubHubName, hub.Data.Name);
            Assert.AreEqual("Deny", hub.Data.Properties.AnonymousConnectPolicy);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);

            var collection = webPubSub.GetWebPubSubHubs();
            string webPubSubHubName = Recording.GenerateAssetName("webpubsubhub");
            var hub = await CreateDefaultWebPubSubHub(collection, webPubSubHubName);
            Assert.IsTrue(await collection.ExistsAsync(webPubSubHubName));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);

            var collection = webPubSub.GetWebPubSubHubs();
            string webPubSubHubName = Recording.GenerateAssetName("webpubsubhub");
            await CreateDefaultWebPubSubHub(collection, webPubSubHubName);
            var hub = await collection.GetAsync(webPubSubHubName);
            Assert.IsNotNull(hub.Value.Data);
            Assert.AreEqual(webPubSubHubName, hub.Value.Data.Name);
            Assert.AreEqual("Deny", hub.Value.Data.Properties.AnonymousConnectPolicy);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);

            var collection = webPubSub.GetWebPubSubHubs();
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
            string webPubSubHubName = Recording.GenerateAssetName("webpubsubhub");
            await CreateDefaultWebPubSubHub(collection, webPubSubHubName);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(webPubSub.Data);

            var collection = webPubSub.GetWebPubSubHubs();
            string webPubSubHubName = Recording.GenerateAssetName("webpubsubhub");
            await CreateDefaultWebPubSubHub(collection, webPubSubHubName);

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            var deleteWebPubSubHub = await collection.GetAsync(webPubSubHubName);
            await deleteWebPubSubHub.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
