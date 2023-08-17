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
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServicesBackup.Models;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupResourceVaultConfigCollectionTests : RecoveryServicesBackupManagementTestBase
    {
        public BackupResourceVaultConfigCollectionTests(bool isAsync)
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

        [RecordedTest]
        public async Task CreareOrUpdate()
        {
           var resourceGroup = await CreateResourceGroupAsync();
           var RSVault = await CreateRSVault(resourceGroup);
           var vaultName = RSVault.Data.Name;
           var colletion = resourceGroup.GetBackupResourceVaultConfigs();
           var data = new BackupResourceVaultConfigData(AzureLocation.EastUS)
            {
                Properties = new Models.BackupResourceVaultConfigProperties()
                {
                    StorageModelType = BackupStorageType.LocallyRedundant,
                    StorageType = BackupStorageType.LocallyRedundant,
                    StorageTypeState = BackupStorageTypeState.Unlocked,
                    EnhancedSecurityState = EnhancedSecurityState.Enabled,
                    SoftDeleteFeatureState = SoftDeleteFeatureState.Enabled,
                    IsSoftDeleteFeatureStateEditable = true,
                }
            };
            var backupResourceVaultConfig = (await colletion.CreateOrUpdateAsync(WaitUntil.Completed,vaultName,data)).Value;
            Assert.NotNull(backupResourceVaultConfig.Data.Name);
            Assert.NotNull(backupResourceVaultConfig.Data.Id);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupResourceVaultConfigs();
            var data = new BackupResourceVaultConfigData(AzureLocation.EastUS)
            {
                Properties = new Models.BackupResourceVaultConfigProperties()
                {
                    StorageModelType = BackupStorageType.LocallyRedundant,
                    StorageType = BackupStorageType.LocallyRedundant,
                    StorageTypeState = BackupStorageTypeState.Unlocked,
                    EnhancedSecurityState = EnhancedSecurityState.Enabled,
                    SoftDeleteFeatureState = SoftDeleteFeatureState.Enabled,
                    IsSoftDeleteFeatureStateEditable = true,
                }
            };
            var backupResourceVaultConfig = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
            BackupResourceVaultConfigResource backupResourceVaultConfig_1 = await collection.GetAsync(vaultName);
            Assert.AreEqual(backupResourceVaultConfig.Data.Name, backupResourceVaultConfig_1.Data.Name);
            Assert.AreEqual(backupResourceVaultConfig.Data.Id, backupResourceVaultConfig_1.Data.Id);
            Assert.AreEqual(backupResourceVaultConfig.Data.Location, backupResourceVaultConfig_1.Data.Location);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupResourceVaultConfigs();
            var data = new BackupResourceVaultConfigData(AzureLocation.EastUS)
            {
                Properties = new Models.BackupResourceVaultConfigProperties()
                {
                    StorageModelType = BackupStorageType.LocallyRedundant,
                    StorageType = BackupStorageType.LocallyRedundant,
                    StorageTypeState = BackupStorageTypeState.Unlocked,
                    EnhancedSecurityState = EnhancedSecurityState.Enabled,
                    SoftDeleteFeatureState = SoftDeleteFeatureState.Enabled,
                    IsSoftDeleteFeatureStateEditable = true,
                }
            };
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data);
            var result_1 = (await collection.ExistsAsync(vaultName)).Value;
            Assert.IsTrue(result_1);
        }
    }
}
