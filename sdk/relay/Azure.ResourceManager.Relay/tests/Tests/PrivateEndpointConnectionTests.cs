// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relay.Tests.Helpers;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.Core;
using Azure.ResourceManager.Relay.Models;

namespace Azure.ResourceManager.Relay.Tests
{
    public class PrivateEndpointConnectionTests: RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private RelayNamespaceResource _relayNamespace;
        private RelayPrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _relayNamespace.GetRelayPrivateEndpointConnections(); }
        public PrivateEndpointConnectionTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            RelayNamespaceCollection namespaceCollection = _resourceGroup.GetRelayNamespaces();
            _relayNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new RelayNamespaceData(DefaultLocation))).Value;
        }

        [Test]
        [RecordedTest]
        [Ignore("Service returns empty type which causes a bug during deserialization")]
        public async Task CreatePrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            List<RelayPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            RelayPrivateEndpointConnectionResource privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.That(privateEndpointConnection.Data.ConnectionState.Status, Is.EqualTo(RelayPrivateLinkConnectionStatus.Pending));

            _ = await _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnection.Data.Name, new RelayPrivateEndpointConnectionData()
            {
                ConnectionState = new Models.RelayPrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            });
            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.That(privateEndpointConnection.Data.ConnectionState.Status, Is.EqualTo(RelayPrivateLinkConnectionStatus.Approved));
        }

        [Test]
        [RecordedTest]
        [Ignore("Service returns empty type which causes a bug during deserialization")]
        public async Task GetAllPrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            Assert.That(privateEndpoint.Data.ManualPrivateLinkServiceConnections, Has.Count.EqualTo(1));

            List<RelayPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateEndpointConnections, Has.Count.EqualTo(1));
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }

        [Test]
        [RecordedTest]
        [Ignore("Service returns empty type which causes a bug during deserialization")]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            List<RelayPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            string name = privateEndpointConnections[0].Data.Name;
            Assert.That((bool)await _privateEndpointConnectionCollection.ExistsAsync(name), Is.True);
            var id = _privateEndpointConnectionCollection.Id;
            id = RelayPrivateEndpointConnectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, name);
            RelayPrivateEndpointConnectionResource privateEndpointConnection = Client.GetRelayPrivateEndpointConnectionResource(id);
            Assert.That(privateEndpointConnection, Is.Not.Null);

            await privateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _privateEndpointConnectionCollection.GetAsync(name); });
            Assert.That(exception.Status, Is.EqualTo(404));
            privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateEndpointConnections.Count, Is.EqualTo(0));
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
                        PrivateLinkServiceId = _relayNamespace.Id,

                        RequestMessage = "SDK test",
                        GroupIds = { "namespace" }
                    }
                },
            };

            return (await _resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, name, privateEndpointData)).Value;
        }

        private void VerifyPrivateEndpointConnections(NetworkPrivateLinkServiceConnection expectedValue, RelayPrivateEndpointConnectionResource actualValue)
        {
            Assert.Multiple(() =>
            {
                // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
                //Assert.AreEqual(expectedValue.Id, actualValue.Id);
                //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
                Assert.That(actualValue.Data.ConnectionState.Status.ToString(), Is.EqualTo(expectedValue.ConnectionState.Status));
                Assert.That(actualValue.Data.ConnectionState.Description, Is.EqualTo(expectedValue.ConnectionState.Description));
            });
        }
    }
}
