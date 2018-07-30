// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class SecurityAlertsTests : TestBase
    {
        #region Test setup

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region Alerts

        [Fact]
        public void SecurityAlerts_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = securityCenterClient.Alerts.List();
                ValidateAlerts(alerts);
            }
        }

        [Fact]
        public void SecurityAlerts_GetResourceGroupLevelAlerts()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alert = securityCenterClient.Alerts.GetResourceGroupLevelAlerts("2518710774294070750_FFF23C70-80EF-4A8B-9122-507B0EA8DFFF", "RSG");
                ValidateAlert(alert);
            }
        }

        [Fact]
        public void SecurityAlerts_GetSubscriptionLevelAlert()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alert = securityCenterClient.Alerts.GetSubscriptionLevelAlert("2518710774894070750_EEE23C70-80EF-4A8B-9122-507B0EA8DFFF");
                ValidateAlert(alert);
            }
        }

        [Fact]
        public void SecurityAlerts_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = securityCenterClient.Alerts.ListByResourceGroup("RSG");
                ValidateAlerts(alerts);
            }
        }

        [Fact]
        public void SecurityAlerts_ListResourceGroupLevelAlertsByRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = securityCenterClient.Alerts.ListResourceGroupLevelAlertsByRegion("RSG");
                ValidateAlerts(alerts);
            }
        }

        [Fact]
        public void SecurityAlerts_ListSubscriptionLevelAlertsByRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = securityCenterClient.Alerts.ListSubscriptionLevelAlertsByRegion();
                ValidateAlerts(alerts);
            }
        }

        [Fact]
        public void SecurityAlerts_UpdateResourceGroupLevelAlertState()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.Alerts.UpdateResourceGroupLevelAlertState("2518710774294070750_FFF23C70-80EF-4A8B-9122-507B0EA8DFFF", "Dismiss", "RSG");
            }
        }

        [Fact]
        public void SecurityAlerts_UpdateSubscriptionLevelAlertState()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.Alerts.UpdateSubscriptionLevelAlertState("2518710774894070750_EEE23C70-80EF-4A8B-9122-507B0EA8DFFF", "Dismiss");
            }
        }

        #endregion

        #region Validations

        private void ValidateAlerts(IPage<Alert> alertPage)
        {
            Assert.True(alertPage.IsAny());

            alertPage.ForEach(ValidateAlert);
        }

        private void ValidateAlert(Alert alert)
        {
            Assert.NotNull(alert);
        }

        #endregion
    }
}
