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
        private DatabaseAccountResource _databaseAccount;
        private SqlDatabaseResource _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private SqlContainerResource _sqlContainer;
        private string _storedProcedureName;

        public SqlStoredProcedureTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlStoredProcedureCollection SqlStoredProcedureCollection => _sqlContainer.GetSqlStoredProcedures();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases());

            _sqlContainerId = (await SqlContainerTests.CreateSqlContainer(SessionRecording.GenerateAssetName("sql-container-"), null, _sqlDatabase.GetSqlContainers())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _sqlContainer.Delete(WaitUntil.Completed);
            _sqlDatabase.Delete(WaitUntil.Completed);
            _databaseAccount.Delete(WaitUntil.Completed);
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetSqlContainerResource(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await SqlStoredProcedureCollection.ExistsAsync(_storedProcedureName))
            {
                var id = SqlStoredProcedureCollection.Id;
                id = SqlStoredProcedureResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Parent.Name, id.Parent.Name, id.Name, _storedProcedureName);
                SqlStoredProcedureResource storedProcedure = this.ArmClient.GetSqlStoredProcedureResource(id);
                await storedProcedure.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlStoredProcedureCreateAndUpdate()
        {
            var storedProcedure = await CreateSqlStoredProcedure(null);
            Assert.AreEqual(_storedProcedureName, storedProcedure.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlStoredProcedureCollection.ExistsAsync(_storedProcedureName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            SqlStoredProcedureResource storedProcedure2 = await SqlStoredProcedureCollection.GetAsync(_storedProcedureName);
            Assert.AreEqual(_storedProcedureName, storedProcedure2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlStoredProcedures(storedProcedure, storedProcedure2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new SqlStoredProcedureCreateOrUpdateContent(AzureLocation.WestUS, storedProcedure.Data.Resource)
            {
                Options = new CreateUpdateOptions { Throughput = TestThroughput2 }
            };

            storedProcedure = (await SqlStoredProcedureCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storedProcedureName, updateOptions)).Value;
            Assert.AreEqual(_storedProcedureName, storedProcedure.Data.Resource.Id);
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

        internal async Task<SqlStoredProcedureResource> CreateSqlStoredProcedure(AutoscaleSettings autoscale)
        {
            _storedProcedureName = Recording.GenerateAssetName("sql-stored-procedure-");
            SqlStoredProcedureCreateOrUpdateContent sqlDatabaseCreateUpdateOptions = new SqlStoredProcedureCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.SqlStoredProcedureResource(_storedProcedureName)
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

        private void VerifySqlStoredProcedures(SqlStoredProcedureResource expectedValue, SqlStoredProcedureResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
            Assert.AreEqual(expectedValue.Data.Resource.Body, actualValue.Data.Resource.Body);
        }
    }
}
