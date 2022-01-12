// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private ResourceGroup ResGroup { get; set; }
        private ConfigurationStore ConfigStore { get; set; }
        private Network.PrivateEndpoint PrivateEndpoint { get; set; }

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
                ResGroup = await (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(groupName, new ResourceGroupData(Location))).WaitForCompletionAsync();
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();
                // Prepare VNet and Private Endpoint
                VirtualNetworkData vnetData = new VirtualNetworkData()
                {
                    Location = "eastus",
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = { "10.0.0.0/16", }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = { "10.1.1.1", "10.1.2.4" }
                    },
                    Subnets = { new SubnetData() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicies = "Disabled" } }
                };
                VirtualNetwork vnet = await (await ResGroup.GetVirtualNetworks().CreateOrUpdateAsync(VnetName, vnetData)).WaitForCompletionAsync();
                PrivateEndpointData privateEndpointData = new PrivateEndpointData()
                {
                    Location = "eastus",
                    PrivateLinkServiceConnections = { new PrivateLinkServiceConnection()
                        {
                            Name ="myconnection",
                            PrivateLinkServiceId = ConfigStore.Data.Id,
                            GroupIds = {"configurationStores"},
                            RequestMessage = "Please approve my connection",
                        }
                        },
                    Subnet = new SubnetData() { Id = "/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/" + groupName + "/providers/Microsoft.Network/virtualNetworks/" + VnetName + "/subnets/" + SubnetName }
                };
                PrivateEndpoint = await (await ResGroup.GetPrivateEndpoints().CreateOrUpdateAsync(EndpointName, privateEndpointData)).WaitForCompletionAsync();
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            // Only support update
            List<PrivateEndpointConnection> connections = await ConfigStore.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.FirstOrDefault().Data.Name;
            PrivateEndpointConnectionData privateEndpointConnectionData = connections.FirstOrDefault().Data;
            privateEndpointConnectionData.PrivateLinkServiceConnectionState.Description = "Update descriptions";
            PrivateEndpointConnection privateEndpointConnection = await (await ConfigStore.GetPrivateEndpointConnections().CreateOrUpdateAsync(privateEndpointConnectionName, privateEndpointConnectionData)).WaitForCompletionAsync();

            Assert.IsTrue(privateEndpointConnectionName.Equals(privateEndpointConnection.Data.Name));
            Assert.IsTrue(PrivateEndpoint.Data.Id.Equals(privateEndpointConnection.Data.PrivateEndpoint.Id));
            Assert.IsTrue(privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Description.Equals("Update descriptions"));
        }

        [Test]
        public async Task GetTest()
        {
            List<PrivateEndpointConnection> connections = await ConfigStore.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.FirstOrDefault().Data.Name;
            PrivateEndpointConnection privateEndpointConnection = await ConfigStore.GetPrivateEndpointConnections().GetAsync(privateEndpointConnectionName);

            Assert.IsTrue(privateEndpointConnectionName.Equals(privateEndpointConnection.Data.Name));
            Assert.IsTrue(privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Status == Models.ConnectionStatus.Approved);
        }

        [Test]
        public async Task GetAllTest()
        {
            string configurationStoreName1 = Recording.GenerateAssetName("testapp-");
            string configurationStoreName2 = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName1, configurationStoreData)).WaitForCompletionAsync();
            await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName2, configurationStoreData)).WaitForCompletionAsync();
            List<ConfigurationStore> configurationStores = await ResGroup.GetConfigurationStores().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(configurationStores.Count >= 2);
            Assert.IsTrue(configurationStores.Where(x => x.Data.Name == configurationStoreName1).FirstOrDefault().Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }

        [Test]
        public async Task GetIfExistsTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetIfExistsAsync(configurationStoreName);

            Assert.IsTrue(configurationStore.Data.Name == configurationStoreName);

            configurationStore = await ResGroup.GetConfigurationStores().GetIfExistsAsync("foo");

            Assert.IsNull(configurationStore);
        }
    }
}
