// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ElasticPoolTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private ElasticPoolCollection collection;
        private static AzureLocation Location = AzureLocation.UKSouth;
        private static SqlAlwaysEncryptedEnclaveType[] enclaveTypes = { SqlAlwaysEncryptedEnclaveType.Default, SqlAlwaysEncryptedEnclaveType.Vbs };

        public ElasticPoolTests(bool isAsync)
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

            // create Sql Server
            string serverName = Recording.GenerateAssetName("sql-server-");
            var sqlServer = await CreateDefaultSqlServer(serverName, Location, _resourceGroup);
            collection = sqlServer.GetElasticPools();
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
        public async Task ElasticPoolApiTests()
        {
            string poolName1 = Recording.GenerateAssetName("sql-pool-");
            string poolName2 = Recording.GenerateAssetName("sql-pool-");

            // 1.CreateOrUpdate
            ElasticPoolData data = new ElasticPoolData(Location) { };
            var pool1 = await collection.CreateOrUpdateAsync(WaitUntil.Completed, poolName1, data);
            Assert.That(pool1.Value.Data, Is.Not.Null);
            Assert.Multiple(async () =>
            {
                Assert.That(pool1.Value.Data.Name, Is.EqualTo(poolName1));

                // 2.CheckIfExist
                Assert.That((bool)await collection.ExistsAsync(poolName1), Is.True);
                Assert.That((bool)await collection.ExistsAsync(poolName2), Is.False);
            });

            // 3.Get
            var getPool = await collection.GetAsync(poolName1);
            Assert.That(getPool.Value.Data, Is.Not.Null);
            Assert.That(getPool.Value.Data.Name, Is.EqualTo(poolName1));

            var pool2 = await collection.CreateOrUpdateAsync(WaitUntil.Completed, poolName2, data);
            Assert.That(pool2.Value.Data, Is.Not.Null);
            Assert.That(pool2.Value.Data.Name, Is.EqualTo(poolName2));

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.EqualTo(2));
            string[] poolNamesList = { list.First().Data.Name, list.Last().Data.Name };
            Assert.That(poolNamesList, Does.Contain(poolName1));
            Assert.That(poolNamesList, Does.Contain(poolName2));

            // 5.Delete
            var deletePool1 = await collection.GetAsync(poolName1);
            await deletePool1.Value.DeleteAsync(WaitUntil.Completed);

            var deletePool2 = await collection.GetAsync(poolName2);
            await deletePool2.Value.DeleteAsync(WaitUntil.Completed);

            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase("Default")]
        [TestCase("VBS")]
        [RecordedTest]
        public async Task ElasticPoolApiTestsWithEnclaves(string preferredEnclaveType)
        {
            SqlAlwaysEncryptedEnclaveType enclaveType;
            if (preferredEnclaveType == SqlAlwaysEncryptedEnclaveType.Default.ToString())
            {
                enclaveType = SqlAlwaysEncryptedEnclaveType.Default;
            }
            else
            {
                enclaveType = SqlAlwaysEncryptedEnclaveType.Vbs;
            }
            string poolName1 = Recording.GenerateAssetName($"sql-pool-{preferredEnclaveType}-");
            string poolName2 = Recording.GenerateAssetName($"sql-pool-{preferredEnclaveType}-");

            // 1.CreateOrUpdate
            ElasticPoolData data = new ElasticPoolData(Location)
            {
                PreferredEnclaveType = preferredEnclaveType
            };

            var pool1 = await collection.CreateOrUpdateAsync(WaitUntil.Completed, poolName1, data);
            Assert.That(pool1.Value.Data, Is.Not.Null);
            Assert.Multiple(async () =>
            {
                Assert.That(pool1.Value.Data.Name, Is.EqualTo(poolName1));
                Assert.That(pool1.Value.Data.PreferredEnclaveType, Is.EqualTo(enclaveType));

                // 2.CheckIfExist
                Assert.That((bool)await collection.ExistsAsync(poolName1), Is.True);
                Assert.That((bool)await collection.ExistsAsync(poolName2), Is.False);
            });

            // 3.Get
            var getPool = await collection.GetAsync(poolName1);
            Assert.That(getPool.Value.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getPool.Value.Data.Name, Is.EqualTo(poolName1));
                Assert.That(getPool.Value.Data.PreferredEnclaveType, Is.EqualTo(enclaveType));
            });

            var pool2 = await collection.CreateOrUpdateAsync(WaitUntil.Completed, poolName2, data);
            Assert.That(pool2.Value.Data, Is.Not.Null);
            Assert.That(pool2.Value.Data.Name, Is.EqualTo(poolName2));

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.EqualTo(2));
            string[] poolNamesList = { list.First().Data.Name, list.Last().Data.Name };
            Assert.That(poolNamesList, Does.Contain(poolName1));
            Assert.That(poolNamesList, Does.Contain(poolName2));

            // 5.Delete
            var deletePool1 = await collection.GetAsync(poolName1);
            await deletePool1.Value.DeleteAsync(WaitUntil.Completed);

            var deletePool2 = await collection.GetAsync(poolName2);
            await deletePool2.Value.DeleteAsync(WaitUntil.Completed);

            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(0));
        }
    }
}
