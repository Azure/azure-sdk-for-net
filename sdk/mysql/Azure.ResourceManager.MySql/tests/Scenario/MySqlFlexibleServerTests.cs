// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MySql.FlexibleServers;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlFlexibleServerTests: MySqlManagementTestBase
    {
        public MySqlFlexibleServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.EastUS);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            var data = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_B1ms", MySqlFlexibleServerSkuTier.Burstable),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() {StorageSizeInGB = 512},
                CreateMode = MySqlFlexibleServerCreateMode.Default,
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                   BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            MySqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Get
            MySqlFlexibleServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // List
            await foreach (MySqlFlexibleServerResource serverFromList in serverCollection)
            {
                Assert.AreEqual(serverName, serverFromList.Data.Name);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.EastUS);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            var data = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_B1ms", MySqlFlexibleServerSkuTier.Burstable),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() {StorageSizeInGB = 512},
                CreateMode = MySqlFlexibleServerCreateMode.Default,
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                   BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            MySqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new MySqlFlexibleServerPatch()
            {
                Tags = {{"key", "value"}}
            });
            MySqlFlexibleServerResource serverFromUpdate = lro.Value;
            Assert.AreEqual(serverName, serverFromUpdate.Data.Name);
            Assert.AreEqual("value", serverFromUpdate.Data.Tags["key"]);
            // Get
            MySqlFlexibleServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
