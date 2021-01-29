// ------------------------------------------------------------------------------------------------
// <copyright file="TestDataGenerator.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace DnsResolver.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.DnsResolver;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

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
           return TestUtilities.GenerateName("dnsresolvertestrgt3");
        }

        public static string GenerateDnsResolverName()
        {
            return TestUtilities.GenerateName("dnsresolvertestresolvert3");
        }

        public static string GenerateVirtualNetworkName()
        {
            return TestUtilities.GenerateName("dnsresolvertestvnett3");
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

        public static ResourceGroup GenerateResourceGroup(string location = null)
        {
            return new ResourceGroup
            {
                Location = location ?? DefaultResourceLocation,
            };
        }

        public static Microsoft.Azure.Management.DnsResolver.Models.SubResource GenerateVirtualNetwork(string subscriptionId = null, string resourceGroupName = null)
        {
            return new Microsoft.Azure.Management.DnsResolver.Models.SubResource
            {
                Id = GenerateVirtualNetworkArmId(subscriptionId: subscriptionId, resourceGroupName: resourceGroupName),
            };
        }

        public static DnsResolverModel GenerateDnsResolver(string location = null, string subscriptionId = null,  string resourceGroupName = null, IDictionary<string, string> tags = null, Microsoft.Azure.Management.DnsResolver.Models.SubResource virtualNetwork = null)
        {
            virtualNetwork = virtualNetwork ?? GenerateVirtualNetwork(subscriptionId: subscriptionId, resourceGroupName: resourceGroupName);
            return new DnsResolverModel
            {
                Location = location,
                Tags = tags,
                VirtualNetwork = virtualNetwork
            };
        }

        public static int GenerateInteger(int minVal= 0, int maxVal = 10)
        {
            return Random.Next(minVal, maxVal);
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
    }
}
