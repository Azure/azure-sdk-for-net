// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PostgreSql.Tests
{
    public class PostgreSqlFlexibleServerTests: PostgreSqlManagementTestBase
    {
        public PostgreSqlFlexibleServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            PostgreSqlFlexibleServerCollection serverCollection = rg.GetPostgreSqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("pgflexserver");
            var data = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D4s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "13",
                Storage = new PostgreSqlFlexibleServerStorage() {StorageSizeInGB = 128},
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                   BackupRetentionDays = 7
                },
                Network = new PostgreSqlFlexibleServerNetwork(),
                HighAvailability = new PostgreSqlFlexibleServerHighAvailability() { Mode = PostgreSqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            PostgreSqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Get
            PostgreSqlFlexibleServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // List
            await foreach (PostgreSqlFlexibleServerResource serverFromList in serverCollection)
            {
                Assert.AreEqual(serverName, serverFromList.Data.Name);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            PostgreSqlFlexibleServerCollection serverCollection = rg.GetPostgreSqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("pgflexserver");
            var data = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D4s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "13",
                Storage = new PostgreSqlFlexibleServerStorage() { StorageSizeInGB = 128 },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new PostgreSqlFlexibleServerNetwork(),
                HighAvailability = new PostgreSqlFlexibleServerHighAvailability() { Mode = PostgreSqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            PostgreSqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                Tags = {{"key", "value"}}
            });
            PostgreSqlFlexibleServerResource serverFromUpdate = lro.Value;
            Assert.AreEqual(serverName, serverFromUpdate.Data.Name);
            Assert.AreEqual("value", serverFromUpdate.Data.Tags["key"]);
            // Get
            PostgreSqlFlexibleServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task FastCreate()
        {
            var version = PostgreSqlFlexibleServerVersion.Ver12;
            var storageSize = 32;
            var location = AzureLocation.NorthEurope;
            var skuName = "Standard_B1ms";
            var tier = PostgreSqlFlexibleServerSkuTier.Burstable;
            var backupRetention = 7;

            // Fast create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", location);
            PostgreSqlFlexibleServerCollection serverCollection = rg.GetPostgreSqlFlexibleServers();

            var data = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku(skuName, tier),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = version,
                Storage = new PostgreSqlFlexibleServerStorage() { StorageSizeInGB = storageSize },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = backupRetention,
                },
                Tags = { { "key1", "val1" } },
            };

            var lro = await serverCollection.FastCreateAsync(WaitUntil.Completed, data);
            PostgreSqlFlexibleServerResource server = lro.Value;

            string serverName = server.Data.Name;

            Assert.AreEqual(location, server.Data.Location);
            Assert.AreEqual(skuName, server.Data.Sku.Name);
            Assert.AreEqual(tier, server.Data.Sku.Tier);
            Assert.AreEqual(version, server.Data.Version);
            Assert.AreEqual(storageSize, server.Data.Storage.StorageSizeInGB);
            Assert.AreEqual(backupRetention, server.Data.Backup.BackupRetentionDays);

            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                Backup = new PostgreSqlFlexibleServerBackupProperties() { BackupRetentionDays = backupRetention + 10 },
                Storage = new PostgreSqlFlexibleServerStorage() { StorageSizeInGB = storageSize * 2 },
                Tags = { { "key2", "val2" } },
            });
            PostgreSqlFlexibleServerResource serverFromUpdate = lro.Value;

            Assert.AreEqual(storageSize * 2, serverFromUpdate.Data.Storage.StorageSizeInGB);
            Assert.AreEqual(backupRetention + 10, serverFromUpdate.Data.Backup.BackupRetentionDays);
            Assert.AreEqual("val2", serverFromUpdate.Data.Tags["key2"]);

            // Get
            PostgreSqlFlexibleServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.AreEqual(serverName, serverFromGet.Data.Name);

            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
