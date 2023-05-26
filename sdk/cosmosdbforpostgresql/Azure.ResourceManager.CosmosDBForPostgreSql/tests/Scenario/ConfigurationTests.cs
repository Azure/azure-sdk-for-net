// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Tests
{
    public class ConfigurationTests : CosmosDBForPostgreSqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ClusterResource _cluster;
        private string _rgName;
        private ResourceIdentifier _clusterIdentifier;

        public ConfigurationTests(bool isAsync)
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
                NodeCount = 2,
                CoordinatorServerEdition = "GeneralPurpose",
                CoordinatorEnablePublicIPAccess = true,
                NodeServerEdition = "MemoryOptimized",
                NodeStorageQuotaInMb = 524288,
                NodeVCores = 4,
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
        public async Task UpdateCoordinatorConfiguration()
        {
            // Update Configuration
            string configurationName = "array_nulls";
            var data = new ServerConfigurationData()
            {
                Value = "false"
            };

            ServerGroupsv2CoordinatorConfigurationCollection configurationCollection = _cluster.GetServerGroupsv2CoordinatorConfigurations();
            var lro = await configurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, data);
            ServerGroupsv2CoordinatorConfigurationResource configuration = lro.Value;
            Assert.AreEqual(data.Value, configuration.Data.Value);

            // Get
            ServerGroupsv2CoordinatorConfigurationResource configurationFromGet = await _cluster.GetServerGroupsv2CoordinatorConfigurationAsync(configurationName);
            Assert.AreEqual(data.Value, configurationFromGet.Data.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateNodeConfiguration()
        {
            // Update Configuration
            string configurationName = "array_nulls";
            var data = new ServerConfigurationData()
            {
                Value = "false"
            };

            ServerGroupsv2NodeConfigurationCollection configurationCollection = _cluster.GetServerGroupsv2NodeConfigurations();
            var lro = await configurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, data);
            ServerGroupsv2NodeConfigurationResource configuration = lro.Value;
            Assert.AreEqual(data.Value, configuration.Data.Value);

            // Get
            ServerGroupsv2NodeConfigurationResource configurationFromGet = await _cluster.GetServerGroupsv2NodeConfigurationAsync(configurationName);
            Assert.AreEqual(data.Value, configurationFromGet.Data.Value);
        }
    }
}
