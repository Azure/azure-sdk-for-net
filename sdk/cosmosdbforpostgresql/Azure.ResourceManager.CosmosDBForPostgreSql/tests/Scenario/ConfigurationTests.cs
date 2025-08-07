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
        private string _rgName;
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        private string _clusterName;
        private CosmosDBForPostgreSqlClusterResource _cluster;
        private ResourceIdentifier _clusterIdentifier;

        public ConfigurationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("test-rg-");
            _clusterName = SessionRecording.GenerateAssetName("cosmos-pg-net-");
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), _rgName);
                _clusterIdentifier = CosmosDBForPostgreSqlClusterResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), _rgName, _clusterName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, _rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    ResourceGroupResource rg = rgLro.Value;
                    CosmosDBForPostgreSqlClusterCollection cls = rg.GetCosmosDBForPostgreSqlClusters();

                    var data = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
                    {
                        CoordinatorVCores = 4,
                        IsHAEnabled = false,
                        CoordinatorStorageQuotaInMb = 524288,
                        NodeCount = 2,
                        CoordinatorServerEdition = "GeneralPurpose",
                        IsCoordinatorPublicIPAccessEnabled = true,
                        NodeServerEdition = "MemoryOptimized",
                        NodeStorageQuotaInMb = 524288,
                        NodeVCores = 4,
                        PostgresqlVersion = "14",
                        CitusVersion = "11.1",
                        AdministratorLoginPassword = "P4ssw@rd1234",
                        IsShardsOnCoordinatorEnabled = true,
                        PreferredPrimaryZone = "1"
                    };

                    var lro = await cls.CreateOrUpdateAsync(WaitUntil.Completed, _clusterName, data);
                    _cluster = lro.Value;
                    _clusterIdentifier = lro.Value.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }
            try
            {
                using (Recording.DisableRecording())
                {
                    await foreach (var cluster in _resourceGroup.GetCosmosDBForPostgreSqlClusters().GetAllAsync())
                    {
                        await cluster.DeleteAsync(WaitUntil.Completed);
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        [SetUp]
        public async Task Setup()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _cluster = await _resourceGroup.GetCosmosDBForPostgreSqlClusterAsync(_clusterIdentifier.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateCoordinatorConfiguration()
        {
            // Update Configuration
            string configurationName = "array_nulls";
            var data = new CosmosDBForPostgreSqlServerConfigurationData()
            {
                Value = "false"
            };

            CosmosDBForPostgreSqlCoordinatorConfigurationCollection configurationCollection = _cluster.GetCosmosDBForPostgreSqlCoordinatorConfigurations();
            var lro = await configurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, data);
            CosmosDBForPostgreSqlCoordinatorConfigurationResource configuration = lro.Value;
            Assert.AreEqual(data.Value, configuration.Data.Value);

            // Get
            CosmosDBForPostgreSqlCoordinatorConfigurationResource configurationFromGet = await _cluster.GetCosmosDBForPostgreSqlCoordinatorConfigurationAsync(configurationName);
            Assert.AreEqual(data.Value, configurationFromGet.Data.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateNodeConfiguration()
        {
            // Update Configuration
            string configurationName = "array_nulls";
            var data = new CosmosDBForPostgreSqlServerConfigurationData()
            {
                Value = "false"
            };

            CosmosDBForPostgreSqlNodeConfigurationCollection configurationCollection = _cluster.GetCosmosDBForPostgreSqlNodeConfigurations();
            var lro = await configurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, data);
            CosmosDBForPostgreSqlNodeConfigurationResource configuration = lro.Value;
            Assert.AreEqual(data.Value, configuration.Data.Value);

            // Get
            CosmosDBForPostgreSqlNodeConfigurationResource configurationFromGet = await _cluster.GetCosmosDBForPostgreSqlNodeConfigurationAsync(configurationName);
            Assert.AreEqual(data.Value, configurationFromGet.Data.Value);
        }
    }
}
