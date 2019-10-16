namespace StorSimple1200Series.Tests
{
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;
    using Xunit.Abstractions;


    /// <summary>
    /// Class represents tests for backup and clone of file and iscsi servers
    /// </summary>
    public class BackupAndCloneTests : StorSimpleTestBase
    {
        #region Constructor

        public BackupAndCloneTests(ITestOutputHelper testOutputHelper) :
            base(testOutputHelper)
        { }

        #endregion Constructor

        #region Test methods
        /// <summary>
        /// Test method to backup a fileserver and clone a fileshare
        /// </summary>
        [Fact]
        public void TestFileServerBackupAndClone()
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

                // Get atleast one share
                var fileShares = fileServer.GetFileShares(fileServer.Name);
                var fileShare = fileShares.First();

                // Create a backup
                var backupSet = fileServer.BackupNow();

                Assert.True(backupSet != null, "No backups were created to clone");

                // Using the backup - clone the fileshare
                backupSet.Clone(
                    fileServer.Name,
                    fileServer,
                    backupSet.Elements[0].Name,
                    TestConstants.DefaultClonedTieredFileShareName);

                // Verify the new share is returned as list of shares
                var fileSharesPostClone = fileServer.GetFileShares(fileServer.Name);

                var restoredFileShare = fileSharesPostClone.FirstOrDefault(
                    s => s.Name.Equals(
                        TestConstants.DefaultClonedTieredFileShareName,
                        StringComparison.CurrentCultureIgnoreCase));

                Assert.True(
                    restoredFileShare != null,
                    "Cloned fileshare was not found:" + TestConstants.DefaultClonedTieredFileShareName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Test method to backup iscsi server and clone a disk
        /// </summary>
        [Fact]
        public void TestIscsiServerBackupAndClone()
        {
            try
            {
                var iscsiServers = TestUtilities.GetIscsiServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(iscsiServers != null && iscsiServers.Count() > 0,
                    "No iscsiserver found in the given manager:" + this.ManagerName);

                var iscsiServer = iscsiServers.FirstOrDefault();
                var iscsiDisks = iscsiServer.GetIscsiDisks(iscsiServer.Name);

                Assert.True(
                    iscsiDisks != null && iscsiDisks.Any(),
                    "No IscsiDisks found");

                // Create a backup
                var backupSet = iscsiServer.BackupNow();

                // Create cloned disk
                backupSet.Clone(
                    iscsiServer.Name,
                    iscsiServer,
                    backupSet.Elements[0].Name,
                    TestConstants.DefaultClonedTieredIscsiDiskName);

                // Verify that new disk is returned in list of disks
                var iscsiDiskPostClone = iscsiServer.GetIscsiDisks(iscsiServer.Name);

                var restoredIscsiDisk = iscsiDiskPostClone.FirstOrDefault(
                    s => s.Name.Equals(
                        TestConstants.DefaultClonedTieredIscsiDiskName,
                        StringComparison.CurrentCultureIgnoreCase));

                Assert.True(
                    restoredIscsiDisk != null,
                    "Cloned iscsidisk not found:" + TestConstants.DefaultClonedTieredIscsiDiskName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestGetBackupsAndDelete()
        {
            DateTime createdTime = DateTime.Parse(TestConstants.BackupsCreatedTime);
            DateTime endTime = DateTime.Parse(TestConstants.BackupsEndTime);
            string deviceName = "HSDK-UGU4PITWNI";

            //Query for a backup
           Expression < Func<BackupFilter, bool> > filter =
               backupFilter =>
                backupFilter.CreatedTime >= createdTime && 
                backupFilter.CreatedTime <=  endTime && 
                backupFilter.InitiatedBy == InitiatedBy.Manual;

           var backups = TestUtilities.GetBackupsByManager(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                new ODataQuery<BackupFilter>(filter));

            Assert.True(backups != null && backups.Any(),
                "No backups were found");

            // Delete the any(first) backup
            TestUtilities.DeleteBackup(
                backups.First().Name,
                deviceName,
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);

            var backupsAfterDelete = TestUtilities.GetBackupsByManager(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                new ODataQuery<BackupFilter>(filter));

            var deletedBackup = backupsAfterDelete.FirstOrDefault(
                b => b.Name.Equals(backups.First().Name, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(deletedBackup == null, "Deletion of Backup failed");
        }

        #endregion Test methods
    }
}
