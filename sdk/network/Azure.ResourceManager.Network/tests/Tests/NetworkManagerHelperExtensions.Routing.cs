// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.ResourceManager.Network.Tests.Helpers.Validation;
using Azure.ResourceManager.Network.Tests.Tests;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class NetworkManagerHelperExtensions
    {
        public static async Task<(NetworkManagerRoutingConfigurationResource Configuration, List<RoutingRuleCollectionResource> Collections, List<RoutingRuleResource> Rules, RoutingConfigurationValidationData Expected)> CreateRoutingConfigurationAsync(
            this NetworkManagerResource networkManager,
            List<ResourceIdentifier> networkGroupIds,
            DisableBgpRoutePropagation disableBgpRoutePropagation,
            int numRules = 10)
        {
            var routingConfigurationName = "routingConfiguration-1";

            NetworkManagerRoutingConfigurationData routingConfigurationData = new()
            {
                Description = "My Test Routing Configuration",
            };

            NetworkManagerRoutingConfigurationCollection routingConfigurationResources = networkManager.GetNetworkManagerRoutingConfigurations();
            ArmOperation<NetworkManagerRoutingConfigurationResource> routingConfigurationResource = await routingConfigurationResources.CreateOrUpdateAsync(WaitUntil.Completed, routingConfigurationName, routingConfigurationData);

            // Create a routing rule collection
            List<RoutingRuleCollectionResource> collections = new();
            RoutingRuleCollectionResource routingCollection = await routingConfigurationResource.Value.CreateRoutingRuleCollectionAsync(networkGroupIds, disableBgpRoutePropagation);
            collections.Add(routingCollection);

            // Create multiple routing rules in parallel
            var routingRules = await CreateRoutingRules(routingCollection, numRules).ConfigureAwait(false);

            // Validate the created routing configuration
            var expectedData = new RoutingConfigurationValidationData
            {
                Description = routingConfigurationData.Description,
                Name = routingConfigurationName,
                RoutingRuleCollections = new List<RoutingRuleCollectionValidationData>
                {
                    new RoutingRuleCollectionValidationData
                    {
                        Description = routingCollection.Data.Description,
                        Name = routingCollection.Data.Name,
                        DisableBgpRoutePropagation = (DisableBgpRoutePropagation)routingCollection.Data.DisableBgpRoutePropagation,
                        AppliesTo = routingCollection.Data.AppliesTo.ToList()
                    }
                },
                RoutingRules = routingRules.Select(rule => new RoutingRuleValidationData
                {
                    Name = rule.Data.Name,
                    DestinationAddress = rule.Data.Destination.DestinationAddress,
                    DestinationType = rule.Data.Destination.DestinationType,
                    NextHopAddress = rule.Data.NextHop.NextHopAddress,
                    NextHopType = rule.Data.NextHop.NextHopType
                }).ToList()
            };

            return (routingConfigurationResource.Value, collections, routingRules, expectedData);
        }

        public static async Task<RoutingRuleCollectionResource> CreateRoutingRuleCollectionAsync(
            this NetworkManagerRoutingConfigurationResource routingConfiguration,
            List<ResourceIdentifier> networkGroupIds,
            DisableBgpRoutePropagation disableBgpRoutePropagation)
        {
            string routingCollectionName = "routingCollection-1";

            RoutingRuleCollectionData routingRuleCollectionData = new()
            {
                Description = "My Test Routing Rule Collection",
                DisableBgpRoutePropagation = disableBgpRoutePropagation,
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
            NetworkManagerRoutingConfigurationResource routingConfiguration)
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
            await DeleteAndVerifyResourceAsync(networkManager.GetNetworkManagerRoutingConfigurations(), routingConfiguration.Data.Name);
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

        public static async Task<RouteTableResource> CreateRouteTable(
            this ResourceGroupResource resourceGroup,
            string routeTableName,
            string location)
        {
            var routeTable = new RouteTableData() { Location = location, };

            // Put RouteTable
            RouteTableCollection routeTableCollection = resourceGroup.GetRouteTables();
            ArmOperation<RouteTableResource> putRouteTableResponseOperation = await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            return getRouteTableResponse.Value;
        }

        public static async Task AssociateRouteTableToSubnet(
            this ResourceGroupResource resourceGroup,
            VirtualNetworkResource vnet,
            SubnetResource subnet,
            RouteTableData routeTable)
        {
            // Associate RouteTable to Subnet
            SubnetData subnetData = subnet.Data;
            subnetData.RouteTable = routeTable;

            var vnetData = vnet.Data;
            ArmOperation<VirtualNetworkResource> vnetLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetData.Name, vnetData).ConfigureAwait(false);
            ArmOperation<SubnetResource> subnetLro = await vnetLro.Value.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetData.Name, subnetData).ConfigureAwait(false);
        }

        public static async Task ValidateRouteTablesAsync(
            this ResourceGroupResource resourceGroup,
            SubscriptionResource subscription,
            List<VirtualNetworkResource> vnets,
            RoutingConfigurationValidationData expectedValues,
            bool isEmpty = false)
        {
            string routeTableRgName = $"AVNM_Managed_ResourceGroup_{subscription.Data.SubscriptionId}";
            Response<ResourceGroupResource> routeTableRg = await subscription.GetResourceGroups().GetAsync(routeTableRgName);
            Assert.IsNotNull(routeTableRg);

            List<Task> validationTasks = new();
            foreach (VirtualNetworkResource vnet in vnets)
            {
                validationTasks.Add(ValidateRouteTablesForSubnetsAsync(resourceGroup, routeTableRg.Value, vnet, expectedValues, isEmpty));
            }

            await Task.WhenAll(validationTasks);
        }

        private static async Task ValidateRouteTablesForSubnetsAsync(
            ResourceGroupResource resourceGroup,
            ResourceGroupResource routeTableRg,
            VirtualNetworkResource vnet,
            RoutingConfigurationValidationData expectedValues,
            bool isEmpty)
        {
            Response<VirtualNetworkResource> virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnet.Data.Name);
            Assert.IsNotNull(virtualNetworkResource);

            var routingRules = expectedValues.RoutingRules.ToDictionary(
                rule => rule.DestinationAddress,
                rule => (rule.NextHopAddress, rule.NextHopType));

            // DisableBgpRoutePropagation is set to false if any of the collection is set to false
            bool disableBgpRoutePropagation = expectedValues.RoutingRuleCollections.Any(collection => collection.DisableBgpRoutePropagation == DisableBgpRoutePropagation.False) == true ? false : true;

            IList<SubnetData> subnets = virtualNetworkResource.Value.Data.Subnets;
            foreach (SubnetData subnet in subnets)
            {
                if (!isEmpty)
                {
                    Assert.IsNotNull(subnet.RouteTable);
                    string routeTableName = subnet.RouteTable.Id.ToString().Split('/').Last();
                    Response<RouteTableResource> routeTable = await routeTableRg.GetRouteTables().GetAsync(routeTableName);

                    Assert.IsNotNull(routeTable);
                    Assert.AreEqual(routeTable.Value.Data.DisableBgpRoutePropagation.ToString(), disableBgpRoutePropagation.ToString());

                    ValidateUserDefinedRoutes(routeTable.Value.Data.Routes, routingRules);
                }
                else
                {
                    Assert.IsNull(subnet.RouteTable);
                }
            }
        }

        private static async Task<List<RoutingRuleResource>> CreateRoutingRules(RoutingRuleCollectionResource routingCollection, int numRules)
        {
            var destinationAddresses = GenerateUniqueIPs(numRules).ToList();
            var nextHopAddresses = GenerateUniqueIPs(numRules).ToList();

            var routingRules = new List<RoutingRuleResource>();
            for (int i = 0; i < numRules; i++)
            {
                var routingRule = await routingCollection.CreateRoutingRuleAsync($"rule{i}", $"{destinationAddresses[i]}/32", RoutingRuleDestinationType.AddressPrefix, $"{nextHopAddresses[i]}", RoutingRuleNextHopType.VirtualAppliance).ConfigureAwait(false);
                routingRules.Add(routingRule);
            }

            return routingRules;
        }

        private static string GenerateIP()
        {
            var random = new Random();
            return $"{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}";
        }

        private static HashSet<string> GenerateUniqueIPs(int count)
        {
            var ips = new HashSet<string>();
            while (ips.Count < count)
            {
                string ip = GenerateIP();
                if (!IsMulticastAddress(ip))
                {
                    ips.Add(ip);
                }
            }

            return ips;
        }

        private static bool IsMulticastAddress(string ipAddress)
        {
            string[] parts = ipAddress.Split('.');
            int firstOctet = int.Parse(parts[0]);
            return (firstOctet >= 224 && firstOctet <= 239) || firstOctet == 127 || firstOctet == 0;
        }
    }
}
