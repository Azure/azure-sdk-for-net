// Copyright (c) Microsoft Corporation. All rights reserved.
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

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class VirtualNetworkPeeringTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public VirtualNetworkPeeringTests(bool isAsync, string apiVersion)
        : base(isAsync, VirtualNetworkPeeringResource.ResourceType, apiVersion)
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
                AddressSpace = new VirtualNetworkAddressSpace()
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
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.That(putVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get Vnet
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);
            Assert.That(getVnetResponse.Value.Data.Name, Is.EqualTo(vnetName));
            Assert.That(getVnetResponse.Value.Data.ResourceGuid, Is.Not.Null);
            Assert.That(getVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get all Vnets
            AsyncPageable<VirtualNetworkResource> getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            await getAllVnetsAP.ToEnumerableAsync();
            vnet.AddressSpace.AddressPrefixes[0] = "10.1.0.0/16";
            vnet.Subnets[0].AddressPrefix = "10.1.1.0/24";
            vnet.Subnets[1].AddressPrefix = "10.1.2.0/24";
            var remoteVirtualNetworkOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, remoteVirtualNetworkName, vnet);
            Response<VirtualNetworkResource> remoteVirtualNetwork = await remoteVirtualNetworkOperation.WaitForCompletionAsync();;

            // Get Peerings in the vnet
            var virtualNetworkPeeringCollection = (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetVirtualNetworkPeerings();
            AsyncPageable<VirtualNetworkPeeringResource> listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            List<VirtualNetworkPeeringResource> listPeering = await listPeeringAP.ToEnumerableAsync();
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
            var putPeeringOperation = await virtualNetworkPeeringCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetPeeringName, peering);
            Response<VirtualNetworkPeeringResource> putPeering = await putPeeringOperation.WaitForCompletionAsync();;
            Assert.That(putPeering.Value.Data.ETag, Is.Not.Null);
            Assert.That(putPeering.Value.Data.Name, Is.EqualTo(vnetPeeringName));
            Assert.That(putPeering.Value.Data.RemoteVirtualNetwork.Id, Is.EqualTo(remoteVirtualNetwork.Value.Id));
            Assert.That(putPeering.Value.Data.AllowForwardedTraffic, Is.EqualTo(peering.AllowForwardedTraffic));
            Assert.That(putPeering.Value.Data.AllowVirtualNetworkAccess, Is.EqualTo(peering.AllowVirtualNetworkAccess));
            Assert.That(putPeering.Value.Data.UseRemoteGateways, Is.False);
            Assert.That(putPeering.Value.Data.AllowGatewayTransit, Is.False);
            Assert.That(putPeering.Value.Data.PeeringState, Is.EqualTo(VirtualNetworkPeeringState.Initiated));

            // get peering
            Response<VirtualNetworkPeeringResource> getPeering = await virtualNetworkPeeringCollection.GetAsync(vnetPeeringName);
            Assert.That(putPeering.Value.Data.ETag, Is.EqualTo(getPeering.Value.Data.ETag));
            Assert.That(getPeering.Value.Data.Name, Is.EqualTo(vnetPeeringName));
            Assert.That(getPeering.Value.Data.RemoteVirtualNetwork.Id, Is.EqualTo(remoteVirtualNetwork.Value.Id));
            Assert.That(getPeering.Value.Data.AllowForwardedTraffic, Is.EqualTo(peering.AllowForwardedTraffic));
            Assert.That(getPeering.Value.Data.AllowVirtualNetworkAccess, Is.EqualTo(peering.AllowVirtualNetworkAccess));
            Assert.That(getPeering.Value.Data.UseRemoteGateways, Is.False);
            Assert.That(getPeering.Value.Data.AllowGatewayTransit, Is.False);
            Assert.That(getPeering.Value.Data.PeeringState, Is.EqualTo(VirtualNetworkPeeringState.Initiated));

            // list peering
            listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeering);
            Assert.That(putPeering.Value.Data.ETag, Is.EqualTo(listPeering.ElementAt(0).Data.ETag));
            Assert.That(listPeering.ElementAt(0).Data.Name, Is.EqualTo(vnetPeeringName));
            Assert.That(listPeering.ElementAt(0).Data.RemoteVirtualNetwork.Id, Is.EqualTo(remoteVirtualNetwork.Value.Id));
            Assert.That(listPeering.ElementAt(0).Data.AllowForwardedTraffic, Is.EqualTo(peering.AllowForwardedTraffic));
            Assert.That(listPeering.ElementAt(0).Data.AllowVirtualNetworkAccess, Is.EqualTo(peering.AllowVirtualNetworkAccess));
            Assert.That(listPeering.ElementAt(0).Data.UseRemoteGateways, Is.False);
            Assert.That(listPeering.ElementAt(0).Data.AllowGatewayTransit, Is.False);
            Assert.That(listPeering.ElementAt(0).Data.PeeringState, Is.EqualTo(VirtualNetworkPeeringState.Initiated));

            // delete peering
            await getPeering.Value.DeleteAsync(WaitUntil.Completed);
            listPeeringAP = virtualNetworkPeeringCollection.GetAllAsync();
            listPeering = await listPeeringAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeering);

            // Delete Vnet
            await putVnetResponse.Value.DeleteAsync(WaitUntil.Completed);
            await remoteVirtualNetwork.Value.DeleteAsync(WaitUntil.Completed);

            // Get all Vnets
            getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            List<VirtualNetworkResource> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.IsEmpty(getAllVnets);
        }
    }
}
