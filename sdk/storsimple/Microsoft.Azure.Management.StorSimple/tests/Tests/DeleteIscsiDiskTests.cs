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
    public class IscsiDiskTests : StorSimpleTestBase
    {
        #region Construtor
        public IscsiDiskTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion #region Construtor

        #region Test methods

        /// <summary>
        /// Test method to create, update and delete filshare
        /// </summary>
        [Fact]
        public void TestDeleteIscsiDisk()
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

                // Validate iscsi disks by Managers
                var iscsiDisks = this.Client.IscsiDisks.ListByIscsiServer(
                    iscsiServer.Name,
                    iscsiServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);

                var iscsiDisksByDevice = this.Client.IscsiDisks.ListByDevice(
                    iscsiServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete IscsiDisks
                foreach (var iscsiDisk in iscsiDisks)
                {
                    TestUtilities.DeleteAndValidateIscsiDisk(
                        this.Client,
                        this.ResourceGroupName,
                        this.ManagerName,
                        iscsiDisk.Name,
                        iscsiServer.Name,
                        iscsiServer.Name);
                }

            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
            #endregion Test methods
        }
    }
}
