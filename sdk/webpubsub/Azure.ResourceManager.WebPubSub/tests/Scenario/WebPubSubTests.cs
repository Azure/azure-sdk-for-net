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
        private ResourceGroup _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;

        public WebPubSubTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(true,SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobleTearDown()
        {
            await _resourceGroup.DeleteAsync(true);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(true);
            }
        }

        public async Task<WebPubSub> CreateWebPubSub(string webPubSubName)
        {
            // Create WebPubSub ConfigData
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>();
            categories.Add(new LiveTraceCategory("category-01", "true"));

            AclAction aclAction = new AclAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>();
            //allow.Add(new WebPubSubRequestType("ClientConnectionValue"));
            deny.Add(new WebPubSubRequestType("RESTAPI"));
            NetworkAcl publicNetwork = new NetworkAcl(allow, deny);
            IList<PrivateEndpointAcl> privateEndpoints = new List<PrivateEndpointAcl>();

            List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
            {
                new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
            };

            WebPubSubData data = new WebPubSubData(AzureLocation.WestUS2)
            {
                Sku = new WebPubSubSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                //EventHandler = new EventHandlerSettings(items),
                NetworkAcls = new WebPubSubNetworkAcls(aclAction, publicNetwork, privateEndpoints),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory),
            };

            // Create WebPubSub
            var webPubSub = await (await _resourceGroup.GetWebPubSubs().CreateOrUpdateAsync(true, webPubSubName, data)).WaitForCompletionAsync();

            return webPubSub.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateWebPubSub(webPubSubName);
            Assert.IsNotNull(webPubSub.Data);
            Assert.AreEqual(webPubSubName, webPubSub.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, webPubSub.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateWebPubSub(webPubSubName);
            Assert.IsTrue(await _resourceGroup.GetWebPubSubs().ExistsAsync(webPubSubName));
            Assert.IsFalse(await _resourceGroup.GetWebPubSubs().ExistsAsync(webPubSubName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateWebPubSub(webPubSubName);
            var webPubSub = await _resourceGroup.GetWebPubSubs().GetAsync(webPubSubName);
            Assert.IsNotNull(webPubSub.Value.Data);
            Assert.AreEqual(webPubSubName, webPubSub.Value.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, webPubSub.Value.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            await CreateWebPubSub(webPubSubName);
            List<WebPubSub> webPubSubList = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, webPubSubList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string webPubSubName = Recording.GenerateAssetName("webpubsub-");
            var webPubSub = await CreateWebPubSub(webPubSubName);
            await webPubSub.DeleteAsync(true);
        }
    }
}
