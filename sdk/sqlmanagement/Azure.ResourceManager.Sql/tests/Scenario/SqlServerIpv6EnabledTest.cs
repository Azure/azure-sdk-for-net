// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class SqlServerIpv6EnabledTest : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public SqlServerIpv6EnabledTest(bool isAsync)
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

        [Ignore("Issue: https://github.com/Azure/azure-sdk-for-net/issues/41823")]
        [Test]
        [RecordedTest]
        public async Task CreateSqlServerWithIpv6Enabled()
        {
            // 1. Create a new server with IPv6 enabled
            string sqlServerName = Recording.GenerateAssetName("sqlserver1-");
            SqlServerData data = new SqlServerData(AzureLocation.SouthCentralUS)
            {
                AdministratorLogin = "Admin-" + sqlServerName,
                AdministratorLoginPassword = CreateGeneralPassword(),
                IsIPv6Enabled = Models.ServerNetworkAccessFlag.Enabled,
            };
            var SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, data);

            // Check if the server is exist
            Assert.AreEqual(true, (await _resourceGroup.GetSqlServers().ExistsAsync(sqlServerName)).Value);

            // Verify IPv6 is enabled
            Assert.IsNotNull(SqlServer.Value);
            Assert.AreEqual("Enabled", SqlServer.Value.Data.IsIPv6Enabled.ToString());

            // 2. Disable IPv6
            data.IsIPv6Enabled = Models.ServerNetworkAccessFlag.Disabled;
            SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, data);

            // Verify IPv6 is disabled
            Assert.AreEqual("Disabled", SqlServer.Value.Data.IsIPv6Enabled.ToString());
        }

        [Ignore("Issue: https://github.com/Azure/azure-sdk-for-net/issues/41823")]
        [Test]
        [RecordedTest]
        public async Task UpdateSqlServerWithIpv6Enabled()
        {
            // 1. Create a new server
            string sqlServerName = Recording.GenerateAssetName("sqlserver2-");
            SqlServerData data = new SqlServerData(AzureLocation.SouthCentralUS)
            {
                AdministratorLogin = "Admin-" + sqlServerName,
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, data);

            // Check if the server is exist
            Assert.AreEqual(true, (await _resourceGroup.GetSqlServers().ExistsAsync(sqlServerName)).Value);

            // 2. Update the sever with IPv6 enabled
            data.IsIPv6Enabled = Models.ServerNetworkAccessFlag.Enabled;
            SqlServer = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, data);

            // Verify IPv6 is enabled
            Assert.AreEqual("Enabled", SqlServer.Value.Data.IsIPv6Enabled.ToString());
        }
    }
}
