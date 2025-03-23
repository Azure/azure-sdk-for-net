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
using Azure.ResourceManager.Network.Tests.Tests;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class NetworkManagerHelperExtensions
    {
        public static async Task<NetworkManagerRoutingConfigurationResource> CreateRoutingConfigurationAsync(
            this NetworkManagerResource networkManager,
            string routingConfigurationName,
            RoutingConfigurationValidationData validationData)
        {
            NetworkManagerRoutingConfigurationData routingConfigurationData = new()
            {
                Description = "My Test Routing Configuration",
            };

            NetworkManagerRoutingConfigurationCollection routingConfigurationResources = networkManager.GetNetworkManagerRoutingConfigurations();
            ArmOperation<NetworkManagerRoutingConfigurationResource> routingConfigurationResource = await routingConfigurationResources.CreateOrUpdateAsync(WaitUntil.Completed, routingConfigurationName, routingConfigurationData).ConfigureAwait(false);

            validationData.Description = routingConfigurationData.Description;
            validationData.Name = routingConfigurationName;

            return routingConfigurationResource.Value;
        }

        public static async Task<RoutingRuleCollectionResource> CreateRoutingRuleCollectionAsync(
            this NetworkManagerRoutingConfigurationResource routingConfiguration,
            string routingCollectionName,
            List<ResourceIdentifier> networkGroupIds,
            DisableBgpRoutePropagation disableBgpRoutePropagation,
            List<RoutingRuleCollectionValidationData> routingCollectionValidationData)
        {
            RoutingRuleCollectionData routingRuleCollectionData = new()
            {
                Description = "SDK Testing",
                DisableBgpRoutePropagation = disableBgpRoutePropagation,
            };

            foreach (ResourceIdentifier networkGroupId in networkGroupIds)
            {
                routingRuleCollectionData.AppliesTo.Add(new NetworkManagerRoutingGroupItem() { NetworkGroupId = networkGroupId });
            }

            RoutingRuleCollectionCollection routingRuleCollectionResources = routingConfiguration.GetRoutingRuleCollections();
            ArmOperation<RoutingRuleCollectionResource> routingRuleCollectionResource = await routingRuleCollectionResources.CreateOrUpdateAsync(WaitUntil.Completed, routingCollectionName, routingRuleCollectionData).ConfigureAwait(false);

            routingCollectionValidationData.Add(new RoutingRuleCollectionValidationData()
            {
                Description = routingRuleCollectionData.Description,
                Name = routingCollectionName,
                DisableBgpRoutePropagation = disableBgpRoutePropagation,
                AppliesTo = routingRuleCollectionData.AppliesTo.ToList(),
            });

            return routingRuleCollectionResource.Value;
        }

        public static async Task<List<RoutingRuleResource>> CreateRoutingRules(
            this RoutingRuleCollectionResource routingCollection,
            int numRules,
            List<RoutingRuleValidationData> routingRulesValidationData)
        {
            var destinationAddresses = GenerateUniqueIPs(numRules).ToList();
            var nextHopAddresses = GenerateUniqueIPs(numRules).ToList();

            var routingRules = new List<RoutingRuleResource>();
            for (int i = 0; i < numRules; i++)
            {
                var routingRule = await routingCollection.CreateRoutingRuleAsync($"rule{i}", $"{destinationAddresses[i]}/32", RoutingRuleDestinationType.AddressPrefix, $"{nextHopAddresses[i]}", RoutingRuleNextHopType.VirtualAppliance, routingRulesValidationData).ConfigureAwait(false);
                routingRules.Add(routingRule);
            }

            return routingRules;
        }

        public static async Task<RoutingRuleResource> CreateRoutingRuleAsync(
            this RoutingRuleCollectionResource routingRuleCollection,
            string routingRuleName,
            string destinationAddress,
            RoutingRuleDestinationType destinationType,
            string nextHopAddress,
            RoutingRuleNextHopType nextHopType,
            List<RoutingRuleValidationData> routingRulesValidationData)
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
            ArmOperation<RoutingRuleResource> routingRuleResource = await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, routingRuleName, routingRuleData).ConfigureAwait(false);

            routingRulesValidationData.Add(new RoutingRuleValidationData()
            {
                Name = routingRuleName,
                DestinationAddress = destinationAddress,
                DestinationType = destinationType,
                NextHopAddress = nextHopAddress,
                NextHopType = nextHopType,
            });

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

            await Task.WhenAll(deleteRuleTasks).ConfigureAwait(false);

            // Delete routing rule collections in parallel
            List<Task> deleteCollectionTasks = new();
            await foreach (RoutingRuleCollectionResource collection in collections.GetAllAsync())
            {
                deleteCollectionTasks.Add(DeleteAndVerifyResourceAsync(collections, collection.Data.Name));
            }

            await Task.WhenAll(deleteCollectionTasks).ConfigureAwait(false);

            // Delete the routing configuration
            await DeleteAndVerifyResourceAsync(networkManager.GetNetworkManagerRoutingConfigurations(), routingConfiguration.Data.Name).ConfigureAwait(false);
        }

        public static async Task DeleteRoutingRuleAsync(
            this RoutingRuleCollectionResource routingRuleCollection,
            RoutingRuleResource routingRule)
        {
            await DeleteAndVerifyResourceAsync(routingRuleCollection.GetRoutingRules(), routingRule.Data.Name).ConfigureAwait(false);
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
            ArmOperation<RouteTableResource> putRouteTableResponseOperation = await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable).ConfigureAwait(false);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName).ConfigureAwait(false);
            return getRouteTableResponse.Value;
        }

        public static async Task ValidateAvnmManagedResourceGroup(SubscriptionResource subscription)
        {
            var subGuid = subscription.Data.Id.ToString().Split('/').Last();
            var managedRgName = $"AVNM_Managed_resourceGroup_{subGuid}";
            var managedRg = await subscription.GetResourceGroups().GetIfExistsAsync(managedRgName).ConfigureAwait(false);
            if (managedRg.HasValue)
            {
                var managedResources = managedRg.Value;
                var resources = await managedResources.GetGenericResourcesAsync().ToEnumerableAsync().ConfigureAwait(false);

                Assert.IsTrue(resources.Count == 0, $"The managed resource group '{managedRgName}' is not empty. Cannot delete it.");

                await managedRg.Value.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
            }
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
            Response<ResourceGroupResource> routeTableRg = await subscription.GetResourceGroups().GetAsync(routeTableRgName).ConfigureAwait(false);
            Assert.IsNotNull(routeTableRg);

            List<Task> validationTasks = new();
            foreach (VirtualNetworkResource vnet in vnets)
            {
                validationTasks.Add(ValidateRouteTablesForSubnetsAsync(resourceGroup, routeTableRg.Value, vnet, expectedValues, isEmpty));
            }

            await Task.WhenAll(validationTasks).ConfigureAwait(false);
        }

        private static async Task ValidateRouteTablesForSubnetsAsync(
            ResourceGroupResource resourceGroup,
            ResourceGroupResource routeTableRg,
            VirtualNetworkResource vnet,
            RoutingConfigurationValidationData expectedValues,
            bool isEmpty)
        {
            Response<VirtualNetworkResource> virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnet.Data.Name).ConfigureAwait(false);
            Assert.IsNotNull(virtualNetworkResource);

            var routingRules = expectedValues.RoutingRules.ToDictionary(
                rule => rule.DestinationAddress,
                rule => (rule.NextHopAddress, rule.NextHopType));

            // DisableBgpRoutePropagation is set to false if any of the collection is set to false
            bool disableBgpRoutePropagation = expectedValues.RoutingRuleCollections.Any(collection => collection.DisableBgpRoutePropagation == DisableBgpRoutePropagation.False) == true ? false : true;

            var routeTables = new HashSet<string>();
            IList<SubnetData> subnets = virtualNetworkResource.Value.Data.Subnets;
            foreach (SubnetData subnet in subnets)
            {
                if (!isEmpty)
                {
                    Assert.IsNotNull(subnet.RouteTable);
                    string routeTableName = subnet.RouteTable.Id.ToString().Split('/').Last();
                    Response<RouteTableResource> routeTable = await routeTableRg.GetRouteTables().GetAsync(routeTableName).ConfigureAwait(false);

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
