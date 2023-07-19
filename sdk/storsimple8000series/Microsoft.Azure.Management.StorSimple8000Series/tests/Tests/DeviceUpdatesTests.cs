using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class DeviceUpdatesTests : StorSimpleTestBase
    {
        public DeviceUpdatesTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestDeviceUpdates()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DeviceForUpdateTests);
            var deviceName = device.Name;

            //Scan for updates
            ScanForUpdates(deviceName);

            //Get update summary
            var updateSummary = GetUpdateSummary(deviceName);

            if (updateSummary.RegularUpdatesAvailable == true)
            {
                //Install updates
                InstallUpdates(deviceName);
            }
        }

        /// <summary>
        /// Get the update summary of a device.
        /// </summary>
        private Updates GetUpdateSummary(string deviceName)
        {
            var updateSummary = this.Client.Devices.GetUpdateSummary(
                deviceName,
                this.ResourceGroupName,
                this.ManagerName);

            return updateSummary;
        }

        /// <summary>
        /// Scan for new updates.
        /// </summary>
        private void ScanForUpdates(string deviceName)
        {
            this.Client.Devices.ScanForUpdates(
                deviceName,
                this.ResourceGroupName,
                this.ManagerName);
        }

        /// <summary>
        /// Install updates.
        /// </summary>
        private void InstallUpdates(string deviceName)
        {
            this.Client.Devices.InstallUpdates(
                deviceName,
                this.ResourceGroupName,
                this.ManagerName);
        }
    }
}
