// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class SqlDatabaseTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private static AzureLocation Location = new AzureLocation("eastus2", "East US 2");

        public SqlDatabaseTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            ArmClientOptions options = new ArmClientOptions();
            var client = GetArmClient(options);
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var sqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            foreach (var item in sqlServerList)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseApiTests()
        {
            // create Sql Server
            string serverName = Recording.GenerateAssetName("sql-server-");
            var sqlServer = await CreateDefaultSqlServer(serverName, Location, _resourceGroup);
            var collection = sqlServer.GetSqlDatabases();

            string databaseName = Recording.GenerateAssetName("sql-database-");

            // 1.CreateOrUpdate
            SqlDatabaseData data = new SqlDatabaseData(Location) { };
            var database = await collection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, data);
            Assert.That(database.Value.Data, Is.Not.Null);
            Assert.That(database.Value.Data.Name, Is.EqualTo(databaseName));

            // 2.CheckIfExist
            Assert.That((bool)await collection.ExistsAsync(databaseName), Is.True);
            Assert.That((bool)await collection.ExistsAsync(databaseName + "0"), Is.False);

            // 3.Get
            var getDatabase = await collection.GetAsync(databaseName);
            Assert.That(getDatabase.Value.Data, Is.Not.Null);
            Assert.That(getDatabase.Value.Data.Name, Is.EqualTo(databaseName));

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count, Is.EqualTo(2));
            string[] databaseNamesList = { list.First().Data.Name, list.Last().Data.Name };
            Assert.That(databaseNamesList, Does.Contain(databaseName));

            // 5.Delete
            var deleteDatabase = await collection.GetAsync(databaseName);
            await deleteDatabase.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.First().Data.Name, Is.Not.EqualTo(databaseName));
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseApiTestsWithEnclaves()
        {
            // create Sql Server
            string serverName = Recording.GenerateAssetName("sql-server-");
            var sqlServer = await CreateDefaultSqlServer(serverName, Location, _resourceGroup);
            SqlAlwaysEncryptedEnclaveType[] enclaveTypes = { SqlAlwaysEncryptedEnclaveType.Default, SqlAlwaysEncryptedEnclaveType.Vbs };

            foreach (SqlAlwaysEncryptedEnclaveType enclaveType in enclaveTypes)
            {
                string preferredEnclaveType = enclaveType.ToString();
                string databaseName = Recording.GenerateAssetName($"sql-database-{preferredEnclaveType}-");
                var collection = sqlServer.GetSqlDatabases();

                // 1.CreateOrUpdate
                SqlDatabaseData data = new SqlDatabaseData(Location)
                {
                    PreferredEnclaveType = preferredEnclaveType
                };

                var database = await collection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, data);
                Assert.That(database.Value.Data, Is.Not.Null);
                Assert.That(database.Value.Data.Name, Is.EqualTo(databaseName));
                Assert.That(database.Value.Data.PreferredEnclaveType, Is.EqualTo(enclaveType));

                // 2.CheckIfExist
                Assert.That((bool)await collection.ExistsAsync(databaseName), Is.True);
                Assert.That((bool)await collection.ExistsAsync(databaseName + "0"), Is.False);

                // 3.Get
                var getDatabase = await collection.GetAsync(databaseName);
                Assert.That(getDatabase.Value.Data, Is.Not.Null);
                Assert.That(getDatabase.Value.Data.Name, Is.EqualTo(databaseName));
                Assert.That(database.Value.Data.PreferredEnclaveType, Is.EqualTo(enclaveType));

                // 4.GetAll
                var list = await collection.GetAllAsync().ToEnumerableAsync();
                Assert.That(list, Is.Not.Empty);
                Assert.That(list.Count, Is.EqualTo(2));
                string[] databaseNamesList = { list.First().Data.Name, list.Last().Data.Name };
                Assert.That(databaseNamesList, Does.Contain(databaseName));

                // 5.Delete
                var deleteDatabase = await collection.GetAsync(databaseName);
                await deleteDatabase.Value.DeleteAsync(WaitUntil.Completed);
                list = await collection.GetAllAsync().ToEnumerableAsync();
                Assert.That(list.Count, Is.EqualTo(1));
                Assert.That(list.First().Data.Name, Is.Not.EqualTo(databaseName));
            }
        }
    }
}
