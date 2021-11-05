using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPUltraSSDTests : DiskRPTestsBase
    {
        [Fact]
        public void UltraSSD_CRUD_EmptyDiskZones()
        {
            UltraSSD_CRUD_Helper(location: "eastus", methodName: "UltraSSD_CRUD_EmptyDiskZones", useZones: true);
        }

        [Fact]
        public void UltraSSD_CRUD_EmptyDiskShared()
        {
            UltraSSD_CRUD_Helper(location: "eastus", methodName: "UltraSSD_CRUD_EmptyDiskShared", sharedDisks: true);
        }

        [Fact]
        public void UltraSSD_CRUD_LogicalSectorSize()
        {
            UltraSSD_CRUD_Helper(location: "eastus2euap", methodName: "UltraSSD_CRUD_LogicalSectorSize", enable512E: true);
        }

        private void UltraSSD_CRUD_Helper(string location, string methodName, bool useZones = false, bool sharedDisks = false, bool enable512E = false)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateBaseDisk("Empty");
                disk.Sku = new DiskSku(DiskStorageAccountTypes.UltraSSDLRS, "Ultra");
                disk.DiskSizeGB = 32;
                if (useZones)
                {
                    disk.Zones = new List<string> { "1" };
                }
                disk.DiskMBpsReadWrite = 8;
                disk.DiskIOPSReadWrite = 512;
                disk.Location = location;
                if (sharedDisks)
                {
                    disk.DiskIOPSReadOnly = 512;
                    disk.DiskMBpsReadOnly = 8;
                    disk.MaxShares = 2;
                }
                if (enable512E)
                {
                    disk.CreationData.LogicalSectorSize = 512;
                }
                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

                    // Put
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Validate(disk, diskOut, location);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, location);
                    if (enable512E)
                    {
                        Assert.Equal(512, diskOut.CreationData.LogicalSectorSize);
                    }
                    else
                    {
                        Assert.Equal(4096, diskOut.CreationData.LogicalSectorSize);
                    }
                    // Patch
                    const string tagKey = "tagKey";
                    var updatedisk = new DiskUpdate();
                    updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagValue" } };
                    updatedisk.DiskMBpsReadWrite = 9;
                    updatedisk.DiskIOPSReadWrite = 600;
                    if (sharedDisks)
                    {
                        updatedisk.DiskMBpsReadOnly = 9;
                        updatedisk.DiskIOPSReadOnly = 600;
                        updatedisk.MaxShares = 3;
                    }
                    updatedisk.Sku = new DiskSku(DiskStorageAccountTypes.UltraSSDLRS, "Ultra");
                    diskOut = m_CrpClient.Disks.Update(rgName, diskName, updatedisk);
                    Validate(disk, diskOut, location, update: true);
                    Assert.Equal(updatedisk.DiskIOPSReadWrite, diskOut.DiskIOPSReadWrite);
                    Assert.Equal(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);
                    if (sharedDisks)
                    {
                        Assert.Equal(updatedisk.DiskIOPSReadOnly, diskOut.DiskIOPSReadOnly);
                        Assert.Equal(updatedisk.DiskMBpsReadOnly, diskOut.DiskMBpsReadOnly);
                        Assert.Equal(updatedisk.MaxShares, diskOut.MaxShares);
                    }

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, location, update: true);
                    Assert.Equal(updatedisk.DiskIOPSReadWrite, diskOut.DiskIOPSReadWrite);
                    Assert.Equal(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);
                    if (sharedDisks)
                    {
                        Assert.Equal(updatedisk.DiskIOPSReadOnly, diskOut.DiskIOPSReadOnly);
                        Assert.Equal(updatedisk.DiskMBpsReadOnly, diskOut.DiskMBpsReadOnly);
                        Assert.Equal(updatedisk.MaxShares, diskOut.MaxShares);
                    }
                    if (enable512E)
                    {
                        Assert.Equal(512, diskOut.CreationData.LogicalSectorSize);
                    }
                    else
                    {
                        Assert.Equal(4096, diskOut.CreationData.LogicalSectorSize);
                    }
                    // Delete
                    m_CrpClient.Disks.Delete(rgName, diskName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.Disks.Get(rgName, diskName);
                        Assert.False(true);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

    }
}

