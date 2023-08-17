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
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using NUnit.Framework;
using Azure.ResourceManager;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServices.Models;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Collections;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Scenario
{
    internal class BackupProtectionPolicyCollectionTests : RecoveryServicesBackupManagementTestBase
    {
        public BackupProtectionPolicyCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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

        public async Task<BackupProtectionPolicyResource> CreateBackupProtection(String policyName,ResourceGroupResource resourceGroup, BackupProtectionPolicyCollection collection)
        {
            var data = new BackupProtectionPolicyData(AzureLocation.EastUS)
            {
                Properties = new FileShareProtectionPolicy()
                {
                    BackupManagementType = "AzureStorage",
                    WorkLoadType = BackupWorkloadType.AzureFileShare,
                    SchedulePolicy = new SimpleSchedulePolicy()
                    {
                        SchedulePolicyType = "SimpleSchedulePolicy",
                        ScheduleRunFrequency = ScheduleRunType.Hourly,
                        HourlySchedule = new BackupHourlySchedule()
                        {
                            Interval = 4,
                            //"scheduleWindowStartTime": "2021-09-29T08:00:00.000Z",
                            ScheduleWindowStartOn = new DateTimeOffset(new DateTime(2023, 08, 11, 08, 00, 00, 000)),
                            ScheduleWindowDuration = 12
                        }
                    },
                    TimeZone = "UTC",
                    RetentionPolicy = new LongTermRetentionPolicy()
                    {
                        DailySchedule = new DailyRetentionSchedule()
                        {
                            RetentionDuration = new RetentionDuration()
                            {
                                Count = 30,
                                DurationType = RetentionDurationType.Days,
                            }
                        },
                    }
                },
            };
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, policyName, data)).Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupProtectionPolicies(vaultName);
            var policyName = Recording.GenerateAssetName("Policy");
            var backupProtectionPolicy = await CreateBackupProtection(policyName, resourceGroup, collection);
            Assert.AreEqual(backupProtectionPolicy.Data.Name, policyName);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupProtectionPolicies(vaultName);
            var policyName = Recording.GenerateAssetName("Policy");
            var backupProtectionPolicy = await CreateBackupProtection(policyName, resourceGroup, collection);
            BackupProtectionPolicyResource backupProtectionPolicy_1 = await (collection.GetAsync(policyName));
            Assert.AreEqual(backupProtectionPolicy.Data.Name,backupProtectionPolicy_1.Data.Name);
            Assert.AreEqual(backupProtectionPolicy.Data.Location, backupProtectionPolicy_1.Data.Location);
            Assert.AreEqual(backupProtectionPolicy.Data.Id, backupProtectionPolicy_1.Data.Id);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupProtectionPolicies(vaultName);
            var policyName_1 = Recording.GenerateAssetName("Policy");
            var policyName_2 = Recording.GenerateAssetName("Policy");
            _ = await CreateBackupProtection(policyName_1, resourceGroup, collection);
            _ = await CreateBackupProtection(policyName_2, resourceGroup, collection);
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
            var resourceGroup = await CreateResourceGroupAsync();
            var RSVault = await CreateRSVault(resourceGroup);
            var vaultName = RSVault.Data.Name;
            var collection = resourceGroup.GetBackupProtectionPolicies(vaultName);
            var policyName = Recording.GenerateAssetName("Policy");
            _ = await CreateBackupProtection(policyName, resourceGroup, collection);
            var result_1 = (await collection.ExistsAsync(policyName)).Value;
            Assert.IsTrue(result_1);
        }
    }
}
