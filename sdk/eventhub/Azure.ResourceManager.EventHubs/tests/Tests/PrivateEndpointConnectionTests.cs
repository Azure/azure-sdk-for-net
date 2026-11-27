// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class PrivateEndpointConnectionTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubsNamespaceResource _eventHubNamespace;
        private EventHubsPrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _eventHubNamespace.GetEventHubsPrivateEndpointConnections(); }
        public PrivateEndpointConnectionTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
            // Network request bodies differ between the packaged and project-referenced Network SDKs.
            CompareBodies = false;
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            _eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
        }

        [RecordedTest]
        public async Task CreatePrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint = await CreatePrivateEndpoint();
            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections = await GetConnectionsAsync();
            EventHubsPrivateEndpointConnectionResource privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(EventHubsPrivateLinkConnectionStatus.Pending, privateEndpointConnection.Data.ConnectionState.Status);

            privateEndpointConnection = await CompleteConnectionUpdateAsync(await _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Started, privateEndpointConnection.Data.Name, new EventHubsPrivateEndpointConnectionData()
            {
                ConnectionState = new Models.EventHubsPrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            }), EventHubsPrivateLinkConnectionStatus.Approved);
            privateEndpoint = await privateEndpoint.GetAsync();
            privateEndpointConnection = await _privateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual(EventHubsPrivateLinkConnectionStatus.Approved, privateEndpointConnection.Data.ConnectionState.Status);
            privateEndpointConnection = await CompleteConnectionUpdateAsync(await privateEndpointConnection.UpdateAsync(WaitUntil.Started, new EventHubsPrivateEndpointConnectionData
            {
                ConnectionState = new EventHubsPrivateLinkServiceConnectionState
                {
                    Status = EventHubsPrivateLinkConnectionStatus.Rejected,
                    Description = "Updated by test"
                }
            }), EventHubsPrivateLinkConnectionStatus.Rejected);
            Response<EventHubsPrivateEndpointConnectionResource> readBack = await privateEndpointConnection.GetAsync();
            AssertStatus(readBack.GetRawResponse(), 200);
            Assert.AreEqual(EventHubsPrivateLinkConnectionStatus.Rejected, readBack.Value.Data.ConnectionState.Status);
            Assert.AreEqual("Updated by test", readBack.Value.Data.ConnectionState.Description);
        }

        [RecordedTest]
        public async Task GetAllPrivateEndpointConnection()
        {
            PrivateEndpointResource privateEndpoint1 = await CreatePrivateEndpoint();
            Assert.AreEqual(privateEndpoint1.Data.ManualPrivateLinkServiceConnections.Count, 1);

            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections1 = await GetConnectionsAsync();
            Assert.AreEqual(1, privateEndpointConnections1.Count);
            VerifyPrivateEndpointConnections(privateEndpoint1.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections1[0]);
        }

        [RecordedTest]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            List<EventHubsPrivateEndpointConnectionResource> privateEndpointConnections = await GetConnectionsAsync();
            string name = privateEndpointConnections[0].Data.Name;
            Assert.IsTrue(await _privateEndpointConnectionCollection.ExistsAsync(name));
            var id = _privateEndpointConnectionCollection.Id;
            id = EventHubsPrivateEndpointConnectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, name);
            EventHubsPrivateEndpointConnectionResource privateEndpointConnection = Client.GetEventHubsPrivateEndpointConnectionResource(id);
            Assert.IsNotNull(privateEndpointConnection);

            await CompleteAsync(await privateEndpointConnection.DeleteAsync(WaitUntil.Started));
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _privateEndpointConnectionCollection.GetAsync(name); });
            Assert.AreEqual(404, exception.Status);
            privateEndpointConnections = await ReadAllAsync(_privateEndpointConnectionCollection.GetAllAsync());
            Assert.AreEqual(0, privateEndpointConnections.Count);
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var peName = Recording.GenerateAssetName("pe-");
            var pecName = Recording.GenerateAssetName("pec");
            var vnet = new VirtualNetworkData()
            {
                Location = DefaultLocation,
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                }}
            };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnet.DhcpOptionsDnsServers.Add("10.1.2.4");
            ResourceIdentifier subnetID;
            VirtualNetworkResource vnetResource = await CompleteAsync(await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Started, vnetName, vnet));
            subnetID = vnetResource.Data.Subnets[0].Id;
            //var name = Recording.GenerateAssetName("pe-");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = DefaultLocation,
                Subnet = new SubnetData() { Id = subnetID },
                ManualPrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = pecName,
                        PrivateLinkServiceId = _eventHubNamespace.Id,

                        RequestMessage = "SDK test",
                        GroupIds = { "namespace" }
                    }
                },
            };

            return await CompleteAsync(await _resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Started, peName, privateEndpointData));
        }

        private async Task<EventHubsPrivateEndpointConnectionResource> CompleteConnectionUpdateAsync(
            ArmOperation<EventHubsPrivateEndpointConnectionResource> operation, EventHubsPrivateLinkConnectionStatus expectedStatus)
        {
            AssertStatus(operation.GetRawResponse(), 200, 201, 202);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            // This PUT can return a completed SDK wrapper around a service-accepted 202.
            AssertStatus(operation.GetRawResponse(), 200, 201, 202);
            EventHubsPrivateEndpointConnectionResource resource = operation.Value;
            for (int attempt = 0; attempt < 60; attempt++)
            {
                Response<EventHubsPrivateEndpointConnectionResource> response = await resource.GetAsync();
                AssertStatus(response.GetRawResponse(), 200);
                resource = response.Value;
                if (resource.Data.ConnectionState.Status == expectedStatus &&
                    resource.Data.ProvisioningState == EventHubsPrivateEndpointConnectionProvisioningState.Succeeded)
                {
                    return resource;
                }
                if (attempt < 59 && Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
            Assert.Fail($"Connection did not reach {expectedStatus}/Succeeded: {resource.Data.ConnectionState.Status}/{resource.Data.ProvisioningState}.");
            return resource;
        }

        private async Task<List<EventHubsPrivateEndpointConnectionResource>> GetConnectionsAsync()
        {
            List<EventHubsPrivateEndpointConnectionResource> connections = null;
            for (int attempt = 0; attempt < 12; attempt++)
            {
                connections = await ReadAllAsync(_privateEndpointConnectionCollection.GetAllAsync());
                if (connections.Count > 0)
                {
                    return connections;
                }
                if (attempt < 11 && Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
            Assert.IsNotEmpty(connections, "The network-created endpoint connection did not appear in Event Hubs.");
            return connections;
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
