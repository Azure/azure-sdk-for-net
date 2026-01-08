// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.Compute is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
                Assert.That(r2.Location, Is.EqualTo(r1.Location));
                Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
            });
        }

        #region AvailabilitySet
        public static void AssertAvailabilitySet(AvailabilitySetData set1, AvailabilitySetData set2)
        {
            AssertTrackedResource(set1, set2);
            Assert.Multiple(() =>
            {
                Assert.That(set2.PlatformFaultDomainCount, Is.EqualTo(set1.PlatformFaultDomainCount));
                Assert.That(set2.PlatformUpdateDomainCount, Is.EqualTo(set1.PlatformUpdateDomainCount));
                Assert.That(set2.ProximityPlacementGroup, Is.EqualTo(set1.ProximityPlacementGroup));
            });
            Assert.That(set2.ProximityPlacementGroup?.Id, Is.EqualTo(set1.ProximityPlacementGroup?.Id));
        }

        public static AvailabilitySetData GetBasicAvailabilitySetData(AzureLocation location)
        {
            return new AvailabilitySetData(location);
        }
        #endregion

        #region DedicatedHostGroup
        public static void AssertGroup(DedicatedHostGroupData group1, DedicatedHostGroupData group2)
        {
            AssertTrackedResource(group1, group2);
            Assert.Multiple(() =>
            {
                Assert.That(group2.PlatformFaultDomainCount, Is.EqualTo(group1.PlatformFaultDomainCount));
                Assert.That(group2.SupportAutomaticPlacement, Is.EqualTo(group1.SupportAutomaticPlacement));
            });
        }

        public static DedicatedHostGroupData GetBasicDedicatedHostGroup(AzureLocation location, int platformFaultDomainCount)
        {
            return new DedicatedHostGroupData(location)
            {
                PlatformFaultDomainCount = platformFaultDomainCount
            };
        }
        #endregion

        #region DedicatedHost
        public static void AssertHost(DedicatedHostData host1, DedicatedHostData host2)
        {
            AssertTrackedResource(host1, host2);
            Assert.Multiple(() =>
            {
                Assert.That(host2.Sku.Name, Is.EqualTo(host1.Sku.Name));
                Assert.That(host2.Sku.Tier, Is.EqualTo(host1.Sku.Tier));
                Assert.That(host2.Sku.Capacity, Is.EqualTo(host1.Sku.Capacity));
                Assert.That(host2.PlatformFaultDomain, Is.EqualTo(host1.PlatformFaultDomain));
            });
        }

        public static DedicatedHostData GetBasicDedicatedHost(AzureLocation location, string skuName, int platformFaultDomain)
        {
            return new DedicatedHostData(location, new ComputeSku()
            {
                Name = skuName
            })
            {
                PlatformFaultDomain = platformFaultDomain
            };
        }
        #endregion

        #region DiskAccess
        public static void AssertDiskAccess(DiskAccessData access1, DiskAccessData access2)
        {
            AssertTrackedResource(access1, access2);
        }

        public static DiskAccessData GetEmptyDiskAccess(AzureLocation location)
        {
            return new DiskAccessData(location);
        }
        #endregion

        #region Disk
        public static void AssertDisk(ManagedDiskData disk1, ManagedDiskData disk2)
        {
            AssertTrackedResource(disk1, disk2);
            Assert.Multiple(() =>
            {
                Assert.That(disk2.BurstingEnabled, Is.EqualTo(disk1.BurstingEnabled));
                Assert.That(disk2.DiskAccessId, Is.EqualTo(disk1.DiskAccessId));
                Assert.That(disk2.DiskIopsReadOnly, Is.EqualTo(disk1.DiskIopsReadOnly));
                Assert.That(disk2.DiskIopsReadWrite, Is.EqualTo(disk1.DiskIopsReadWrite));
                Assert.That(disk2.DiskSizeGB, Is.EqualTo(disk1.DiskSizeGB));
                Assert.That(disk2.ManagedBy, Is.EqualTo(disk1.ManagedBy));
                Assert.That(disk2.Encryption?.DiskEncryptionSetId, Is.EqualTo(disk1.Encryption?.DiskEncryptionSetId));
                Assert.That(disk2.Encryption?.EncryptionType, Is.EqualTo(disk1.Encryption?.EncryptionType));
                Assert.That(disk2.CreationData?.CreateOption, Is.EqualTo(disk1.CreationData?.CreateOption));
                Assert.That(disk2.CreationData?.ImageReference?.Id, Is.EqualTo(disk1.CreationData?.ImageReference?.Id));
                Assert.That(disk2.CreationData?.ImageReference?.Lun, Is.EqualTo(disk1.CreationData?.ImageReference?.Lun));
                Assert.That(disk2.CreationData?.GalleryImageReference?.Id, Is.EqualTo(disk1.CreationData?.GalleryImageReference?.Id));
                Assert.That(disk2.CreationData?.GalleryImageReference?.Lun, Is.EqualTo(disk1.CreationData?.GalleryImageReference?.Lun));
                Assert.That(disk2.CreationData?.LogicalSectorSize, Is.EqualTo(disk1.CreationData?.LogicalSectorSize));
                Assert.That(disk2.CreationData?.SourceResourceId, Is.EqualTo(disk1.CreationData?.SourceResourceId));
                Assert.That(disk2.CreationData?.SourceUniqueId, Is.EqualTo(disk1.CreationData?.SourceUniqueId));
                Assert.That(disk2.CreationData?.SourceUri, Is.EqualTo(disk1.CreationData?.SourceUri));
                Assert.That(disk2.CreationData?.StorageAccountId, Is.EqualTo(disk1.CreationData?.StorageAccountId));
                Assert.That(disk2.CreationData?.UploadSizeBytes, Is.EqualTo(disk1.CreationData?.UploadSizeBytes));
            });
        }

        public static ManagedDiskData GetEmptyDiskData(AzureLocation location, IDictionary<string, string> tags = null)
        {
            return new ManagedDiskData(location)
            {
                Sku = new DiskSku()
                {
                    Name = DiskStorageAccountType.StandardLrs
                },
                CreationData = new DiskCreationData(DiskCreateOption.Empty),
                DiskSizeGB = 1,
            };
        }
        #endregion

        #region Gallery
        public static void AssertGallery(GalleryData gallery1, GalleryData gallery2)
        {
            AssertTrackedResource(gallery1, gallery2);
            Assert.Multiple(() =>
            {
                Assert.That(gallery2.Description, Is.EqualTo(gallery1.Description));
                Assert.That(gallery2.Identifier?.UniqueName, Is.EqualTo(gallery1.Identifier?.UniqueName));
            });
        }

        public static GalleryData GetBasicGalleryData(AzureLocation location, string description = null)
        {
            var data = new GalleryData(location)
            {
                Description = description
            };
            return data;
        }
        #endregion

        #region GalleryImage
        public static void AssertGalleryImage(GalleryImageData image1, GalleryImageData image2)
        {
            AssertTrackedResource(image1, image2);
            Assert.Multiple(() =>
            {
                Assert.That(image2.Identifier.Offer, Is.EqualTo(image1.Identifier.Offer));
                Assert.That(image2.Identifier.Publisher, Is.EqualTo(image1.Identifier.Publisher));
                Assert.That(image2.Identifier.Sku, Is.EqualTo(image1.Identifier.Sku));
                Assert.That(image2.OSType, Is.EqualTo(image1.OSType));
                Assert.That(image2.OSState, Is.EqualTo(image1.OSState));
                Assert.That(image2.Description, Is.EqualTo(image1.Description));
            });
        }

        public static GalleryImageData GetBasicGalleryImageData(AzureLocation location, SupportedOperatingSystemType osType, GalleryImageIdentifier identifier)
        {
            var data = new GalleryImageData(location)
            {
                OSType = osType,
                Identifier = identifier
            };
            return data;
        }

        public static GalleryImageIdentifier GetGalleryImageIdentifier(string publisher, string offer, string sku)
        {
            return new GalleryImageIdentifier(publisher, offer, sku);
        }
        #endregion

        #region VirtualMachine
        public static void AssertVirtualMachine(VirtualMachineData vm1, VirtualMachineData vm2)
        {
            AssertTrackedResource(vm1, vm2);
            // adding these checks one by one is so tedious, is there anything we can do about this?
        }

        public static VirtualMachineData GetBasicLinuxVirtualMachineData(AzureLocation location, string computerName, ResourceIdentifier nicID, string adminUsername = "adminuser")
        {
            return new VirtualMachineData(location)
            {
                HardwareProfile = new()
                {
                    VmSize = VirtualMachineSizeType.StandardF2
                },
                OSProfile = new()
                {
                    AdminUsername = adminUsername,
                    ComputerName = computerName,
                    LinuxConfiguration = new()
                    {
                        DisablePasswordAuthentication = true,
                        Ssh = new()
                        {
                            PublicKeys = {
                                new()
                                {
                                    Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                    KeyData = dummySSHKey,
                                }
                            }
                        }
                    }
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = nicID,
                            Primary = true,
                        }
                    }
                },
                StorageProfile = new()
                {
                    OSDisk = new(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Linux,
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs
                        }
                    },
                    ImageReference = new()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };
        }
        #endregion

        #region VirtualMachineScaleSet
        public static void AssertVirtualMachineScaleSet(VirtualMachineScaleSetData vmss1, VirtualMachineScaleSetData vmss2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(vmss2.Id, Is.EqualTo(vmss1.Id));
                Assert.That(vmss2.Name, Is.EqualTo(vmss1.Name));
            });
        }

        public static VirtualMachineScaleSetData GetBasicLinuxVirtualMachineScaleSetData(AzureLocation location, string computerNamePrefix, ResourceIdentifier subnetId, int capacity = 2, string adminUsername = "adminuser")
        {
            return new VirtualMachineScaleSetData(location)
            {
                Sku = new()
                {
                    Name = "Standard_F2",
                    Capacity = capacity,
                    Tier = "Standard"
                },
                UpgradePolicy = new()
                {
                    Mode = VirtualMachineScaleSetUpgradeMode.Manual,
                },
                VirtualMachineProfile = new()
                {
                    OSProfile = new()
                    {
                        ComputerNamePrefix = computerNamePrefix,
                        AdminUsername = adminUsername,
                        LinuxConfiguration = new()
                        {
                            DisablePasswordAuthentication = true,
                            Ssh = new()
                            {
                                PublicKeys =
                                {
                                    new()
                                    {
                                        Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                        KeyData = dummySSHKey
                                    }
                                }
                            }
                        }
                    },
                    StorageProfile = new()
                    {
                        OSDisk = new(DiskCreateOptionType.FromImage)
                        {
                            Caching = CachingType.ReadWrite,
                            ManagedDisk = new()
                            {
                                StorageAccountType = StorageAccountType.StandardLrs
                            }
                        },
                        ImageReference = new()
                        {
                            Publisher = "Canonical",
                            Offer = "UbuntuServer",
                            Sku = "16.04-LTS",
                            Version = "latest"
                        }
                    },
                    NetworkProfile = new()
                    {
                        NetworkInterfaceConfigurations =
                        {
                            new("example")
                            {
                                Primary = true,
                                IPConfigurations =
                                {
                                    new("internal")
                                    {
                                        Primary = true,
                                        Subnet = new WritableSubResource()
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
        #endregion
    }
}
