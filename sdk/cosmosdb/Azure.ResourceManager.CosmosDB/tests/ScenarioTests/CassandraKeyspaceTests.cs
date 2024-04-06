// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CassandraKeyspaceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _keyspaceAccountIdentifier;
        private CosmosDBAccountResource _keyspaceAccount;

        private string _keyspaceName;

        public CassandraKeyspaceTests(bool isAsync) : base(isAsync)
        {
        }

        protected CassandraKeyspaceCollection CassandraKeyspaceCollection => _keyspaceAccount.GetCassandraKeyspaces();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>
            {
                new CosmosDBAccountCapability("EnableCassandra", null)
            };
            _keyspaceAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, capabilities)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (_keyspaceAccountIdentifier != null)
            {
                await ArmClient.GetCosmosDBAccountResource(_keyspaceAccountIdentifier).DeleteAsync(WaitUntil.Completed);
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _keyspaceAccount = await ArmClient.GetCosmosDBAccountResource(_keyspaceAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await CassandraKeyspaceCollection.ExistsAsync(_keyspaceName))
            {
                var id = CassandraKeyspaceCollection.Id;
                id = CassandraKeyspaceResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _keyspaceName);
                CassandraKeyspaceResource keyspace = this.ArmClient.GetCassandraKeyspaceResource(id);
                await keyspace.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceCreateAndUpdate()
        {
            var keyspace = await CreateCassandraKeyspace(null);
            Assert.AreEqual(_keyspaceName, keyspace.Data.Resource.KeyspaceName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, keyspace.Data.Options.Throughput);

            bool ifExists = await CassandraKeyspaceCollection.ExistsAsync(_keyspaceName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await keyspace.GetMongoDBCollectionThroughputAsync();
            CassandraKeyspaceResource keyspace2 = await CassandraKeyspaceCollection.GetAsync(_keyspaceName);
            Assert.AreEqual(_keyspaceName, keyspace2.Data.Resource.KeyspaceName);
            //Assert.AreEqual(TestThroughput1, keyspace2.Data.Options.Throughput);

            VerifyCassandraKeyspaces(keyspace, keyspace2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new CassandraKeyspaceCreateOrUpdateContent(AzureLocation.WestUS, keyspace.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            keyspace = (await CassandraKeyspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _keyspaceName, updateOptions)).Value;
            Assert.AreEqual(_keyspaceName, keyspace.Data.Resource.KeyspaceName);
            keyspace2 = await CassandraKeyspaceCollection.GetAsync(_keyspaceName);
            VerifyCassandraKeyspaces(keyspace, keyspace2);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceList()
        {
            var keyspace = await CreateCassandraKeyspace(null);

            var keyspaces = await CassandraKeyspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(keyspaces, Has.Count.EqualTo(1));
            Assert.AreEqual(keyspace.Data.Name, keyspaces[0].Data.Name);

            VerifyCassandraKeyspaces(keyspaces[0], keyspace);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceThroughput()
        {
            var keyspace = await CreateCassandraKeyspace(null);
            CassandraKeyspaceThroughputSettingResource throughput = await keyspace.GetCassandraKeyspaceThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            CassandraKeyspaceThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo(TestThroughput2, null, null, null, null, null, null)))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task CassandraKeyspaceMigrateToAutoscale()
        {
            var keyspace = await CreateCassandraKeyspace(null);

            CassandraKeyspaceThroughputSettingResource throughput = await keyspace.GetCassandraKeyspaceThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateCassandraKeyspaceToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task CassandraKeyspaceMigrateToManual()
        {
            var keyspace = await CreateCassandraKeyspace(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            CassandraKeyspaceThroughputSettingResource throughput = await keyspace.GetCassandraKeyspaceThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateCassandraKeyspaceToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceDelete()
        {
            var keyspace = await CreateCassandraKeyspace(null);
            await keyspace.DeleteAsync(WaitUntil.Completed);

            bool exists = await CassandraKeyspaceCollection.ExistsAsync(_keyspaceName);
            Assert.IsFalse(exists);
        }

        internal async Task<CassandraKeyspaceResource> CreateCassandraKeyspace(AutoscaleSettings autoscale)
        {
            _keyspaceName = Recording.GenerateAssetName("cassandra-keyspace-");
            return await CreateCassandraKeyspace(_keyspaceName, autoscale, _keyspaceAccount.GetCassandraKeyspaces());
        }

        internal static async Task<CassandraKeyspaceResource> CreateCassandraKeyspace(string name, AutoscaleSettings autoscale, CassandraKeyspaceCollection collection)
        {
            var cassandraKeyspaceCreateUpdateOptions = new CassandraKeyspaceCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CassandraKeyspaceResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var keyspaceLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, cassandraKeyspaceCreateUpdateOptions);
            return keyspaceLro.Value;
        }

        private void VerifyCassandraKeyspaces(CassandraKeyspaceResource expectedValue, CassandraKeyspaceResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.KeyspaceName, actualValue.Data.Resource.KeyspaceName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
        }
    }
}
