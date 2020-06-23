// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class VirtualNetworkPeeringTests : NetworkTestsManagementClientBase
    {
        public VirtualNetworkPeeringTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task VirtualNetworkPeeringApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var location = "westus";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string vnetName = Recording.GenerateAssetName("azsmnet");
            string remoteVirtualNetworkName = Recording.GenerateAssetName("azsmnet");
            string vnetPeeringName = Recording.GenerateAssetName("azsmnet");
            string subnet1Name = Recording.GenerateAssetName("azsmnet");
            string subnet2Name = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnet1Name, AddressPrefix = "10.0.1.0/24", }, new Subnet() { Name = subnet2Name, AddressPrefix = "10.0.2.0/24", } }
            };

            // Put Vnet
            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            Assert.AreEqual("Succeeded", putVnetResponse.Value.ProvisioningState.ToString());

            // Get Vnet
            Response<VirtualNetwork> getVnetResponse = await NetworkManagementClient.VirtualNetworks.GetAsync(resourceGroupName, vnetName);
            Assert.AreEqual(vnetName, getVnetResponse.Value.Name);
            Assert.NotNull(getVnetResponse.Value.ResourceGuid);
            Assert.AreEqual("Succeeded", getVnetResponse.Value.ProvisioningState.ToString());

            // Get all Vnets
            AsyncPageable<VirtualNetwork> getAllVnetsAP = NetworkManagementClient.VirtualNetworks.ListAsync(resourceGroupName);
            await getAllVnetsAP.ToEnumerableAsync();
            vnet.AddressSpace.AddressPrefixes[0] = "10.1.0.0/16";
            vnet.Subnets[0].AddressPrefix = "10.1.1.0/24";
            vnet.Subnets[1].AddressPrefix = "10.1.2.0/24";
            VirtualNetworksCreateOrUpdateOperation remoteVirtualNetworkOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, remoteVirtualNetworkName, vnet);
            Response<VirtualNetwork> remoteVirtualNetwork = await WaitForCompletionAsync(remoteVirtualNetworkOperation);

            // Get Peerings in the vnet
            AsyncPageable<VirtualNetworkPeering> listPeeringAP = NetworkManagementClient.VirtualNetworkPeerings.ListAsync(resourceGroupName, vnetName);
            List<VirtualNetworkPeering> listPeering = await listPeeringAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeering);

            VirtualNetworkPeering peering = new VirtualNetworkPeering
            {
                Name = vnetPeeringName,
                RemoteVirtualNetwork = new SubResource
                {
                    Id = remoteVirtualNetwork.Value.Id
                },
                AllowForwardedTraffic = true,
                AllowVirtualNetworkAccess = false
            };

            // Put peering in the vnet
            VirtualNetworkPeeringsCreateOrUpdateOperation putPeeringOperation = await NetworkManagementClient.VirtualNetworkPeerings.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnetPeeringName, peering);
            Response<VirtualNetworkPeering> putPeering = await WaitForCompletionAsync(putPeeringOperation);
            Assert.NotNull(putPeering.Value.Etag);
            Assert.AreEqual(vnetPeeringName, putPeering.Value.Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, putPeering.Value.RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, putPeering.Value.AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, putPeering.Value.AllowVirtualNetworkAccess);
            Assert.False(putPeering.Value.UseRemoteGateways);
            Assert.False(putPeering.Value.AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, putPeering.Value.PeeringState);

            // get peering
            Response<VirtualNetworkPeering> getPeering = await NetworkManagementClient.VirtualNetworkPeerings.GetAsync(resourceGroupName, vnetName, vnetPeeringName);
            Assert.AreEqual(getPeering.Value.Etag, putPeering.Value.Etag);
            Assert.AreEqual(vnetPeeringName, getPeering.Value.Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, getPeering.Value.RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, getPeering.Value.AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, getPeering.Value.AllowVirtualNetworkAccess);
            Assert.False(getPeering.Value.UseRemoteGateways);
            Assert.False(getPeering.Value.AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, getPeering.Value.PeeringState);

            // list peering
            listPeeringAP = NetworkManagementClient.VirtualNetworkPeerings.ListAsync(resourceGroupName, vnetName);
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeering);
            Assert.AreEqual(listPeering.ElementAt(0).Etag, putPeering.Value.Etag);
            Assert.AreEqual(vnetPeeringName, listPeering.ElementAt(0).Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, listPeering.ElementAt(0).RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, listPeering.ElementAt(0).AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, listPeering.ElementAt(0).AllowVirtualNetworkAccess);
            Assert.False(listPeering.ElementAt(0).UseRemoteGateways);
            Assert.False(listPeering.ElementAt(0).AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, listPeering.ElementAt(0).PeeringState);

            // delete peering
            await NetworkManagementClient.VirtualNetworkPeerings.StartDeleteAsync(resourceGroupName, vnetName, vnetPeeringName);
            listPeeringAP = NetworkManagementClient.VirtualNetworkPeerings.ListAsync(resourceGroupName, vnetName);
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeering);

            // Delete Vnet
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, remoteVirtualNetworkName);

            // Get all Vnets
            getAllVnetsAP = NetworkManagementClient.VirtualNetworks.ListAsync(resourceGroupName);
            List<VirtualNetwork> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.IsEmpty(getAllVnets);
        }
    }
}
