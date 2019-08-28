using Microsoft.Azure.Management.EdgeGateway;
using Xunit;
using Xunit.Abstractions;


namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for device update APIs
    /// </summary>
    public class DeviceUpdatesTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test device update APIs
        /// </summary>
        public DeviceUpdatesTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests download  device updates APIs.
        /// </summary>
        [Fact]
        public void Test_GetAndDownloadUpdates()
        {
            // Get the update summary.
            var updateSummary = Client.Devices.GetUpdateSummary(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Scan the device for updates.
            Client.Devices.ScanForUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Download the updates in the device.
            // This is a long running operation and may take upto hours. 
            Client.Devices.DownloadUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Get the update summary.
            updateSummary = Client.Devices.GetUpdateSummary(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);


        }


        /// <summary>
        /// Tests install  device updates APIs.
        /// </summary>
        [Fact]
        public void Test_InstallUpdates()
        {
            // Install updates in the device.
            // This is a long running operation and may take upto hours. 
            Client.Devices.InstallUpdates(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Get the update summary.
            var updateSummary = Client.Devices.GetUpdateSummary(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods
    }
}

