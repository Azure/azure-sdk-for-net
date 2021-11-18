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
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class SharedPrivateLinkTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private WebPubSubResource _webPubSub;
        private string _webPubSubName;
        private string _linkName;
        private string _vnetName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public SharedPrivateLinkTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _linkName = SessionRecording.GenerateAssetName("link-");
            _vnetName = SessionRecording.GenerateAssetName("vnet-");

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

        public async Task<SharedPrivateLinkResource> CreateSharedPrivateLink(string LinkName)
        {
            //1. create vnet
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.10.0.0/16", }
                },
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData() { Name = "subnet02", AddressPrefix = "10.10.2.0/24", PrivateEndpointNetworkPolicies = "Disabled", }
                },
            };
            var vnetContainer = _resourceGroup.GetVirtualNetworks();
            var vnet = await vnetContainer.CreateOrUpdateAsync(_vnetName, vnetData);

            //2.1 Create AppServicePlan
            //string appServicePlanName = "appServicePlan5952";
            //string location = "westus2";
            //string appServicePlanId = $"{_resourceGroupIdentifier}/providers/Microsoft.Web/serverfarms/{appServicePlanName}";
            //var armClient = GetArmClient();
            //await armClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(appServicePlanId, new GenericResourceData(location)
            //{
            //    Properties = new Dictionary<string, object>
            //    {
            //        { "resources", new Dictionary<string, object>
            //            {
            //                { "type", "Microsoft.Web/serverfarms" },
            //                { "apiVersion", "2021-01-15" },
            //                { "name", appServicePlanName },
            //                { "location", location },
            //                { "kind", "app" },
            //                { "sku", new Dictionary<string,object>
            //                    {
            //                        { "name", "P1v2" },
            //                        { "tier", "PremiumV2" },
            //                        { "size", "P1v2" },
            //                        { "family", "P1v2" },
            //                        { "capacity", 1 },
            //                    }
            //                },
            //                { "properties", new Dictionary<string,object>
            //                    {
            //                        { "perSiteScaling", false },
            //                        { "elasticScaleEnabled", false },
            //                        { "maximumElasticWorkerCount", 1 },
            //                        { "isSpot", false },
            //                        { "reserved", false },
            //                        { "isXenon", false },
            //                        { "hyperV", false },
            //                        { "targetWorkerCount", 0 },
            //                        { "targetWorkerSizeId", 0 },
            //                    }
            //                },
            //            }
            //        }
            //    }
            //});

            //TODO: 2.2 Create Appservice(Microsoft.Web/sites)
            string WebAppName = SessionRecording.GenerateAssetName("site-");

            //3 create SharedPrivateLink
            //TODO: Creating a SharedPrivateLink inevitably requires manual approval on the portal.
            var container = _webPubSub.GetSharedPrivateLinkResources();
            SharedPrivateLinkResourceData data = new SharedPrivateLinkResourceData()
            {
                PrivateLinkResourceId = $"{_resourceGroupIdentifier}/providers/Microsoft.Web/sites/{WebAppName}/sharedPrivateLinkResources/{LinkName}",
                GroupId = "webPubSub",
                RequestMessage = "please approve",
            };
            var link = await container.CreateOrUpdateAsync(LinkName, data);
            return link.Value;
        }

        [Test]
        [RecordedTest]
        [Ignore("Creating a SharedPrivateLink inevitably requires manual approval on the portal")]
        public async Task CreateOrUpdate()
        {
            var sharedPrivateLink = await CreateSharedPrivateLink(_linkName);
            Assert.IsNotNull(sharedPrivateLink);
            Assert.AreEqual("Approved", sharedPrivateLink.Data.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            _webPubSub = await CreateWebPubSub();
            var list = await _webPubSub.GetSharedPrivateLinkResources().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
