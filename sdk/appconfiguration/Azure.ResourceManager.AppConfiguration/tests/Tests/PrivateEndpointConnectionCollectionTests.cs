﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;

using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class PrivateEndpointConnectionCollectionTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }
        private ConfigurationStoreResource ConfigStore { get; set; }
        private Network.PrivateEndpointResource PrivateEndpointResource { get; set; }

        public PrivateEndpointConnectionCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
                string groupName = Recording.GenerateAssetName(ResourceGroupPrefix);
                string VnetName = Recording.GenerateAssetName("vnetname");
                string SubnetName = Recording.GenerateAssetName("subnetname");
                string EndpointName = Recording.GenerateAssetName("endpointxyz");
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;
                // Prepare VNet and Private Endpoint
                VirtualNetworkData vnetData = new VirtualNetworkData()
                {
                    Location = "eastus",
                    Subnets = { new SubnetData() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicy = "Disabled" } }
                };
                vnetData.AddressPrefixes.Add("10.0.0.0/16");
                vnetData.DhcpOptionsDnsServers.Add("10.1.1.1");
                vnetData.DhcpOptionsDnsServers.Add("10.1.2.4");
                VirtualNetworkResource vnet = (await ResGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, VnetName, vnetData)).Value;
                PrivateEndpointData privateEndpointData = new PrivateEndpointData()
                {
                    Location = "eastus",
                    PrivateLinkServiceConnections = { new NetworkPrivateLinkServiceConnection()
                        {
                            Name ="myconnection",
                            PrivateLinkServiceId = ConfigStore.Data.Id,
                            GroupIds = {"configurationStores"},
                            RequestMessage = "Please approve my connection",
                        }
                        },
                    Subnet = new SubnetData() { Id = new ResourceIdentifier("/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/" + groupName + "/providers/Microsoft.Network/virtualNetworks/" + VnetName + "/subnets/" + SubnetName) }
                };
                PrivateEndpointResource = (await ResGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, EndpointName, privateEndpointData)).Value;
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            // Only support update
            List<AppConfigurationPrivateEndpointConnectionResource> connections = await ConfigStore.GetAppConfigurationPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.FirstOrDefault().Data.Name;
            AppConfigurationPrivateEndpointConnectionData privateEndpointConnectionData = connections.FirstOrDefault().Data;
            privateEndpointConnectionData.ConnectionState.Description = "Update descriptions";
            AppConfigurationPrivateEndpointConnectionResource privateEndpointConnection = (await ConfigStore.GetAppConfigurationPrivateEndpointConnections().CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, privateEndpointConnectionData)).Value;

            Assert.IsTrue(privateEndpointConnectionName.Equals(privateEndpointConnection.Data.Name));
            Assert.IsTrue(PrivateEndpointResource.Data.Id.Equals(privateEndpointConnection.Data.PrivateEndpoint.Id));
            Assert.IsTrue(privateEndpointConnection.Data.ConnectionState.Description.Equals("Update descriptions"));
        }

        [Test]
        public async Task GetTest()
        {
            List<AppConfigurationPrivateEndpointConnectionResource> connections = await ConfigStore.GetAppConfigurationPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.First().Data.Name;
            AppConfigurationPrivateEndpointConnectionResource privateEndpointConnection = await ConfigStore.GetAppConfigurationPrivateEndpointConnections().GetAsync(privateEndpointConnectionName);

            Assert.IsTrue(privateEndpointConnectionName.Equals(privateEndpointConnection.Data.Name));
            Assert.IsTrue(privateEndpointConnection.Data.ConnectionState.Status == Models.ConnectionStatus.Approved);
        }

        [Test]
        public async Task GetAllTest()
        {
            string configurationStoreName1 = Recording.GenerateAssetName("testapp-");
            string configurationStoreName2 = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName1, configurationStoreData);
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName2, configurationStoreData);
            List<ConfigurationStoreResource> configurationStores = await ResGroup.GetConfigurationStores().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(configurationStores.Count >= 2);
            Assert.IsTrue(configurationStores.Where(x => x.Data.Name == configurationStoreName1).FirstOrDefault().Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }
    }
}
