// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoDBCollectionTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private ResourceIdentifier _mongoDBDatabaseId;
        private MongoDBDatabase _mongoDBDatabase;
        private string _collectionName;

        public MongoDBCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        protected MongoDBCollectionCollection MongoDBCollectionCollection { get => _mongoDBDatabase.GetMongoDBCollections(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            _mongoDBDatabaseId = (await MongoDBDatabaseTests.CreateMongoDBDatabase(SessionRecording.GenerateAssetName("mongodb-"), null, _databaseAccount.GetMongoDBDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _mongoDBDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mongoDBDatabase = await ArmClient.GetMongoDBDatabase(_mongoDBDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            MongoDBCollection collection = await MongoDBCollectionCollection.GetIfExistsAsync(_collectionName);
            if (collection != null)
            {
                await collection.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionCreateAndUpdate()
        {
            var collection = await CreateMongoDBCollection(null);
            Assert.AreEqual(_collectionName, collection.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, collection.Data.Options.Throughput);

            bool ifExists = await MongoDBCollectionCollection.CheckIfExistsAsync(_collectionName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await collection.GetMongoDBCollectionThroughputAsync();
            MongoDBCollection collection2 = await MongoDBCollectionCollection.GetAsync(_collectionName);
            Assert.AreEqual(_collectionName, collection2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, collection2.Data.Options.Throughput);

            VerifyMongoDBCollections(collection, collection2);

            MongoDBCollectionCreateUpdateOptions updateOptions = new MongoDBCollectionCreateUpdateOptions(collection.Id, _collectionName, collection.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, collection.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            collection = await (await MongoDBCollectionCollection.CreateOrUpdateAsync(_collectionName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_collectionName, collection.Data.Resource.Id);
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
            DatabaseAccountMongodbDatabaseCollectionThroughputSetting throughput = await collection.GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountMongodbDatabaseCollectionThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionMigrateToAutoscale()
        {
            var collection = await CreateMongoDBCollection(null);
            DatabaseAccountMongodbDatabaseCollectionThroughputSetting throughput = await collection.GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateMongoDBCollectionToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionMigrateToManual()
        {
            var collection = await CreateMongoDBCollection(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountMongodbDatabaseCollectionThroughputSetting throughput = await collection.GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateMongoDBCollectionToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBCollectionDelete()
        {
            var collection = await CreateMongoDBCollection(null);
            await collection.DeleteAsync();

            collection = await MongoDBCollectionCollection.GetIfExistsAsync(_collectionName);
            Assert.Null(collection);
        }

        protected async Task<MongoDBCollection> CreateMongoDBCollection(AutoscaleSettings autoscale)
        {
            _collectionName = Recording.GenerateAssetName("mongodb-collection-");
            return await CreateMongoDBCollection(_collectionName, autoscale, MongoDBCollectionCollection);
        }
        internal static async Task<MongoDBCollection> CreateMongoDBCollection(string name, AutoscaleSettings autoscale, MongoDBCollectionCollection mongoDBContainerCollection)
        {
            MongoDBCollectionCreateUpdateOptions mongoDBDatabaseCreateUpdateOptions = new MongoDBCollectionCreateUpdateOptions(Resources.Models.Location.WestUS,
                new MongoDBCollectionResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var mongoDBContainerLro = await mongoDBContainerCollection.CreateOrUpdateAsync(name, mongoDBDatabaseCreateUpdateOptions);
            return mongoDBContainerLro.Value;
        }

        private void VerifyMongoDBCollections(MongoDBCollection expectedValue, MongoDBCollection actualValue)
        {
            Assert.AreEqual(expectedValue.Data.Id, actualValue.Data.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
        }
    }
}
