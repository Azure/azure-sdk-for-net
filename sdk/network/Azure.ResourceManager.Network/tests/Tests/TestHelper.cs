// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class TestHelper
    {
        public static async Task<ExpressRouteCircuit> CreateDefaultExpressRouteCircuit(string resourceGroupName, string circuitName, string location,
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

            ExpressRouteCircuit circuit = new ExpressRouteCircuit()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                Sku = sku,
                ServiceProviderProperties = provider
            };

            // Put circuit
            Operation<ExpressRouteCircuit> circuitOperation = await nrpClient.ExpressRouteCircuits.StartCreateOrUpdateAsync(resourceGroupName, circuitName, circuit);
            Response<ExpressRouteCircuit> circuitResponse = await circuitOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", circuitResponse.Value.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await nrpClient.ExpressRouteCircuits.GetAsync(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName,
            NetworkManagementClient nrpClient)
        {
            ExpressRouteCircuitPeering peering = new ExpressRouteCircuitPeering()
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

            Operation<ExpressRouteCircuitPeering> peerOperation = await nrpClient.ExpressRouteCircuitPeerings.StartCreateOrUpdateAsync(resourceGroupName, circuitName, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await nrpClient.ExpressRouteCircuits.GetAsync(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(string resourceGroupName, string circuitName,
            NetworkManagementClient nrpClient)
        {
            Ipv6ExpressRouteCircuitPeeringConfig ipv6Peering = new Ipv6ExpressRouteCircuitPeeringConfig()
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

            ExpressRouteCircuitPeering peering = new ExpressRouteCircuitPeering()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                Ipv6PeeringConfig = ipv6Peering
            };

            Operation<ExpressRouteCircuitPeering> peerOperation = await nrpClient.ExpressRouteCircuitPeerings.StartCreateOrUpdateAsync(resourceGroupName, circuitName, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await nrpClient.ExpressRouteCircuits.GetAsync(resourceGroupName, circuitName);

            return getCircuitResponse;
        }

        public static async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName,
            RouteFilter filter, NetworkManagementClient nrpClient)
        {

            ExpressRouteCircuitPeering peering = new ExpressRouteCircuitPeering()
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

            Operation<ExpressRouteCircuitPeering> peerOperation = await nrpClient.ExpressRouteCircuitPeerings.StartCreateOrUpdateAsync(resourceGroupName, circuitName, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await nrpClient.ExpressRouteCircuits.GetAsync(resourceGroupName, circuitName);

            return getCircuitResponse;
        }


        public static async Task<RouteFilter> CreateDefaultRouteFilter(string resourceGroupName, string filterName, string location,
            NetworkManagementClient nrpClient, bool containsRule = false)
        {
            var filter = new RouteFilter()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } }
            };

            if (containsRule)
            {
                RouteFilterRule rule = new RouteFilterRule()
                {
                    Name = "test",
                    Access = ExpressRouteTests.Filter_Access,
                    Communities = new List<string> { ExpressRouteTests.Filter_Commmunity },
                    Location = location
                };

                List<RouteFilterRule> rules = new List<RouteFilterRule> { rule };
                filter.Rules = rules;
            }

            // Put route filter
            Operation<RouteFilter> filterOperatopn = await nrpClient.RouteFilters.StartCreateOrUpdateAsync(resourceGroupName, filterName, filter);
            Response<RouteFilter> filterResponse = await filterOperatopn.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", filterResponse.Value.ProvisioningState.ToString());
            Response<RouteFilter> getFilterResponse = await nrpClient.RouteFilters.GetAsync(resourceGroupName, filterName);

            return getFilterResponse;
        }

        public static async Task<RouteFilter> CreateDefaultRouteFilterRule(string resourceGroupName, string filterName, string ruleName, string location,
            NetworkManagementClient nrpClient)
        {
            RouteFilterRule rule = new RouteFilterRule()
            {
                Access = ExpressRouteTests.Filter_Access,
                Communities = new List<string> { ExpressRouteTests.Filter_Commmunity },
                Location = location
            };

            // Put route filter rule
            Operation<RouteFilterRule> ruleOperation = await nrpClient.RouteFilterRules.StartCreateOrUpdateAsync(resourceGroupName, filterName, ruleName, rule);
            Response<RouteFilterRule> ruleResponse = await ruleOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", ruleResponse.Value.ProvisioningState.ToString());
            Response<RouteFilter> getFilterResponse = await nrpClient.RouteFilters.GetAsync(resourceGroupName, filterName);

            return getFilterResponse;
        }

        public static async Task<PublicIPAddress> CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location,
            NetworkManagementClient nrpClient)
        {
            PublicIPAddress publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            Operation<PublicIPAddress> putPublicIpAddressOperation = await nrpClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, name, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());
            Response<PublicIPAddress> getPublicIpAddressResponse = await nrpClient.PublicIPAddresses.GetAsync(resourceGroupName, name);

            return getPublicIpAddressResponse;
        }

        public static async Task<NetworkInterface> CreateNetworkInterface(string name, string resourceGroupName, string publicIpAddressId, string subnetId,
            string location, string ipConfigName, NetworkManagementClient client)
        {
            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                         Name = ipConfigName,
                         PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                         Subnet = new Subnet() { Id = subnetId }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new PublicIPAddress() { Id = publicIpAddressId };
            }

            // Test NIC apis
            await client.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, name, nicParameters);
            Response<NetworkInterface> getNicResponse = await client.NetworkInterfaces.GetAsync(resourceGroupName, name);
            Assert.AreEqual(getNicResponse.Value.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.Value.IpConfigurations[0].Primary);

            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());

            return getNicResponse;
        }

        public static async Task<VirtualNetwork> CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location,
            NetworkManagementClient client)
        {
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
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            await client.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> getVnetResponse = await client.VirtualNetworks.GetAsync(resourceGroupName, vnetName);

            return getVnetResponse;
        }

        public static string GetChildLbResourceId(string subscriptionId, string resourceGroupName, string lbname, string childResourceType, string childResourceName)
        {
            return
                string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName);
        }
    }
}
