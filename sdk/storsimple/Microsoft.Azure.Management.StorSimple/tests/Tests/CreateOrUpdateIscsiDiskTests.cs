namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    /// <summary>
    /// Class represents tests for fileshare
    /// </summary>
    public class CreateOrUpdateIscsiDiskTests : StorSimpleTestBase
    {
        #region Construtor
        public CreateOrUpdateIscsiDiskTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion #region Construtor

        #region Test methods

        /// <summary>
        /// Test method to create, update and delete filshare
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateIscsiDisk()
        {
            try
            {
                var iSCSIServers = TestUtilities.GetIscsiServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    iSCSIServers != null && iSCSIServers.Any(),
                    $"No iscsiservers were found in the manger {this.ManagerName}");

                // Select the first iscsiserver
                var iscsiServer = iSCSIServers.First();

                // Create a iscsidisk with Tiered data policy
                var iscsiDisk = new ISCSIDisk(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName, 
                    "Auto-TestIscsiDisk1");
                iscsiDisk.Initialize(DataPolicy.Tiered);

                var iscsiDiskCreated = iscsiDisk.CreateOrUpdate(
                    iscsiServer.Name,
                    iscsiServer.Name);

                // Create a iscsidisk with tiered data policy
                var iscsiDisk2 = new ISCSIDisk(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName, 
                    "Auto-TestIscsiDisk2");
                iscsiDisk2.Initialize(DataPolicy.Tiered);

                var iscsiDiskCreated2 = iscsiDisk2.CreateOrUpdate(
                    iscsiServer.Name,
                    iscsiServer.Name);

                // Update Description and ShareStatus
                iscsiDiskCreated.Description = "Updated: " + iscsiDiskCreated.Description;
                iscsiDiskCreated.DiskStatus = DiskStatus.Offline;
                iscsiDiskCreated = iscsiDiskCreated.CreateOrUpdate(
                    iscsiServer.Name,
                    iscsiServer.Name);

                // Validate iscsi disks by Managers
                var iscsiDisksByIscsiServer = this.Client.IscsiDisks.ListByIscsiServer(
                    iscsiServer.Name,
                    iscsiServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);

                var iscsiDisksByDevice = this.Client.IscsiDisks.ListByDevice(
                    iscsiServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
            #endregion Test methods
        }
    }
}
