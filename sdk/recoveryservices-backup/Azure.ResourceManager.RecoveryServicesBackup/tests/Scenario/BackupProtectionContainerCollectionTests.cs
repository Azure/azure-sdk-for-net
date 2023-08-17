// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    public class BackupProtectionContainerCollectionTests: RecoveryServicesBackupManagementTestBase
    {
        public BackupProtectionContainerCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "BackupRG", AzureLocation.EastUS);
        }

        public async Task<StorageAccountResource> CreateStorage(ResourceGroupResource resourceGroup,string accountName)
        {
            var storageAccountCollection = resourceGroup.GetStorageAccounts();
            var sku = new StorageSku("Standard_ZRS");
            var storageKind = StorageKind.StorageV2;
            var content = new StorageAccountCreateOrUpdateContent(sku, storageKind, AzureLocation.EastUS);
            return (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;
        }

        public async Task<RecoveryServicesVaultResource> CreateRSVault(ResourceGroupResource resourceGroup)
        {
            var collection = resourceGroup.GetRecoveryServicesVaults();
            var vaultName = Recording.GenerateAssetName("RecoveryServicesVault");
            var data = new RecoveryServicesVaultData(AzureLocation.EastUS)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                },
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
                {
                    Name = RecoveryServicesSkuName.RS0,
                    Tier = "Standard",
                },
            };
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
        }

        [RecordedTest]
        [Ignore("Need container")]
        public async Task CreateOrUpdate()
        {
            var subid = (await Client.GetDefaultSubscriptionAsync()).Id;
            //var subid = Client.GetSubscriptions();
            var accountName = Recording.GenerateAssetName("storageaccount56");
            var resourceGroup = await CreateResourceGroupAsync();
            var storageAccount = await CreateStorage(resourceGroup,accountName);
            //var blobService = storageAccount.GetBlobService();
            //blobService = await blobService.GetAsync();
            //var blob = await blobService.GetBlobContainers();
            var RSVault = await CreateRSVault(resourceGroup);
            var storageId = storageAccount.Id;
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupProtectionContainers();
            //var fabricName = "Azure";
            //var containerName = $"storagecontainer;Storage;{resourceGroupName};{accountName}";
            var data = new BackupProtectionContainerData(AzureLocation.EastUS)
            {
                Properties = new StorageContainer()
                {
                    FriendlyName = "MyBackupServer",
                    BackupManagementType = BackupManagementType.AzureStorage,
                    ContainerType = ProtectableContainerType.StorageContainer,
                    SourceResourceId = storageId,
                    //SourceResourceId = new ResourceIdentifier($"/subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Data.Name}"),
                    AcquireStorageAccountLock = AcquireStorageAccountLock.Acquire
                }
            };
            //var backupProtectionContainers =(await collection.CreateOrUpdateAsync(WaitUntil.Completed,vaultName,fabricName,containerName,data)).Value;
            //Assert.AreEqual(backupProtectionContainers.Data.Name, containerName);
            //Assert.AreEqual(backupProtectionContainers.Data.Name, AzureLocation.EastUS);
        }
    }
}
