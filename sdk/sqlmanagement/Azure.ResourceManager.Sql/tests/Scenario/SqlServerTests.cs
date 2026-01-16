// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class SqlServerTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public SqlServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            foreach (var item in SqlServerList)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SqlServerResource> CreateOrUpdateSqlServer(string sqlServerName)
        {
            SqlServerData data = new SqlServerData(AzureLocation.WestUS2)
            {
                AdministratorLogin = "Admin-" + sqlServerName,
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, data);
            return SqlServer.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            Assert.That((await _resourceGroup.GetSqlServers().ExistsAsync(sqlServerName)).Value, Is.EqualTo(true));
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            var SqlServer = await CreateOrUpdateSqlServer(sqlServerName);
            Assert.That(SqlServer.Data, Is.Not.Null);
            Assert.That(SqlServer.Data.Name, Is.EqualTo(sqlServerName));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            var SqlServer = await _resourceGroup.GetSqlServers().GetAsync(sqlServerName);
            Assert.That(SqlServer.Value.Data, Is.Not.Null);
            Assert.That(SqlServer.Value.Data.Name, Is.EqualTo(sqlServerName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.That(SqlServerList, Is.Not.Empty);
            Assert.That(SqlServerList.Count, Is.EqualTo(1));
            Assert.That(SqlServerList[0].Data.Name, Is.EqualTo(sqlServerName));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string SqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(SqlServerName);
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.That(SqlServerList.Count, Is.EqualTo(1));

            await SqlServerList[0].DeleteAsync(WaitUntil.Completed);
            SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.That(SqlServerList.Count, Is.EqualTo(0));
        }
    }
}
