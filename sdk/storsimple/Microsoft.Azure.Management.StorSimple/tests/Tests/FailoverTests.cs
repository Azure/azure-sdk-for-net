namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Class represents failover of file and iscsi servers
    /// </summary>
    public class FailoverTests : StorSimpleTestBase
    {
        #region Private Constructor

        public FailoverTests(ITestOutputHelper testOutputHelper) :
            base(testOutputHelper)
        { }

        #endregion Private Constructor

        /// <summary>
        /// Test method to failover fileserver
        /// </summary>
        [Fact]
        public void TestFileServerFailover()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(fileServers != null && fileServers.Count() > 0,
                    "No fileserver found in the given manager:" + this.ManagerName);

                var fileServer = fileServers.FirstOrDefault();

                // Ensure there is atleast one fileshare
                var fileShares = fileServer.GetFileShares(fileServer.Name);

                Assert.True(
                    fileShares != null && fileShares.Any(),
                    "No fileshares found on source device to failover");
                var fileShare = fileShares.First();

                // Backup so it can be used for fail over
                var backupSet = fileServer.BackupNow();

                Assert.True(backupSet != null, "No backups were created to clone");

                // Get the device that the fileserver belongs to
                var sourceDevice = TestUtilities.GetDeviceByFileServer(
                    fileServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Find a failover target device for a given device
                var targetDevices = sourceDevice.GetFailoverTargets();

                Assert.True(
                    targetDevices != null && targetDevices.Any(),
                    $"No device found as a failover target for the given device: {sourceDevice.Name}");

                // Take the first failover target device
                var targetDevice = targetDevices.FirstOrDefault();
                var accessPointIds = new List<string>()
                {
                    fileServer.Id
                };
                sourceDevice.Failover(accessPointIds, targetDevice.Id);

                var failoverFileServer = TestUtilities.GetFileServer(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    targetDevice.Name,
                    targetDevice.Name);

                var failoverShares = failoverFileServer.GetFileShares(targetDevice.Name);

                Assert.True(
                    failoverShares != null && failoverShares.Any(),
                    "No failed over shares found");

                var failoverShare = failoverShares.FirstOrDefault(d =>
                    d.Name.Equals(
                        fileShare.Name, 
                        StringComparison.CurrentCultureIgnoreCase));

                Assert.True(failoverShare != null, "Failover of Share failed");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Test method to failover iscsiserver
        /// </summary>
        [Fact]
        public void TestIscsiServerFailover()
        {
            try
            {
                var iscsiServers = TestUtilities.GetIscsiServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(iscsiServers != null && iscsiServers.Count() > 0,
                    "No iscsiServers found in the given manager:" + this.ManagerName);

                var iscsiServer = iscsiServers.FirstOrDefault();

                // Ensure there is atleast one fileshare
                var iscsiDisks = iscsiServer.GetIscsiDisks(iscsiServer.Name);

                Assert.True(
                    iscsiDisks != null && iscsiDisks.Any(),
                    "Found no iscsiDisks on source device to failover");

                var iscsiDisk = iscsiDisks.First();

                // Backup so it can be used for fail over
                var backupSet = iscsiServer.BackupNow();

                Assert.True(backupSet != null, "No backups were created to clone");

                // Get the device that the fileserver belongs to
                var sourceDevice = TestUtilities.GetDeviceByIscsiServer(
                    iscsiServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Find a failover target device for a given device
                var targetDevices = sourceDevice.GetFailoverTargets();

                Assert.True(
                    targetDevices != null && targetDevices.Any(),
                    $"No device found as a failover target for the given device: {sourceDevice.Name}");

                // Take the first failover target device
                var targetDevice = targetDevices.FirstOrDefault();
                var accessPointIds = new List<string>()
                {
                    iscsiServer.Id
                };
                sourceDevice.Failover(accessPointIds, targetDevice.Id);

                var failoverIscsiServer = TestUtilities.GetIsciServer(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    targetDevice.Name,
                    targetDevice.Name);

                var failoverDisks = failoverIscsiServer.GetIscsiDisks(targetDevice.Name);

                Assert.True(
                    failoverDisks != null && failoverDisks.Any(),
                    "No failed over disks found");

                var failoverDisk = failoverDisks.FirstOrDefault(d =>
                    d.Name.Equals(iscsiDisk.Name, StringComparison.CurrentCultureIgnoreCase));

                Assert.True(failoverDisk != null, "Failover of disk failed");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}
