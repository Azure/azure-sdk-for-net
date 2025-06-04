// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.Core;
using Azure.ResourceManager.HardwareSecurityModules.Models;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests
{
    public class CloudHsmClustersPrivateEndpointConnectionTests : HardwareSecurityModulesManagementTestBase
    {
        private CloudHsmClusterResource _cloudHsmClusterResource;
        private CloudHsmClusterPrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _cloudHsmClusterResource.GetCloudHsmClusterPrivateEndpointConnections(); }

        public CloudHsmClustersPrivateEndpointConnectionTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUpForTests();

            //Create Cloud HSM
            string resourceName = Recording.GenerateAssetName("CloudhsmSDKTest");
            _cloudHsmClusterResource = await CreateCloudHsmClusterResourceAsync();
        }

        [Ignore("Exception")]
        [RecordedTest]
        public async Task CreateOrUpdateAsyncPrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();

            List<CloudHsmClusterPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(privateEndpointConnections);

            CloudHsmClusterPrivateEndpointConnectionResource privateEndpointConnectionResource = privateEndpointConnections.FirstOrDefault();
            var expectedPrivateEndpointManualLinkServiceConnections = privateEndpoint.Data.ManualPrivateLinkServiceConnections.FirstOrDefault();

            Assert.IsNotNull(privateEndpointConnectionResource);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Status.ToString(),privateEndpointConnectionResource.Data.Properties.ConnectionState.Status.ToString());
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Description, privateEndpointConnectionResource.Data.Properties.ConnectionState.Description);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.GroupIds, privateEndpointConnectionResource.Data.Properties.GroupIds);
            Assert.AreEqual(CloudHsmClusterPrivateEndpointServiceConnectionStatus.Pending, privateEndpointConnectionResource.Data.Properties.ConnectionState.Status);

            CloudHsmClusterPrivateEndpointConnectionData data = new CloudHsmClusterPrivateEndpointConnectionData()
            {
                Properties = new CloudHsmClusterPrivateEndpointConnectionProperties(new CloudHsmClusterPrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Approve by sdk test case"
                }),
            };

            _ = await _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionResource.Data.Name, data);

            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnectionResource = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnectionResource.Data.Name);
            expectedPrivateEndpointManualLinkServiceConnections = privateEndpoint.Data.ManualPrivateLinkServiceConnections.FirstOrDefault();

            Assert.IsNotNull(privateEndpoint);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Status.ToString(), privateEndpointConnectionResource.Data.Properties.ConnectionState.Status.ToString());
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Description, privateEndpointConnectionResource.Data.Properties.ConnectionState.Description);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.GroupIds, privateEndpointConnectionResource.Data.Properties.GroupIds);
            Assert.AreEqual(CloudHsmClusterPrivateEndpointServiceConnectionStatus.Approved, privateEndpointConnectionResource.Data.Properties.ConnectionState.Status);
        }

        [Ignore("Exception")]
        [RecordedTest]
        public async Task GetAllPrivateEndpointConnections()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            Assert.IsTrue(privateEndpoint.Data.ManualPrivateLinkServiceConnections.Count == 1);

            List<CloudHsmClusterPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            CloudHsmClusterPrivateEndpointConnectionResource privateEndpointConnectionResource = privateEndpointConnections.FirstOrDefault();
            var expectedPrivateEndpointManualLinkServiceConnections = privateEndpoint.Data.ManualPrivateLinkServiceConnections.FirstOrDefault();

            Assert.IsTrue(privateEndpointConnections.Count == 1);
            Assert.IsNotNull(privateEndpointConnectionResource);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Status.ToString(), privateEndpointConnectionResource.Data.Properties.ConnectionState.Status.ToString());
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.ConnectionState.Description, privateEndpointConnectionResource.Data.Properties.ConnectionState.Description);
            Assert.AreEqual(expectedPrivateEndpointManualLinkServiceConnections.GroupIds, privateEndpointConnectionResource.Data.Properties.GroupIds);
            Assert.AreEqual(CloudHsmClusterPrivateEndpointServiceConnectionStatus.Pending, privateEndpointConnectionResource.Data.Properties.ConnectionState.Status);
        }

        [Ignore("Exception")]
        [RecordedTest]
        public async Task DeletePrivateEndpointConnection()
        {
            var privateEndpoint = await CreatePrivateEndpoint();
            List<CloudHsmClusterPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            string pecName = privateEndpointConnections[0].Data.Name;
            //Check that the resource is there before deleting.
            Assert.IsTrue(await _privateEndpointConnectionCollection.ExistsAsync(pecName));

            await privateEndpoint.DeleteAsync(WaitUntil.Completed);
            privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();

            Assert.IsFalse(await _privateEndpointConnectionCollection.ExistsAsync(pecName));
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _privateEndpointConnectionCollection.GetAsync(pecName); });
            Assert.AreEqual(404, exception.Status);
            Assert.AreEqual(0, privateEndpointConnections.Count);
        }

        protected async Task<CloudHsmClusterResource> CreateCloudHsmClusterResourceAsync()
        {
            string resourceName = Recording.GenerateAssetName("CloudhsmSDKTest");
            CloudHsmClusterData cloudHsmClusterBody = new CloudHsmClusterData(Location)
            {
                Sku = new CloudHsmClusterSku(CloudHsmClusterSkuFamily.B, CloudHsmClusterSkuName.StandardB1),
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                    ["UseMockHfc"] = "true",
                    ["MockHfcDelayInMs"] = "1"
                },
            };

            CloudHsmClusterCollection collection = ResourceGroupResource.GetCloudHsmClusters();
            var createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, cloudHsmClusterBody);
            return createOperation.Value;
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("pe-vnet-");
            var peName = Recording.GenerateAssetName("pe-");
            var pecName = Recording.GenerateAssetName("pec-");

            var vnet = new VirtualNetworkData()
            {
                Location = Location,
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = "default",
                        AddressPrefix = "10.0.1.0/24",
                        PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                    }
                }
            };

            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnet.DhcpOptionsDnsServers.Add("10.1.2.4");
            //VirtualNetworkResource virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;

            ResourceIdentifier subnetID;
            VirtualNetworkResource vnetResource = (await ResourceGroupResource.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            var subnetCollection = vnetResource.GetSubnets();
            subnetID = vnetResource.Data.Subnets[0].Id;
            //var name = Recording.GenerateAssetName("pe-");

            var privateEndpointData = new PrivateEndpointData
            {
                Location = Location,
                Subnet = new SubnetData { Id = subnetID },
                ManualPrivateLinkServiceConnections =
                {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = pecName,
                         // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _cloudHsmClusterResource.Id,
                        RequestMessage = "SDK testing",
                        GroupIds = { "cloudhsm" }
                    }
                },
            };

            PrivateEndpointResource privateEndpoint = (await ResourceGroupResource.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, peName, privateEndpointData)).Value;
            Assert.AreEqual(privateEndpoint.Data.Name, peName);
            return privateEndpoint;
        }
    }
}
