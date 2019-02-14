namespace EdgeGateway.Tests
{
    using Microsoft.Azure.Management.EdgeGateway.Models;
    using Xunit;
    using Xunit.Abstractions;
    using Microsoft.Azure.Management.EdgeGateway;
    public class DeviceExtendedInfoTests : EdgeGatewayTestBase
    {
        #region Constructor
        public DeviceExtendedInfoTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_GetExtendedInformation()
        {
            // Get the extended information.
            var extendedInfo = Client.Devices.GetExtendedInformation(TestConstants.GatewayResourceName,  TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods

    }
}
