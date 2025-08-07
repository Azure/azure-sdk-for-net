// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.MySql.FlexibleServers;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlFlexibleServerBackupTests: MySqlManagementTestBase
    {
        public MySqlFlexibleServerBackupTests(bool isAsync)
            : base(isAsync)//,RecordedTestMode.Record)
        {
        }

        private async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource resourceGroup)
        {
            var storageAccountCollection = resourceGroup.GetStorageAccounts();
            var accountName = Recording.GenerateAssetName("storagetest3");
            var sku = new StorageSku(StorageSkuName.StandardRagrs);
            var kind = StorageKind.StorageV2;
            var accountContent = new StorageAccountCreateOrUpdateContent(sku, kind, AzureLocation.EastUS)
            {
                AccessTier = StorageAccountAccessTier.Cool
            };
            var storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, accountContent)).Value;
            return storageAccount;
        }

        private async Task<BlobContainerResource> CreateBlobContainer(StorageAccountResource storageAccount,ResourceGroupResource resourceGroup)
        {
            var blobService = storageAccount.GetBlobService();
            var blobContainersCollection = blobService.GetBlobContainers();
            var containerName = Recording.GenerateAssetName("container");
            var containerData = new BlobContainerData() { };
            var blobContainer = (await blobContainersCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, containerData)).Value;
            return blobContainer;
        }

        [TestCase]
        public async Task CreateBackupAndExport()
        {
            // Create a server
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.EastUS);
            var storageAccount = await CreateStorageAccount(rg);
            var blobContainer = await CreateBlobContainer(storageAccount, rg);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            var serverData = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_B1ms", MySqlFlexibleServerSkuTier.Burstable),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() { StorageSizeInGB = 512 },
                CreateMode = MySqlFlexibleServerCreateMode.Default,
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, serverData);
            MySqlFlexibleServerResource server1 = lro.Value;
            Assert.AreEqual(serverName, server1.Data.Name);

            //create backup
            List<string> list1 = new List<string>();
            var aSascontent = new AccountSasContent(StorageAccountSasSignedService.B, StorageAccountSasSignedResourceType.O, "rwd", Recording.UtcNow.AddHours(1));
            var sas = (await storageAccount.GetAccountSasAsync(aSascontent)).Value.AccountSasToken;
            list1.Add($"https://{storageAccount.Data.Name}.blob.core.windows.net/{blobContainer.Data.Name}?{sas}");
            MySqlFlexibleServerBackupAndExportContent backupAndExportContent = new MySqlFlexibleServerBackupAndExportContent
            (
                new MySqlFlexibleServerBackupSettings("customer-backup-sdktest-1"),
                new MySqlFlexibleServerFullBackupStoreDetails(list1)
            );

            var lroBackupAndExport = await server1.CreateBackupAndExportAsync(Azure.WaitUntil.Completed, backupAndExportContent);
            MySqlFlexibleServerBackupAndExportResult resultBackupAndExport = lroBackupAndExport.Value;
            Assert.AreEqual("Succeeded", resultBackupAndExport.Status.ToString());
            Assert.AreEqual("100", resultBackupAndExport.PercentComplete.ToString());
        }
    }
}
