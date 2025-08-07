// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlStoredProcedureTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private CosmosDBSqlContainerResource _sqlContainer;
        private string _storedProcedureName;

        public SqlStoredProcedureTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlStoredProcedureCollection SqlStoredProcedureCollection => _sqlContainer.GetCosmosDBSqlStoredProcedures();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            IgnoreTestInNonWindowsAgent();

            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetCosmosDBSqlDatabases());

            _sqlContainerId = (await SqlContainerTests.CreateSqlContainer(SessionRecording.GenerateAssetName("sql-container-"), null, _sqlDatabase.GetCosmosDBSqlContainers())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await _sqlContainer.DeleteAsync(WaitUntil.Completed);
                await _sqlDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetCosmosDBSqlContainerResource(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await SqlStoredProcedureCollection.ExistsAsync(_storedProcedureName))
                {
                    var id = SqlStoredProcedureCollection.Id;
                    id = CosmosDBSqlStoredProcedureResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Parent.Name, id.Parent.Name, id.Name, _storedProcedureName);
                    CosmosDBSqlStoredProcedureResource storedProcedure = this.ArmClient.GetCosmosDBSqlStoredProcedureResource(id);
                    await storedProcedure.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlStoredProcedureCreateAndUpdate()
        {
            var storedProcedure = await CreateSqlStoredProcedure(null);
            Assert.AreEqual(_storedProcedureName, storedProcedure.Data.Resource.StoredProcedureName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlStoredProcedureCollection.ExistsAsync(_storedProcedureName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            CosmosDBSqlStoredProcedureResource storedProcedure2 = await SqlStoredProcedureCollection.GetAsync(_storedProcedureName);
            Assert.AreEqual(_storedProcedureName, storedProcedure2.Data.Resource.StoredProcedureName);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlStoredProcedures(storedProcedure, storedProcedure2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new CosmosDBSqlStoredProcedureCreateOrUpdateContent(AzureLocation.WestUS, storedProcedure.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            storedProcedure = (await SqlStoredProcedureCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storedProcedureName, updateOptions)).Value;
            Assert.AreEqual(_storedProcedureName, storedProcedure.Data.Resource.StoredProcedureName);
            storedProcedure2 = await SqlStoredProcedureCollection.GetAsync(_storedProcedureName);
            VerifySqlStoredProcedures(storedProcedure, storedProcedure2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlStoredProcedureList()
        {
            var storedProcedure = await CreateSqlStoredProcedure(null);

            var storedProcedures = await SqlStoredProcedureCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(storedProcedures, Has.Count.EqualTo(1));
            Assert.AreEqual(storedProcedure.Data.Name, storedProcedures[0].Data.Name);

            VerifySqlStoredProcedures(storedProcedures[0], storedProcedure);
        }

        [Test]
        [RecordedTest]
        public async Task SqlStoredProcedureDelete()
        {
            var storedProcedure = await CreateSqlStoredProcedure(null);
            await storedProcedure.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlStoredProcedureCollection.ExistsAsync(_storedProcedureName);
            Assert.IsFalse(exists);
        }

        internal async Task<CosmosDBSqlStoredProcedureResource> CreateSqlStoredProcedure(AutoscaleSettings autoscale)
        {
            _storedProcedureName = Recording.GenerateAssetName("sql-stored-procedure-");
            CosmosDBSqlStoredProcedureCreateOrUpdateContent sqlDatabaseCreateUpdateOptions = new CosmosDBSqlStoredProcedureCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlStoredProcedureResourceInfo(_storedProcedureName)
                {
                    Body = @"function () {
    var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('First Hello World');
}"
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await SqlStoredProcedureCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storedProcedureName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlStoredProcedures(CosmosDBSqlStoredProcedureResource expectedValue, CosmosDBSqlStoredProcedureResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.StoredProcedureName, actualValue.Data.Resource.StoredProcedureName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
            Assert.AreEqual(expectedValue.Data.Resource.Body, actualValue.Data.Resource.Body);
        }
    }
}
