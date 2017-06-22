using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;

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