// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Attestation.Tests.Helpers;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Attestation.Tests
{
    public class PrivateEndpointConnectionTests : AttestationManagementTestBase
    {
        public PrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateEndpointConnectionApiTest()
        {
            //Prepare
            var providerName = Recording.GenerateAssetName("testprovider");
            var pointName = Recording.GenerateAssetName("testEndpoint-");
            var endpointName = Recording.GenerateAssetName("testEndpointConnection-");
            var endpointName2 = Recording.GenerateAssetName("testEndpointConnection-");
            var endpointName3 = Recording.GenerateAssetName("testEndpointConnection-");
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetAttestationProviders();
            var providrerCollection = resourceGroup.GetAttestationProviders();
            var providerInput = ResourceDataHelper.GetProviderData(DefaultLocation);
            //1.CreateOrUpdate
            var providerResource = (await providrerCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, providerInput)).Value;
            var endpoint = await GetEndpointResource(resourceGroup, providerResource.Data.Id);
            var endpointCollection = providerResource.GetAttestationPrivateEndpointConnections();
            //2.Get
            var connections = await endpointCollection.GetAllAsync().ToEnumerableAsync();
            string privateEndpointConnectionName = connections.FirstOrDefault().Data.Name;
            var privateEndpointConnectionData = connections.FirstOrDefault().Data;
            Assert.NotNull(privateEndpointConnectionData);
            Assert.AreEqual("Approved", privateEndpointConnectionData.ConnectionState.Status.ToString());
            //3.GetAll
            var list = await endpointCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            //4.CheckIfExist
            Assert.True(await endpointCollection.ExistsAsync(list[0].Data.Name));
            Assert.False(await endpointCollection.ExistsAsync(list[0].Data.Name + "01"));
            //Resouece operation
            //Delete
            Assert.AreEqual(1, list.Count);
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
            list = await endpointCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
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
                            GroupIds = {"standard"},
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
