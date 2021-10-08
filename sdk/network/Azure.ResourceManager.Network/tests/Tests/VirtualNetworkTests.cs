// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class VirtualNetworkTests : NetworkServiceClientTestBase
    {
        public VirtualNetworkTests(bool isAsync) : base(isAsync)
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

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string vnetName = Recording.GenerateAssetName("azsmnet");
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
            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            // Get Vnet
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkContainer.GetAsync(vnetName);
            Assert.AreEqual(vnetName, getVnetResponse.Value.Data.Name);
            Assert.NotNull(getVnetResponse.Value.Data.ResourceGuid);
            Assert.AreEqual("Succeeded", getVnetResponse.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual("10.1.1.1", getVnetResponse.Value.Data.DhcpOptions.DnsServers[0]);
            Assert.AreEqual("10.1.2.4", getVnetResponse.Value.Data.DhcpOptions.DnsServers[1]);
            Assert.AreEqual("10.0.0.0/16", getVnetResponse.Value.Data.AddressSpace.AddressPrefixes[0]);
            Assert.AreEqual(subnet1Name, getVnetResponse.Value.Data.Subnets[0].Name);
            Assert.AreEqual(subnet2Name, getVnetResponse.Value.Data.Subnets[1].Name);

            // Get all Vnets
            AsyncPageable<VirtualNetwork> getAllVnetsAP = virtualNetworkContainer.GetAllAsync();
            List<VirtualNetwork> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.AreEqual(vnetName, getAllVnets.ElementAt(0).Data.Name);
            Assert.AreEqual("Succeeded", getAllVnets.ElementAt(0).Data.ProvisioningState.ToString());
            Assert.AreEqual("10.0.0.0/16", getAllVnets.ElementAt(0).Data.AddressSpace.AddressPrefixes[0]);
            Assert.AreEqual(subnet1Name, getAllVnets.ElementAt(0).Data.Subnets[0].Name);
            Assert.AreEqual(subnet2Name, getAllVnets.ElementAt(0).Data.Subnets[1].Name);

            // Get all Vnets in a subscription
            AsyncPageable<VirtualNetwork> getAllVnetInSubscriptionAP = ArmClient.DefaultSubscription.GetVirtualNetworksAsync();
            List<VirtualNetwork> getAllVnetInSubscription = await getAllVnetInSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getAllVnetInSubscription);

            // Delete Vnet
            var deleteOperation = await getVnetResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get all Vnets
            getAllVnetsAP = virtualNetworkContainer.GetAllAsync();
            getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.IsEmpty(getAllVnets);
        }

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkCheckIpAddressAvailabilityTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

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
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.1.0/24" } }
            };

            // Put Vnet
            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IpConfigurations = {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new SubnetData()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var putNicResponseOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(nicName, nicParameters);
            await putNicResponseOperation.WaitForCompletionAsync();;

            // Check Ip Address availability API
            Response<IPAddressAvailabilityResult> responseAvailable = await putVnetResponse.Value.CheckIPAddressAvailabilityAsync("10.0.1.10");

            Assert.True(responseAvailable.Value.Available);
            Assert.IsEmpty(responseAvailable.Value.AvailableIPAddresses);

            Response<IPAddressAvailabilityResult> responseTaken = await putVnetResponse.Value.CheckIPAddressAvailabilityAsync("10.0.1.9");

            Assert.False(responseTaken.Value.Available);
            Assert.AreEqual(5, responseTaken.Value.AvailableIPAddresses.Count);

            await putNicResponseOperation.Value.DeleteAsync();
            await putVnetResponse.Value.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkPeeringTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string vnet1Name = Recording.GenerateAssetName("azsmnet");
            string vnet2Name = Recording.GenerateAssetName("azsmnet");
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
                Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.0.1.0/24", }, new SubnetData() { Name = subnet2Name, AddressPrefix = "10.0.2.0/24" } }
            };

            // Put Vnet
            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnet1Name, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            // Get Vnet
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkContainer.GetAsync(vnet1Name);
            Assert.AreEqual(vnet1Name, getVnetResponse.Value.Data.Name);
            Assert.NotNull(getVnetResponse.Value.Data.ResourceGuid);
            Assert.AreEqual("Succeeded", getVnetResponse.Value.Data.ProvisioningState.ToString());

            // Create vnet2
            var vnet2 = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.1.0.0/16", }
                },
                Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.1.1.0/24" } }
            };

            // Put Vnet2
            var putVnet2Operation = await virtualNetworkContainer.CreateOrUpdateAsync(vnet2Name, vnet2);
            Response<VirtualNetwork> putVnet2 = await putVnet2Operation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnet2.Value.Data.ProvisioningState.ToString());

            // Create peering object
            var peering = new VirtualNetworkPeeringData()
            {
                AllowForwardedTraffic = true,
                RemoteVirtualNetwork = new WritableSubResource { Id = putVnet2.Value.Id }
            };

            // Create Peering
            var virtualNetworkPeeringContainer = getVnetResponse.Value.GetVirtualNetworkPeerings();
            await virtualNetworkPeeringContainer.CreateOrUpdateAsync("peer1", peering);

            // Get Peering
            VirtualNetworkPeering getPeer = await virtualNetworkPeeringContainer.GetAsync("peer1");
            Assert.AreEqual("peer1", getPeer.Data.Name);
            Assert.True(getPeer.Data.AllowForwardedTraffic);
            Assert.True(getPeer.Data.AllowVirtualNetworkAccess);
            Assert.False(getPeer.Data.AllowGatewayTransit);
            Assert.NotNull(getPeer.Data.RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, getPeer.Data.RemoteVirtualNetwork.Id);

            // List Peering
            AsyncPageable<VirtualNetworkPeering> listPeerAP = virtualNetworkPeeringContainer.GetAllAsync();
            List<VirtualNetworkPeering> listPeer = await listPeerAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeer);
            Assert.AreEqual("peer1", listPeer[0].Data.Name);
            Assert.True(listPeer[0].Data.AllowForwardedTraffic);
            Assert.True(listPeer[0].Data.AllowVirtualNetworkAccess);
            Assert.False(listPeer[0].Data.AllowGatewayTransit);
            Assert.NotNull(listPeer[0].Data.RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, listPeer[0].Data.RemoteVirtualNetwork.Id);

            // Get peering from GET vnet
            VirtualNetwork peeringVnet = await virtualNetworkContainer.GetAsync(vnet1Name);
            Assert.AreEqual(vnet1Name, peeringVnet.Data.Name);
            Has.One.EqualTo(peeringVnet.Data.VirtualNetworkPeerings);
            Assert.AreEqual("peer1", peeringVnet.Data.VirtualNetworkPeerings[0].Name);
            Assert.True(peeringVnet.Data.VirtualNetworkPeerings[0].AllowForwardedTraffic);
            Assert.True(peeringVnet.Data.VirtualNetworkPeerings[0].AllowVirtualNetworkAccess);
            Assert.False(peeringVnet.Data.VirtualNetworkPeerings[0].AllowGatewayTransit);
            Assert.NotNull(peeringVnet.Data.VirtualNetworkPeerings[0].RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, peeringVnet.Data.VirtualNetworkPeerings[0].RemoteVirtualNetwork.Id);

            // Delete Peering
            var deleteOperation = await getPeer.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            listPeerAP = virtualNetworkPeeringContainer.GetAllAsync();
            listPeer = await listPeerAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeer);

            peeringVnet = await virtualNetworkContainer.GetAsync(vnet1Name);
            Assert.AreEqual(vnet1Name, peeringVnet.Data.Name);
            Assert.IsEmpty(peeringVnet.Data.VirtualNetworkPeerings);

            // Delete Vnets
            await putVnet2.Value.DeleteAsync();
            await putVnetResponse.Value.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkUsageTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

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
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.1.0/24" } }
            };

            // Put Vnet
            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);

            // Get Vnet usage
            var usage = await putVnetResponse.Value.GetUsageAsync().ToEnumerableAsync();
            Assert.AreEqual(0.0, usage[0].CurrentValue);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IpConfigurations = {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new SubnetData()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();
            var putNicResponseOperation = await networkInterfaceContainer.CreateOrUpdateAsync(nicName, nicParameters);
            var nicResponse = await putNicResponseOperation.WaitForCompletionAsync();;

            // Get Vnet usage again
            usage = await putVnetResponse.Value.GetUsageAsync().ToEnumerableAsync();
            Assert.AreEqual(1.0, usage[0].CurrentValue);

            // Delete Vnet and Nic
            await nicResponse.Value.DeleteAsync();
            await putVnetResponse.Value.DeleteAsync();
        }
    }
}
