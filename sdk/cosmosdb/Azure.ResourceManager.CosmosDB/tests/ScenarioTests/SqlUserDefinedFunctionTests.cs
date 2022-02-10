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
    public class SqlUserDefinedFunctionTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private SqlDatabase _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private SqlContainer _sqlContainer;
        private string _userDefinedFunctionName;

        public SqlUserDefinedFunctionTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlUserDefinedFunctionCollection SqlUserDefinedFunctionCollection { get => _sqlContainer.GetSqlUserDefinedFunctions(); }

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
            _sqlContainer.Delete(true);
            _sqlDatabase.Delete(true);
            _databaseAccount.Delete(true);
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetSqlContainer(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlUserDefinedFunction userDefinedFunction = await SqlUserDefinedFunctionCollection.GetIfExistsAsync(_userDefinedFunctionName);
            if (userDefinedFunction != null)
            {
                await userDefinedFunction.DeleteAsync(true);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlUserDefinedFunctionCreateAndUpdate()
        {
            var userDefinedFunction = await CreateSqlUserDefinedFunction(null);
            Assert.AreEqual(_userDefinedFunctionName, userDefinedFunction.Data.Resource.Id);
            Assert.That(userDefinedFunction.Data.Resource.Body, Contains.Substring("First Hello World"));
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlUserDefinedFunctionCollection.ExistsAsync(_userDefinedFunctionName);
            Assert.True(ifExists);

            SqlUserDefinedFunction userDefinedFunction2 = await SqlUserDefinedFunctionCollection.GetAsync(_userDefinedFunctionName);
            Assert.AreEqual(_userDefinedFunctionName, userDefinedFunction2.Data.Resource.Id);

            VerifySqlUserDefinedFunctions(userDefinedFunction, userDefinedFunction2);

            SqlUserDefinedFunctionCreateUpdateOptions updateOptions = new SqlUserDefinedFunctionCreateUpdateOptions(userDefinedFunction.Id, _userDefinedFunctionName, userDefinedFunction.Data.Type, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, userDefinedFunction.Data.Resource, new CreateUpdateOptions());
            updateOptions = new SqlUserDefinedFunctionCreateUpdateOptions(AzureLocation.WestUS, new SqlUserDefinedFunctionResource(_userDefinedFunctionName)
            {
                Body = @"function () { var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('Second Hello World');
}"
            });

            userDefinedFunction = (await SqlUserDefinedFunctionCollection.CreateOrUpdateAsync(true, _userDefinedFunctionName, updateOptions)).Value;
            Assert.AreEqual(_userDefinedFunctionName, userDefinedFunction.Data.Resource.Id);
            Assert.That(userDefinedFunction.Data.Resource.Body, Contains.Substring("Second Hello World"));

            userDefinedFunction2 = await SqlUserDefinedFunctionCollection.GetAsync(_userDefinedFunctionName);
            VerifySqlUserDefinedFunctions(userDefinedFunction, userDefinedFunction2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlUserDefinedFunctionList()
        {
            var userDefinedFunction = await CreateSqlUserDefinedFunction(null);

            var userDefinedFunctions = await SqlUserDefinedFunctionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(userDefinedFunctions, Has.Count.EqualTo(1));
            Assert.AreEqual(userDefinedFunction.Data.Name, userDefinedFunctions[0].Data.Name);

            VerifySqlUserDefinedFunctions(userDefinedFunctions[0], userDefinedFunction);
        }

        [Test]
        [RecordedTest]
        public async Task SqlUserDefinedFunctionDelete()
        {
            var userDefinedFunction = await CreateSqlUserDefinedFunction(null);
            await userDefinedFunction.DeleteAsync(true);

            userDefinedFunction = await SqlUserDefinedFunctionCollection.GetIfExistsAsync(_userDefinedFunctionName);
            Assert.Null(userDefinedFunction);
        }

        protected async Task<SqlUserDefinedFunction> CreateSqlUserDefinedFunction(AutoscaleSettings autoscale)
        {
            _userDefinedFunctionName = Recording.GenerateAssetName("sql-stored-procedure-");
            SqlUserDefinedFunctionCreateUpdateOptions sqlDatabaseCreateUpdateOptions = new SqlUserDefinedFunctionCreateUpdateOptions(AzureLocation.WestUS,
                new SqlUserDefinedFunctionResource(_userDefinedFunctionName)
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
            var sqlContainerLro = await SqlUserDefinedFunctionCollection.CreateOrUpdateAsync(true, _userDefinedFunctionName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlUserDefinedFunctions(SqlUserDefinedFunction expectedValue, SqlUserDefinedFunction actualValue)
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
