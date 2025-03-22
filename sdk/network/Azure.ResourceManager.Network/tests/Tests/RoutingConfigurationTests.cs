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
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            _resourceGroup = await _subscription.CreateResourceGroupAsync(SessionRecording.GenerateAssetName("rg-"), _location);
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(SessionRecording.GenerateAssetName("nm-"), _location, new List<string> { _subscription.Data.Id }, new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.Routing });
            _vnets = await _resourceGroup.CreateTestVirtualNetworksAsync(_location, numVnets: 2, numSubnetsPerVnet: 2).ConfigureAwait(false);
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.GetNetworkManagers().DeleteAndVerifyResourceAsync(_networkManager.Data.Name);
            IEnumerable<Task> deleteVnetsTasks = _vnets.Select(vnet => _resourceGroup.GetVirtualNetworks().DeleteAndVerifyResourceAsync(vnet.Data.Name));
            await Task.WhenAll(deleteVnetsTasks);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }

            _networkGroupVnet = await _networkManager.CreateNetworkGroupAsync(VirtualNetworkGroupType);
            _networkGroupSubnet = await _networkManager.CreateNetworkGroupAsync(SubnetNetworkGroupType);
            await _networkGroupVnet.AddVnetStaticMemberToNetworkGroup(_vnets);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await _networkManager.DeleteRoutingConfigurationAsync(_routingConfiguration);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupSubnet);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupVnet);
            await StopSessionRecordingAsync();
        }

        [Test]
        [RecordedTest]
        public async Task TestRoutingConfigurationCrud()
        {
            (_routingConfiguration, _routingCollections, _routingRules, _routingConfigurationValidationData) = await _networkManager.CreateRoutingConfigurationAsync(
                new List<ResourceIdentifier> { _networkGroupSubnet.Id, _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False,
                numRules: 10);

            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData);
        }

        [Test]
        [RecordedTest]
        public async Task TestRoutingConfigurationCommit()
        {
            (_routingConfiguration, _routingCollections, _routingRules, _routingConfigurationValidationData) = await _networkManager.CreateRoutingConfigurationAsync(
                new List<ResourceIdentifier> { _networkGroupSubnet.Id, _networkGroupVnet.Id },
                DisableBgpRoutePropagation.False);

            await _networkManager.VerifyRoutingConfigurationAsync(_routingConfigurationValidationData);

            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { _routingConfiguration.Id }, NetworkConfigurationDeploymentType.Routing);
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, _routingConfigurationValidationData);

            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.Routing);
            await _resourceGroup.ValidateRouteTablesAsync(_subscription, _vnets, new RoutingConfigurationValidationData(), isEmpty: true);
        }

        /*[Test]
        [RecordedTest]
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
