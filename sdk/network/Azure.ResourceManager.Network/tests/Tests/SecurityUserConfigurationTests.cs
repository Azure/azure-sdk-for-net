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
    public class SecurityUserConfigurationTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private NetworkGroupResource _networkGroupSubnet;
        private readonly AzureLocation _location = AzureLocation.EastUS2;
        private SecurityUserConfigurationResource _securityUserConfiguration;
        private List<SecurityUserRuleCollectionResource> _securityUserCollections;
        private List<SecurityUserRuleResource> _securityUserRules;
        private List<VirtualNetworkResource> _vnets = new();
        private List<SubnetResource> _subnets = new();
        private SubscriptionResource _subscription;
        private const string SubnetNetworkGroupType = "Subnet";

        public SecurityUserConfigurationTests(bool isAsync) : base(isAsync)
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
                new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.SecurityUser });

            // Create test virtual networks and subnets
            // (_vnets, _subnets) = await _resourceGroup.CreateTestVirtualNetworksAsync(_location);
            (_vnets, _subnets) = (new List<VirtualNetworkResource>(), new List<SubnetResource>());
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            // Delete the network manager
            await _resourceGroup.GetNetworkManagers().DeleteAndVerifyResourceAsync(_networkManager.Data.Name);

            // Delete the test virtual networks
            // IEnumerable<Task> deleteVnetsTasks = _vnets.Select(vnet => _resourceGroup.GetVirtualNetworks().DeleteAndVerifyResourceAsync(vnet.Data.Name));
            // await Task.WhenAll(deleteVnetsTasks);

            // Delete the resource group
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }

            // Create network groups for virtual networks and subnets
            _networkGroupSubnet = await _networkManager.CreateNetworkGroupAsync(SubnetNetworkGroupType);

            // Create a securityUser configuration
            (_securityUserConfiguration, _securityUserCollections, _securityUserRules) = await _networkManager.CreateSecurityUserConfigurationAsync
                (new List<ResourceIdentifier>() { _networkGroupSubnet.Id });

            // Add static members to the network groups
            // await _networkGroupSubnet.AddSubnetStaticMemberToNetworkGroup(_subnets);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            // Delete the securityUser configuration
            await _networkManager.DeleteSecurityUserConfigurationAsync(_securityUserConfiguration);

            // Delete the network groups
            await _networkManager.DeleteNetworkGroupAsync(_networkGroupSubnet);

            await StopSessionRecordingAsync();
        }

        [Test]
        [RecordedTest]
        public async Task TestSecurityUserConfigurationCrud()
        {
            // Assert
            // Fetch the securityUser configuration
            Response<SecurityUserConfigurationResource> fetchedSecurityUserConfiguration = await _networkManager.GetSecurityUserConfigurations().GetAsync(_securityUserConfiguration.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedSecurityUserConfiguration.Value.Data.ProvisioningState);

            // Fetch the securityUser rule collection
            Response<SecurityUserRuleCollectionResource> fetchedSecurityUserRuleCollection = await fetchedSecurityUserConfiguration.Value.GetSecurityUserRuleCollections().GetAsync(_securityUserCollections.First().Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedSecurityUserRuleCollection.Value.Data.ProvisioningState);
            Assert.AreEqual(2, fetchedSecurityUserRuleCollection.Value.Data.AppliesToGroups.Count);

            // Validate each securityUser rule
            SecurityUserRuleCollection fetchedSecurityUserRules = fetchedSecurityUserRuleCollection.Value.GetSecurityUserRules();
            await foreach (SecurityUserRuleResource fetchedRule in fetchedSecurityUserRules)
            {
                // Fetch the created security user rules with the id and validate
                SecurityUserRuleResource createdRule = _securityUserRules.FirstOrDefault(rule => rule.Data.Id == fetchedRule.Id);
                Assert.IsNotNull(createdRule);

                NetworkManagerHelperExtensions.ValidateSecurityUserRule(createdRule, fetchedRule);
            }
        }

        [Test]
        [RecordedTest]
        public async Task TestSecurityUserConfigurationCommit()
        {
            // Act
            // Commit the securityUser configuration
            await _networkManager.PostNetworkManagerCommitAsync(
                _location,
                new List<string> { _securityUserConfiguration.Id },
                NetworkConfigurationDeploymentType.SecurityUser);

            // Assert
            // Validate all the routes within the route tables associated with the subnets
            await _resourceGroup.ValidateNsgAsync(_subscription, _vnets);

            // Act
            // Commit an empty securityUser configuration
            await _networkManager.PostNetworkManagerCommitAsync(_location, new List<string> { }, NetworkConfigurationDeploymentType.SecurityUser);

            // Assert
            // Validate that the route tables are empty
            await _resourceGroup.ValidateNsgAsync(_subscription, _vnets, isEmpty: true);
        }
    }
}
