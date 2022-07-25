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
using Azure.Core;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class PrivateEndpointConnectionTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private WebPubSubResource _webPubSub;
        private VirtualNetworkResource _vnet;
        private string _vnetName;
        private string _privateEndPointName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public PrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _vnetName = SessionRecording.GenerateAssetName("Vnet-");
            _privateEndPointName = SessionRecording.GenerateAssetName("PrivateEndPoint-");

            //create vnet
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData() { Name = "subnet02", AddressPrefix = "10.10.2.0/24", PrivateEndpointNetworkPolicy = "Disabled", }
                },
            };
            vnetData.AddressPrefixes.Add("10.10.0.0/16");
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, _vnetName, vnetData);
            _vnet = vnetLro.Value;

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
            var privateEndpointList = await _resourceGroup.GetPrivateEndpoints().GetAllAsync().ToEnumerableAsync();
            foreach (var item in privateEndpointList)
            {
                await (await item.DeleteAsync(WaitUntil.Completed)).WaitForCompletionResponseAsync();
            }
            var list = await _resourceGroup.GetWebPubSubs().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        public async Task CreatePrivateEndpointConnection(string privateEndPointName)
        {
            //create private endpoint (privateEndpoint of WebPubSUb will be generated automatically)
            var privateEndPointData = new PrivateEndpointData()
            {
                Subnet = new SubnetData() { Id = new ResourceIdentifier($"{_vnet.Id}" + "/subnets/subnet02") },
                Location = "westus2",
                PrivateLinkServiceConnections =
                {
                    new NetworkPrivateLinkServiceConnection()
                    {
                        Name = privateEndPointName,
                        PrivateLinkServiceId = _webPubSub.Data.Id,
                        GroupIds = { "webpubsub" },
                    }
                },
            };
            var privateEndPointContainer = _resourceGroup.GetPrivateEndpoints();
            var privateEndPointLro = await (await privateEndPointContainer.CreateOrUpdateAsync(WaitUntil.Completed, privateEndPointName, privateEndPointData)).WaitForCompletionAsync();
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateDefaultWebPubSub(webPubSubName,AzureLocation.WestUS2, _resourceGroup);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            var PrivateEndpointConnection = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAsync(list[0].Data.Name);
            Assert.NotNull(PrivateEndpointConnection.Value.Data);
            Assert.AreEqual("Approved", PrivateEndpointConnection.Value.Data.ConnectionState.Status.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateDefaultWebPubSub(webPubSubName,AzureLocation.WestUS2, _resourceGroup);
            var list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.True(await _webPubSub.GetWebPubSubPrivateEndpointConnections().ExistsAsync(list[0].Data.Name));
            Assert.False(await _webPubSub.GetWebPubSubPrivateEndpointConnections().ExistsAsync(list[0].Data.Name + "01"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _webPubSub = await CreateDefaultWebPubSub(webPubSubName, AzureLocation.WestUS2, _resourceGroup);
            await CreatePrivateEndpointConnection(_privateEndPointName);
            var list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
            list = await _webPubSub.GetWebPubSubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
