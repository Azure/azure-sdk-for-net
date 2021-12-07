// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CassandraKeyspaceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _keyspaceAccountIdentifier;
        private DatabaseAccount _keyspaceAccount;

        private string _keyspaceName;

        public CassandraKeyspaceTests(bool isAsync) : base(isAsync)
        {
        }

        protected CassandraKeyspaceCollection CassandraKeyspaceCollection { get => _keyspaceAccount.GetCassandraKeyspaces(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _keyspaceAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new DatabaseAccountCapability("EnableCassandra"))).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            if (_keyspaceAccountIdentifier != null)
            {
                ArmClient.GetDatabaseAccount(_keyspaceAccountIdentifier).Delete();
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _keyspaceAccount = await ArmClient.GetDatabaseAccount(_keyspaceAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            CassandraKeyspace keyspace = await CassandraKeyspaceCollection.GetIfExistsAsync(_keyspaceName);
            if (keyspace != null)
            {
                await keyspace.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceCreateAndUpdate()
        {
            var keyspace = await CreateCassandraKeyspace(null);
            Assert.AreEqual(_keyspaceName, keyspace.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, keyspace.Data.Options.Throughput);

            bool ifExists = await CassandraKeyspaceCollection.CheckIfExistsAsync(_keyspaceName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await keyspace.GetMongoDBCollectionThroughputAsync();
            CassandraKeyspace keyspace2 = await CassandraKeyspaceCollection.GetAsync(_keyspaceName);
            Assert.AreEqual(_keyspaceName, keyspace2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, keyspace2.Data.Options.Throughput);

            VerifyCassandraKeyspaces(keyspace, keyspace2);

            CassandraKeyspaceCreateUpdateOptions updateOptions = new CassandraKeyspaceCreateUpdateOptions(keyspace.Id, _keyspaceName, keyspace.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, keyspace.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            keyspace = await (await CassandraKeyspaceCollection.CreateOrUpdateAsync(_keyspaceName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_keyspaceName, keyspace.Data.Resource.Id);
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
            DatabaseAccountCassandraKeyspaceThroughputSetting throughput = await keyspace.GetDatabaseAccountCassandraKeyspaceThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountCassandraKeyspaceThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceMigrateToAutoscale()
        {
            var keyspace = await CreateCassandraKeyspace(null);

            DatabaseAccountCassandraKeyspaceThroughputSetting throughput = await keyspace.GetDatabaseAccountCassandraKeyspaceThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateCassandraKeyspaceToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceMigrateToManual()
        {
            var keyspace = await CreateCassandraKeyspace(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountCassandraKeyspaceThroughputSetting throughput = await keyspace.GetDatabaseAccountCassandraKeyspaceThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateCassandraKeyspaceToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraKeyspaceDelete()
        {
            var keyspace = await CreateCassandraKeyspace(null);
            await keyspace.DeleteAsync();

            keyspace = await CassandraKeyspaceCollection.GetIfExistsAsync(_keyspaceName);
            Assert.Null(keyspace);
        }

        protected async Task<CassandraKeyspace> CreateCassandraKeyspace(AutoscaleSettings autoscale)
        {
            _keyspaceName = Recording.GenerateAssetName("cassandra-keyspace-");
            return await CreateCassandraKeyspace(_keyspaceName, autoscale, _keyspaceAccount.GetCassandraKeyspaces());
        }

        internal static async Task<CassandraKeyspace> CreateCassandraKeyspace(string name, AutoscaleSettings autoscale, CassandraKeyspaceCollection collection)
        {
            CassandraKeyspaceCreateUpdateOptions cassandraKeyspaceCreateUpdateOptions = new CassandraKeyspaceCreateUpdateOptions(Resources.Models.Location.WestUS,
                new CassandraKeyspaceResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var keyspaceLro = await collection.CreateOrUpdateAsync(name, cassandraKeyspaceCreateUpdateOptions);
            return keyspaceLro.Value;
        }

        private void VerifyCassandraKeyspaces(CassandraKeyspace expectedValue, CassandraKeyspace actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.Type, actualValue.Data.Type);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
        }
    }
}
