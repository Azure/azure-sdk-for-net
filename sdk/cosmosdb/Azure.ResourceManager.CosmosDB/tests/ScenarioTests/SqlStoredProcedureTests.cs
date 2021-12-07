// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlStoredProcedureTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private SqlDatabase _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private SqlContainer _sqlContainer;
        private string _storedProcedureName;

        public SqlStoredProcedureTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlStoredProcedureCollection SqlStoredProcedureCollection { get => _sqlContainer.GetSqlStoredProcedures(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases());

            _sqlContainerId = (await SqlContainerTests.CreateSqlContainer(SessionRecording.GenerateAssetName("sql-container-"), null, _sqlDatabase.GetSqlContainers())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _sqlContainer.Delete();
            _sqlDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetSqlContainer(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlStoredProcedure storedProcedure = await SqlStoredProcedureCollection.GetIfExistsAsync(_storedProcedureName);
            if (storedProcedure != null)
            {
                await storedProcedure.DeleteAsync();
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

            bool ifExists = await SqlStoredProcedureCollection.CheckIfExistsAsync(_storedProcedureName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            SqlStoredProcedure storedProcedure2 = await SqlStoredProcedureCollection.GetAsync(_storedProcedureName);
            Assert.AreEqual(_storedProcedureName, storedProcedure2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlStoredProcedures(storedProcedure, storedProcedure2);

            SqlStoredProcedureCreateUpdateOptions updateOptions = new SqlStoredProcedureCreateUpdateOptions(storedProcedure.Id, _storedProcedureName, storedProcedure.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, storedProcedure.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            storedProcedure = await (await SqlStoredProcedureCollection.CreateOrUpdateAsync(_storedProcedureName, updateOptions)).WaitForCompletionAsync();
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
            await storedProcedure.DeleteAsync();

            storedProcedure = await SqlStoredProcedureCollection.GetIfExistsAsync(_storedProcedureName);
            Assert.Null(storedProcedure);
        }

        protected async Task<SqlStoredProcedure> CreateSqlStoredProcedure(AutoscaleSettings autoscale)
        {
            _storedProcedureName = Recording.GenerateAssetName("sql-stored-procedure-");
            SqlStoredProcedureCreateUpdateOptions sqlDatabaseCreateUpdateOptions = new SqlStoredProcedureCreateUpdateOptions(Resources.Models.Location.WestUS,
                new SqlStoredProcedureResource(_storedProcedureName)
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
            var sqlContainerLro = await SqlStoredProcedureCollection.CreateOrUpdateAsync(_storedProcedureName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlStoredProcedures(SqlStoredProcedure expectedValue, SqlStoredProcedure actualValue)
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
