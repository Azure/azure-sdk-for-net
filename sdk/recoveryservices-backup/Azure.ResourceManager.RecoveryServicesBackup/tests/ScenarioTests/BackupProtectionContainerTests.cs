// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests
{
    [NonParallelizable]
    public class BackupProtectionContainerTests : RecoveryServicesBackupManagementTestBase
    {
        public BackupProtectionContainerTests(bool isAsnyc)
            : base(isAsnyc)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task CreateTest()
        {
            var sub = await Client.GetDefaultSubscriptionAsync();
            var rg = await CreateResourceGroup(sub, "sdktest", AzureLocation.EastUS);

            var storageName = Recording.GenerateAssetName("teststorage");
            var storageData = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardGrs), StorageKind.StorageV2, AzureLocation.EastUS);
            var storage = (await rg.GetStorageAccounts()
                .CreateOrUpdateAsync(WaitUntil.Completed, storageName, storageData)).Value;

            var vaultName = Recording.GenerateAssetName("testvalut");
            var vaultData = new RecoveryServicesVaultData(AzureLocation.EastUS)
            {
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0) { Tier = "Standard" },
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled
                }
            };
            var vault = (await rg.GetRecoveryServicesVaults().CreateOrUpdateAsync(WaitUntil.Completed, vaultName, vaultData)).Value;

            var containerName = $"StorageContainer;Storage;{rg.Data.Name};{storageName}";
            var containerData = new BackupProtectionContainerData(AzureLocation.EastUS)
            {
                Properties = new StorageContainer()
                {
                    FriendlyName = storageName,
                    BackupManagementType = BackupManagementType.AzureStorage,
                    SourceResourceId = storage.Id,
                    AcquireStorageAccountLock = AcquireStorageAccountLock.Acquire
                }
            };
            var container = (await rg.GetBackupProtectionContainers()
                .CreateOrUpdateAsync(WaitUntil.Completed, vaultName, "Azure", containerName, containerData)).Value;
            Assert.AreEqual(container.Data.Properties.RegistrationStatus, "Registered");
            Assert.AreEqual(container.Data.Name, containerName);

            // Remove the auto-lock before we delete the resource group
            var deleteLock = (await storage.GetManagementLocks().GetAsync("AzureBackupProtectionLock")).Value;
            await deleteLock.DeleteAsync(WaitUntil.Completed);
        }
    }
}
