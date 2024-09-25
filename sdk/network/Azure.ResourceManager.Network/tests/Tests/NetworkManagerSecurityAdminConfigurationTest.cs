// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkManagerSecurityAdminConfigurationTest : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private NetworkGroupResource _networkGroup;
        private List<VirtualNetworkResource> _vnets = new();
        private SubscriptionResource _subscription;
        private SecurityAdminConfigurationResource _securityAdminConfiguration;
        private AdminRuleGroupResource _securityAdminRuleCollection;
        private BaseAdminRuleResource _securityRule;
        private string _networkManagerName;
        private string _securityAdminConfigName;
        private string _networkGroupName;
        private string _staticMemberName;
        private string _networkSecurityRuleCollectionName;
        private string _networkSecurityRuleName;
        private const string VNetGroupType = "VirtualNetwork";
        private readonly AzureLocation _location = AzureLocation.EastUS2;

        public NetworkManagerSecurityAdminConfigurationTest(bool isAsync) : base(isAsync) { }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            // Get the default subscription
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            // Create a resource group
            string resourceGroupName = SessionRecording.GenerateAssetName("secadmin-tests-RG-");
            _resourceGroup = await _subscription.CreateResourceGroupAsync(resourceGroupName, _location);

            // Create a network manager
            _networkManagerName = SessionRecording.GenerateAssetName("nm-");
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(
                _networkManagerName,
                _location,
                new List<string> { _subscription.Data.Id },
                new List<NetworkConfigurationDeploymentType> { NetworkConfigurationDeploymentType.SecurityAdmin });
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (_vnets != null && _vnets.Any())
            {
                foreach (var vnet in _vnets)
                {
                    await vnet.DeleteAsync(WaitUntil.Completed);
                }
            }

            // Delete other resources
            if (_networkManager != null)
            {
                if (_networkGroup != null)
                {
                    await _networkManager.DeleteNetworkGroupAsync(_networkGroup);
                }
                await _networkManager.DeleteAsync(WaitUntil.Completed);
            }

            if (_resourceGroup != null)
            {
                await _resourceGroup.DeleteAsync(WaitUntil.Completed);
            }

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _networkGroupName = SessionRecording.GenerateAssetName("networkGroup-");
            _networkGroup = await _networkManager.CreateNetworkGroupAsync(VNetGroupType);

            (_vnets, _) = await _resourceGroup.CreateTestVirtualNetworksAsync(_location);

            _securityAdminConfigName = SessionRecording.GenerateAssetName("secAdminConfig-");
            _staticMemberName = SessionRecording.GenerateAssetName("staticMember-");
            _networkSecurityRuleCollectionName = SessionRecording.GenerateAssetName("ruleCollection-");
            _networkSecurityRuleName = SessionRecording.GenerateAssetName("rule-");

            // Add static members and commit configuration
            await _networkGroup.AddVnetStaticMemberToNetworkGroup(_vnets);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            if (_networkGroup != null)
            {
                await _networkManager.DeleteNetworkGroupAsync(_networkGroup);
            }

            if (_vnets != null && _vnets.Any())
            {
                foreach (var vnet in _vnets)
                {
                    await vnet.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task TestSecurityAdminConfigurationCrud()
        {
            Response<SecurityAdminConfigurationResource> fetchedSecurityAdminConfiguration = await _networkManager.GetSecurityAdminConfigurations().GetAsync(_securityAdminConfiguration.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedSecurityAdminConfiguration.Value.Data.ProvisioningState);

            // Fetch the rule collection
            Response<AdminRuleGroupResource> fetchedSecurityAdminRuleCollection = await fetchedSecurityAdminConfiguration.Value.GetAdminRuleGroups().GetAsync(_securityAdminRuleCollection.Data.Name);
            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedSecurityAdminRuleCollection.Value.Data.ProvisioningState);
            Assert.AreEqual(2, fetchedSecurityAdminRuleCollection.Value.Data.AppliesToGroups.Count);

            // Validate each rule
            AdminRuleGroupCollection fetchedSecurityAdminRules = fetchedSecurityAdminRuleCollection.Value.GetBaseAdminRules();
            await foreach (BaseAdminRuleResource fetchedRule in fetchedSecurityAdminRules)
            {
                // Fetch the created security rules with the id and validate
                BaseAdminRuleResource createdRule = _securityRule.Data((rule => rule.Data.Id == fetchedRule.Id));
                Assert.IsNotNull(createdRule);

                NetworkManagerSecurityAdminConfigurationHelperExtensions.ValidateSecurityAdminRule(createdRule, fetchedRule);
            }
        }
    }
}
