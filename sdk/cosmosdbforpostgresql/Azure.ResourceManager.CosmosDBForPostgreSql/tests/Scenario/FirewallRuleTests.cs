// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Tests
{
    public class FirewallRuleTests : CosmosDBForPostgreSqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ClusterResource _cluster;
        private string _rgName;
        private ResourceIdentifier _clusterIdentifier;

        public FirewallRuleTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("test-rg-");
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, _rgName, new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            ClusterCollection cls =  rg.GetClusters();

            string clusterName = SessionRecording.GenerateAssetName("cosmospgnet");
            var data = new ClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                EnableHa = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                CoordinatorEnablePublicIPAccess = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                EnableShardsOnCoordinator = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await cls.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            _cluster = lro.Value;
            _clusterIdentifier = lro.Value.Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task Setup()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _cluster = await _resourceGroup.GetClusterAsync(_clusterIdentifier.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGet()
        {
            // Create
            string firewallRuleName = Recording.GenerateAssetName("fwrule");
            var data = new FirewallRuleData("0.0.0.0", "0.0.0.1");
            FirewallRuleCollection firewallRules = _cluster.GetFirewallRules();
            var lro = await firewallRules.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, data);
            FirewallRuleResource firewallRule = lro.Value;
            Assert.AreEqual(firewallRuleName, firewallRule.Data.Name);

            // Get
            FirewallRuleResource firewallRuleFromGet = await _cluster.GetFirewallRuleAsync(firewallRuleName);
            Assert.AreEqual(firewallRuleName, firewallRuleFromGet.Data.Name);

            // List
            await foreach (FirewallRuleResource firewallRuleFromList in firewallRules)
            {
                Assert.AreEqual(firewallRuleName, firewallRuleFromList.Data.Name);
            }
            //await firewallRuleFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdate()
        {
            // Create
            string firewallRuleName = Recording.GenerateAssetName("fwrule");
            var data = new FirewallRuleData("0.0.0.0", "0.0.0.1");
            FirewallRuleCollection firewallRules = _cluster.GetFirewallRules();
            var lro = await firewallRules.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, data);
            FirewallRuleResource firewallRule = lro.Value;
            Assert.AreEqual(firewallRuleName, firewallRule.Data.Name);

            // Update
            var updatedData = new FirewallRuleData("0.0.0.0", "0.0.0.2");
            var updatedLro = await firewallRules.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, updatedData);
            FirewallRuleResource updatedFirewallRule = updatedLro.Value;

            FirewallRuleResource firewallRuleFromGet = await _cluster.GetFirewallRuleAsync(firewallRuleName);
            Assert.AreEqual(updatedData, firewallRuleFromGet.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            // Create
            string firewallRuleName = Recording.GenerateAssetName("fwrule");
            var data = new FirewallRuleData("0.0.0.0", "0.0.0.1");
            FirewallRuleCollection firewallRules = _cluster.GetFirewallRules();
            var lro = await firewallRules.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, data);
            FirewallRuleResource firewallRule = lro.Value;
            Assert.AreEqual(firewallRuleName, firewallRule.Data.Name);

            // Delete
            FirewallRuleResource firewallRuleFromGet = await _cluster.GetFirewallRuleAsync(firewallRuleName);
            await firewallRuleFromGet.DeleteAsync(WaitUntil.Completed);

            // List
            Assert.IsEmpty(_cluster.GetFirewallRules());
        }
    }
}
