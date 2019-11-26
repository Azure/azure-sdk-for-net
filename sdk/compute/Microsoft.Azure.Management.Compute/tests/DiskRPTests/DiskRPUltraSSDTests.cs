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
        //direct drive is only enabled in eastus2euap
        private static string DiskRPLocation = "eastus2";

        [Fact]
        public void UltraSSD_CRUD_EmptyDisk()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateBaseDisk("Empty");
                disk.Sku = new DiskSku(DiskStorageAccountTypes.UltraSSDLRS, "Ultra");
                disk.DiskSizeGB = 256;
                disk.Zones = new List<string> { "1" };
                disk.DiskMBpsReadWrite = 8;
                disk.DiskIOPSReadWrite = 512;
                disk.Location = DiskRPLocation;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    
                    // Put
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Validate(disk, diskOut, DiskRPLocation);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, DiskRPLocation);

                    // Patch
                    const string tagKey = "tagKey";
                    var updatedisk = new DiskUpdate();
                    updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagValue" } };
                    updatedisk.DiskMBpsReadWrite = 9;
                    updatedisk.DiskIOPSReadWrite = 600;
                    diskOut = m_CrpClient.Disks.Update(rgName, diskName, updatedisk);
                    Validate(disk, diskOut, DiskRPLocation, update : true);
                    Assert.Equal(updatedisk.DiskIOPSReadWrite, diskOut.DiskIOPSReadWrite);
                    Assert.Equal(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, DiskRPLocation, update: true);
                    Assert.Equal(updatedisk.DiskIOPSReadWrite, diskOut.DiskIOPSReadWrite);
                    Assert.Equal(updatedisk.DiskMBpsReadWrite, diskOut.DiskMBpsReadWrite);

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

