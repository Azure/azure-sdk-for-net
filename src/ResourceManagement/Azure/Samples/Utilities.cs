using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples
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

        internal static void PrintStorageAccountKeys(IList<StorageAccountKey> storageAccountKeys)
        {
            foreach (var storageAccountKey in storageAccountKeys)
            {
                Console.WriteLine($"Key + {storageAccountKey.KeyName} = {storageAccountKey.Value}");
            }
        }

        internal static void PrintStorageAccount(IStorageAccount storageAccount)
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
    }
}