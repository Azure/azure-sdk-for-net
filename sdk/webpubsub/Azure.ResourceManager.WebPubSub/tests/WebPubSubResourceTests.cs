// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class WebPubSubResourceTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private string _webPubSubName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public WebPubSubResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            StopSessionRecording();
        }

        [OneTimeTearDown]
        public async Task GlobleTearDown()
        {
            await _resourceGroup.DeleteAsync();
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
            if (_resourceGroup.GetWebPubSubResources().CheckIfExists(_webPubSubName))
            {
                var webPubSub = await _resourceGroup.GetWebPubSubResources().GetAsync(_webPubSubName);
                await webPubSub.Value.DeleteAsync();
            }
        }

        public async Task<WebPubSubResource> CreateWebPubSub()
        {
            // Create WebPubSub ConfigData
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>();
            categories.Add(new LiveTraceCategory("category-01", "true"));

            ACLAction aCLAction = new ACLAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>();
            //allow.Add(new WebPubSubRequestType("ClientConnectionValue"));
            deny.Add(new WebPubSubRequestType("RESTAPI"));
            NetworkACL publicNetwork = new NetworkACL(allow, deny);
            IList<PrivateEndpointACL> privateEndpoints = new List<PrivateEndpointACL>();

            List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
            {
                new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
            };

            WebPubSubResourceData data = new WebPubSubResourceData(Location.WestUS2)
            {
                Sku = new ResourceSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                //EventHandler = new EventHandlerSettings(items),
                NetworkACLs = new WebPubSubNetworkACLs(aCLAction, publicNetwork, privateEndpoints),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory),
            };

            // Create WebPubSub
            var webPubSub = await (await _resourceGroup.GetWebPubSubResources().CreateOrUpdateAsync(_webPubSubName, data)).WaitForCompletionAsync();

            return webPubSub.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var webPubSub = await CreateWebPubSub();
            Assert.IsNotNull(webPubSub.Data);
            Assert.AreEqual(_webPubSubName, webPubSub.Data.Name);
            Assert.AreEqual(Location.WestUS2, webPubSub.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            await CreateWebPubSub();
            Assert.IsTrue(_resourceGroup.GetWebPubSubResources().CheckIfExists(_webPubSubName));
            Assert.IsFalse(_resourceGroup.GetWebPubSubResources().CheckIfExists(_webPubSubName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateWebPubSub();
            var webPubSub = await _resourceGroup.GetWebPubSubResources().GetAsync(_webPubSubName);
            Assert.IsNotNull(webPubSub.Value.Data);
            Assert.AreEqual(_webPubSubName, webPubSub.Value.Data.Name);
            Assert.AreEqual(Location.WestUS2, webPubSub.Value.Data.Location);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateWebPubSub();
            List<WebPubSubResource> webPubSubList = await _resourceGroup.GetWebPubSubResources().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, webPubSubList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var webPubSub = await CreateWebPubSub();
            await webPubSub.DeleteAsync();
        }
    }
}
