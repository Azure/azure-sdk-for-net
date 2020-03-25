namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    public class DeviceUpdateTests : StorSimpleTestBase
    {
        #region Constructor

        public DeviceUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods

        /// <summary>
        /// Test method for scan and install device updates
        /// </summary>
        [Fact]
        public void TestDeviceUpdates()
        {
            // Specific manager for updates test case
            this.ManagerName = TestConstants.ManagerForAlertsAndDeviceUpdates;

            //checking for prerequisites
            var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.ReadyToSetup, 1);
            Assert.True(devices != null && devices.FirstOrDefault() != null,
                    "No online devices were found to be registered in the manger:" + this.ManagerName);

            var device = devices.First();

            //Scan for updates
            var updates = device.ScanForUpdates();

            if (updates.RegularUpdatesAvailable == true)
            {
                //Install updates
                device.InstallUpdates();
            }
        }

        /// <summary>
        /// Test method to validate device patch
        /// </summary>
        [Fact]
        public void TestDevicePatch()
        {
            var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.ReadyToSetup, 1);

            Assert.True(devices != null && devices.Any(), "No devices found");

            // Get the first device
            Device device = devices.First();

            Assert.True(string.IsNullOrEmpty(device.DeviceDescription), "Device description is not null");

            string newDescriptionPrefix = "NewDescription";
            string newDescription = newDescriptionPrefix + DateTime.Now.ToString();
            DevicePatch patchInput = new DevicePatch(newDescription);

            var deviceAfterUpdate = device.Patch(patchInput);

            Assert.True(
                deviceAfterUpdate.DeviceDescription.StartsWith(
                    newDescriptionPrefix, 
                    StringComparison.CurrentCultureIgnoreCase),
                "The device update failed");
        }
        #endregion Test methods

    }
}

