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
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupPrivateEndpointConnectionCollectionTests:RecoveryServicesBackupManagementTestBase
    {
        public BackupPrivateEndpointConnectionCollectionTests(bool isAsync)
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
            var RSV = await CreateRSVault(resourceGroup);
            var vaultName = RSV.Data.Name;
            var collection = resourceGroup.GetBackupPrivateEndpointConnections();
            var privateEndpointName = Recording.GenerateAssetName("privateEndpoint_");
            var data = new BackupPrivateEndpointConnectionData(AzureLocation.EastUS)
            {
                Properties = new BackupPrivateEndpointConnectionProperties()
                {
                    PrivateEndpoint = new WritableSubResource()
                    {
                        Id = {},//需要container的id，暂时做不了了
                    },
                    PrivateLinkServiceConnectionState = new RecoveryServicesBackupPrivateLinkServiceConnectionState()
                    {
                        Description = "nothing",
                        ActionRequired = "nothing",
                    },
                }
            };
            var backupPrivateEndpointConnection = await collection.CreateOrUpdateAsync(WaitUntil.Completed,vaultName,privateEndpointName,data);
        }
    }
}
