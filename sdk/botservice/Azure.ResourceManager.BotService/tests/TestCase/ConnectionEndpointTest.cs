// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BotService.Models;
using Azure.ResourceManager.BotService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.BotService.Tests
{
    internal class ConnectionEndpointTest : BotServiceManagementTestBase
    {
        public ConnectionEndpointTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ProviderApiTest()
        {
            //1.Create
            var botName = Recording.GenerateAssetName("testbotService");
            var pointName = Recording.GenerateAssetName("testEndpoint-");
            var connectionName = Recording.GenerateAssetName("testconnection");
            var connectionName2 = Recording.GenerateAssetName("testconnection");
            var connectionName3 = Recording.GenerateAssetName("testconnection");
            var msaAppId = Recording.Random.NewGuid().ToString();
            var resourceGroup = await CreateResourceGroupAsync();
            var botCollection = resourceGroup.GetBots();
            var botInput = ResourceDataHelpers.GetBotData(msaAppId);
            var botResource = (await botCollection.CreateOrUpdateAsync(WaitUntil.Completed, botName, botInput)).Value;
            var collection = botResource.GetBotServicePrivateEndpointConnections();
            var endpoint = await GetEndpointResource(resourceGroup, botResource.Data.Id);
            //2.Get
            var connections = await collection.GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.FirstOrDefault().Data.Name;
            var privateEndpointConnectionData = connections.FirstOrDefault().Data;
            Assert.NotNull(privateEndpointConnectionData);
            Assert.AreEqual("Approved", privateEndpointConnectionData.ConnectionState.Status.ToString());
            //3.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            //4.Exist
            //Assert.IsTrue(await collection.ExistsAsync(privateEndpointConnectionName));
            Assert.IsFalse(await collection.ExistsAsync(privateEndpointConnectionName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //Delete
            Assert.AreEqual(1, list.Count);
            /*foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);*/
            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<PrivateEndpointResource> GetEndpointResource(ResourceGroupResource resourceGroup, ResourceIdentifier providerId)
        {
            string VnetName = Recording.GenerateAssetName("vnetname");
            string SubnetName = Recording.GenerateAssetName("subnetname");
            string EndpointName = Recording.GenerateAssetName("endpointxyz");
            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = "eastus",
                Subnets = { new SubnetData() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicy = "Disabled" } }
            };
            vnetData.AddressPrefixes.Add("10.0.0.0/16");
            vnetData.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnetData.DhcpOptionsDnsServers.Add("10.1.2.4");
            ResourceIdentifier subnetID = await GetSubnetID(resourceGroup, VnetName, SubnetName, vnetData);
            PrivateEndpointData privateEndpointData = new PrivateEndpointData()
            {
                Location = "eastus",
                PrivateLinkServiceConnections = { new NetworkPrivateLinkServiceConnection()
                        {
                            Name ="myconnection",
                            PrivateLinkServiceId = providerId,
                            GroupIds = {"Bot"},
                            RequestMessage = "Please approve my connection",
                        }
                        },
                Subnet = new SubnetData() { Id = subnetID }
            };
            PrivateEndpointResource resource = (await resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, EndpointName, privateEndpointData)).Value;
            return resource;
        }
        protected async Task<ResourceIdentifier> GetSubnetID(ResourceGroupResource ResGroup, string VnetName, string SubnetName, VirtualNetworkData VnetData)
        {
            ResourceIdentifier subnetID;
            var vnetResource = await ResGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, VnetName, VnetData);
            var subnetCollection = vnetResource.Value.GetSubnets();
            subnetID = vnetResource.Value.Data.Subnets[0].Id;
            return subnetID;
        }
    }
}
