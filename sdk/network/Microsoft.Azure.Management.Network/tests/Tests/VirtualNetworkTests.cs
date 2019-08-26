// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class VirtualNetworkTests
    {
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string subnet1Name = TestUtilities.GenerateName();
                string subnet2Name = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = "10.0.1.0/24",
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = "10.0.2.0/24",
                        }
                    }
                };

                // Put Vnet
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                // Get Vnet
                var getVnetResponse = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                Assert.Equal(vnetName, getVnetResponse.Name);
                Assert.NotNull(getVnetResponse.ResourceGuid);
                Assert.Equal("Succeeded", getVnetResponse.ProvisioningState);
                Assert.Equal("10.1.1.1", getVnetResponse.DhcpOptions.DnsServers[0]);
                Assert.Equal("10.1.2.4", getVnetResponse.DhcpOptions.DnsServers[1]);
                Assert.Equal("10.0.0.0/16", getVnetResponse.AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getVnetResponse.Subnets[0].Name);
                Assert.Equal(subnet2Name, getVnetResponse.Subnets[1].Name);

                // Get all Vnets
                var getAllVnets = networkManagementClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(vnetName, getAllVnets.ElementAt(0).Name);
                Assert.Equal("Succeeded", getAllVnets.ElementAt(0).ProvisioningState);
                Assert.Equal("10.0.0.0/16", getAllVnets.ElementAt(0).AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getAllVnets.ElementAt(0).Subnets[0].Name);
                Assert.Equal(subnet2Name, getAllVnets.ElementAt(0).Subnets[1].Name);

                // Get all Vnets in a subscription
                var getAllVnetInSubscription = networkManagementClient.VirtualNetworks.ListAll();
                Assert.NotEmpty(getAllVnetInSubscription);

                // Delete Vnet
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                
                // Get all Vnets
                getAllVnets = networkManagementClient.VirtualNetworks.List(resourceGroupName);
                Assert.Empty(getAllVnets);
            }
        }

        [Fact(Skip="Disable tests")]
        public void VirtualNetworkCheckIpAddressAvailabilityTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.1.0/24",
                        },
                    }
                };

                // Put Vnet
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                    {
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Static,
                             PrivateIPAddress = "10.0.1.9",
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                // Check Ip Address availability API
                var responseAvailable = networkManagementClient.VirtualNetworks.CheckIPAddressAvailability(resourceGroupName, vnetName, "10.0.1.10");

                Assert.True(responseAvailable.Available);
                Assert.Null(responseAvailable.AvailableIPAddresses);

                var responseTaken = networkManagementClient.VirtualNetworks.CheckIPAddressAvailability(resourceGroupName, vnetName, "10.0.1.9");

                Assert.False(responseTaken.Available);
                Assert.Equal(5, responseTaken.AvailableIPAddresses.Count);

                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void VirtualNetworkPeeringTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnet1Name = TestUtilities.GenerateName();
                string vnet2Name = TestUtilities.GenerateName();
                string subnet1Name = TestUtilities.GenerateName();
                string subnet2Name = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = "10.0.1.0/24",
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = "10.0.2.0/24",
                        }
                    }
                };

                // Put Vnet
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnet1Name, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                // Get Vnet
                var getVnetResponse = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnet1Name);
                Assert.Equal(vnet1Name, getVnetResponse.Name);
                Assert.NotNull(getVnetResponse.ResourceGuid);
                Assert.Equal("Succeeded", getVnetResponse.ProvisioningState);

                // Create vnet2
                var vnet2 = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.1.0.0/16",
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = "10.1.1.0/24",
                        }
                    }
                };

                // Put Vnet2
                var putVnet2 = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnet2Name, vnet2);
                Assert.Equal("Succeeded", putVnet2.ProvisioningState);

                // Create peering object
                var peering = new VirtualNetworkPeering()
                {
                    AllowForwardedTraffic = true,
                    RemoteVirtualNetwork = new Microsoft.Azure.Management.Network.Models.SubResource
                    {
                        Id = putVnet2.Id
                    }
                };

                // Create Peering
                networkManagementClient.VirtualNetworkPeerings.CreateOrUpdate(resourceGroupName, vnet1Name, "peer1", peering);

                // Get Peering
                var getPeer = networkManagementClient.VirtualNetworkPeerings.Get(resourceGroupName, vnet1Name, "peer1");
                Assert.Equal("peer1", getPeer.Name);
                Assert.True(getPeer.AllowForwardedTraffic);
                Assert.True(getPeer.AllowVirtualNetworkAccess);
                Assert.False(getPeer.AllowGatewayTransit);
                Assert.NotNull(getPeer.RemoteVirtualNetwork);
                Assert.Equal(putVnet2.Id, getPeer.RemoteVirtualNetwork.Id);

                // List Peering
                var listPeer = networkManagementClient.VirtualNetworkPeerings.List(resourceGroupName, vnet1Name).ToList();
                Assert.Single(listPeer);
                Assert.Equal("peer1", listPeer[0].Name);
                Assert.True(listPeer[0].AllowForwardedTraffic);
                Assert.True(listPeer[0].AllowVirtualNetworkAccess);
                Assert.False(listPeer[0].AllowGatewayTransit);
                Assert.NotNull(listPeer[0].RemoteVirtualNetwork);
                Assert.Equal(putVnet2.Id, listPeer[0].RemoteVirtualNetwork.Id);

                // Get peering from GET vnet
                var peeringVnet = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnet1Name);
                Assert.Equal(vnet1Name, peeringVnet.Name);
                Assert.Single(peeringVnet.VirtualNetworkPeerings);
                Assert.Equal("peer1", peeringVnet.VirtualNetworkPeerings[0].Name);
                Assert.True(peeringVnet.VirtualNetworkPeerings[0].AllowForwardedTraffic);
                Assert.True(peeringVnet.VirtualNetworkPeerings[0].AllowVirtualNetworkAccess);
                Assert.False(peeringVnet.VirtualNetworkPeerings[0].AllowGatewayTransit);
                Assert.NotNull(peeringVnet.VirtualNetworkPeerings[0].RemoteVirtualNetwork);
                Assert.Equal(putVnet2.Id, peeringVnet.VirtualNetworkPeerings[0].RemoteVirtualNetwork.Id);

                // Delete Peering
                networkManagementClient.VirtualNetworkPeerings.Delete(resourceGroupName, vnet1Name, "peer1");

                listPeer = networkManagementClient.VirtualNetworkPeerings.List(resourceGroupName, vnet1Name).ToList();
                Assert.Empty(listPeer);

                peeringVnet = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnet1Name);
                Assert.Equal(vnet1Name, peeringVnet.Name);
                Assert.Empty(peeringVnet.VirtualNetworkPeerings);

                // Delete Vnets
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnet1Name);
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnet2Name);
            }
        }

        [Fact(Skip="Disable tests")]
        public void VirtualNetworkUsageTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.1.0/24",
                        },
                    }
                };

                // Put Vnet
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Get Vnet usage
                var listUsageResponse = networkManagementClient.VirtualNetworks.ListUsage(resourceGroupName, vnetName).ToList();
                Assert.Equal(0.0, listUsageResponse[0].CurrentValue);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                    {
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Static,
                             PrivateIPAddress = "10.0.1.9",
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                // Get Vnet usage again
                listUsageResponse = networkManagementClient.VirtualNetworks.ListUsage(resourceGroupName, vnetName).ToList();
                Assert.Equal(1.0, listUsageResponse[0].CurrentValue);

                // Delete Vnet and Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }
    }
}

