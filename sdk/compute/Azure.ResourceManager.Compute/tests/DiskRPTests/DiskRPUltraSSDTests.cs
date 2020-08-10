// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPUltraSSDTests : DiskRPTestsBase
    {
        public DiskRPUltraSSDTests(bool isAsync)
       : base(isAsync)
        {
        }

        [Test]
        public async Task UltraSSD_CRUD_EmptyDiskZones()
        {
            await UltraSSD_CRUD_Helper(location: "eastus", methodName: "UltraSSD_CRUD_EmptyDiskZones", useZones: true);
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task UltraSSD_CRUD_EmptyDiskShared()
        {
            await UltraSSD_CRUD_Helper(location: "eastus2euap", methodName: "UltraSSD_CRUD_EmptyDiskShared", sharedDisks: true);
        }

        private async Task UltraSSD_CRUD_Helper(string location, string methodName, bool useZones = false, bool sharedDisks = false)
        {
            EnsureClientsInitialized(DefaultLocation);

            // Data
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = GenerateBaseDisk("Empty");
            disk.Sku = new DiskSku(DiskStorageAccountTypes.UltraSSDLRS, "Ultra");
            disk.DiskSizeGB = 32;
            if (useZones)
            {
                disk.Zones = new List<string> { "1" };
            }
            disk.DiskMBpsReadWrite = 8;
            disk.DiskIopsReadWrite = 512;
            disk.Location = location;
            if (sharedDisks)
            {
                disk.DiskIopsReadOnly = 512;
                disk.DiskMBpsReadOnly = 8;
                disk.MaxShares = 2;
            }
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(location));

            // Put
            Disk diskOut = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Validate(disk, diskOut, location);

            // Get
            diskOut = (await DisksOperations.GetAsync(rgName, diskName)).Value;
            Validate(disk, diskOut, location);

            // Patch
            const string tagKey = "tagKey";
            var updatedisk = new DiskUpdate();
            updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagValue" } };
            updatedisk.DiskMBpsReadWrite = 9;
            updatedisk.DiskIopsReadWrite = 600;
            if (sharedDisks)
            {
                updatedisk.DiskMBpsReadOnly = 9;
                updatedisk.DiskIopsReadOnly = 600;
                updatedisk.MaxShares = 3;
            }
            updatedisk.Sku = new DiskSku(DiskStorageAccountTypes.UltraSSDLRS, "Ultra");
            diskOut = await WaitForCompletionAsync(await DisksOperations.StartUpdateAsync(rgName, diskName, updatedisk));
            Validate(disk, diskOut, location, update: true);
            Assert.AreEqual(updatedisk.DiskIopsReadWrite, diskOut.DiskIopsReadWrite);
            Assert.AreEqual(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);
            if (sharedDisks)
            {
                Assert.AreEqual(updatedisk.DiskIopsReadOnly, diskOut.DiskIopsReadOnly);
                Assert.AreEqual(updatedisk.DiskMBpsReadOnly, diskOut.DiskMBpsReadOnly);
                Assert.AreEqual(updatedisk.MaxShares, diskOut.MaxShares);
            }

            // Get
            diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, location, update: true);
            Assert.AreEqual(updatedisk.DiskIopsReadWrite, diskOut.DiskIopsReadWrite);
            Assert.AreEqual(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);
            if (sharedDisks)
            {
                Assert.AreEqual(updatedisk.DiskIopsReadOnly, diskOut.DiskIopsReadOnly);
                Assert.AreEqual(updatedisk.DiskMBpsReadOnly, diskOut.DiskMBpsReadOnly);
                Assert.AreEqual(updatedisk.MaxShares, diskOut.MaxShares);
            }

            // Delete
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
            try
            {
                // Ensure it was really deleted
                await DisksOperations.GetAsync(rgName, diskName);
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                //Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }
    }
}
