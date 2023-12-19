// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServices.Tests.Scenario
{
    public class RecoveryServicesVaultCollectionTests : RecoveryServicesManagementTestBase
    {
        public RecoveryServicesVaultCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RecoveryServicesRG", AzureLocation.EastAsia);
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroupe = await CreateResourceGroupAsync();
            var collection = resourceGroupe.GetRecoveryServicesVaults();
            var vaultName = Recording.GenerateAssetName("RecoveryServicesVault");
            var data = new RecoveryServicesVaultData(AzureLocation.EastAsia)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                    SecuritySettings = new RecoveryServicesSecuritySettings()
                    {
                        ImmutabilitySettings = new ImmutabilitySettings()
                        {
                            State = "Disabled",
                        }
                    },
                },
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
                {
                    Name = RecoveryServicesSkuName.RS0,
                    Tier = "Standard",
                },
            };
            var recoveryServicesVault = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
            Assert.AreEqual(recoveryServicesVault.Data.Name, vaultName);
            Assert.AreEqual(recoveryServicesVault.Data.Location, AzureLocation.EastAsia);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetRecoveryServicesVaults();
            var vaultName = Recording.GenerateAssetName("RecoveryServicesVault");
            var data = new RecoveryServicesVaultData(AzureLocation.EastAsia)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                    SecuritySettings = new RecoveryServicesSecuritySettings()
                    {
                        ImmutabilitySettings = new ImmutabilitySettings()
                        {
                            State = "Disabled",
                        }
                    },
                },
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
                {
                    Name = RecoveryServicesSkuName.RS0,
                    Tier = "Standard",
                },
            };
            var recoveryServicesVault = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
            RecoveryServicesVaultResource recoveryServicesVault2 = await collection.GetAsync(vaultName);
            Assert.AreEqual(recoveryServicesVault.Data.Name, recoveryServicesVault2.Data.Name);
            Assert.AreEqual(recoveryServicesVault.Data.Location, recoveryServicesVault2.Data.Location);
            Assert.AreEqual(recoveryServicesVault.Data.Id, recoveryServicesVault2.Data.Id);
            Assert.AreEqual(recoveryServicesVault.Data.ResourceType, recoveryServicesVault2.Data.ResourceType);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetRecoveryServicesVaults();
            var vaultName_1 = Recording.GenerateAssetName("RecoveryServicesVault");
            var vaultName_2 = Recording.GenerateAssetName("RecoveryServicesVault");
            var data = new RecoveryServicesVaultData(AzureLocation.EastAsia)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                    SecuritySettings = new RecoveryServicesSecuritySettings()
                    {
                        ImmutabilitySettings = new ImmutabilitySettings()
                        {
                            State = "Disabled",
                        }
                    },
                },
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
                {
                    Name = RecoveryServicesSkuName.RS0,
                    Tier = "Standard",
                },
            };
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName_1, data);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName_2, data);
            var count = 0;
            await foreach (var _ in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroupe = await CreateResourceGroupAsync();
            var collection = resourceGroupe.GetRecoveryServicesVaults();
            var vaultName = Recording.GenerateAssetName("RecoveryServicesVault");
            var data = new RecoveryServicesVaultData(AzureLocation.EastAsia)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new RecoveryServicesVaultProperties()
                {
                    PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                    SecuritySettings = new RecoveryServicesSecuritySettings()
                    {
                        ImmutabilitySettings = new ImmutabilitySettings()
                        {
                            State = "Disabled",
                        }
                    }
                },
                Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
                {
                    Name = RecoveryServicesSkuName.RS0,
                    Tier = "Standard",
                },
            };
            var recoveryServicesVault = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
            var result_1 = (await collection.ExistsAsync(recoveryServicesVault.Data.Name)).Value;
            Assert.IsTrue(result_1);
        }
    }
}
