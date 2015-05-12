// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    public class ConfigSplitHelper
    {
        private const int maxRank = 20;

        /// <summary>
        /// Rank corresponds to number of objects which can be accomadeted in a single request of
        /// Import Legacy config. ACR, SAC, CHAP, VDG = 1, BW, BP = 3, DC = 4, Vol = 5
        /// </summary>
        private static Dictionary<Type, int> ranks = new Dictionary<Type, int>()
        {
            {typeof (AccessControlRecord), 1},
            {typeof (StorageAccountCredential), 1},
            {typeof (MigrationChapSetting), 1},
            {typeof (VirtualDiskGroup), 1},
            {typeof (BandwidthSetting), 3},
            {typeof (MigrationBackupPolicy), 3},
            {typeof (MigrationDataContainer), 4},
            {typeof (VirtualDisk), 5}
        };

        /// <summary>
        /// Splits the inputConfig in smaller chunks of a size which the service can accept
        /// </summary>
        /// <param name='inputConfig'>
        /// Required. The complete list of LegacyApplianceConfig parsed
        /// </param>
        /// <returns>
        /// The smaller chunks of LegacyApplianceConfig which the service can process
        /// </returns>
        public static List<LegacyApplianceConfig> Split(LegacyApplianceConfig inputConfig)
        {
            var splitConfig = new List<LegacyApplianceConfig>();
            var serialNumber = 1;
            var parentConfig = new LegacyApplianceConfig();

            parentConfig.AccessControlRecords = new List<AccessControlRecord>(inputConfig.AccessControlRecords);
            parentConfig.BackupPolicies = new List<MigrationBackupPolicy>(inputConfig.BackupPolicies);
            parentConfig.BandwidthSettings = new List<BandwidthSetting>(inputConfig.BandwidthSettings);
            parentConfig.DeviceId = inputConfig.DeviceId;
            if (inputConfig.InboundChapSettings != null)
            {
                parentConfig.InboundChapSettings = new List<MigrationChapSetting>(inputConfig.InboundChapSettings);
            }
            parentConfig.InstanceId = inputConfig.InstanceId;
            parentConfig.Name = inputConfig.Name;
            parentConfig.OperationInProgress = inputConfig.OperationInProgress;
            parentConfig.SerialNumber = inputConfig.SerialNumber;
            parentConfig.StorageAccountCredentials =
                new List<StorageAccountCredential>(inputConfig.StorageAccountCredentials);
            if (inputConfig.TargetChapSettings != null)
            {
                parentConfig.TargetChapSettings = new List<MigrationChapSetting>(inputConfig.TargetChapSettings);
            }
            parentConfig.TotalCount = inputConfig.TotalCount;
            parentConfig.CloudConfigurations = new List<MigrationDataContainer>(inputConfig.CloudConfigurations);
            parentConfig.VolumeGroups = new List<VirtualDiskGroup>(inputConfig.VolumeGroups);
            parentConfig.Volumes = new List<VirtualDisk>(inputConfig.Volumes);

            while (!IsConfigEmpty(parentConfig))
            {
                var config = new LegacyApplianceConfig();
                var currRank = 0;
                var rank = 0;
                var objectCountCanBeAccomodated = 0;
                var objectsAccomodated = 0;

                config.SerialNumber = serialNumber++;

                config.DeviceId = parentConfig.DeviceId;
                config.InstanceId = parentConfig.InstanceId;
                config.Name = parentConfig.Name;
                config.OperationInProgress = parentConfig.OperationInProgress;

                rank = FindRank(typeof (VirtualDisk));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.Volumes.Count);
                    config.Volumes =
                        new List<VirtualDisk>(
                            config.Volumes.Concat(
                                parentConfig.Volumes.Take(objectsAccomodated)));
                    parentConfig.Volumes =
                        RemoveFirstNItems(new List<VirtualDisk>(parentConfig.Volumes),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.Volumes = new List<VirtualDisk>();
                }
                currRank += rank*objectsAccomodated;

                rank = FindRank(typeof (MigrationDataContainer));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.CloudConfigurations.Count);
                    config.CloudConfigurations =
                        new List<MigrationDataContainer>(
                            config.CloudConfigurations.Concat(
                                parentConfig.CloudConfigurations.Take(objectsAccomodated)));
                    parentConfig.CloudConfigurations =
                        RemoveFirstNItems(new List<MigrationDataContainer>(parentConfig.CloudConfigurations),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.CloudConfigurations = new List<MigrationDataContainer>();
                }
                currRank += rank*objectsAccomodated;

                rank = FindRank(typeof (MigrationBackupPolicy));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.BackupPolicies.Count);
                    config.BackupPolicies =
                        new List<MigrationBackupPolicy>(
                            config.BackupPolicies.Concat(
                                parentConfig.BackupPolicies.Take(objectsAccomodated)));
                    parentConfig.BackupPolicies =
                        RemoveFirstNItems(new List<MigrationBackupPolicy>(parentConfig.BackupPolicies),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.BackupPolicies = new List<MigrationBackupPolicy>();
                }
                currRank += rank*objectsAccomodated;

                rank = FindRank(typeof (BandwidthSetting));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.BandwidthSettings.Count);
                    config.BandwidthSettings =
                        new List<BandwidthSetting>(
                            config.BandwidthSettings.Concat(
                                parentConfig.BandwidthSettings.Take(objectsAccomodated)));
                    parentConfig.BandwidthSettings =
                        RemoveFirstNItems(new List<BandwidthSetting>(parentConfig.BandwidthSettings),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.BandwidthSettings = new List<BandwidthSetting>();
                }
                currRank += rank*objectsAccomodated;

                rank = FindRank(typeof (VirtualDiskGroup));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.VolumeGroups.Count);
                    config.VolumeGroups =
                        new List<VirtualDiskGroup>(
                            config.VolumeGroups.Concat(
                                parentConfig.VolumeGroups.Take(objectsAccomodated)));
                    parentConfig.VolumeGroups =
                        RemoveFirstNItems(new List<VirtualDiskGroup>(parentConfig.VolumeGroups),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.VolumeGroups = new List<VirtualDiskGroup>();
                }
                currRank += rank*objectsAccomodated;

                if (parentConfig.InboundChapSettings != null)
                {
                    rank = FindRank(typeof (MigrationChapSetting));
                    objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                    if (objectCountCanBeAccomodated > 0)
                    {
                        objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                            parentConfig.InboundChapSettings.Count);
                        config.InboundChapSettings =
                            new List<MigrationChapSetting>(
                                config.InboundChapSettings.Concat(
                                    parentConfig.InboundChapSettings.Take(objectsAccomodated)));
                        parentConfig.InboundChapSettings =
                            RemoveFirstNItems(new List<MigrationChapSetting>(parentConfig.InboundChapSettings),
                                objectsAccomodated);
                    }
                    else
                    {
                        objectsAccomodated = 0;
                        config.InboundChapSettings = new List<MigrationChapSetting>();
                    }
                    currRank += rank*objectsAccomodated;
                }

                if (parentConfig.TargetChapSettings != null)
                {
                    rank = FindRank(typeof (MigrationChapSetting));
                    objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                    if (objectCountCanBeAccomodated > 0)
                    {
                        objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                            parentConfig.TargetChapSettings.Count);
                        config.TargetChapSettings =
                            new List<MigrationChapSetting>(
                                config.TargetChapSettings.Concat(
                                    parentConfig.TargetChapSettings.Take(objectsAccomodated)));
                        parentConfig.TargetChapSettings =
                            RemoveFirstNItems(new List<MigrationChapSetting>(parentConfig.TargetChapSettings),
                                objectsAccomodated);
                    }
                    else
                    {
                        objectsAccomodated = 0;
                        config.TargetChapSettings = new List<MigrationChapSetting>();
                    }
                    currRank += rank*objectsAccomodated;
                }

                rank = FindRank(typeof (StorageAccountCredential));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.StorageAccountCredentials.Count);
                    config.StorageAccountCredentials =
                        new List<StorageAccountCredential>(
                            config.StorageAccountCredentials.Concat(
                                parentConfig.StorageAccountCredentials.Take(objectsAccomodated)));
                    parentConfig.StorageAccountCredentials =
                        RemoveFirstNItems(new List<StorageAccountCredential>(parentConfig.StorageAccountCredentials),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.StorageAccountCredentials = new List<StorageAccountCredential>();
                }
                currRank += rank*objectsAccomodated;

                rank = FindRank(typeof (AccessControlRecord));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.AccessControlRecords.Count);
                    config.AccessControlRecords =
                        new List<AccessControlRecord>(
                            config.AccessControlRecords.Concat(
                                parentConfig.AccessControlRecords.Take(objectsAccomodated)));
                    parentConfig.AccessControlRecords =
                        RemoveFirstNItems(new List<AccessControlRecord>(parentConfig.AccessControlRecords),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.AccessControlRecords = new List<AccessControlRecord>();
                }

                splitConfig.Add(config);
            }

            foreach (var config in splitConfig)
            {
                config.TotalCount = splitConfig.Count;
            }

            return splitConfig;
        }

        /// <summary>
        /// Checks if the provided config is empty or not
        /// </summary>
        /// <param name='config'>
        /// Required. A LegacyApplianceConfig 
        /// </param>
        /// <returns>
        /// The boolean specifying whether the config is empty or not
        /// </returns>
        private static bool IsConfigEmpty(LegacyApplianceConfig config)
        {
            return config.AccessControlRecords.Count == 0 &&
                   config.BackupPolicies.Count == 0 &&
                   config.BandwidthSettings.Count == 0 &&
                   (config.InboundChapSettings == null || config.InboundChapSettings.Count == 0) &&
                   config.StorageAccountCredentials.Count == 0 &&
                   (config.TargetChapSettings == null || config.TargetChapSettings.Count == 0) &&
                   config.CloudConfigurations.Count == 0 &&
                   config.VolumeGroups.Count == 0 &&
                   config.Volumes.Count == 0;
        }

        /// <summary>
        /// Finds the rank of given object
        /// </summary>
        /// <param name='T'>
        /// Required. The Object Type
        /// </param>
        /// <returns>
        /// The rank of the object type
        /// </returns>
        private static int FindRank(Type T)
        {
            return ranks[T];
        }

        /// <summary>
        /// Remove the first N items from a given list
        /// </summary>
        /// <param name='list'>
        /// Required. The Main List
        /// </param>
        /// /// <param name='count'>
        /// Required. The count of how many items to be removed.
        /// </param>
        /// <returns>
        /// The final list
        /// </returns>
        private static List<T> RemoveFirstNItems<T>(List<T> list, int count)
        {
            list.RemoveRange(0, count);
            return list;
        }
    }
}