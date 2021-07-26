// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class VirtualMachineScaleSetHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        public static void AssertVirtualMachineScaleSet(VirtualMachineScaleSetData vmss1, VirtualMachineScaleSetData vmss2)
        {
            Assert.AreEqual(vmss1.Id, vmss2.Id);
            Assert.AreEqual(vmss1.Name, vmss2.Name);
        }

        public static VirtualMachineScaleSetData GetBasicLinuxVirtualMachineScaleSetData(Location location, string computerNamePrefix, ResourceGroupResourceIdentifier subnetId, int capacity = 2, string adminUsername = "adminuser")
        {
            return new VirtualMachineScaleSetData(location)
            {
                Sku = new Models.Sku()
                {
                    Name = "Standard_F2",
                    Capacity = capacity,
                    Tier = "Standard"
                },
                UpgradePolicy = new UpgradePolicy()
                {
                    Mode = UpgradeMode.Manual,
                },
                VirtualMachineProfile = new VirtualMachineScaleSetVMProfile()
                {
                    OsProfile = new VirtualMachineScaleSetOSProfile()
                    {
                        ComputerNamePrefix = computerNamePrefix,
                        AdminUsername = adminUsername,
                        LinuxConfiguration = new LinuxConfiguration()
                        {
                            DisablePasswordAuthentication = true,
                            Ssh = new SshConfiguration()
                            {
                                PublicKeys =
                                {
                                    new SshPublicKeyInfo()
                                    {
                                        Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                        KeyData = dummySSHKey
                                    }
                                }
                            }
                        }
                    },
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        OsDisk = new VirtualMachineScaleSetOSDisk(DiskCreateOptionTypes.FromImage)
                        {
                            Caching = CachingTypes.ReadWrite,
                            ManagedDisk = new VirtualMachineScaleSetManagedDiskParameters()
                            {
                                StorageAccountType = StorageAccountTypes.StandardLRS
                            }
                        },
                        ImageReference = new ImageReference()
                        {
                            Publisher = "Canonical",
                            Offer = "UbuntuServer",
                            Sku = "16.04-LTS",
                            Version = "latest"
                        }
                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile()
                    {
                        NetworkInterfaceConfigurations =
                        {
                            new VirtualMachineScaleSetNetworkConfiguration("example")
                            {
                                Primary = true,
                                IpConfigurations =
                                {
                                    new VirtualMachineScaleSetIPConfiguration("internal")
                                    {
                                        Primary = true,
                                        Subnet = new ApiEntityReference()
                                        {
                                            Id = subnetId
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
