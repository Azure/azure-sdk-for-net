using Microsoft.Azure.Management.EdgeGateway;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for network settings APIs
    /// </summary>
    public class NetworkSettingsTest : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test network settings APIs
        /// </summary>
        public NetworkSettingsTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests network settings create, update, get, list and delete APIs
        /// </summary>
        [Fact]
        public void Test_GetNetworkSettings()
        {
            // Get the device network settings.
            var NetworkSettings = Client.Devices.GetNetworkSettings(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods
    }
}

