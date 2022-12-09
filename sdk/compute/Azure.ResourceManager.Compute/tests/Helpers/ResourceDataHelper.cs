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
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region AvailabilitySet
        public static void AssertAvailabilitySet(AvailabilitySetData set1, AvailabilitySetData set2)
        {
            AssertTrackedResource(set1, set2);
            Assert.AreEqual(set1.PlatformFaultDomainCount, set2.PlatformFaultDomainCount);
            Assert.AreEqual(set1.PlatformUpdateDomainCount, set2.PlatformUpdateDomainCount);
            Assert.AreEqual(set1.ProximityPlacementGroup, set2.ProximityPlacementGroup);
            Assert.AreEqual(set1.ProximityPlacementGroup?.Id, set2.ProximityPlacementGroup?.Id);
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
            Assert.AreEqual(group1.PlatformFaultDomainCount, group2.PlatformFaultDomainCount);
            Assert.AreEqual(group1.SupportAutomaticPlacement, group2.SupportAutomaticPlacement);
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
            Assert.AreEqual(host1.Sku.Name, host2.Sku.Name);
            Assert.AreEqual(host1.Sku.Tier, host2.Sku.Tier);
            Assert.AreEqual(host1.Sku.Capacity, host2.Sku.Capacity);
            Assert.AreEqual(host1.PlatformFaultDomain, host2.PlatformFaultDomain);
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
            Assert.AreEqual(disk1.BurstingEnabled, disk2.BurstingEnabled);
            Assert.AreEqual(disk1.DiskAccessId, disk2.DiskAccessId);
            Assert.AreEqual(disk1.DiskIopsReadOnly, disk2.DiskIopsReadOnly);
            Assert.AreEqual(disk1.DiskIopsReadWrite, disk2.DiskIopsReadWrite);
            Assert.AreEqual(disk1.DiskSizeGB, disk2.DiskSizeGB);
            Assert.AreEqual(disk1.ManagedBy, disk2.ManagedBy);
            Assert.AreEqual(disk1.Encryption?.DiskEncryptionSetId, disk2.Encryption?.DiskEncryptionSetId);
            Assert.AreEqual(disk1.Encryption?.EncryptionType, disk2.Encryption?.EncryptionType);
            Assert.AreEqual(disk1.CreationData?.CreateOption, disk2.CreationData?.CreateOption);
            Assert.AreEqual(disk1.CreationData?.ImageReference?.Id, disk2.CreationData?.ImageReference?.Id);
            Assert.AreEqual(disk1.CreationData?.ImageReference?.Lun, disk2.CreationData?.ImageReference?.Lun);
            Assert.AreEqual(disk1.CreationData?.GalleryImageReference?.Id, disk2.CreationData?.GalleryImageReference?.Id);
            Assert.AreEqual(disk1.CreationData?.GalleryImageReference?.Lun, disk2.CreationData?.GalleryImageReference?.Lun);
            Assert.AreEqual(disk1.CreationData?.LogicalSectorSize, disk2.CreationData?.LogicalSectorSize);
            Assert.AreEqual(disk1.CreationData?.SourceResourceId, disk2.CreationData?.SourceResourceId);
            Assert.AreEqual(disk1.CreationData?.SourceUniqueId, disk2.CreationData?.SourceUniqueId);
            Assert.AreEqual(disk1.CreationData?.SourceUri, disk2.CreationData?.SourceUri);
            Assert.AreEqual(disk1.CreationData?.StorageAccountId, disk2.CreationData?.StorageAccountId);
            Assert.AreEqual(disk1.CreationData?.UploadSizeBytes, disk2.CreationData?.UploadSizeBytes);
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
            Assert.AreEqual(gallery1.Description, gallery2.Description);
            Assert.AreEqual(gallery1.Identifier?.UniqueName, gallery2.Identifier?.UniqueName);
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
            Assert.AreEqual(image1.Identifier.Offer, image2.Identifier.Offer);
            Assert.AreEqual(image1.Identifier.Publisher, image2.Identifier.Publisher);
            Assert.AreEqual(image1.Identifier.Sku, image2.Identifier.Sku);
            Assert.AreEqual(image1.OSType, image2.OSType);
            Assert.AreEqual(image1.OSState, image2.OSState);
            Assert.AreEqual(image1.Description, image2.Description);
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
            Assert.AreEqual(vmss1.Id, vmss2.Id);
            Assert.AreEqual(vmss1.Name, vmss2.Name);
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
