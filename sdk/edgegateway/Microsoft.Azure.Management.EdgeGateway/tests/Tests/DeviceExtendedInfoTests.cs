namespace EdgeGateway.Tests
{
    using Microsoft.Azure.Management.EdgeGateway.Models;
    using Xunit;
    using Xunit.Abstractions;
    using Microsoft.Azure.Management.EdgeGateway;

    /// <summary>
    /// Contains the tests for device extended information APIs
    /// </summary>
    public class DeviceExtendedInfoTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Initializes the instance to test device extended information APIs
        /// </summary>
        public DeviceExtendedInfoTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests device extended information APIs
        /// </summary>
        [Fact]
        public void Test_GetExtendedInformation()
        {
            // Get the extended information.
            var extendedInfo = Client.Devices.GetExtendedInformation(TestConstants.GatewayResourceName,  TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods

    }
}

