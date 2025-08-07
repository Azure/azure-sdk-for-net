// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of server and database Advanced Threat Protection settings
    /// </summary>
    public class AdvancedThreatProtectionSettingsTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private static AzureLocation Location = AzureLocation.EastUS;

        public AdvancedThreatProtectionSettingsTests(bool isAsync)
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
            var client = GetArmClient();
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
        public async Task TestThreatProtectionOnServerAndDatabase()
        {
            string serverTestPrefix = "server-atp-test-";
            string databaseTestPrefix = "db-atp-test-";
            string sqlServerName = Recording.GenerateAssetName(serverTestPrefix);
            string sqlDatabaseName = Recording.GenerateAssetName(databaseTestPrefix);

            SqlServerData serverData = new SqlServerData(Location)
            {
                AdministratorLogin = "Admin-" + sqlServerName,
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var sqlServerResponse = await _resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, serverData);
            var sqlServerResource = sqlServerResponse.Value;

            SqlDatabaseData databaseData = new SqlDatabaseData(Location);
            var sqlDatabaseResponse = await sqlServerResource.GetSqlDatabases().CreateOrUpdateAsync(WaitUntil.Completed, sqlDatabaseName, databaseData);
            var sqlDatabaseResource = sqlDatabaseResponse.Value;

            // Server Advanced Threat Protection settings
            var serverAdvancedThreatProtectionResponse = await sqlServerResource.GetServerAdvancedThreatProtectionAsync(AdvancedThreatProtectionName.Default);
            var serverAdvancedThreatProtectionResource = serverAdvancedThreatProtectionResponse.Value;

            // Verify that the initial Get request contains the default settings.
            Assert.AreEqual(AdvancedThreatProtectionState.Disabled, serverAdvancedThreatProtectionResource.Data.State);

            // Modify the settings. Then send, receive and see if its still ok.
            ServerAdvancedThreatProtectionData serverAtpData = new ServerAdvancedThreatProtectionData()
            {
                State = AdvancedThreatProtectionState.Enabled
            };

            // Set Advanced Threat Protection settings for server.
            await serverAdvancedThreatProtectionResource.UpdateAsync(WaitUntil.Completed, serverAtpData);

            // Get Advanced Threat Protection settings from the server.
            serverAdvancedThreatProtectionResponse = await sqlServerResource.GetServerAdvancedThreatProtectionAsync(AdvancedThreatProtectionName.Default);
            serverAdvancedThreatProtectionResource = serverAdvancedThreatProtectionResponse.Value;

            // Verify that the Get request contains the updated settings.
            Assert.AreEqual(serverAtpData.State, serverAdvancedThreatProtectionResource.Data.State);

            // Modify the settings again. Then send, receive and see if its still ok.
            serverAtpData.State = AdvancedThreatProtectionState.Disabled;

            // Set Advanced Threat Protection settings for server.
            await serverAdvancedThreatProtectionResource.UpdateAsync(WaitUntil.Completed, serverAtpData);

            // Get Advanced Threat Protection settings from the server.
            serverAdvancedThreatProtectionResponse = await sqlServerResource.GetServerAdvancedThreatProtectionAsync(AdvancedThreatProtectionName.Default);
            serverAdvancedThreatProtectionResource = serverAdvancedThreatProtectionResponse.Value;

            Assert.AreEqual(serverAtpData.State, serverAdvancedThreatProtectionResource.Data.State);

            // Database Advanced Threat Protection settings
            var databaseAdvancedThreatProtectionResponse = await sqlDatabaseResource.GetDatabaseAdvancedThreatProtectionAsync(AdvancedThreatProtectionName.Default);
            var databaseAdvancedThreatProtectionResource = databaseAdvancedThreatProtectionResponse.Value;

            // Verify that the initial Get request contains the default settings.
            Assert.AreEqual(AdvancedThreatProtectionState.Disabled, databaseAdvancedThreatProtectionResource.Data.State);

            // Modify the settings. Then send, receive and see if its still ok.
            DatabaseAdvancedThreatProtectionData databaseAtpData = new DatabaseAdvancedThreatProtectionData()
            {
                State = AdvancedThreatProtectionState.Enabled
            };

            // Set Advanced Threat Protection settings for server.
            await databaseAdvancedThreatProtectionResource.UpdateAsync(WaitUntil.Completed, databaseAtpData);

            // Get Advanced Threat Protection settings from the database.
            databaseAdvancedThreatProtectionResponse = await sqlDatabaseResource.GetDatabaseAdvancedThreatProtectionAsync(AdvancedThreatProtectionName.Default);
            databaseAdvancedThreatProtectionResource = databaseAdvancedThreatProtectionResponse.Value;

            // Verify that the Get request contains the updated settings.
            Assert.AreEqual(databaseAtpData.State, databaseAdvancedThreatProtectionResource.Data.State);
        }
    }
}
