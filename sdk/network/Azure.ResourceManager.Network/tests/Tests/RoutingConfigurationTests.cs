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
        private List<VirtualNetworkResource> _vnets = new();
        private List<SubnetResource> _subnets = new();
        private const string VirtualNetworkGroupType = "VirtualNetwork";
        private const string SubnetNetworkGroupType = "Subnet";

        public RoutingConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            // Create resource group
            string resourceGroupName = SessionRecording.GenerateAssetName("rg-");
            _resourceGroup = await subscription.CreateResourceGroupAsync(resourceGroupName, _location);

            // Create network manager
            string networkManagerName = SessionRecording.GenerateAssetName("nm-");
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(networkManagerName, _location, new List<string> { subscription.Data.Id }, new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.Routing });

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
            _networkGroupVnet = await _networkManager.CreateNetworkGroupAsync(VirtualNetworkGroupType);
            _networkGroupSubnet = await _networkManager.CreateNetworkGroupAsync(SubnetNetworkGroupType);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await _networkManager.DeleteRoutingConfigurationAsync(_routingConfiguration);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupSubnet);
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupVnet);
        }

        [Test]
        [RecordedTest]
        public async Task RoutingConfigurationCrudWithVnetMemberType()
        {
            // Arrange
            // Create routing configuration
            _routingConfiguration = await _networkManager.CreateRoutingConfigurationAsync();

            // Create routing rule collection
            RoutingRuleCollectionResource routingCollection = await _routingConfiguration.CreateRoutingRuleCollectionAsync(new List<ResourceIdentifier>() { _networkGroupVnet.Id });

            // Create multiple routing rules
            List<RoutingRuleResource> routingRules = new()
            {
                await routingCollection.CreateRoutingRuleAsync("rule1", "10.1.1.0/24", RoutingRuleDestinationType.AddressPrefix, "20.1.1.1", RoutingRuleNextHopType.VirtualAppliance),
                await routingCollection.CreateRoutingRuleAsync("rule2", "10.2.2.0/24", RoutingRuleDestinationType.AddressPrefix, "20.2.2.2", RoutingRuleNextHopType.VirtualAppliance)
            };

            // Expected values for validation
            var expectedValues = new Dictionary<string, (string NextHopAddress, RoutingRuleNextHopType NextHopType)>();
            foreach (RoutingRuleResource rule in routingRules)
            {
                expectedValues.Add(rule.Data.Destination.DestinationAddress, (rule.Data.NextHop.NextHopAddress, rule.Data.NextHop.NextHopType));
            }

            // Act
            // Fetch the routing configuration
            Response<RoutingConfigurationResource> fetchedRoutingConfiguration = await _networkManager.GetRoutingConfigurations().GetAsync(_routingConfiguration.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedRoutingConfiguration.Value.Data.ProvisioningState);

            // Fetch the routing rule collection
            Response<RoutingRuleCollectionResource> fetchedRoutingRuleCollection = await fetchedRoutingConfiguration.Value.GetRoutingRuleCollections().GetAsync(routingCollection.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedRoutingRuleCollection.Value.Data.ProvisioningState);
            Assert.AreEqual(_networkGroupVnet.Id, fetchedRoutingRuleCollection.Value.Data.AppliesTo.First().NetworkGroupId);
            Assert.AreEqual("True", fetchedRoutingRuleCollection.Value.Data.DisableBgpRoutePropagation);

            // Assert
            // Validate each routing rule
            var fetchedRoutingRules = fetchedRoutingRuleCollection.Value.GetRoutingRules();
            await foreach (RoutingRuleResource rule in fetchedRoutingRules)
            {
                NetworkManagerHelperExtensions.ValidateRoutingRule(rule, expectedValues);
            }
        }
    }
}
