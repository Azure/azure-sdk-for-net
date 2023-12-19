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
    public class PrivateLinkResourceCollectionTests : RecoveryServicesManagementTestBase
    {
        public PrivateLinkResourceCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RecoveryServicesRG", AzureLocation.EastAsia);
        }

        private async Task<RecoveryServicesVaultResource> CreateRecoveryServicesVault(ResourceGroupResource resourceGroup)
        {
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
            return recoveryServicesVault;
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var recoveryServicesVault = await CreateRecoveryServicesVault(resourceGroup);
            var privateLinkResourceCollection = recoveryServicesVault.GetRecoveryServicesPrivateLinkResources();
            var privateLinkResources = (await privateLinkResourceCollection.GetAsync("backupResource")).Value;
            Assert.AreEqual(privateLinkResources.Data.Name,"backupResource");
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var recoveryServicesVaule = await CreateRecoveryServicesVault(resourceGroup);
            var privateLinkResourceCollection = recoveryServicesVaule.GetRecoveryServicesPrivateLinkResources();
            Assert.IsTrue(await privateLinkResourceCollection.ExistsAsync("backupResource"));
            Assert.IsFalse(await privateLinkResourceCollection.ExistsAsync("backupResource" + 1));
        }

        [RecordedTest]
        [Ignore("Invalid response ID")]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var recoveryServicesVault = await CreateRecoveryServicesVault(resourceGroup);
            var privateLinkResourceCollection = recoveryServicesVault.GetRecoveryServicesPrivateLinkResources();
            var count = 0;
            await foreach (var privateLinkResource in privateLinkResourceCollection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
    }
}
