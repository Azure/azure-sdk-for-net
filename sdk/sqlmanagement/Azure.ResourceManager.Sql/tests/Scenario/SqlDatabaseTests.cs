// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class SqlDatabaseTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;

        public SqlDatabaseTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var lro = await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("Sql-ViditGupta-"), new ResourceGroupData(AzureLocation.EastUS));
            _resourceGroup = lro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseApiTests()
        {
            // create Sql Server
            string serverName = Recording.GenerateAssetName("sql-server-");
            var sqlServer = await CreateDefaultSqlServer(serverName, AzureLocation.EastUS, _resourceGroup);

            string databaseName = Recording.GenerateAssetName("sql-database-");
            var collection = sqlServer.GetSqlDatabases();

            // 1.CreateOrUpdate
            SqlDatabaseData data = new SqlDatabaseData(AzureLocation.EastUS) { };
            var database = await collection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, data);
            Assert.IsNotNull(database.Value.Data);
            Assert.AreEqual(databaseName, database.Value.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(await collection.ExistsAsync(databaseName));
            Assert.IsFalse(await collection.ExistsAsync(databaseName + "0"));

            // 3.Get
            var getDatabase = await collection.GetAsync(databaseName);
            Assert.IsNotNull(getDatabase.Value.Data);
            Assert.AreEqual(databaseName, getDatabase.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(databaseName, list.FirstOrDefault().Data.Name);

            // 5.Delete
            var deleteDatabase = await collection.GetAsync(databaseName);
            await deleteDatabase.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
