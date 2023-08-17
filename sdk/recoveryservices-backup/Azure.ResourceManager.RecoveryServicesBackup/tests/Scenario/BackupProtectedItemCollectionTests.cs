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
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Microsoft.Extensions.Azure;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupProtectedItemCollectionTests : RecoveryServicesBackupManagementTestBase
    {
        public BackupProtectedItemCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RecoveryServicesBackupRG", AzureLocation.EastUS);
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
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var id = new ResourceIdentifier(resourceGroup.Id);
            BackupProtectedItemCollection collection = new BackupProtectedItemCollection(Client,id);
            //先创建一个container才能继续进行，因为BackupProtectedItemCollection是在BackupProtectionContainerResource里面

            //var backupProtectedItemResource = await resourceGroup.GetBackupProtectedItemsAsync(vaultName).ToEnumerableAsync();
            //foreach (var item in backupProtectedItemResource)
            //{
            //    item
            //}
            var protectedItemName = Recording.GenerateAssetName("protectedItemName");
            var data = new BackupProtectedItemData(AzureLocation.EastUS)
            {
                Properties = new FileshareProtectedItem()
                {
                    FriendlyName = "MyFileShare",
                    ProtectionStatus = "Healthy",
                    ProtectionState = BackupProtectionState.Protected,
                    LastBackupStatus = "Healthy",
                    LastBackupOn = DateTimeOffset.Parse("2023-08-11T09:26:09+08:00"),
                    ExtendedInfo = new FileshareProtectedItemExtendedInfo()
                    {
                        OldestRecoverOn = DateTimeOffset.Parse("2023-08-11T09:26:09+08:00"),
                        RecoveryPointCount = 10,
                        PolicyState = "Consistent",
                    },
                }
            };
            var backupProtectedItem = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, protectedItemName, data)).Value;
            Assert.AreEqual(backupProtectedItem.Data.Name, protectedItemName);
            Assert.AreEqual(backupProtectedItem.Data.Location, AzureLocation.EastUS);
        }
    }
}
