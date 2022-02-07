﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests
{
    public class VirtualNetworkPeeringTests : NetworkServiceClientTestBase
    {
        private Subscription _subscription;

        public VirtualNetworkPeeringTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkPeeringApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var location = "westus";
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string vnetName = Recording.GenerateAssetName("azsmnet");
            string remoteVirtualNetworkName = Recording.GenerateAssetName("azsmnet");
            string vnetPeeringName = Recording.GenerateAssetName("azsmnet");
            string subnet1Name = Recording.GenerateAssetName("azsmnet");
            string subnet2Name = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.0.1.0/24", }, new SubnetData() { Name = subnet2Name, AddressPrefix = "10.0.2.0/24", } }
            };

            // Put Vnet
            var virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(true, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            // Get Vnet
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);
            Assert.AreEqual(vnetName, getVnetResponse.Value.Data.Name);
            Assert.NotNull(getVnetResponse.Value.Data.ResourceGuid);
            Assert.AreEqual("Succeeded", getVnetResponse.Value.Data.ProvisioningState.ToString());

            // Get all Vnets
            AsyncPageable<VirtualNetwork> getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            await getAllVnetsAP.ToEnumerableAsync();
            vnet.AddressSpace.AddressPrefixes[0] = "10.1.0.0/16";
            vnet.Subnets[0].AddressPrefix = "10.1.1.0/24";
            vnet.Subnets[1].AddressPrefix = "10.1.2.0/24";
            var remoteVirtualNetworkOperation = await virtualNetworkCollection.CreateOrUpdateAsync(true, remoteVirtualNetworkName, vnet);
            Response<VirtualNetwork> remoteVirtualNetwork = await remoteVirtualNetworkOperation.WaitForCompletionAsync();;

            // Get Peerings in the vnet
            var virtualNetworkPeeringCollection = (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetVirtualNetworkPeerings();
            AsyncPageable<VirtualNetworkPeering> listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            List<VirtualNetworkPeering> listPeering = await listPeeringAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeering);

            var peering = new VirtualNetworkPeeringData
            {
                Name = vnetPeeringName,
                RemoteVirtualNetwork = new WritableSubResource
                {
                    Id = remoteVirtualNetwork.Value.Id
                },
                AllowForwardedTraffic = true,
                AllowVirtualNetworkAccess = false
            };

            // Put peering in the vnet
            var putPeeringOperation = await virtualNetworkPeeringCollection.CreateOrUpdateAsync(true, vnetPeeringName, peering);
            Response<VirtualNetworkPeering> putPeering = await putPeeringOperation.WaitForCompletionAsync();;
            Assert.NotNull(putPeering.Value.Data.Etag);
            Assert.AreEqual(vnetPeeringName, putPeering.Value.Data.Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, putPeering.Value.Data.RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, putPeering.Value.Data.AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, putPeering.Value.Data.AllowVirtualNetworkAccess);
            Assert.False(putPeering.Value.Data.UseRemoteGateways);
            Assert.False(putPeering.Value.Data.AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, putPeering.Value.Data.PeeringState);

            // get peering
            Response<VirtualNetworkPeering> getPeering = await virtualNetworkPeeringCollection.GetAsync(vnetPeeringName);
            Assert.AreEqual(getPeering.Value.Data.Etag, putPeering.Value.Data.Etag);
            Assert.AreEqual(vnetPeeringName, getPeering.Value.Data.Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, getPeering.Value.Data.RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, getPeering.Value.Data.AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, getPeering.Value.Data.AllowVirtualNetworkAccess);
            Assert.False(getPeering.Value.Data.UseRemoteGateways);
            Assert.False(getPeering.Value.Data.AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, getPeering.Value.Data.PeeringState);

            // list peering
            listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeering);
            Assert.AreEqual(listPeering.ElementAt(0).Data.Etag, putPeering.Value.Data.Etag);
            Assert.AreEqual(vnetPeeringName, listPeering.ElementAt(0).Data.Name);
            Assert.AreEqual(remoteVirtualNetwork.Value.Id, listPeering.ElementAt(0).Data.RemoteVirtualNetwork.Id);
            Assert.AreEqual(peering.AllowForwardedTraffic, listPeering.ElementAt(0).Data.AllowForwardedTraffic);
            Assert.AreEqual(peering.AllowVirtualNetworkAccess, listPeering.ElementAt(0).Data.AllowVirtualNetworkAccess);
            Assert.False(listPeering.ElementAt(0).Data.UseRemoteGateways);
            Assert.False(listPeering.ElementAt(0).Data.AllowGatewayTransit);
            Assert.AreEqual(VirtualNetworkPeeringState.Initiated, listPeering.ElementAt(0).Data.PeeringState);

            // delete peering
            await getPeering.Value.DeleteAsync(true);
            listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeering);

            // Delete Vnet
            await putVnetResponse.Value.DeleteAsync(true);
            await remoteVirtualNetwork.Value.DeleteAsync(true);

            // Get all Vnets
            getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            List<VirtualNetwork> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.IsEmpty(getAllVnets);
        }
    }
}
