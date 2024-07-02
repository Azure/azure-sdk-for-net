// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using System.Runtime.CompilerServices;
using System;

namespace Azure.ResourceManager.Network.Tests
{
    public class RoutingConfigurationTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private NetworkGroupResource _networkGroupVnet;
        private NetworkGroupResource _networkGroupSubnet;
        private readonly AzureLocation _location = AzureLocation.EastUS2;
        private RoutingConfigurationResource _routingConfiguration;
        private List<RoutingRuleCollectionResource> _routingCollections;
        private List<RoutingRuleResource> _routingRules;
        private List<VirtualNetworkResource> _vnets = new();
        private List<SubnetResource> _subnets = new();
        private SubscriptionResource _subscription;
        private const string VirtualNetworkGroupType = "VirtualNetwork";
        private const string SubnetNetworkGroupType = "Subnet";

        public RoutingConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            // Get the default subscription
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            // Create a resource group
            string resourceGroupName = SessionRecording.GenerateAssetName("rg-");
            _resourceGroup = await _subscription.CreateResourceGroupAsync(resourceGroupName, _location);

            // Create a network manager
            string networkManagerName = SessionRecording.GenerateAssetName("nm-");
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(
                networkManagerName,
                _location,
                new List<string> { _subscription.Data.Id },
                new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.Routing });

            // Create test virtual networks and subnets
            (_vnets, _subnets) = await _resourceGroup.CreateTestVirtualNetworksAsync(_location);

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            // Delete the network manager
            await _resourceGroup.GetNetworkManagers().DeleteAndVerifyResourceAsync(_networkManager.Data.Name);

            // Delete the test virtual networks
            IEnumerable<Task> deleteVnetsTasks = _vnets.Select(vnet => _resourceGroup.GetVirtualNetworks().DeleteAndVerifyResourceAsync(vnet.Data.Name));
            await Task.WhenAll(deleteVnetsTasks);

            // Delete the resource group
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // Create network groups for virtual networks and subnets
            _networkGroupVnet = await _networkManager.CreateNetworkGroupAsync(VirtualNetworkGroupType);
            _networkGroupSubnet = await _networkManager.CreateNetworkGroupAsync(SubnetNetworkGroupType);

            // Create a routing configuration
            (_routingConfiguration, _routingCollections, _routingRules) = await _networkManager.CreateRoutingConfigurationAsync
                (new List<ResourceIdentifier>() { _networkGroupSubnet.Id, _networkGroupVnet.Id });
        }

        [TearDown]
        public async Task TestTearDown()
        {
            // Delete the routing configuration
            await _networkManager.DeleteRoutingConfigurationAsync(_routingConfiguration);

            // Delete the network groups
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupSubnet);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupVnet);
        }

        [Test]
        [RecordedTest]
        public async Task TestRoutingConfigurationCrud()
        {
            // Prepare expected values for validation
            var expectedValues = _routingRules.ToDictionary(
                rule => rule.Data.Destination.DestinationAddress,
                rule => (rule.Data.NextHop.NextHopAddress, rule.Data.NextHop.NextHopType));

            // Assert
            // Fetch the routing configuration
            Response<RoutingConfigurationResource> fetchedRoutingConfiguration = await _networkManager.GetRoutingConfigurations().GetAsync(_routingConfiguration.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedRoutingConfiguration.Value.Data.ProvisioningState);

            // Fetch the routing rule collection
            Response<RoutingRuleCollectionResource> fetchedRoutingRuleCollection = await fetchedRoutingConfiguration.Value.GetRoutingRuleCollections().GetAsync(_routingCollections.First().Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedRoutingRuleCollection.Value.Data.ProvisioningState);

            Assert.AreEqual(2, fetchedRoutingRuleCollection.Value.Data.AppliesTo.Count);
            Assert.AreEqual("True", fetchedRoutingRuleCollection.Value.Data.DisableBgpRoutePropagation);

            // Validate each routing rule
            RoutingRuleCollection fetchedRoutingRules = fetchedRoutingRuleCollection.Value.GetRoutingRules();
            await foreach (RoutingRuleResource rule in fetchedRoutingRules)
            {
                NetworkManagerHelperExtensions.ValidateRoutingRule(rule, expectedValues);
            }
        }

        [Test]
        [RecordedTest]
        public async Task TestRoutingConfigurationCommit()
        {
            // Prepare expected values for validation
            var expectedValues = _routingRules.ToDictionary(
                rule => rule.Data.Destination.DestinationAddress,
                rule => (rule.Data.NextHop.NextHopAddress, rule.Data.NextHop.NextHopType));

            // Add static members to the network groups
            await _networkGroupVnet.AddVnetStaticMemberToNetworkGroup(_vnets);

            // Act
            // Commit the routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(
                _location,
                new List<string> { _routingConfiguration.Id },
                NetworkConfigurationDeploymentType.Routing);

            // Assert
            // Validate all the routes within the route tables associated with the subnets
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, expectedValues);

            // Act
            // Commit an empty routing configuration
            expectedValues = new Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)>();
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.Routing);

            // Assert
            // Validate that the route tables are empty
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, expectedValues, isEmpty: true);
        }
    }
}
