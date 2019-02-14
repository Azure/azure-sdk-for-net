using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;


namespace EdgeGateway.Tests
{
    public class DeviceUpdatesTests : EdgeGatewayTestBase
    {
        #region Constructor
        public DeviceUpdatesTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_GetAndInstallUpdates()
        {
            // Get the update summary.
            var updateSummary = Client.Devices.GetUpdateSummary(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Scan the device for updates.
            Client.Devices.ScanForUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Download the updates in the device.
            Client.Devices.DownloadUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Install updates in the device.
            // Client.Devices.InstallUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Get the update summary.
            updateSummary = Client.Devices.GetUpdateSummary(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);


        }

        #endregion Test Methods
    }
}
