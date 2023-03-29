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
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class PrivateEndpointConnectionTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubsNamespaceResource _eventHubNamespace;
        private EventHubsPrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _eventHubNamespace.GetEventHubsPrivateEndpointConnections(); }
        public PrivateEndpointConnectionTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            _eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
        }

        [Test]
        [RecordedTest]
        [Ignore("RequestFailedException")]
        public async Task CreatePrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            EventHubsPrivateEndpointConnectionResource privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(EventHubsPrivateLinkConnectionStatus.Pending, privateEndpointConnection.Data.ConnectionState.Status);

            _ = await _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnection.Data.Name, new EventHubsPrivateEndpointConnectionData()
            {
                ConnectionState = new Models.EventHubsPrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            });
            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(EventHubsPrivateLinkConnectionStatus.Approved, privateEndpointConnection.Data.ConnectionState.Status);
        }

        [Test]
        public async Task GetAllPrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            Assert.AreEqual(privateEndpoint.Data.ManualPrivateLinkServiceConnections.Count, 1);

            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, privateEndpointConnections.Count);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }
        [Test]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            string name = privateEndpointConnections[0].Data.Name;
            Assert.IsTrue(await _privateEndpointConnectionCollection.ExistsAsync(name));
            var id = _privateEndpointConnectionCollection.Id;
            id = EventHubsPrivateEndpointConnectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, name);
            EventHubsPrivateEndpointConnectionResource privateEndpointConnection = Client.GetEventHubsPrivateEndpointConnectionResource(id);
            Assert.IsNotNull(privateEndpointConnection);

            await privateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _privateEndpointConnectionCollection.GetAsync(name); });
            Assert.AreEqual(404, exception.Status);
            privateEndpointConnections = await _privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, privateEndpointConnections.Count);
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var peName = Recording.GenerateAssetName("pe-");
            var pecName = Recording.GenerateAssetName("pec");
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
            //VirtualNetworkResource virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            ResourceIdentifier subnetID;
            if (Mode == RecordedTestMode.Playback)
            {
                subnetID = SubnetResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, vnetName, "default");
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    VirtualNetworkResource vnetResource = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
                    var subnetCollection = vnetResource.GetSubnets();
                    //SubnetResource subnetResource = (await subnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, subnetName2, subnetData)).Value;
                    subnetID = vnetResource.Data.Subnets[0].Id;
                }
            };
            //var name = Recording.GenerateAssetName("pe-");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = AzureLocation.WestUS2,
                Subnet = new SubnetData() { Id = subnetID },
                ManualPrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = pecName,
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _eventHubNamespace.Id,

                        RequestMessage = "SDK test",
                        GroupIds = { "namespace" }
                    }
                },
            };

            return (await _resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, peName, privateEndpointData)).Value;
        }

        private void VerifyPrivateEndpointConnections(NetworkPrivateLinkServiceConnection expectedValue, EventHubsPrivateEndpointConnectionResource actualValue)
        {
            // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
            //Assert.AreEqual(expectedValue.Id, actualValue.Id);
            //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.ConnectionState.Status, actualValue.Data.ConnectionState.Status.ToString());
            Assert.AreEqual(expectedValue.ConnectionState.Description, actualValue.Data.ConnectionState.Description);
        }
    }
}
