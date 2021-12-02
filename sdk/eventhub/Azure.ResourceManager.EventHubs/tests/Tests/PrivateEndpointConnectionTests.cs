// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.EventHubs.Tests.Helpers;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class PrivateEndpointConnectionTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        private EventHubNamespace _eventHubNamespace;
        private PrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _eventHubNamespace.GetPrivateEndpointConnections(); }
        public PrivateEndpointConnectionTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            _eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
        }

        [TearDown]
        public async Task TearDown()
        {
            List<PrivateEndpointConnection> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            foreach (PrivateEndpointConnection connection in privateEndpointConnections)
            {
                await connection.DeleteAsync();
            }
            await _eventHubNamespace.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("RequestFailedException")]
        public async Task CreatePrivateEndpointConnection()
        {
            PrivateEndpoint privateEndpoint = await CreatePrivateEndpoint();
            List<PrivateEndpointConnection> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            PrivateEndpointConnection privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(PrivateLinkConnectionStatus.Pending, privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Status);

            _ = await _privateEndpointConnectionCollection.CreateOrUpdateAsync(privateEndpointConnection.Data.Name, new PrivateEndpointConnectionData()
            {
                PrivateLinkServiceConnectionState = new Models.ConnectionState()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            });
            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(PrivateLinkConnectionStatus.Approved, privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Status);
        }

        [Test]
        [RecordedTest]
        [Ignore("can pass locally, cost too much time on pipeline")]
        public async Task GetAllPrivateEndpointConnection()
        {
            PrivateEndpoint privateEndpoint = await CreatePrivateEndpoint();
            Assert.AreEqual(privateEndpoint.Data.ManualPrivateLinkServiceConnections.Count, 1);

            List<PrivateEndpointConnection> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, privateEndpointConnections.Count);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }
        [Test]
        [RecordedTest]
        [Ignore("can pass locally, cost too much time on pipeline")]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            List<PrivateEndpointConnection> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            PrivateEndpointConnection privateEndpointConnection = await _privateEndpointConnectionCollection.GetIfExistsAsync(privateEndpointConnections[0].Data.Name);
            Assert.IsNotNull(privateEndpointConnection);

            await privateEndpointConnection.DeleteAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetIfExistsAsync(privateEndpointConnection.Data.Name);
            Assert.Null(privateEndpointConnection);
            privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, privateEndpointConnections.Count);
        }

        protected async Task<PrivateEndpoint> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnet = new VirtualNetworkData()
            {
                Location = Resources.Models.Location.WestUS2,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicies = VirtualNetworkPrivateEndpointNetworkPolicies.Disabled
                }}
            };
            VirtualNetwork virtualNetwork = await _resourceGroup.GetVirtualNetworks().CreateOrUpdate(vnetName, vnet).WaitForCompletionAsync();

            var name = Recording.GenerateAssetName("pe-");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = Resources.Models.Location.WestUS2,
                Subnet = virtualNetwork.Data.Subnets[0],
                ManualPrivateLinkServiceConnections = {
                    new PrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("pec"),
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _eventHubNamespace.Id,

                        RequestMessage = "SDK test",
                        GroupIds = { "namespace" }
                    }
                },
            };

            return await _resourceGroup.GetPrivateEndpoints().CreateOrUpdate(name, privateEndpointData).WaitForCompletionAsync();
        }

        private void VerifyPrivateEndpointConnections(PrivateLinkServiceConnection expectedValue, PrivateEndpointConnection actualValue)
        {
            // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
            //Assert.AreEqual(expectedValue.Id, actualValue.Id);
            //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.PrivateLinkServiceConnectionState.Status, actualValue.Data.PrivateLinkServiceConnectionState.Status.ToString());
            Assert.AreEqual(expectedValue.PrivateLinkServiceConnectionState.Description, actualValue.Data.PrivateLinkServiceConnectionState.Description);
        }
    }
}
