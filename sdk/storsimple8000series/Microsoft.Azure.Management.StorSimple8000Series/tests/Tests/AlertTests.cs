using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.Azure.OData;

namespace StorSimple8000Series.Tests
{
    public class AlertTests : StorSimpleTestBase
    {
        public AlertTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestAlerts()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;

            try
            {
                // Get Active Alerts with device name filter
                var alerts = GetActiveAlertsForDevice(deviceName);
                var firstAlert = alerts.First();

                // Clear Alert
                ClearAlert(firstAlert.Id);

                // Get Cleared Alerts
                GetClearedAlerts();

                //Test Severity Filters - Get warning alerts
                GetAlertsBySeverity(AlertSeverity.Warning);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestSendTestAlertEmailAPI()
        {
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;

            try
            {
                var emailList = new List<string>() { "testemailid@contoso.com" };

                var sendTestAlertEmailRequest = new SendTestAlertEmailRequest(emailList);

                this.Client.Alerts.SendTestEmail(
                    deviceName.GetDoubleEncoded(),
                    sendTestAlertEmailRequest,
                    this.ResourceGroupName,
                    this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private IPage<Alert> GetAlertsBySeverity(AlertSeverity severity)
        {
            var minTime = TestConstants.MinTimeForAlert;
            var maxTime = TestConstants.MaxTimeForAlert;

            Expression<Func<AlertFilter, bool>> filterExp = filter =>
                filter.AppearedOnTime >= minTime &&
                filter.AppearedOnTime <= maxTime &&
                filter.Severity == severity;

            var alertFilters = new ODataQuery<AlertFilter>(filterExp);
            alertFilters.Top = 100;

            var alerts = GetAlertsByFilters(alertFilters);

            Assert.True(alerts.Any(), "No Alerts found");

            return alerts;
        }

        private IPage<Alert> GetActiveAlertsForDevice(string deviceName)
        {
            var minTime = TestConstants.MinTimeForAlert;
            var maxTime = TestConstants.MaxTimeForAlert;

            Expression<Func<AlertFilter, bool>> filterExp = filter =>
                filter.Status == AlertStatus.Active &&
                filter.AppearedOnTime >= minTime &&
                filter.AppearedOnTime <= maxTime &&
                filter.SourceType == AlertSourceType.Device &&
                filter.SourceName == deviceName;

            var alertFilters = new ODataQuery<AlertFilter>(filterExp);
            alertFilters.Top = 100;

            var alerts = GetAlertsByFilters(alertFilters);

            Assert.True(alerts.Any(), "No Active Alerts found");

            return alerts;
        }

        private IPage<Alert> GetClearedAlerts()
        {
            var minTime = TestConstants.MinTimeForAlert;
            var maxTime = TestConstants.MaxTimeForAlert;

            Expression<Func<AlertFilter, bool>> filterExp = filter =>
                filter.Status == AlertStatus.Cleared &&
                filter.AppearedOnTime >= minTime &&
                filter.AppearedOnTime <= maxTime;

            var alertFilters = new ODataQuery<AlertFilter>(filterExp);
            alertFilters.Top = 100;

            var alerts = GetAlertsByFilters(alertFilters);

            Assert.True(alerts.Any(), "No Cleared Alerts found");

            return alerts;
        }

        private IPage<Alert> GetAlertsByFilters(ODataQuery<AlertFilter> filters)
        {
            return this.Client.Alerts.ListByManager(this.ResourceGroupName, this.ManagerName, filters);
        }

        private void ClearAlert(string alertId)
        {
            var clearAlertRequest = new ClearAlertRequest()
            {
                Alerts = new List<string>()
                    {
                        alertId
                    }
            };

            this.Client.Alerts.Clear(clearAlertRequest, this.ResourceGroupName, this.ManagerName);
        }
    }
}
