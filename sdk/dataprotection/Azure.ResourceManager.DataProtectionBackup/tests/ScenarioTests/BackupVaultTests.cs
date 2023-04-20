// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataProtectionBackup.Tests
{
    public class BackupVaultTests : DataProtectionBackupManagementTestBase
    {
        public BackupVaultTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [Ignore("Only need to verify serialize and deserialize")]
        public async Task RegressionTest()
        {
            // Deserialize test
            // Create a Backup vault with this arm template:
            // https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.dataprotection/backup-create-storage-account-enable-protection/azuredeploy.json
            var id = DataProtectionBackupVaultResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, "sdktest", "sdktest1564");
            var vault = Client.GetDataProtectionBackupVaultResource(id);
            var instances = await vault.GetDataProtectionBackupInstances().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, instances.Count());
            Assert.IsFalse(String.IsNullOrEmpty(instances.FirstOrDefault().Data.Properties.DataSourceInfo.ResourceUriString));
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNull(instances.FirstOrDefault().Data.Properties.DataSourceInfo.ResourceUri);
#pragma warning restore CS0618 // Type or member is obsolete

            // Serialize test
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var resourceGroup = await CreateResourceGroup(subscription, "backuptest", AzureLocation.EastUS);
            var vaultCollection = resourceGroup.GetDataProtectionBackupVaults();
            var properties = new List<DataProtectionBackupStorageSetting>();
            properties.Add(new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.VaultStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            });
            properties.Add(new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.OperationalStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            });
            var vaultData = new DataProtectionBackupVaultData(AzureLocation.EastUS, new DataProtectionBackupVaultProperties(properties))
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var vaultName = Recording.GenerateAssetName("sdktestvault");
            vault = (await vaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, vaultData)).Value;

            Assert.AreEqual(vaultName, vault.Data.Name);

            var policyCollection = vault.GetDataProtectionBackupPolicies();
            List<string> dataSource = new() { "Microsoft.Storage/storageAccounts/blobServices" };
            List<DataProtectionBasePolicyRule> rules = new()
            {
                new DataProtectionBackupRule(
                    "BackupDaily",
                    new DataStoreInfoBase(DataStoreType.VaultStore, "DataStoreInfoBase"),
                    new ScheduleBasedBackupTriggerContext(
                        new DataProtectionBackupSchedule( new List<string>{ "R/2023-04-17T16:00:00\u002B00:00/P1D"} ){ TimeZone = "UTC" },
                        new List<DataProtectionBackupTaggingCriteria>{ new DataProtectionBackupTaggingCriteria(true, 99, new DataProtectionBackupRetentionTag("Default")) }
                    ))
                {
                    BackupParameters = new DataProtectionBackupSettings("Discrete")
                },
                new DataProtectionRetentionRule(
                    "Default",
                    new List<SourceLifeCycle>
                    {
                        new SourceLifeCycle(
                            new DataProtectionBackupAbsoluteDeleteSetting(XmlConvert.ToTimeSpan("P30D")),
                            new DataStoreInfoBase(DataStoreType.OperationalStore, "DataStoreInfoBase")
                            ),
                        new SourceLifeCycle(
                            new DataProtectionBackupAbsoluteDeleteSetting(XmlConvert.ToTimeSpan("P7D")),
                            new DataStoreInfoBase(DataStoreType.VaultStore, "DataStoreInfoBase")
                            )
                    }
                    )
                {
                    IsDefault = true
                }
            };
            var policyData = new DataProtectionBackupPolicyData()
            {
                Properties = new RuleBasedBackupPolicy(dataSource, rules)
            };
            var policy = (await policyCollection.CreateOrUpdateAsync(WaitUntil.Completed, "retentionpolicy2", policyData)).Value;

            var instanceCollection = vault.GetDataProtectionBackupInstances();
            var instanceName = Recording.GenerateAssetName("sdktest");
            var instanceData = new DataProtectionBackupInstanceData()
            {
                Properties = new DataProtectionBackupInstanceProperties(
                    new DataSourceInfo(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest/providers/Microsoft.Storage/storageAccounts/test4676"))
                    {
                        ResourceUriString = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest/providers/Microsoft.Storage/storageAccounts/test4676",
                        DataSourceType = "Microsoft.Storage/storageAccounts/blobServices",
                        ResourceName = "test4676",
                        ResourceType = new ResourceType("Microsoft.Storage/storageAccounts"),
                        ResourceLocation = AzureLocation.EastUS,
                        ObjectType = "Datasource"
                    },
                    new BackupInstancePolicyInfo(policy.Id)
                    {
                        PolicyParameters = new BackupInstancePolicySettings()
                        {
                            BackupDataSourceParametersList = { new BlobBackupDataSourceSettings(new List<string> { "const" }) }
                        }
                    },
                    "BackupInstance"
                    )
                {
                    FriendlyName = instanceName,
                    DataSourceSetInfo = new DataSourceSetInfo(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest/providers/Microsoft.Storage/storageAccounts/test4676"))
                    {
                        ResourceUriString = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest/providers/Microsoft.Storage/storageAccounts/test4676",
                        DataSourceType = "Microsoft.Storage/storageAccounts/blobServices",
                        ResourceName = "test4676",
                        ResourceType = new ResourceType("Microsoft.Storage/storageAccounts"),
                        ResourceLocation = AzureLocation.EastUS,
                        ObjectType = "Datasource"
                    }
                }
            };
            var instance = (await instanceCollection.CreateOrUpdateAsync(WaitUntil.Completed, "test4676-test4676-500a6c9e-ca3f-4336-beb0-1e434260e03b", instanceData)).Value;
            Assert.AreEqual(instanceName, instance.Data.Properties.FriendlyName);
        }
    }
}
