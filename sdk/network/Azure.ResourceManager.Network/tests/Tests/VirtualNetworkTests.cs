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
    public class VirtualNetworkTests : NetworkTestsManagementClientBase
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task VirtualNetworkApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualNetworks");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string vnetName = Recording.GenerateAssetName("azsmnet");
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
            Assert.AreEqual("10.1.1.1", getVnetResponse.Value.DhcpOptions.DnsServers[0]);
            Assert.AreEqual("10.1.2.4", getVnetResponse.Value.DhcpOptions.DnsServers[1]);
            Assert.AreEqual("10.0.0.0/16", getVnetResponse.Value.AddressSpace.AddressPrefixes[0]);
            Assert.AreEqual(subnet1Name, getVnetResponse.Value.Subnets[0].Name);
            Assert.AreEqual(subnet2Name, getVnetResponse.Value.Subnets[1].Name);

            // Get all Vnets
            AsyncPageable<VirtualNetwork> getAllVnetsAP = NetworkManagementClient.VirtualNetworks.ListAsync(resourceGroupName);
            List<VirtualNetwork> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.AreEqual(vnetName, getAllVnets.ElementAt(0).Name);
            Assert.AreEqual("Succeeded", getAllVnets.ElementAt(0).ProvisioningState.ToString());
            Assert.AreEqual("10.0.0.0/16", getAllVnets.ElementAt(0).AddressSpace.AddressPrefixes[0]);
            Assert.AreEqual(subnet1Name, getAllVnets.ElementAt(0).Subnets[0].Name);
            Assert.AreEqual(subnet2Name, getAllVnets.ElementAt(0).Subnets[1].Name);

            // Get all Vnets in a subscription
            AsyncPageable<VirtualNetwork> getAllVnetInSubscriptionAP = NetworkManagementClient.VirtualNetworks.ListAllAsync();
            List<VirtualNetwork> getAllVnetInSubscription = await getAllVnetInSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getAllVnetInSubscription);

            // Delete Vnet
            VirtualNetworksDeleteOperation deleteOperation = await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
            await WaitForCompletionAsync(deleteOperation);

            // Get all Vnets
            getAllVnetsAP = NetworkManagementClient.VirtualNetworks.ListAsync(resourceGroupName);
            getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.IsEmpty(getAllVnets);
        }

        [Test]
        public async Task VirtualNetworkCheckIpAddressAvailabilityTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualNetworks");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

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
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.1.0/24" } }
            };

            // Put Vnet
            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            Assert.AreEqual("Succeeded", putVnetResponse.Value.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);

            // Check Ip Address availability API
            Response<IPAddressAvailabilityResult> responseAvailable = await NetworkManagementClient.VirtualNetworks.CheckIPAddressAvailabilityAsync(resourceGroupName, vnetName, "10.0.1.10");

            Assert.True(responseAvailable.Value.Available);
            Assert.Null(responseAvailable.Value.AvailableIPAddresses);

            Response<IPAddressAvailabilityResult> responseTaken = await NetworkManagementClient.VirtualNetworks.CheckIPAddressAvailabilityAsync(resourceGroupName, vnetName, "10.0.1.9");

            Assert.False(responseTaken.Value.Available);
            Assert.AreEqual(5, responseTaken.Value.AvailableIPAddresses.Count);

            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task VirtualNetworkPeeringTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualNetworks");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string vnet1Name = Recording.GenerateAssetName("azsmnet");
            string vnet2Name = Recording.GenerateAssetName("azsmnet");
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
                Subnets = new List<Subnet>() { new Subnet() { Name = subnet1Name, AddressPrefix = "10.0.1.0/24", }, new Subnet() { Name = subnet2Name, AddressPrefix = "10.0.2.0/24" } }
            };

            // Put Vnet
            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnet1Name, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            Assert.AreEqual("Succeeded", putVnetResponse.Value.ProvisioningState.ToString());

            // Get Vnet
            Response<VirtualNetwork> getVnetResponse = await NetworkManagementClient.VirtualNetworks.GetAsync(resourceGroupName, vnet1Name);
            Assert.AreEqual(vnet1Name, getVnetResponse.Value.Name);
            Assert.NotNull(getVnetResponse.Value.ResourceGuid);
            Assert.AreEqual("Succeeded", getVnetResponse.Value.ProvisioningState.ToString());

            // Create vnet2
            VirtualNetwork vnet2 = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.1.0.0/16", }
                },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnet1Name, AddressPrefix = "10.1.1.0/24" } }
            };

            // Put Vnet2
            VirtualNetworksCreateOrUpdateOperation putVnet2Operation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnet2Name, vnet2);
            Response<VirtualNetwork> putVnet2 = await WaitForCompletionAsync(putVnet2Operation);
            Assert.AreEqual("Succeeded", putVnet2.Value.ProvisioningState.ToString());

            // Create peering object
            var peering = new VirtualNetworkPeering()
            {
                AllowForwardedTraffic = true,
                RemoteVirtualNetwork = new SubResource { Id = putVnet2.Value.Id }
            };

            // Create Peering
            await NetworkManagementClient.VirtualNetworkPeerings.StartCreateOrUpdateAsync(resourceGroupName, vnet1Name, "peer1", peering);

            // Get Peering
            Response<VirtualNetworkPeering> getPeer = await NetworkManagementClient.VirtualNetworkPeerings.GetAsync(resourceGroupName, vnet1Name, "peer1");
            Assert.AreEqual("peer1", getPeer.Value.Name);
            Assert.True(getPeer.Value.AllowForwardedTraffic);
            Assert.True(getPeer.Value.AllowVirtualNetworkAccess);
            Assert.False(getPeer.Value.AllowGatewayTransit);
            Assert.NotNull(getPeer.Value.RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, getPeer.Value.RemoteVirtualNetwork.Id);

            // List Peering
            AsyncPageable<VirtualNetworkPeering> listPeerAP = NetworkManagementClient.VirtualNetworkPeerings.ListAsync(resourceGroupName, vnet1Name);
            List<VirtualNetworkPeering> listPeer = await listPeerAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeer);
            Assert.AreEqual("peer1", listPeer[0].Name);
            Assert.True(listPeer[0].AllowForwardedTraffic);
            Assert.True(listPeer[0].AllowVirtualNetworkAccess);
            Assert.False(listPeer[0].AllowGatewayTransit);
            Assert.NotNull(listPeer[0].RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, listPeer[0].RemoteVirtualNetwork.Id);

            // Get peering from GET vnet
            Response<VirtualNetwork> peeringVnet = await NetworkManagementClient.VirtualNetworks.GetAsync(resourceGroupName, vnet1Name);
            Assert.AreEqual(vnet1Name, peeringVnet.Value.Name);
            Has.One.EqualTo(peeringVnet.Value.VirtualNetworkPeerings);
            Assert.AreEqual("peer1", peeringVnet.Value.VirtualNetworkPeerings[0].Name);
            Assert.True(peeringVnet.Value.VirtualNetworkPeerings[0].AllowForwardedTraffic);
            Assert.True(peeringVnet.Value.VirtualNetworkPeerings[0].AllowVirtualNetworkAccess);
            Assert.False(peeringVnet.Value.VirtualNetworkPeerings[0].AllowGatewayTransit);
            Assert.NotNull(peeringVnet.Value.VirtualNetworkPeerings[0].RemoteVirtualNetwork);
            Assert.AreEqual(putVnet2.Value.Id, peeringVnet.Value.VirtualNetworkPeerings[0].RemoteVirtualNetwork.Id);

            // Delete Peering
            VirtualNetworkPeeringsDeleteOperation deleteOperation = await NetworkManagementClient.VirtualNetworkPeerings.StartDeleteAsync(resourceGroupName, vnet1Name, "peer1");
            await WaitForCompletionAsync(deleteOperation);

            listPeerAP = NetworkManagementClient.VirtualNetworkPeerings.ListAsync(resourceGroupName, vnet1Name);
            listPeer = await listPeerAP.ToEnumerableAsync();
            Assert.IsEmpty(listPeer);

            peeringVnet = await NetworkManagementClient.VirtualNetworks.GetAsync(resourceGroupName, vnet1Name);
            Assert.AreEqual(vnet1Name, peeringVnet.Value.Name);
            Assert.IsEmpty(peeringVnet.Value.VirtualNetworkPeerings);

            // Delete Vnets
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnet1Name);
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnet2Name);
        }

        [Test]
        public async Task VirtualNetworkUsageTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualNetworks");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

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
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.1.0/24" } }
            };

            // Put Vnet
            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            Assert.AreEqual("Succeeded", putVnetResponse.Value.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Get Vnet usage
            AsyncPageable<VirtualNetworkUsage> listUsageResponseAP = NetworkManagementClient.VirtualNetworks.ListUsageAsync(resourceGroupName, vnetName);
            List<VirtualNetworkUsage> listUsageResponse = await listUsageResponseAP.ToEnumerableAsync();
            Assert.AreEqual(0.0, listUsageResponse[0].CurrentValue);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            // Get Vnet usage again
            listUsageResponseAP = NetworkManagementClient.VirtualNetworks.ListUsageAsync(resourceGroupName, vnetName);
            listUsageResponse = await listUsageResponseAP.ToEnumerableAsync();
            Assert.AreEqual(1.0, listUsageResponse[0].CurrentValue);

            // Delete Vnet and Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }
    }
}
