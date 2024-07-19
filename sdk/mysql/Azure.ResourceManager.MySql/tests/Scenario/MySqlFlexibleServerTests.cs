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
using Azure.Core.TestFramework.Models;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlFlexibleServerTests: MySqlManagementTestBase
    {
        public MySqlFlexibleServerTests(bool isAsync)
            : base(isAsync)//,RecordedTestMode.Record)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.importSourceProperties.storageUrl") { Value = "https://fakeaccout.blob.windows.core.net/fakecontainer" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.importSourceProperties.sasToken"));
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

        [TestCase]
        [RecordedTest]
        public async Task ImportFromStorageCreate()
        {
            // Create import from storage server
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.SouthCentralUS);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            string sourceStorageUri = "https://rishpercona.blob.core.windows.net/mysqlvm-57-1tb";
            string sourceDataDirPath = "data";
            string sourceStorageSasToken = "sp=rl&st=2024-07-16T08:51:17Z&se=2024-07-31T16:51:17Z&spr=https&sv=2022-11-02&sr=c&sig=x0xM8esHtKJBoHML4YfJDPNK7D%2FqVVl%2Fe1El%2FxdHKkY%3D";

            var data = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_D32ds_v4", MySqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() { StorageSizeInGB = 1600 },
                CreateMode = "Create",
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
                ImportSourceProperties = new ImportSourceProperties() { StorageType = "AzureBlob", StorageUri = new System.Uri(sourceStorageUri), DataDirPath = sourceDataDirPath, SasToken = sourceStorageSasToken }
            };
            var lroImportFromStorage = await serverCollection.CreateOrUpdateAsync(WaitUntil.Started, serverName, data);
            while (!lroImportFromStorage.HasCompleted)
            {
                var statusResult = await lroImportFromStorage.GetDetailedStatusAsync().ConfigureAwait(false);
                if (statusResult.Value.PercentComplete is not null)
                    Assert.IsTrue(statusResult.Value.PercentComplete >= 0);
                ImportFromStorageResponseType responseType = (ImportFromStorageResponseType)statusResult.Value.Properties;
                //Assert.IsNotNull(responseType.EstimatedCompletionOn);
                await Delay(5000);
            }
            MySqlFlexibleServerResource server = lroImportFromStorage.Value;
            //Assert.AreEqual(serverName, server.Data.Name);
        }
    }
}
