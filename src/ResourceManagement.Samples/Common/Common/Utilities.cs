// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Fluent.Redis;
using Microsoft.Azure.Management.V2.Network;

namespace Micosoft.Azure.Management.Samples.Common
{
    public static class Utilities
    {
        public static void PrintVirtualMachine(IVirtualMachine virtualMachine)
        {
            StringBuilder storageProfile = new StringBuilder().Append("\n\tStorageProfile: ");
            if (virtualMachine.StorageProfile.ImageReference != null)
            {
                storageProfile.Append("\n\t\tImageReference:");
                storageProfile.Append("\n\t\t\tPublisher: ").Append(virtualMachine.StorageProfile.ImageReference.Publisher);
                storageProfile.Append("\n\t\t\tOffer: ").Append(virtualMachine.StorageProfile.ImageReference.Offer);
                storageProfile.Append("\n\t\t\tSKU: ").Append(virtualMachine.StorageProfile.ImageReference.Sku);
                storageProfile.Append("\n\t\t\tVersion: ").Append(virtualMachine.StorageProfile.ImageReference.Version);
            }

            if (virtualMachine.StorageProfile.OsDisk != null)
            {
                storageProfile.Append("\n\t\tOSDisk:");
                storageProfile.Append("\n\t\t\tOSType: ").Append(virtualMachine.StorageProfile.OsDisk.OsType);
                storageProfile.Append("\n\t\t\tName: ").Append(virtualMachine.StorageProfile.OsDisk.Name);
                storageProfile.Append("\n\t\t\tCaching: ").Append(virtualMachine.StorageProfile.OsDisk.Caching);
                storageProfile.Append("\n\t\t\tCreateOption: ").Append(virtualMachine.StorageProfile.OsDisk.CreateOption);
                storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(virtualMachine.StorageProfile.OsDisk.DiskSizeGB);
                if (virtualMachine.StorageProfile.OsDisk.Image != null)
                {
                    storageProfile.Append("\n\t\t\tImage Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Image.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.Vhd != null)
                {
                    storageProfile.Append("\n\t\t\tVhd Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Vhd.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.EncryptionSettings != null)
                {
                    storageProfile.Append("\n\t\t\tEncryptionSettings: ");
                    storageProfile.Append("\n\t\t\t\tEnabled: ").Append(virtualMachine.StorageProfile.OsDisk.EncryptionSettings.Enabled);
                    storageProfile.Append("\n\t\t\t\tDiskEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .DiskEncryptionKey.SecretUrl);
                    storageProfile.Append("\n\t\t\t\tKeyEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .KeyEncryptionKey.KeyUrl);
                }
            }

            if (virtualMachine.StorageProfile.DataDisks != null)
            {
                int i = 0;
                foreach (var disk in virtualMachine.StorageProfile.DataDisks)
                {
                    storageProfile.Append("\n\t\tDataDisk: #").Append(i++);
                    storageProfile.Append("\n\t\t\tName: ").Append(disk.Name);
                    storageProfile.Append("\n\t\t\tCaching: ").Append(disk.Caching);
                    storageProfile.Append("\n\t\t\tCreateOption: ").Append(disk.CreateOption);
                    storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(disk.DiskSizeGB);
                    storageProfile.Append("\n\t\t\tLun: ").Append(disk.Lun);
                    if (disk.Vhd.Uri != null)
                    {
                        storageProfile.Append("\n\t\t\tVhd Uri: ").Append(disk.Vhd.Uri);
                    }
                    if (disk.Image != null)
                    {
                        storageProfile.Append("\n\t\t\tImage Uri: ").Append(disk.Image.Uri);
                    }
                }
            }

            StringBuilder osProfile = new StringBuilder().Append("\n\tOSProfile: ");
            osProfile.Append("\n\t\tComputerName:").Append(virtualMachine.OsProfile.ComputerName);
            if (virtualMachine.OsProfile.WindowsConfiguration != null)
            {
                osProfile.Append("\n\t\t\tWindowsConfiguration: ");
                osProfile.Append("\n\t\t\t\tProvisionVMAgent: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.ProvisionVMAgent);
                osProfile.Append("\n\t\t\t\tEnableAutomaticUpdates: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.EnableAutomaticUpdates);
                osProfile.Append("\n\t\t\t\tTimeZone: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.TimeZone);
            }

            if (virtualMachine.OsProfile.LinuxConfiguration != null)
            {
                osProfile.Append("\n\t\t\tLinuxConfiguration: ");
                osProfile.Append("\n\t\t\t\tDisablePasswordAuthentication: ")
                        .Append(virtualMachine.OsProfile.LinuxConfiguration.DisablePasswordAuthentication);
            }

            StringBuilder networkProfile = new StringBuilder().Append("\n\tNetworkProfile: ");
            foreach (var networkInterfaceId in virtualMachine.NetworkInterfaceIds)
            {
                networkProfile.Append("\n\t\tId:").Append(networkInterfaceId);
            }

            Console.WriteLine(new StringBuilder().Append("Virtual Machine: ").Append(virtualMachine.Id)
                    .Append("Name: ").Append(virtualMachine.Name)
                    .Append("\n\tResource group: ").Append(virtualMachine.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(virtualMachine.Region)
                    .Append("\n\tTags: ").Append(virtualMachine.Tags)
                    .Append("\n\tHardwareProfile: ")
                    .Append("\n\t\tSize: ").Append(virtualMachine.Size)
                    .Append(storageProfile)
                    .Append(osProfile)
                    .Append(networkProfile)
                    .ToString());
        }

        public static void PrintStorageAccountKeys(IList<StorageAccountKey> storageAccountKeys)
        {
            foreach (var storageAccountKey in storageAccountKeys)
            {
                Console.WriteLine($"Key + {storageAccountKey.KeyName} = {storageAccountKey.Value}");
            }
        }

        public static void PrintStorageAccount(IStorageAccount storageAccount)
        {
            Console.WriteLine($"{storageAccount.Name} created @ {storageAccount.CreationTime}");
        }

        public static string createRandomName(String namePrefix)
        {
            var root = Guid.NewGuid().ToString().Replace("-", "");
            return $"{namePrefix}{root.ToLower().Substring(0, 3)}{(DateTime.UtcNow.Millisecond % 10000000L)}";
        }

        public static void PrintAvailabilitySet(IAvailabilitySet resource)
        {
            Console.WriteLine(new StringBuilder().Append("Availability Set: ").Append(resource.Id)
                .Append("Name: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.Region)
                .Append("\n\tTags: ").Append(resource.Tags)
                .Append("\n\tFault domain count: ").Append(resource.FaultDomainCount)
                .Append("\n\tUpdate domain count: ").Append(resource.UpdateDomainCount)
                .ToString());
        }

        public static void PrintRedisCache(IRedisCache redisCache)
        {
            StringBuilder redisInfo = new StringBuilder();
            redisInfo.Append("Redis Cache Name: ").AppendLine(redisCache.Name)
                     .Append("\tResource group: ").AppendLine(redisCache.ResourceGroupName)
                     .Append("\tRegion: ").AppendLine(redisCache.Region.ToString())
                     .Append("\tSKU Name: ").AppendLine(redisCache.Sku.Name)
                     .Append("\tSKU Family: ").AppendLine(redisCache.Sku.Family)
                     .Append("\tHost name: ").AppendLine(redisCache.HostName)
                     .Append("\tSSL port: ").AppendLine(redisCache.SslPort?.ToString())
                     .Append("\tNon-SSL port (6379) enabled: ").AppendLine(redisCache.NonSslPort?.ToString());
            if (redisCache.RedisConfiguration != null && redisCache.RedisConfiguration.Count > 0)
            {
                redisInfo.AppendLine("\tRedis Configuration:");
                foreach (KeyValuePair<string, string> rc in redisCache.RedisConfiguration)
                {
                    redisInfo.Append("\t  '").Append(rc.Key)
                             .Append("' : '").Append(rc.Value).AppendLine("'");
                }
            }
            if (redisCache.IsPremium)
            {
                var premium = redisCache.AsPremium();
                var scheduleEntries = premium.GetPatchSchedules();
                if (scheduleEntries != null && scheduleEntries.Any())
                {
                    redisInfo.AppendLine("\tRedis Patch Schedule:");
                    foreach (var schedule in scheduleEntries)
                    {
                        redisInfo.Append("\t\tDay: '").Append(schedule.DayOfWeek)
                                .Append("', start at: '").Append(schedule.StartHourUtc)
                                .Append("', maintenance window: '").Append(schedule.MaintenanceWindow)
                                .AppendLine("'");
                    }
                }
            }

            Console.WriteLine(redisInfo.ToString());
        }

        public static void PrintRedisAccessKeys(IRedisAccessKeys redisAccessKeys)
        {
            StringBuilder redisKeys = new StringBuilder();
            redisKeys.AppendLine("Redis Access Keys: ")
                     .Append("\tPrimary Key: '").Append(redisAccessKeys.PrimaryKey).AppendLine("', ")
                     .Append("\tSecondary Key: '").Append(redisAccessKeys.SecondaryKey).AppendLine("', ");

            Console.WriteLine(redisKeys.ToString());
        }

        public static void PrintNetworkSecurityGroup(INetworkSecurityGroup resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.RegionName)
                    .Append("\n\tTags: ").Append(resource.Tags);

            // Output security rules
            foreach (var rule in resource.SecurityRules())
            {
                info.Append("\n\tRule: ").Append(rule.Name)
                        .Append("\n\t\tAccess: ").Append(rule.Access)
                        .Append("\n\t\tDirection: ").Append(rule.Direction)
                        .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                        .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                        .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                        .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                        .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\tPriority: ").Append(rule.Priority);
            }
            Console.WriteLine(info.ToString());
        }
    }
}