// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class SqlServerTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public SqlServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            foreach (var item in SqlServerList)
            {
                await item.DeleteAsync();
            }
        }

        private async Task<SqlServer> CreateOrUpdateSqlServer(string sqlServerName)
        {
            SqlServerData data = new SqlServerData(Location.WestUS2)
            {
                AdministratorLogin = "Admin-" + sqlServerName,
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(sqlServerName, data);
            return SqlServer.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            Assert.AreEqual(true, _resourceGroup.GetSqlServers().CheckIfExists(sqlServerName).Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            var SqlServer = await CreateOrUpdateSqlServer(sqlServerName);
            Assert.IsNotNull(SqlServer.Data);
            Assert.AreEqual(sqlServerName, SqlServer.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            var SqlServer = await _resourceGroup.GetSqlServers().GetAsync(sqlServerName);
            Assert.IsNotNull(SqlServer.Value.Data);
            Assert.AreEqual(sqlServerName, SqlServer.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string sqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(sqlServerName);
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(SqlServerList);
            Assert.AreEqual(1,SqlServerList.Count);
            Assert.AreEqual(sqlServerName, SqlServerList[0].Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string SqlServerName = Recording.GenerateAssetName("sqlserver-");
            await CreateOrUpdateSqlServer(SqlServerName);
            var SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, SqlServerList.Count);

            await SqlServerList[0].DeleteAsync();
            SqlServerList = await _resourceGroup.GetSqlServers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, SqlServerList.Count);
        }
    }
}
