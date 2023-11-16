// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Attestation.Models;
using Azure.ResourceManager.Attestation.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Attestation.Tests
{
    public class PrivateEndpointConnectionTests : AttestationManagementTestBase
    {
        public PrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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
            var providerResource = (await providrerCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, providerInput)).Value;
            var endpoint = await GetEndpointResource(resourceGroup, providerResource.Data.Id);
            var endppintCollection = providerResource.GetAttestationPrivateEndpointConnections();
            //1.CreateOrUpdate
            var input = ResourceDataHelper.GetPrivateEndpointConnectionData();
            var endpointResource = (await endppintCollection.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, input)).Value;
            Assert.AreEqual(endpointName, endpointResource.Data.Name);
            //2.Get
            var endpointResource2 = (await endpointResource.GetAsync()).Value;
            ResourceDataHelper.AssetPrivateEndpointConnection(endpointResource.Data, endpointResource.Data);
            //3.GetAll
            _ = await endppintCollection.CreateOrUpdateAsync(WaitUntil.Completed, endpointName2, input);
            _ = await endppintCollection.CreateOrUpdateAsync(WaitUntil.Completed, endpointName3, input);
            int count = 0;
            await foreach (var availabilitySet in providrerCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await endppintCollection.ExistsAsync(providerName));
            Assert.IsFalse(await endppintCollection.ExistsAsync(providerName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endppintCollection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var endpointResource3 = (await endpointResource.GetAsync()).Value;
            ResourceDataHelper.AssetPrivateEndpointConnection(endpointResource.Data, endpointResource3.Data);
            //2.Update
            AttestationPrivateEndpointConnectionData data = new AttestationPrivateEndpointConnectionData()
            {
                ConnectionState = new AttestationPrivateLinkServiceConnectionState()
                {
                    Description = "Updated Auto-Approved",
                },
            };
            var endpointResource4 = (await endpointResource3.UpdateAsync(WaitUntil.Completed, data)).Value;
            ResourceDataHelper.AssetPrivateEndpointConnection(endpointResource4.Data, data);
            //3. Delete
            await endpointResource4.DeleteAsync(WaitUntil.Completed);
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
