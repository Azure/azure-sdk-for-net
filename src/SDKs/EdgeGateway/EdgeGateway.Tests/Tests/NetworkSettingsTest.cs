using Microsoft.Azure.Management.EdgeGateway;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    public class NetworkSettingsTest : EdgeGatewayTestBase
    {
        #region Constructor
        public NetworkSettingsTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_GetNetworkSettings()
        {
            // Get the device network settings.
            var NetworkSettings = Client.Devices.GetNetworkSettings(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods
    }
}
