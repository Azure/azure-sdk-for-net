// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class VirtualMachineHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        public static void AssertVirtualMachine(VirtualMachineData vm1, VirtualMachineData vm2)
        {
            Assert.AreEqual(vm1.Name, vm2.Name);
            Assert.AreEqual(vm1.Id, vm2.Id);
            Assert.AreEqual(vm1.Type, vm2.Type);
            Assert.AreEqual(vm1.Location, vm2.Location);
            Assert.AreEqual(vm1.Tags, vm2.Tags);
            // adding these checks one by one is so tedious, is there anything we can do about this?
        }

        public static VirtualMachineData GetBasicLinuxVirtualMachineData(Location location, string computerName, string nicID, string adminUsername = "adminuser")
        {
            return new VirtualMachineData(location)
            {
                HardwareProfile = new HardwareProfile()
                {
                    VmSize = VirtualMachineSizeTypes.StandardF2
                },
                OsProfile = new OSProfile()
                {
                    AdminUsername = adminUsername,
                    ComputerName = computerName,
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = true,
                        Ssh = new SshConfiguration()
                        {
                            PublicKeys = {
                                new SshPublicKeyInfo()
                                {
                                    Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                    KeyData = dummySSHKey,
                                }
                            }
                        }
                    }
                },
                NetworkProfile = new NetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new NetworkInterfaceReference()
                        {
                            Id = nicID,
                            Primary = true,
                        }
                    }
                },
                StorageProfile = new StorageProfile()
                {
                    OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                    {
                        OsType = OperatingSystemTypes.Linux,
                        Caching = CachingTypes.ReadWrite,
                        ManagedDisk = new ManagedDiskParameters()
                        {
                            StorageAccountType = StorageAccountTypes.StandardLRS
                        }
                    },
                    ImageReference = new ImageReference()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };
        }
    }
}
