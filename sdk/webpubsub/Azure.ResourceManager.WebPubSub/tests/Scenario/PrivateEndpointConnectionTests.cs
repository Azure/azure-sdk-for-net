// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.WebPubSub.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class PrivateEndpointConnectionTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private WebPubSub _webPubSub;
        private VirtualNetwork _vnet;
        private string _vnetName;
        private string _privateEndPointName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public PrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _vnetName = SessionRecording.GenerateAssetName("Vnet-");
            _privateEndPointName = SessionRecording.GenerateAssetName("PrivateEndPoint-");

            //create vnet
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
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(_vnetName, vnetData);
            _vnet = vnetLro.Value;

            await StopSessionRecordingAsync();
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
            var privateEndpointList = await _resourceGroup.GetPrivateEndpoints().GetAllAsync().ToEnumerableAsync();
            foreach (var item in privateEndpointList)
            {
                await (await item.DeleteAsync()).WaitForCompletionResponseAsync();
            }
            var list = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync();
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

            WebPubSubData data = new WebPubSubData(Location.WestUS2)
            {
                Sku = new WebPubSubSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                //EventHandler = new EventHandlerSettings(items),
                NetworkAcls = new WebPubSubNetworkAcls(aclAction, publicNetwork, privateEndpoints),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory),
            };

            // Create WebPubSub
            var webPubSub = await (await _resourceGroup.GetWebPubSubs().CreateOrUpdateAsync(webPubSubName, data)).WaitForCompletionAsync();

            return webPubSub.Value;
        }

        public async Task CreatePrivateEndpointConnection(string privateEndPointName)
        {
            //create private endpoint (privateEndpoint of WebPubSUb will be generated automatically)
            var privateEndPointData = new PrivateEndpointData()
            {
                Subnet = new SubnetData() { Id = $"{_vnet.Id}" + "/subnets/subnet02" },
                Location = "westus2",
                PrivateLinkServiceConnections =
                {
                    new PrivateLinkServiceConnection()
                    {
                        Name = privateEndPointName,
                        PrivateLinkServiceId = _webPubSub.Data.Id.ToString(),
                        GroupIds = { "webpubsub" },
                    }
                },
            };
            var privateEndPointContainer = _resourceGroup.GetPrivateEndpoints();
            var privateEndPointLro = await (await privateEndPointContainer.CreateOrUpdateAsync(privateEndPointName, privateEndPointData)).WaitForCompletionAsync();
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateWebPubSub(webPubSubName);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            var PrivateEndpointConnection = await _webPubSub.GetPrivateEndpointConnections().GetAsync(list[0].Data.Name);
            Assert.NotNull(PrivateEndpointConnection.Value.Data);
            Assert.AreEqual("Approved", PrivateEndpointConnection.Value.Data.PrivateLinkServiceConnectionState.Status.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateWebPubSub(webPubSubName);
            var list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateWebPubSub(webPubSubName);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.True(_webPubSub.GetPrivateEndpointConnections().CheckIfExists(list[0].Data.Name));
            Assert.False(_webPubSub.GetPrivateEndpointConnections().CheckIfExists(list[0].Data.Name + "01"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateWebPubSub(webPubSubName);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            foreach (var item in list)
            {
                await item.DeleteAsync();
            }
            list = await _webPubSub.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
