namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    /// <summary>
    /// Class represents file server tests
    /// </summary>
    public class DeleteFileServerTests : StorSimpleTestBase
    {
        #region Constructor

        public DeleteFileServerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods
        /// <summary>
        /// Test method to create and update fileserver
        /// </summary>
        [Fact]
        public void TestDeleteFileServer()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    fileServers != null && fileServers.Any(),
                    $"No fileservers were found in the manger {this.ManagerName}");

                // Select the first fileserver
                var fileServer = fileServers.First();

                // Get the associated storage domain
                StorageDomain sd = TestUtilities.GetStorageDomainById(
                    fileServer.StorageDomainId,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Get the associated BackupScheduleGroup
                var backupScheduleGroup = TestUtilities.GetBackupScheduleGroupById(
                    fileServer.BackupScheduleGroupId,
                    fileServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete FileServer
                TestUtilities.DeleteAndValidateFileServer(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    fileServer.Name,
                    fileServer.Name);

                // Delete storage domain
                TestUtilities.DeleteStorageDomain(
                    sd.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete BackupScheduleGroup
                TestUtilities.DeleteBackupScheduleGroup(
                    backupScheduleGroup.Name,
                    fileServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test methods
    }
}
