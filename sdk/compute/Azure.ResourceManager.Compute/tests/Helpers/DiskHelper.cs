// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class DiskHelper
    {
        public static void AssertDisk(DiskData disk1, DiskData disk2)
        {
            Assert.AreEqual(disk1.Name, disk2.Name);
            Assert.AreEqual(disk1.Id, disk2.Id);
            Assert.AreEqual(disk1.BurstingEnabled, disk2.BurstingEnabled);
            Assert.AreEqual(disk1.DiskAccessId, disk2.DiskAccessId);
            Assert.AreEqual(disk1.DiskIopsReadOnly, disk2.DiskIopsReadOnly);
            Assert.AreEqual(disk1.DiskIopsReadWrite, disk2.DiskIopsReadWrite);
            Assert.AreEqual(disk1.DiskSizeGB, disk2.DiskSizeGB);
            Assert.AreEqual(disk1.ManagedBy, disk2.ManagedBy);
            Assert.AreEqual(disk1.Encryption?.DiskEncryptionSetId, disk2.Encryption?.DiskEncryptionSetId);
            Assert.AreEqual(disk1.Encryption?.Type, disk2.Encryption?.Type);
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

        public static DiskData GetEmptyDiskData(Location location, IDictionary<string, string> tags = null)
        {
            return new DiskData(location)
            {
                Sku = new DiskSku()
                {
                    Name = DiskStorageAccountTypes.StandardLRS
                },
                CreationData = new CreationData(DiskCreateOption.Empty),
                DiskSizeGB = 1,
            };
        }
    }
}
