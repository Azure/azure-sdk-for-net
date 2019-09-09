// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Xunit;

namespace Networks.Tests
{
    using System;

    public class TestHelper
    {
        public static ExpressRouteCircuit CreateDefaultExpressRouteCircuit(string resourceGroupName, string circuitName, string location,
            NetworkManagementClient nrpClient)
        {
            ExpressRouteCircuitSku sku = new ExpressRouteCircuitSku
            {
                Name = "Premium_MeteredData",
                Tier = "Premium",
                Family = "MeteredData"
            };

            ExpressRouteCircuitServiceProviderProperties provider = new ExpressRouteCircuitServiceProviderProperties
            {
                BandwidthInMbps = Convert.ToInt32(ExpressRouteTests.Circuit_BW),
                PeeringLocation = ExpressRouteTests.Circuit_Location,
                ServiceProviderName = ExpressRouteTests.Circuit_Provider
            };

            var circuit = new ExpressRouteCircuit()
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    } ,
                Sku = sku,
                ServiceProviderProperties = provider
            };

            // Put circuit
            var circuitResponse = nrpClient.ExpressRouteCircuits.CreateOrUpdate(resourceGroupName, circuitName, circuit);
            Assert.Equal("Succeeded", circuitResponse.ProvisioningState);
            var getCircuitResponse = nrpClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static ExpressRouteCircuit UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName,
            NetworkManagementClient nrpClient)
        {
                var peering = new ExpressRouteCircuitPeering()
                {
                    Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                    PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                    PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                    VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                    PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                    SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                    MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                    {
                        AdvertisedPublicPrefixes = new List<string>
                    {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                        LegacyMode = Convert.ToInt32(true)
                    },
                };

            var peerResponse = nrpClient.ExpressRouteCircuitPeerings.CreateOrUpdate(resourceGroupName, circuitName, 
                ExpressRouteTests.Peering_Microsoft, peering);
            Assert.Equal("Succeeded", peerResponse.ProvisioningState);
            var getCircuitResponse = nrpClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static ExpressRouteCircuit UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(string resourceGroupName, string circuitName,
            NetworkManagementClient nrpClient)
        {
            var ipv6Peering = new Ipv6ExpressRouteCircuitPeeringConfig()
            {
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix_V6,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix_V6,
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = new List<string>
                    {
                        ExpressRouteTests.MS_PublicPrefix_V6
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
            };

            var peering = new ExpressRouteCircuitPeering()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                Ipv6PeeringConfig = ipv6Peering
            };

            var peerResponse = nrpClient.ExpressRouteCircuitPeerings.CreateOrUpdate(resourceGroupName, circuitName,
                ExpressRouteTests.Peering_Microsoft, peering);
            Assert.Equal("Succeeded", peerResponse.ProvisioningState);
            var getCircuitResponse = nrpClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static ExpressRouteCircuit UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName, RouteFilter filter,
            NetworkManagementClient nrpClient)
        {

            var peering = new ExpressRouteCircuitPeering()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = new List<string>
                    {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
                RouteFilter = { Id = filter.Id }
            };

            var peerResponse = nrpClient.ExpressRouteCircuitPeerings.CreateOrUpdate(resourceGroupName, circuitName,
                ExpressRouteTests.Peering_Microsoft, peering);
            Assert.Equal("Succeeded", peerResponse.ProvisioningState);
            var getCircuitResponse = nrpClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

            return getCircuitResponse;
        }


        public static RouteFilter CreateDefaultRouteFilter(string resourceGroupName, string filterName, string location, 
            NetworkManagementClient nrpClient, bool containsRule = false)
        {
            var filter = new RouteFilter()
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    }
            };

            if (containsRule)
            {
                var rule = new RouteFilterRule()
                {
                    Name = "test",
                    Access = ExpressRouteTests.Filter_Access,
                    Communities = new List<string> { ExpressRouteTests.Filter_Commmunity },
                    Location = location
                };

                var rules = new List<RouteFilterRule>();
                rules.Add(rule);
                filter.Rules = rules;                
            }

            // Put route filter 
            var filterResponse = nrpClient.RouteFilters.CreateOrUpdate(resourceGroupName, filterName, filter);
            Assert.Equal("Succeeded", filterResponse.ProvisioningState);
            var getFilterResponse = nrpClient.RouteFilters.Get(resourceGroupName, filterName);

            return getFilterResponse;
        }

        public static RouteFilter CreateDefaultRouteFilterRule(string resourceGroupName, string filterName, string ruleName, string location,
            NetworkManagementClient nrpClient)
        {
            var rule = new RouteFilterRule()
            {
                Access = ExpressRouteTests.Filter_Access,
                Communities = new List<string> { ExpressRouteTests.Filter_Commmunity },
                Location = location
            };                      

            // Put route filter rule
            var ruleResponse = nrpClient.RouteFilterRules.CreateOrUpdate(resourceGroupName, filterName, ruleName, rule);
            Assert.Equal("Succeeded", ruleResponse.ProvisioningState);
            var getFilterResponse = nrpClient.RouteFilters.Get(resourceGroupName, filterName);

            return getFilterResponse;
        }

        public static PublicIPAddress CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location,
            NetworkManagementClient nrpClient)
        {
            var publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put nic1PublicIpAddress
            var putPublicIpAddressResponse = nrpClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, name, publicIp);
            Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);
            var getPublicIpAddressResponse = nrpClient.PublicIPAddresses.Get(resourceGroupName, name);

            return getPublicIpAddressResponse;
        }

        public static NetworkInterface CreateNetworkInterface(
            string name,
            string resourceGroupName,
            string publicIpAddressId,
            string subnetId,
            string location,
            string ipConfigName,
            NetworkManagementClient client)
        {
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
                         PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                         
                         Subnet = new Subnet()
                         {
                             Id = subnetId
                         }
                    }
                }
            };

            if (!String.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new PublicIPAddress() { Id = publicIpAddressId };
            }

            // Test NIC apis
            var putNicResponse = client.NetworkInterfaces.CreateOrUpdate(resourceGroupName, name, nicParameters);
            
            var getNicResponse = client.NetworkInterfaces.Get(resourceGroupName, name);
            Assert.Equal(getNicResponse.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.IpConfigurations[0].Primary);

            Assert.Equal("Succeeded", getNicResponse.ProvisioningState);

            return getNicResponse;
        }

        public static VirtualNetwork CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location, NetworkManagementClient client)
        {
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
                                AddressPrefix = "10.0.0.0/24",
                            }
                        }
            };

            client.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
            var getVnetResponse = client.VirtualNetworks.Get(resourceGroupName, vnetName);

            return getVnetResponse;
        }

        public static string GetChildLbResourceId(
            string subscriptionId,
            string resourceGroupName,
            string lbname,
            string childResourceType,
            string childResourceName)
        {
            return
                String.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName);
        }
    }
}

