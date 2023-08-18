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
    internal class ResourceGuardProxyCollectionTests : RecoveryServicesBackupManagementTestBase
    {
        public ResourceGuardProxyCollectionTests(bool isAsync)
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
        [Ignore("No ResourceGuard sdk avilable")]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSV = await CreateRSVault(resourceGroup);
            var vaultName = RSV.Data.Name;
            var resourceGuardProxyName = Recording.GenerateAssetName("resourceGuardProxy");
            var collection = resourceGroup.GetResourceGuardProxies(vaultName);
            var data = new ResourceGuardProxyData(AzureLocation.EastUS)
            {
                Properties = new ResourceGuardProxyProperties()
                {
                    ResourceGuardResourceId = {}, //need resource guard
                    Description = "nothing",
                    ResourceGuardOperationDetails = {},
                    LastUpdatedOn = DateTime.UtcNow,
                }
            };
            var ResourceGuardProxy = await collection.CreateOrUpdateAsync(WaitUntil.Completed,resourceGuardProxyName,data);
        }
    }
}
