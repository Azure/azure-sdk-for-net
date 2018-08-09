
using Microsoft.AzureStack.Management.Compute.Admin;
using Microsoft.AzureStack.Management.Compute.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class DiskTests : ComputeTestBase
    {
        private void ValidateDisk(Disk disk)
        {
            Assert.NotNull(disk);
            Assert.NotNull(disk.ActualSizeGB);
            Assert.NotNull(disk.ProvisionSizeGB);
            Assert.NotNull(disk.DiskSku);
            Assert.NotNull(disk.DiskType);
            Assert.NotNull(disk.SharePath);
            Assert.NotNull(disk.Status);
            Assert.NotNull(disk.UserResourceId);
            Assert.NotNull(disk.Type);
            Assert.NotNull(disk.Id);
            Assert.NotNull(disk.Name);
            Assert.NotNull(disk.Location);
            Assert.NotNull(disk.DiskId);
        }

        private void ValidateDiskTheSame(Disk diskRight, Disk diskLeft)
        {
            Assert.NotNull(diskRight);
            Assert.NotNull(diskLeft);

            Assert.True(diskRight.Id == diskLeft.Id);
        }

        private void ValidateDisksTheSame(IEnumerable<Disk> disksRight, IEnumerable<Disk> disksLeft)
        {
            Assert.NotNull(disksRight);
            Assert.NotNull(disksLeft);
            Assert.Equal(disksRight.Count(), disksLeft.Count());

            disksRight.ForEach(disk => Assert.True(IsDiskExistsInCollection(disk, disksLeft)));
        }

        private bool IsDiskExistsInCollection(Disk disk, IEnumerable<Disk> disks)
        {
            return disks.Any(diskInCollection => diskInCollection.UserResourceId.Equals(disk.UserResourceId, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void TestListDisks()
        {
            RunTest((client) => {
                var disks = client.Disks.List(Location);
                disks.ForEach(ValidateDisk);

                if(disks.Count()>0)
                {
                    var firstDisk = disks.First();
                    var tenantSubscriptionId = firstDisk.UserResourceId.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];

                    var disksForSubscription = client.Disks.List(Location, userSubscriptionId: tenantSubscriptionId);
                    ValidateDisksTheSame(disks.Where(disk => disk.UserResourceId.Contains(tenantSubscriptionId)), disksForSubscription);

                    var disksForStatus = client.Disks.List(Location, status: firstDisk.Status);
                    ValidateDisksTheSame(disks.Where(disk => disk.Status.Equals(firstDisk.Status, StringComparison.OrdinalIgnoreCase)), disksForStatus);

                    var disksForShare = client.Disks.List(Location, sharePath: firstDisk.SharePath);
                    ValidateDisksTheSame(disks.Where(disk => disk.SharePath.Equals(firstDisk.SharePath, StringComparison.OrdinalIgnoreCase)), disksForShare);

                    if (disks.Count() >= 2)
                    {
                        var disksWithCountAndStart = client.Disks.List(Location, count: 1, start: 1);
                        ValidateDisksTheSame(new List<Disk>() { disks.ElementAt(1) }, disksWithCountAndStart);
                    }
                }
            });
        }

        [Fact]
        public void TestGetDisk()
        {
            RunTest((client) => {
                var disks = client.Disks.List(Location);
                disks.ForEach(ValidateDisk);

                if (disks.Count() > 0)
                {
                    var firstDisk = disks.First();
                    var diskFromServer = client.Disks.Get(Location, firstDisk.DiskId);
                    ValidateDiskTheSame(firstDisk, diskFromServer);
                }
            });
        }

        [Fact]
        public void TestGetDiskInvalid()
        {
            RunTest((client) => {
                ValidateExpectedReturnCode(
                    () => client.Disks.Get(Location, "454E5E28-8D5E-41F9-929E-BFF6A7E1A253"),
                    HttpStatusCode.NotFound);
            });
        }
    }
}
