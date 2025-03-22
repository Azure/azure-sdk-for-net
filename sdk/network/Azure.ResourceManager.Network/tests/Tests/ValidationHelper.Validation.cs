// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using System;
using Azure.ResourceManager.Network.Tests.Tests;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Network.Tests.Helpers.Validation
{
    public static class ValidationHelper
    {
        public static void ValidateRoutingRule(
            RoutingRuleResource rule,
            Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)> expectedValues)
        {
            Assert.AreEqual(NetworkProvisioningState.Succeeded, rule.Data.ProvisioningState);

            if (!expectedValues.TryGetValue(rule.Data.Destination.DestinationAddress, out var expected))
            {
                Assert.Fail($"Unexpected routing rule destination address: {rule.Data.Destination.DestinationAddress}");
            }

            Assert.AreEqual(expected.NextHopAddress, rule.Data.NextHop.NextHopAddress);
            Assert.AreEqual(expected.NextHopType, rule.Data.NextHop.NextHopType);
        }

        public static void ValidateUserDefinedRoutes(
            IList<RouteData> routes,
            Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)> expectedValues)
        {
            // Validate the count of routes
            Assert.AreEqual(routes.Count, expectedValues.Count);

            foreach (RouteData route in routes)
            {
                Assert.AreEqual(NetworkProvisioningState.Succeeded, route.ProvisioningState);

                if (!expectedValues.TryGetValue(route.AddressPrefix, out var expected))
                {
                    Assert.Fail($"Unexpected routing rule destination address: {route.AddressPrefix}");
                }

                Assert.AreEqual(expected.NextHopAddress, route.NextHopIPAddress);
                Assert.IsTrue(string.Equals(expected.NextHopType.ToString(), route.NextHopType.ToString(), StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public static void ValidateRoutingConfigurationData(
            NetworkManagerRoutingConfigurationResource routingConfiguration,
            RoutingConfigurationValidationData expectedData)
        {
            Assert.AreEqual(expectedData.Description, routingConfiguration.Data.Description);

            var collections = routingConfiguration.GetRoutingRuleCollections().ToEnumerableAsync().Result;
            Assert.AreEqual(expectedData.RoutingRuleCollections.Count, collections.Count);

            var routingRules = collections
                .SelectMany(c => c.GetRoutingRules().ToEnumerableAsync().Result)
                .ToList();

            Assert.AreEqual(expectedData.RoutingRules.Count, routingRules.Count);

            foreach (var expectedRule in expectedData.RoutingRules)
            {
                var rule = routingRules.FirstOrDefault(r => r.Data.Destination.DestinationAddress == expectedRule.DestinationAddress);
                Assert.IsNotNull(rule, $"Routing rule with destination address {expectedRule.DestinationAddress} not found.");

                Assert.AreEqual(expectedRule.DestinationType, rule.Data.Destination.DestinationType);
                Assert.AreEqual(expectedRule.NextHopAddress, rule.Data.NextHop.NextHopAddress);
                Assert.AreEqual(expectedRule.NextHopType, rule.Data.NextHop.NextHopType);
            }

            foreach (var expectedCollection in expectedData.RoutingRuleCollections)
            {
                var collection = collections.FirstOrDefault(c => c.Data.Name == expectedCollection.Name);
                Assert.IsNotNull(collection, $"Routing rule collection with name {expectedCollection.Name} not found.");

                Assert.AreEqual(expectedCollection.DisableBgpRoutePropagation, collection.Data.DisableBgpRoutePropagation);

                // Sort the appliesTo lists for comparison
                var expectedAppliesTo = expectedCollection.AppliesTo.OrderBy(a => a.NetworkGroupId.ToString()).ToList();
                var actualAppliesTo = collection.Data.AppliesTo.OrderBy(a => a.NetworkGroupId.ToString()).ToList();
                Assert.AreEqual(expectedAppliesTo.Count, actualAppliesTo.Count, $"Count mismatch in appliesTo for collection {expectedCollection.Name}");
            }
        }
    }
}
