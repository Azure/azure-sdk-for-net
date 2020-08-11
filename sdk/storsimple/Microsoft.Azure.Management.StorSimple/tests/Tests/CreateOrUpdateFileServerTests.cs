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
    public class CreateOrUpdateFileServerTests : StorSimpleTestBase
    {
        #region Constructor

        public CreateOrUpdateFileServerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods
        /// <summary>
        /// Test method to create and update fileserver
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateFileServer()
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

                // Create StorageDomain
                var storageDomain = TestUtilities.GetStorageDomain(
                    TestConstants.DefaultStorageDomainFileServerNamePrefix + device.Name,
                    sacCreated.Id,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    storageDomain != null,
                    $"StorageDomain not found: {storageDomain.Name}");

                // Create BackupScheduleGroup
                var bsg = new BackupScheduleGroup(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName,
                    TestConstants.DefaultBackupSchGroupName);
                bsg.Initialize();
                var bsgCreated = bsg.CreateOrUpdate(device.Name);

                // Create FileServer
                var fileServer = new FileServer(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName,
                    device.Name);
                fileServer.Initialize(storageDomain.Id, bsgCreated.Id);
                var fileServerCreated = fileServer.CreateOrUpdate(device.Name);

                 //Update FileServer
                fileServerCreated.Description = "Update description of fileserver";
                fileServerCreated.CreateOrUpdate(device.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test methods
    }
}
