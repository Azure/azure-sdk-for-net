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
using Azure.Core;
using System;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class NetworkManagerHelperExtensions
    {
        public static async Task<RoutingConfigurationResource> CreateRoutingConfigurationAsync(this NetworkManagerResource networkManager)
        {
            string routingConfigurationName = $"routingConfiguration-1";

            RoutingConfigurationData routingConfigurationData = new()
            {
                Description = "My Test Routing Configuration",
            };

            RoutingConfigurationCollection routingConfigurationResources = networkManager.GetRoutingConfigurations();
            ArmOperation<RoutingConfigurationResource> routingConfigurationResource = await routingConfigurationResources.CreateOrUpdateAsync(WaitUntil.Completed, routingConfigurationName, routingConfigurationData);
            return routingConfigurationResource.Value;
        }

        public static async Task<RoutingRuleCollectionResource> CreateRoutingRuleCollectionAsync(
            this RoutingConfigurationResource routingConfiguration,
            List<ResourceIdentifier> networkGroupIds)
        {
            var routingCollectionName = $"routingCollection-1";

            RoutingRuleCollectionData routingRuleCollectionData = new()
            {
                Description = "My Test Routing Rule Collection",
                DisableBgpRoutePropagation = "True",
                LocalRouteSetting = RoutingRuleCollectionLocalRouteSetting.NotSpecified,
            };

            foreach (ResourceIdentifier networkGroupId in networkGroupIds)
            {
                routingRuleCollectionData.AppliesTo.Add(new NetworkManagerRoutingGroupItem() { NetworkGroupId = networkGroupId });
            }

            RoutingRuleCollectionCollection routingRuleCollectionResources = routingConfiguration.GetRoutingRuleCollections();
            ArmOperation<RoutingRuleCollectionResource> routingRuleCollectionResource = await routingRuleCollectionResources.CreateOrUpdateAsync(WaitUntil.Completed, routingCollectionName, routingRuleCollectionData);
            return routingRuleCollectionResource.Value;
        }

        public static async Task<RoutingRuleResource> CreateRoutingRuleAsync(
            this RoutingRuleCollectionResource routingRuleCollection,
            string routingRuleName,
            string destinationAddress,
            RoutingRuleDestinationType destinationType,
            string nextHopAddress,
            RoutingRuleNextHopType nextHopType)
        {
            RoutingRuleData routingRuleData = new()
            {
                Destination = new RoutingRuleRouteDestination()
                {
                    DestinationAddress = destinationAddress,
                    DestinationType = destinationType,
                },
                NextHop = new RoutingRuleNextHop()
                {
                    NextHopAddress = nextHopAddress,
                    NextHopType = nextHopType,
                },
            };

            RoutingRuleCollection ruleCollection = routingRuleCollection.GetRoutingRules();
            ArmOperation<RoutingRuleResource> routingRuleResource = await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, routingRuleName, routingRuleData);
            return routingRuleResource.Value;
        }

        public static async Task DeleteRoutingConfigurationAsync(this NetworkManagerResource networkManager, RoutingConfigurationResource routingConfiguration)
        {
            RoutingRuleCollectionCollection collections = routingConfiguration.GetRoutingRuleCollections();

            await foreach (RoutingRuleCollectionResource collection in collections.GetAllAsync())
            {
                await foreach (var rule in collection.GetRoutingRules().GetAllAsync())
                {
                    await DeleteAndVerifyResourceAsync(collection.GetRoutingRules(), rule.Data.Name);
                }
            }

            var deleteTasks = new List<Task>();
            await foreach (var collection in collections.GetAllAsync())
            {
                deleteTasks.Add(DeleteAndVerifyResourceAsync(collections, collection.Data.Name));
            }

            await Task.WhenAll(deleteTasks);

            await DeleteAndVerifyResourceAsync(networkManager.GetRoutingConfigurations(), routingConfiguration.Data.Name);
        }

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
    }
}
