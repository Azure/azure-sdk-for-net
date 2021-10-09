// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class PrivateLinkResourceContainerTests : AppConfigurationClientBase
    {
        private ResourceGroup ResGroup { get; set; }
        private ConfigurationStore ConfigStore { get; set; }

        public PrivateLinkResourceContainerTests(bool isAsync)
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
                ResGroup = await (await ArmClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(groupName, new ResourceGroupData(Location))).WaitForCompletionAsync();
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();
                // Prepare VNet and Private Endpoint
                //VirtualNetworkData vnetData = new VirtualNetworkData()
                //{
                //    Location = "eastus",
                //    AddressSpace = new AddressSpace()
                //    {
                //        AddressPrefixes = { "10.0.0.0/16", }
                //    },
                //    DhcpOptions = new DhcpOptions()
                //    {
                //        DnsServers = { "10.1.1.1", "10.1.2.4" }
                //    },
                //    Subnets = { new SubnetData() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicies = "Disabled" } }
                //};
                //VirtualNetwork vnet = await (await ResGroup.GetVirtualNetworks().CreateOrUpdateAsync(VnetName, vnetData)).WaitForCompletionAsync();
                //PrivateEndpointData privateEndpointData = new PrivateEndpointData()
                //{
                //    Location = "eastus",
                //    PrivateLinkServiceConnections = { new PrivateLinkServiceConnection()
                //        {
                //            Name ="myconnection",
                //            PrivateLinkServiceId = ConfigStore.Data.Id,
                //            GroupIds = {"configurationStores"},
                //            RequestMessage = "Please approve my connection",
                //        }
                //        },
                //    Subnet = new SubnetData() { Id = "/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/" + groupName + "/providers/Microsoft.Network/virtualNetworks/" + VnetName + "/subnets/" + SubnetName }
                //};
                //PrivateEndpoint = await (await ResGroup.GetPrivateEndpoints().CreateOrUpdateAsync(EndpointName, privateEndpointData)).WaitForCompletionAsync();
            }
        }

        [Test]
        public async Task GetTest()
        {
            PrivateLinkResource linkResource = await ConfigStore.GetPrivateLinkResources().GetAsync("configurationStores");

            Assert.NotNull(linkResource);
        }

        [Test]
        public async Task GetIfExistsTest()
        {
            PrivateLinkResource linkResource = await ConfigStore.GetPrivateLinkResources().GetIfExistsAsync("configurationStores");

            Assert.NotNull(linkResource);
        }

        [Test]
        public async Task GetAllTest()
        {
            List<PrivateLinkResource> linkResources = await ConfigStore.GetPrivateLinkResources().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(linkResources.Count > 0);
        }

        [Test]
        public async Task CheckIfExistsTest()
        {
            bool linkResource = await ConfigStore.GetPrivateLinkResources().CheckIfExistsAsync("configurationStores");

            Assert.IsTrue(linkResource);
        }
    }
}
