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
        private DatabaseAccountResource _databaseAccount;
        private SqlDatabaseResource _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private SqlContainerResource _sqlContainer;
        private string _userDefinedFunctionName;

        public SqlUserDefinedFunctionTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlUserDefinedFunctionCollection SqlUserDefinedFunctionCollection => _sqlContainer.GetSqlUserDefinedFunctions();

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
            if (await SqlUserDefinedFunctionCollection.ExistsAsync(_userDefinedFunctionName))
            {
                var id = SqlUserDefinedFunctionCollection.Id;
                id = SqlUserDefinedFunctionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Parent.Name, id.Parent.Name, id.Name, _userDefinedFunctionName);
                SqlUserDefinedFunctionResource userDefinedFunction = this.ArmClient.GetSqlUserDefinedFunctionResource(id);
                await userDefinedFunction.DeleteAsync(WaitUntil.Completed);
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

            SqlUserDefinedFunctionResource userDefinedFunction2 = await SqlUserDefinedFunctionCollection.GetAsync(_userDefinedFunctionName);
            Assert.AreEqual(_userDefinedFunctionName, userDefinedFunction2.Data.Resource.Id);

            VerifySqlUserDefinedFunctions(userDefinedFunction, userDefinedFunction2);

            var updateOptions = new SqlUserDefinedFunctionCreateOrUpdateContent(AzureLocation.WestUS, new Models.SqlUserDefinedFunctionResource(_userDefinedFunctionName)
            {
                Body = @"function () { var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('Second Hello World');
}"
            });

            userDefinedFunction = (await SqlUserDefinedFunctionCollection.CreateOrUpdateAsync(WaitUntil.Completed, _userDefinedFunctionName, updateOptions)).Value;
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
            await userDefinedFunction.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlUserDefinedFunctionCollection.ExistsAsync(_userDefinedFunctionName);
            Assert.IsFalse(exists);
        }

        internal async Task<SqlUserDefinedFunctionResource> CreateSqlUserDefinedFunction(AutoscaleSettings autoscale)
        {
            _userDefinedFunctionName = Recording.GenerateAssetName("sql-stored-procedure-");
            var sqlDatabaseCreateUpdateOptions = new SqlUserDefinedFunctionCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.SqlUserDefinedFunctionResource(_userDefinedFunctionName)
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
            var sqlContainerLro = await SqlUserDefinedFunctionCollection.CreateOrUpdateAsync(WaitUntil.Completed, _userDefinedFunctionName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlUserDefinedFunctions(SqlUserDefinedFunctionResource expectedValue, SqlUserDefinedFunctionResource actualValue)
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
