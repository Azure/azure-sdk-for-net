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
    public class VirtualNetworkTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public VirtualNetworkTests(bool isAsync) : base(isAsync)
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
            Assert.Multiple(() =>
            {
                Assert.That(getVnetResponse.Value.Data.Name, Is.EqualTo(vnetName));
                Assert.That(getVnetResponse.Value.Data.ResourceGuid, Is.Not.Null);
                Assert.That(getVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
                Assert.That(getVnetResponse.Value.Data.DhcpOptions.DnsServers[0], Is.EqualTo("10.1.1.1"));
                Assert.That(getVnetResponse.Value.Data.DhcpOptions.DnsServers[1], Is.EqualTo("10.1.2.4"));
                Assert.That(getVnetResponse.Value.Data.AddressSpace.AddressPrefixes[0], Is.EqualTo("10.0.0.0/16"));
                Assert.That(getVnetResponse.Value.Data.Subnets[0].Name, Is.EqualTo(subnet1Name));
                Assert.That(getVnetResponse.Value.Data.Subnets[1].Name, Is.EqualTo(subnet2Name));
            });

            // Get all Vnets
            AsyncPageable<VirtualNetworkResource> getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            List<VirtualNetworkResource> getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.Multiple(() =>
            {
                Assert.That(getAllVnets.ElementAt(0).Data.Name, Is.EqualTo(vnetName));
                Assert.That(getAllVnets.ElementAt(0).Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            });
            Assert.AreEqual("10.0.0.0/16", getAllVnets.ElementAt(0).Data.AddressSpace.AddressPrefixes[0]);
            Assert.Multiple(() =>
            {
                Assert.That(getAllVnets.ElementAt(0).Data.Subnets[0].Name, Is.EqualTo(subnet1Name));
                Assert.That(getAllVnets.ElementAt(0).Data.Subnets[1].Name, Is.EqualTo(subnet2Name));
            });

            // Get all Vnets in a subscription
            AsyncPageable<VirtualNetworkResource> getAllVnetInSubscriptionAP = _subscription.GetVirtualNetworksAsync();
            List<VirtualNetworkResource> getAllVnetInSubscription = await getAllVnetInSubscriptionAP.ToEnumerableAsync();
            Assert.That(getAllVnetInSubscription, Is.Not.Empty);

            // Delete Vnet
            var deleteOperation = await getVnetResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get all Vnets
            getAllVnetsAP = virtualNetworkCollection.GetAllAsync();
            getAllVnets = await getAllVnetsAP.ToEnumerableAsync();
            Assert.That(getAllVnets, Is.Empty);
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

                AddressSpace = new VirtualNetworkAddressSpace()
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
            var virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.That(putVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            Response<SubnetResource> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IPConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new SubnetData()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var putNicResponseOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, nicName, nicParameters);
            await putNicResponseOperation.WaitForCompletionAsync();;

            // Check Ip Address availability API
            Response<IPAddressAvailabilityResult> responseAvailable = await putVnetResponse.Value.CheckIPAddressAvailabilityAsync("10.0.1.10");

            Assert.Multiple(() =>
            {
                Assert.That(responseAvailable.Value.Available, Is.True);
                Assert.That(responseAvailable.Value.AvailableIPAddresses, Is.Empty);
            });

            Response<IPAddressAvailabilityResult> responseTaken = await putVnetResponse.Value.CheckIPAddressAvailabilityAsync("10.0.1.9");

            Assert.Multiple(() =>
            {
                Assert.That(responseTaken.Value.Available, Is.False);
                Assert.That(responseTaken.Value.AvailableIPAddresses, Has.Count.EqualTo(5));
            });

            await putNicResponseOperation.Value.DeleteAsync(WaitUntil.Completed);
            await putVnetResponse.Value.DeleteAsync(WaitUntil.Completed);
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

                AddressSpace = new VirtualNetworkAddressSpace()
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
            var virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnet1Name, vnet);
            Response<VirtualNetworkResource> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.That(putVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get Vnet
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnet1Name);
            Assert.Multiple(() =>
            {
                Assert.That(getVnetResponse.Value.Data.Name, Is.EqualTo(vnet1Name));
                Assert.That(getVnetResponse.Value.Data.ResourceGuid, Is.Not.Null);
                Assert.That(getVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            });

            // Create vnet2
            var vnet2 = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.1.0.0/16", }
                },
                Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.1.1.0/24" } }
            };

            // Put Vnet2
            var putVnet2Operation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnet2Name, vnet2);
            Response<VirtualNetworkResource> putVnet2 = await putVnet2Operation.WaitForCompletionAsync();;
            Assert.That(putVnet2.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Create peering object
            var peering = new VirtualNetworkPeeringData()
            {
                AllowForwardedTraffic = true,
                RemoteVirtualNetwork = new WritableSubResource { Id = putVnet2.Value.Id }
            };

            // Create Peering
            var virtualNetworkPeeringCollection = getVnetResponse.Value.GetVirtualNetworkPeerings();
            await virtualNetworkPeeringCollection.CreateOrUpdateAsync(WaitUntil.Completed, "peer1", peering);

            // Get Peering
            VirtualNetworkPeeringResource getPeer = await virtualNetworkPeeringCollection.GetAsync("peer1");
            Assert.Multiple(() =>
            {
                Assert.That(getPeer.Data.Name, Is.EqualTo("peer1"));
                Assert.That(getPeer.Data.AllowForwardedTraffic, Is.True);
                Assert.That(getPeer.Data.AllowVirtualNetworkAccess, Is.True);
                Assert.That(getPeer.Data.AllowGatewayTransit, Is.False);
                Assert.That(getPeer.Data.RemoteVirtualNetwork, Is.Not.Null);
            });
            Assert.That(getPeer.Data.RemoteVirtualNetwork.Id, Is.EqualTo(putVnet2.Value.Id));

            // List Peering
            AsyncPageable<VirtualNetworkPeeringResource> listPeerAP = virtualNetworkPeeringCollection.GetAllAsync();
            List<VirtualNetworkPeeringResource> listPeer = await listPeerAP.ToEnumerableAsync();
            Has.One.EqualTo(listPeer);
            Assert.Multiple(() =>
            {
                Assert.That(listPeer[0].Data.Name, Is.EqualTo("peer1"));
                Assert.That(listPeer[0].Data.AllowForwardedTraffic, Is.True);
                Assert.That(listPeer[0].Data.AllowVirtualNetworkAccess, Is.True);
                Assert.That(listPeer[0].Data.AllowGatewayTransit, Is.False);
                Assert.That(listPeer[0].Data.RemoteVirtualNetwork, Is.Not.Null);
            });
            Assert.That(listPeer[0].Data.RemoteVirtualNetwork.Id, Is.EqualTo(putVnet2.Value.Id));

            // Get peering from GET vnet
            VirtualNetworkResource peeringVnet = await virtualNetworkCollection.GetAsync(vnet1Name);
            Assert.That(peeringVnet.Data.Name, Is.EqualTo(vnet1Name));
            Has.One.EqualTo(peeringVnet.Data.VirtualNetworkPeerings);
            Assert.Multiple(() =>
            {
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].Name, Is.EqualTo("peer1"));
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].AllowForwardedTraffic, Is.True);
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].AllowVirtualNetworkAccess, Is.True);
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].AllowGatewayTransit, Is.False);
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].RemoteVirtualNetwork, Is.Not.Null);
            });
            Assert.That(peeringVnet.Data.VirtualNetworkPeerings[0].RemoteVirtualNetwork.Id, Is.EqualTo(putVnet2.Value.Id));

            // Delete Peering
            var deleteOperation = await getPeer.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            listPeerAP = virtualNetworkPeeringCollection.GetAllAsync();
            listPeer = await listPeerAP.ToEnumerableAsync();
            Assert.That(listPeer, Is.Empty);

            peeringVnet = await virtualNetworkCollection.GetAsync(vnet1Name);
            Assert.Multiple(() =>
            {
                Assert.That(peeringVnet.Data.Name, Is.EqualTo(vnet1Name));
                Assert.That(peeringVnet.Data.VirtualNetworkPeerings, Is.Empty);
            });

            // Delete Vnets
            await putVnet2.Value.DeleteAsync(WaitUntil.Completed);
            await putVnetResponse.Value.DeleteAsync(WaitUntil.Completed);
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
                AddressSpace = new VirtualNetworkAddressSpace()
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
            var virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.That(putVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            Response<SubnetResource> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);

            // Get Vnet usage
            var usage = await putVnetResponse.Value.GetUsageAsync().ToEnumerableAsync();
            Assert.That(usage[0].CurrentValue, Is.EqualTo(0.0));

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IPConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.1.9",
                        Subnet = new SubnetData()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            var putNicResponseOperation = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nicName, nicParameters);
            var nicResponse = await putNicResponseOperation.WaitForCompletionAsync();;

            // Get Vnet usage again
            usage = await putVnetResponse.Value.GetUsageAsync().ToEnumerableAsync();
            Assert.That(usage[0].CurrentValue, Is.EqualTo(1.0));

            // Delete Vnet and Nic
            await nicResponse.Value.DeleteAsync(WaitUntil.Completed);
            await putVnetResponse.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
