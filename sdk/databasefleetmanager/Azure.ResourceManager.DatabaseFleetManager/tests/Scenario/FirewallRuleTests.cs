// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DatabaseFleetManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DatabaseFleetManager.Tests.Scenario
{
    public class FirewallRuleTests : DatabaseFleetManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public FirewallRuleTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroupName = Recording.GenerateAssetName("sdk-test-rg");
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, resourceGroupName, DefaultLocation);
        }

        [TearDown]
        public async Task TearDown()
        {
            List<FleetResource> fleets = await _resourceGroup.GetFleets().GetAllAsync().ToEnumerableAsync();
            foreach (FleetResource fleet in fleets)
            {
                await fleet.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            List<FirewallRuleResource> firewallRules = await fleetspace.GetFirewallRules().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(firewallRules);
            Assert.AreEqual(1, firewallRules.Count);
            Assert.AreEqual(firewallRuleName, firewallRules[0].Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FirewallRuleResource firewallRule = await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            Assert.IsNotNull(firewallRule?.Data);
            Assert.AreEqual(firewallRuleName, firewallRule.Data.Name);
            Assert.AreEqual(DefaultFirewallRuleProperties.StartIPAddress, firewallRule.Data.Properties.StartIPAddress);
            Assert.AreEqual(DefaultFirewallRuleProperties.EndIPAddress, firewallRule.Data.Properties.EndIPAddress);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            await CreateFleetAsync(_resourceGroup, fleetName);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            Assert.IsTrue((await fleetspace.GetFirewallRules().ExistsAsync(firewallRuleName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            await CreateFleetAsync(_resourceGroup, fleetName);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            Response<FirewallRuleResource> firewallRule = await fleetspace.GetFirewallRules().GetAsync(firewallRuleName);

            Assert.IsNotNull(firewallRule.Value.Data);
            Assert.AreEqual(firewallRuleName, firewallRule.Value.Data.Name);
            Assert.AreEqual(DefaultFirewallRuleProperties.StartIPAddress, firewallRule.Value.Data.Properties.StartIPAddress);
            Assert.AreEqual(DefaultFirewallRuleProperties.EndIPAddress, firewallRule.Value.Data.Properties.EndIPAddress);
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            Response<FleetResource> fleet = await _resourceGroup.GetFleets().GetAsync(fleetName);
            Response<FleetspaceResource> fleetspace = await fleet.Value.GetFleetspaces().GetAsync(fleetspaceName);
            Response<FirewallRuleResource> firewallRule = await fleetspace.Value.GetFirewallRules().GetAsync(firewallRuleName);

            var startIpAddress = "1.1.1.1";
            var endIpAddress = "2.2.2.2";

            ArmOperation<FirewallRuleResource> updatedFirewallRule = await firewallRule.Value.UpdateAsync(WaitUntil.Completed, new FirewallRuleData
            {
                Properties = new FirewallRuleProperties
                {
                    StartIPAddress = startIpAddress,
                    EndIPAddress = endIpAddress
                }
            });

            Assert.IsNotNull(updatedFirewallRule.Value.Data);
            Assert.AreEqual(startIpAddress, updatedFirewallRule.Value.Data.Properties.StartIPAddress);
            Assert.AreEqual(endIpAddress, updatedFirewallRule.Value.Data.Properties.EndIPAddress);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var firewallRuleName = Recording.GenerateAssetName("firewallRule");

            await CreateFleetAsync(_resourceGroup, fleetName);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateFirewallRuleAsync(_resourceGroup, fleetName, fleetspaceName, firewallRuleName, DefaultFirewallRuleProperties);

            List<FirewallRuleResource> firewallRules = await fleetspace.GetFirewallRules().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, firewallRules.Count);

            await firewallRules[0].DeleteAsync(WaitUntil.Completed);

            firewallRules = await fleetspace.GetFirewallRules().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, firewallRules.Count);
        }
    }
}
