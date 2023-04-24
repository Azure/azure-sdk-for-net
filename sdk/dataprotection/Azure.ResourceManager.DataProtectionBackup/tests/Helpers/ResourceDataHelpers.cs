// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;
using System.Xml;

namespace Azure.ResourceManager.DataProtectionBackup.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region policy
        public static DataProtectionBackupPolicyData GetPolicyData()
        {
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
            return policyData;
        }

        public static void AssertpolicyData(DataProtectionBackupPolicyData data1, DataProtectionBackupPolicyData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.DataSourceTypes, data2.Properties.DataSourceTypes);
            Assert.AreEqual(data1.Properties.ObjectType, data2.Properties.ObjectType);
        }
        #endregion

        #region Instance
        public static DataProtectionBackupInstanceData GetInstanceData()
        {
            var data = new DataProtectionBackupInstanceData()
            {
                Properties = new DataProtectionBackupInstanceProperties(new DataSourceInfo(new ResourceIdentifier("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.Compute/disks/testingDisk"))
                {
                    ObjectType = "Datasource",
                    ResourceName = "testingDisk",
                    ResourceType = "Microsoft.Compute/disks",
                    ResourceUri = new Uri("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.Compute/disks/testingDisk"),
                    ResourceLocation = AzureLocation.SoutheastAsia,
                    DataSourceType = "Microsoft.Compute/disks"
                }, new BackupInstancePolicyInfo(new ResourceIdentifier("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/BackupVaults/DiskbackupVault2/backupPolicies/retentionpolicy2"))
                {
                    PolicyParameters = new BackupInstancePolicySettings()
                    {
                        DataStoreParametersList =
                        {
                            new OperationalDataStoreSettings(DataStoreType.OperationalStore)
                            {
                                ResourceGroupId = new ResourceIdentifier("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarOTDSRG")
                            }
                        }
                    },
                }, "BackupInstance")
                {
                }
            };
            return data;
        }
        public static void AssertInstanceData(DataProtectionBackupInstanceData data1, DataProtectionBackupInstanceData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.ProtectionErrorDetails, data2.Properties.ProtectionErrorDetails);
            Assert.AreEqual(data1.Properties.ObjectType, data2.Properties.ObjectType);
            Assert.AreEqual(data1.Properties.ValidationType, data2.Properties.ValidationType);
            Assert.AreEqual(data1.Properties.ProtectionStatus, data2.Properties.ProtectionStatus);
        }
        #endregion

        #region Vault
        public static DataProtectionBackupVaultData GetVaultData()
        {
            IEnumerable<DataProtectionBackupStorageSetting> setting = new List<DataProtectionBackupStorageSetting>() { new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.VaultStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            },
            new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.OperationalStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            }
            };
            var data = new DataProtectionBackupVaultData(AzureLocation.EastUS, new Models.DataProtectionBackupVaultProperties(setting));
            return data;
        }

        public static void AssertVaultData(DataProtectionBackupVaultData data1, DataProtectionBackupVaultData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.ProvisioningState, data2.Properties.ProvisioningState);
            Assert.AreEqual(data1.Properties.FeatureSettings, data2.Properties.FeatureSettings);
            Assert.AreEqual(data1.Properties.ProvisioningState, data2.Properties.ProvisioningState);
        }
        #endregion
    }
}
