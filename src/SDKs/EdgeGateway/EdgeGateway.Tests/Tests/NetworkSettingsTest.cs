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
