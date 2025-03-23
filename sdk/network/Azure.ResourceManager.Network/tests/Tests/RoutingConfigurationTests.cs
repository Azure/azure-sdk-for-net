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
using System;
using Azure.ResourceManager.Network.Tests.Tests;

namespace Azure.ResourceManager.Network.Tests
{
    public class RoutingConfigurationTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private NetworkGroupResource _networkGroupVnet;
        private NetworkGroupResource _networkGroupSubnet;
        private readonly AzureLocation _location = new("eastus2euap");
        private NetworkManagerRoutingConfigurationResource _routingConfiguration;
        private List<RoutingRuleCollectionResource> _routingCollections;
        private List<RoutingRuleResource> _routingRules;
        private List<VirtualNetworkResource> _vnets = new();
        private List<SubnetResource> _subnets = new();
        private SubscriptionResource _subscription;
        private RoutingConfigurationValidationData _routingConfigurationValidationData;
        private const string VirtualNetworkGroupType = "VirtualNetwork";
        private const string SubnetNetworkGroupType = "Subnet";

        public RoutingConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _resourceGroup = await _subscription.CreateResourceGroupAsync(SessionRecording.GenerateAssetName("ankursood-rg-"), _location).ConfigureAwait(false);
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(SessionRecording.GenerateAssetName("ankursood-nm-"), _location, new List<string> { _subscription.Data.Id }, new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.Routing }).ConfigureAwait(false);
            _vnets = await _resourceGroup.CreateTestVirtualNetworksAsync(_location, numVnets: 2, numSubnetsPerVnet: 2).ConfigureAwait(false);
        }
        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (_resourceGroup == null || _networkManager == null || _vnets == null || _subscription == null)
            {
                throw new InvalidOperationException("Required resources are not initialized.");
            }

            await _resourceGroup.GetNetworkManagers().DeleteAndVerifyResourceAsync(_networkManager.Data.Name).ConfigureAwait(false);
            IEnumerable<Task> deleteVnetsTasks = _vnets.Select(vnet => _resourceGroup.GetVirtualNetworks().DeleteAndVerifyResourceAsync(vnet.Data.Name));
            await Task.WhenAll(deleteVnetsTasks).ConfigureAwait(false);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }

            _networkGroupVnet = await _networkManager.CreateNetworkGroupAsync(VirtualNetworkGroupType).ConfigureAwait(false);
            _networkGroupSubnet = await _networkManager.CreateNetworkGroupAsync(SubnetNetworkGroupType).ConfigureAwait(false);
            await _networkGroupVnet.AddVnetStaticMemberToNetworkGroup(_vnets).ConfigureAwait(false);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await _networkManager.DeleteRoutingConfigurationAsync(_routingConfiguration).ConfigureAwait(false);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupSubnet).ConfigureAwait(false);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupVnet).ConfigureAwait(false);
            await StopSessionRecordingAsync().ConfigureAwait(false);
        }

        [Test]
        public async Task TestRoutingConfigurationCrud()
        {
            // Create a routing configuration, routing rule collection, and routing rules
            _routingConfigurationValidationData = new RoutingConfigurationValidationData();
            _routingConfiguration = await _networkManager.CreateRoutingConfigurationAsync("rc-1", _routingConfigurationValidationData).ConfigureAwait(false);

            _routingCollections = new List<RoutingRuleCollectionResource>();

            var collection = await _routingConfiguration.CreateRoutingRuleCollectionAsync(
                "rc-1",
                new List<ResourceIdentifier> { _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False,
                _routingConfigurationValidationData.RoutingRuleCollections).ConfigureAwait(false);
            _routingCollections.Add(collection);

            _routingRules = await collection.CreateRoutingRules(numRules: 10, _routingConfigurationValidationData.RoutingRules).ConfigureAwait(false);

            // Validate the routing configuration
            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData).ConfigureAwait(false);
            await NetworkManagerHelperExtensions.ValidateAvnmManagedResourceGroup(_subscription).ConfigureAwait(false);
        }

        [Test]
        public async Task TestRoutingConfigurationCommit()
        {
            // Create a new routing configuration, routing rule collection, and routing rules
            _routingConfigurationValidationData = new RoutingConfigurationValidationData();
            _routingConfiguration = await _networkManager.CreateRoutingConfigurationAsync("rc-1", _routingConfigurationValidationData).ConfigureAwait(false);

            _routingCollections = new List<RoutingRuleCollectionResource>();

            var collection = await _routingConfiguration.CreateRoutingRuleCollectionAsync(
                "rc-1",
                new List<ResourceIdentifier> { _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False,
                _routingConfigurationValidationData.RoutingRuleCollections).ConfigureAwait(false);
            _routingCollections.Add(collection);

            _routingRules = await collection.CreateRoutingRules(numRules: 10, _routingConfigurationValidationData.RoutingRules).ConfigureAwait(false);

            // Validate the routing configuration
            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData).ConfigureAwait(false);

            // Commit the routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { _routingConfiguration.Id }, NetworkConfigurationDeploymentType.Routing).ConfigureAwait(false);

            // Add a delay to ensure the commit operation is completed before proceeding
            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);

            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, _routingConfigurationValidationData).ConfigureAwait(false);

            // Commit an empty routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.Routing).ConfigureAwait(false);

            // Add a delay to ensure the commit operation is completed before proceeding
            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);

            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, new RoutingConfigurationValidationData(), isEmpty: true).ConfigureAwait(false);

            await NetworkManagerHelperExtensions.ValidateAvnmManagedResourceGroup(_subscription).ConfigureAwait(false);
        }

        [Test]
        public async Task TestRoutingConfigurationCommit_WithMultipleCollections_TargetingSameRouteTable()
        {
            // Create a new routing configuration, routing rule collection, and routing rules
            _routingConfigurationValidationData = new RoutingConfigurationValidationData();
            _routingConfiguration = await _networkManager.CreateRoutingConfigurationAsync("rc-1", _routingConfigurationValidationData).ConfigureAwait(false);

            _routingCollections = new List<RoutingRuleCollectionResource>();

            var collection = await _routingConfiguration.CreateRoutingRuleCollectionAsync(
                "rc-1",
                new List<ResourceIdentifier> { _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False,
                _routingConfigurationValidationData.RoutingRuleCollections).ConfigureAwait(false);
            _routingCollections.Add(collection);

            _routingRules = await collection.CreateRoutingRules(numRules: 10, _routingConfigurationValidationData.RoutingRules).ConfigureAwait(false);

            // Validate the routing configuration
            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData).ConfigureAwait(false);

            // Commit the routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { _routingConfiguration.Id }, NetworkConfigurationDeploymentType.Routing).ConfigureAwait(false);
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, _routingConfigurationValidationData).ConfigureAwait(false);

            // Create another routing collection and rules
            var collection2 = await _routingConfiguration.CreateRoutingRuleCollectionAsync(
                "rc-2",
                new List<ResourceIdentifier> { _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False,
                _routingConfigurationValidationData.RoutingRuleCollections).ConfigureAwait(false);
            _routingCollections.Add(collection2);

            var rules2 = await collection2.CreateRoutingRules(numRules: 10, _routingConfigurationValidationData.RoutingRules).ConfigureAwait(false);
            _routingRules.AddRange(rules2);

            // Validate the routing configuration
            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData).ConfigureAwait(false);

            // Commit the routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { _routingConfiguration.Id }, NetworkConfigurationDeploymentType.Routing).ConfigureAwait(false);

            // Add a delay to ensure the commit operation is completed before proceeding
            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);

            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, _routingConfigurationValidationData).ConfigureAwait(false);

            // Delete one deployed routing rule.
            var ruleToDelete = _routingRules.First();
            var collectionToDelete = _routingCollections.First();

            // Find and Remove the routing rule from the validation data.
            var ruleToDeleteValidationData = _routingConfigurationValidationData.RoutingRules.FirstOrDefault(r => r.Name == ruleToDelete.Data.Name);
            _routingConfigurationValidationData.RoutingRules.Remove(ruleToDeleteValidationData);

            await collectionToDelete.DeleteRoutingRuleAsync(ruleToDelete).ConfigureAwait(false);

            // Add a delay to ensure the commit operation is completed before proceeding
            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);

            // Validate the routing configuration
            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData).ConfigureAwait(false);

            // Commit an empty routing configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.Routing).ConfigureAwait(false);

            // Add a delay to ensure the commit operation is completed before proceeding
            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);

            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, new RoutingConfigurationValidationData(), isEmpty: true).ConfigureAwait(false);

            await NetworkManagerHelperExtensions.ValidateAvnmManagedResourceGroup(_subscription).ConfigureAwait(false);
        }

        /*[Test]
        public async Task TestRoutingConfigurationCommitWithExistingConfiguration()
        {
            var routeTable = await _resourceGroup.CreateRouteTable("rt-1", _location);
            RouteCollection collection = routeTable.GetRoutes();
            string routeName = "route1";
            RouteData data = new RouteData() { AddressPrefix = "10.0.3.0/24", NextHopType = RouteNextHopType.VirtualNetworkGateway };
            ArmOperation<RouteResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, routeName, data);
            RouteResource result = lro.Value;
            await _resourceGroup.AssociateRouteTableToSubnet(_vnets.First(), _subnets.First(), routeTable.Data).ConfigureAwait(false);

            (_routingConfiguration, _routingCollections, _routingRules) = await _networkManager.CreateRoutingConfigurationAsync(
                new List<ResourceIdentifier> { _networkGroupSubnet.Id, _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False);

            await VerifyRoutingConfigurationAsync(_routingConfiguration, _routingCollections, _routingRules);

            var expectedValues = _routingRules.ToDictionary(
                rule => rule.Data.Destination.DestinationAddress,
                rule => (rule.Data.NextHop.NextHopAddress, rule.Data.NextHop.NextHopType));

            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { _routingConfiguration.Id }, NetworkConfigurationDeploymentType.Routing);
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, expectedValues, disableBgpRoutePropagation: DisableBgpRoutePropagation.False);

            expectedValues = new Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)>();
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.Routing);
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, expectedValues, disableBgpRoutePropagation: DisableBgpRoutePropagation.False, isEmpty: true);
        }*/
    }
}
