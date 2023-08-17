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
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Extensions.Azure;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{//没有CreateOrUpdate方法
    public class BackupEngineCollectionTests//:RecoveryServicesBackupManagementTestBase
    {
        //public BackupEngineCollectionTests(bool isAsync)
        //    : base(isAsync, RecordedTestMode.Record)
        //{
        //}
        //public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        //{
        //    return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "BackupRG", AzureLocation.EastAsia);
        //}
        //public async Task<RecoveryServicesVaultResource> CreateRSVault(ResourceGroupResource resourceGroup)
        //{
        //    var collection = resourceGroup.GetRecoveryServicesVaults();
        //    var vaultName = Recording.GenerateAssetName("RecoveryServicesVault");
        //    var data = new RecoveryServicesVaultData(AzureLocation.EastUS)
        //    {
        //        Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
        //        Properties = new RecoveryServicesVaultProperties()
        //        {
        //            PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
        //        },
        //        Sku = new RecoveryServicesSku(RecoveryServicesSkuName.RS0)
        //        {
        //            Name = RecoveryServicesSkuName.RS0,
        //            Tier = "Standard",
        //        },
        //    };
        //    return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, data)).Value;
        //}
        //[RecordedTest]
        //public async Task Get()
        //{
        //    var resourceGroup = await CreateResourceGroupAsync();
        //    var RSVault = await CreateRSVault(resourceGroup);
        //    var vaultName = RSVault.Data.Name;
        //    var backUpEngineName = Recording.GenerateAssetName("backupEngine");
        //    var collection = resourceGroup.GetBackupEngines(vaultName);
        //    var backupEngine = (await collection.GetAsync(backUpEngineName)).Value;//通过名称获取整个资源的数据
        //    Assert.IsNotNull(backupEngine);
        //}
    }
}
