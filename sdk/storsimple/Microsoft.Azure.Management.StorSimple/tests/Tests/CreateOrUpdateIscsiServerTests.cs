namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    /// <summary>
    /// Class represents iscsi server
    /// </summary>
    public class CreateOrUpdateIscsiServerTests : StorSimpleTestBase
    {
        #region Constructor

        public CreateOrUpdateIscsiServerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods

        /// <summary>
        /// Test method to create iscsi server
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateIscsiServer()
        {
            try
            {
                //Check if atleast a device is registered to the manager.
                var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.ReadyToSetup, 1);

                Assert.True(devices != null && devices.FirstOrDefault() != null,
                        "No devices were found to be registered in the manger:" + this.ManagerName);

                // Get the first device
                Device device = devices.FirstOrDefault();

                var sacCreated = TestUtilities.GetStorageAccountCredential(
                    this.Client,
                    TestConstants.DefaultSacName,
                    this.ResourceGroupName,
                    this.ManagerName);

                var storageDomain = TestUtilities.GetStorageDomain(
                    TestConstants.DefaultStorageDomainIscsiServerNamePrefix + device.Name,
                    sacCreated.Id,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    storageDomain != null,
                    $"StorageDomain not found: {storageDomain.Name}");

                // Create BackupScheduleGroup
                var bsg = TestUtilities.GetBackupScheduleGroup(
                    device.Name,
                    TestConstants.DefaultBackupSchGroupName,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Create IscsiServer
                var iscsiServer = new ISCSIServer(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    device.Name);
                iscsiServer.Initialize(storageDomain.Id, bsg.Id);
                var iscsiServerCreated = iscsiServer.CreateOrUpdate(device.Name);

                iscsiServerCreated.Description = "Updated desc of the iscsiServer";
                iscsiServerCreated.CreateOrUpdate(iscsiServer.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }

        }

        /// <summary>
        /// Test method to create or update ChapSettings
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateChapSettings()
        {
            var iscsiServers = TestUtilities.GetIscsiServers(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(iscsiServers != null && iscsiServers.Count() > 0,
                "No iscsiserver found in the given manager:" + this.ManagerName);

            var iscsiServer = iscsiServers.FirstOrDefault();

            var chapSettings = new ChapSettings(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                TestConstants.DefaultChapSettingName);

            chapSettings.Initialize();
            var chapSettingsCreated = chapSettings.CreateOrUpdate(iscsiServer.Name);

            var chapSettingsAfterGet = TestUtilities.GetChapSettings(
                chapSettings.Name,
                iscsiServer.Name,
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(chapSettingsAfterGet.Name.Equals(
                chapSettings.Name,
                StringComparison.CurrentCultureIgnoreCase),
                "ChapSettings created but not found");

            Assert.True(string.IsNullOrWhiteSpace(iscsiServer.ChapId),
                "ChapId already set");

            // Update the iscsiserver
            iscsiServer.ChapId = chapSettingsAfterGet.Id;
            var iscsiServerAfterUpdate = iscsiServer.CreateOrUpdate(iscsiServer.Name);

            Assert.True(
                iscsiServerAfterUpdate.ChapId.Equals(
                    chapSettingsAfterGet.Id,
                    StringComparison.CurrentCultureIgnoreCase),
                "ChapId failed to be set on IscsiServer");
        }


        /// <summary>
        /// Test to create and delete chap settings
        /// </summary>
        [Fact]
        public void TestDeleteChapSettings()
        {
            var iscsiServers = TestUtilities.GetIscsiServers(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(iscsiServers != null && iscsiServers.Count() > 0,
                "No iscsiserver found in the given manager:" + this.ManagerName);

            var iscsiServer = iscsiServers.FirstOrDefault();

            var chapSettings = new ChapSettings(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                TestConstants.DefaultChapSettingNameForDelete);

            chapSettings.Initialize();
            var chapSettingsCreated = chapSettings.CreateOrUpdate(iscsiServer.Name);

            var chapSettingsGet = TestUtilities.GetChapSettings(
                chapSettings.Name,
                iscsiServer.Name,
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);

            var chapSettingsList = iscsiServer.GetChapSettings(iscsiServer.Name);

            Assert.True(chapSettingsList != null && chapSettingsList.Any(),
                "No chapsettings found");

            var chapSettingToDelete = chapSettingsList.FirstOrDefault(cs =>
                        cs.Name.Equals(
                            chapSettings.Name,
                            StringComparison.CurrentCultureIgnoreCase));

            Assert.True(chapSettingToDelete != null, "ChapSetting to delete not found");

            // Delete the chap settings
            TestUtilities.DeleteChapSettings(
                chapSettingToDelete.Name,
                iscsiServer.Name,
                this.Client,
                this.ResourceGroupName,
                this.ManagerName);
        }

        #endregion Test methods
    }
}
