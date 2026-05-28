// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private AppConfigurationStoreResource ConfigStore { get; set; }
        private Network.PrivateEndpointResource PrivateEndpointResource { get; set; }
        public PrivateEndpointConnectionCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task Prepare()
        {
                Initialize();
                string groupName = Recording.GenerateAssetName(ResourceGroupPrefix);
                string VnetName = Recording.GenerateAssetName("vnetname");
                string SubnetName = Recording.GenerateAssetName("subnetname");
                string EndpointName = Recording.GenerateAssetName("endpointxyz");
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
                };
                ConfigStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;
                // Prepare VNet and Private Endpoint
                VirtualNetworkData vnetData = new VirtualNetworkData()
                {
                    Location = "eastus",
                    Subnets = { new SubnetData() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicy = "Disabled" } }
                };
                vnetData.AddressPrefixes.Add("10.0.0.0/16");
                vnetData.DhcpOptionsDnsServers.Add("10.1.1.1");
                vnetData.DhcpOptionsDnsServers.Add("10.1.2.4");
                ResourceIdentifier subnetID = await GetSubnetID(ResGroup, VnetName, SubnetName, vnetData);
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
                    Subnet = new SubnetData() { Id = subnetID }
                };
                PrivateEndpointResource = (await ResGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, EndpointName, privateEndpointData)).Value;
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            // Only support update
            await Prepare();
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
            await Prepare();
            List<AppConfigurationPrivateEndpointConnectionResource> connections = await ConfigStore.GetAppConfigurationPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.First().Data.Name;
            AppConfigurationPrivateEndpointConnectionResource privateEndpointConnection = await ConfigStore.GetAppConfigurationPrivateEndpointConnections().GetAsync(privateEndpointConnectionName);

            Assert.IsTrue(privateEndpointConnectionName.Equals(privateEndpointConnection.Data.Name));
            Assert.IsTrue(privateEndpointConnection.Data.ConnectionState.Status == Models.AppConfigurationPrivateLinkServiceConnectionStatus.Approved);
        }

        [Test]
        public async Task GetAllTest()
        {
            string configurationStoreName1 = Recording.GenerateAssetName("testapp-");
            string configurationStoreName2 = Recording.GenerateAssetName("testapp-");
            await Prepare();
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
            };
            await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName1, configurationStoreData);
            await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName2, configurationStoreData);
            List<AppConfigurationStoreResource> configurationStores = await ResGroup.GetAppConfigurationStores().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(configurationStores.Count >= 0);
            Assert.IsTrue(configurationStores.Where(x => x.Data.Name == configurationStoreName1).FirstOrDefault().Data.PublicNetworkAccess == AppConfigurationPublicNetworkAccess.Disabled);
        }
    }
}
