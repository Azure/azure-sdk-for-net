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
        public static async Task<(RoutingConfigurationResource Configuration, List<RoutingRuleCollectionResource> Collections, List<RoutingRuleResource> Rules)> CreateRoutingConfigurationAsync(
            this NetworkManagerResource networkManager,
            List<ResourceIdentifier> networkGroupIds)
        {
            string routingConfigurationName = "routingConfiguration-1";

            RoutingConfigurationData routingConfigurationData = new()
            {
                Description = "My Test Routing Configuration",
            };

            RoutingConfigurationCollection routingConfigurationResources = networkManager.GetRoutingConfigurations();
            ArmOperation<RoutingConfigurationResource> routingConfigurationResource = await routingConfigurationResources.CreateOrUpdateAsync(WaitUntil.Completed, routingConfigurationName, routingConfigurationData);

            // Create a routing rule collection
            List<RoutingRuleCollectionResource> collections = new();
            RoutingRuleCollectionResource routingCollection = await routingConfigurationResource.Value.CreateRoutingRuleCollectionAsync(networkGroupIds);
            collections.Add(routingCollection);

            // Create multiple routing rules in parallel
            List<Task<RoutingRuleResource>> routingRuleTasks = new()
            {
                routingCollection.CreateRoutingRuleAsync("rule1", "10.1.1.0/24", RoutingRuleDestinationType.AddressPrefix, "20.1.1.1", RoutingRuleNextHopType.VirtualAppliance),
                routingCollection.CreateRoutingRuleAsync("rule2", "10.2.2.0/24", RoutingRuleDestinationType.AddressPrefix, string.Empty, RoutingRuleNextHopType.VirtualNetworkGateway),
                routingCollection.CreateRoutingRuleAsync("rule3", "ApiManagement", RoutingRuleDestinationType.ServiceTag, string.Empty, RoutingRuleNextHopType.Internet),
                routingCollection.CreateRoutingRuleAsync("rule5", "2001::1/128", RoutingRuleDestinationType.AddressPrefix, "2001::2", RoutingRuleNextHopType.VirtualAppliance),
            };
            List<RoutingRuleResource> routingRules = (await Task.WhenAll(routingRuleTasks)).ToList();

            return (routingConfigurationResource.Value, collections, routingRules);
        }

        public static async Task<RoutingRuleCollectionResource> CreateRoutingRuleCollectionAsync(
            this RoutingConfigurationResource routingConfiguration,
            List<ResourceIdentifier> networkGroupIds)
        {
            string routingCollectionName = "routingCollection-1";

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

        public static async Task DeleteRoutingConfigurationAsync(
            this NetworkManagerResource networkManager,
            RoutingConfigurationResource routingConfiguration)
        {
            RoutingRuleCollectionCollection collections = routingConfiguration.GetRoutingRuleCollections();

            // Delete routing rules in parallel
            List<Task> deleteRuleTasks = new();
            await foreach (RoutingRuleCollectionResource collection in collections.GetAllAsync())
            {
                await foreach (RoutingRuleResource rule in collection.GetRoutingRules().GetAllAsync())
                {
                    deleteRuleTasks.Add(DeleteAndVerifyResourceAsync(collection.GetRoutingRules(), rule.Data.Name));
                }
            }
            await Task.WhenAll(deleteRuleTasks);

            // Delete routing rule collections in parallel
            List<Task> deleteCollectionTasks = new();
            await foreach (RoutingRuleCollectionResource collection in collections.GetAllAsync())
            {
                deleteCollectionTasks.Add(DeleteAndVerifyResourceAsync(collections, collection.Data.Name));
            }
            await Task.WhenAll(deleteCollectionTasks);

            // Delete the routing configuration
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

        public static void ValidateUserDefinedRoutes(
            IList<RouteData> routes,
            Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)> expectedValues)
        {
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

        public static async Task ValidateRouteTablesAsync(
            this ResourceGroupResource resourceGroup,
            SubscriptionResource subscription,
            List<VirtualNetworkResource> vnets,
            Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)> expectedValues,
            bool isEmpty = false)
        {
            string routeTableRgName = $"AVNM_Rg_11434_{subscription.Data.SubscriptionId}";
            Response<ResourceGroupResource> routeTableRg = await subscription.GetResourceGroups().GetAsync(routeTableRgName);
            Assert.IsNotNull(routeTableRg);

            List<Task> validationTasks = new();
            foreach (VirtualNetworkResource vnet in vnets)
            {
                validationTasks.Add(ValidateRouteTablesAsync(resourceGroup, routeTableRg.Value, vnet, expectedValues, isEmpty));
            }
            await Task.WhenAll(validationTasks);
        }

        private static async Task ValidateRouteTablesAsync(
            ResourceGroupResource resourceGroup,
            ResourceGroupResource routeTableRg,
            VirtualNetworkResource vnet,
            Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)> expectedValues,
            bool isEmpty)
        {
            Response<VirtualNetworkResource> virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnet.Data.Name);
            Assert.IsNotNull(virtualNetworkResource);

            IList<SubnetData> subnets = virtualNetworkResource.Value.Data.Subnets;
            foreach (SubnetData subnet in subnets)
            {
                if (!isEmpty)
                {
                    Assert.IsNotNull(subnet.RouteTable);
                    string routeTableName = subnet.RouteTable?.Id.ToString().Split('/').Last();
                    Response<RouteTableResource> routeTable = await routeTableRg.GetRouteTables().GetAsync(routeTableName);
                    ValidateUserDefinedRoutes(routeTable.Value.Data.Routes, expectedValues);
                }
                else
                {
                    Assert.IsNull(subnet.RouteTable);
                }
            }
        }
    }
}
