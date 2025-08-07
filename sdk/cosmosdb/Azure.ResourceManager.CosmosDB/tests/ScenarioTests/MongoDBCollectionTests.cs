// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoDBCollectionTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _mongoDBDatabaseId;
        private MongoDBDatabaseResource _mongoDBDatabase;
        private string _collectionName;

        public MongoDBCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        protected MongoDBCollectionCollection MongoDBCollectionCollection => _mongoDBDatabase.GetMongoDBCollections();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            _mongoDBDatabaseId = (await MongoDBDatabaseTests.CreateMongoDBDatabase(SessionRecording.GenerateAssetName("mongodb-"), null, _databaseAccount.GetMongoDBDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await _mongoDBDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _mongoDBDatabase = await ArmClient.GetMongoDBDatabaseResource(_mongoDBDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await MongoDBCollectionCollection.ExistsAsync(_collectionName))
                {
                    var id = MongoDBCollectionCollection.Id;
                    id = MongoDBCollectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _collectionName);
                    MongoDBCollectionResource collection = this.ArmClient.GetMongoDBCollectionResource(id);
                    await collection.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionCreateAndUpdate()
        {
            var collection = await CreateMongoDBCollection(null);
            Assert.AreEqual(_collectionName, collection.Data.Resource.CollectionName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, collection.Data.Options.Throughput);

            bool ifExists = await MongoDBCollectionCollection.ExistsAsync(_collectionName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await collection.GetMongoDBCollectionThroughputAsync();
            MongoDBCollectionResource collection2 = await MongoDBCollectionCollection.GetAsync(_collectionName);
            Assert.AreEqual(_collectionName, collection2.Data.Resource.CollectionName);
            //Assert.AreEqual(TestThroughput1, collection2.Data.Options.Throughput);

            VerifyMongoDBCollections(collection, collection2);

            var updateOptions = new MongoDBCollectionCreateOrUpdateContent(collection.Id, _collectionName, collection.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, collection.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, default(ManagedServiceIdentity), null);

            collection = await (await MongoDBCollectionCollection.CreateOrUpdateAsync(WaitUntil.Started, _collectionName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_collectionName, collection.Data.Resource.CollectionName);
            collection2 = await MongoDBCollectionCollection.GetAsync(_collectionName);
            VerifyMongoDBCollections(collection, collection2);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionList()
        {
            var collection = await CreateMongoDBCollection(null);

            var collections = await MongoDBCollectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(collections, Has.Count.EqualTo(1));
            Assert.AreEqual(collection.Data.Name, collections[0].Data.Name);

            VerifyMongoDBCollections(collections[0], collection);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionThroughput()
        {
            var collection = await CreateMongoDBCollection(null);
            MongoDBCollectionThroughputSettingResource throughput = await collection.GetMongoDBCollectionThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            MongoDBCollectionThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task MongoDBCollectionMigrateToAutoscale()
        {
            var collection = await CreateMongoDBCollection(null);
            MongoDBCollectionThroughputSettingResource throughput = await collection.GetMongoDBCollectionThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateMongoDBCollectionToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task MongoDBCollectionMigrateToManual()
        {
            var collection = await CreateMongoDBCollection(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            MongoDBCollectionThroughputSettingResource throughput = await collection.GetMongoDBCollectionThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateMongoDBCollectionToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionDelete()
        {
            var collection = await CreateMongoDBCollection(null);
            await collection.DeleteAsync(WaitUntil.Completed);

            bool exists = await MongoDBCollectionCollection.ExistsAsync(_collectionName);
            Assert.IsFalse(exists);
        }

        internal async Task<MongoDBCollectionResource> CreateMongoDBCollection(AutoscaleSettings autoscale)
        {
            _collectionName = Recording.GenerateAssetName("mongodb-collection-");
            return await CreateMongoDBCollection(_collectionName, autoscale, MongoDBCollectionCollection);
        }
        internal static async Task<MongoDBCollectionResource> CreateMongoDBCollection(string name, AutoscaleSettings autoscale, MongoDBCollectionCollection mongoDBContainerCollection)
        {
            var mongoDBDatabaseCreateUpdateOptions = new MongoDBCollectionCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.MongoDBCollectionResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var mongoDBContainerLro = await mongoDBContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, mongoDBDatabaseCreateUpdateOptions);
            return mongoDBContainerLro.Value;
        }

        private void VerifyMongoDBCollections(MongoDBCollectionResource expectedValue, MongoDBCollectionResource actualValue)
        {
            Assert.AreEqual(expectedValue.Data.Id, actualValue.Data.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.CollectionName, actualValue.Data.Resource.CollectionName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
        }
    }
}
