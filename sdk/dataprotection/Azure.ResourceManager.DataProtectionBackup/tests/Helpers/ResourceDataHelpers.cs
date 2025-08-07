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

        public static DataProtectionBackupPolicyData GetDiskPolicyData()
        {
            List<string> dataSource = new() { "Microsoft.Compute/disks" };
            List<DataProtectionBasePolicyRule> rules = new()
            {
                new DataProtectionBackupRule(
                    "Default",
                    new DataStoreInfoBase(DataStoreType.OperationalStore, "DataStoreInfoBase"),
                    new ScheduleBasedBackupTriggerContext(
                        new DataProtectionBackupSchedule( new List<string>{ "R/2023-04-27T15:30:00+00:00/P1D" } ){ TimeZone = "UTC" },
                        new List<DataProtectionBackupTaggingCriteria>{ new DataProtectionBackupTaggingCriteria(true, 99, new DataProtectionBackupRetentionTag("Default")) }
                    ))
                {
                    BackupParameters = new DataProtectionBackupSettings("Incremental")
                    {
                        ObjectType = "AzureBackupParams"
                    }
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
                            new DataProtectionBackupAbsoluteDeleteSetting(XmlConvert.ToTimeSpan("P7D"))
                            {
                                ObjectType = "AbsoluteDeleteOption"
                            },
                            new DataStoreInfoBase(DataStoreType.OperationalStore, "DataStoreInfoBase")
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
        public static DataProtectionBackupInstanceData GetInstanceData(ResourceIdentifier policyId, String instanceName)
        {
            var instanceData = new DataProtectionBackupInstanceData()
            {
                Properties = new DataProtectionBackupInstanceProperties(
                    new DataSourceInfo(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0427/providers/Microsoft.Compute/disks/sdktestdisk"))
                    {
                        ResourceUriString = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0427/providers/Microsoft.Compute/disks/sdktestdisk",
                        DataSourceType = "Microsoft.Compute/disks",
                        ResourceName = "sdktestdisk",
                        ResourceType = new ResourceType("Microsoft.Compute/disks"),
                        ResourceLocation = AzureLocation.EastUS,
                        ObjectType = "Datasource"
                    },
                    new BackupInstancePolicyInfo(policyId)
                    {
                        PolicyParameters = new BackupInstancePolicySettings()
                        {
                            BackupDataSourceParametersList = { new UnknownBackupDatasourceParameters("AzureOperationalStoreParameters" ,null) }
                        }
                    },
                    "BackupInstance"
                    )
                {
                    FriendlyName = instanceName,
                    DataSourceSetInfo = new DataSourceSetInfo(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0427/providers/Microsoft.Compute/disks/sdktestdisk"))
                    {
                        ResourceUriString = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0427/providers/Microsoft.Compute/disks/sdktestdisk",
                        DataSourceType = "Microsoft.Compute/disks",
                        ResourceName = "sdktestdisk",
                        ResourceType = new ResourceType("Microsoft.Compute/disks"),
                        ResourceLocation = AzureLocation.EastUS,
                        ObjectType = "Datasource"
                    }
                }
            };
            return instanceData;
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
            var data = new DataProtectionBackupVaultData(AzureLocation.EastUS, new Models.DataProtectionBackupVaultProperties(setting))
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
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
