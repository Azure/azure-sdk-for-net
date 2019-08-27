using Microsoft.Azure.Management.EdgeGateway;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for alerts APIs
    /// </summary>
    public class AlertTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Initializes the instance to test alert APIs
        /// </summary>
        public AlertTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests alert list and get APIs
        /// </summary>
        [Fact]
        public void Test_Alerts()
        {
            string contiunationToken = null;
            // Get the list of alerts in the device.
            var alerts = TestUtilities.ListAlerts(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, out contiunationToken);

            if (contiunationToken != null)
            {
                // Get the list of remaining alerts in the device.
                alerts = TestUtilities.ListAlertsNext(Client, contiunationToken, out contiunationToken);
            }

            if (alerts != null && alerts.Count() > 0)
            {
                // Get one alert by name
                var alert = Client.Alerts.Get(TestConstants.GatewayResourceName, alerts.ToList().First().Name, TestConstants.DefaultResourceGroupName);
            }
        }

        #endregion Test Methods
    }
}
