namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;
    using System.Collections.Generic;

    /// <summary>
    ///  Class represents monitoring tests
    /// </summary>
    public class AlertsTests : StorSimpleTestBase
    {
        #region Constructor
        public AlertsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Test method to send test alert email
        /// </summary>
        [Fact]
        public void TestSendTestAlertEmailAPI()
        {
            try
            {
                // Using a specific manager for the test case.
                this.ManagerName = TestConstants.ManagerForAlertsAndDeviceUpdates;

                // Get a device scoped alert and clear
                var alert = GetADeviceScopedAlert();

                var emailList = new List<string>() { "testemailid@contoso.com" };
                var sendTestAlertEmailRequest = new SendTestAlertEmailRequest(emailList);

                TestUtilities.SendEmail(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    alert.Source.Name,
                    sendTestAlertEmailRequest);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }


        /// <summary>
        /// Test method to get alert and clear
        /// </summary>
        [Fact]
        public void TestClearAlerts()
        {
            try
            {
                // Using a specific manager for the test case.
                this.ManagerName = TestConstants.ManagerForAlertsAndDeviceUpdates;

                var alert = GetADeviceScopedAlert();
                TestUtilities.ClearAlerts(this.Client, this.ResourceGroupName, this.ManagerName, alert.Id);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test Methods


        #region Private method

        /// <summary>
        /// Returns first device scoped alert
        /// </summary>
        /// <returns></returns>
        private Alert GetADeviceScopedAlert()
        {
            Expression<Func<AlertFilter, bool>> filterExp = filter =>
                filter.Status == AlertStatus.Active &&
                filter.Severity == AlertSeverity.Critical;

            var alertFilters = new ODataQuery<AlertFilter>(filterExp);
            alertFilters.Top = 1;

            var alerts = TestUtilities.GetAlerts(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                alertFilters);

            Assert.True(alerts != null && alerts.Any(), "No alerts found");
            return alerts.First();
        }

        #endregion Private method
    }
}

