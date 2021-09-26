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
    public class SharedPrivateLinkTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private WebPubSubResource _webPubSub;
        private string _webPubSubName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public SharedPrivateLinkTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");

            // Create WebPubSub ConfigData
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>();
            categories.Add(new LiveTraceCategory("category-01", "true"));

            IDictionary<string, IList<EventHandlerTemplate>> items = new Dictionary<string, IList<EventHandlerTemplate>>();
            List<EventHandlerTemplate> eventHandlerTemplates = new List<EventHandlerTemplate>();
            //eventHandlerTemplates.Add(new EventHandlerTemplate("xn--0zwm56d.com"));
            eventHandlerTemplates.Add(new EventHandlerTemplate("http://directreach.com/domain/xn--0zwm56d.com/") { SystemEventPattern = "&quot;connect&quot;" });
            items.Add("key", eventHandlerTemplates);

            ACLAction aCLAction = new ACLAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>();
            //allow.Add(new WebPubSubRequestType("ClientConnectionValue"));
            deny.Add(new WebPubSubRequestType("RESTAPI"));
            NetworkACL publicNetwork = new NetworkACL(allow, deny);
            IList<PrivateEndpointACL> privateEndpoints = new List<PrivateEndpointACL>();

            WebPubSubResourceData data = new WebPubSubResourceData(Location.WestUS2)
            {
                Sku = new ResourceSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                EventHandler = new EventHandlerSettings(items),
                NetworkACLs = new WebPubSubNetworkACLs(aCLAction, publicNetwork, privateEndpoints),
            };

            // Create WebPubSub
            _webPubSub = await (await rg.GetWebPubSubResources().CreateOrUpdateAsync(_webPubSubName, data)).WaitForCompletionAsync();
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

        [Test]
        [RecordedTest]
        [Ignore("unable know the [PrivateLinkResourceId]")]
        public async Task CreateOrUpdate()
        {
            var container = _webPubSub.GetSharedPrivateLinkResources();
            SharedPrivateLinkResourceData data = new SharedPrivateLinkResourceData()
            {
                PrivateLinkResourceId = "",
            };
            var link = await container.CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Link-"), data);
            Assert.IsNotNull(link.Value.Data);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = _webPubSub.GetSharedPrivateLinkResources();
            var list = await container.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
