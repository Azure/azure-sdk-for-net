// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests
{
    public class PrivateEndpointConnectionTests : StorageTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private StoragePrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _storageAccount.GetStoragePrivateEndpointConnections(); }
        public PrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            _storageAccount = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2))).Value;
        }

        [TearDown]
        public async Task TearDown()
        {
            List<StoragePrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            foreach (StoragePrivateEndpointConnectionResource connection in privateEndpointConnections)
            {
                await connection.DeleteAsync(WaitUntil.Completed);
            }
            await _storageAccount.DeleteAsync(WaitUntil.Completed);
        }
        [Test]
        [RecordedTest]
        public async Task CreatePrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            List<StoragePrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            StoragePrivateEndpointConnectionResource privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(StoragePrivateEndpointServiceConnectionStatus.Pending, privateEndpointConnection.Data.ConnectionState.Status);

            _ = await _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnection.Data.Name, new StoragePrivateEndpointConnectionData()
            {
                ConnectionState = new Models.StoragePrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            });
            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(StoragePrivateEndpointServiceConnectionStatus.Approved, privateEndpointConnection.Data.ConnectionState.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllPrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            Assert.AreEqual(privateEndpoint.Data.ManualPrivateLinkServiceConnections.Count, 1);

            List<StoragePrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, privateEndpointConnections.Count);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }
        [Test]
        [RecordedTest]
        public async Task StoragePrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            List<StoragePrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            string name = privateEndpointConnections[0].Data.Name;
            Assert.IsTrue(await _privateEndpointConnectionCollection.ExistsAsync(name));
            var id = _privateEndpointConnectionCollection.Id;
            id = StoragePrivateEndpointConnectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, name);
            StoragePrivateEndpointConnectionResource privateEndpointConnection = Client.GetStoragePrivateEndpointConnectionResource(id);

            await privateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            //should return 404 rather than 400
            //privateEndpointConnection = await _privateEndpointConnectionCollection.GetIfExistsAsync(privateEndpointConnection.Data.Name);
            //Assert.Null(privateEndpointConnection);
            privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, privateEndpointConnections.Count);
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnet = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS2,
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                }}
            };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnet.DhcpOptionsDnsServers.Add("10.1.2.4");
            VirtualNetworkResource virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;

            var name = Recording.GenerateAssetName("pe-");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = AzureLocation.WestUS2,
                Subnet = virtualNetwork.Data.Subnets[0],
                ManualPrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("pec"),
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _storageAccount.Id,

                        RequestMessage = "SDK test",
                        GroupIds = { "Blob" }
                    }
                },
            };

            return (await _resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, name, privateEndpointData)).Value;
        }
        private void VerifyPrivateEndpointConnections(NetworkPrivateLinkServiceConnection expectedValue, StoragePrivateEndpointConnectionResource actualValue)
        {
            // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
            //Assert.AreEqual(expectedValue.Id, actualValue.Id);
            //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.ConnectionState.Status, actualValue.Data.ConnectionState.Status.ToString());
            Assert.AreEqual(expectedValue.ConnectionState.Description, actualValue.Data.ConnectionState.Description);
        }
    }
}
