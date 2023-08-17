// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupResourceConfigCollectionTests:RecoveryServicesBackupManagementTestBase
    {
        public BackupResourceConfigCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "BackupRG", AzureLocation.EastUS);
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

        public async Task<BackupResourceConfigResource> CreateBackupResourceConfig(ResourceGroupResource resourceGroup,BackupResourceConfigCollection collection,String vaultName)
        {
            var data = new BackupResourceConfigData(AzureLocation.EastUS)
            {
                Properties = new BackupResourceConfigProperties()
                {
                    StorageModelType = BackupStorageType.GeoRedundant,
                    StorageType = BackupStorageType.GeoRedundant,
                    StorageTypeState = BackupStorageTypeState.Unlocked,
                    EnableCrossRegionRestore = true,
                    DedupState = VaultDedupState.Enabled,
                    XcoolState = VaultXcoolState.Enabled,
                }
            };
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSV = await CreateRSVault(resourceGroup);
            var vaultName = RSV.Data.Name;
            var collection = resourceGroup.GetBackupResourceConfigs();
            var backupResourceConfig = await CreateBackupResourceConfig(resourceGroup,collection,vaultName);
            Assert.IsNotNull(backupResourceConfig.Data.Name);
            Assert.IsNotNull(backupResourceConfig.Data.Id);
            Assert.IsNotNull(backupResourceConfig.Data.Properties.StorageModelType, "GeoRedundant");
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSV = await CreateRSVault(resourceGroup);
            var vaultName = RSV.Data.Name;
            var collection = resourceGroup.GetBackupResourceConfigs();
            var backupResourceConfig = await CreateBackupResourceConfig(resourceGroup, collection,vaultName);
            BackupResourceConfigResource backupResourceConfig_1 = await collection.GetAsync(vaultName);
            Assert.AreEqual(backupResourceConfig.Data.Name,backupResourceConfig_1.Data.Name);
            Assert.AreEqual(backupResourceConfig.Data.Id,backupResourceConfig_1.Data.Id);
            Assert.AreEqual(backupResourceConfig.Data.Properties.StorageTypeState,backupResourceConfig_1.Data.Properties.StorageTypeState);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSV = await CreateRSVault(resourceGroup);
            var vaultName = RSV.Data.Name;
            var collection = resourceGroup.GetBackupResourceConfigs();
            _ = await CreateBackupResourceConfig(resourceGroup, collection, vaultName);
            var result_1 = (await collection.ExistsAsync(vaultName)).Value;
            Assert.IsTrue(result_1);
        }
    }
}
