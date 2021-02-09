// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using SubResource = Microsoft.Azure.Management.DnsResolver.Models.SubResource;

    internal static class TestDataGenerator
    {
        private const string DefaultResourceLocation = "Central US";

        private static readonly Random Random;

        static TestDataGenerator()
        {
            Random = new Random();
        }

        public static string GenerateSubscriptionId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateResourceGroupName()
        {
           return TestUtilities.GenerateName("dnsresolvertestrg");
        }

        public static string GenerateDnsResolverName()
        {
            return TestUtilities.GenerateName("dnsresolvertestresolver");
        }

        public static string GenerateVirtualNetworkName()
        {
            return TestUtilities.GenerateName("dnsresolvertestvnet");
        }

        public static string GenerateSubnetName()
        {
            return TestUtilities.GenerateName("dnsresolvertestsubnet");
        }

        public static string GenerateInboundEndpointName()
        {
            return TestUtilities.GenerateName("dnsresolvertestinboundendpoint");
        }

        public static string GenerateVirtualNetworkArmId(string subscriptionId = null, string resourceGroupName = null, string virtualNetworkName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            virtualNetworkName = virtualNetworkName ?? GenerateVirtualNetworkName();

            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";
        }

        public static string GenerateDnsResolverArmId(string subscriptionId = null, string resourceGroupName = null, string dnsResolverName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            dnsResolverName = dnsResolverName ?? GenerateDnsResolverName();

            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsResolvers/{dnsResolverName}";
        }

        public static string GenerateSubnetArmId(string subscriptionId = null, string resourceGroupName = null, string virtualNetworkName = null, string subnetName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            virtualNetworkName = virtualNetworkName ?? GenerateSubnetName();
            subnetName = subnetName ?? GenerateSubnetName();

            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
        }


        public static ResourceGroup GenerateResourceGroup(string location = null)
        {
            return new ResourceGroup
            {
                Location = location ?? DefaultResourceLocation,
            };
        }

        public static SubResource GenerateNonExistentVirtualNetwork(string subscriptionId = null, string resourceGroupName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();

            return new SubResource
            {
                Id = GenerateVirtualNetworkArmId(subscriptionId: subscriptionId, resourceGroupName: resourceGroupName),
            };
        }

        public static VirtualNetwork GenerateVirtualNetwork(
            string location = null,
            string addressSpaceCidr = "10.0.0.0/16",
            string subnetName = "Default",
            string subnetAddressSpaceCidr = "10.0.0.0/24")
        {
            return new VirtualNetwork
            {
                AddressSpace = new AddressSpace
                {
                    AddressPrefixes = new List<string>
                    {
                        addressSpaceCidr
                    }
                },
                Subnets = new List<Subnet>
                {
                    new Subnet
                    {
                        Name = subnetName,
                        AddressPrefix = subnetAddressSpaceCidr
                    }
                },
                Location = location ?? DefaultResourceLocation,
            };
        }

        public static List<IpConfiguration> GenerateRandomIpConfigurations(int count = 1, string subscriptionId = null, string resourceGroupName = null,  string virtualNetworkName = null) 
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            virtualNetworkName = virtualNetworkName ?? GenerateVirtualNetworkName();
            var ipConfigurations = new List<IpConfiguration>();

            for (var i = 0; i < count; i++)
            {
                ipConfigurations.Add(new IpConfiguration
                {
                    Subnet = GenerateRandomSubnetSubResource(subscriptionId: subscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: virtualNetworkName),
                    PrivateIpAddress = null, 
                    PrivateIpAllocationMethod = Constants.StaticPrivateIpAllocationMethod,
                });
            }

            return ipConfigurations;
        }

        public static DnsResolverModel GenerateDnsResolverWithoutVirtualNetwork(string location = null, IDictionary<string, string> tags = null)
        {
            return new DnsResolverModel
            {
                Location = location,
                Tags = tags,
                VirtualNetwork = new SubResource(),
            };
        }

        public static IDictionary<string, string> GenerateTags(int numTags = 5, int startFrom = 0)
        {
            var tags = new Dictionary<string, string>();
            for (var i = 0; i < numTags; i++)
            {
                var tagKey = $"tagKey{startFrom + i}";
                var tagValue = $"tagValue{startFrom + i}";

                tags.Add(tagKey, tagValue);
            }

            return tags;
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomIpAddress()
        {
            var random = new Random();
            return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        }

        private static SubResource GenerateRandomSubnetSubResource(string subscriptionId = null, string resourceGroupName = null, string virtualNetworkName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            virtualNetworkName = virtualNetworkName ?? GenerateVirtualNetworkName();
            var subnetName = GenerateSubnetName();

            return new SubResource
            {
                Id = GenerateSubnetArmId(subscriptionId, resourceGroupName, virtualNetworkName, subnetName),
            };
        }
    }
}
