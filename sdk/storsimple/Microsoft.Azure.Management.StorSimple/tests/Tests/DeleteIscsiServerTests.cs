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
    public class DeleteIscsiServerTests : StorSimpleTestBase
    {
        #region Constructor

        public DeleteIscsiServerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods
        /// <summary>
        /// Test method to create and update IscsiServer
        /// </summary>
        [Fact]
        public void TestDeleteIscsiServer()
        {
            try
            {
                var iscsiServers = TestUtilities.GetIscsiServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    iscsiServers != null && iscsiServers.Any(),
                    $"No IscsiServers were found in the manger {this.ManagerName}");

                // Select the first IscsiServer
                var IscsiServer = iscsiServers.First();

                // Get the associated storage domain
                StorageDomain sd = TestUtilities.GetStorageDomainById(
                    IscsiServer.StorageDomainId,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Get the associated BackupScheduleGroup
                var backupScheduleGroup = TestUtilities.GetBackupScheduleGroupById(
                    IscsiServer.BackupScheduleGroupId,
                    IscsiServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete IscsiServer
                TestUtilities.DeleteAndValidateIscsiServer(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    IscsiServer.Name,
                    IscsiServer.Name);

                // Delete storage domain
                TestUtilities.DeleteStorageDomain(
                    sd.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete BackupScheduleGroup
                TestUtilities.DeleteBackupScheduleGroup(
                    backupScheduleGroup.Name,
                    IscsiServer.Name,
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
