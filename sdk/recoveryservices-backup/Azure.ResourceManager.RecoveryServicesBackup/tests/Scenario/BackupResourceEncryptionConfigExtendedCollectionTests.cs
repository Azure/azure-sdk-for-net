// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.ManagedServiceIdentities;
using NUnit.Framework;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupResourceEncryptionConfigExtendedCollectionTests: RecoveryServicesBackupManagementTestBase
    {
        public BackupResourceEncryptionConfigExtendedCollectionTests(bool isAsync)
            :base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RecoveryServicesBackupRG", AzureLocation.EastUS);
        }

        public async Task<UserAssignedIdentityResource> CreateUAI(ResourceGroupResource resourceGroup)
        {
            var collection = resourceGroup.GetUserAssignedIdentities();
            var name = Recording.GenerateAssetName("UserAssignedIdentity");
            var data = new UserAssignedIdentityData(AzureLocation.EastUS);
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
        }

        public async Task<RecoveryServicesVaultResource> CreateRSV(ResourceGroupResource resourceGroup)
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

        public async Task<KeyVaultResource> CreateKeyVaultAsync(ResourceGroupResource resourceGroup, RecoveryServicesVaultResource recoveryServicesVault)
        {
            var collection = resourceGroup.GetKeyVaults();
            var vaultName = Recording.GenerateAssetName("KeyVault");
            var tenantId = TestEnvironment.TenantId;
            var skuName = KeyVaultSkuName.Premium;
            var sku = new KeyVaultSku(KeyVaultSkuFamily.A, skuName);
            var properties = new KeyVault.Models.KeyVaultProperties(Guid.Parse(tenantId), sku);
            var content = new KeyVaultCreateOrUpdateContent(AzureLocation.EastUS, properties);
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content)).Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var recoveryServicesVault = await CreateRSV(resourceGroup);
            var vaultName = recoveryServicesVault.Data.Name;
            var UAI = await CreateUAI(resourceGroup);
            var keyVault = await CreateKeyVaultAsync(resourceGroup, recoveryServicesVault);
            var keyClient = new KeyClient(keyVault.Data.Properties.VaultUri, TestEnvironment.Credential);
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var keyData = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
                ExpiresOn = DateTimeOffset.Now.AddYears(1)
            };

            await keyClient.CreateRsaKeyAsync(keyData);
            var rsaKey = (await keyClient.GetKeyAsync(rsaKeyName)).Value;
            var collection = resourceGroup.GetBackupResourceEncryptionConfigExtendeds();
            var content = new BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(AzureLocation.EastUS)
            {
                Properties = new BackupResourceEncryptionConfigExtendedProperties()
                {
                    EncryptionAtRestType = BackupEncryptionAtRestType.CustomerManaged,
                    KeyUri = rsaKey.Id,
                    SubscriptionId = TestEnvironment.SubscriptionId,
                    InfrastructureEncryptionState = Models.InfrastructureEncryptionState.Enabled,
                    //UserAssignedIdentity = UAI.Id,
                    //UseSystemAssignedIdentity = false,
                }
            };

            var backupResourceEncryptionConfigExtended = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content);
            Assert.IsNotNull(backupResourceEncryptionConfigExtended);
        }
    }
}
